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
        private ArrayList lastRange = null;
        private ArrayList firstRange = null;
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
            if (firstRange == null || lastRange == null)
            {
                MessageBox.Show("尚未選擇腦波資料!");
                return;
            }
            if (outPath.Length == 0)
            {
                MessageBox.Show("尚未選擇輸出路徑!");
                return;
            }
            if (bluetooth_list.getResult().Count == 0)
            {
                MessageBox.Show("尚未選擇Device!");
                return;
            }
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderCreate, httpResponse);
            JSONObject form = new JSONObject();
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
                ArrayList list = bluetooth_list.getResult();
                BluetoothDeviceManager manager = (BluetoothDeviceManager)list[0];
                string order_id = response.getString("orderID");
                ConfigManager config_manager = new ConfigManager(order_id, outPath, int.Parse(textTestTime.Text), manager, firstRange, lastRange);
                Process.Start("chrome.exe", "http://shared.tw/En/body/pages/test/chooseWord/?orderID=" + order_id);
                Choose choose = new Choose(config_manager);
                choose.Location = new Point(20, 0);
                choose.Show();
                this.Hide();
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

        private void runTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (runTypeCombo.SelectedIndex)
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
            if (fr == null || lr == null)
            {
                runTypeCombo.SelectedIndex = 0;
            }
            else
            {
                this.firstRange = fr;
                this.lastRange = lr;
            }
        }
    }
}
