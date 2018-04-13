using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;
using AutoMapper;
using ZSZ.AdminWeb.Comm;
using ZSZ.AdminWeb.Models;
using ZSZ.Model.Models.Custom.Result;
using ZSZ.Model.Models.Custom;

namespace ZSZ.AdminWeb.Controllers
{
    [PermissionDes(Name = "菜单管理")]
    public class SysMenuManageController : BaseController
    {
        public ISysMenusService SysMenusService { get; set; }

        [PermissionDes(Name = "浏览")]
        // GET: SysMenuManage
        public ActionResult Index()
        {
            return View();
        }


        [PermissionDes(Name = "获取菜单树数据", BelongOperate = "浏览", IsNotShow = true)]
        public ActionResult GetMenuTreeNodeList()
        {
            var result = SysMenusService.GetZtreeNodeByUserId();
            return Json(result);
        }


        [PermissionDes(Name = "获取菜单节点详情数据", BelongOperate = "浏览", IsNotShow = true)]
        public ActionResult GetMenuTreeNode(int id)
        {
            var result = SysMenusService.GetZtreeNodeDetailById(id);
            return Json(result);
        }

        [PermissionDes(Name = "增加同级菜单页面", BelongOperate = "增加菜单", IsNotShow = true)]
        public ActionResult AddMenuPage(int id = 0)
        {
            T_SysMenus model = new T_SysMenus();
            if (id == 0)
            {
                model.Id = 0;
                model.MenuName = "根节点";
            }
            else
            {
                model = SysMenusService.GetModel(x => x.ParentId == id).FirstOrDefault();
            }
            return View(model);
        }


        [PermissionDes(Name = "跟新菜单页面", BelongOperate = "跟新菜单", IsNotShow = true)]
        public ActionResult UpdateMenuPage()
        {
            return View();
        }


        [PermissionDes(Name = "增加菜单")]
        public ActionResult AddMenuNode(SysMenu sysMenu)
        {          
            var result = SysMenusService.IsLackRuquiredMenuInfo(sysMenu);
            if (!result.IsSuccess)
            {              
                return Json(result);
            }
            result = SysMenusService.IsRepeatedMenuNameOrUrl(sysMenu.MenuName, sysMenu.MenuUrl);
            if (!result.IsSuccess)
            {               
                return Json(result);
            }
            T_SysMenus menu = Mapper.Map<T_SysMenus>(sysMenu);
            menu.Guid = Guid.NewGuid().ToString("N");
            menu.IsDeleted = false;
            menu.CreateUser = UserId;
            menu.CreateTime = DateTime.Now;
            result = SysMenusService.Add(menu);           
            return Json(result);
        }


        [PermissionDes(Name = "跟新菜单")]
        public ActionResult UpdateMenuNode(SysMenu sysMenu)
        {
            return null;
        }

        [PermissionDes(Name = "删除菜单")]
        public ActionResult DeleteMenuNode(string guid)
        {
            MsgResult result = new MsgResult();
            if (string.IsNullOrEmpty(guid))
            {
                result.IsSuccess = false;
                result.Message = "传输数据有误，请重试！";
            }
            var model = SysMenusService.GetModel(x => x.Guid == guid).FirstOrDefault();
            if (model != null)
            {
                result.IsSuccess = false;
                result.Message = "传输数据有误，请重试！";
            }
            result = SysMenusService.MarkDelete(model);
            return Json(result);
        }
    }
}