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
    public partial class Choose : Form
    {
        ConfigManager configManager = null;
        public Choose(ConfigManager manager )
        {
            InitializeComponent();
            this.configManager = manager;
            this.TopMost = true;
        }

        private void chooseFinishBtn_Click(object sender, EventArgs e)
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderCheckout, httpResponse);
            JSONObject form = new JSONObject();
            form.setString("orderID", configManager.getOrderID());
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
                ChromeUtils.closeChrome();
                this.Close();
                ShowExDialog.show("第二步、背單字", Properties.Resources.memory);
                Memory memory = new Memory(configManager);
                memory.Show();
                memory.Location = new Point(0, 0);
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
    }
}
