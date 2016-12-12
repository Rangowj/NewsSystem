using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string addressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    addressIP = _IPAddress.ToString();
                    Response.Write("<script>alert('" + addressIP + "')</script>");
                }
            }
        }


            //string source = "123456789";

            //MD5 provider = MD5.Create();

            //byte[] inputArr = Encoding.UTF8.GetBytes(source);

            //byte[] result = provider.ComputeHash(inputArr);

            //string re = null;

            //for(int i = 0; i<result.Length; i++)
            //{
            //    re += result[i].ToString("X");
            //}

            //Response.Write("<script>alert('"+re+"')</script>");



        }

        //public string MD5PW(string passWord)
        //{
        //    string source = tbPassWord1.Text;

        //    MD5 provider = MD5.Create();

        //    byte[] inputArr = Encoding.UTF8.GetBytes(source);

        //    byte[] result = provider.ComputeHash(inputArr);

        //    string re = null;

        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        re += result[i].ToString("X");
        //    }

        //    return re;
        //}
    }
