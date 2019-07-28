using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webczw.DBUtil
{
    public class SqlHelper
    {
        private static String ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        #region 格式化SQL语句
        /// <summary>
        /// 增删改非查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static int UPDATE(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 返回单条结果查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static object getSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 多条结果查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static SqlDataReader getReader(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// 返回DataSet数据集方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>结果集DataSet</returns>
        public static DataSet getDataSet(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region 带参数SQL语句
        /// <summary>
        /// 增删改非查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">SQl参数</param>
        /// <returns></returns>
        public static int UPDATE(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 返回单条结果查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">SQL参数</param>
        /// <returns></returns>
        public static object getSingleResult(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 多条结果查询类方法
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">SQL参数</param>
        /// <returns></returns>
        public static SqlDataReader getReader(string sql, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
