using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;

namespace CloudService
{
    /// <summary>
    /// Summary description for CloudSVC
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CloudSVC : System.Web.Services.WebService
    {

        [WebMethod]
        public int attemptLogin(string[] loginInfo)
        {
            int response;
            string email = loginInfo[0];
            string password = loginInfo[1];
            DBConnect objDB;
            SqlCommand objCommand;
            DataSet myDs;


            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCloudUserInfo";
            objCommand.Parameters.AddWithValue("@email", email);
            myDs = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDs.Tables[0].Rows.Count != 0)
            {
                if (password != objDB.GetField("Password", 0).ToString())
                {
                    response = 0;
                }
                else
                {
                    response = 1;
                }
            }
            else
            {
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudAdminInfo";
                objCommand.Parameters.AddWithValue("@email", email);
                myDs = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDs.Tables[0].Rows.Count != 0)
                {
                    if (password != objDB.GetField("Password", 0).ToString())
                    {
                        response = 0;
                    }
                    else
                    {
                        response = 2;
                    }
                }
                else
                {
                    response = -1;
                }
            }
            return response;
        }

        [WebMethod]
        public int addUser(string[] userInfo)
        {
            int response;
            //if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            //{
            string name = userInfo[0];
            string email = userInfo[1];
            string password = userInfo[2];
            string phone = userInfo[3];
            DBConnect objDB;
            SqlCommand objCommand;
            DataSet myDs;

            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetCloudUserInfo";
            objCommand.Parameters.AddWithValue("@email", email);
            myDs = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDs.Tables[0].Rows.Count != 0)
            {
                response = -1;
            }
            else
            {
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddCloudUser";
                objCommand.Parameters.AddWithValue("@name", name);
                objCommand.Parameters.AddWithValue("@email", email);
                objCommand.Parameters.AddWithValue("@password", password);
                objCommand.Parameters.AddWithValue("@phone", phone);
                //myDs = objDB.GetDataSetUsingCmdObj(objCommand);
                objDB.DoUpdateUsingCmdObj(objCommand);
                response = 0;
            }
            //} 
            // else
            //{
            //    response = -1;
            //}
            return response;
        }

        [WebMethod]
        public int addAdmin(string[] loginInfo, string[] userInfo)
        {
            int response;
            if (attemptLogin(loginInfo) == 2)
            {
                string name = userInfo[0];
                string email = userInfo[1];
                string password = userInfo[2];
                string phone = userInfo[3];
                DBConnect objDB;
                SqlCommand objCommand;
                DataSet myDs;

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudAdminInfo";
                objCommand.Parameters.AddWithValue("@email", email);
                myDs = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDs.Tables[0].Rows.Count != 0)
                {
                    response = -1;
                }
                else
                {
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddCloudAdmin";
                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@email", email);
                    objCommand.Parameters.AddWithValue("@password", password);
                    objCommand.Parameters.AddWithValue("@phone", phone);
                    //myDs = objDB.GetDataSetUsingCmdObj(objCommand);
                    objDB.DoUpdateUsingCmdObj(objCommand);
                    response = 0;
                }
            }
            else
            {
                response = -1;
            }
            return response;
        }

        [WebMethod]
        public int addFile(string[] loginInfo, string[] fileInfo, byte[] fileData)
        {
            int response = 0;
            string transactionType = "Upload";
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                string fileEmail = fileInfo[0];
                string fileName = fileInfo[1];
                string fileType = fileInfo[2];
                double fileSize = Convert.ToDouble(fileInfo[3]);
                double freeStorage = getUserFreeStorage(loginInfo, fileInfo);

                DBConnect objDB;
                SqlCommand objCommand;

                //Checks to see if file already exists
                //DataSet myDs = checkForFile(loginInfo, fileInfo);
                double oldFileSize = checkForFile(loginInfo, fileInfo);
                //if (myDs.Tables[0].Rows.Count != 0
                if (oldFileSize != 0)
                {
                    string[] file = new string[3];
                    file[0] = fileName;
                    //file[1] = fileSize.ToString();
                    file[1] = oldFileSize.ToString();
                    deleteFile(loginInfo, file);
                    transactionType = "Update";
                    response = 1;

                }
                //Checks to see if enough storage is available
                if (fileSize > freeStorage)
                {
                    response = -1;
                }
                else
                {
                    //Adds file to DB
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddCloudFile";
                    objCommand.Parameters.AddWithValue("@email", fileEmail);
                    objCommand.Parameters.AddWithValue("@fileName", fileName);
                    objCommand.Parameters.AddWithValue("@fileType", fileType);
                    objCommand.Parameters.AddWithValue("@fileSize", fileSize);
                    objCommand.Parameters.AddWithValue("@fileData", fileData);
                    objDB.DoUpdateUsingCmdObj(objCommand);

                    //Updates free storage number in CloudUsersDB
                    double newFreeStorage = freeStorage - fileSize;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "UpdateUserFreeStorage";
                    objCommand.Parameters.AddWithValue("@email", fileEmail);
                    objCommand.Parameters.AddWithValue("@newStorage", newFreeStorage);
                    objDB.DoUpdateUsingCmdObj(objCommand);

                    //Adds transaction record to CloudUserTransactions table
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddCloudTransaction";
                    objCommand.Parameters.AddWithValue("@email", fileEmail);
                    objCommand.Parameters.AddWithValue("@type", transactionType);
                    objCommand.Parameters.AddWithValue("@fileName", fileName);
                    objCommand.Parameters.AddWithValue("@time", DateTime.Now);
                    objDB.DoUpdateUsingCmdObj(objCommand);
                }
            }
            else
            {
                response = -1;
            }
            return response;
        }

        [WebMethod]
        public double checkForFile(string[] loginInfo, string[] userInfo)
        {
            double size = 0;
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "checkForFile";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                objCommand.Parameters.AddWithValue("@fileName", userInfo[1]);
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                if (myDS.Tables[0].Rows.Count != 0)
                {
                    size = Convert.ToDouble(objDB.GetField("File Size", 0));
                }
            }
            //return myDS;
            return size;
        }

        [WebMethod]
        public DataSet getFilesByUser(string[] loginInfo, string[] userInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudFilesByUser";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);        
            }
            return myDS;

        }

        [WebMethod]
        public double getUserFreeStorage(string[] loginInfo, string[] userInfo)
        {
            double freeStorage = 0;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudUserFreeStorage";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                DBConnect objDB = new DBConnect();
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                freeStorage = Convert.ToDouble(objDB.GetField("Free Storage", 0));
            }
            return freeStorage;
        }

        [WebMethod]
        public double getUserTotalStorage(string[] loginInfo, string[] userInfo)
        {
            double totalStorage = 0;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudUserTotalStorage";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                DBConnect objDB = new DBConnect();
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                totalStorage = Convert.ToDouble(objDB.GetField("Total Storage", 0));
            }
            return totalStorage;
        }

        [WebMethod]
        public DataSet getCloudUsers(string[] loginInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudUsers";
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            }
            return myDS;
        }

        [WebMethod]
        public DataSet getCloudUsersInfo(string[] loginInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudUsersInfo";
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            }
            return myDS;
        }

        [WebMethod]
        public DataSet getTransactions(string[] loginInfo, string[] userInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetCloudTransactions";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                if (userInfo[1] == "All")
                {
                    objCommand.Parameters.AddWithValue("@timePeriod", "1/01/1900 12:00:01 AM");
                }
                else if (userInfo[1] == "Past Day")
                {
                    DateTime timePeriod = (Convert.ToDateTime(userInfo[1])).AddDays(-1);
                    objCommand.Parameters.AddWithValue("@timePeriod", userInfo[1]);
                }
                else if (userInfo[1] == "Past Week")
                {
                    DateTime timePeriod = (Convert.ToDateTime(userInfo[1])).AddDays(-7);
                    objCommand.Parameters.AddWithValue("@timePeriod", userInfo[1]);
                }
                else if (userInfo[1] == "Past Month")
                {
                    DateTime timePeriod = (Convert.ToDateTime(userInfo[1])).AddDays(-30);
                    objCommand.Parameters.AddWithValue("@timePeriod", userInfo[1]);
                }

                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            }
            return myDS;
        }

        [WebMethod]
        public int adminUpdateUser(string[] loginInfo, string[] userInfo)
        {
            int response = -1;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                double freeStorage = getUserFreeStorage(loginInfo, userInfo);
                double oldTotalStorage = getUserTotalStorage(loginInfo, userInfo);
                double difference = (Convert.ToDouble(userInfo[3])) - oldTotalStorage;
                freeStorage += difference;

                SqlCommand objCommand = new SqlCommand();
                DBConnect objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateCloudUser";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                objCommand.Parameters.AddWithValue("@password", userInfo[1]);
                objCommand.Parameters.AddWithValue("@phone", userInfo[2]);
                objCommand.Parameters.AddWithValue("@totalStorage", userInfo[3]);
                objCommand.Parameters.AddWithValue("@freeStorage", freeStorage);
                objDB.DoUpdateUsingCmdObj(objCommand);
                response = 0;
            }
            return response;
        }

        [WebMethod]
        public int deleteUser(string[] loginInfo, string[] userInfo)
        {
            int response = -1;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                DBConnect objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DeleteCloudUser";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                objDB.DoUpdateUsingCmdObj(objCommand);
                response = 0;
            }
            return response;
        }

        [WebMethod]
        public DataSet getSingleUserInfo(string[] loginInfo, string[] userInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetSingleCloudUser";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            }
            return myDS;
        }

        [WebMethod]
        public int userUpdateUser(string[] loginInfo, string[] userInfo)
        {
            int response = -1;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                DBConnect objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateCloudUserPersonal";
                objCommand.Parameters.AddWithValue("@id", Convert.ToInt32(userInfo[0]));
                objCommand.Parameters.AddWithValue("@name", userInfo[1]);
                objCommand.Parameters.AddWithValue("@email", userInfo[2]);
                objCommand.Parameters.AddWithValue("@password", userInfo[3]);
                objCommand.Parameters.AddWithValue("@phone", userInfo[4]);
                objDB.DoUpdateUsingCmdObj(objCommand);
                response = 0;
            }

            return response;
        }

        [WebMethod]
        public int deleteFile(string[] loginInfo, string[] userInfo)
        {
            int response = -1;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                DBConnect objDB = new DBConnect();

                //GET FILE
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetFile";
                objCommand.Parameters.AddWithValue("@email", loginInfo[0]);
                objCommand.Parameters.AddWithValue("@fileName", userInfo[0]);
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                string email = objDB.GetField("Email", 0).ToString();
                string fileName = objDB.GetField("File Name", 0).ToString();
                string fileType = objDB.GetField("File Type", 0).ToString();
                double fileSizeOld = Convert.ToDouble(objDB.GetField("File Size", 0));
                byte[] fileData = (byte[])objDB.GetField("File Data", 0);
                DateTime timeStamp = DateTime.Now;
                //byte[] image = (byte[])objDB.GetField("File Image", 0);

                //Put file in trash
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddToTrash";
                objCommand.Parameters.AddWithValue("@email", email);
                objCommand.Parameters.AddWithValue("@fileName", fileName);
                objCommand.Parameters.AddWithValue("@fileType", fileType);
                objCommand.Parameters.AddWithValue("@fileSize", fileSizeOld);
                objCommand.Parameters.AddWithValue("@fileData", fileData);
                objCommand.Parameters.AddWithValue("@timeStamp", timeStamp);
                //objCommand.Parameters.AddWithValue("@image", image);
                objDB.DoUpdateUsingCmdObj(objCommand);


                //Delete File
                objDB = new DBConnect();
                objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DeleteFile";
                objCommand.Parameters.AddWithValue("@email", loginInfo[0]);
                objCommand.Parameters.AddWithValue("@fileName", userInfo[0]);
                objDB.DoUpdateUsingCmdObj(objCommand);

                double oldFreeSpace = Convert.ToDouble(getUserFreeStorage(loginInfo, loginInfo));
                double fileSize = Convert.ToDouble(userInfo[1]);
                double newFreeSpace = oldFreeSpace + fileSize;


                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateFreeSpace";
                objCommand.Parameters.AddWithValue("@email", loginInfo[0]);
                objCommand.Parameters.AddWithValue("@freeStorage", newFreeSpace);
                objDB.DoUpdateUsingCmdObj(objCommand);

                // add transaction
                if (userInfo[2] == "delete")
                {
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "AddCloudTransaction";
                    objCommand.Parameters.AddWithValue("@email", email);
                    objCommand.Parameters.AddWithValue("@type", "Delete");
                    objCommand.Parameters.AddWithValue("@fileName", fileName);
                    objCommand.Parameters.AddWithValue("@time", DateTime.Now);
                    objDB.DoUpdateUsingCmdObj(objCommand);
                }

                response = 0;
            }
            return response;
        }

        [WebMethod]
        public DataSet getUserTrash(string[] loginInfo, string[] userInfo)
        {
            DataSet myDS = null;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetTrashByUser ";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                DBConnect objDB = new DBConnect();
                myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            }
            return myDS;
        }

        [WebMethod]
        public int changeStoragePlan(string[] loginInfo, string[] userInfo)
        {
            int response = 0;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                double freeStorage = getUserFreeStorage(loginInfo, userInfo);
                double totalStorage = getUserTotalStorage(loginInfo, userInfo);
                double newTotalStorage = Convert.ToDouble(userInfo[1]);
                double newFreeStorage = freeStorage + (newTotalStorage - totalStorage);
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "ChangeStoragePlan";
                objCommand.Parameters.AddWithValue("@email", userInfo[0]);
                objCommand.Parameters.AddWithValue("@freeStorage", newFreeStorage);
                objCommand.Parameters.AddWithValue("@totalStorage", newTotalStorage);
                objDB.DoUpdateUsingCmdObj(objCommand);
            }
            return response;
        }

        [WebMethod]
        public int recoverFile(string[] loginInfo, string[] userInfo)
        {
            int response = 0;
            if (attemptLogin(loginInfo) == 1 || attemptLogin(loginInfo) == 2)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                //GET FILE
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GetFileFromTrash";
                objCommand.Parameters.AddWithValue("@id", userInfo[1]);
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
                string email = objDB.GetField("Email", 0).ToString();
                string fileName = objDB.GetField("File Name", 0).ToString();
                fileName += "-R";
                string fileType = objDB.GetField("File Type", 0).ToString();
                double fileSizeOld = Convert.ToDouble(objDB.GetField("File Size", 0));
                byte[] fileData = (byte[])objDB.GetField("File Data", 0);
                DateTime timeStamp = DateTime.Now;

                //Update Free Space
                double oldFreeSpace = Convert.ToDouble(getUserFreeStorage(loginInfo, loginInfo));
                double newFreeSpace = oldFreeSpace - fileSizeOld;
                if (oldFreeSpace < fileSizeOld)
                {
                    return -1;
                }

                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "UpdateFreeSpace";
                objCommand.Parameters.AddWithValue("@email", loginInfo[0]);
                objCommand.Parameters.AddWithValue("@freeStorage", newFreeSpace);
                objDB.DoUpdateUsingCmdObj(objCommand);

                //Put file back
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddCloudFile";
                objCommand.Parameters.AddWithValue("@email", email);
                objCommand.Parameters.AddWithValue("@fileName", fileName);
                objCommand.Parameters.AddWithValue("@fileType", fileType);
                objCommand.Parameters.AddWithValue("@fileSize", fileSizeOld);
                objCommand.Parameters.AddWithValue("@fileData", fileData);
                objDB.DoUpdateUsingCmdObj(objCommand);


                //Delete File From Trash
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "DeleteFileFromTrash";
                objCommand.Parameters.AddWithValue("@id", userInfo[1]);
                objDB.DoUpdateUsingCmdObj(objCommand);

                //Add transaction
                objDB = new DBConnect();
                objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "AddCloudTransaction";
                objCommand.Parameters.AddWithValue("@email", email);
                objCommand.Parameters.AddWithValue("@type", "Recover");
                objCommand.Parameters.AddWithValue("@fileName", fileName);
                objCommand.Parameters.AddWithValue("@time", DateTime.Now);
                objDB.DoUpdateUsingCmdObj(objCommand);

            }
            return response;
        }
    }
}
