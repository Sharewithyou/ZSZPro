using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_SysRoles : BaseEntity
    {
        public T_SysRoles()
        {
            this.T_GroupRoles = new List<T_GroupRoles>();
            this.T_RolePermissions = new List<T_RolePermissions>();
            this.T_UserRoles = new List<T_UserRoles>();
        }

     
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public virtual ICollection<T_GroupRoles> T_GroupRoles { get; set; }
        public virtual ICollection<T_RolePermissions> T_RolePermissions { get; set; }
        public virtual ICollection<T_UserRoles> T_UserRoles { get; set; }
    }
}
