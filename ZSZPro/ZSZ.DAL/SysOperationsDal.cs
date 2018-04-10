﻿// <autogenerated>
//   This file was generated by T4 code generator DalTemplate.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>


using ZSZ.IDAL;
using ZSZ.Model.Models;
using ZSZ.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ZSZ.IDAL
{
    public class SysOperationsDal : BaseDal<T_SysOperations>, ISysOperationsDal
    {
        private DbContext dbContext = DbContextFactory.Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<T_SysOperations> GetSysOperationListByRoleId(int roleId)
        {
            string sql = "select * from T_SysOperations where Id in( select OperationId from T_OperatePermissions where PermissionId in (select Id from T_SysPermissions where Type = 1 and Id in(select PermissionId from T_RolePermissions where RoleId = @roleID)))";
            SqlParameter parameter = new SqlParameter("@roleID", roleId);
            return dbContext.Database.SqlQuery<T_SysOperations>(sql, parameter).ToList();
        }
    }
}
