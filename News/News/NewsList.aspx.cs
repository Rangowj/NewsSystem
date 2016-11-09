using System;
using BLL;
using Model;
using System.Data;

namespace News
{
    public partial class NewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                DataSet ds = new NewsMgr().Select2();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsEdit.aspx");
        }

 
    }
}