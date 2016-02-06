using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Class;

namespace Stu.UI
{
    public partial class ConfigTest : Form
    {
        public ConfigTest()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (textTestTime.Text.Length == 0 || textUserName.Text.Length == 0 || textUserYearOld.Text.Length == 0 || textWordNum.Text.Length == 0)
            {
                MessageBox.Show("欄位都為必填!");
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
        }

        private void httpResponse(JSONObject response)
        {
            int error_code = response.getInt("error_code");
            if (error_code == 0) Console.WriteLine(response.toString());
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult myResult = MessageBox.Show("取消設定?", "確定要取消此測試?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ( myResult  == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
