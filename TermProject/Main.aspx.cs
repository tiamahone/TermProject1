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
            btnEditUser.Visible = true;
            btnDeleteUser.Visible = true;
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
            adminFormsOff();
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
        public void adminFormsOff()
        {
            lblSelectUser.Visible = false;
            dropUser.Visible = false; lblSelectTimePeriod.Visible = false;
            dropTimePeriod.Visible = false;
            btnGetTransactions.Visible = false;
            gvTransactions.Visible = false;
            gvAdminModify.Visible = false;
            btnDeleteSelection.Visible = false;
            gvDelete.Visible = false;
        }


        protected void gvAdminModify_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvAdminModify_PageIndexChanging(Object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvAdminModify.PageIndex = e.NewPageIndex;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo();
            gvAdminModify.DataBind();
        }
        protected void gvAdminModify_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvAdminModify.EditIndex = e.NewEditIndex;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo();
            gvAdminModify.DataBind();
        }

        protected void gvAdminModify_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvAdminModify.EditIndex = -1;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo();
            gvAdminModify.DataBind();
        }
        protected void gvAdminModify_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string email = gvAdminModify.Rows[rowIndex].Cells[2].Text;
            TextBox passwordBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[3].Controls[0];
            TextBox phoneBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[4].Controls[0];
            TextBox totalBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[6].Controls[0];
            Functions.adminUpdateUser(email, passwordBox.Text, phoneBox.Text, totalBox.Text);
            gvAdminModify.EditIndex = -1;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo();
            gvAdminModify.DataBind();

         }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            adminFormsOff();
            gvAdminModify.Visible = true;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo();
            gvAdminModify.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            adminFormsOff();
            gvDelete.Visible = true;
            gvDelete.DataSource = Functions.getCloudUsersInfo();
            gvDelete.DataBind();
            btnDeleteSelection.Visible = true;
        }
        protected void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            int checkCount = 0;
            for (int row = 0; row < gvDelete.Rows.Count; row++)
            {
                CheckBox CBox = (CheckBox)gvDelete.Rows[row].FindControl("chkSelect");
                if (CBox.Checked)
                {
                    checkCount++;
                    string email = gvDelete.Rows[row].Cells[3].Text;
                    Functions.deleteUser(email);
                }
            }
            if (checkCount == 0)
            {
                //tell user to check something
            }
            else
            {
                gvDelete.DataSource = Functions.getCloudUsersInfo();
                gvDelete.DataBind();
            }
        }
    






    }
}