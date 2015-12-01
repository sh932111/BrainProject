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
using Stu.Utils;

namespace Stu.UI
{
    public partial class BrainWorker : Form
    {
        private int runType = 0;
        private string runPath = null;
        private BluetoothDeviceManager deviceManager = null;
        private BrainReceiver brainReceiver;
        private int time;
        private int overTime;
        private string startTime = null;
        private ArrayList lastRange = null;
        private ArrayList firstRange = null;
        private BrainCharts brainCharts = null;
        private BackgroundWorker bgBluetooth;
        private int serviceTime;
        public BrainWorker(string run_path,BluetoothDeviceManager device_manager)
        {
            InitializeComponent();
            this.runPath = run_path;
            this.deviceManager = device_manager;
            this.brainReceiver = new BrainReceiver(deviceManager.getCOM(), brainReiverCallback, sectionReciver);
            setComboBox();
            setValue();
            buttonStop.Hide();
            serviceTime = -1;
        }

        private void setComboBox()
        {
            this.runTypeCombo.SelectedIndex = this.runType;
        }

        private void setValue()
        {
            labelDeviceName.Text = deviceManager.getDeviceName() + "(" + deviceManager.getCOM() + ")";
            labelMac.Text = deviceManager.getDeviceAddress();
            textBoxSecond.Text = "10";
        }

        private void addTime()
        {
            labelTimer.Text = time + "s";
            if (time == overTime)
            {
                stopTimer();
                buttonStop.Hide();
                buttonRun.Show();
            }
            else runWorker();
        }

        private void stopTimer()
        {
            stopWorker();
            time = 0;
            brainReceiver.stop();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (textBoxSecond.Text.Length == 0)
            {
                MessageBox.Show("請填入時間!");
                return;
            }
            switch (this.runType)
            {
                case 0:
                    setRange(RangeDefinition.getFirstRange(), RangeDefinition.getLastRange());
                    break;
                case 1:
                    RangeDialog.show(setRange);
                    break;
                default:
                    setRange(RangeDefinition.getFirstRange(), RangeDefinition.getLastRange());
                    break;
            }
        }

        private void setRange(ArrayList fr, ArrayList lr)
        {
            this.firstRange = fr;
            this.lastRange = lr;
            brainReciverRun();
        }
        delegate void ChartUIHabdler(ArrayList list);
        private void sectionReciver(ArrayList sectionList)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmssfffff");
            string dir = runPath + "/" + time;
            FloderUtils folder = new FloderUtils();
            folder.createFolder(dir);
            writeCode(dir + "/" + "NoFFT.csv", "", "", sectionList, 2048, 1, null);
            ArrayList fft_resource = FFTList(sectionList);
            writeCode(dir + "/" + "FFT.csv", "", "", fft_resource, 1025, 1, null);
            ArrayList chartSource = writeFFTResult(firstRange, lastRange, dir + "/" + "FFTResult.csv", dir + "/" + "FFT.csv");
            /*存資料後，更新圖表*/
            this.Invoke(new ChartUIHabdler(brainCharts.drawLine), chartSource);
        }

        private void brainReciverRun()
        {
            if (brainCharts == null)
            {
                brainCharts = new BrainCharts(deviceManager.getDeviceName(), deviceManager.getDeviceAddress(), firstRange, lastRange);
                brainCharts.Show();
            }
            buttonStop.Show();
            buttonRun.Hide();
            overTime = int.Parse(textBoxSecond.Text);
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
            while(now == serviceTime)
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

        private void brainReiverCallback(BrainManager manager)
        {
            string over_time = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            int numRow = manager.getStreamLog().Count / 513;
            writeCode(runPath + "/" + "streamLog.csv", startTime, over_time, manager.getStreamLog(), 513, numRow, null);
            writeCode(runPath + "/" + "dataLog.csv", startTime, over_time, manager.getDataLog(), 512, numRow, fftTitleItem());
            writeCode(runPath + "/" + "Brain.csv", startTime, over_time, manager.getBrainList(), 1, numRow, brashTitleItem());
            MessageBox.Show(deviceManager.getDeviceName() + " is Finish");
            System.Diagnostics.Process.Start(runPath);
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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopTimer();
            buttonStop.Hide();
            buttonRun.Show();
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

        private void runTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.runType = runTypeCombo.SelectedIndex;
        }
    }
}
