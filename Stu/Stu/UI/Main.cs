using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Class;
using System.Collections;
using Stu.Utils;
using Stu.Manager;
using System.Diagnostics;

namespace Stu.UI
{
    public partial class Main : Form
    {
        private string outPath = "";
        BluetoothList bluetooth_list = null;
        public Main()
        {
            InitializeComponent();
            this.bluetooth_list = new BluetoothList();
            bluetooth_list.Location = new Point(350, 40);
            bluetooth_list.TopLevel = false;
            this.Controls.Add(bluetooth_list);
            bluetooth_list.Show();
            bluetooth_list.hideButton();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (textTestTime.Text.Length == 0 || textUserName.Text.Length == 0 || textUserYearOld.Text.Length == 0 || textWordNum.Text.Length == 0)
            {
                MessageBox.Show("欄位都為必填!");
                return;
            }
            if (outPath.Length == 0)
            {
                MessageBox.Show("尚未選擇輸出路徑!");
                return;
            }
            ArrayList list = bluetooth_list.getResult();
            if (list.Count == 0)
            {
                MessageBox.Show("尚未選擇Device!");
                return;
            }
            string ProcessName = "chrome";//這裡換成你需要刪除的進程名稱
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process p in processes)
            {
                p.CloseMainWindow();
            }
            BluetoothDeviceManager manager = (BluetoothDeviceManager)list[0];
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderCreate, httpResponse);
            JSONObject form = new JSONObject();
            form.setString("deviceAddress", manager.getDeviceAddress());
            form.setString("userName", textUserName.Text);
            form.setString("userYearOld", textUserYearOld.Text);
            form.setString("wordNum", textWordNum.Text);
            form.setString("testTime", textTestTime.Text);
            httpWorker.setData(form);
            httpWorker.httpWorker();
            WaitDialog.show();
        }

        private void httpResponse(JSONObject response)
        {
            WaitDialog.close();
            int error_code = response.getInt("error_code");
            if (error_code == 0)
            {
                ShowExDialog.show("第一步、選擇單字", Properties.Resources.choose);
                ArrayList list = bluetooth_list.getResult();
                BluetoothDeviceManager manager = (BluetoothDeviceManager)list[0];
                string order_id = response.getString("orderID");
                ConfigManager config_manager = new ConfigManager(order_id, outPath, int.Parse(textTestTime.Text), manager);
                Process.Start("chrome.exe", "http://shared.tw/En/body/pages/test/chooseWord/?orderID=" + order_id);
                Choose choose = new Choose(config_manager);
                choose.Show();
                choose.Location = new Point(0, 0);
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            outputText.Text = path.SelectedPath;
            this.outPath = path.SelectedPath;
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            if (outPath.Length == 0)
            {
                FolderBrowserDialog path = new FolderBrowserDialog();
                path.ShowDialog();
                outputText.Text = path.SelectedPath;
                outPath = path.SelectedPath;
            }
            OrderList list = new OrderList(outPath);
            list.Show();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            textTestTime.Text = ""; 
            textUserName.Text = "";
            textUserYearOld.Text = "";
            textWordNum.Text = "";
            outPath = "";
            outputText.Text = "";
        }

        private void exBtn_Click(object sender, EventArgs e)
        {
            Process.Start("chrome.exe", "http://shared.tw/En/body/pages/test/ex/");
        }
    }
}
