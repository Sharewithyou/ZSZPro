using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models.Custom;
using Newtonsoft.Json;
using ZSZ.Model.Models.DTO;
using AutoMapper;
using ZSZ.Model.Models;

namespace ZSZ.Service
{
    public class LoginService : ILoginService
    {
        public IAdminUsersDal AdminUsersDal { get; set; }
        public ISysOperationsDal SysOperationsDal { get; set; }

        /// <summary>
        /// 校验登陆
        /// </summary>
        /// <param name="userName">账户</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public MsgResult CheckLogin(string userName, string pwd)
        {
            MsgResult result = new MsgResult();
            try
            {
                var model = AdminUsersDal.GetModel(x => x.Phone == userName).FirstOrDefault();
                AdminUser user = Mapper.Map<AdminUser>(model);
                if (model != null)
                {
                    string pwdHush = EncryptHelper.GetMd5(pwd.Trim() + model.Salt);
                    if (string.Equals(pwdHush, model.PwdHush))
                    {                       
                        result.IsSuccess = true;
                        result.Message = "登陆成功";
                        result.Data = JsonConvert.SerializeObject(user);
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "用户名或者密码错误";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "用户名或者密码错误";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "系统异常：" + ex.Message;  
            }

            return result;
            
        }

        /// <summary>
        /// 校验权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">方法</param>
        /// <returns></returns>
        public MsgResult HasPermission(int userId, string controller, string action)
        {
            MsgResult result = new MsgResult();
            try
            {
                var model = AdminUsersDal.GetModel(x => x.Id == userId).FirstOrDefault();
                if (model != null)
                {
                    var cache = CacheHelper.GetCache("SysOp" + model.Id);
                    List<T_SysOperations> list = new List<T_SysOperations>();
                    if (cache == null)
                    {
                        foreach (var role in model.T_UserRoles)
                        {
                            var tempList = SysOperationsDal.GetSysOperationListByRoleId(role.Id);
                            list.AddRange(tempList);
                        }
                        CacheHelper.SetCache("SysOp" + model.Id, list);
                    }
                    else
                    {
                        list = (List<T_SysOperations>)cache;
                    }

                    if (list.Any(x => x.ContronllerName == controller & x.ActionName == action))
                    {
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "无权限访问当前方法";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "当前用户不存在";                   
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
