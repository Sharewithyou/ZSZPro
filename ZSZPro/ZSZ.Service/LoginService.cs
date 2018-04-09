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

namespace ZSZ.Service
{
    public class LoginService : ILoginService
    {
        public IAdminUsersDal AdminUsersDal { get; set; }

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
    }
}
