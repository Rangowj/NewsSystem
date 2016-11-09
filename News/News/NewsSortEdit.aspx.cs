using System;
using BLL;
using System.Data;
using Model;

namespace News
{
    public partial class NewsSortEdit : System.Web.UI.Page
    {
        NewsSortMgr nsm = new NewsSortMgr();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    int id = Convert.ToInt32(Request["id"]);
                    NewsSort ns = new NewsSort()
                    {
                        ID = id
                    };
                    DataSet ds = nsm.Select(ns);
                    var text = ds.Tables[0].Rows[0]["NewsSortName"];
                    txtSort.Text = text.ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request["id"] == null)
            {
                AddSort();
            }
            else
            {
                UpdateSort();
            }
           
        }

        private void UpdateSort()
        {
            int id = Convert.ToInt32(Request["id"]);
            NewsSort ns = new NewsSort
            {
                ID = id,
                NewsSortName = txtSort.Text.Trim(),
                CreatedTime = DateTime.Now
            };
            nsm.Update(ns);
            Response.Write("<script>alert('保存成功！')</script>");
            Response.Write("<script>window.location.href='NewsSortList.aspx';</script>");
        }

        private void AddSort()
        {
            NewsSort ns = new NewsSort()
            {
                NewsSortName = txtSort.Text.Trim(),
                CreatedTime = DateTime.Now
            };
            nsm.Insert(ns);
            Response.Write("<script>alert('保存成功！')</script>");
            Response.Write("<script>window.location.href='NewsSortList.aspx';</script>");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsSortList.aspx");
        }
    }
}