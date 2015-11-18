using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Stu.UI
{
    public partial class FolderController : Form
    {
        ArrayList readyRunList = null;

        public FolderController()
        {
            InitializeComponent();
            reloadData(new ArrayList());
        }

        public void reloadData(ArrayList ready_list)
        {
            this.readyRunList = ready_list;
            chooseNumLabel.Text = ready_list.Count.ToString();
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {

        }

        private void runBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
