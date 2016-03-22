using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Stu.Class;
using Stu.Utils;
using System.Diagnostics;

namespace Stu.UI
{
    public partial class BrainChart : Form
    {
        private string outPath = "";
        private ArrayList fDataes = null;
        private ArrayList lDataes = null;
        private ArrayList nDataes = null;
        private ArrayList fftDataes = null;
        private ArrayList lastDataes = null;
        private ArrayList attDataes = null;
        private ArrayList resDataes = null;
        private ArrayList resTitleDataes = null;
        private int colorIndex;
        public BrainChart(string path,Boolean show_csv)
        {
            InitializeComponent();
            this.outPath = path;
            this.colorIndex = 0;
            this.fftDataes = new ArrayList();
            this.attDataes = new ArrayList();
            this.resDataes = new ArrayList();
            this.resTitleDataes = new ArrayList();
            this.lastDataes = new ArrayList();
            parseBrainFile();
            parseFFTFile();
            parseLastFile();
            runTypeCombo.SelectedIndex = 0;
            if (show_csv)
            {
                if (File.Exists(outPath + "/ResultFileAvg.xlsx"))
                {
                    Process.Start(outPath + "/ResultFileAvg.xlsx");
                }
            }
        }

        private void parseLastFile()
        {
            lastDataes.Clear();
            StreamReader fSR = new StreamReader(outPath + "/NoFFT.csv");
            string fLine;
            while ((fLine = fSR.ReadLine()) != null)
            {
                lastDataes.Add(fLine);
            }
            fSR.Close();
        }

        private void parseFFTFile()
        {
            fftDataes.Clear();
            StreamReader fSR = new StreamReader(outPath + "/FFT.csv");
            string fLine;
            while ((fLine = fSR.ReadLine()) != null)
            {
                fftDataes.Add(fLine);
            }
            fSR.Close();
        }

        private void parseResultFile()
        {
            resDataes.Clear();
            resTitleDataes.Clear();
            rangeList.Items.Clear();
            rangeList.Text = "";
            comboFFT.Items.Clear();
            comboFFT.Text = "";
            StreamReader fSR = new StreamReader(outPath + "/ResultFile.csv");
            string fLine;
            int index = 0;
            while ((fLine = fSR.ReadLine()) != null)
            {
                string[] ReadLine_Array = fLine.Split(',');
                if (index == 0)
                {
                    for (int i = 1; i < ReadLine_Array.Length; i++)
                    {
                        rangeList.Items.Add(ReadLine_Array[i]);
                        comboFFT.Items.Add(ReadLine_Array[i]);
                        resTitleDataes.Add(ReadLine_Array[i]);
                    }
                }
                else
                {
                    resDataes.Add(fLine);
                }
                index++;
            }
            fSR.Close();
        }

        private void parseBrainFile()
        {
            attDataes.Clear();
            StreamReader fSR = new StreamReader(outPath + "/Brain.csv");
            string fLine;
            int index = 0;
            while ((fLine = fSR.ReadLine()) != null)
            {
                if (index != 0)
                {
                    attDataes.Add(fLine);
                }
                index++;
            }
            fSR.Close();
        }

        private void lastBtn_Click(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisY.Maximum = 2048;
            chart1.ChartAreas[0].AxisY.Minimum = -2048;
            for (int i = 1; i < lastDataes.Count; i++)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.Stock;
                series.Color = Color.Blue;
                string line = (string)lastDataes[i];
                string[] data_Array = line.Split(',');
                for (int x = 1; x < data_Array.Length; x++)
                {
                    drawLine(series, x - 1 + "", data_Array[x]);
                }
                this.chart1.Series.Add(series);
            }
        }
        private void btnFFT_Click(object sender, EventArgs e)
        {
            string title_line = (string)fftDataes[0];
            string[] title_Array = title_line.Split(',');
            runFFTRange(0, title_Array.Length - 2);
        }

