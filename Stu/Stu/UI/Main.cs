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
using System.IO;

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

            //ArrayList list = new ArrayList();
            //for (double i = 1; i <= 3; i++)
            //{
            //    list.Add(i);
            //}
            //double res = Calculate.norm(list);
            //Console.WriteLine(res);
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
            ChromeUtils.closeChrome();
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
                Boolean isTest = radioTest.Checked;
                ArrayList list = bluetooth_list.getResult();
                BluetoothDeviceManager manager = (BluetoothDeviceManager)list[0];
                string order_id = response.getString("orderID");
                ConfigManager config_manager = new ConfigManager(order_id, outPath, int.Parse(textTestTime.Text), manager, isTest);
                if (!config_manager.getIsTest())
                {
                    ShowExDialog.show("第一步、選擇單字", Properties.Resources.choose);
                    string chooseUrl = ChromeUtils.chooseURL + order_id;
                    ChromeUtils.openChrome(chooseUrl);
                    Choose choose = new Choose(config_manager);
                    choose.Show();
                    choose.Location = new Point(0, 0);
                }
                else
                {
                    Memory memory = new Memory(config_manager);
                    memory.Show();
                    memory.Location = new Point(0, 0);
                }
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
            int test = 0;
            if (test == 1)
            {
                if (outPath.Length == 0)
                {
                    FolderBrowserDialog path = new FolderBrowserDialog();
                    path.ShowDialog();
                    outputText.Text = path.SelectedPath;
                    outPath = path.SelectedPath;
                }
                string p = outPath + "/" + "BrainResult" + "/" + "8CDE52929277" ;
                foreach (string fname in Directory.GetFileSystemEntries(p)) 
                {
                    string file = fname + "/" + "FFT.csv";
                } 
            }
            ChromeUtils.openChrome(ChromeUtils.exURL);
        }

        private void radioEn_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            textWordNum.Visible = true;
            textTestTime.Text = "600";
        }

        private void radioTest_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            textWordNum.Visible = false;
            textTestTime.Text = "180";
        }
    }
}
