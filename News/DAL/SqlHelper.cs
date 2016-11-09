using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class SqlHelper
    {
        private string conStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["XMLConnectionString"].ConnectionString;
            }
        }

        private SqlConnection GetConnection()
        {
            SqlConnection conn = null;
            if (string.IsNullOrWhiteSpace(conStr))
            {
                throw new Exception("数据库连接字符串为空！");
            }
            else
            {
                if (conn == null)
                {
                    conn = new SqlConnection(conStr);
                }
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                return conn;
            }
        }
        public void ExecuteNonQuery(string sql, SqlParameter[] pars = null, CommandType type = CommandType.Text)
        {
            SqlConnection conn = GetConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = type;
                if (pars != null && pars.Length > 0)
                {
                    cmd.Parameters.AddRange(pars);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataSet ExecuteQuery(string sql, SqlParameter[] pars = null, CommandType type = CommandType.Text)
        {
            SqlConnection conn = GetConnection();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            if (pars != null && pars.Length > 0)
            {
                sda.SelectCommand.Parameters.AddRange(pars);
            }
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
    }
}
