using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Class_Library
{
    public partial class Functions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string attemptLogin(string email, string password)
        {
            string[] loginInfo = new string[2];
            string response = "";
            loginInfo[0] = email; loginInfo[1] = password;
            CloudService.CloudSVC pxy = new CloudService.CloudSVC();

            int result = pxy.attemptLogin(loginInfo);
            if (result == -1)
            {
                response = "Not Found";
            }
            else if (result == 0)
            {
                response = "Invalid Password";
            }
            else if (result == 1)
            {
                response = "Success User";
            }
            else if (result == 2)
            {
                response = "Success Admin";
            }

            return response;

        }

        public static string addUser(string name, string email, string password, string phone)
        {
            string[] userInfo = new string[4];
            string response = "";
            CloudService.CloudSVC pxy = new CloudService.CloudSVC();
            userInfo[0] = name; userInfo[1] = email;
            userInfo[2] = password; userInfo[3] = phone;
            int result = pxy.addUser(userInfo);

            if (result == 0)
            {
                response = "User successfully registered!";
            }
            else if (result == -1)
            {
                response = "Error: User already exists";
            }

            return response;
        }

    }
}