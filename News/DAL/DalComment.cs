using System;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DalComment
    {
        public void InsertCommentInfo(Comment model)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"insert into Comment
                                        (NewsDatailId
                                        ,CommentedContent
                                        ,Commentator
                                        ,UserIp
                                        ,CreatedTime )
                             values(@NewsDatailId
                                   ,@CommentedContent
                                   ,@Commentator
                                   ,@UserIp
                                   ,@CreatedTime
                            )");
            if (model.NewsDatailId == 0)
            {
                model.NewsDatailId = 2028;
            }
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsDatailId",model.NewsDatailId),
                new SqlParameter("@CommentedContent",model.CommentedContent),
                new SqlParameter("@Commentator",model.Commentator),
                new SqlParameter("@UserIp",model.UserIP),
                new SqlParameter("@CreatedTime",model.CreatedTime)
            };
            new SqlHelper().ExecuteNonQuery(sql.ToString(), pars);
        }

        public DataSet SelectCommentInfo(int pageSize, int pageIndex, int id)
        {
            int minRowNum = pageSize * (pageIndex - 1) + 1;
            int maxRowNum = pageSize * pageIndex;
            if(id == 0)
            {
                id = 2028;
            }
            StringBuilder sql = new StringBuilder();
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@minRowNum",minRowNum),
                new SqlParameter("@maxRowNum",maxRowNum),
                new SqlParameter("@NewsDatailId",id)
            };
            sql.AppendLine(@"select CommentedContent 
                                   ,CreatedTime 
                                   ,UserIP
                                    from(");
            sql.AppendLine(@"select *,ROW_NUMBER() over(order by CreatedTime desc) as List from Comment where NewsDatailId = @NewsDatailId) as Temp
                                    where List between @minRowNum and @maxRowNum
                                    ");
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(),pars);

            return ds;
        }

        public int SelectRowCount(int NewsDatailId)
        {
            if(NewsDatailId == 0)
            {
                NewsDatailId = 2028;
            }
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"select count(*) from Comment
                             where NewsDatailId = @NewsDatailId");
            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@NewsDatailId",NewsDatailId)
            };
            DataSet ds = new SqlHelper().ExecuteQuery(sql.ToString(), pars);
            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            return count;
        }
    }
}
