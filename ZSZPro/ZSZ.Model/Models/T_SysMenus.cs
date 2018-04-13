using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_SysMenus : BaseEntity
    {
        public T_SysMenus()
        {
            this.T_MenuPermissions = new List<T_MenuPermissions>();
        }

        public string Guid { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string IconFont { get; set; }
        public bool IsLeaf { get; set; }
        public int ParentId { get; set; }
        public int SortNum { get; set; }

        public virtual ICollection<T_MenuPermissions> T_MenuPermissions { get; set; }
    }
}
