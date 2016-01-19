using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Stu.Class
{
    class WriteFile
    {
        private string runPath;
        private string FFTResultFile = "/ResultFile.csv";
        public WriteFile(string path)
        {
            this.runPath = path;
        }
        public void FFTResult(ArrayList fr, ArrayList lr ,string time , string fft_resource)
        {
            string path = runPath + FFTResultFile;
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
    }
}
