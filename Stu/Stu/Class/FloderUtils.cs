using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Stu.Class
{
    public class FloderUtils
    {
        private string rootFolder = "BrainResult";
        private string userChoosePath = null;
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

        private void createFolder(string dir)
        {
            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);
        }
    }
}
