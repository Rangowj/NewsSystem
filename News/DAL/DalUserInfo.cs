using System.Text;
using Model;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DalUserInfo
    {
        public void InsertUserInfo(UserInfo model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"insert into UserInfo 
                             values(@RoleId,@UserName,@PassWord,@Phone,@CreatedTime,@LastLoginTime)");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@RoleId",model.RoleId),
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@PassWord",model.PassWord),
                new SqlParameter("@Phone",model.Phone),
                new SqlParameter("@CreatedTime",model.CreatedTime),
                new SqlParameter("@LastLoginTime",model.LastLoginTime)
            };

            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }

        public DataSet SelectUserPWByUserName(string userName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select *
                             from UserInfo
                             where UserName = @UserName");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName)
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);

            return ds;
        }

        public void UpdatePassWord(string passWord,string userName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"update UserInfo set PassWord = @PassWord
                             where UserName = @UserName");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@PassWord",passWord),
                new SqlParameter("@UserName",userName)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }

        public void UpdateLastUserName(string lastUserName,int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"update News_Datail set LastUpdatedBy = @LastUpdatedBy where ID = @ID");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@LastUpdatedBy",lastUserName),
                new SqlParameter("@ID",id)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }
    }
}
