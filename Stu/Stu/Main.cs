using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Utils;
using Stu.Class;
using System.IO;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using NCalc;

namespace Stu
{
    public partial class Main : Form
    {
        FileListUtils fileListUtils = null;
        String outputPath = "";
        int runType = 0;

        public Main()
        {
            InitializeComponent();
            setBluetooth();
            setListView();
            setComboBox();
            Computer computer = new Computer();
            computer.Show();
            
            ArrayList time_out = DSP.getArrayWithDivision(512.0f, 0.0f, 2048.0f);
            complex[] fft_res = DSP.FFT(getTestResource());
            ArrayList result = DSP.arrayMagic(time_out, fft_res, 2048);

            StreamWriter sw = new StreamWriter("yoga_FFT_res.csv");
            foreach (ArrayList item in result)
            {
                String row = "";
                for (int i = 0; i < item.Count; i++)
                {
                    if (row.Length == 0) row = (String)item[i];
                    else row = row + "," + (String)item[i];
                    if (i == item.Count - 1) sw.WriteLine(row);
                }
            }
            sw.Close();
        }

        private complex[] getTestResource() 
        {
            ArrayList resource = new ArrayList();
            StreamReader SR = new StreamReader("ch1_4_512.csv");
            string Line;
            int index = 0;
            while ((Line = SR.ReadLine()) != null && index < 2048)
            {
                string[] ReadLine_Array = Line.Split(',');
                String row_a = ReadLine_Array[0];
                float f_row_a = float.Parse(row_a);
                resource.Add(f_row_a);
                index++;
            }
            SR.Close();
            complex[] res = new complex[resource.Count];
            int x = 0;
            foreach (float f in resource) 
            {
                complex item = new complex(f , 0);
                res[x] = item;
                x++;
            }
            return res;
        } 

        /*藍芽*/
        private void setBluetooth()
        {
            if (_comPortLength > 0)
            {
                Expression.CacheEnabled = false;
            }
        }


        /// <summary>
        /// 執行序
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// 記數
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// 腦波初始化
        /// </summary>
        private Boolean _isInit = false;

        /// <summary>
        /// 腦波錯誤代碼
        /// </summary>
        private int _errCode = -1;

        /// <summary>
        /// 資料訊號是否穩定
        /// </summary>
        private double _poorSignal = -1;

        /// <summary>
        /// 腦波連接ID
        /// </summary>
        private int _connectionId = -1;

        /// <summary>
        /// 用於辨識資料是否重複
        /// </summary>
        private double _tempValue = 0;

        /// <summary>
        /// 使用者選擇ComPort編號
        /// </summary>
        private String _SelectComPort { get { return "COM6"; } }

        /// <summary>
        /// 取得電腦上的ComPort
        /// </summary>
        private String[] _comPorts { get { return SerialPort.GetPortNames(); } }

        /// <summary>
        /// ComPort總長度
        /// </summary>
        private int _comPortLength { get { return _comPorts.Length; } }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            runCustomSDK();
        }
        
        private SerialPort BluetoothConnection1 = new SerialPort();
        private SerialPort BluetoothConnection2 = new SerialPort();
        private Thread _thread1;
        private Thread _thread2;
        private System.Windows.Forms.Timer theTimer = new System.Windows.Forms.Timer();
        private int time;
        private Boolean isRun = false;

        private void runCustomSDK()
        {
            if (BluetoothConnection1.IsOpen)
            {
                closeRun();
                isRun = false;
                time = 0;
            }
            else
            {
                FolderBrowserDialog path = new FolderBrowserDialog();
                path.ShowDialog();
                pathLabel.Text = path.SelectedPath;
                this.outputPath = path.SelectedPath;
                isRun = true;
                time = 0;
                theTimer.Interval = 1000;
                theTimer.Tick += new System.EventHandler(this.addTime);
                theTimer.Enabled = true;

                this.BluetoothConnection1.PortName = "COM3";
                BluetoothConnection1.BaudRate = 115200;
                BluetoothConnection1.Open();
                _thread1 = new Thread(() => customRun(BluetoothConnection1));
                _thread1.Start();

                this.BluetoothConnection2.PortName = "COM8";
                BluetoothConnection2.BaudRate = 115200;
                BluetoothConnection2.Open();
                _thread2 = new Thread(() => customRun(BluetoothConnection2));
                _thread2.Start();
            }
        }

        private void addTime(object sender, System.EventArgs e)
        {
            time = time + 1;
            timeLabel.Text = time + "s";
            if (time == 10) {
                theTimer.Enabled = false;
                isRun = false;
                time = 0;
            }
        }

