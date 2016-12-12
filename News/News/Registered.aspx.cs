using System;
using Model;
using BLL;
using System.Security.Cryptography;
using System.Text;

namespace News
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            string md5PW = MD5PW();

            UserInfo userInfo = new BllUserInfo().SelectUserInfo(tbUserName.Text);

            if (tbPassWord1.Text != "" && tbPassWord2.Text == tbPassWord1.Text && tbPhone.Text != "" && tbUserName.Text != "")
            {
                UserInfo model = new UserInfo()
                {
                    RoleId = 3,
                    UserName = tbUserName.Text,
                    PassWord = md5PW,
                    Phone = tbPhone.Text,
                    CreatedTime = DateTime.Now,
                    LastLoginTime = DateTime.Now
                };

                new BllUserInfo().InsertUserInfo(model);
                Response.Write("<script>alert('注册成功！')</script>");
                Response.Write("<script>window.location.href='Login.aspx'</script>");
            }
            else if (userInfo != null)
            {
                Response.Write("<script>alert('用户已存在！')</script>");
            }
            else if (tbPassWord2.Text != tbPassWord1.Text && tbPassWord1.Text != "")
            {
                Response.Write("<script>alert('请核实密码是否匹配！')</script>");
            }
            else
            {
                Response.Write("<script>alert('请填写有效信息！')</script>");
            }
        }

        public string MD5PW()
        {
            string source = tbPassWord1.Text;
            MD5 provider = MD5.Create();
            byte[] inputArr = Encoding.UTF8.GetBytes(source);
            byte[] result = provider.ComputeHash(inputArr);
            string re = null;
            for(int i = 0; i<result.Length; i++)
            {
                re += result[i].ToString("X");
            }

            return re;
        }
    }
}