using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Class_Library;

namespace TermProject
{
    public partial class Registraion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirm.Text)
            {
                lblDisplayText.Text = "Passwords must match";
            }
            else
            {
                string result = Functions.addUser(txtName.Text, txtEmail.Text,
                    txtPassword.Text, txtPhone.Text);

                lblDisplayText.Text = result;
            }

        }
    }
}