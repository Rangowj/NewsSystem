using System;
using System.Web;
using BLL;
using System.Web.Script.Serialization;
using VNewsModel;

namespace News
{
    /// <summary>
    /// HdrNews 的摘要说明
    /// </summary>
    public class HdrNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageSize = Convert.ToInt32(context.Request["pSize"]);
            int pageIndex = Convert.ToInt32(context.Request["pIndex"]);
            int id = Convert.ToInt32(context.Request["nSortId"]);
            var list = new NewsMgr().GetNewsList(pageSize, pageIndex, id);

            var totalCount = new NewsMgr().SelectRowCount(id);
            var pageCount = 1;
            if (totalCount % pageSize > 0)
            {
                pageCount = totalCount / pageSize + 1;
            }
            else
            {
                pageCount = totalCount / pageSize;
            }

            NewsListPageCount pc = new NewsListPageCount();
            pc.List = list;
            pc.PageCount = pageCount;

            string str = new JavaScriptSerializer().Serialize(pc);
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