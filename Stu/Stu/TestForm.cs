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
using Stu.Manager;

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
            JSONObject form = new JSONObject();
            form.setString("enTypeID", "201602011620292818");
            httpWorker.setData(form);
            httpWorker.httpWorker();
        }

        private void httpResponse(JSONObject response)
        {
            JSONArray list = response.getJSONArray("wordList");
            for (int i = 0 ;i < list.Count ; i ++) 
            {
                JSONObject item = list.getJSONObject(i);
                WordManager manager = new WordManager(item);
            }
        }
    }
}
