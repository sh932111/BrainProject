using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Stu.Utils;
using Stu.Manager;
using Stu.Class;

namespace Stu.UI
{
    public partial class FolderController : Form
    {
        private ArrayList readyRunList = null;
        private string outPath = "";
        public FolderController()
        {
            InitializeComponent();
        }

        public void reloadData(ArrayList ready_list)
        {
            this.readyRunList = ready_list;
            chooseNumLabel.Text = ready_list.Count.ToString();
        }

        private void chooseFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            outputText.Text = path.SelectedPath;
            this.outPath = path.SelectedPath;
        }
        
        private void runBtn_Click(object sender, EventArgs e)
        {
            if (outPath.Length > 0)
            {
                if (readyRunList.Count > 0)
                {
                    string now = DateTime.Now.ToString("MMddyyyyHHmmss");
                    FloderUtils folder = new FloderUtils(outPath);
                    folder.createRoot();
                    for (int i = 0; i < readyRunList.Count; i++)
                    {
                        BluetoothDeviceManager manager = (BluetoothDeviceManager)readyRunList[i];
                        string path = folder.createDeviceFolder(manager.getDeviceAddress(),now);
                        BrainWorker worker = new BrainWorker(path, manager);
                        worker.StartPosition = FormStartPosition.Manual;
                        worker.Location = new Point(i / 5 * 300, i % 5 * 150);
                        worker.Show();
                    }
                }
                else
                {
                    MessageBox.Show("尚未選擇腦波裝置!");
                }
            }
            else
            {
                MessageBox.Show("請選擇輸出的資料夾!");
            }
        }
    }
}
