using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_SysPermissions : BaseEntity
    {
        public T_SysPermissions()
        {
            this.T_MenuPermissions = new List<T_MenuPermissions>();
            this.T_OperatePermissions = new List<T_OperatePermissions>();
            this.T_RolePermissions = new List<T_RolePermissions>();
        }

     
        public string Guid { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
       
        public virtual ICollection<T_MenuPermissions> T_MenuPermissions { get; set; }
        public virtual ICollection<T_OperatePermissions> T_OperatePermissions { get; set; }
        public virtual ICollection<T_RolePermissions> T_RolePermissions { get; set; }
    }
}
