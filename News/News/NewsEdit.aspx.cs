using BLL;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace News
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {     
                sortBind();
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(ddlSort.Text.Trim());
            if (tbTitle.Text != "" && ddlSort.Text != "全部" && tbContent.Text != null)
            {
                 News_Datail model = new News_Datail
                {
                    NewsTitle = tbTitle.Text,
                    NewsSortId = id,
                    CreatedTime = DateTime.Now
                };
                new NewsMgr().Insert(model);
                Response.Write("<script>alert('保存成功!')</script>");
                Response.Redirect("NewsList.aspx");
            }
            else
            {
                Response.Write("<script>alert('请把所有信息填写完成!!')</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsList.aspx");
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

        //public void contentBind()
        //{
        //    if (Request["id"] != null)
        //    {
        //        int id = Convert.ToInt32(Request["id"]);
        //        News_Datail model = new News_Datail
        //        {
        //            ID = id
        //        };
        //        DataSet ds = new NewsMgr().Select5(model);
        //        tbTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
        //        ddlSort.Text = ds.Tables[0].Rows[0]["NewsSortId"].ToString();
        //    }
        //}
    }
}