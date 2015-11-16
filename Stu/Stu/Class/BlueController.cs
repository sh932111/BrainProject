using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Management;
using System.Collections;

namespace Stu.Class
{
    class BluetoothController
    {
        ArrayList bluetoothList = null;

        public BluetoothController()
        {
            bluetoothList =  new ArrayList();
        }

        public void findBluetoothTolist()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Discoverable;
            BluetoothClient bluetoothClient = new BluetoothClient();
            BluetoothDeviceInfo[] bluetoothDeviceInfo = bluetoothClient.DiscoverDevices(10);
            foreach (BluetoothDeviceInfo device_info in bluetoothDeviceInfo)
            {
                string device_address = device_info.DeviceAddress.ToString();
                string device_name = device_info.DeviceName;
                System.Management.ManagementObjectSearcher Searcher = new System.Management.ManagementObjectSearcher("Select * from WIN32_SerialPort");
                foreach (System.Management.ManagementObject Port in Searcher.Get()) 
                {
                    string PNPDeviceID = Port.GetPropertyValue("PNPDeviceID").ToString();
                    string DeviceID = Port.GetPropertyValue("DeviceID").ToString();
                    int index = PNPDeviceID.IndexOf(device_address);
                    if (index > 0)
                    {
                        Dictionary<string, string> item = new Dictionary<string, string>();
                        item.Add("DeviceName", device_name);
                        item.Add("DeviceAddress", device_address);
                        item.Add("COM", DeviceID);
                        bluetoothList.Add(item);
                    }
                }
            }
        }

        public ArrayList getBluetoothList()
        {
            return bluetoothList;
        }
    }
}
