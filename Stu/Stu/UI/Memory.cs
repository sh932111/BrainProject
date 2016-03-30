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
using WMPLib;

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
        private Form rootFrom = null;

        public Memory(ConfigManager manager,Form root_f)
        {
            InitializeComponent();
            this.configManager = manager;
            this.TopMost = true;
            this.rootFrom = root_f;
            if (!manager.getIsTest())
            {
                string memory = ChromeUtils.memoryURL + configManager.getOrderID();
                ChromeUtils.openChrome(memory);
            }
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
            if (!configManager.getIsTest())
            {
                DialogResult myResult = MessageBox.Show("確定背完?", "確定已經背完單字，準備提早考試嗎??", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (myResult == DialogResult.Yes)
                {
                    stopTimer();
                }
            }
            else
            {
                MessageBox.Show("現在是測試模式!無法提早結束，請專心測試!");
            }
        }

        private void stopTimer()
        {
            stopWorker();
            time = 0;
            brainReceiver.stop();
            if (!configManager.getIsTest())
            {
                ChromeUtils.closeChrome();
                this.Close();
                ShowExDialog.show("第三步、測試單字", Properties.Resources.test);
                DoTest doTest = new DoTest(configManager);
                doTest.Show();
                doTest.Location = new Point(0, 0);
                ChromeUtils.openChrome(ChromeUtils.testURL + configManager.getOrderID());
            }
            else
            {
                WindowsMediaPlayer newMedia = new WindowsMediaPlayer();
                newMedia.URL = @"sound.mp3";
                newMedia.controls.play();
                if (configManager.getIsClient())
                {
                    WriteFile writeFile = new WriteFile(this.runPath);
                    writeFile.clientSave(configManager);
                    this.Close();
                    BrainChart view = new BrainChart(this.runPath,false);
                    view.Show();
                }
                else
                {
                    HttpWorker httpWorker = new HttpWorker(HttpWorker.orderFinish, httpResponse);
                    JSONObject form = new JSONObject();
                    form.setString("orderID", configManager.getOrderID());
                    httpWorker.setData(form);
                    httpWorker.httpWorker();
                    WaitDialog.show();
                }
            }
        }
        private void httpResponse(JSONObject response)
        {
            WaitDialog.close();
            int error_code = response.getInt("error_code");
            if (error_code == 0)
            {
                this.Close();
                OrderView view = new OrderView(configManager.getOrderID(), configManager.getPath());
                view.Show();
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
        delegate void ChartUIHabdler(ArrayList list);

        private void brainReciverRun()
        {
            this.time = 0;
            this.startTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            runWorker();
            if (!brainReceiver.run())
            {
                MessageBox.Show("連接裝置失敗!");
                this.Close();
            }
            else
            {
                this.Show();
                this.Location = new Point(0, 0);
                if (rootFrom!=null)  rootFrom.WindowState = FormWindowState.Minimized; 
            }
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
            WriteFile.writeFinishCode(runPath + "/" + "streamLog.csv", startTime, over_time, manager.getStreamLog(), 513, numRow, null);
            WriteFile.writeFinishCode(runPath + "/" + "dataLog.csv", startTime, over_time, manager.getDataLog(), 512, numRow, fftTitleItem());
            WriteFile.writeFinishCode(runPath + "/" + "Brain.csv", "", "", manager.getBrainList(), 1, numRow, brashTitleItem());
            //System.Diagnostics.Process.Start(runPath);
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
            result.Add("Low Gamma");
            result.Add("High Gamma");
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

        private void sectionReciver(ArrayList sectionList)
        {
            string over_time = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            WriteFile writeFile = new WriteFile(runPath);
            writeFile.NoFFTWrite(sectionList, over_time);
            ArrayList fft_resource = FFTList(sectionList);
            writeFile.FFTWrite(fft_resource, over_time);
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
    }
}
