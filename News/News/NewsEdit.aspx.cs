using BLL;
using Model;
using System;
using System.Data;

namespace News
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int ID()
        {
            NewsSort ns = new NewsSort
            {
                NewsSortName = ddlSort.Text
            };
            int id = new NewsSortMgr().Select2(ns);
            return id;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            News_Datail model = new News_Datail
            {
                NewsTitle = tbTitle.Text,
                NewsSortId = ID(),
                CreatedTime = DateTime.Now
            };
            new NewsMgr().Insert(model);
            Response.Write("<script>alert('保存成功!')</script>");
            Response.Redirect("NewsList.aspx?id=" + ID());
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsList.aspx");
        }
    }
}