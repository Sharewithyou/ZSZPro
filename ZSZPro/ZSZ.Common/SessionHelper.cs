﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ZSZ.Common
{
    /// <summary>  
    /// Session 操作类  
    /// 1、GetSession(string name)根据session名获取session对象  
    /// 2、SetSession(string name, object val)设置session  
    /// </summary>  
    public class SessionHelper
    {
        /// <summary>  
        /// 根据session名获取Session对象  
        /// </summary>  
        /// <param name="name"></param>  
        /// <returns></returns>  
        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }
        /// <summary>  
        /// 设置Session  
        /// </summary>  
        /// <param name="name">session 名</param>  
        /// <param name="val">session 值</param>  
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }

        /// <summary>  
        /// 清空所有的Session  
        /// </summary>  
        /// <returns></returns>  
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>  
        /// 删除一个指定的Session  
        /// </summary>  
        /// <param name="name">Session名称</param>  
        /// <returns></returns>  
        public static void RemoveSession(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }

        /// <summary>  
        /// 删除所有的Session  
        /// </summary>  
        /// <returns></returns>  
        public static void RemoveAllSession(string name)
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}
