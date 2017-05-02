using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Class_Library;

namespace TermProject
{
    public partial class StorageOptions : System.Web.UI.Page
    {
        double storage;
        
        string[] loginInfo = new string[2];
        string email = "";
        int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                lblDisplayText.Text = Session["User"].ToString() + "'s Storage Options";
                loginInfo[0] = Session["User"].ToString();
                loginInfo[1] = Session["Password"].ToString();
                email = Session["User"].ToString();
                if(Session["Index"] != null)
                {
                    index = Convert.ToInt32(Session["Index"]);
                }
                // if (!IsPostBack)
                // {
                stateLoggedIn();
                //}
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

        public void stateLoggedIn()
        {
            rdoStorageOptions.Visible = true;
            lblDisplayText2.Text = "";
            if (!IsPostBack)
            {
                storage = Convert.ToDouble(Functions.getUserTotalSpace(loginInfo, email));
                storage = storage / 1000000;
                if (storage == 100)
                {
                    rdoStorageOptions.SelectedIndex = 0; ;
                    rdoStorageOptions.SelectedItem.Text = "100 MB (Free) -- Current Plan";
                    index = 0;
                }
                else if (storage == 1000)
                {
                    rdoStorageOptions.SelectedIndex = 1; ;
                    rdoStorageOptions.SelectedItem.Text = "1 GB ($0.99/Month) -- Current Plan";
                    index = 1;
                }
                else if (storage == 2000)
                {
                    rdoStorageOptions.SelectedIndex = 2; ;
                    rdoStorageOptions.SelectedItem.Text = "2 GB ($1.99/Month) -- Current Plan";
                    index = 2;
                }
                else if (storage == 5000)
                {
                    rdoStorageOptions.SelectedIndex = 3; ;
                    rdoStorageOptions.SelectedItem.Text = "5 GB ($2.99/Month) -- Current Plan";
                    index = 3;
                }
                else if (storage == 10000)
                {
                    rdoStorageOptions.SelectedIndex = 4; ;
                    rdoStorageOptions.SelectedItem.Text = "10 GB ($4.99/Month) -- Current Plan";
                    index = 4;
                }
                else if (storage == 50000)
                {
                    rdoStorageOptions.SelectedIndex = 5; ;
                    rdoStorageOptions.SelectedItem.Text = "50 GB ($9.99/Month) -- Current Plan";
                    index = 5;
                }
                Session["Index"] = index;
            }

        }

        public void paymentFormOn()
        {
            lblAddress.Visible = true; lblCardNumber.Visible = true; lblCardType.Visible = true;
            lblCity.Visible = true; lblExpiration.Visible = true; lblName.Visible = true; lblSecurityCode.Visible = true;
            lblState.Visible = true; lblZipCode.Visible = true; txtAddress.Visible = true; txtCardNumber.Visible = true;
            txtCity.Visible = true; txtName.Visible = true; txtSecurityCode.Visible = true; txtZipCode.Visible = true;
            ddlCardType.Visible = true; ddlMonth.Visible = true; ddlState.Visible = true; ddlYear.Visible = true;
            btnSubmit.Visible = true;
        }
        public void paymentFormOff()
        {
            lblAddress.Visible = false; lblCardNumber.Visible = false; lblCardType.Visible = false;
            lblCity.Visible = false; lblExpiration.Visible = false; lblName.Visible = false; lblSecurityCode.Visible = false;
            lblState.Visible = false; lblZipCode.Visible = false; txtAddress.Visible = false; txtCardNumber.Visible = false;
            txtCity.Visible = false; txtName.Visible = false; txtSecurityCode.Visible = false; txtZipCode.Visible = false;
            ddlCardType.Visible = false; ddlMonth.Visible = false; ddlState.Visible = false; ddlYear.Visible = false;
            btnSubmit.Visible = false;
        }

        protected void btnChangePlan_Click(object sender, EventArgs e)
        {
            if (rdoStorageOptions.SelectedIndex == index)
            {
                lblDisplayText2.Text = "Must choose plan different from current plan";

            }
            else if (rdoStorageOptions.SelectedIndex == 0) 
            {
                lblDisplayText2.Text = "Plan Successfully changed";
            }
            
            else
            {
                paymentFormOn();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validations())
            {
                lblDisplayText2.Text = "Plan Successfully changed";
                paymentFormOff();
                Functions.changeStoragePlan(loginInfo, email, rdoStorageOptions.SelectedIndex);
            }
        }


        public bool Validations()
        {
            if (txtAddress.Text == String.Empty ||
                txtCardNumber.Text == String.Empty ||
                txtCity.Text == String.Empty||
                txtName.Text == String.Empty ||
                txtSecurityCode.Text == String.Empty ||
                txtZipCode.Text == String.Empty
                )
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