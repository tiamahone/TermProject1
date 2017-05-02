using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Class_Library
{
    public class File
    {
        private string email;
        private string fileName;
        private string fileType;
        private double fileSize;
        private byte[] fileData;

        public File()
        {
        }

        public File(string email, string fileName, string fileType, double fileSize, byte[] fileData)
        {
            this.email = email;
            this.fileName = fileName;
            this.fileType = fileType;
            this.fileSize = fileSize;
            this.fileData = fileData;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }
        public double FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }
        

    }
}