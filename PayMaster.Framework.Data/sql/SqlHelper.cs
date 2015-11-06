using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace PayMaster.Framework.Data.sql
{
    public static class SqlHelper
    {

        /// <summary>
        /// Execute sp by passing Parameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connectionString"></param>
        /// <param name="spName"></param>
        /// <param name="listSqlParameters"></param>
        /// <returns></returns>
        public static T ExecuteStoredProcedure<T>(string connectionString, string spName, IList<SqlParameter> listSqlParameters)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 150;

                    foreach (SqlParameter sqlParam in listSqlParameters)
                    {
                        if (sqlParam.DbType == DbType.String || sqlParam.DbType == DbType.AnsiString)
                            if (sqlParam.Value == null)
                            {
                                sqlParam.Value = DBNull.Value;
                            }

                        // sqlParam.Value=!string.IsNullOrEmpty((string) sqlParam.Value)?sqlParam.Value:DBNull.Value;
                        cmd.Parameters.Add(sqlParam);
                    }
                    listSqlParameters.Clear();
                    if (typeof(T) == typeof(string))
                    {
                        var da = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        conn.Open();
                        da.Fill(ds);
                        return ds.Tables[0].Rows.Count > 0
                            ? (T)ds.Tables[0].Rows[0][0]
                            : (T)(object)String.Empty;
                    }
                    if (typeof(T) == typeof(DataTable))
                    {
                        var da = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        conn.Open();
                        da.Fill(ds);
                        ds.Locale = CultureInfo.CurrentCulture;
                        return (T)(object)ds.Tables[0];
                    }
                    if (typeof(T) == typeof(DataSet))
                    {
                        var da = new SqlDataAdapter(cmd);
                        var ds = new DataSet();
                        conn.Open();
                        da.Fill(ds);
                        ds.Locale = CultureInfo.CurrentCulture;
                        return (T)(object)ds;
                    }
                    if (typeof(T) == typeof(int))
                    {

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return default(T);

                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return default(T);
                }
            }
        }

        public static ICollection<T> DataTableToList<T>(DataTable table) where T : class, new()
        {
            // AutoMapper.Mapper.CreateMap<IDataReader, T>();
            return table.ToCollection<T>();
            //return AutoMapper.Mapper.DynamicMap<IDataReader, IList<T>>(table.CreateDataReader()).ToList();
        }

        internal static ICollection<T> ToCollection<T>(this DataTable dt)
        {
            ICollection<T> lst = new Collection<T>();
            var tClass = typeof(T);
            var pClass = tClass.GetProperties();
            var dc = dt.Columns.Cast<DataColumn>().ToList();
            foreach (DataRow item in dt.Rows)
            {
                var cn = (T)Activator.CreateInstance(tClass);
                var item1 = item;
                foreach (var pc in from pc in pClass let d = dc.Find(c => c.ColumnName == pc.Name) where d != null where !string.IsNullOrEmpty(Convert.ToString(item1[pc.Name])) select pc)
                {
                    pc.SetValue(cn, item[pc.Name], null);
                }
                lst.Add(cn);
            }
            return lst;
        }
    }
}
