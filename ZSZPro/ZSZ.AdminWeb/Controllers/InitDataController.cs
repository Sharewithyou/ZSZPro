using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
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
            #region 初始化菜单
            MsgResult tempResult = new MsgResult();

            tempResult = SysMenusService.Clear(typeof(T_MenuPermissions).Name);
            tempResult = SysMenusService.Clear(typeof(T_SysMenus).Name);

            var nodes = MvcSiteMapProvider.SiteMaps.Current.FindSiteMapNodeFromKey("root").ChildNodes;
            foreach (var node in nodes)
            {
                if (!node.Clickable)
                {
                    T_SysMenus menu = new T_SysMenus();
                    menu.Guid = Guid.NewGuid().ToString("N");
                    menu.MenuName = node.Title;
                    menu.MenuUrl = "";
                    menu.ParentId = 0;
                    menu.CreateTime = DateTime.Now;
                    menu.CreateUser = 1;
                    menu.IconFont = (string)node.Attributes["iconfont"];
                    var result = SysMenusService.Add(menu);
                    if (result.IsSuccess)
                    {
                        T_SysMenus addMenu = JsonConvert.DeserializeObject<T_SysMenus>(result.Data);
                        var childNodes = node.ChildNodes;
                        List<T_SysMenus> menuList = new List<T_SysMenus>();
                        foreach (var childNode in childNodes)
                        {
                            T_SysMenus menuNew = new T_SysMenus();
                            menuNew.Guid = Guid.NewGuid().ToString("N");
                            menuNew.MenuName = childNode.Title;
                            menuNew.MenuUrl = "/" + childNode.Controller + "/" + childNode.Action;
                            menuNew.ParentId = addMenu.Id;
                            menuNew.IsLeaf = true;
                            menuNew.CreateTime = DateTime.Now;
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
                    var attr = ((PermissionDesAttribute)action.GetCustomAttributes(typeof(PermissionDesAttribute)).FirstOrDefault()).Name;
                    var isNotShow = ((PermissionDesAttribute)action.GetCustomAttributes(typeof(PermissionDesAttribute)).FirstOrDefault()).IsNotShow;
                    T_SysOperations model = new T_SysOperations();
                    model.ContronllerName = controller.Name.Replace("Controller", "");
                    model.ActionName = action.Name;
                    model.TypeName = typeName;
                    model.OperateName = attr;
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