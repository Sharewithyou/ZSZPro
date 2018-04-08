using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Common;

namespace ZSZ.AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetVerifyCode()
        {
            string code = CaptchaHelper.CreateVerifyCode(4);
            TempData["verifyCode"] = code;
            var stream = CaptchaHelper.CreateVerifyCodeImg(code);
            return File(stream, "image/jpeg");
        }

        public ActionResult SubmitLogin()
        {
            return null;
        }
    }
}