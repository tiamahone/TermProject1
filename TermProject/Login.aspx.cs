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
        UserInformation login;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            if (txtEmail != null)
            {
                Response.Redirect("Main.aspx");
            }
            else
            {
                lblDisplay.Text = "Please enter your email and password.";
            }
        }

        public void ConfirmLogin()
        {
            login = new UserInformation();

            login.email = txtEmail.Text;
            login.password = txtPassword.Text;

        }
    }
}