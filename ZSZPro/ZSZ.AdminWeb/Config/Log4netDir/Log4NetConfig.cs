using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZSZ.AdminWeb.Config.Log4netDir
{
    public class Log4NetConfig
    {
        private static ILog Logger { get; set; }
        public static void LogConfig()
        {
            string configPath = System.Web.HttpContext.Current.Server.MapPath("~") + @"/Log4Net.config";
            if (System.IO.File.Exists(configPath))
            {
                //log4日志                       
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(configPath));
            }

            //实例化log4net，参数为类或程序集名称   
            Logger = LogManager.GetLogger("Log4NetConfig");
            //输出日志信息，信息级别：info  
            Logger.Info("初始化应用程序日志");
        }
    }
}
