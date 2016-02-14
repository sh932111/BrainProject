using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stu.UI
{
    public partial class ShowExDialog : Form
    {
        static DialogResult result = DialogResult.No;
        static ShowExDialog dialog;
        public ShowExDialog(string title, Bitmap img)
        {
            InitializeComponent();
            titlelabel.Text = title;
            showPicture.Image = img;//Properties.Resources.memory;
        }
        /*Dialog show*/
        public static DialogResult show(string title, Bitmap img)
        {
            dialog = new ShowExDialog(title , img);

            dialog.ShowDialog();

            return result;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
             dialog.Close();
        }
        /*Dialog show*/

    }
}