        private void customRun(SerialPort BluetoothConnection)
        {
            ArrayList list = new ArrayList();
            ArrayList nothinglist = new ArrayList();
            ArrayList brashlist = new ArrayList();
            ArrayList fftlist = new ArrayList();
            ArrayList xlist = new ArrayList();
            ArrayList temp = new ArrayList();
            int check = 0;
            int init = 0;
            String startTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            while (isRun)
            {
                String Value = BluetoothConnection.ReadByte().ToString("X2");
                String res = Value;
                if (Value.Equals("AA") && check == 0 )
                {
                    check = 1;
                    temp.Add(res);
                }
                else if (Value.Equals("AA") && check == 1)
                {
                    check = 2;
                    temp.Add(res);
                }
                else if (Value.Equals("04") && check == 2)
                {
                    ArrayList item = new ArrayList();
                    ArrayList newItem = new ArrayList();
                    Boolean brash_check = false;
                    int brash_init = 0;
                    for (int x = 0; x < temp.Count; x++)
                    {
                        if (x == temp.Count - 1 || x == temp.Count - 2)
                        {
                            newItem.Add(temp[x]);
                        }
                        else 
                        {
                            if (temp[x].Equals("AA") && brash_init == 0) 
                            {
                                brash_init = 1;
                                item.Add(temp[x]);
                            }
                            else if (temp[x].Equals("AA") && brash_init == 1)
                            {
                                brash_init = 2;
                                item.Add(temp[x]);
                            }
                            else if (temp[x].Equals("04") && brash_init == 2)
                            {
                                brash_init = 0;
                                item.Add(temp[x]);
                                brash_check = false;
                            }
                            else if (temp[x].Equals("20") && brash_init == 2)
                            {
                                brash_init = 0;
                                item.Add(temp[x]);
                                brash_check = true;
                            }
                            else if (temp[x].Equals("AA") && brash_init == 2)
                            {
                                brash_init = 2;
                                item.Add(temp[x]);
                            }
                            else
                            {
                                brash_init = 0;
                                item.Add(temp[x]);
                            }
                        } 
                    }
                    if (init == 2)
                    {
                        String getTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fffff");
                        item.Insert(0, getTime);
                        list.Add(item);
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
                            brashlist.Add(refresh_item);
                        }
                        else
                        {
                            ArrayList refresh_item = new ArrayList();
                            refresh_item.Add(item[0]);
                            String code = (String)item[6] + (String)item[7];
                            String code_result = Calculate.run16To2(code);
                            refresh_item.Add(code_result);
                            nothinglist.Add(refresh_item);

                            ArrayList fft_item = new ArrayList();
                            fft_item.Add(code_result);
                            fftlist.Add(fft_item);
                            //fftlist.Add(code_result);
                        }
                    }
                    if (init == 1) 
                    {
                        init = 2;
                    }
                    temp.Clear();
                    temp = (ArrayList)newItem.Clone();
                    check = 0;
                    temp.Add(res);
                }
                else if (Value.Equals("20") && check == 2)
                {
                    ArrayList item = new ArrayList();
                    ArrayList newItem = new ArrayList();
                    for (int x = 0; x < temp.Count; x++)
                    {
                        if (x == temp.Count - 1 || x == temp.Count - 2)
                        {
                            newItem.Add(temp[x]);
                        }
                        else item.Add(temp[x]);
                    }
                    if (init == 2)
                    {
                        String getTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fffff");
                        item.Insert(0, getTime);
                        list.Add(item);
                    }
                    if (init == 0) init = 1;
                    temp.Clear();
                    temp = (ArrayList)newItem.Clone();
                    check = 0;
                    temp.Add(res);
                }
                else if (Value.Equals("AA") && check == 2)
                {
                    check = 2;
                    temp.Add(res);
                }
                else
                {
                    check = 0;
                    temp.Add(res);
                }
            }
            Random crandom = new Random();
            int rand = crandom.Next(1000);
            Console.WriteLine(rand);
            String overTime = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            String create_file_name1 = outputPath + "/" + DateTime.Now.ToString("MMddyyyyHHmmss") + rand + "1.csv";
            String create_file_name2 = outputPath + "/" + DateTime.Now.ToString("MMddyyyyHHmmss") + rand + "2.csv";
            String create_file_name3 = outputPath + "/" + DateTime.Now.ToString("MMddyyyyHHmmss") + rand + "3.csv";
            String create_file_name4 = outputPath + "/" + DateTime.Now.ToString("MMddyyyyHHmmss") + rand + "4.csv";
            int numRow = list.Count / 513;
            Console.WriteLine(numRow);
            writeCode(create_file_name1, startTime, overTime, list, 513, numRow,null);
            writeCode(create_file_name2, startTime, overTime, nothinglist, 512, numRow,brashTitleItem());
            writeCode(create_file_name3, startTime, overTime, brashlist , 1 , numRow , fftTitleItem());
            writeCode(create_file_name4, "", "", fftlist, 512, numRow,null);

