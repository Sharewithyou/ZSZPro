using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZSZ.Model.Models.Custom.Result
{
    //validform 结果
    //注意json数据必须严格按如下格式输出：{"info":"demo info","status":"y"};
    //info: 输出提示信息;
    //status: 返回提交数据的状态,是否提交成功。“y”表示提交成功，“n”表示提交失败，在callback函数里可以根据该值执行相应的回调操作;

    public class ValidFormResult
    {
        [JsonProperty("info")]
        public string Info { get; set; }


        /// <summary>
        /// y 表示成功 n 表示失败
        /// </summary>
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
