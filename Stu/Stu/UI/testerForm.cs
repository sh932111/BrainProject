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
        public TesterForm(BluetoothDeviceManager manager , string path)
        {
            InitializeComponent();
            this.bluetoothDeviceManager = manager;
            this.outputPath = path;
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
            new Memory(config_manager, formList);
        }
    }
}
