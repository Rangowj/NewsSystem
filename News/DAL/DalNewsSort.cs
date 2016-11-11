using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class DalNewsSort
    {
        SqlHelper sh = new SqlHelper();

        public void Insert(NewsSort model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO [dbo].[News_Sort]
                            ([NewsSortName]
                            ,[CreatedTime])
                            VALUES
                            (@NewsSortName
                            ,@CreatedTime)");
            SqlParameter[] paras = new SqlParameter[]
            {   
                new SqlParameter("@NewsSortName",model.NewsSortName),
                new SqlParameter("@CreatedTime",model.CreatedTime)
            };

            new SqlHelper().ExecuteNonQuery(sql.ToString(), paras);
        }

        public void Delete(NewsSort model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"DELETE FROM [dbo].[News_Sort]
                            WHERE ID=@ID");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",model.ID)
            };
            sh.ExecuteNonQuery(sql.ToString(), pars);
        }

        public DataSet Select(NewsSort model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT [ID]
                            ,[NewsSortName]
                            ,[CreatedTime]
                            FROM [dbo].[News_Sort]
                            where ID = @ID    
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",model.ID)
            };
            DataSet ds = sh.ExecuteQuery(sql.ToString(), pars);
            return ds;
        }
              
        public DataSet Select()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select * from News_Sort");
            DataSet ds = sh.ExecuteQuery(sql.ToString());
            return ds;
        }


        public void Update(NewsSort model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"UPDATE [dbo].[News_Sort]
                            SET [NewsSortName] = @NewsSortName
                            ,[CreatedTime] = @CreatedTime
                            WHERE ID=@ID");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsSortName",model.NewsSortName),
                new SqlParameter("@CreatedTime",model.CreatedTime),
                new SqlParameter("@ID",model.ID)
            };
            sh.ExecuteNonQuery(sql.ToString(), pars);
        }
    }
}