        private void runFFTRange(int startIndex , int endIndex)
        {
            this.chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisY.Maximum = 100000;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            string title_line = (string)fftDataes[0];
            string[] title_Array = title_line.Split(',');
            for (int i = 1; i < fftDataes.Count; i++)
            {
                Series series = new Series();
                series.ChartType = SeriesChartType.FastPoint;
                series.Color = Color.Brown;
                string line = (string)fftDataes[i];
                string[] data_Array = line.Split(',');
                for (int x = 1; x < data_Array.Length; x++)
                {
                    string title = title_Array[x];
                    if (x >= startIndex && x <= endIndex)
                    {
                        drawLine(series, title, data_Array[x]);
                    }
                    else
                    {
                        drawLine(series, title, "0");
                    }
                    if (title.Equals("100")) break;
                }
                this.chart1.Series.Add(series);
            }
        }
        private void setChartLayout(string name, int max)
        {
            this.chart1.Series.Clear();
            Series series = new Series(name);
            series.Font = new System.Drawing.Font("新細明體", 10);
            series.ChartType = SeriesChartType.Line;
            series.Color = getColorWithIndex();
            this.chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
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
        public void drawLine(Series series, string time, string data)
        {
            series.Points.AddXY(time, data);
        }
        private void rangeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = rangeList.SelectedIndex;
            int max = 1200000;
            setChartLayout((string)resTitleDataes[index], max);
            Series series = chart1.Series[0];
            series.Points.Clear();
            for (int i = 0; i < resDataes.Count; i++)
            {
                string line = (string)resDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy/MM/dd/ HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[index + 1];
                drawLine(series, time, chartCode);
            }
        }
        private void runTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = runTypeCombo.SelectedIndex;
            if (index == 0)
            {
                setRange(RangeDefinition.getFirstRange(), RangeDefinition.getLastRange(), RangeDefinition.getNameRange());
                parseResultFile();
            }
            else
            {
                RangeDialog.show(setRange);
                parseResultFile();
            }
        }
        private void setRange(ArrayList fr, ArrayList lr, ArrayList nr)
        {
            this.fDataes = fr;
            this.lDataes = lr;
            this.nDataes = nr;
            WriteFile writeFile = new WriteFile(outPath);
            writeFile.FFTQuery(WriteFile.FFTResultFile, WriteFile.FFT , nr, fr, lr);
            writeFile.FFTQuery(WriteFile.NormResultFile, WriteFile.FFTNorm, nr, fr, lr);
        }

        private void bigBtn_Click(object sender, EventArgs e)
        {
            BrainChart brain_chart = new BrainChart(this.outPath,false);
            brain_chart.Show();
            brain_chart.bigStyle();
        }
        public void bigStyle()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;
            bigBtn.Hide();
            chart1.Width = this.Width - 6;
            chart1.Height = this.Height - 80;
        }

        private void BrainChart_Resize(object sender, EventArgs e)
        {
            chart1.Width = this.Width - 6;
            chart1.Height = this.Height - 80;
        }

        private void lastCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lastCombo.SelectedIndex;
            setChartLayout(getTitle(index), getMax(index));
            Series series = chart1.Series[0];
            series.Points.Clear();
            int avgCode = 8;
            int temp = 0;
            double code = 0;
            for (int i = 0; i < attDataes.Count; i++)
            {
                string line = (string)attDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy/MM/dd/ HH:mm:ss.fffff", System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[index+1];
                code = code + double.Parse(chartCode);
                temp++;
                if (temp == avgCode - 1)
                {
                    double avg = code / avgCode;
                    drawLine(series, time, avg + "");
                    temp = 0;
                    code = 0;
                }
            }
        }
        private string getTitle(int index)
        {
            string[] res = new string[] { "Delta", "Theta", "Low Alpha", "High Alpha", "Low Beta", "High Beta", "Low Gamma", "High Gamma","專注度","放鬆度" };
            return res[index];
        }

        private int getMax(int index)
        {
            if (index == 9 || index == 8)
            {
                return 100;
            }
            else
            {
                return 12000000;
            }
        }

        private void comboFFT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fDataes != null && lDataes != null)
            {
                int index = comboFFT.SelectedIndex;
                double f = double.Parse((string)fDataes[index]);
                double l = double.Parse((string)lDataes[index]);
                string title_line = (string)fftDataes[0];
                string[] title_Array = title_line.Split(',');
                int temp = 0; /*0未找到 1找到f 2找到l*/
                int fpoint = 0;
                int lpoint = 0;
                for (int i = 1; i < title_Array.Length; i++)
                {
                    double code = double.Parse((string)title_Array[i]);
                    if (temp == 0) 
                    {
                        if (code >= f)
                        {
                            temp = 1;
                            fpoint = i;
                        }
                    }
                    else if (temp == 1)
                    {
                        if (code > l)
                        {
                            temp = 2;
                            lpoint = i - 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                runFFTRange(fpoint, lpoint);
            }
        }
    }
}
