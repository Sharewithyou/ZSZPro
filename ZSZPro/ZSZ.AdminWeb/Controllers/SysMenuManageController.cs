using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;

namespace ZSZ.AdminWeb.Controllers
{
    [PermissionDes(Name = "菜单管理")]
    public class SysMenuManageController : Controller
    {
        [PermissionDes(Name = "浏览")]
        // GET: SysMenuManage
        public ActionResult Index()
        {
            return View();
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