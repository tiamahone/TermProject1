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
        string[] loginInfo = new string[2];
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
                loginInfo[0] = Session["User"].ToString();
                loginInfo[1] = Session["Password"].ToString();
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
            btnUserEditUser.Visible = true;
            btnMyFiles.Visible = true;
        }
        public void stateAdmin()
        {
            btnAddAdmin.Visible = true;
            btnViewTransactions.Visible = true;
            btnAdminEditUser.Visible = true;
            btnDeleteUser.Visible = true;
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            userFormsOff();
            int fileSize;
            string fileType, fileName;
            if (fileUp.HasFile)
            {
                fileSize = fileUp.PostedFile.ContentLength;
                byte[] fileData = new byte[fileSize];

                fileUp.PostedFile.InputStream.Read(fileData, 0, fileSize);
                fileName = fileUp.PostedFile.FileName;
                fileType = fileUp.PostedFile.ContentType;

                string response = Functions.fileUpload(loginInfo, Session["User"].ToString(), fileName, fileType, 
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
            dropUser.DataSource = Functions.getCloudUsers(loginInfo);
            dropUser.DataTextField = "Email";
            dropUser.DataBind();
            transactionFormOn();       
        }

        protected void btnGetTransactions_Click(object sender, EventArgs e)
        {
            gvTransactions.DataSource = Functions.getTransactions(loginInfo, dropUser.SelectedItem.ToString(),
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

        public void userFormsOff()
        {
            gvUserFiles.Visible = false;
            lblFile.Visible = false; fileUp.Visible = false;
            lblFreeUserSpace.Visible = false; btnFile.Visible = false;
            gvUserModify.Visible = false;
        }


        protected void gvAdminModify_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvAdminModify_PageIndexChanging(Object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvAdminModify.PageIndex = e.NewPageIndex;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo(loginInfo);
            gvAdminModify.DataBind();
        }
        protected void gvAdminModify_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvAdminModify.EditIndex = e.NewEditIndex;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo(loginInfo);
            gvAdminModify.DataBind();
        }

        protected void gvAdminModify_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvAdminModify.EditIndex = -1;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo(loginInfo);
            gvAdminModify.DataBind();
        }
        protected void gvAdminModify_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string email = gvAdminModify.Rows[rowIndex].Cells[2].Text;
            TextBox passwordBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[3].Controls[0];
            TextBox phoneBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[4].Controls[0];
            TextBox totalBox = (TextBox)gvAdminModify.Rows[rowIndex].Cells[6].Controls[0];
            Functions.adminUpdateUser(loginInfo, email, passwordBox.Text, phoneBox.Text, totalBox.Text);
            gvAdminModify.EditIndex = -1;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo(loginInfo);
            gvAdminModify.DataBind();

         }

        protected void btnAdminEditUser_Click(object sender, EventArgs e)
        {
            adminFormsOff();
            gvAdminModify.Visible = true;
            gvAdminModify.DataSource = Functions.getCloudUsersInfo(loginInfo);
            gvAdminModify.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            adminFormsOff();
            gvDelete.Visible = true;
            gvDelete.DataSource = Functions.getCloudUsersInfo(loginInfo);
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
                    Functions.deleteUser(loginInfo, email);
                }
            }
            if (checkCount == 0)
            {
                //tell user to check something
            }
            else
            {
                gvDelete.DataSource = Functions.getCloudUsersInfo(loginInfo);
                gvDelete.DataBind();
            }
        }

        protected void btnUserEditUser_Click(object sender, EventArgs e)
        {
            userFormsOff();
            gvUserModify.Visible = true;
            gvUserModify.DataSource = Functions.getSingleUserInfo(loginInfo, Session["User"].ToString());
            gvUserModify.DataBind(); 
        }
        protected void gvUserModify_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvUserModify_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvUserModify.EditIndex = e.NewEditIndex;
            gvUserModify.DataSource = Functions.getSingleUserInfo(loginInfo, Session["User"].ToString());
            gvUserModify.DataBind();
        }

        protected void gvUserModify_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvUserModify.EditIndex = -1;
            gvUserModify.DataSource = Functions.getSingleUserInfo(loginInfo, Session["User"].ToString());
            gvUserModify.DataBind();
        }
        protected void gvUserModify_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int id = Convert.ToInt32(gvUserModify.Rows[rowIndex].Cells[0].Text);
            TextBox nameBox = (TextBox)gvUserModify.Rows[rowIndex].Cells[1].Controls[0];
            TextBox emailBox = (TextBox)gvUserModify.Rows[rowIndex].Cells[2].Controls[0];
            TextBox passwordBox = (TextBox)gvUserModify.Rows[rowIndex].Cells[3].Controls[0];
            TextBox phoneBox = (TextBox)gvUserModify.Rows[rowIndex].Cells[4].Controls[0];
            Functions.userUpdateUser(loginInfo, id, nameBox.Text, emailBox.Text, passwordBox.Text, phoneBox.Text);
            gvUserModify.EditIndex = -1;
            gvUserModify.DataSource = Functions.getSingleUserInfo(loginInfo, Session["User"].ToString());
            gvUserModify.DataBind();

        }

        protected void btnMyFiles_Click(object sender, EventArgs e)
        {
            userFormsOff();
            lblFile.Visible = true; fileUp.Visible = true;
            lblFreeUserSpace.Visible = true; btnFile.Visible = true;
            lblFreeUserSpace.Text = "Free Space Remaining: " +
                Functions.getUserFreeSpace(loginInfo, Session["User"].ToString()) +
                " Bytes";
            gvUserFiles.DataSource = Functions.getFilesByUser(loginInfo, Session["User"].ToString());
            gvUserFiles.DataBind(); gvUserFiles.Visible = true;
        }







    }
}