using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DalNews
    {
        public void Insert(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"INSERT INTO [dbo].[News_Datail]
                                   ([NewsSortId]
                                   ,[NewsTitle]
                                   ,[CreatedTime])
                             VALUES
                                   (@NewsSortId
                                   ,@NewsTitle
                                   ,@CreatedTime)");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@NewsSortId", model.NewsSortId),
                new SqlParameter("@NewsTitle", model.NewsTitle),
                new SqlParameter("@CreatedTime", DateTime.Now)
            };

            new SqlHelper().ExecuteNonQuery(sql.ToString(), paras);
        }

        public void Delete(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"DELETE FROM [dbo].[News_Datail]
                                    WHERE ID=@ID
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",model.ID)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }

        public DataSet Select()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT [dbo].[News_Datail].[ID] 
                            ,[dbo].[News_Sort].[NewsSortName] 
                            ,[dbo].[News_Datail].[NewsTitle] 
                            ,[dbo].[News_Datail].[CreatedTime]
                            FROM [dbo].[News_Datail] inner join [dbo].[News_Sort] on [dbo].[News_Datail].NewsSortId = [dbo].[News_Sort].ID");
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString());
            return ds;
        }

        public DataSet Select2(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT News_Datail.ID
                            ,News_Sort.NewsSortName
                            ,News_Datail.NewsTitle
                            ,News_Datail.CreatedTime
                            FROM dbo.News_Datail inner join News_Sort on News_Datail.NewsSortId = News_Sort.ID
                            WHERE NewsTitle like @NewsTitle and NewsSortId = @NewsSortId
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle","%"+model.NewsTitle+"%"),
                new SqlParameter("@NewsSortId",model.NewsSortId)
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            return ds;
        }

        public DataSet Select3(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT News_Datail.ID
                            ,News_Sort.NewsSortName
                            ,News_Datail.NewsTitle
                            ,News_Datail.CreatedTime
                            FROM dbo.News_Datail inner join News_Sort on News_Datail.NewsSortId = News_Sort.ID
                            WHERE NewsTitle like @NewsTitle 
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle","%"+model.NewsTitle+"%")
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            return ds;
        }

        //public DataSet Select4(News_Datail model)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.AppendLine(@"SELECT NewsTitle,
		      //                      NewsSortId,
		      //                      News_Datail.ID
        //                    FROM News_Datail inner join News_Sort on NewsSortId = News_Sort.ID
        //                    where News_Datail.ID = @ID
        //                   ");
        //    SqlParameter[] pars = new SqlParameter[]
        //    {
        //        new SqlParameter("@ID",model.ID)
        //    };
        //    DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
        //    return ds;
        //}

        public void Update(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"UPDATE [dbo].[News_Datail]
                                SET [NewsTitle] = @NewsTitle
                                ,[CreatedTime] = @CreatedTime
                                WHERE NewsSortId = @NewsSortId  
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle",model.NewsTitle),
                new SqlParameter("@NewsTitle",model.CreatedTime),
                new SqlParameter("@NewsSortId",model.NewsSortId)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }
    }
}
