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
            if (!IsPostBack && Request.Cookies["Login_Cookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["Login_Cookie"];
                lblEmail.Text = "Welcome back " + cookie.Values["userName"].ToString() + "!";
                txtEmail.Text = cookie.Values["userName"].ToString();
                txtEmail.Visible = false; btnRegister.Visible = false; btnOtherUser.Visible = true;
            }
            else
            {
                lblEmail.Text = "Email Address:";
                txtEmail.Visible = true; btnRegister.Visible = true; btnOtherUser.Visible = false;
            }
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

            if (Validations())
            {

                if (response == "Success User" || response == "Success Admin" || response=="Success SuperAdmin")
                {
                    // Adds cookie if remember me is checked
                    if (chkRemember.Checked)
                    {
                        HttpCookie myCookie = new HttpCookie("Login_Cookie");
                        myCookie.Values["userName"] = txtEmail.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    // Deletes cookie if remember me is not checked
                    else
                    {
                        if (Request.Cookies["Login_Cookie"] != null)
                        {
                            HttpCookie myCookie = new HttpCookie("Login_Cookie");
                            myCookie.Expires = DateTime.Now.AddDays(-1d);
                            Response.Cookies.Add(myCookie);
                        }
                    }

                    Session["Login"] = response;
                    Session["User"] = email;
                    Session["Password"] = password;
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    lblDisplayText1.Text = response;
                }
            }
        }

        protected void btnOtherUser_Click(object sender, EventArgs e)
        {
            // Deletes cookie if Not Me is clicked
            HttpCookie myCookie = new HttpCookie("Login_Cookie");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            txtEmail.Text = "";
        }

        public bool Validations()
        {
            if (txtEmail.Text == String.Empty ||
                txtPassword.Text == String.Empty)
            {
                lblDisplayText2.Text = "Enter all fields above!";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}