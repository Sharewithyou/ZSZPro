using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZSZ.Common;
using ZSZ.IDAL;
using ZSZ.IService;
using ZSZ.Model.Models.Base;
using ZSZ.Model.Models.Custom;

namespace ZSZ.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public IBaseDal<T> BaseDal { get; set; }
        public MsgResult Add(T entity)
        {
            MsgResult result = new MsgResult();
            try
            {
                T t = BaseDal.Add(entity);
                bool flag = BaseDal.SaveChanges();
                if (flag)
                {
                    result.IsSuccess = true;
                    result.Data = JsonConvert.SerializeObject(t);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "增加失败";
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "增加失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "增加失败：" + ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 批量增加实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public MsgResult AddRange(List<T> list)
        {
            MsgResult result = new MsgResult();
            try
            {
                BaseDal.AddRange(list);
                BaseDal.SaveChanges();
                result.IsSuccess = true;
                result.Message = "批量增加数据成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "批量增加数据失败：" + sb.ToString();
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "批量增加数据失败：" + ex.Message;
            }

            return result;
        }

        public MsgResult BatchAdd(List<T> list)
        {
            MsgResult result = new MsgResult();
            try
            {
                BaseDal.BatchAdd(list);
                //BaseDal.SaveChanges();
                result.IsSuccess = true;
                result.Message = "批量增加数据成功";
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "批量增加数据失败：" + sb.ToString();
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "批量增加数据失败：" + ex.Message;
            }

            return result;
        }

        public MsgResult BatchMarkDelete(List<T> list)
        {
            throw new NotImplementedException();
        }

        public MsgResult Clear(string tableName)
        {
            MsgResult result = new MsgResult();
            try
            {
                int count = BaseDal.Clear(tableName);
                if (count > 0)
                {
                    result.IsSuccess = true;
                    result.Message = "清除" + tableName + "成功";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "清除" + tableName + "失败";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "清除" + tableName + "失败" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 返回查询数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return BaseDal.GetModel(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda, out int totalCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public MsgResult MarkDelete(T entity)
        {
            MsgResult result = new MsgResult();
            try
            {
                BaseDal.MarkDelete(entity);
                bool flag = BaseDal.SaveChanges();
                if (flag)
                {
                    result.IsSuccess = true;
                    result.Message = "删除成功";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "删除失败";
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ve in ex.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
                {
                    sb.AppendLine(ve.PropertyName + ":" + ve.ErrorMessage);
                }
                result.IsSuccess = false;
                result.Message = "删除失败：" + sb.ToString();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public MsgResult Update(T entity)
        {
            throw new NotImplementedException();
        }

        public MsgResult UpdateFields(T entity, List<string> fieldNames)
        {
            throw new NotImplementedException();
        }
    }
}
