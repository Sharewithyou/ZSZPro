using System;
using System.Collections.Generic;

namespace ZSZ.Model.Models
{
    public partial class T_SysLog
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
