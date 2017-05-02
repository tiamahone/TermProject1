using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class SuperAdmin : System.Web.UI.Page
    {
        string[] loginInfo = new string[2];
        string email = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                lblDisplayText.Text = Session["SuperAdmin"].ToString() + "'s Storage Options";
                loginInfo[0] = Session["SuperAdmin"].ToString();
                loginInfo[1] = Session["Password"].ToString();
                email = Session["SuperAdmin"].ToString();
            }
            else
            {
                lblDisplayText.Text = "Error: Must Login in";
            }

        }
    }
}