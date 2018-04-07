using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Model.Models;
using ZSZ.Model.Models.Custom;

namespace ZSZ.IService
{
    public interface IInitDataService
    {
       /// <summary>
       /// 初始化数据
       /// </summary>
       /// <param name="list">操作列表</param>
       /// <returns></returns>
        MsgResult InitData(List<T_SysOperations> list);

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        bool IsValid(int userId,string controller,string action);
    }
}
