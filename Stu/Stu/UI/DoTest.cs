using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Manager;
using System.Diagnostics;
using Stu.Class;

namespace Stu.UI
{
    public partial class DoTest : Form
    {
        ConfigManager configManager = null;

        public DoTest(ConfigManager manager)
        {
            InitializeComponent();
            this.configManager = manager;
            this.TopMost = true;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MessageBox.Show("確定答題完成", "正要交卷，確定已經上傳答案了嗎??", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ( myResult  == DialogResult.Yes)
            {
                HttpWorker httpWorker = new HttpWorker(HttpWorker.orderFinish, httpResponse);
                JSONObject form = new JSONObject();
                form.setString("orderID", configManager.getOrderID());
                httpWorker.setData(form);
                httpWorker.httpWorker();
                WaitDialog.show();
            }
        }
        private void httpResponse(JSONObject response)
        {
            WaitDialog.close();
            int error_code = response.getInt("error_code");
            if (error_code == 0)
            {
                string ProcessName = "chrome";//這裡換成你需要刪除的進程名稱
                Process[] processes = Process.GetProcessesByName(ProcessName);
                foreach (Process p in processes)
                {
                    p.CloseMainWindow();
                }
                OrderView view = new OrderView(configManager.getOrderID());
                view.Show();
                this.Close();
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
    }
}
