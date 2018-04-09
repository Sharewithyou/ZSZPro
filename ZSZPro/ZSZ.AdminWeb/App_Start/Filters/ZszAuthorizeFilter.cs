using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.App_Start.CustomAttribute;

namespace ZSZ.AdminWeb.App_Start.Filters
{
    public class ZszAuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var attribute = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoAuthorizeAttribute), true);
            if(attribute.Length==0)
            {
                if (filterContext.HttpContext.Session["UserName"] == null)
                {
                    filterContext.Result = new RedirectResult("/login/index");
                }
            }
           
        }
    }
}