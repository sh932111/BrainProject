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
    public partial class OrderView : Form
    {
        private string orderID;
        private string outPath;
        private ListView bluetoothList = null;
        private ArrayList resultList;
        public OrderView(string order_id , string path)
        {
            InitializeComponent();
            this.orderID = order_id;
            this.outPath = path;
            this.resultList = new ArrayList();
            this.bluetoothList = bluetoothListView;
            bluetoothList.BeginUpdate();
            bluetoothList.View = View.Details;
            loadListTitle();
            bluetoothList.EndUpdate();
            getOrderView();
        }
        private void getOrderView()
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderView, httpResponse);
            JSONObject form = new JSONObject();
            form.setString("orderID", orderID);
            form.setString("showTranslate", "true");
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
                FloderUtils folder = new FloderUtils(outPath);
                JSONObject value = response.getJSONObject("value");
                string file_path = folder.createDeviceFolder(value.getString("deviceAddress"), orderID);
                BrainCharts brainCharts = new BrainCharts("","", null, "yyyy_MM_dd_HH_mm_ss_fffff");
                brainCharts.Location = new Point(350, 45);
                brainCharts.TopLevel = false;
                this.Controls.Add(brainCharts);
                brainCharts.Show();
                brainCharts.parseResultFile(file_path + "/ResultFile.csv");
                brainCharts.addParseFile(file_path + "/Brain.csv");
                resultList.Clear();
                JSONArray list = response.getJSONArray("list");
                for (int i = 0; i < list.Count; i++)
                {
                    JSONObject item = list.getJSONObject(i);
                    resultList.Add(item);
                }
                reloadList();
                setValue(value);
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
        private void setValue(JSONObject value)
        {
            textCreateTime.Text = value.getString("create_time");
            textUserName.Text = value.getString("userName");
            textUserYearOld.Text = value.getString("userYearOld");
            textTestTime.Text = value.getString("testTime");
            textWordNum.Text = value.getString("wordNum");
            labelScore.Text = "共獲得:"+value.getString("testResult")+"分";
        }
        private void reloadList()
        {
            bluetoothList.BeginUpdate();
            bluetoothList.Clear();
            loadListTitle();
            foreach (JSONObject manager in resultList)
            {
                ListViewItem i1 = new ListViewItem(manager.getString("enWord"));
                i1.SubItems.Add(manager.getString("test"));
                int result = manager.getInt("testResult");
                string res = "正確";
                if (result == 2) res = "錯誤";
                i1.SubItems.Add(res);
                bluetoothList.Items.Add(i1);
            }
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            bluetoothList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            bluetoothList.EndUpdate();
        }

        #region 增加Item的標題，共有三個列
        private void loadListTitle()
        {
            bluetoothList.Columns.Add("考試單字");
            bluetoothList.Columns.Add("您的答案");
            bluetoothList.Columns.Add("答題結果");
        }
        #endregion
    }
}
