using System;
using System.Web;
using BLL;
using System.Web.Script.Serialization;
using Model;

namespace News
{
    /// <summary>
    /// HdrDemo 的摘要说明
    /// </summary>
    public class HdrDemo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sortName = Convert.ToString(context.Request["SortName"]);

            NewsSort model = new NewsSort
            {
                NewsSortName = sortName
            };

            var newsList = new NewsSortMgr().Select2(model);

            string jsonStr = new JavaScriptSerializer().Serialize(newsList);

            context.Response.Write(jsonStr);
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