using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_SysOperations : BaseEntity
    {
        public T_SysOperations()
        {
            this.T_OperatePermissions = new List<T_OperatePermissions>();
        }

      
        public string Guid { get; set; }
        public string TypeName { get; set; }
        public string OperateName { get; set; }
        public string ContronllerName { get; set; }
        public string ActionName { get; set; }
        public string BelongOperate { get; set; }
        public bool IsNotShow { get; set; }
       
        public virtual ICollection<T_OperatePermissions> T_OperatePermissions { get; set; }
    }
}
