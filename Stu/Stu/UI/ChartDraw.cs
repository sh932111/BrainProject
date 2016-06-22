using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stu.UI
{
    public partial class ChartDraw : Form
    {
        private string outPath = "";
        private ArrayList brainDataes = null;
        public ChartDraw(string path)
        {
            InitializeComponent();
            for (int i = 0; i < brainList.Items.Count; i++)
            {
                if (!bool.Parse(brainList.GetItemChecked(i).ToString()))
                {
                    brainList.SetItemChecked(i, true);
                }
            }
            this.outPath = path;
            this.brainDataes = new ArrayList();
        }

        public void parseBrainFile()
        {
            this.brainDataes.Clear();
            if (File.Exists(outPath + "/Brain.csv"))
            {
                StreamReader fSR = new StreamReader(outPath + "/Brain.csv");
                string fLine;
                int index = 0;
                while ((fLine = fSR.ReadLine()) != null)
                {
                    if (index != 0)
                    {
                        this.brainDataes.Add(fLine);
                    }
                    index++;
                }
                fSR.Close();
            }
        }

        public void setList(ArrayList brainList)
        {
            this.brainDataes.Clear();
            foreach (ArrayList brainItem in brainList)
            {
                string str = "";
                foreach (String item in brainItem)
                {
                    if (str.Length == 0) 
                    {
                        str = item;
                    }
                    else
                    {
                        str = str + "," + item;
                    }
                }
                this.brainDataes.Add(str);
            }
        }

        private string[] getBrainStrList() 
        {
            List<string> result = new List<string>();
            for (int i = 0; i < brainList.Items.Count; i++)
            {
                if (bool.Parse(brainList.GetItemChecked(i).ToString()))
                {
                    string item = brainList.GetItemText(brainList.Items[i]);
                    result.Add(item);
                }
            }
            string[] brainTitle = new string[result.Count]; 
            for (int i = 0; i < result.Count; i++)
            {
                brainTitle[i] = result[i];
            }
            return brainTitle;
        }

        public void showChart()
        {
           string[] brainTitle = getBrainStrList();
           string[] attTitle =  { "Attention" };
           string[] medTitle = { "Meditation" };
           setChartLayout(20000000, this.bChart, brainTitle);
           setChartLayout(100, this.aChart, attTitle);
           setChartLayout(100, this.mChart, medTitle);
            for (int i = 0; i < brainDataes.Count; i++)
            {
                string line = (string)brainDataes[i];
                string[] data_Array = line.Split(',');
                string time = data_Array[0];
                DateTime myDate = DateTime.ParseExact(time, "yyyy/MM/dd/ HH:mm:ss.fffff", System.Globalization.CultureInfo.InvariantCulture);
                for (int x = 1; x < data_Array.Length; x++)
                {
                    string data = data_Array[x];
                    if (x == 9)
                    {
                        Series series = this.aChart.Series[0];
                        drawLine(series, time, data);
                    }
                    else if (x == 10)
                    {
                        Series series = this.mChart.Series[0];
                        drawLine(series, time, data);
                    }
                    else
                    {
                        if (x >  brainTitle.Length) 
                            continue;
                        int index = x - 1;
                        Series series = this.bChart.Series[index];
                        drawLine(series, time, data);
                    }
                }
            }
        }

        private void setChartLayout( int max, Chart chart1 , string[] seriesNames )
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Maximum = max;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            for (int x = 0; x < seriesNames.Length; x++)
            {
                string name = seriesNames[x];
                Series series = new Series(name);
                series.Font = new System.Drawing.Font("新細明體", 10);
                Legend legend = new Legend(name);
                legend.Docking = Docking.Bottom; //自訂顯示位置
                series.ChartType = SeriesChartType.Line;
                series.IsVisibleInLegend = true;
                chart1.Series.Add(series);
                chart1.Legends.Add(legend);
            }   
        }

        public void drawLine(Series series, string time, string data)
        {
            series.Points.AddXY(time, data);
        }
    }
}
