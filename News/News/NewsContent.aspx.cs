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
            }
            else
            {
                var id = Convert.ToInt32(Request["id"]);
                News_Datail model = new News_Datail
                {
                    ID = id
                };
                DataSet ds = new NewsMgr().Select7(model);
                lbContent.Text = ds.Tables[0].Rows[0]["NewsContent"].ToString();
            }
        }
    }
}