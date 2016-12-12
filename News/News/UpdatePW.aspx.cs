using Model;
using System;
using System.Security.Cryptography;
using BLL;
using System.Text;

namespace News
{
    public partial class UpdatePW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string oldPW = MD5PW(tbOldPW.Text);

            UserInfo info = new BllUserInfo().SelectUserInfo(tbUserName.Text);
            if(info != null)
            {
                if(info.PassWord == oldPW)
                {
                    string newPW = MD5PW(tbNewPW.Text);
                    new BllUserInfo().UpdatePassWord(newPW, tbUserName.Text);
                    Response.Write("<script>alert('修改成功，即将为您跳转页面！')</script>");
                    Response.Write("<script>setTimeout(function(){window.location.href='Login.aspx';},5000);</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户不存在')</script>");
            }
        }

        public string MD5PW(string passWord)
        {
            MD5 provider = MD5.Create();
            byte[] inputArr = Encoding.UTF8.GetBytes(passWord);
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