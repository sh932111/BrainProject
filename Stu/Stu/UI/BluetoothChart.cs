﻿using System;
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
        private ArrayList chartDataes = null;
        private ArrayList chartCombos = null;
        private int comboIndex;
        /*Chart Value*/
        public BrainCharts(string device_name , string device_mac)
        {
            InitializeComponent();
            this.labelDeviceName.Text = device_name;
            this.labelMac.Text = device_mac;
            this.chartCombos = new ArrayList();
            this.chartDataes = new ArrayList();
            this.comboIndex = 0;
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
            setChartLayout((string)chartCombos[comboIndex]);
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
            int start = (index - 1) * value;
            for (int i = start; i < chartDataes.Count; i++)
            {
                if (i == value) break;
                string line = (string)chartDataes[i];
                string[] ReadLine_Array = line.Split(',');
                string time = ReadLine_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy_MM_dd_HH_mm_ss_fffff",  System.Globalization.CultureInfo.InvariantCulture);
                time = myDate.ToString("HH:mm:ss");
                string chartCode = ReadLine_Array[comboIndex + 1];
                drawLine(series, time, chartCode);
            }
        }

        private void setChartLayout(string name)
        {
            this.brainChart.Series.Clear();
            int max = 1000000;
            Series series = new Series(name, max);
            series.Font = new System.Drawing.Font("新細明體", 10);
            series.ChartType = SeriesChartType.Line;
            this.brainChart.Series.Add(series);
            brainChart.ChartAreas[0].AxisX.IsMarginVisible = false;
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
            setChartLayout((string)chartCombos[comboIndex]);
            drawChartLine();
        }
    }
}
