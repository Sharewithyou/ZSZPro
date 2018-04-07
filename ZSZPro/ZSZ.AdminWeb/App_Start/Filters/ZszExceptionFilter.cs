using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using ZSZ.Model.Models.Custom.log;

namespace ZSZ.AdminWeb.App_Start.Filters
{
    public class ZszExceptionFilter : IExceptionFilter
    {

        private static ILog log = LogManager.GetLogger(typeof(ZszExceptionFilter));

        public void OnException(ExceptionContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];

            log.Fatal(new LogContent(controllerName + "/" + actionName, filterContext.Exception.Message));
        }
    }
}