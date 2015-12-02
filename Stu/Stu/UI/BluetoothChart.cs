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

namespace Stu.UI
{
    public partial class BrainCharts : Form
    {
        private ArrayList chartCollection = null;
        public BrainCharts(string device_name , string device_mac)
        {
            InitializeComponent();
            this.labelDeviceName.Text = device_name;
            this.labelMac.Text = device_mac;
            chartCollection = new ArrayList();
        }

        public void setChartLine(ArrayList chart_fnames, ArrayList chart_lnames)
        {
            int max = 1000000;
            for (int i = 0; i < chart_fnames.Count; i++)
            {
                string fn = (string)chart_fnames[i];
                string ln = (string)chart_lnames[i];
                string name = fn + "~" + ln;
                Series series = new Series(name, max);
                series.Font = new System.Drawing.Font("新細明體", 10);
                series.ChartType = SeriesChartType.Line;
                this.brainChart.Series.Add(series);
                chartCollection.Add(series);
            }
            brainChart.ChartAreas[0].AxisX.IsMarginVisible = false;
        }

        public void drawLine(ArrayList chartSource)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            for (int i = 0; i < chartSource.Count; i++)
            {
                double data = (double)chartSource[i];
                Series series = (Series)chartCollection[i];
                series.Points.AddXY(time, data);
            }
        }

        private void BrainCharts_ResizeEnd(object sender, EventArgs e)
        {
            brainChart.Width = this.Width - 20;
            brainChart.Height = this.Height - 100;
        }
    }
}
