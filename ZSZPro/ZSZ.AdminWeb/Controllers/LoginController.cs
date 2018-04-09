using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Common;
using ZSZ.IService;
using ZSZ.Model.Models.Custom;
using ZSZ.Model.Models.Custom.Request;
using Newtonsoft.Json;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace ZSZ.AdminWeb.Controllers
{
    public class LoginController : Controller
    {
        public ILoginService LoginService { get; set; }
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

        public ActionResult SubmitLogin(LoginRequest request)
        {
             MsgResult result = new MsgResult();
            if (string.IsNullOrEmpty(request.UserAccount) || string.IsNullOrEmpty(request.PassWord) || string.IsNullOrEmpty(request.VerifyCode))
            {
                result.IsSuccess = false;
                result.Message = "值不允许为空";
                return Json(result);
            }
            if (!string.Equals(request.VerifyCode, (string)TempData["verifyCode"], StringComparison.OrdinalIgnoreCase))
            {
                result.IsSuccess = false;
                result.Message = "验证码错误";
                return Json(result);
            }

            result = LoginService.CheckLogin(request.UserAccount, request.PassWord);
            if (result.IsSuccess)
            {
                if (request.IsRemind)
                {
                    var user = JsonConvert.DeserializeObject<AdminUser>(result.Data);
                    SessionHelper.SetSession("UserName", user.Phone);
                    //Session["UserName"] = user.Phone;
                }            
            }

            return Json(result);

        }
    }
}