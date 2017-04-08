using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                lblDisplayText.Text = Session["Login"].ToString();
            }
            else
            {
                lblDisplayText.Text = "Error: Must Login in";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}