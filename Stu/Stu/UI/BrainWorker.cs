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

namespace Stu.UI
{
    public partial class BrainWorker : Form
    {
        private int runType = 0;
        private string runPath = null;
        private BluetoothDeviceManager deviceManager = null;
        private BrainReceiver brainReceiver;
        private System.Windows.Forms.Timer theTimer = null;
        private int time;
        private int overTime;
        private string startTime = null;

        public BrainWorker(string run_path,BluetoothDeviceManager device_manager)
        {
            InitializeComponent();
            this.runPath = run_path;
            this.deviceManager = device_manager;
            this.brainReceiver = new BrainReceiver(deviceManager.getCOM(), brainReiverCallback);
            setComboBox();
            setValue();
            buttonStop.Hide();
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

        private void addTime(object sender, System.EventArgs e)
        {
            time = time + 1;
            labelTimer.Text = time + "s";
            if (time == overTime)
            {
                stopTimer();
                buttonStop.Hide();
                buttonRun.Show();
            }
        }

        private void stopTimer()
        {
            theTimer.Enabled = false;
            theTimer = null;
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
            buttonStop.Show();
            buttonRun.Hide();
            overTime = int.Parse(textBoxSecond.Text);
            this.time = 0;
            this.startTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            theTimer = new System.Windows.Forms.Timer();
            theTimer.Interval = 1000;
            theTimer.Tick += new System.EventHandler(this.addTime);
            theTimer.Enabled = true;
            brainReceiver.run();
        }

        private void brainReiverCallback(BrainManager manager)
        {
            MessageBox.Show("Finish");
            string over_time = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            int numRow = manager.getStreamLog().Count / 513;
            writeCode(runPath + "/" + "streamLog", startTime, over_time, manager.getStreamLog(), 513, numRow, null);
            writeCode(runPath + "/" + "dataLog", startTime, over_time, manager.getDataLog(), 512, numRow, null);
            writeCode(runPath + "/" + "Brain", startTime, over_time, manager.getBrainList(), 1, numRow, brashTitleItem());
            writeCode(runPath + "/" + "LastFFT", startTime, over_time, manager.getFFTList(), 512, numRow, fftTitleItem());
            System.Diagnostics.Process.Start(runPath);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopTimer();
            buttonStop.Hide();
            buttonRun.Show();
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
            foreach (ArrayList item in list)
            {
                if (index == 0)
                {
                    num_max++;
                    if (num_max > numRow) break;
                }
                String row = "";
                for (int i = 0; i < item.Count; i++)
                {
                    if (row.Length == 0) row = (String)item[i];
                    else row = row + "," + (String)item[i];
                    if (i == item.Count - 1) sw.WriteLine(row);
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
            sw.Close();
        }
    }
}
