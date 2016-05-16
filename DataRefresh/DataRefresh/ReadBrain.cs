using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace DataRefresh
{
    class ReadBrain
    {
        /*File name*/
        public static string Brain = "/Brain.csv";
        public static string BrainNorm = "/BrainNorm.csv";
        /*Class args*/
        public string brainPath = null;
        public static string peopleFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/BrainResult/Resource/people";
        public static string brainFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/BrainResult/Resource/brain";
        private ArrayList brainList = null;
        
        public ReadBrain(string path , string fileName)
        {
            this.brainPath = path + fileName;
            this.brainList = new ArrayList();
            parseFile();
        }
        private void parseFile()
        {
            this.brainList.Clear();
            if (!File.Exists(this.brainPath))
            {
                return;
            }
            StreamReader fSR = new StreamReader(this.brainPath);
            string fLine;
            while ((fLine = fSR.ReadLine()) != null)
            {
                this.brainList.Add(fLine);
            }
            fSR.Close();
        }
        public ArrayList getListForIndex(int index)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < this.brainList.Count; i++)
            {
                string item = (string)this.brainList[i];
                string[] spItem = item.Split(',');
                list.Add(spItem[index]);
            }
            return list;
        }
    }
}
