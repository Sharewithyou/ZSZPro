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

        /// <summary>
        /// 校验权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controller">控制器名称</param>
        /// <param name="action">方法名称</param>
        /// <returns></returns>
        MsgResult HasPermission(int userId, string controller, string action);
    }
}
