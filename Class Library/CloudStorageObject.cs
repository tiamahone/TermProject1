using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Class_Library
{
    public class CloudStorageObject
    {
         private List<File> cloudItems = new List<File>();

            public CloudStorageObject()
            {
            }

            public List<File> LineItems
            {
                get { return cloudItems; }
                set { cloudItems = value; }
            }

            public void Add(File file)
            {
                if (file != null)
                {
                    cloudItems.Add(file);
                }
            }

            public void clear()
            {
                cloudItems.Clear();
            }
        
    }
}