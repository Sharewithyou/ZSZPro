using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZSZ.AdminWeb.App_Start.Filters;
using ZSZ.AdminWeb.Config.AutofacDir;
using ZSZ.AdminWeb.Config.AutoMapDir;
using ZSZ.AdminWeb.Config.Log4netDir;

namespace ZSZ.AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //依赖注入
            AutofacConfig.Register();

            //注册logNet配置
            Log4NetConfig.LogConfig();

            //注册过滤器
            FilterConfig.RegisterFilters(GlobalFilters.Filters);

            //实体模型映射
            Mapper.Initialize(x => { x.AddProfile<SourceProfile>(); });


        }
    }
}
