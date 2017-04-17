﻿using System;
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

        public static string addUser(string name, string email, string password, string phone)
        {
            string[] userInfo = new string[4];
            string response = "";
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
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

        public static string addAdmin(string name, string email, string password, string phone)
        {
            string[] userInfo = new string[4];
            string response = "";
            CloudSVCRef.CloudSVC pxy = new CloudSVCRef.CloudSVC();
            userInfo[0] = name; userInfo[1] = email;
            userInfo[2] = password; userInfo[3] = phone;
            int result = pxy.addAdmin(userInfo);

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

        public static string fileUpload(string email, string fileName, string fileType, int fileSize, byte[] fileData)
        {
            string response = "";
            string[] fileInfo = new string[4];
            CloudSVCRef1.CloudSVC pxy = new CloudSVCRef1.CloudSVC();
            fileInfo[0] = email; fileInfo[1] = fileName;
            fileInfo[2] = fileType; fileInfo[3] = fileSize.ToString();

            int result = pxy.addFile(fileInfo, fileData);

            if (result == 0)
            {
                response = "File successfully added!";
            }
            else if (result == -1)
            {
                response = "Error";
            }

            return response;

        }

        public static DataSet getFilesByUser(string email)
        {
            string[] userInfo = new string[1];
            CloudSVCRef1.CloudSVC pxy = new CloudSVCRef1.CloudSVC();
            userInfo[0] = email;
            DataSet myDS = pxy.getFilesByUser(userInfo);
            return myDS;
        }
    }
}