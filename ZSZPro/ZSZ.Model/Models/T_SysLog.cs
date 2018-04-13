using System;
using System.Collections.Generic;
using ZSZ.Model.Models.Base;

namespace ZSZ.Model.Models
{
    public partial class T_SysLog: BaseEntity
    {      
        public System.DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
