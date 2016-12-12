using BLL;
using System;
using System.Web;
using System.Web.Script.Serialization;
using VNewsModel;

namespace News
{
    /// <summary>
    /// HdrComment 的摘要说明
    /// </summary>
    public class HdrComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id = Convert.ToInt32(context.Request["pId"]);
            int pageSize = Convert.ToInt32(context.Request["pSize"]);
            int pageIndex = Convert.ToInt32(context.Request["pIndex"]);
            int totalCount = new BllComment().SelectRowCount(id);
            int pageCount = 1;

            var list = new BllComment().SelectCommentInfo(pageSize,pageIndex,id);

            if(totalCount % pageSize > 0)
            {
                pageCount = totalCount / pageSize + 1;
            }
            else
            {
                pageCount = totalCount / pageSize;
            }
            CommentListPageCount view = new CommentListPageCount();
            view.List = list;
            view.PageCount = pageCount;
            
            string str = new JavaScriptSerializer().Serialize(view);
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}