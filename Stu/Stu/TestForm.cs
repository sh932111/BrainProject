using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stu.UI;
using Stu.Utils;
using Stu.Class;
using Newtonsoft.Json;

namespace Stu
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.wordList, httpResponse);
            Dictionary<string, string> form = new Dictionary<string, string>();
            form["enTypeID"] = "201602011620292818";
            httpWorker.setData(form);
            httpWorker.httpWorker();
        }

        private void httpResponse(Dictionary<string, object> response)
        {
            string wordList = response["wordList"].ToString();
            List<object> list = JsonConvert.DeserializeObject<List<object>>(wordList);
            for (int i = 0; i < list.Count; i++)
            {
                string wordItem = list[i].ToString();
                Dictionary<string, object> item = JsonConvert.DeserializeObject<Dictionary<string, object>>(wordItem);
                Console.WriteLine(item["enWord"]);
            }
        }
    }
}
