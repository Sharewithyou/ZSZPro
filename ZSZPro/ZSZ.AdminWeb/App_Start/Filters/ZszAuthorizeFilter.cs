using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.IService;
using ZSZ.Model.Models.Custom;
using ZSZ.Model.Models.Custom.Enum;

namespace ZSZ.AdminWeb.App_Start.Filters
{
    public class ZszAuthorizeFilter : IAuthorizationFilter
    {
        public ILoginService LoginService = DependencyResolver.Current.GetService<ILoginService>();
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            //控制器统一处理
            var attribute = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoAuthorizeAttribute), true);
            //控制器未标注
            if (attribute.Length == 0)
            {
                //单个方法处理
                var actionAttribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof(NoAuthorizeAttribute), true);
                //方法未标注
                if (actionAttribute.Length == 0)
                {
                    if (filterContext.HttpContext.Session["UserId"] == null)
                    {
                        filterContext.Result = new RedirectResult("/login/index");
                    }
                    else
                    {
                        int userId = (int)filterContext.HttpContext.Session["UserId"];
                        string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                        string action = filterContext.ActionDescriptor.ActionName;
                        //鉴权处理
                        var result = LoginService.HasPermission(userId, controller, action);
                        //无权限处理
                        if (!result.IsSuccess)
                        {
                            //todo 异步判断
                            //string ajaxHeader = (string)filterContext.HttpContext.Request.Headers["x-requested-with"];
                            //if(!string.IsNullOrEmpty(ajaxHeader)&&string.Equals(ajaxHeader,"XMLHttpRequest",StringComparison.OrdinalIgnoreCase))
                            if (filterContext.HttpContext.Request.IsAjaxRequest())
                            {
                                MsgResult resultNew = new MsgResult();
                                resultNew.IsSuccess = false;
                                resultNew.MsgCode = (int)ErrorCodeEnum.没有权限;
                                resultNew.Message = "没有权限访问";
                                resultNew.Data = "/Home/Index";
                                filterContext.Result = new JsonResult() { Data = resultNew };
                            }
                            else
                            {
                                filterContext.Result = new RedirectResult("/Home/Index");
                            }

                        }

                    }
                }
            }







        }
    }
}