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
        private int runTime = 0;
        private Boolean isTest = false;
        public ConfigManager(string id, string path, int run, BluetoothDeviceManager device , Boolean is_test)
        {
            this.orderID = id;
            this.outPath = path;
            this.deviceManager = device;
            if (is_test)
            {
                this.runTime = run ;
            }
            else
            {
                this.runTime = run + 10;
            }
            this.isTest = is_test;
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
        public Boolean getIsTest()
        {
            return isTest;
        }
    }
}
