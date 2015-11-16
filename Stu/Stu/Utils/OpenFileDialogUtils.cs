using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stu.Utils
{
    public delegate void fileCallback(string[] files);

    class OpenFileDialogUtils
    {
        private fileCallback callback;

        /*OpenFileDialog Initialize*/
        public OpenFileDialogUtils(fileCallback call_back)
        {
            this.callback = call_back;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            //dialog.Filter = "xls files (*.*)|*.xls";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (callback != null)
                    callback(dialog.FileNames);
            }
        }
        /*OpenFileDialog Initialize*/
    }
}
