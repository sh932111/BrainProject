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
            theTimer = new System.Windows.Forms.Timer();
            theTimer.Interval = 1000;
            theTimer.Tick += new System.EventHandler(this.addTime);
            theTimer.Enabled = true;
            brainReceiver.run();
        }

        private void brainReiverCallback(BrainManager manager)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopTimer();
            buttonStop.Hide();
            buttonRun.Show();
        }
    }
}
