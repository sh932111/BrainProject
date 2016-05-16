using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace DataRefresh
{
    class PathUtils
    {
        public static string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/BrainResult";
        public static string[] devicePath = { "/8CDE52929277", "/8CDE5292926F" };
        public static string getExistPath(string orderID)
        {
            string path = "";
            for (int i = 0; i < devicePath.Length; i++)
            {
                string device = devicePath[i];
                string existPath = rootPath + device + orderID;
                if (Directory.Exists(existPath))
                {
                    path = existPath;
                    break;
                }
            }
            return path;
        }
        public static void write(string folder /*people or brain*/,string fileName, string table  /*Resource Class*/, ArrayList list , bool insertUser)
        {
            int max = 0;
            /*先取得Array數量的最大值*/
            for (int i = 0; i < list.Count; i++)
            {
                ArrayList item = (ArrayList)list[i];
                if (item.Count > max)
                {
                    max = item.Count;
                }
            }
            /*給Array補上空值*/
            for (int i = 0; i < list.Count; i++)
            {
                ArrayList item = (ArrayList)list[i];
                if (item.Count != max)
                {
                    int diff = max - item.Count;
                    for (int x = 0; x < diff; x++)
                    {
                        item.Add("");
                    }
                }
            }
            /*加上人名*/
            if (insertUser)
            {
                int nameLength = list.Count / Resource.names.Length;
                int nameIndex = 0;
                for (int x = 0; x < list.Count; x++)
                {
                    ArrayList item = (ArrayList)list[x];
                    int index = x / nameLength;
                    if (index == nameIndex)
                    {
                        string name = Resource.names[index];
                        item.Insert(0, name);
                        nameIndex++;
                    }
                    else
                    {
                        item.Insert(0, "");
                    }
                }
            }
            else
            {
                for (int x = 0; x < list.Count; x++)
                {
                    ArrayList item = (ArrayList)list[x];
                    string name = Resource.names[x % Resource.names.Length];
                    item.Insert(0, name);
                }
            }
            /*寫入*/
            string excelFile = folder + "/" + fileName + "_" + table + ".csv";
            StreamWriter sw = new StreamWriter(excelFile);
            string line = "";
            for (int i = 0; i < max; i++)
            {
                for (int x = 0; x < list.Count; x++)
                {
                    ArrayList item = (ArrayList)list[x];
                    string code = (string)item[i];
                    if (x == list.Count - 1)
                    {
                        line = line + code;
                        sw.WriteLine(line);
                        line = "";
                    }
                    else
                    {
                        line = line + code + ",";
                    }
                }
            }
            sw.Close();
        }
    }
}
