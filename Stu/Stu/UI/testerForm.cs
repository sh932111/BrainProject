using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Manager;
using System.Collections;

namespace Stu.UI
{
    public partial class TesterForm : Form
    {
        BluetoothDeviceManager bluetoothDeviceManager = null;
        string outputPath  = null;
        int devIndex = 0;
        public TesterForm(BluetoothDeviceManager manager , string path , int index)
        {
            InitializeComponent();
            this.bluetoothDeviceManager = manager;
            this.outputPath = path;
            this.devIndex = index;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (textTestTime.Text.Length == 0 || textUserName.Text.Length == 0 || textUserYearOld.Text.Length == 0)
            {
                MessageBox.Show("欄位都為必填!");
                return;
            }
            string order_id = DateTime.Now.ToString("yyyyMMddHHmmss");
            ConfigManager config_manager = new ConfigManager(order_id, outputPath, int.Parse(textTestTime.Text), bluetoothDeviceManager, true, true, textUserName.Text, textUserYearOld.Text);
            MessageBox.Show("準備好了?確定後開始測試");
            ArrayList formList = new ArrayList();
            formList.Add(this);
            Memory m = new Memory(config_manager, formList);
            m.Location = new Point(0, this.devIndex * 256);
            this.Close();
        }
    }
}
