using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.Utils;
using System.Collections;

namespace Stu
{
    public delegate void rangeDialogCallback(ArrayList farraylist ,ArrayList larraylist);

    public partial class RangeDialog : Form
    {
        static RangeDialog dialog;
        static DialogResult result = DialogResult.No;
        private rangeDialogCallback callback;

        RangeListUtils rangeListUtils = null;

        public RangeDialog(rangeDialogCallback _callback)
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this.callback = _callback;

            setListView();
        }
        
        /*Dialog show*/
        public static DialogResult show(rangeDialogCallback _callback) 
        {
            dialog = new RangeDialog(_callback);

            dialog.ShowDialog();
            
            return result;
        }
        /*Dialog show*/

        private void setListView()
        {
            this.rangeListUtils = new RangeListUtils(rangeList);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            String fr = fRangeInput.Text;

            String lr = lRangeInput.Text;

            if (fr.Length > 0 && lr.Length > 0)
            {
                rangeListUtils.addRangeItem(fr, lr);

                fRangeInput.Text = "";

                lRangeInput.Text = "";
            }
            else
            {
                MessageBox.Show("有參數尚未輸入!");
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (rangeListUtils.getfRangeList().Count > 0 && rangeListUtils.getlRangeList().Count > 0)
            {

                result = DialogResult.Yes;

                if (callback != null)
                    callback(rangeListUtils.getfRangeList(), rangeListUtils.getlRangeList());

                dialog.Close();
            }
            else 
            {
                MessageBox.Show("至少需要一筆判斷值!");
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                // Assume that X has been clicked and act accordingly.
                // Confirm user wants to close
                if (callback != null)
                    callback(null, null);
            }
        }
    }
}
