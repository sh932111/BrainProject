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
    public partial class OrderView : Form
    {
        private string orderID;
        public OrderView(string order_id)
        {
            InitializeComponent();
            this.orderID = order_id;
            getOrderView();
        }
        private void getOrderView()
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.orderView, httpResponse);
            JSONObject form = new JSONObject();
            form.setString("orderID", orderID);
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
                Console.WriteLine(response.toString());
            }
            else
            {
                string message = response.getString("message");
                MessageBox.Show(message);
            }
        }
    }
}
