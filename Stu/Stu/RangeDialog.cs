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
    public delegate void rangeDialogCallback(ArrayList farraylist ,ArrayList larraylist , ArrayList nameList);

    public partial class RangeDialog : Form
    {
        static RangeDialog dialog;
        static DialogResult result = DialogResult.No;
        private rangeDialogCallback callback;

        RangeListUtils rangeListUtils = null;

        public RangeDialog(rangeDialogCallback _callback)
        {
            InitializeComponent();
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

            String nr = textName.Text;

            if (fr.Length > 0 && lr.Length > 0 && nr.Length > 0)
            {
                rangeListUtils.addRangeItem(fr, lr ,nr);

                fRangeInput.Text = "";

                lRangeInput.Text = "";

                textName.Text = "";
            }
            else
            {
                MessageBox.Show("有參數尚未輸入!");
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (rangeListUtils.getfRangeList().Count > 0 && rangeListUtils.getlRangeList().Count > 0 && rangeListUtils.getnRangeList().Count > 0)
            {

                result = DialogResult.Yes;

                if (callback != null)
                    callback(rangeListUtils.getfRangeList(), rangeListUtils.getlRangeList(),rangeListUtils.getnRangeList());

                dialog.Close();
            }
            else 
            {
                MessageBox.Show("至少需要一筆判斷值!");
            }
        }
    }
}
