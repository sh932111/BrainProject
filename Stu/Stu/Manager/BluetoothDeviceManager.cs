using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stu.Manager
{
    public class BluetoothDeviceManager
    {
        private Dictionary<string, string> deviceData = null;
        public BluetoothDeviceManager(string DeviceName, string DeviceAddress)
        {
            deviceData = new Dictionary<string, string>();
            deviceData["DeviceName"] = DeviceName;
            deviceData["DeviceAddress"] = DeviceAddress;
        }
        public void addCOM(string com) 
        {
            deviceData["COM"] = com;
        }
        public string getDeviceName()
        {
            return deviceData["DeviceName"];
        }
        public string getDeviceAddress()
        {
            return deviceData["DeviceAddress"];
        }
        public string getCOM()
        {
            return deviceData["COM"];
        }
    }
}
