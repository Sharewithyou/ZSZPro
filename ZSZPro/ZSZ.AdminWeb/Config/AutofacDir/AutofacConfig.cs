﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ZSZ.AdminWeb.Models;

namespace ZSZ.AdminWeb.Config.AutofacDir
{
    public class AutofacConfig
    {
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            //注册控制器 自动属性注入
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //builder.RegisterFilterProvider();

            //为 ActionFilter 注入
            //builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
            //.Where(type => typeof(ActionFilterAttribute).IsAssignableFrom(type) && !type.IsAbstract)
            //.PropertiesAutowired();

            //builder.RegisterType(typeof(BtnRoleHelper)).PropertiesAutowired();

            //注册业务逻辑与数据访问
            Assembly[] assemblies = new Assembly[] { Assembly.Load("ZSZ.Service"), Assembly.Load("ZSZ.DAL") };

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().PropertiesAutowired();

            //注册log4net
            builder.RegisterModule(new LoggingModule());

            //var IServices = Assembly.Load("ZSZ.IService");
            //var Services = Assembly.Load("ZSZ.Service");
            //var IRepository = Assembly.Load("ZSZ.IDAL");
            //var Repository = Assembly.Load("ZSZ.DAL");

            ////根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            //builder.RegisterAssemblyTypes(IRepository, Repository)
            // .Where(t => t.Name.EndsWith("Dal"))
            // .AsImplementedInterfaces();

            ////根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            //builder.RegisterAssemblyTypes(IServices, Services)
            //  .Where(t => t.Name.EndsWith("Service"))
            //  .AsImplementedInterfaces();

            
            var container = builder.Build();

            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//!
        }
    }
}