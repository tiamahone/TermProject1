using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Class_Library;

namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string response = Functions.attemptLogin(email, password);

            if (response == "Success User" || response == "Success Admin")
            {
                Session["Login"] = response;
                Response.Redirect("Main.aspx");
            }
            else
            {
                lblDisplayText.Text = response;
            }

        }
    }
}