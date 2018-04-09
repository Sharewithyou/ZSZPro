using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Models.Custom;

namespace ZSZ.IService
{
    public interface ILoginService
    {
        /// <summary>
        /// 校验登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        MsgResult CheckLogin(string userName, string pwd);
    }
}
