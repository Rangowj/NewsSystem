using System;
using Model;
using BLL;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace News
{
    public partial class UserLogin : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            string userName = tbUserName.Text;
            UserInfo info = new BllUserInfo().SelectUserInfo(userName);
            var user = (UserInfo)Session["User"];

            string md5PW = MD5PW();

            if (info != null)
            {
                Session["User"] = info;
                if (info.PassWord == md5PW)
                {
                    Response.Write("<script>alert('登陆成功！')</script>");
                    Response.Write("<script>window.location.href='NewsSortList.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('密码错误！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名不存在！')</script>");
            }
        }

        public string MD5PW()
        {
            string source = tbPassWord1.Text;
            MD5 provider = MD5.Create();
            byte[] inputArr = Encoding.UTF8.GetBytes(source);
            byte[] result = provider.ComputeHash(inputArr);
            string re = null;
            for (int i = 0; i < result.Length; i++)
            {
                re += result[i].ToString("X");
            }

            return re;
        }
    }
}