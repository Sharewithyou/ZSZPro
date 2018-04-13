using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_AdminUsers : BaseEntity
    {
        public T_AdminUsers()
        {
            this.T_SysGroupUsers = new List<T_SysGroupUsers>();
            this.T_UserRoles = new List<T_UserRoles>();
        }
    
        public string Guid { get; set; }
        public string Phone { get; set; }
        public string Salt { get; set; }
        public string PwdHush { get; set; }
               
        public virtual ICollection<T_SysGroupUsers> T_SysGroupUsers { get; set; }
        public virtual ICollection<T_UserRoles> T_UserRoles { get; set; }
    }
}
