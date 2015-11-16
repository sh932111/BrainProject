using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stu.Class;

namespace Stu
{
    public partial class Computer : Form
    {
        public Computer()
        {
            InitializeComponent();
        }

        private void run_Click(object sender, EventArgs e)
        {
            String get = input.Text;
            String result = Calculate.run16ToString(get);
            output.Text = result;
        }

        private int runLoop(int value)
        {
            if (value > 0) return runLoop(value - 1) * 16;
            else return 1;
        }

        private String changeCode(String str)
        {
            if (str.Equals("A")) return "10";
            else if (str.Equals("B")) return "11";
            else if (str.Equals("C")) return "12";
            else if (str.Equals("D")) return "13";
            else if (str.Equals("E")) return "14";
            else if (str.Equals("F")) return "15";
            else return str;
        }
    }
}
