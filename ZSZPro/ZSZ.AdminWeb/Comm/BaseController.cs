using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.Common;

namespace ZSZ.AdminWeb.Comm
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名-手机号
        /// </summary>
        public string UserName { get; set; }

        public BaseController()
        {
            this.UserId = System.Web.HttpContext.Current.Session["UserId"].ToInt();
            if (UserId > 0)
            {
                this.UserName = System.Web.HttpContext.Current.Session["UserName"].ConvToString();
            }
        }
    }
}