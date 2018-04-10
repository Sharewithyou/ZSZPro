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
using ZSZ.AdminWeb.App_Start.CustomAttribute;

namespace ZSZ.AdminWeb.Controllers
{
    [NoAuthorize]
    public class LoginController : Controller
    {
        public ILoginService LoginService { get; set; }

        /// <summary>
        /// 登陆页
        /// </summary>
        /// <returns></returns>  
        public ActionResult Index()
        {
            if (SessionHelper.GetSession("IsRemind") != null)
            {
                return Redirect("/home/index");
            }
            ViewData["UserName"] = SessionHelper.GetSession("UserName");
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetVerifyCode()
        {
            string code = CaptchaHelper.CreateVerifyCode(4);
            TempData["verifyCode"] = code;
            var stream = CaptchaHelper.CreateVerifyCodeImg(code);
            return File(stream, "image/jpeg");
        }

        /// <summary>
        /// 提交登陆
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                var user = JsonConvert.DeserializeObject<AdminUser>(result.Data);
                SessionHelper.SetSession("UserName", user.Phone);
                SessionHelper.SetSession("UserId", user.Id);

                if (request.IsRemind)
                {
                    SessionHelper.SetSession("IsRemind", true);
                }            
            }

            return Json(result);

        }

        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            SessionHelper.ClearSession();
            return Redirect("/login/index");
        }
    }
}