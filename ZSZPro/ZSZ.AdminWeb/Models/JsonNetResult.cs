using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ZSZ.AdminWeb.Models
{
    /// <summary>
    /// 重写json的返回形式
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        public JsonSerializerSettings Settings { get; set; }

        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ///忽略循环引用 Ignore，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                ReferenceLoopHandling = ReferenceLoopHandling.Error,

                //日期格式化，默认的格式也不好看
                DateFormatString = "yyyy-MM-dd HH:mm:ss"/*,*/

                //json中属性开头字母小写的驼峰命名
                //ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && string.Equals(context.HttpContext.Request.HttpMethod, "GET",
                    StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" :
                this.ContentType;
            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;
            var scriptSerializer = JsonSerializer.Create(this.Settings);
            scriptSerializer.Serialize(response.Output, this.Data);
        }
    }
}