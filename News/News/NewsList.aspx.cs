using System;
using BLL;
using Model;
using System.Data;
using System.Web.UI.WebControls;

namespace News
{
    public partial class NewsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsBind();
                sortBind();
            }
        }

        public void newsBind()
        {
            DataSet ds = new NewsMgr().Select2();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsEdit.aspx");
        }

        public void sortBind()
        {
            var list = new NewsSortMgr().Select();
            ddlSort.Items.Add("全部");
            foreach (var item in list)
            {
                var listItem = new ListItem(item.NewsSortName, item.ID.ToString());
                ddlSort.Items.Add(listItem);
                
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var sort = ddlSort.Text.Trim();
            if(sort == "全部" && title != null)
            {
                News_Datail model = new News_Datail
                {
                    NewsTitle = title
                    
                };
                DataSet ds = new NewsMgr().Select4(model);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else if(sort != "全部" && title != null)
            {
                var id = Convert.ToInt32(sort);
                 News_Datail model = new News_Datail
                 {
                    NewsTitle = title,
                    NewsSortId = id
                 };
                 DataSet ds = new NewsMgr().Select3(model);
                 GridView1.DataSource = ds.Tables[0];
                 GridView1.DataBind();
            }
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.Rows[e.NewEditIndex].Cells[1].Text);
            Response.Redirect("NewsEdit.aspx?id="+id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}