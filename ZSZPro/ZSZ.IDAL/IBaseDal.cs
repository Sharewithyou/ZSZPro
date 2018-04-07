using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.IDAL
{
    public interface IBaseDal<T> where T : class
    {
        /// <summary>
        /// 增加实体
        /// </summary>
        /// <param name="entity">数据库实体</param>
        /// <returns>插入实体</returns>
        T Add(T entity);

        /// <summary>
        ///EF自带的批量增加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<T> AddRange(List<T> list);

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <param name="list"></param>
        void BatchAdd(List<T> list);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 修改实体部分字段
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fieldNames">修改字段名称</param>
        void UpdateFields(T entity, List<string> fieldNames);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="entity"></param>
        void MarkDelete(T entity);

        /// <summary>
        /// 批量软删除
        /// </summary>
        /// <param name="entity"></param>
        void BatchMarkDelete(List<T> list);

        /// <summary>
        /// 清空某张表的数据
        /// </summary>
        /// <param name="tableName">表名</param>
        int Clear(string tableName);

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns>IQueryable</returns>
        IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="type"></typeparam>
        /// <param name="pageSize">数据大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">排序规则</param>
        /// <param name="OrderByLambda"></param>
        /// <param name="WhereLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda, out int totalCount);

        /// <summary>
        /// 统一提交EF操作
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
