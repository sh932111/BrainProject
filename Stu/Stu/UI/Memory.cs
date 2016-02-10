using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Manager;
using Stu.Class;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace Stu.UI
{
    public partial class Memory : Form
    {
        ConfigManager configManager = null;

        private BrainReceiver brainReceiver;
        private int time;
        private string startTime = null;
        private BackgroundWorker bgBluetooth;
        private int serviceTime;
        private string runPath = null;

        public Memory(ConfigManager manager)
        {
            InitializeComponent();
            this.configManager = manager;
            this.TopMost = true;
            BluetoothDeviceManager deviceManager = manager.getDeviceManager();
            FloderUtils folder = new FloderUtils(manager.getPath());
            folder.createRoot();
            this.runPath = folder.createDeviceFolder(deviceManager.getDeviceAddress(), manager.getOrderID());
            this.brainReceiver = new BrainReceiver(deviceManager.getCOM(), brainReiverCallback, sectionReciver);
            labelDeviceName.Text = deviceManager.getDeviceName() + "(" + deviceManager.getCOM() + ")";
            labelMac.Text = deviceManager.getDeviceAddress();
            serviceTime = -1;
            brainReciverRun();
        }

        private void memoryFinishBtn_Click(object sender, EventArgs e)
        {
            stopTimer();
        }

        private void stopTimer()
        {
            stopWorker();
            time = 0;
            brainReceiver.stop();

            string ProcessName = "chrome";//這裡換成你需要刪除的進程名稱
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process p in processes)
            {
                p.CloseMainWindow();
            }

            //BluetoothDeviceManager deviceManager = configManager.getDeviceManager();
            //BrainCharts brainCharts = new BrainCharts(deviceManager.getDeviceName(), deviceManager.getDeviceAddress(), null, "yyyy_MM_dd_HH_mm_ss_fffff");
            //brainCharts.Show();
            //brainCharts.parseResultFile(runPath + "/ResultFile.csv");

            DoTest doTest = new DoTest(configManager);
            doTest.DesktopLocation = new Point(0, 0);
            doTest.Show();

            Process.Start("chrome.exe", "http://shared.tw/En/body/pages/test/testWord/?orderID=" + configManager.getOrderID());
            this.Close();
            //ArrayList list = new ArrayList();
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 8 || i == 9)
            //    {
            //        list.Add(100);
            //    }
            //    else
            //    {
            //        list.Add(20000000);
            //    }
            //}

            //BrainCharts brainCharts2 = new BrainCharts(deviceManager.getDeviceName(), deviceManager.getDeviceAddress(), list, "yyyy/MM/dd/ HH:mm:ss.fffff");
            //brainCharts2.Show();
            //brainCharts2.parseResultFile(runPath + "/Brain.csv");
        }

        delegate void ChartUIHabdler(ArrayList list);

        private void brainReciverRun()
        {
            this.time = 0;
            this.startTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            runWorker();
            brainReceiver.run();
        }

        private void runWorker()
        {
            bgBluetooth = new BackgroundWorker();
            bgBluetooth.WorkerReportsProgress = true;
            bgBluetooth.WorkerSupportsCancellation = true;
            bgBluetooth.DoWork += new DoWorkEventHandler(background_DoWork);
            bgBluetooth.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_Finish);
            bgBluetooth.RunWorkerAsync();
        }

        private void stopWorker()
        {
            if (bgBluetooth != null)
            {
                bgBluetooth.CancelAsync();
                bgBluetooth = null;
            }
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            int now = serviceTime;
            while (now == serviceTime)
            {
                string ss = DateTime.Now.ToString("ss");
                now = int.Parse(ss);
            }
            serviceTime = now;
            time = time + 1;
        }

        private void background_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            stopWorker();
            addTime();
        }

        private void addTime()
        {
            if (!brainReceiver.isRun) return;
            labelTimer.Text = (configManager.getRunTime() - time) + "s";
            if (time == configManager.getRunTime())
            {
                stopTimer();
            }
            else runWorker();
        }

        private void brainReiverCallback(BrainManager manager)
        {
            string over_time = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            int numRow = manager.getStreamLog().Count / 513;
            writeCode(runPath + "/" + "streamLog.csv", startTime, over_time, manager.getStreamLog(), 513, numRow, null);
            writeCode(runPath + "/" + "dataLog.csv", startTime, over_time, manager.getDataLog(), 512, numRow, fftTitleItem());
            writeCode(runPath + "/" + "Brain.csv", "", "", manager.getBrainList(), 1, numRow, brashTitleItem());
            System.Diagnostics.Process.Start(runPath);
        }

        private ArrayList brashTitleItem()
        {
            ArrayList result = new ArrayList();
            result.Add("DateTime");
            result.Add("Delta");
            result.Add("Theta");
            result.Add("Low Alpha");
            result.Add("High Alpha");
            result.Add("Low Beta");
            result.Add("High Beta");
            result.Add("Low GammaHigh");
            result.Add("GammaPool");
            result.Add("Attention");
            result.Add("Meditation");
            return result;
        }

        private ArrayList fftTitleItem()
        {
            ArrayList result = new ArrayList();
            result.Add("DateTime");
            result.Add("FFT");
            return result;
        }

        private void writeCode(String create_file_name, String startTime, String overTime, ArrayList list, int numMax, int numRow, ArrayList titleItem)
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

        private void sectionReciver(ArrayList sectionList)
        {
            string time = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fffff");
            string file = time + ".csv";
            FloderUtils folder = new FloderUtils();
            string dir_nofft = runPath + "/NoFFT";
            string dir_fft = runPath + "/FFT";
            folder.createFolder(dir_nofft);
            folder.createFolder(dir_fft);

            writeCode(dir_nofft + "/" + file, "", "", sectionList, 2048, 1, null);
            ArrayList fft_resource = FFTList(sectionList);
            writeCode(dir_fft + "/" + file, "", "", fft_resource, 1025, 1, null);

            WriteFile writeFile = new WriteFile(runPath);
            writeFile.FFTResult(configManager.getFirstRange(), configManager.getLastRange(), time, dir_fft + "/" + file);
        }
        /*2048目前為寫死*/
        int max = 2048;
        private ArrayList FFTList(ArrayList lfft)
        {
            float[] resource = new float[max];
            int x = 0;
            foreach (string fft in lfft)
            {
                if (x == max) break;
                float f = float.Parse(fft);
                resource[x] = f;
                x++;
            }
            ArrayList time_out = TWFFT.getArrayWithDivision(512.0f, 0.0f, 1024.0f);
            ArrayList result = TWFFT.FFTMagic(time_out, TWFFT.FFTAbs(TWFFT.FFT(resource, getZero())), 1025);
            return result;
        }

        private float[] getZero()
        {
            float[] res = new float[max];
            for (int i = 0; i < max; i++) res[i] = 0.0f;
            return res;
        }

        private ArrayList writeFFTResult(ArrayList fr, ArrayList lr, string write_file_name, string fft_path)
        {
            StreamWriter sw = new StreamWriter(write_file_name);
            /*寫入標準*/
            String row0 = "";
            for (int i = 0; i < fr.Count; i++)
            {
                double frange = double.Parse((String)fr[i]);
                double lrange = double.Parse((String)lr[i]);
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
            String row_more = "";
            ArrayList Classified = new ArrayList();
            for (int i = 0; i < fr.Count; i++)
            {
                double num = 0.0f;
                double frange = double.Parse((String)fr[i]);
                double lrange = double.Parse((String)lr[i]);
                StreamReader SR = new StreamReader(fft_path);
                string Line;
                while ((Line = SR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                {
                    string[] ReadLine_Array = Line.Split(',');

                    String row_a = ReadLine_Array[0];
                    String row_b = ReadLine_Array[1];

                    double f_row_a = double.Parse(row_a);
                    double f_row_b = double.Parse(row_b);

                    if (frange <= f_row_a && lrange >= f_row_a) /*參考論文邊界怎麼做*/
                    {
                        num = num + f_row_b;
                    }
                }
                row_more = row_more + num;
                if (i != fr.Count - 1) row_more = row_more + ",";
                Classified.Add(num);
            }
            sw.WriteLine(row_more);
            /*將判斷後增加的資料寫入*/
            sw.Close();
            return Classified;
        }
    }
}
