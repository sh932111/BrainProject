using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Stu.Class
{
    public class FloderUtils
    {
        private string rootFolder = "BrainResult";
        private string userChoosePath = null;
        public FloderUtils()
        {

        }
        public FloderUtils(string user_path)
        {
            this.userChoosePath = user_path;
        }

        public void createRoot()
        {
            createFolder(userChoosePath + "/" + rootFolder);
        }

        public string createDeviceFolder(string mac_path , string time)
        {
            string result_path = userChoosePath + "/" + rootFolder + "/" + mac_path;
            createFolder(result_path);
            createFolder(result_path + "/" + time);
            return result_path + "/" + time;
        }

        public void createFolder(string dir)
        {
            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
        }

        public ArrayList listAllOrder()
        {
            ArrayList pathes = new ArrayList();
            string r_p = userChoosePath + "/" + rootFolder; 
            foreach (string fname in Directory.GetFileSystemEntries(r_p))
            {
                foreach (string lname in Directory.GetFileSystemEntries(fname))
                {
                    string cli = lname + "/Client.txt";
                    if (File.Exists(cli))
                    {
                        WriteFile wFile = new WriteFile(lname);
                        JSONObject item = wFile.readClient();
                        pathes.Add(item);
                    }
                }
            } 
            return pathes;
        }
    }
}
