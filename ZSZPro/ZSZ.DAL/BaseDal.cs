using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Utilities;
using ZSZ.IDAL;

namespace ZSZ.DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class
    {
        private DbContext DbContext = DbContextFactory.Create();

        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="entity">返回实体</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            return DbContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// EF自带批量增加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<T> AddRange(List<T> list)
        {
            return DbContext.Set<T>().AddRange(list).ToList();
        }

        /// <summary>
        /// 高效批量插入 EntityFramework.Utilities
        /// </summary>
        /// <param name="list">实体集合</param>
        public void BatchAdd(List<T> list)
        {
            EFBatchOperation.For(DbContext, DbContext.Set<T>()).InsertAll(list);
        }

        /// <summary>
        /// 软删除 必须有IsDeleted字段
        /// </summary>
        /// <param name="entity">实体</param>
        public void MarkDelete(T entity)
        {
            //解决必填字段更新的问题，将所有为空的字段置空
            //foreach (System.Reflection.PropertyInfo p in entity.GetType().GetProperties())
            //{
            //    if (p.GetValue(entity) == null)
            //    {

            //        DbContext.Entry<T>(entity).Property(p.Name).CurrentValue = "";
            //    }
            //}
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).Property("IsDeleted").IsModified = true;

            //解决必填字段更新的问题
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        public void BatchMarkDelete(List<T> list)
        {
            //TODO 批量删除
            //foreach (var entity in list)
            //{
            //    DbContext.Entry<T>(entity).Property("IsDeleted").CurrentValue = true;
            //}
            //EFBatchOperation.For(DbContext,DbContext.Set<T>()).UpdateAll(list,x=>x.ColumnsToUpdate(c=>c.));
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改部分实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldNames"></param>
        public void UpdateFields(T entity, List<string> fieldNames)
        {
            if (fieldNames != null && fieldNames.Count > 0)
            {
                DbContext.Set<T>().Attach(entity);
                foreach (var item in fieldNames)
                {
                    DbContext.Entry<T>(entity).Property(item).IsModified = true;
                }
                //解决必填字段更新的问题
                DbContext.Configuration.ValidateOnSaveEnabled = false;
            }
            else
            {
                DbContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        /// <summary>
        /// 清空表中的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        public int Clear(string tableName)
        {
            return DbContext.Database.ExecuteSqlCommand("delete from " + tableName + " where Id > 0");
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="whereLambda">lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="whereLambda"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda, out int totalCount)
        {
            var temp = DbContext.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, type>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageIndex);
            }
            else
            {
                temp = temp.OrderByDescending<T, type>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageIndex);
            }
            return temp;
        }


        /// <summary>
        /// 统一提交
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return DbContext.SaveChanges() > 0;
        }


    }
}
