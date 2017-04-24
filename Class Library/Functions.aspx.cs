using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();

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

        public static string addUser(string[] loginInfo, string name, string email, string password, string phone)
        {
            string[] userInfo = new string[4];
            string response = "";
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            userInfo[0] = name; userInfo[1] = email;
            userInfo[2] = password; userInfo[3] = phone;
            int result = pxy.addUser(loginInfo, userInfo);

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

        public static string addAdmin(string[] loginInfo, string name, string email, string password, string phone)
        {
            string[] userInfo = new string[4];
            string response = "";
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            userInfo[0] = name; userInfo[1] = email;
            userInfo[2] = password; userInfo[3] = phone;
            int result = pxy.addAdmin(loginInfo, userInfo);

            if (result == 0)
            {
                response = "Admin successfully registered!";
            }
            else if (result == -1)
            {
                response = "Error: Admin already exists";
            }

            return response;

        }

        public static string fileUpload(string[] loginInfo, string email, string fileName, string fileType, int fileSize, byte[] fileData)
        {
            string response = "";
            string[] fileInfo = new string[4];
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            fileInfo[0] = email; fileInfo[1] = fileName;
            fileInfo[2] = fileType; fileInfo[3] = fileSize.ToString();

            int result = pxy.addFile(loginInfo, fileInfo, fileData);

            if (result == 0)
            {
                response = "File successfully added!";
            }
            else if (result == -1)
            {
                response = "Error: Not Enough Free Storage";
            }

            return response;

        }

        public static DataSet getFilesByUser(string[] loginInfo, string email)
        {
            string[] userInfo = new string[1];
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            userInfo[0] = email;
            DataSet myDS = pxy.getFilesByUser(loginInfo, userInfo);
            return myDS;
        }

        public static string getUserFreeSpace(string[] loginInfo, string email)
        {
            string response = "";
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            string[] userInfo = new string[1];
            userInfo[0] = email;
            response = pxy.getUserFreeStorage(loginInfo, userInfo).ToString();
            return response;
        }

        public static DataSet getTransactions(string[] loginInfo, string user, string timePeriod)
        {
            string[] userInfo = new string[2];
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            userInfo[0] = user; userInfo[1] = timePeriod;
            DataSet myDS = pxy.getTransactions(loginInfo, userInfo);
            return myDS;
        }

        public static DataSet getCloudUsers(string[] loginInfo)
        {
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            DataSet myDS = pxy.getCloudUsers(loginInfo);
            return myDS;
        }
        public static DataSet getCloudUsersInfo(string[] loginInfo)
        {
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            DataSet myDS = pxy.getCloudUsersInfo(loginInfo);
            return myDS;
        }

        public static int adminUpdateUser(string[] loginInfo, string email, string password, string phone, string total)
        {
            string[] userInfo = new string[4];
            userInfo[0] = email;
            userInfo[1] = password;
            userInfo[2] = phone;
            userInfo[3] = total;
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            int response = pxy.adminUpdateUser(loginInfo, userInfo);
            return response;
        }

        public static int deleteUser(string[] loginInfo, string email)
        {
            string[] userInfo = new string[1];
            userInfo[0] = email;
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            int response = pxy.deleteUser(loginInfo, userInfo);
            return response;
        }

        public static DataSet getSingleUserInfo(string[] loginInfo, string email)
        {
            string[] userInfo = new string[1];
            userInfo[0] = email;
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            DataSet myDS = pxy.getSingleUserInfo(loginInfo, userInfo);
            return myDS;
        }

        public static int userUpdateUser(string[] loginInfo, int id, string name, string email, string password, string phone)
        {
            string[] userInfo = new string[5];
            userInfo[0] = id.ToString();
            userInfo[1] = name;
            userInfo[2] = email;
            userInfo[3] = password;
            userInfo[4] = phone;
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            int response = pxy.userUpdateUser(loginInfo, userInfo);
            return response;
        }

        public static int deleteFile(string[] loginInfo, string fileName, string fileSize)
        {
            string[] userInfo = new string[2];
            userInfo[0] = fileName;
            userInfo[1] = fileSize;
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            int response = pxy.deleteFile(loginInfo, userInfo);
            return response;
        }
    }
}