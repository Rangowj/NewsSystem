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
                                   ,[CreatedTime]
                                   ,[NewsContent]
                                   ,[CreatedBy])
                             VALUES
                                   (@NewsSortId
                                   ,@NewsTitle
                                   ,@CreatedTime
                                   ,@NewsContent
                                   ,@CreatedBy
                                    )");
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@NewsSortId", model.NewsSortId),
                new SqlParameter("@NewsTitle", model.NewsTitle),
                new SqlParameter("@CreatedTime", DateTime.Now),
                new SqlParameter("@NewsContent",model.NewsContent),
                new SqlParameter("@CreatedBy",model.CreatedBy)
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

        public DataSet SelectSortList()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT  ID,
                                     NewsTitle,
                                     CreatedTime,
                                     NewsSortName
                                     FROM  VNews");
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

        public DataSet Select4(Public model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"SELECT News_Datail.ID
	                        ,NewsSortId
	                        ,NewsTitle
	                        ,NewsSortName
                            ,NewsContent
                            FROM News_Datail inner join News_Sort on NewsSortId = News_Sort.ID
                            WHERE News_Datail.ID=@ID
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",model.ID)
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            return ds;
        }

        public DataSet Select5()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select NewsContent
                                    ,CreatedTime
                                    ,NewsTitle
                            from News_Datail
                            where ID = 2028
                                    ");
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString());
            return ds;
        }

        public DataSet SelectNewsContentById(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select NewsContent
                                ,NewsTitle
                                ,CreatedTime
                            from News_Datail
                            where ID = @ID
                                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@ID",model.ID)
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            return ds;
        }

        public DataSet SelectNewsList(int NewsSortId = 0)
        {
            StringBuilder sql = new StringBuilder();
            DataSet ds = null;
            SqlParameter[] pars = null;
            if (NewsSortId == 0)
            {
                sql.AppendLine(@"select NewsTitle
                                        ,CreatedTime
                                from News_Datail
                                ");
            }
            else
            {
                sql.AppendLine(@"select NewsTitle
	                                ,News_Datail.CreatedTime 
                                from News_Datail inner join News_Sort on News_Datail.NewsSortId = News_Sort.ID
                                where News_Sort.ID = @ID
                                ");
                pars = new SqlParameter[]
                {
                    new SqlParameter("@ID",NewsSortId)
                };
            }
            ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            return ds;
        }
        public void Update(News_Datail model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"UPDATE [dbo].[News_Datail]
                                SET [NewsTitle] = @NewsTitle
                                ,[CreatedTime] = @CreatedTime
                                ,[NewsSortId] = @NewsSortId
                                ,NewsContent = @NewsContent
                                ,LastUpdatedBy = @LastUpdatedBy
                                ,LastCreatedTime = @LastCreatedTime
                                WHERE ID = @ID  
                            ");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle",model.NewsTitle),
                new SqlParameter("@CreatedTime",model.CreatedTime),
                new SqlParameter("@NewsSortId",model.NewsSortId),
                new SqlParameter("@NewsContent",model.NewsContent),
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@LastUpdatedBy",model.LastUpdatedBy),
                new SqlParameter("@LastCreatedTime",model.LastCreatedTime)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }

        public DataSet GetNewsList(int pageSize, int pageIndex, int NewsSortId)
        {
            int minRowNum = pageSize * (pageIndex - 1) + 1;
            int maxRowNum = pageSize * pageIndex;
            StringBuilder sql = new StringBuilder();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsSortId",NewsSortId),
                new SqlParameter("@minRowNum",minRowNum),
                new SqlParameter("@maxRowNum",maxRowNum)
            };
            sql.AppendLine(@"select NewsTitle 
                                   ,CreatedTime 
                                   ,ID
                                    from(");
            if (NewsSortId > 0)
            {
                sql.AppendLine(@"select *,ROW_NUMBER() over(order by CreatedTime) as List from News_Datail where NewsSortId = @NewsSortId) as Temp
                                    where List between @minRowNum and @maxRowNum
                                    ");
            }
            else
            {
                sql.AppendLine(@"select *,ROW_NUMBER() over(order by CreatedTime) as List from News_Datail) as Temp
                                    where List between @minRowNum and @maxRowNum");
            }
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(),pars);
            return ds;
        }

        public int SelectRowCount(int newsSortId)
        {
            StringBuilder sql = new StringBuilder();
            SqlParameter[] pars = new SqlParameter[] {
                 new SqlParameter("@NewsSortId", newsSortId)
            };
            if (newsSortId > 0)
            {
                sql.AppendLine(@"select Count(*) from News_Datail
                                    where NewsSortId = @NewsSortId");
            }
            else
            {
                sql.AppendLine(@"select COUNT(*) from News_Datail");
            }
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(),pars);
            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            return count;
        }
    }
}
