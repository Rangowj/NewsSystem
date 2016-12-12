using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News
{
    public partial class Reception : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                newsBind();
        }

        public void newsBind()
        {
            var list = new NewsSortMgr().Select();
            StringBuilder aa = new StringBuilder();
            foreach (var i in list)
            {
                var href = "NewsTitle.aspx?id=" + i.ID;
                aa.AppendLine("<li>" + "<a href='"+href+"'>" + i.NewsSortName + "</a>" + "</li>");
                sortList.InnerHtml = aa.ToString();
            }
        }

        
    }
}