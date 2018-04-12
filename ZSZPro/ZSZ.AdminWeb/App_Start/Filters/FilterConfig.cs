using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSZ.AdminWeb.App_Start.Filters
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
            //权限过滤器
            filters.Add(new ZszAuthorizeFilter());

            //全局异常过滤器
            filters.Add(new ZszExceptionFilter());

            //json结果过滤器
            filters.Add(new JsonResultActionFilter());

            //这里使用了Autofac容器来实例化Filter对象，然后添加到Global Filter中
            //filters.Add(DependencyResolver.Current.GetService<VisitorAdditionFilter>());
        }
    }
}