using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Class_Library
{


    public class Cloud_Storage
    {
        Functions cloud = new Functions();

        public ArrayList files { get; set; }
        public ArrayList accountInfo { get; set; }
        public ArrayList userInfo { get; set; }

        public static void DownloadFiles()
        {
            
        }

    }
}