using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Stu.Manager
{
    class ConfigManager
    {
        private ArrayList lastRange = null;
        private ArrayList firstRange = null;
        private BluetoothDeviceManager deviceManager = null;
        private string outPath = "";
        private string orderID = "";
        int runTime = 0;
        public ConfigManager(string id, string path, BluetoothDeviceManager device, ArrayList fr, ArrayList lr)
        {
            this.orderID = id;
            this.outPath = path;
            this.deviceManager = device;
            this.firstRange = fr;
            this.lastRange = lr;
        }
    }
}
