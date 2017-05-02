using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Class_Library;

namespace TermProject
{
    public partial class Trash : System.Web.UI.Page
    {
        string[] loginInfo = new string[2];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                lblDisplayText.Text = Session["User"].ToString() + "'s Trash Can";
                
                loginInfo[0] = Session["User"].ToString();
                loginInfo[1] = Session["Password"].ToString();

                gvTrash.DataSource = Functions.getUserTrash(loginInfo, Session["User"].ToString());
                gvTrash.DataBind();
            }
            else
            {
                lblDisplayText.Text = "Error: Must Login in";
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void gvTrash_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("recover"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = gvTrash.Rows[index].Cells[1].Text;
                string[] userInfo = new string[2];
                userInfo[0] = Session["User"].ToString(); userInfo[1] = id;
                int response = Functions.recoverFile(loginInfo, userInfo);
                gvTrash.DataSource = Functions.getUserTrash(loginInfo, Session["User"].ToString());
                gvTrash.DataBind();
                if (response == -1)
                {
                    lblDisplayText2.Text = "Not enough free space to recover file.";
                }

            }
        }

    }
}