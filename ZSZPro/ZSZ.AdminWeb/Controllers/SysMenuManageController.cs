using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    [PermissionDes(Name = "菜单管理")]
    public class SysMenuManageController : Controller
    {
        public ISysMenusService SysMenusService { get; set; }

        [PermissionDes(Name = "浏览")]
        // GET: SysMenuManage
        public ActionResult Index()
        {
            return View();
        }

        [NoAuthorize]
        [PermissionDes(Name = "获取菜单树数据",IsNotShow = true)]
        public ActionResult GetMenuTreeNode()
        {
            var result = SysMenusService.GetZtreeNodeByUserId();
            return Json(result);
        }

        public ActionResult AddMenuPage()
        {
            return View();
        }

        public ActionResult UpdateMenuPage()
        {
            return View(); 
        }
    }
}