using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Collections;
using Stu.Manager;

namespace Stu.Class
{
    class BrainReceiver
    {
        public delegate void BrainReceiverCallback(BrainManager manager);

        private string COM = null;
        private SerialPort bluetoothConnection = null;
        private Thread bluetoothThread = null;
        private Boolean isRun = false;
        private BrainReceiverCallback aCallback;

        public BrainReceiver(string com,BrainReceiverCallback cb)
        {
            this.aCallback = cb;
            this.COM = com;
            this.bluetoothConnection = new SerialPort();
            bluetoothConnection.PortName = com;
            bluetoothConnection.BaudRate = 115200;
            this.isRun = true;
        }
        
        public void run()
        {
            bluetoothConnection.Open();
            bluetoothThread = new Thread(() => customRun(bluetoothConnection));
            bluetoothThread.Start();
        }

        private void customRun(SerialPort BluetoothConnection)
        {
            ArrayList streamLogList = new ArrayList();
            ArrayList dataLogList = new ArrayList();
            ArrayList brainList = new ArrayList();
            ArrayList fftList = new ArrayList();
            ArrayList tempList = new ArrayList();
            int check = 0;
            int init = 0;
            while (isRun)
            {
                String Value = BluetoothConnection.ReadByte().ToString("X2");
                String res = Value;
                if (Value.Equals("AA") && check == 0)
                {
                    check = 1;
                    tempList.Add(res);
                }
                else if (Value.Equals("AA") && check == 1)
                {
                    check = 2;
                    tempList.Add(res);
                }
                else if (Value.Equals("04") && check == 2)
                {
                    ArrayList item = new ArrayList();
                    ArrayList newItem = new ArrayList();
                    Boolean brash_check = false;
                    int brash_init = 0;
                    for (int x = 0; x < tempList.Count; x++)
                    {
                        if (x == tempList.Count - 1 || x == tempList.Count - 2)
                        {
                            newItem.Add(tempList[x]);
                        }
                        else
                        {
                            if (tempList[x].Equals("AA") && brash_init == 0)
                            {
                                brash_init = 1;
                                item.Add(tempList[x]);
                            }
                            else if (tempList[x].Equals("AA") && brash_init == 1)
                            {
                                brash_init = 2;
                                item.Add(tempList[x]);
                            }
                            else if (tempList[x].Equals("04") && brash_init == 2)
                            {
                                brash_init = 0;
                                item.Add(tempList[x]);
                                brash_check = false;
                            }
                            else if (tempList[x].Equals("20") && brash_init == 2)
                            {
                                brash_init = 0;
                                item.Add(tempList[x]);
                                brash_check = true;
                            }
                            else if (tempList[x].Equals("AA") && brash_init == 2)
                            {
                                brash_init = 2;
                                item.Add(tempList[x]);
                            }
                            else
                            {
                                brash_init = 0;
                                item.Add(tempList[x]);
                            }
                        }
                    }
                    if (init == 2)
                    {
                        String getTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fffff");
                        item.Insert(0, getTime);
                        streamLogList.Add(item);
                        if (brash_check)
                        {
                            ArrayList refresh_item = new ArrayList();
                            int refresh = 0;
                            int datalog = 0;
                            String code = "";
                            for (int i = 0; i < item.Count; i++)
                            {
                                if (i == 0) refresh_item.Add(item[i]);
                                else if (i < 7 && i > 0) continue;
                                else if (datalog < 8)
                                {
                                    code = code + item[i];
                                    if (refresh == 0)
                                    {
                                        refresh = 1;
                                    }
                                    else if (refresh == 1)
                                    {
                                        refresh = 2;
                                    }
                                    else if (refresh == 2)
                                    {
                                        datalog = datalog + 1;
                                        refresh = 0;
                                        String add = (String)code.Clone();
                                        refresh_item.Add(Calculate.run16ToString(add));
                                        code = "";
                                    }
                                }
                                else
                                {
                                    if (datalog == 10 || datalog == 12)
                                    {
                                        refresh_item.Add(Calculate.run16ToString((String)item[i]));
                                    }
                                    datalog = datalog + 1;
                                }
                            }
                            brainList.Add(refresh_item);
                        }
                        else
                        {
                            ArrayList refresh_item = new ArrayList();
                            refresh_item.Add(item[0]);
                            String code = (String)item[6] + (String)item[7];
                            String code_result = Calculate.run16To2(code);
                            refresh_item.Add(code_result);
                            dataLogList.Add(refresh_item);
                            ArrayList fft_item = new ArrayList();
                            fft_item.Add(code_result);
                            fftList.Add(fft_item);
                        }
                    }
                    if (init == 1)
                    {
                        init = 2;
                    }
                    tempList.Clear();
                    tempList = (ArrayList)newItem.Clone();
                    check = 0;
                    tempList.Add(res);
                }
                else if (Value.Equals("20") && check == 2)
                {
                    ArrayList item = new ArrayList();
                    ArrayList newItem = new ArrayList();
                    for (int x = 0; x < tempList.Count; x++)
                    {
                        if (x == tempList.Count - 1 || x == tempList.Count - 2)
                        {
                            newItem.Add(tempList[x]);
                        }
                        else item.Add(tempList[x]);
                    }
                    if (init == 2)
                    {
                        String getTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fffff");
                        item.Insert(0, getTime);
                        streamLogList.Add(item);
                    }
                    if (init == 0) init = 1;
                    tempList.Clear();
                    tempList = (ArrayList)newItem.Clone();
                    check = 0;
                    tempList.Add(res);
                }
                else if (Value.Equals("AA") && check == 2)
                {
                    check = 2;
                    tempList.Add(res);
                }
                else
                {
                    check = 0;
                    tempList.Add(res);
                }
            }
            bluetoothConnection.Close();
            bluetoothThread.Abort();
            Console.WriteLine("STOP");
            BrainManager manager = new BrainManager(streamLogList,dataLogList,brainList,fftList);
            if (aCallback != null) aCallback(manager);
        }

        public void stop()
        {
            isRun = false;
        }
    }
}
