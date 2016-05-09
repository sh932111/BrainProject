using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Stu.Manager;

namespace Stu.Class
{
    class WriteFile
    {
        private string runPath;
        public static string FFTResultFile = "/ResultFile.csv";
        public static string NormResultFile = "/NormResultFile.csv";
        public static string FFTNorm = "/FFTNorm.csv";
        public static string BrainNorm = "/BrainNorm.csv";
        public static string Brain = "/Brain.csv";
        public static string FFT = "/FFT.csv";
        private string NoFFT = "/NoFFT.csv";
        private string Client = "/Client.txt";
        public WriteFile(string path)
        {
            this.runPath = path;
        }
        public void BrainToNBrain()
        {
            string file = runPath + Brain;
            if (!File.Exists(file))
            {
                return;
            }
            ArrayList lineArray = new ArrayList();
            int index = 0;
            StreamReader fSR = new StreamReader(file);
            string fLine;
            while ((fLine = fSR.ReadLine()) != null)
            {
                if (index == 0)
                {
                    string[] ReadLine_Array = fLine.Split(',');
                    string code = "";
                    for (int i = 0; i < ReadLine_Array.Length - 2; i++)
                    {
                        if (i == 0)
                        {
                            code = code + ReadLine_Array[i];
                        }
                        else
                        {
                            code = code + "," + ReadLine_Array[i];
                        }
                    }
                    lineArray.Add(code);
                }
                else
                {
                    string[] ReadLine_Array = fLine.Split(',');
                    /*取得量化的值*/
                    ArrayList list = new ArrayList();
                    for (int i = 1; i < ReadLine_Array.Length - 2; i++)
                    {
                        double val = double.Parse(ReadLine_Array[i]);
                        list.Add(val);
                    }
                    double norm_res = Calculate.norm(list);
                    /*計算量化後的結果*/
                    string code = "";
                    for (int i = 0; i < ReadLine_Array.Length - 2; i++)
                    {
                        if (i == 0)
                        {
                            code = code + ReadLine_Array[i];
                        }
                        else
                        {
                            double val = double.Parse(ReadLine_Array[i]);
                            double result = val / norm_res;
                            code = code + "," + result;
                        }
                    }
                    lineArray.Add(code);
                }
                index++;
            }
            fSR.Close();
            string FFT_N = runPath + BrainNorm;
            StreamWriter sw = new StreamWriter(FFT_N);
            for (int i = 0; i < lineArray.Count; i++)
            {
                string row = (string)lineArray[i];
                sw.WriteLine(row);
            }
            sw.Close();
        }
        public void clientSave(ConfigManager manager)
        {
            string path = runPath + Client;
            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                string orderID = manager.getOrderID();
                sw.WriteLine(orderID);
                string name = manager.getName();
                sw.WriteLine(name);
                string year = manager.getYear();
                sw.WriteLine(year);
                string runTime = manager.getRunTime() + "";
                sw.WriteLine(runTime);
                BluetoothDeviceManager blueManager = manager.getDeviceManager();
                string addr = blueManager.getDeviceAddress();
                sw.WriteLine(addr);
                sw.Close();
            }
        }
        public JSONObject readClient()
        {
            JSONObject item = new JSONObject();
            item.setString("path", runPath);
            string path = runPath + Client;
            if (File.Exists(path))
            {
                StreamReader fSR = new StreamReader(path);
                string fLine;
                int index = 0;
                while ((fLine = fSR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                {
                    if (index == 0)
                    {
                        item.setString("orderID", fLine);   
                    }
                    else if (index == 1)
                    {
                        item.setString("userName", fLine);   
                    }
                    else if (index == 2)
                    {
                        item.setString("userYearOld", fLine);   
                    }
                    else if (index == 3)
                    {
                        item.setString("testTime", fLine);   
                    }
                    else if (index == 4)
                    {
                        item.setString("deviceAddress", fLine);   
                    }
                    index++;
                }
                fSR.Close();
            }
            return item;
        }
        public void NoFFTWrite(ArrayList sectionList , string time)
        {
            string path = runPath + NoFFT;
            if (File.Exists(path))
            {
                /*先讀取上一階段所存的資料*/
                StreamReader fSR = new StreamReader(path);
                string fLine;
                ArrayList fList = new ArrayList();
                while ((fLine = fSR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                {
                    fList.Add(fLine);
                }
                fSR.Close();
                /*先讀取上一階段所存的資料*/
                /*寫入上一階段所存的資料*/
                StreamWriter sw = new StreamWriter(path);
                for (int i = 0; i < fList.Count; i++)
                {
                    string write = (string)fList[i];
                    sw.WriteLine(write);
                }
                /*寫入上一階段所存的資料*/
                String res = time;
                for (int i = 0; i < sectionList.Count; i++)
                {
                    String data = (String)sectionList[i];
                    res = res + "," + data;
                }
                sw.WriteLine(res);
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(path);
                String res = time;
                for (int i = 0; i < sectionList.Count; i++)
                {
                    String data = (String)sectionList[i];
                    res = res + "," + data;
                }
                sw.WriteLine(res);
                sw.Close();
            }
        }
        public void FFTToNFFT()
        {
            string file = runPath + FFT;
            if (File.Exists(file))
            {
                ArrayList lineArray = new ArrayList();
                int index = 0;
                StreamReader fSR = new StreamReader(file);
                string fLine;
                while ((fLine = fSR.ReadLine()) != null)
                {
                    if (index == 0)
                    {
                        lineArray.Add(fLine);
                    }
                    else
                    {
                        string[] ReadLine_Array = fLine.Split(',');
                        /*取得量化的值*/
                        ArrayList list = new ArrayList();
                        for (int i = 1; i < ReadLine_Array.Length; i++)
                        {
                            double val = double.Parse(ReadLine_Array[i]);
                            list.Add(val);
                        }
                        double norm_res = Calculate.norm(list);
                        /*計算量化後的結果*/
                        string code = "";
                        for (int i = 0; i < ReadLine_Array.Length; i++)
                        {
                            if (i == 0)
                            {
                                code = code + ReadLine_Array[i];
                            }
                            else
                            {
                                double val = double.Parse(ReadLine_Array[i]);
                                double result = val / norm_res;
                                code = code + "," + result;
                            }
                        }
                        lineArray.Add(code);
                    }
                    index++;
                }
                fSR.Close();
                string FFT_N = runPath + FFTNorm;
                StreamWriter sw = new StreamWriter(FFT_N);
                for (int i = 0; i < lineArray.Count; i++)
                {
                    string row = (string)lineArray[i];
                    sw.WriteLine(row);
                }
                sw.Close();
            }
        }
        public void FFTWrite(ArrayList sectionList, string time)
        {
            string path = runPath + FFT;
            if (File.Exists(path))
            {
                /*先讀取上一階段所存的資料*/
                StreamReader fSR = new StreamReader(path);
                string fLine;
                ArrayList fList = new ArrayList();
                while ((fLine = fSR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                {
                    fList.Add(fLine);
                }
                fSR.Close();
                /*先讀取上一階段所存的資料*/
                /*寫入上一階段所存的資料*/
                StreamWriter sw = new StreamWriter(path);
                for (int i = 0; i < fList.Count; i++)
                {
                    string write = (string)fList[i];
                    sw.WriteLine(write);
                }
                /*寫入上一階段所存的資料*/
                String res = time;
                for (int i = 0; i < sectionList.Count; i++)
                {
                    ArrayList data = (ArrayList)sectionList[i];
                    string r = (string)data[1];
                    res = res + "," + r;
                }
                sw.WriteLine(res);
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(path);
                String title = "Time";
                String res = time;
                for (int i = 0; i < sectionList.Count; i++)
                {
                    ArrayList data = (ArrayList)sectionList[i];
                    string t = (string)data[0];
                    string r = (string)data[1];
                    title = title + "," + t;
                    res = res + "," + r;
                }
                sw.WriteLine(title);
                sw.WriteLine(res);
                sw.Close();
            }
            FFTToNFFT();
        }
        public void FFTQuery(string fileName,string resourcePath, ArrayList nr, ArrayList fr, ArrayList lr)
        {
            string path = runPath + fileName;
            StreamWriter sw = new StreamWriter(path);
            /*寫入標準*/
            string row0 = "Time,";
            for (int i = 0; i < fr.Count; i++)
            {
                string name = (string)nr[i];
                double frange = double.Parse((string)fr[i]);
                double lrange = double.Parse((string)lr[i]);
                if (i != fr.Count - 1)
                {
                    row0 = row0 + frange + "~" + lrange + "(" + name +")"+ ",";
                }
                else
                {
                    row0 = row0 + frange + "~" + lrange + "(" + name + ")";
                }
            }
            sw.WriteLine(row0);
            /*寫入標準*/
            string fft_resource = runPath + resourcePath;
            StreamReader SR = new StreamReader(fft_resource);
            string Line;
            int index = 0;
            ArrayList temp = new ArrayList();
            while ((Line = SR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
            {
                string[] ReadLine_Array = Line.Split(',');
                if (index == 0)
                {
                    for (int i = 0; i < fr.Count; i++)
                    {
                        double frange = double.Parse((string)fr[i]);
                        double lrange = double.Parse((string)lr[i]);
                        ArrayList readTemp = new ArrayList();
                        for (int x = 1; x < ReadLine_Array.Length; x++)
                        {
                            double range = double.Parse((string)ReadLine_Array[x]);
                            if (frange <= range && lrange > range)
                            {
                                readTemp.Add(x);
                            }
                        }
                        temp.Add(readTemp);
                    }
                }
                else
                {
                    string res = ReadLine_Array[0];
                    for (int x = 0; x < temp.Count; x++) 
                    {
                        ArrayList readTemp = (ArrayList)temp[x];
                        double resTemp = 0;
                        for (int i = 0; i < readTemp.Count; i++)
                        {
                            int temp_x = (int)readTemp[i];
                            double range = double.Parse((string)ReadLine_Array[temp_x]);
                            resTemp = resTemp + range;
                        }
                        res = res + "," + resTemp;
                    }
                    sw.WriteLine(res);
                }
                index++;
            }
            /*將判斷後增加的資料寫入*/
            SR.Close();
            sw.Close();
        }

        public void FFTResult(string fileName , ArrayList nr ,  ArrayList fr, ArrayList lr ,string time , string fft_resource)
        {
            string path = runPath + fileName;
            if (File.Exists(path))
            {
                /*先讀取上一階段所存的資料*/
                StreamReader fSR = new StreamReader(path);
                string fLine;
                ArrayList fList = new ArrayList();
                while ((fLine = fSR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                {
                    fList.Add(fLine);
                }
                fSR.Close();
                /*先讀取上一階段所存的資料*/
                /*寫入上一階段所存的資料*/
                StreamWriter sw = new StreamWriter(path);
                for (int i = 0; i < fList.Count; i++)
                {
                    string write = (string)fList[i];
                    sw.WriteLine(write);
                }
                /*寫入上一階段所存的資料*/
                string row_more = time + ",";
                for (int i = 0; i < fr.Count; i++)
                {
                    double num = 0.0f;
                    double frange = double.Parse((string)fr[i]);
                    double lrange = double.Parse((string)lr[i]);
                    StreamReader SR = new StreamReader(fft_resource);
                    string Line;
                    while ((Line = SR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                    {
                        string[] ReadLine_Array = Line.Split(',');
                        string row_a = ReadLine_Array[0];
                        string row_b = ReadLine_Array[1];
                        double f_row_a = double.Parse(row_a);
                        double f_row_b = double.Parse(row_b);
                        if (frange <= f_row_a && lrange >= f_row_a) /*參考論文邊界怎麼做*/
                        {
                            num = num + f_row_b;
                        }
                    }
                    row_more = row_more + num;
                    if (i != fr.Count - 1) row_more = row_more + ",";
                    SR.Close();
                }
                sw.WriteLine(row_more);
                /*將判斷後增加的資料寫入*/
                sw.Close();
            }
            else 
            {
                StreamWriter sw = new StreamWriter(path);
                /*寫入標準*/
                string row0 = "Time,";
                for (int i = 0; i < fr.Count; i++)
                {
                    double frange = double.Parse((string)fr[i]);
                    double lrange = double.Parse((string)lr[i]);
                    if (i != fr.Count - 1)
                    {
                        row0 = row0 + frange + "~" + lrange + ",";
                    }
                    else
                    {
                        row0 = row0 + frange + "~" + lrange;
                    }
                }
                sw.WriteLine(row0);
                /*寫入標準*/
                /*將判斷後增加的資料寫入*/
                string row_more = time + ",";
                for (int i = 0; i < fr.Count; i++)
                {
                    double num = 0.0f;
                    double frange = double.Parse((string)fr[i]);
                    double lrange = double.Parse((string)lr[i]);
                    StreamReader SR = new StreamReader(fft_resource);
                    string Line;
                    while ((Line = SR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                    {
                        string[] ReadLine_Array = Line.Split(',');
                        string row_a = ReadLine_Array[0];
                        string row_b = ReadLine_Array[1];
                        double f_row_a = double.Parse(row_a);
                        double f_row_b = double.Parse(row_b);
                        if (frange <= f_row_a && lrange >= f_row_a) /*參考論文邊界怎麼做*/
                        {
                            num = num + f_row_b;
                        }
                    }
                    row_more = row_more + num;
                    if (i != fr.Count - 1) row_more = row_more + ",";
                    SR.Close();
                }
                sw.WriteLine(row_more);
                /*將判斷後增加的資料寫入*/
                sw.Close();
            }
        }

        public static void writeFinishCode(String create_file_name, String startTime, String overTime, ArrayList list, int numMax, int numRow, ArrayList titleItem)
        {
            StreamWriter sw = new StreamWriter(create_file_name);
            int index = 0;
            int num_max = 0;
            if (startTime.Length > 0 && overTime.Length > 0) sw.WriteLine(startTime + " ~ " + overTime);
            if (titleItem != null)
            {
                String row = "";
                for (int i = 0; i < titleItem.Count; i++)
                {
                    if (row.Length == 0) row = (String)titleItem[i];
                    else row = row + "," + (String)titleItem[i];
                    if (i == titleItem.Count - 1) sw.WriteLine(row);
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is ArrayList)
                {
                    ArrayList item = (ArrayList)list[i];
                    if (index == 0)
                    {
                        num_max++;
                        if (num_max > numRow) break;
                    }
                    String row = "";
                    for (int x = 0; x < item.Count; x++)
                    {
                        if (row.Length == 0) row = (String)item[x];
                        else row = row + "," + (String)item[x];
                        if (x == item.Count - 1) sw.WriteLine(row);
                    }
                    if (index == numMax - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                else if (list[i] is string)
                {
                    string item = (string)list[i];
                    sw.WriteLine(item);
                }
            }
            sw.Close();
        }
    }
}
