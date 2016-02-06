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
using System.Diagnostics;

namespace Stu
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            ConfigTest config = new ConfigTest();
            config.Show();
        }

        public void openChrome()
        {
            Process.Start("chrome.exe", "http://shared.tw/En/body/pages/index/");
        }

        public void closeChrome()
        {
            string ProcessName = "chrome";//這裡換成你需要刪除的進程名稱
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process p in processes)
            {
                p.CloseMainWindow();
            }
        }

        public void callWordList()
        {
            HttpWorker httpWorker = new HttpWorker(HttpWorker.wordList, httpResponse);
            JSONObject form = new JSONObject();
            httpWorker.setData(form);
            httpWorker.httpWorker();
        }

        private void httpResponse(JSONObject response)
        {
            JSONArray list = response.getJSONArray("wordList");
            for (int i = 0; i < list.Count; i++)
            {
                JSONObject item = list.getJSONObject(i);
                Console.WriteLine(item.toString());
                WordManager manager = new WordManager(item);
            }
        }
    }
}
