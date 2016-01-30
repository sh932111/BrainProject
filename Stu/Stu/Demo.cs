﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.UI;
using System.Collections;
using Stu.Class;

namespace Stu
{
    public partial class Demo : Form
    {
        private FolderController folder_controller;
        public Demo()
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                if (i == 8 || i == 9)
                {
                    list.Add(100);
                }
                else
                {
                    list.Add(20000000);
                }
            }

            InitializeComponent();
            reloadBlockUI();
            BrainCharts brainCharts = new BrainCharts("", "", list, "yyyy/MM/dd/ HH:mm:ss.fffff");
            brainCharts.Show();
        }

        private void reloadBlockUI()
        {
            BluetoothList bluetooth_list = new BluetoothList(bluetoothCallback, bluetoothOnClickCallback);
            bluetooth_list.Location = new Point(0, 0);
            bluetooth_list.TopLevel = false;
            this.Controls.Add(bluetooth_list);
            bluetooth_list.Show();
            this.folder_controller = new FolderController();
            folder_controller.Location = new Point(300, 0);
            folder_controller.TopLevel = false;
            this.Controls.Add(folder_controller);
            folder_controller.Hide();
        }

        private void bluetoothCallback(ArrayList bluetoothCheckedList)
        {
            folder_controller.Show();
            folder_controller.reloadData(bluetoothCheckedList);
        }
        private void bluetoothOnClickCallback()
        {
            folder_controller.Hide();
        }
    }
}
