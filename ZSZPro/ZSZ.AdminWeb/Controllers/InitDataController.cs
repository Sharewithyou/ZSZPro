using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.Custom;

namespace ZSZ.AdminWeb.Controllers
{
    [NoAuthorize]
    [PermissionDes(Name = "数据初始化",IsNotShow =true)]
    public class InitDataController : Controller
    {
        public IInitDataService InitDataService {  get; set; }

        public ISysMenusService SysMenusService { get; set; }

        [PermissionDes(Name = "初始化管理员数据", IsNotShow = true)]
        public ActionResult Index()
        {
            //清空Session,cookie,cahce
            SessionHelper.ClearSession();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                HttpCookie cookie = new HttpCookie("ASP.NET_SessionId");
                cookie.Expires =DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }  
            
            CacheHelper.RemoveAllCache();        

            #region 初始化菜单
            MsgResult tempResult = new MsgResult();

            tempResult = SysMenusService.Clear(typeof(T_MenuPermissions).Name);
            tempResult = SysMenusService.Clear(typeof(T_SysMenus).Name);

            var nodes = MvcSiteMapProvider.SiteMaps.Current.FindSiteMapNodeFromKey("root").ChildNodes;
            int sortNum = 0;
            foreach (var node in nodes)
            {              
                if (!node.Clickable)
                {
                    sortNum += 20;
                    T_SysMenus menu = new T_SysMenus();
                    menu.Guid = Guid.NewGuid().ToString("N");
                    menu.MenuName = node.Title;
                    menu.MenuUrl = "";
                    menu.ParentId = 0;
                    menu.SortNum = sortNum;
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUser = 1;
                    menu.IconFont = (string)node.Attributes["iconfont"];
                    var result = SysMenusService.Add(menu);
                    if (result.IsSuccess)
                    {
                        int sort = 0;
                        T_SysMenus addMenu = JsonConvert.DeserializeObject<T_SysMenus>(result.Data);
                        var childNodes = node.ChildNodes;
                        List<T_SysMenus> menuList = new List<T_SysMenus>();
                        foreach (var childNode in childNodes)
                        {
                            sort += 20;
                            T_SysMenus menuNew = new T_SysMenus();
                            menuNew.Guid = Guid.NewGuid().ToString("N");
                            menuNew.MenuName = childNode.Title;
                            menuNew.MenuUrl = "/" + childNode.Controller + "/" + childNode.Action;
                            menuNew.ParentId = addMenu.Id;
                            menuNew.IsLeaf = true;
                            menuNew.CreateTime = DateTime.Now;
                            menuNew.SortNum = sort;
                            menuNew.CreateUser = 1;
                            menuList.Add(menuNew);
                        }

                        tempResult = SysMenusService.BatchAdd(menuList);
                    }

                }
            }

            #endregion

            #region 初始化权限操作列表

            List<T_SysOperations> list = new List<T_SysOperations>();

            //创建控制器类型列表
            List<Type> controllerTypes = new List<Type>();

            //加载程序集  
            var assembly = Assembly.Load("ZSZ.AdminWeb");

            controllerTypes.AddRange(assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) & type.IsDefined(typeof(PermissionDesAttribute))));

            foreach (var controller in controllerTypes)
            {
                //var controller = assembly.GetTypes().Where(type => type.Name == itemType.Name).FirstOrDefault();

                //获取控制器的标记属性
                var typeName = ((PermissionDesAttribute)controller.GetCustomAttributes(typeof(PermissionDesAttribute)).FirstOrDefault()).Name;

                //获取所有的标记方法
                var actions = controller.GetMethods().Where(method => method.IsDefined(typeof(PermissionDesAttribute)));

                foreach (var action in actions)
                {
                    var attribute = (PermissionDesAttribute)action.GetCustomAttributes(typeof(PermissionDesAttribute)).FirstOrDefault();
                    var operate = attribute.Name;
                    var isNotShow = attribute.IsNotShow;
                    var pName = attribute.BelongOperate ?? "";
                    T_SysOperations model = new T_SysOperations();
                    model.ContronllerName = controller.Name.Replace("Controller", "");
                    model.ActionName = action.Name;
                    model.TypeName = typeName;
                    model.OperateName = operate;
                    model.BelongOperate = pName;
                    model.Guid = Guid.NewGuid().ToString("N");
                    model.CreateUser = 1;
                    model.CreateTime = DateTime.Now;
                    if (isNotShow)
                        model.IsNotShow = true;
                    list.Add(model);
                }
            }

            #endregion

            InitDataService.InitData(list);

            return View();
        }
    }
}