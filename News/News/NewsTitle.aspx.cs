using BLL;
using Model;
using System;
using System.Collections.Generic;

namespace News
{
    public partial class NewsTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            titleBind();
        }

        public void titleBind()
        {
            List<News_Datail> title = new NewsMgr().Select();
            gvTitle.DataSource = title;
            gvTitle.DataBind();
        }
    }
}