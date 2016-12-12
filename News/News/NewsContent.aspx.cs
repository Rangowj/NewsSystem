using BLL;
using Model;
using System;
using System.Data;
using System.Net;

namespace News
{
    public partial class NewsContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                contentBind();
            }
        }

        public void contentBind()
        {
            if(Request["id"] == null)
            {
                DataSet ds = new NewsMgr().Select6();
                lbContent.Text = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                lbCreatedTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["CreatedTime"]);
                lbTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
            }
            else
            {
                var id = Convert.ToInt32(Request["id"]);
                News_Datail model = new News_Datail
                {
                    ID = id
                };
                DataSet ds = new NewsMgr().SelectNewsContentById(model);
                lbContent.Text = ds.Tables[0].Rows[0]["NewsContent"].ToString();
                lbTitle.Text = ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                lbCreatedTime.Text = ds.Tables[0].Rows[0]["CreatedTime"].ToString();
            }
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            string userIP = null;
            foreach(IPAddress _IPAdress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if(_IPAdress.AddressFamily.ToString() == "InterNetwork")
                {
                    userIP = _IPAdress.ToString();
                }
            }
            UserInfo user = (UserInfo)Session["User"];
            if(user == null)
            {
                Response.Write("<script>alert('请登录！')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            else if(txtComment.Value == null)
            {
                Response.Write("<script>alert('请填写回复内容！');</script>");
            }
            else
            {
                Comment model = new Comment
                {
                    NewsDatailId = Convert.ToInt32(Request["id"]),
                    CommentedContent = txtComment.Value,
                    Commentator = user.UserName,
                    UserIP = userIP,
                    CreatedTime = DateTime.Now
                };
                new BllComment().InsertConmmentInfo(model);
            }
        }
    }
}