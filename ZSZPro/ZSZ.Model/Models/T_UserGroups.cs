using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_UserGroups : BaseEntity
    {
        public T_UserGroups()
        {
            this.T_GroupRoles = new List<T_GroupRoles>();
            this.T_SysGroupUsers = new List<T_SysGroupUsers>();
        }
    
        public string Guid { get; set; }
        public string GroupName { get; set; }
        public int ParentId { get; set; }
      
        public virtual ICollection<T_GroupRoles> T_GroupRoles { get; set; }
        public virtual ICollection<T_SysGroupUsers> T_SysGroupUsers { get; set; }
    }
}
