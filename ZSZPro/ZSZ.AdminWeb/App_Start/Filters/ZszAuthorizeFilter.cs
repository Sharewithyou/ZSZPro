using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;
using ZSZ.IService;

namespace ZSZ.AdminWeb.App_Start.Filters
{
    public class ZszAuthorizeFilter : IAuthorizationFilter
    {
        public ILoginService LoginService { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //控制器统一处理
            var attribute = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoAuthorizeAttribute), true);
            //控制器未标注
            if(attribute.Length==0)
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
                        var result = LoginService.HasPermission(userId, controller, action);
                        if (result.IsSuccess)
                        {
                           //todo 异步判断
                        }
                        else
                        {

                        }
                    }
                }
            }


           
               
              
                
                  
        }
    }
}