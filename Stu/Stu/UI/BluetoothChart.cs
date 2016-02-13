using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using Stu.Utils;
using System.IO;

namespace Stu.UI
{
    public partial class BrainCharts : Form
    {
        /*Chart Value*/
        private ArrayList attDataes = null;
        private ArrayList chartDataes = null;
        private ArrayList chartCombos = null;
        private ArrayList maxRange = null;
        private int comboIndex;
        private int colorIndex;
        private string parseTimeForrmat = null;
        /*Chart Value*/
        public BrainCharts(string device_name , string device_mac , ArrayList max_range , string time_forrmat)
        {
            InitializeComponent();
            this.labelDeviceName.Text = device_name;
            this.labelMac.Text = device_mac;
            this.chartCombos = new ArrayList();
            this.attDataes = new ArrayList();
            this.chartDataes = new ArrayList();
            this.comboIndex = 0;
            this.colorIndex = 0;
            this.parseTimeForrmat = time_forrmat;
            this.maxRange = max_range;
        }
        /*2/11*/
        public void addParseFile(string file_path)
        {
            attDataes.Clear();
            StreamReader fSR = new StreamReader(file_path);
            string fLine;
            int index = 0;
            while ((fLine = fSR.ReadLine()) != null)
            {
                string[] ReadLine_Array = fLine.Split(',');
                if (index != 0)
                {
                    attDataes.Add(fLine);
                }
                index++;
            }
            fSR.Close();
        }

        public void parseResultFile(string file_path)
        {
            chartCombos.Clear();
            chartDataes.Clear();
            comboIndex = 0;
            StreamReader fSR = new StreamReader(file_path);
            string fLine;
            int index = 0;
            while ((fLine = fSR.ReadLine()) != null)
            {
                string[] ReadLine_Array = fLine.Split(',');
                if (index == 0)
                {
                    rangeList.Items.Clear();
                    for (int i = 1; i < ReadLine_Array.Length; i++)
                    {
                        chartCombos.Add(ReadLine_Array[i]);
                        rangeList.Items.Add(ReadLine_Array[i]);
                    }
                }
                else
                {
                    chartDataes.Add(fLine);
                }
                index++;
            }
            fSR.Close();
            showNumCombo.SelectedIndex = 0;
            int max = 3000000;
            if (maxRange != null) max = (int)maxRange[comboIndex];
            setChartLayout((string)chartCombos[comboIndex],max);
            rangeList.SelectedIndex = comboIndex;
        }

        private void reloadIndexCombo()
        {
            indexCombo.Items.Clear();
            string item = (string)showNumCombo.SelectedItem;
            int value = int.Parse(item);
            int index = 1;
            for (int i = 0; i < chartDataes.Count; i = i + value)
            {
                indexCombo.Items.Add(index);
                index++;
            }
        }

        private void drawChartLine()
        {
            if (brainChart.Series.Count == 0) return;
            string item1 = (string)showNumCombo.SelectedItem;
            int value = int.Parse(item1);
            int index = (int)indexCombo.SelectedItem;
            Series series = brainChart.Series[0];
            series.Points.Clear();
            int start = (index - 1) * value;
            for (int i = start; i < chartDataes.Count; i++)
            {
                if (i == value * index - 1) break;
                string line = (string)chartDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time,parseTimeForrmat,  System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[comboIndex + 1];
                drawLine(series, time, chartCode);
            }
        }

        private void setChartLayout(string name,int max)
        {
            this.brainChart.Series.Clear();
            Series series = new Series(name);
            series.Font = new System.Drawing.Font("新細明體", 10);
            series.ChartType = SeriesChartType.Line;
            series.Color = getColorWithIndex();
            this.brainChart.Series.Add(series);
            brainChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            brainChart.ChartAreas[0].AxisY.Maximum = max;
            colorIndex++;
        }

        private Color getColorWithIndex()
        {
            if (colorIndex % 5 == 0) return Color.Red;
            else if (colorIndex % 5 == 1) return Color.Blue;
            else if (colorIndex % 5 == 2) return Color.Black;
            else if (colorIndex % 5 == 3) return Color.Purple;
            else return Color.Green;
        }

        public void drawLine(Series series , string time , string data)
        {
            series.Points.AddXY(time, data);
        }

        private void BrainCharts_ResizeEnd(object sender, EventArgs e)
        {
            brainChart.Width = this.Width - 20;
            brainChart.Height = this.Height - 100;
        }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            new OpenFileDialogUtils(fileDialogCallback);
        }

        private void fileDialogCallback(string[] files)
        {
            parseResultFile(files[0]);
        }

        private void showNumCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadIndexCombo();
            indexCombo.SelectedIndex = 0;
        }

        private void indexCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawChartLine();
        }

        private void rangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboIndex = rangeList.SelectedIndex;
            int max = 3000000;
            if (maxRange != null) max = (int)maxRange[comboIndex];
            setChartLayout((string)chartCombos[comboIndex], max);
            drawChartLine();
        }

        private void btnMed_Click(object sender, EventArgs e)
        {
            if (brainChart.Series.Count == 0) return;
            setChartLayout("放鬆度", 100);
            string item1 = (string)showNumCombo.SelectedItem;
            int value = int.Parse(item1);
            int index = (int)indexCombo.SelectedItem;
            Series series = brainChart.Series[0];
            series.Points.Clear();
            int start = (index - 1) * value;
            for (int i = start; i < attDataes.Count; i++)
            {
                if (i == value * index - 1) break;
                string line = (string)attDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy/MM/dd/ HH:mm:ss.fffff", System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[10];
                drawLine(series, time, chartCode);
            }
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            if (brainChart.Series.Count == 0) return;
            setChartLayout("專注度", 100);
            string item1 = (string)showNumCombo.SelectedItem;
            int value = int.Parse(item1);
            int index = (int)indexCombo.SelectedItem;
            Series series = brainChart.Series[0];
            series.Points.Clear();
            int start = (index - 1) * value;
            for (int i = start; i < attDataes.Count; i++)
            {
                if (i == value * index - 1) break;
                string line = (string)attDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy/MM/dd/ HH:mm:ss.fffff", System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[9];
                drawLine(series, time, chartCode);
            }
        }
    }
}
