using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZSZ.AdminWeb.App_Start.CustomAttribute
{
    /// <summary>
    /// 不校验权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
   
    public class NoAuthorizeAttribute : Attribute
    {

    }
}