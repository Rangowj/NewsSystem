using System;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace News
{
    public partial class NewsSortList : System.Web.UI.Page
    {
        NewsSortMgr nsm = new NewsSortMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsBind();
            }
        }

        public void newsBind()
        {
            var list = nsm.Select();
            gvNewSort.DataSource = list;
            gvNewSort.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvNewSort.Rows[e.RowIndex].Cells[1].Text);
            NewsSort ns = new NewsSort()
            {
                ID = id
            };
            nsm.Delete(ns);
            newsBind();
            Response.Write("<script>alert('删除成功！')</script>");
            e.Cancel = true;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvNewSort.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("NewsSortEdit.aspx?id=" + id);
        }

    }
}