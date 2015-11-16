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

namespace Stu.UI
{
    public partial class BluetoothList : Form
    {
        private BackgroundWorker bgBluetooth;
        private BluetoothController bluetoothController;
        private ListView bluetoothList = null;
        private ArrayList resultList;
        private int selectIndex;
        public BluetoothList()
        {
            InitializeComponent();
            /*搜尋很久放在BackgroundWorker*/
            bgBluetooth = new BackgroundWorker();
            bgBluetooth.WorkerReportsProgress = true;
            bgBluetooth.WorkerSupportsCancellation = true;
            bgBluetooth.DoWork += new DoWorkEventHandler(background_DoWork);
            bgBluetooth.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_Finish);
            bgBluetooth.RunWorkerAsync();
            /*ListView UI*/
            this.resultList = new ArrayList();
            this.selectIndex = -1;
            this.bluetoothList = bluetoothListView;
            bluetoothList.BeginUpdate();
            bluetoothList.View = View.Details;
            loadListTitle();
            bluetoothList.EndUpdate();
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            bluetoothController = new BluetoothController();
            bluetoothController.findBluetoothTolist();
        }

        private void background_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            loaderImage.Hide();
            resultList = bluetoothController.getBluetoothList();
            bgBluetooth.CancelAsync();
            reloadList();
        }

        private void loadListTitle()
        {
            #region 增加Item的標題，共有三個列
            bluetoothList.Columns.Add("裝置名稱");
            bluetoothList.Columns.Add("裝置位置");
            bluetoothList.Columns.Add("COM PORT");
            #endregion
        }
    
        private void reloadList()
        {
            bluetoothList.BeginUpdate();
            bluetoothList.Clear();
            loadListTitle();
            foreach (Dictionary<string, string> item in resultList)
            {
                ListViewItem i1 = new ListViewItem(item["DeviceName"]);
                i1.SubItems.Add(item["DeviceAddress"]);
                i1.SubItems.Add(item["COM"]);               
                bluetoothList.Items.Add(i1);
            }
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            bluetoothList.EndUpdate();
        }

        private void bluetoothListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bluetoothList.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection selected = bluetoothList.SelectedItems;
                selectIndex = selected[0].Index;
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (selectIndex != -1)
            {
                if (resultList.Count > selectIndex)
                {
                    Dictionary<string, string> item =  (Dictionary<string, string>)resultList[selectIndex];
                    MessageBox.Show(item["COM"]);
                }
            }
        }
    }
}
