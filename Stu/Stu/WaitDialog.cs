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
    public partial class WaitDialog : Form
    {
        static DialogResult result = DialogResult.No;
        static WaitDialog dialog;
        public WaitDialog()
        {
            InitializeComponent();
            loaderImage.Show();
        }
         /*Dialog show*/
        public static DialogResult show() 
        {
            dialog = new WaitDialog();

            dialog.ShowDialog();
            
            return result;
        }
        /*Dialog show*/
        public static void close() 
        {
            dialog.Close();
        }
    }
}
