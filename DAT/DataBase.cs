using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAT
{
    public class DataBase
    {
       // private readonly string sqlcon = "server=10.14.4.251;database=LJ5GW;uid=sa;pwd=longi;";

        private static SqlConnection Con
        {
            get
            {
                var connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;//.ConnectionString;
               
                var con = new SqlConnection(connection);
                try
                {
                    con.Open();
                }
                catch 
                {
                    throw;
                        }
                return con;
            }
        }
        private static SqlCommand Cmd
        {
            get
            {
                return new SqlCommand { Connection = Con };
            }
        }
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Update(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                
                if (cmd.Connection.State == ConnectionState.Open) {
                    return cmd.ExecuteNonQuery() > 0;//ExecuteNonQuery该函数返回受影响的行数
                    
                }
                    
                else {
                    return false;
                }                  
                
            }
            catch(Exception ex1) 
            {
                try
                {

                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        return cmd.ExecuteNonQuery() > 0;//ExecuteNonQuery该函数返回受影响的行数

                    }

                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    AppLog.WriteError(string.Format("数据库增删改异常{0}+sql{1}", ex, sql), true);
                    AppLog.WriteInfo(string.Format("Update切方完工表失败"), true);
                    return false;
                }               
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        /// <summary>
        /// 获取一个对象，常常与聚合函数一起使用
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool SelectForScalar(string sql,out int count)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    return true;
                }
                else
                {
                    count = -1;
                    return false;
                }
            }
            catch 
            {
                count = -1;
                return false;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        /// <summary>
        /// 获取一个结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader SelectForReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                if (cmd.Connection.State == ConnectionState.Open)
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    return null;
                //CommandBehavior.CloseConnection解决了流读取数据模式下，数据库连接不能有效关闭的情况。当某个XXXDataReader对象在生成时使用了CommandBehavior.CloseConnection，
                //那数据库连接将在XXXDataReader对象关闭时自动关闭。
            }
            catch 
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                throw;
            }
        }
        public bool ifOpen()
        {
            if (Con.State == ConnectionState.Open)
                return true;
            else
                return false;
        }
        // static DataSet dt = new DataSet();
        public static DataSet ExecuteTable(string sql,string str)
        {
            try
            {
                
                using (SqlDataAdapter sda = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["con"].ConnectionString))
                {
                    // DataTable dt = new DataTable();
                    DataSet dt = new DataSet();
                    sda.Fill(dt, str);
                    // DataTable sd= dt.Tables["cs"];
                    return dt;
                }
            }
            catch 
            {
                throw;
            }
        }

    }
}
