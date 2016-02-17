using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Manager
{
    public partial class ConfigManager
    {
        private BluetoothDeviceManager deviceManager = null;
        private string outPath = "";
        private string orderID = "";
        int runTime = 0;
        public ConfigManager(string id, string path, int run, BluetoothDeviceManager device)
        {
            this.orderID = id;
            this.outPath = path;
            this.deviceManager = device;
            this.runTime = run + 10;
        }
        public string getOrderID()
        {
            return orderID;
        }
        public string getPath()
        {
            return outPath;
        }
        public int getRunTime()
        {
            return runTime;
        }
        public BluetoothDeviceManager getDeviceManager()
        {
            return deviceManager;
        }
    }
}
