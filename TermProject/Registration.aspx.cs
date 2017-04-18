﻿using System;
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
        string[] loginInfo = new string[2];
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (Session["Login"] != null)
            {
                loginInfo[0] = Session["User"].ToString();
                loginInfo[1] = Session["Password"].ToString();
                if (Session["Login"].ToString() == "Success Admin")
                {
                    btnRegister.Text = "Register Admin";
                    lblRemember.Visible = false;
                    chkRemember.Checked = false;
                    chkRemember.Visible = false;
                }
            }
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            string result = "";
            if (Validation())
            {
                if (txtPassword.Text != txtConfirm.Text)
                {
                    lblDisplayText.Text = "Passwords must match";
                }
                else
                {
                    if (Session["Login"] != null)
                    {
                        if (Session["Login"].ToString() == "Success Admin")
                        {
                            result = Functions.addAdmin(loginInfo, txtName.Text, txtEmail.Text,
                            txtPassword.Text, txtPhone.Text);
                        }
                    }
                    else
                    {
                        result = Functions.addUser(loginInfo, txtName.Text, txtEmail.Text,
                            txtPassword.Text, txtPhone.Text);
                    }

                    lblDisplayText.Text = result;

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
                }
            }

        }

        public Boolean Validation()
        {

            if (txtName.Text == String.Empty || 
                txtEmail.Text == String.Empty || 
                txtPassword.Text == String.Empty || 
                txtConfirm.Text == String.Empty || 
                txtPhone.Text == String.Empty)
            {
                lblDisplayText.Text = "Enter all fields above!";
                return false;
            }
            else
            {
                return true;
            }

            
        }
    }
}