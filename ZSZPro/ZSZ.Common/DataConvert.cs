using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ZSZ.Common
{
    public static class DataConvert
    {
        #region 转换为string类型
        /// <summary>
        /// 将string转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this string oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this object oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this double oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将Int32转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this Int32 oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将Int64转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this Int64 oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将decimal转换为string类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>string</returns>
        public static string ConvToString(this decimal oldObject, string defaultVal = "")
        {
            try
            {
                return (oldObject + "").ToString();
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region 转换为int类型
        /// <summary>
        /// 将string转换为int类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int</returns>
        public static int ToInt(this string oldObject, int defaultVal = 0)
        {
            try
            {
                return int.Parse(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }

        public static string ToStringExtension(this string obj, string defaultVal = "0")
        {
            try
            {
                if (obj == null)
                {
                    return "0";
                }
                else
                {
                    return (string)obj;
                }
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为int类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int</returns>
        public static int ToInt(this object oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(oldObject ?? defaultVal);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为int类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int</returns>
        public static int ToInt(this double oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将Int64转换为int类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int</returns>
        public static int ToInt(this Int64 oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将decimal转换为int类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int</returns>
        public static int ToInt(this decimal oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region 转换为int64类型
        /// <summary>
        /// 将string转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this string oldObject, Int64 defaultVal = 0)
        {
            try
            {
                return Int64.Parse(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this object oldObject, Int64 defaultVal = 0)
        {
            try
            {
                return Convert.ToInt64(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this double oldObject, Int64 defaultVal = 0)
        {
            try
            {
                return Convert.ToInt64(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将long转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this long oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt64(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int转换为Int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this int oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt64(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int32转换为Int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this Int32 oldObject, Int64 defaultVal = 0)
        {
            try
            {
                return Convert.ToInt64(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将decimal转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>int64</returns>
        public static Int64 ToInt64(this decimal oldObject, Int64 defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region 转换为long类型
        /// <summary>
        /// 将string转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this string oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this object oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this double oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将long转换为int64类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this long oldObject, int defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this int oldObject, int defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int32转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this Int32 oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int64转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this Int64 oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将decimal转换为long类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>long</returns>
        public static long ToLong(this decimal oldObject, long defaultVal = 0)
        {
            try
            {
                return long.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region 转换为decimal类型
        /// <summary>
        /// 将string转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this string oldObject, decimal defaultVal = 0)
        {
            try
            {
                return decimal.Parse(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this object oldObject, decimal defaultVal = 0)
        {
            try
            {
                return Convert.ToDecimal(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this double oldObject, decimal defaultVal = 0)
        {
            try
            {
                return Convert.ToDecimal(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this int oldObject, int defaultVal = 0)
        {
            try
            {
                return Convert.ToDecimal(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int32转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this Int32 oldObject, decimal defaultVal = 0)
        {
            try
            {
                return Convert.ToDecimal(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int64转换为decimal类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this Int64 oldObject, decimal defaultVal = 0)
        {
            try
            {
                return Convert.ToDecimal(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region 转换为double类型
        /// <summary>
        /// 将string转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this string oldObject, double defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject);
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将object转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this object oldObject, double defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将double转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this double oldObject, double defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this int oldObject, int defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int32转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this Int32 oldObject, double defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        /// <summary>
        /// 将int64转换为double类型
        /// </summary>
        /// <param name="oldObject">需要转换的对象</param>
        /// <param name="defaultVal">默认返回值</param>
        /// <returns>double</returns>
        public static double ToDouble(this Int64 oldObject, double defaultVal = 0)
        {
            try
            {
                return double.Parse(oldObject + "");
            }
            catch (Exception)
            {
                return defaultVal;
            }
        }
        #endregion

        #region Json序列化和反序列化
        /// <summary>
        /// json序列化
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="oldObject">序列化对象</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns>返回json格式字符串</returns>
        public static string ToJsonSerialize<T>(this T oldObject)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(oldObject);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// json反序列化
        /// </summary>
        /// <typeparam name="T">反序列化对象类型</typeparam>
        /// <param name="oldObject">反序列化对象</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns>返回对象</returns>
        public static T ToJsonDeserialize<T>(this string oldObject)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Deserialize<T>(oldObject);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        public static string ToJsonByDataTable(this DataTable dt)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue;
            ArrayList arrayList = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                foreach (DataColumn dataColumn in dt.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ConvToString());
                }
                arrayList.Add(dictionary);
            }
            return javaScriptSerializer.Serialize(arrayList);
        }
        #endregion

        #region List转换为DataTable
        /// <summary>
        /// 将IEnumerable转换为DataTable
        /// </summary>
        /// <typeparam name="T">转换的对象类型</typeparam>
        /// <param name="list">转换的对象</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, string tbName = "newTable")
        {
            List<PropertyInfo> pList = new List<PropertyInfo>();
            Type type = typeof(T);
            DataTable dt = new DataTable(tbName);
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// 将IList转换为DataTable
        /// </summary>
        /// <param name="list">转换的对象</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        /// <summary>
        /// 将List转换为DataTable
        /// </summary>
        /// <param name="list">转换的对象</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ToDataTable<T>(List<T> list)
        {
            DataTable result = new DataTable();
            try
            {
                if (list.Count > 0)
                {
                    PropertyInfo[] propertys = list[0].GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        ArrayList tempList = new ArrayList();
                        foreach (PropertyInfo pi in propertys)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        object[] array = tempList.ToArray();
                        result.LoadDataRow(array, true);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        #endregion

        #region DataTable转换为List
        /// <summary>
        /// 将DataTable转换为List
        /// </summary>
        /// <typeparam name="T">List对象类型</typeparam>
        /// <param name="table">转换的DataTable</param>
        /// <returns>List集合</returns>
        public static List<T> ToList<T>(this DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }
        static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }
        static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        if (row[column.ColumnName] != DBNull.Value)
                        {
                            object value = row[column.ColumnName];
                            prop.SetValue(obj, value, null);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 将datarow转换为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="row">当前行</param>
        /// <returns>当前实体</returns>
        public static T ToModel<T>(this DataRow row)
        {
            T obj = CreateItem<T>(row);
            return obj;
        }
        #endregion

        #region 判断字符是否为空
        /// <summary>
        /// 判断字符是否为空
        /// </summary>
        /// <param name="oldObject"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string oldObject)
        {
            if (string.IsNullOrEmpty(oldObject))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsNullOrEmpty(this object oldObject)
        {
            string str = oldObject + "";
            if (str == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 将string类型数组转换为int类型数组
        /// <summary>
        /// 将string类型数组转换为int类型数组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static int[] ToIntArray(this string[] strs)
        {
            try
            {
                int[] idArray = Array.ConvertAll<string, int>(strs, delegate (string s) { return s.ToInt(); });
                return idArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 将string字符串转换为int类型数组
        /// <summary>
        /// 将string字符串转换为int类型数组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static int[] ToIntArray(this string strs)
        {
            try
            {
                string[] strIds = strs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] idArray = Array.ConvertAll<string, int>(strIds, delegate (string s) { return s.ToInt(); });
                return idArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 汉字转换为拼音
        /// <summary>
        /// 汉字转换为拼音
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static string ToPinYin(this string str)
        //{
        //    try
        //    {
        //        string PYstr = "";
        //        foreach (char item in str.ToCharArray())
        //        {
        //            if (ChineseChar.IsValidChar(item))
        //            {
        //                ChineseChar cc = new ChineseChar(item);
        //                string pinYin = cc.Pinyins[0].Substring(0, cc.Pinyins[0].Length - 1);
        //                string piny1 = pinYin.Substring(0, 1).ToUpper();
        //                string piny2 = pinYin.Substring(1).ToLower();
        //                PYstr += piny1 + piny2; //System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase();
        //            }
        //            else
        //            {
        //                string piny1 = item.ToString().Substring(0, 1).ToUpper();
        //                string piny2 = item.ToString().Substring(1).ToLower();
        //                PYstr += piny1 + piny2;
        //            }
        //        }
        //        return PYstr;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
        #endregion

        #region 获取身份证性别
        /// <summary>
        /// 获取身份证性别
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public static string GetIdCardSex(this string cardNum)
        {
            try
            {
                var num = cardNum.Trim();
                if (num.Length == 18)
                {
                    if (num.Substring(14, 3).ToInt() % 2 == 0)
                    {
                        return "女";
                    }
                    else
                    {
                        return "男";
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion

        #region 获取身份证出生日期
        /// <summary>
        /// 获取身份证出生日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetIdCardBirthDate(this string cardNum)
        {
            try
            {
                string bir = null;
                var num = cardNum.Trim();
                if (num.Length == 18)
                {
                    bir = num.Substring(6, 4) + "-" + num.Substring(10, 2) + "-" + num.Substring(12, 2);
                }
                else
                {
                    return "";
                }
                DateTime dt = new DateTime();
                var isdate = DateTime.TryParse(bir, out dt);
                if (isdate)
                {
                    return bir;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        /// <summary>
        /// 转换DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist">IEnumerable<T></param>
        /// <returns></returns>
        public static DataTable ToDataTableZ<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            // 可以添加一个检查，以验证有一个元素0
            foreach (T rec in varlist)
            {
                // 用反射来获取属性名，创建表，只会第一次，其他人会跟随
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();

                    foreach (PropertyInfo pi in oProps)
                    {

                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }

            return dtReturn;
        }
        #endregion

        #region 获取预约时段类型

        /// <summary>
        /// 获取预约时段类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetCustomType(this int type)
        {
            try
            {
                switch (type)
                {
                    case 0:
                        return "随时";
                    case 1:
                        return "早上";
                    case 2:
                        return "中午";
                    case 3:
                        return "下午";
                    default:
                        return "未知";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        #endregion

        #region 获取身份证类型

        public static string GetCardType(this int type)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        return "身份证";
                    case 2:
                        return "护照";
                    case 3:
                        return "其它";
                    default:
                        return "未知";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #endregion

        #region 获得文件类型

        public static string GetFileType(this int type)
        {
            try
            {
                switch (type)
                {
                    case 10:
                        return "产品条款";
                    case 20:
                        return "保单样本";
                    case 30:
                        return "除外责任";
                    default:
                        return "未知";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #endregion

        #region 获取指定周第一天和最后一天

        /// <summary>
        /// 获取指定周第一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDaySun(this DateTime datetime)
        {
            //星期天为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>  
        /// 得到指定周最后一天(以星期六为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySat(this DateTime datetime)
        {
            //星期六为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        #endregion
    }
}
