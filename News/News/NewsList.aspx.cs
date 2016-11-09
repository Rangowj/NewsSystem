﻿using System;
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
        }
    }
}