
using CYFang.Class;
using CYFang.Forms;
using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace CYFang
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 圖元件
        /// </summary>
        private Chart _chart;

        private Chart _chartAvg;

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
        /// 記錄使用者勾選顯示欄位
        /// </summary>
        private List<int> _list
        {
            get
            {
                List<int> list = new List<int>();
                int count = _CheckBoxCount;

                for (int index = 0; index < count; index++)
                    if (checkedListBox1.GetItemChecked(index)) list.Add(index);
                return list;
            }
        }

        /// <summary>
        /// CheckBox count
        /// </summary>
        private int _CheckBoxCount { get { return checkedListBox1.Items.Count; } }


        /// <summary>
        /// 使用者選擇ComPort編號
        /// </summary>
        private String _SelectComPort { get { return comboBoxPort.SelectedItem.ToString(); } }

        /// <summary>
        /// 取得電腦上的ComPort
        /// </summary>
        private String[] _comPorts { get { return SerialPort.GetPortNames(); } }

        /// <summary>
        /// ComPort總長度
        /// </summary>
        private int _comPortLength { get { return _comPorts.Length; } }

        /// <summary>
        /// 選取的數值
        /// </summary>
        private int[] _selectNumbers { get { return _list.ToArray(); } }

        private List<String> _listHeader = new List<string>();

        /// <summary>
        /// 圖的種類
        /// </summary>
        private SeriesChartType _type
        {
            get
            {
                int index = _selectChartType;

                if (index == 0)
                    return SeriesChartType.Line;
                else if (index == 1)
                    return SeriesChartType.Column;
                return SeriesChartType.Pie;
            }
        }

        /// <summary>
        /// 選擇的圖形
        /// </summary>
        private int _selectChartType { get; set; }


        /// <summary>
        /// 資料序列的長度
        /// </summary>
        private Series[] _series
        {
            get
            {
                return GetSeries();
            }
        }

        /// <summary>
        /// 平均資料序列的長度
        /// </summary>
        private Series[] _seriesAvg
        {
            get
            {
                return GetSeries();
            }
        }

        /// <summary>
        /// User name
        /// </summary>
        private String _userName { get { return textBoxName.Text; } }


        /// <summary>
        /// 所選擇標籤數量
        /// </summary>
        private int _seriesCount { get { return _series.Length; } }


        /// 儲存腦波陣列
        /// </summary>
        private double[] _array;

        /// <summary>
        /// 腦波陣列平均
        /// </summary>
        private double[] _avgArray;

        /// <summary>
        /// 預設的標籤
        /// </summary>
        protected internal readonly String[] _Header = new String[]{
            "DateTime",  "Delta", "Theta", "Low Alpha", "High Alpha", 
                "Low Beta", "High Beta", "Low Gamma", "High Gamma","Pool Signal", 
                "Attention","Meditation","Presure","Sleep Qulaity","Tired"};

        /// <summary>
        /// 初始標籤
        /// </summary>
        private static List<String> _Labels = new List<string>();

        public Form1() { InitializeComponent(); }

        /// <summary>
        /// 表單載入完成的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            bool isMulti;
            Mutex mutex = new Mutex(true, Application.ProductName, out isMulti);

            if (mutex.WaitOne() == false)
            {
                MessageBox.Show("本程式不允許多開");
                Application.Exit();
            }
            else
            {

                if (_comPortLength > 0)
                {
                    Expression.CacheEnabled = false;
                    comboBoxPort.Items.AddRange(_comPorts);
                    comboBoxPort.SelectedIndex = 0;
                    comboBoxChart.SelectedIndex = 0;
                    _chart = chart1;
                    _chartAvg = chart2;

                    for (int index = 1; index < _Header.Length; index++)
                    {
                        if (index != 9)
                        {
                            checkedListBox1.Items.Add(_Header[index]);
                            _Labels.Add(_Header[index]);
                        }
                    }

                    try
                    {
                        checkedListBox1.Items.AddRange(OutputFile.Config.GetNames());
                        _Labels.AddRange(OutputFile.Config.GetNames());
                    }
                    catch (NullReferenceException ex)
                    {

                    }


                    _array = new double[checkedListBox1.Items.Count];
                    _avgArray = new double[checkedListBox1.Items.Count];

                    InitChart(ref _chart, "腦波圖");
                    InitChart(ref _chartAvg, "腦波圖(平均值)");


                    OutputFile.CSV.InitDataTable(_CheckBoxCount + 2);

                    _listHeader.AddRange(_Header);
                    foreach (String name in checkedListBox1.Items)
                        if (_listHeader.Contains(name) == false)
                            _listHeader.Add(name);

                }
                else
                {
                    MessageBox.Show("請確認電腦是否有藍牙");
                    this.Close();
                }
            }
        }


        /// <summary>
        /// 禁止使用者在ComPort上Key in
        /// </summary>
        /// <param name="sender">ComboBox</param>
        /// <param name="e">事件變數</param>
        private void comboBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        //按鈕的功能部分**********************************************************************************************************************************************
        /// <summary>
        /// 開始或停止按鈕的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "啟動")
            {
                if (_series == null)
                {
                    MessageBox.Show("請選擇要顯示的資料");
                    return;
                }
                else
                {
                    if (!_isInit)
                    {
                        //取得通訊ID
                        _connectionId = Think.TG_GetNewConnectionId();
                        if (_connectionId < 0)
                        {
                            MessageBox.Show("無法連接"); return;
                        }

                        /* Set/open stream (raw bytes) log file for connection */
                        _errCode = Think.TG_SetStreamLog(_connectionId, "streamLog.txt");
                        if (_errCode < 0)
                        {
                            MessageBox.Show("無法連接"); return;
                        }

                        /* Set/open data (Think values) log file for connection */
                        _errCode = Think.TG_SetDataLog(_connectionId, "dataLog.txt");
                        if (_errCode < 0)
                        {
                            MessageBox.Show("無法連接"); return;
                        }

                        _errCode = Think.TG_Connect(_connectionId, _SelectComPort,
                                Think.BAUD_57600, Think.STREAM_PACKETS);
                        if (_errCode < 0)
                        {
                            MessageBox.Show("無法連接"); return;
                        }

                        button.Text = "停止";
                        _isInit = true;
                        CleanArray();
                        CleanAvgArray();
                        CleanChart(ref _chart, true);
                        CleanChart(ref _chartAvg, true);
                        buttonImport.Enabled = false;


                        foreach (Series s in _series)
                            try { _chart.Series.Add(s); }
                            catch (ArgumentException ex) { }

                        foreach (Series s in _seriesAvg)
                            try { _chartAvg.Series.Add(s); }
                            catch (ArgumentException ex) { }


                        _thread = new Thread(new ThreadStart(Run));
                        _thread.Start();

                    }
                }
            }
            else if (button.Text == "停止")
            {
                button.Text = "啟動";
                Think.TG_Disconnect(_connectionId);
                _isInit = false;
                _thread.Abort();
                CleanChart(ref _chart, false);
                CleanChart(ref _chartAvg, false);
                buttonImport.Enabled = true;


                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();

                int[] select = _list.ToArray();
                String[] labels = checkedListBox1.Items.Cast<String>().ToArray();

                new TotalForm(select, _avgArray, labels, _index).ShowDialog();
                _index = 0;

            }
        }
        //END OFF按鈕的功能部分********************************************************************************************************************************
        //廠商所提供的腦波執行序******************************************************************************************************************************************
        /// <summary>
        /// 腦波執行序方法
        /// </summary>
        private void Run()
        {
            while (_isInit)
            {
                _errCode = Think.TG_ReadPackets(_connectionId, 1);

                if (_errCode == 1)
                {
                    if (Think.TG_GetValueStatus(_connectionId,
                            Think.DATA_POOR_SIGNAL) != 0)
                    {
                        _poorSignal = Think.TG_GetValue(_connectionId,
                                Think.DATA_POOR_SIGNAL);
                    }

                    if (Think
                            .TG_GetValueStatus(_connectionId, Think.DATA_DELTA) != 0)
                    {
                        _array[0] = Think.TG_GetValue(_connectionId,
                                Think.DATA_DELTA);
                    }


                    if (Think
                            .TG_GetValueStatus(_connectionId, Think.DATA_THETA) != 0)
                    {
                        _array[1] = Think.TG_GetValue(_connectionId,
                                Think.DATA_THETA);
                    }

                    if (Think.TG_GetValueStatus(_connectionId,
                            Think.DATA_LowALPHA) != 0)
                    {
                        _array[2] = Think.TG_GetValue(_connectionId,
                                Think.DATA_LowALPHA);
                    }

                    if (Think.TG_GetValueStatus(_connectionId,
                            Think.DATA_HighALPHA) != 0)
                    {
                        _array[3] = Think.TG_GetValue(_connectionId,
                                Think.DATA_HighALPHA);
                    }

                    if (Think
                            .TG_GetValueStatus(_connectionId, Think.DATA_LowBETA) != 0)
                    {
                        _array[4] = Think.TG_GetValue(_connectionId,
                                Think.DATA_LowBETA);
                    }

                    if (Think
                            .TG_GetValueStatus(_connectionId, Think.DATA_HighBETA) != 0)
                    {
                        _array[5] = Think.TG_GetValue(_connectionId,
                                Think.DATA_HighBETA);
                    }

                    if (Think.TG_GetValueStatus(_connectionId,
                            Think.DATA_LowGAMMA) != 0)
                    {
                        _array[6] = Think.TG_GetValue(_connectionId,
                                Think.DATA_LowGAMMA);
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_HighGAMMA) != 0)
                    {
                        _array[7] = Think.TG_GetValue(_connectionId,
                                Think.DATA_HighGAMMA);
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_ATTENTION) != 0)
                    {
                        _array[8] = Think.TG_GetValue(_connectionId,
                                Think.DATA_ATTENTION);
                    }

                    if (Think.TG_GetValueStatus(_connectionId, Think.DATA_MEDITATION) != 0)
                    {
                        _array[9] = Think.TG_GetValue(_connectionId,
                                Think.DATA_MEDITATION);
                    }


                    if (_tempValue != _array[0])
                    {
                        float A = (float)(_array[2] + _array[3]);
                        float B = (float)(_array[4] + _array[5]);
                        float D = (float)_array[0];
                        float T = (float)_array[1];

                        // Pressure
                        _array[10] = 100 - _array[9];
                        //Sleep_Quality
                        _array[11] = (int)((((B / 2) + (T / 20)) / ((A / 2) + (D / 20))) * 100);
                        //Fatigue
                        _array[12] = (int)((((A / 2) + T) / (B / 2)));



                        if (_CheckBoxCount > 13)
                            for (int index = 13; index < _CheckBoxCount; index++)
                                _array[index] = Rules.RulesToDouble(Rules.GetReplaceString(
                                   OutputFile.Config.GetRules()[index - 13]), ref _array);

                        for (int index = 0; index < _array.Length; index++)
                            _avgArray[index] += _array[index];
                        //判斷訊號雜訊不為0就會被刪掉***********************************************************************************************************************************
                        if (_poorSignal == 0)
                        {
                            int tempCount = 0;

                            foreach (double p in _array)
                            {
                                if (p == 0)
                                    tempCount++;
                                if (tempCount == 3)
                                    break;
                            }

                            if (tempCount != 3)
                                OutputFile.CSV.AddData(_CheckBoxCount, ref _array, _poorSignal);
                        }
                        //END OFF判斷雜訊值為不為0***************************************************************************************************************************************

                        try
                        {
                            _chart.Invoke(new MethodInvoker(delegate()
                            {
                                DrawChart(_array, ref _index, ref _chart);
                            }));

                            _chartAvg.Invoke(new MethodInvoker(delegate()
                            {
                                DrawChartAvg(_avgArray, ref _index, ref _chartAvg);
                            }));
                        }
                        catch
                        {

                        }


                        _index++;
                        _tempValue = _array[0];
                    }
                }
            }
        }
        //END OFF廠商執行序************************************************************************************************************************************************
        /// <summary>
        /// 將平均的數值畫出線段
        /// </summary>
        /// <param name="array">陣列</param>
        /// <param name="index">序列</param>
        /// <param name="chart">平均陣列的圖形</param>
        private void DrawChartAvg(double[] array, ref int index, ref Chart chart)
        {
            double[] tempArray = new double[array.Length];
            for (int point = 0; point < tempArray.Length; point++)
                tempArray[point] = Math.Round(array[point] / (_index + 1), 4);

            DrawChart(tempArray, ref index, ref chart);
        }

        /// <summary>
        /// 將數值畫出線段
        /// </summary>
        /// <param name="type">SeriesChartType</param>
        /// <param name="index">位置</param>
        private void DrawChart(double[] array, ref int index, ref Chart chart)
        {
            if (_type == SeriesChartType.Line)
            {
                //折線圖
                if (index % 30 == 0 && index != 0)
                    chart.ChartAreas[0].AxisX.ScaleView.Position += 30;

                for (int i = 0; i < _seriesCount; i++)
                    chart.Series[i].Points.AddXY(_index, array[_list[i]]);
                //chart.ChartAreas[0].AxisX.ScaleView.Position = index / 2
            }
            else if (_type == SeriesChartType.Column)
                //長條圖
                for (int i = 0; i < _seriesCount; i++)
                {
                    chart.Series[i].Points.Clear();
                    chart.Series[i].Points.AddXY(0, array[_list[i]]);
                }
            else if (_type == SeriesChartType.Pie)
            {
                chart.Series[0].Points.Clear();

                for (int i = 0; i < _list.Count; i++)
                    chart.Series[0].Points.AddXY(i, array[_list[i]]);
            }
        }

        private void DrawChart(double[] array, ref int index, int[] selectNumber, ref Chart chart)
        {
            if (_type == SeriesChartType.Line)
            {
                //折線圖
                if (index % 30 == 0 && index != 0)
                    chart.ChartAreas[0].AxisX.ScaleView.Position += 30;

                for (int i = 0; i < selectNumber.Length; i++)
                    chart.Series[i].Points.AddXY(_index, array[selectNumber[i]]);
            }
            else if (_type == SeriesChartType.Column)
                //長條圖
                for (int i = 0; i < selectNumber.Length; i++)
                {
                    chart.Series[i].Points.Clear();
                    chart.Series[i].Points.AddXY(0, array[selectNumber[i]]);
                }
            else if (_type == SeriesChartType.Pie)
            {
                chart.Series[0].Points.Clear();

                for (int i = 0; i < _list.Count; i++)
                    chart.Series[0].Points.AddXY(i, array[selectNumber[i]]);
            }
        }

        /// <summary>
        /// 顯示設定公式畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetRules_Click(object sender, EventArgs e)
        {
            new RulesForm(this).ShowDialog();
        }

        /// <summary>
        /// 圖形種類選項改變的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            _selectChartType = box.SelectedIndex;
        }

        /// <summary>
        /// 背景執行序執行完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OutputFile.CSV.InitDataTable(_CheckBoxCount + 2);
            MessageBox.Show("檔案已經輸出");
        }


        /// <summary>
        /// 背景執行序開始運行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            OutputFile.CSV.OutputCSV(String.Format("{0}__{1}.csv", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                _userName), _listHeader.ToArray());
        }


        private void CleanChart(ref Chart chart, bool isInit)
        {
            if (isInit)
            {
                chart.Series.Clear();
            }
            else
            {
                chart.ChartAreas[0].AxisX.ScaleView.Position = 0;
            }
        }

        /// <summary>
        /// 清除陣列的數值
        /// </summary>
        private void CleanArray()
        {
            int max = _array.Length;
            for (int index = 0; index < max; index++)
                _array[index] = 0;
        }

        /// <summary>
        /// 清除平均陣列的數值
        /// </summary>
        private void CleanAvgArray()
        {
            int max = _avgArray.Length;
            for (int index = 0; index < max; index++)
                _avgArray[index] = 0;
        }

        /// <summary>
        /// 重新建立陣列數量
        /// </summary>
        private void ReNewArray()
        {
            _array = new double[checkedListBox1.Items.Count];
            _avgArray = new double[checkedListBox1.Items.Count];
        }

        /// <summary>
        /// 刪除公式
        /// </summary>
        /// <param name="index">公式選項</param>
        protected internal void DeleteItem(int index)
        {
            checkedListBox1.Items.RemoveAt(index);
            _listHeader.RemoveAt(index);
            ReNewArray();
            OutputFile.CSV.InitDataTable(_CheckBoxCount + 2);
        }

        /// <summary>
        /// 加入選項
        /// </summary>
        /// <param name="name">公式名稱</param>
        protected internal void AddItem(String name)
        {
            checkedListBox1.Items.Add(name);
            _listHeader.Add(name);
            ReNewArray();
            OutputFile.CSV.InitDataTable(_CheckBoxCount + 2);
        }

        private void InitChart(ref Chart chart, String title)
        {
            chart.Titles.Clear();
            chart.Titles.Add(title);

            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart.ChartAreas[0].AxisX.ScaleView.Zoom(1, 30);

            chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 30;
            chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 1000;

            //讓使Avg用者可以選取想看得範圍
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

        }

        /// <summary>
        /// 輸出按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();

                //File type
                fileDialog.Filter = "csv files(*.csv)|*.csv";

                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String[] headers = OutputFile.CSV.ReadHeaders(fileDialog.FileName);

                    if (headers == null)
                        MessageBox.Show(String.Format("該{0}檔案不存在數據"), fileDialog.FileName);
                    else
                    {

                        var names = OutputFile.Config.GetNames();
                        var rules = OutputFile.Config.GetRules();
                        var selectForm = new SelectForm(headers, names);
                        selectForm.ShowDialog();

                        headers = selectForm.GetHeaders();

                        var selectNumber = selectForm.GetSelect();
                        for (int point = 0; point < selectNumber.Length; point++)
                        {
                            Console.WriteLine(selectNumber[point]);
                        }
                       
                        var series = GetSeries(headers, selectNumber);
                        var seriesAvg = GetSeries(headers, selectNumber);
                        CleanArray();
                        CleanAvgArray();
                        CleanChart(ref _chart, true);
                        CleanChart(ref _chartAvg, true);

                        foreach (Series s in series)
                            try { _chart.Series.Add(s); }
                            catch (ArgumentException ex) { }

                        foreach (Series s in seriesAvg)
                            try { _chartAvg.Series.Add(s); }
                            catch (ArgumentException ex) { }


                        DrawCSV(fileDialog.FileName, rules, selectNumber);

                        if (OutputFile.CSV.OldToNewCSV(fileDialog.FileName,
    OutputFile.Config.GetRules(), _listHeader.ToArray()) == true)
                            MessageBox.Show("檔案輸出成功");
                        else
                            MessageBox.Show("檔案輸出失敗");
                    }
                }
                else
                {
                    MessageBox.Show("請選擇正確檔案");
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("請先關閉該檔案");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("請確認檔案是否存在");
            }

        }


        private void DrawCSV(String filepath, String[] rules, int[] selectNumber)
        {
            String[] csv = OutputFile.CSV.ReadCSV(filepath);

            int csvLength = csv.Length;
            int selectLength = selectNumber.Length;
            double[] avg = new double[selectLength];

            for (int index = 1; index < csvLength; index++)
            {
                String[] tempLine = csv[index].Split(
                    new string[] { ",", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

                int size = tempLine.Length - 2 + rules.Length;

                double[] array = new double[size];
                array[0] = double.Parse(tempLine[1]);
                array[1] = double.Parse(tempLine[2]);
                array[2] = double.Parse(tempLine[3]);
                array[3] = double.Parse(tempLine[4]);
                array[4] = double.Parse(tempLine[5]);
                array[5] = double.Parse(tempLine[6]);
                array[6] = double.Parse(tempLine[7]);
                array[7] = double.Parse(tempLine[8]);
                array[8] = double.Parse(tempLine[10]);
                array[9] = double.Parse(tempLine[11]);
                array[10] = double.Parse(tempLine[12]);
                array[11] = double.Parse(tempLine[13]);
                array[12] = double.Parse(tempLine[14]);


                int point = 13;
                if (tempLine.Length - 15 > 0)
                    for (point = 13; point < tempLine.Length - 2; point++)
                        array[point] = double.Parse(tempLine[point + 2]);

                int temp = 0;
                int newRulesLength = (size - (tempLine.Length - 2));
                if (newRulesLength > 0)
                    for (; point < size; point++)
                    {
                        array[point] = Rules.RulesToDouble(Rules.GetReplaceString(
                           rules[temp]), ref array);
                        temp++;
                    }

                for (point = 0; point < selectLength; point++)
                {
                    avg[point] += array[selectNumber[point]];
                    _chart.Series[point].Points.AddY(array[selectNumber[point]]);
                    _chartAvg.Series[point].Points.AddY(avg[point] / index);
                }

            }
        }

        private Series[] GetSeries(String[] headers, int[] selectNumber)
        {
            int length = selectNumber.Length;
            Series[] series = length > 0 ? new Series[length] : null;
            if (series == null)
                return series;

            if (_type == SeriesChartType.Pie)
            {
                series = new Series[1];
                series[0] = new Series();
                series[0].ChartType = SeriesChartType.Pie;
                series[0].IsValueShownAsLabel = false;
                return series;
            }


            for (int index = 0; index < length; index++)
            {
                series[index] = new Series(headers[index]);
                series[index].ChartType = _type;
                series[index].BorderWidth = 3;
                series[index].BorderColor = Color.FromArgb(index);
                series[index].MarkerStyle = MarkerStyle.Circle;
                series[index].MarkerSize = 10;
                series[index].MarkerColor = Color.Black;
                series[index].IsValueShownAsLabel = false;
            }
            return series;
        }

        private Series[] GetSeries()
        {
            Series[] series = _list.Count > 0 ? new Series[_list.Count] : null;
            if (series == null)
                return series;

            if (_type == SeriesChartType.Pie)
            {
                series = new Series[1];
                series[0] = new Series();
                series[0].ChartType = SeriesChartType.Pie;
                series[0].IsValueShownAsLabel = false;
                return series;
            }

            int length = series.Length;
            for (int index = 0; index < length; index++)
            {
                series[index] = new Series(checkedListBox1.Items[_list[index]].ToString());
                series[index].ChartType = _type;
                series[index].BorderWidth = 3;
                series[index].BorderColor = Color.FromArgb(index);
                series[index].MarkerStyle = MarkerStyle.Circle;
                series[index].MarkerSize = 10;
                series[index].MarkerColor = Color.Black;
                series[index].IsValueShownAsLabel = false;
            }
            return series;
        }


    }
}
