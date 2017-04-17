using Class_Library;
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
                lblDisplayText.Text = "Welcome " + Session["User"].ToString();
                if (Session["Login"].ToString() == "Success Admin")
                {
                    stateAdmin();
                }
                else if (Session["Login"].ToString() == "Success User")
                {
                    stateUser();
                }
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

        protected void btnAddAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
        public void stateUser()
        {
            lblFile.Visible = true; fileUp.Visible = true;
            lblFreeUserSpace.Visible = true; btnFile.Visible = true;
            lblFreeUserSpace.Text = "Free Space Remaining: " +
                Functions.getUserFreeSpace(Session["User"].ToString()) +
                " Bytes";
            gvUserFiles.DataSource = Functions.getFilesByUser(Session["User"].ToString());
            gvUserFiles.DataBind(); gvUserFiles.Visible = true;


        }
        public void stateAdmin()
        {
            btnAddAdmin.Visible = true;
            btnViewTransactions.Visible = true;
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            int fileSize;
            string fileType, fileName;
            if (fileUp.HasFile)
            {
                fileSize = fileUp.PostedFile.ContentLength;
                byte[] fileData = new byte[fileSize];

                fileUp.PostedFile.InputStream.Read(fileData, 0, fileSize);
                fileName = fileUp.PostedFile.FileName;
                fileType = fileUp.PostedFile.ContentType;

                string response = Functions.fileUpload(Session["User"].ToString(), fileName, fileType, 
                    fileSize, fileData);
                lblDisplayText.Text = response;

                stateUser();
            }    
        }

        protected void gvTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnViewTransactions_Click(object sender, EventArgs e)
        {
            dropUser.DataSource = Functions.getCloudUsers();
            dropUser.DataTextField = "Email";
            dropUser.DataBind();
            transactionFormOn();       
        }

        protected void btnGetTransactions_Click(object sender, EventArgs e)
        {
            gvTransactions.DataSource = Functions.getTransactions(dropUser.SelectedItem.ToString(),
                dropTimePeriod.SelectedItem.ToString());
            gvTransactions.DataBind();
            gvTransactions.Visible = true;
        }
        
        public void transactionFormOn()
        {
            lblSelectUser.Visible = true;
            dropUser.Visible = true; lblSelectTimePeriod.Visible = true;
            dropTimePeriod.Visible = true;
            btnGetTransactions.Visible = true;
        }
        public void transactionFormOff()
        {
            lblSelectUser.Visible = false;
            dropUser.Visible = false; lblSelectTimePeriod.Visible = false;
            dropTimePeriod.Visible = false;
            btnGetTransactions.Visible = false;
            gvTransactions.Visible = false;
        }
    }
}