using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stu.UI;
using Stu.Utils;

namespace Stu
{
    public partial class TestForm : Form
    {
        private BrainCharts brainCharts;
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (brainCharts == null)
            {
                brainCharts = new BrainCharts("deviceName", "deviceAddress");
                brainCharts.Show();
            }
            //brainCharts.drawLine(getTestData(RangeDefinition.getFirstRange().Count));
        }
        private ArrayList getTestData(int num)
        {
            Random crandom = new Random();
            ArrayList res = new ArrayList();
            for (int i = 0; i < num; i++)
            {
                double d = crandom.Next(1000, 1000000);
                res.Add(d);
            }
            return res;
        }
    }
}
