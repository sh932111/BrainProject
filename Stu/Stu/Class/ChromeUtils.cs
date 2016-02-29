using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Stu.Class
{
    public class ChromeUtils
    {
        public static string chooseURL = "http://shared.tw/En/test/chooseWord/?orderID=";
        public static string memoryURL = "http://shared.tw/En/test/memoryWord/?orderID=";
        public static string testURL = "http://shared.tw/En/test/checkout/?orderID=";
        public static string exURL = "http://shared.tw/En/test/ex/";
        public static void openChrome(string url)
        {
            Process.Start("chrome.exe",url);
        }
        public static void closeChrome()
        {
            string ProcessName = "chrome";//這裡換成你需要刪除的進程名稱
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (Process p in processes)
            {
                p.CloseMainWindow();
            }
        }
    }
}
