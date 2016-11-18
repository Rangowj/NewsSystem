using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News
{
    public partial class NewsContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contentBind();
        }

        public void contentBind()
        {
            if(Request["id"] != null)
            {
                News_Datail model = new News_Datail
                {
                    ID = Convert.ToInt32(Request["id"])
                };
                DataSet ds = new NewsMgr().Select6(model);
                lbContent.Text = ds.Tables[0].Rows[0]["NewsContent"].ToString();
            }
        }
    }
}