            MessageBox.Show("Over");
            System.Diagnostics.Process.Start(outputPath);
        }

        private ArrayList brashTitleItem()
        {
            ArrayList result = new ArrayList();
            result.Add("DateTime");
            result.Add("Delta");
            result.Add("Theta");
            result.Add("Low Alpha");
            result.Add("High Alpha");
            result.Add("Low Beta");
            result.Add("High Beta");
            result.Add("Low GammaHigh");
            result.Add("GammaPool");
            result.Add("Attention");
            result.Add("Meditation");
            return result;
        }

        private ArrayList fftTitleItem()
        {
            ArrayList result = new ArrayList();
            result.Add("DateTime");
            result.Add("FFT");
            return result;
        }
        private void writeCode(String create_file_name, String startTime, String overTime , ArrayList list , int numMax , int numRow,ArrayList titleItem) 
        {
            StreamWriter sw = new StreamWriter(create_file_name);
            int index = 0;
            int num_max = 0;
            if (startTime.Length > 0 && overTime.Length > 0) sw.WriteLine(startTime + " ~ " + overTime);
            if (titleItem != null)
            {
                String row = "";
                for (int i = 0; i < titleItem.Count; i++)
                {
                    if (row.Length == 0) row = (String)titleItem[i];
                    else row = row + "," + (String)titleItem[i];
                    if (i == titleItem.Count - 1) sw.WriteLine(row);
                }
            }
            foreach (ArrayList item in list)
            {
                if (index == 0)
                {
                    num_max++;
                    if (num_max > numRow) break;
                }
                String row = "";
                for (int i = 0; i < item.Count; i++)
                {
                    if (row.Length == 0) row = (String)item[i];
                    else row = row + "," + (String)item[i];
                    if (i == item.Count - 1) sw.WriteLine(row);
                }
                if (index == numMax - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            sw.Close();
        }

        private void closeRun()
        {
            BluetoothConnection1.Close();
            _thread1.Abort();
            BluetoothConnection2.Close();
            _thread2.Abort();
        }

        private void runSDK() 
        {
            //取得通訊ID
            _connectionId = Think.TG_GetNewConnectionId();
            if (_connectionId < 0)
            {
                MessageBox.Show("_connectionId無法連接"); return;
            }

            /* Set/open stream (raw bytes) log file for connection */
            _errCode = Think.TG_SetStreamLog(_connectionId, "streamLog.csv");
            if (_errCode < 0)
            {
                MessageBox.Show("streamLog無法連接"); return;
            }

            /* Set/open data (Think values) log file for connection */
            _errCode = Think.TG_SetDataLog(_connectionId, "dataLog.txt");
            if (_errCode < 0)
            {
                MessageBox.Show("dataLog無法連接"); return;
            }

            _errCode = Think.TG_Connect(_connectionId, _SelectComPort,
                    Think.BAUD_115200, Think.STREAM_PACKETS);
            if (_errCode < 0)
            {
                MessageBox.Show("BAUD無法連接"); return;
            }

            isRun = true;
            time = 0;
            theTimer.Interval = 1000;
            theTimer.Tick += new System.EventHandler(this.addTime);
            theTimer.Enabled = true;
                
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        private void Run()
        {
            while (isRun)
            {
                _errCode = Think.TG_ReadPackets(_connectionId, 1);
                ArrayList temp = new ArrayList();
                if (_errCode == 1)
                {
                    if (Think.TG_GetValueStatus(_connectionId,Think.DATA_POOR_SIGNAL) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_POOR_SIGNAL));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_DELTA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_DELTA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_THETA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_THETA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId,Think.DATA_LowALPHA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_LowALPHA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId,Think.DATA_HighALPHA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_HighALPHA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_LowBETA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_LowBETA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_HighBETA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_HighBETA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_LowGAMMA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_LowGAMMA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_HighGAMMA) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId,Think.DATA_HighGAMMA));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_ATTENTION) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_ATTENTION));
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_MEDITATION) != 0)
                    {
                        temp.Add(Think.TG_GetValue(_connectionId, Think.DATA_MEDITATION));
                    }

                    for (int i = 0; i < temp.Count; i++)
                    {
                        Console.WriteLine(temp[i]);
                    }

                    //if (_tempValue != _array[0])
                    //{
                    //    float A = (float)(_array[2] + _array[3]);
                    //    float B = (float)(_array[4] + _array[5]);
                    //    float D = (float)_array[0];
                    //    float T = (float)_array[1];

                    //    // Pressure
                    //    _array[10] = 100 - _array[9];
                    //    //Sleep_Quality
                    //    _array[11] = (int)((((B / 2) + (T / 20)) / ((A / 2) + (D / 20))) * 100);
                    //    //Fatigue
                    //    _array[12] = (int)((((A / 2) + T) / (B / 2)));

                    //    _index++;
                    //    _tempValue = _array[0];
                    //}
                }
            }
            _thread1.Abort();
            _thread2.Abort();
            MessageBox.Show("Over");

        }
        /*藍芽*/

        private void setListView() 
        {
            this.fileListUtils = new FileListUtils(fileList);
        }

        private void setComboBox()
        {
            this.runTypeCombo.SelectedIndex = this.runType;
        }
        
        /*選擇檔案*/
        private void chooseBtn_Click(object sender, EventArgs e)
        {
            new OpenFileDialogUtils(fileDialogCallback);
        }

        private void fileDialogCallback(string[] files)
        {
            fileListUtils.setFileListItem(files);
        }
        /*選擇檔案*/

        /*執行*/
        private void taskBtn_Click(object sender, EventArgs e)
        {
            if (outputPath.Length > 0)
            {
                switch (this.runType)
                {
                    case 0 :
                        setRange(RangeDefinition.getFirstRange(), RangeDefinition.getLastRange());
                        break;
                    case 1:
                        RangeDialog.show(setRange);
                        break;
                    default:
                        setRange(RangeDefinition.getFirstRange(), RangeDefinition.getLastRange());
                        break;
                }
            }
            else 
            {
                MessageBox.Show("請選擇輸出的資料夾!");
            }
        }

        private void setRange(ArrayList fr, ArrayList lr)
        {
            ArrayList list = fileListUtils.getFiles();
            String create_file_name = outputPath + "/" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".csv";
            StreamWriter sw = new StreamWriter(create_file_name);
            /*寫入標準*/
            String row0 = " ,";
            for (int i = 0; i < fr.Count; i++)
            {
                double frange = double.Parse((String)fr[i]);
                double lrange = double.Parse((String)lr[i]);
                if (i != fr.Count - 1)
                {
                    row0 = row0 + frange + "~" + lrange + ",";
                }
                else
                {
                    row0 = row0 + frange + "~" + lrange;
                }
            }
            sw.WriteLine(row0);
            /*寫入標準*/

            /*將判斷後增加的資料寫入*/
            foreach (String file_path in list)
            {
                Console.WriteLine(file_path);
                String file_name = file_path.Substring(file_path.LastIndexOf("\\") + 1);
                String row_more = "";
                row_more = file_name + ",";
                double num = 0.0f;
                for (int i = 0; i < fr.Count; i++)
                {
                    double frange = double.Parse((String)fr[i]);
                    double lrange = double.Parse((String)lr[i]);

                    StreamReader SR = new StreamReader(file_path);
                    string Line;
                    while ((Line = SR.ReadLine()) != null)/*讓使用者選擇第幾筆到第幾筆(1:512)*/
                    {
                        string[] ReadLine_Array = Line.Split(',');

                        String row_a = ReadLine_Array[0];
                        String row_b = ReadLine_Array[1];

                        double f_row_a = double.Parse(row_a);
                        double f_row_b = double.Parse(row_b);

                        if (frange <= f_row_a && lrange >= f_row_a) /*參考論文邊界怎麼做*/
                        {
                            num = num + f_row_b;
                        }
                    }
                    row_more = row_more + num;
                    if (i != fr.Count - 1) row_more = row_more + ",";
                    num = 0.0f;
                }
                sw.WriteLine(row_more);
            }
            /*將判斷後增加的資料寫入*/
            sw.Close();
            MessageBox.Show("執行成功！");
            System.Diagnostics.Process.Start(outputPath);
        }

        /*執行*/

        /*選擇路徑*/
        private void pathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            pathLabel.Text = path.SelectedPath;
            this.outputPath = path.SelectedPath;
        }

        private void runTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.runType = runTypeCombo.SelectedIndex;
        }
        /*選擇路徑*/

    }
}
