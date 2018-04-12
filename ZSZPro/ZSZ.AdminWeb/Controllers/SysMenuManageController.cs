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
        public ActionResult AddMenuPage()
        {
            return View();
        }

        [PermissionDes(Name = "增加子级菜单页面", BelongOperate = "增加菜单", IsNotShow = true)]
        public ActionResult AddChildMenuPage(int id)
        {
            return View();
        }

        [PermissionDes(Name = "跟新菜单页面", BelongOperate = "跟新菜单", IsNotShow = true)]
        public ActionResult UpdateMenuPage()
        {
            return View();
        }

       
        [PermissionDes(Name = "增加菜单")]
        public ActionResult AddMenuNode(SysMenu sysMenu)
        {
            T_SysMenus menu = Mapper.Map<T_SysMenus>(sysMenu);
            menu.Guid = Guid.NewGuid().ToString("N");
            menu.IsDeleted = false;
            menu.CreateUser = UserId;
            menu.CreateTime = DateTime.Now;
            var result = SysMenusService.Add(menu);
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
            return null;
        }
    }
}