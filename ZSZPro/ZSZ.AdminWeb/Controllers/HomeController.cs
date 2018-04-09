using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;

namespace ZSZ.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        [NoAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}