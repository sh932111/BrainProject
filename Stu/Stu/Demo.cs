using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.UI;

namespace Stu
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
            reloadBlockUI();
        }

        private void reloadBlockUI()
        {
            BluetoothList bluetooth_list = new BluetoothList();
            bluetooth_list.Location = new Point(0, 0);
            bluetooth_list.TopLevel = false;
            this.Controls.Add(bluetooth_list);
            bluetooth_list.Show();
            FolderController folder_controller = new FolderController();
            folder_controller.Location = new Point(300, 0);
            folder_controller.TopLevel = false;
            this.Controls.Add(folder_controller);
            folder_controller.Show();
        }
    }
}
