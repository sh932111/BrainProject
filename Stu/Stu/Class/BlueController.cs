using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Management;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using Stu.Manager;

namespace Stu.Class
{
    class BluetoothController
    {
        public BluetoothController()
        {
            initBluetoothList();
        }

        ArrayList bluetoothList = null;

        private void initBluetoothList()
        {
            bluetoothList = new ArrayList();
        }

        public void findBluetoothTolist()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Discoverable;
            BluetoothClient bluetoothClient = new BluetoothClient();
            BluetoothDeviceInfo[] bluetoothDeviceInfo = bluetoothClient.DiscoverDevices(10);
            ArrayList deviceCollection = new ArrayList();
            foreach (BluetoothDeviceInfo device_info in bluetoothDeviceInfo)
            {
                string device_name = device_info.DeviceName;
                string device_address = device_info.DeviceAddress.ToString();
                BluetoothDeviceManager manager = new BluetoothDeviceManager(device_name,device_address);
                deviceCollection.Add(manager);
            }
            System.Management.ManagementObjectSearcher Searcher = new System.Management.ManagementObjectSearcher("Select * from WIN32_SerialPort");
            foreach (System.Management.ManagementObject Port in Searcher.Get())
            {
                string PNPDeviceID = Port.GetPropertyValue("PNPDeviceID").ToString();
                string DeviceID = Port.GetPropertyValue("DeviceID").ToString();
                for (int i = 0; i < deviceCollection.Count; i++)
                {
                    BluetoothDeviceManager manager = (BluetoothDeviceManager)deviceCollection[i];
                    string device_address = manager.getDeviceAddress();
                    int index = PNPDeviceID.IndexOf(device_address);
                    if (index > 0)
                    {
                        manager.addCOM(DeviceID);
                        bluetoothList.Add(manager);
                    }
                }
            }
        }

        public ArrayList getBluetoothList()
        {
            return bluetoothList;
        }

        private Boolean tryConnect(string COM)
        {
            Console.WriteLine(COM);
            try
            {
                SerialPort BluetoothConnection = new SerialPort();
                BluetoothConnection.PortName = COM;
                BluetoothConnection.BaudRate = 115200;
                BluetoothConnection.Open();
                BluetoothConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
//foreach (PropertyData prop in Port.Properties)
//{
//    Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
//}
