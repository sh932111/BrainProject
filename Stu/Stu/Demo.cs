using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.UI;
using System.Collections;

namespace Stu
{
    public partial class Demo : Form
    {
        private FolderController folder_controller;
        public Demo()
        {
            InitializeComponent();
            reloadBlockUI();
        }

        private void reloadBlockUI()
        {
            BluetoothList bluetooth_list = new BluetoothList(bluetoothCallback);
            bluetooth_list.Location = new Point(0, 0);
            bluetooth_list.TopLevel = false;
            this.Controls.Add(bluetooth_list);
            bluetooth_list.Show();
            this.folder_controller = new FolderController();
            folder_controller.Location = new Point(300, 0);
            folder_controller.TopLevel = false;
            this.Controls.Add(folder_controller);
            folder_controller.Show();
            //folder_controller.Hide();
        }

        private void bluetoothCallback(ArrayList bluetoothCheckedList)
        {
            //folder_controller.Show();
            folder_controller.reloadData(bluetoothCheckedList);
        }
    }
}
