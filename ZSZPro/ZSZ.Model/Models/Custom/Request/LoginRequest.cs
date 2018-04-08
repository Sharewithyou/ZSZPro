using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Models.Custom.Request
{
    public class LoginRequest
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode { get; set; }

        /// <summary>
        /// 是否记住信息
        /// </summary>
        public bool IsRemind { get; set; }
    }
}
