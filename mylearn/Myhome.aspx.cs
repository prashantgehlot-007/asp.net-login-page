using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mylearn
{
    public partial class Myhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["name"]!=null)
            {
                Label1.Text = Request.QueryString["name"].ToString();
            }

            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}