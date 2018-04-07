﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Models.Custom.log
{
    /// <summary>
    /// 自定义日志输出对象
    /// </summary>
    public class LogContent
    {
        /// <summary>
        /// 日志消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public string ExceptoiopnMsg { get; set; }


        public LogContent(string msg, string ex)
        {
            this.Message = msg;
            this.ExceptoiopnMsg = ex;
        }
    }
}
