﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Model.Models.DTO
{
    public class SysMenu
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string IconFont { get; set; }
        public bool IsLeaf { get; set; }
        public int ParentId { get; set; }
        public int SortNum { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }

        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }
    }
}
