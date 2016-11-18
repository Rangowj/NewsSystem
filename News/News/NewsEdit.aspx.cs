using BLL;
using CKEditor.NET;
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
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    editBind();
                }
                else
                {
                    sortBind();
                }
            }
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(Request["id"] != null)
            {
                Update();
            }
            else
            {
                Insert();
            }
        }

        public void Update()
        {
            var text = tbTitle.Text;
            var text2 = CKEditorControl1.Text;
           
                News_Datail model = new News_Datail
                {
                    NewsTitle = tbTitle.Text,
                    NewsSortId = Convert.ToInt32(ddlSort.Text.Trim()),
                    NewsContent = CKEditorControl1.Text,
                    CreatedTime = DateTime.Now,
                    ID = Convert.ToInt32(Request["id"])
                };
                new NewsMgr().Update(model);
                Response.Write("<script>alert('保存成功！')</script>");
                Response.Write("<script>window.location.href='NewsList.aspx';</script>");
            
        }
        public void Insert()
        {
            if (tbTitle.Text != "" && ddlSort.Text != "全部")
            {
                var id = Convert.ToInt32(ddlSort.Text.Trim());
                News_Datail model = new News_Datail
                {
                    NewsTitle = tbTitle.Text,
                    NewsSortId = id,
                    CreatedTime = DateTime.Now,
                    NewsContent = CKEditorControl1.Text
                };
                new NewsMgr().Insert(model);
                Response.Write("<script>alert('保存成功!')</script>");
                Response.Write("<script>window.location.href='NewsList.aspx';</script>");
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
       
        public void editBind()
        {
            if(Request["id"] != null)
            {
                int id = Convert.ToInt32(Request["id"]);
                Public model = new Public
                {
                    ID = id
                };
                var list = new NewsMgr().Select5(model);
                foreach( var item in list)
                {
                    var listItem = new ListItem(item.NewsSortName, item.NewsSortId.ToString());
                    ddlSort.Items.Add(listItem);
                    tbTitle.Text = item.NewsTitle;
                    CKEditorControl1.Text = item.NewsContent;
                }
            }  
        }
    }
}