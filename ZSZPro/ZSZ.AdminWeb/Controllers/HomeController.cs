using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Model.Models;
using Newtonsoft.Json;
using ZSZ.Model.Models.DTO;

namespace ZSZ.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public ISysMenusService SysMenusService { get; set; }

        [NoAuthorize]
        public ActionResult Index()
        {
            if (!SessionHelper.HasSession("UserId"))
            {
                return Redirect("/login/index");
            }
            List<SysMenu> menuList = new List<SysMenu>();
            var result = SysMenusService.GetSysMenusByUserId((int)SessionHelper.GetSession("UserId"));
            if (result.IsSuccess)
            {
                menuList = JsonConvert.DeserializeObject<List<SysMenu>>(result.Data);
            }            
            return View(menuList);
        }
    }
}