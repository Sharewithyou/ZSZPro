using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models;
using ZSZ.Model.Models.Custom;
using ZSZ.Model.Models.Custom.log;

namespace ZSZ.Service
{
    public class InitDataService : IInitDataService
    {
        public IBaseDal<T_AdminUsers> BaseDal { get; set; }

        public ISysRolesDal SysRolesDal { get; set; }

        public ISysPermissionsDal SysPermissionsDal { get; set; }

        public ISysOperationsDal SysOperationsDal { get; set; }

        public ISysMenusDal SysMenusDal { get; set; }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public MsgResult InitData(List<T_SysOperations> list)
        {
            MsgResult result = new MsgResult();
            try
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    int count = 0;

                    //1 , 清除关系表以及数据表
                    count = BaseDal.Clear(typeof(T_UserRoles).Name);
                    count = BaseDal.Clear(typeof(T_RolePermissions).Name);
                    count = BaseDal.Clear(typeof(T_OperatePermissions).Name);
                    count = BaseDal.Clear(typeof(T_MenuPermissions).Name);

                    count = BaseDal.Clear(typeof(T_AdminUsers).Name);
                    count = BaseDal.Clear(typeof(T_SysRoles).Name);
                    count = BaseDal.Clear(typeof(T_SysPermissions).Name);
                    count = BaseDal.Clear(typeof(T_SysOperations).Name);

                    // 2 , 初始化数据

                    //用户
                    T_AdminUsers adminUser = new T_AdminUsers();
                    adminUser.Phone = "17512039375";
                    adminUser.CreateTime = DateTime.Now;
                    adminUser.CreateUser = 1;
                    adminUser.Salt = "123456";
                    adminUser.PwdHush = EncryptHelper.GetMd5("n5187698" + adminUser.Salt);
                    adminUser.Guid = Guid.NewGuid().ToString("N");
                    var addUser = BaseDal.Add(adminUser);
                    BaseDal.SaveChanges();

                    //角色
                    T_SysRoles role = new T_SysRoles();
                    role.Guid = Guid.NewGuid().ToString("N");
                    role.Name = "超级管理员";
                    role.Description = "拥有所有的权限";
                    role.CreateUser = addUser.Id;
                    role.CreateTime = DateTime.Now;


                    //操作权限
                    T_SysPermissions permission = new T_SysPermissions();
                    permission.Guid = Guid.NewGuid().ToString("N");
                    permission.Type = 1;
                    permission.Description = "操作权限";
                    permission.CreateUser = addUser.Id;
                    permission.CreateTime = DateTime.Now;

                    //菜单权限
                    T_SysPermissions permissionNew = new T_SysPermissions();
                    permissionNew.Guid = Guid.NewGuid().ToString("N");
                    permissionNew.Type = 2;
                    permissionNew.Description = "菜单权限";
                    permissionNew.CreateUser = addUser.Id;
                    permissionNew.CreateTime = DateTime.Now;


                    var addRole = SysRolesDal.Add(role);
                    var addPermission = SysPermissionsDal.Add(permission);
                    var addPermissionNew = SysPermissionsDal.Add(permissionNew);
                    BaseDal.SaveChanges();

                    //操作列表
                    SysOperationsDal.BatchAdd(list);
                    var newList = SysOperationsDal.GetModel(x => x.Id >= 0).ToList();



                    // 3 , 初始化关系
                    T_UserRoles userRole = new T_UserRoles();
                    userRole.UserId = addUser.Id;
                    userRole.RoleId = addRole.Id;

                    //用户角色
                    adminUser.T_UserRoles.Add(userRole);
                    BaseDal.SaveChanges();

                    //操作权限
                    T_RolePermissions permissions = new T_RolePermissions();
                    permissions.RoleId = addRole.Id;
                    permissions.PermissionId = addPermission.Id;

                    //菜单权限
                    T_RolePermissions permissionsNew = new T_RolePermissions();
                    permissionsNew.RoleId = addRole.Id;
                    permissionsNew.PermissionId = addPermissionNew.Id;


                    //角色权限
                    role.T_RolePermissions.Add(permissions);
                    role.T_RolePermissions.Add(permissionsNew);


                    List<T_OperatePermissions> addOperatelist = new List<T_OperatePermissions>();
                    for (int i = 0; i < newList.Count; i++)
                    {
                        T_OperatePermissions operate = new T_OperatePermissions();
                        operate.PermissionId = addPermission.Id;
                        operate.OperationId = newList[i].Id;
                        addOperatelist.Add(operate);
                    }

                    //权限操作
                    permission.T_OperatePermissions = addOperatelist;


                    List<T_MenuPermissions> addMenuOperate = new List<T_MenuPermissions>();
                    List<T_SysMenus> menuList = new List<T_SysMenus>();
                    menuList = SysMenusDal.GetModel(X => X.Id >= 0).ToList();
                    for (int i = 0; i < menuList.Count; i++)
                    {
                        T_MenuPermissions menuPermission = new T_MenuPermissions();
                        menuPermission.MenuId = menuList[i].Id;
                        menuPermission.PermissionId = addPermissionNew.Id;
                        addMenuOperate.Add(menuPermission);
                    }

                    permissionNew.T_MenuPermissions = addMenuOperate;
                    BaseDal.SaveChanges();

                    scope.Complete();


                }
               


                result.IsSuccess = true;

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }

            return result;
        }

       
    }
}
