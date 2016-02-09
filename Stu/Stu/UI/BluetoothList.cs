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
using Stu.Manager;

namespace Stu.UI
{
    public partial class BluetoothList : Form
    {
        public delegate void BrainListCallback(ArrayList bluetoothCheckedList);
        public delegate void BrainOnClickListCallback();

        private BackgroundWorker bgBluetooth;
        private BluetoothController bluetoothController;
        private ListView bluetoothList = null;
        private ArrayList resultList;
        private BrainListCallback aCallback = null;
        private BrainOnClickListCallback aOnClickCallback = null;
        public BluetoothList()
        {
            InitializeComponent();
            /*ListView UI*/
            this.resultList = new ArrayList();
            this.bluetoothList = bluetoothListView;
            bluetoothList.BeginUpdate();
            bluetoothList.View = View.Details;
            bluetoothList.ItemChecked += new ItemCheckedEventHandler(CheckedState);
            loadListTitle();
            bluetoothList.EndUpdate();
            /*搜尋很久放在BackgroundWorker*/
            runSearchDevice();
        }
        public BluetoothList(BrainListCallback acb , BrainOnClickListCallback onCb)
        {
            InitializeComponent();
            this.aCallback = acb;
            this.aOnClickCallback = onCb;
            /*ListView UI*/
            this.resultList = new ArrayList();
            this.bluetoothList = bluetoothListView;
            bluetoothList.BeginUpdate();
            bluetoothList.View = View.Details;
            bluetoothList.ItemChecked += new ItemCheckedEventHandler(CheckedState);
            loadListTitle();
            bluetoothList.EndUpdate();
            /*搜尋很久放在BackgroundWorker*/
            runSearchDevice();
        }

        private void runSearchDevice()
        {
            bluetoothList.Clear();
            loaderImage.Show();
            btnSearchDevice.Enabled = false;
            bgBluetooth = new BackgroundWorker();
            bgBluetooth.WorkerReportsProgress = true;
            bgBluetooth.WorkerSupportsCancellation = true;
            bgBluetooth.DoWork += new DoWorkEventHandler(background_DoWork);
            bgBluetooth.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_Finish);
            bgBluetooth.RunWorkerAsync();
        }

        private void background_DoWork(object sender, DoWorkEventArgs e)
        {
            bluetoothController = new BluetoothController();
            bluetoothController.findBluetoothTolist();
        }

        private void background_Finish(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearchDevice.Enabled = true;
            loaderImage.Hide();
            resultList = bluetoothController.getBluetoothList();
            if (bgBluetooth != null)
            {
                bgBluetooth.CancelAsync();
                bgBluetooth = null;
            }
            reloadList();
        }

        #region 增加Item的標題，共有三個列
        private void loadListTitle()
        {
            bluetoothList.Columns.Add("裝置名稱");
            bluetoothList.Columns.Add("裝置位置");
            bluetoothList.Columns.Add("COM PORT");
        }
        #endregion
    
        private void reloadList()
        {
            bluetoothList.BeginUpdate();
            bluetoothList.Clear();
            loadListTitle();
            foreach (BluetoothDeviceManager manager in resultList)
            {
                ListViewItem i1 = new ListViewItem(manager.getDeviceName());
                i1.SubItems.Add(manager.getDeviceAddress());
                i1.SubItems.Add(manager.getCOM());
                bluetoothList.Items.Add(i1);
            }
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            bluetoothList.EndUpdate();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (aCallback != null) aCallback(getResult());
        }
        private void CheckedState(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
        {
            if (aOnClickCallback != null) aOnClickCallback();
        }

        private void btnSearchDevice_Click(object sender, EventArgs e)
        {
            if (aOnClickCallback != null) aOnClickCallback();
            runSearchDevice();
        }

        public void hideButton()
        {
            connectBtn.Hide();
            btnSearchDevice.Width = 278;
        }

        public ArrayList getResult()
        {
            ArrayList result_list = new ArrayList();
            for (int i = 0; i < bluetoothList.Items.Count; i++)
            {
                if (bluetoothList.Items[i].Checked)
                {
                    result_list.Add(resultList[i]);
                }
            }
            return result_list;
        }
    }
}
