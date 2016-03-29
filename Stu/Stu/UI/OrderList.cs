using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stu.Class;

namespace Stu.UI
{
    public partial class OrderList : Form
    {
        private string outPath = "";
        private ListView bluetoothList = null;
        private ArrayList resultList;
        
        public OrderList(string path)
        {
            InitializeComponent();
            this.outPath = path;
            this.resultList = new ArrayList();
            this.bluetoothList = bluetoothListView;
            this.bluetoothList = bluetoothListView;
            bluetoothList.BeginUpdate();
            bluetoothList.View = View.Details;
            loadListTitle();
            bluetoothList.EndUpdate();
            getOrderList();
        }
        private void getOrderList()
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderList, httpResponse);
            JSONObject form = new JSONObject();
            form.setString("status", "4");
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
                resultList.Clear();
                JSONArray list = response.getJSONArray("list");
                for (int i = 0; i < list.Count; i++)
                {
                    JSONObject item = list.getJSONObject(i);
                    resultList.Add(item);
                }
                reloadList();
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
        private void reloadList()
        {
            bluetoothList.BeginUpdate();
            bluetoothList.Clear();
            loadListTitle();
            int i = 0;
            foreach (JSONObject manager in resultList)
            {
                ListViewItem i1 = new ListViewItem(i+"");
                i1.SubItems.Add(manager.getString("userName"));
                i1.SubItems.Add(manager.getString("userYearOld"));
                i1.SubItems.Add(manager.getString("wordNum"));
                i1.SubItems.Add(manager.getString("testTime"));
                i1.SubItems.Add(manager.getString("testResult"));
                bluetoothList.Items.Add(i1);
                i++;
            }
            bluetoothList.EndUpdate();
        }

        #region 增加Item的標題，共有五個列
        private void loadListTitle()
        {
            bluetoothList.Columns.Add(" ");
            bluetoothList.Columns.Add("名字");
            bluetoothList.Columns.Add("年紀");
            bluetoothList.Columns.Add("單字數");
            bluetoothList.Columns.Add("時間");
            bluetoothList.Columns.Add("分數");
        }
        #endregion

        private void bluetoothListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bluetoothList.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection selected = bluetoothList.SelectedItems;
                string indexStr = selected[0].SubItems[0].Text;
                int index = int.Parse(indexStr);
                JSONObject manager = (JSONObject)resultList[index];
                string orderID = manager.getString("orderID");
                OrderView view = new OrderView(orderID,outPath);
                view.Show();
                this.Close();
            }
        }
    }
}
