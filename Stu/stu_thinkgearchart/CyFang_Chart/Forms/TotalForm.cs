
using System;
using System.Text;
using System.Windows.Forms;

namespace CYFang.Forms
{
    public partial class TotalForm : Form
    {
        private TotalForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="list">使用者選擇的選項</param>
        /// <param name="avgArray">所有的平均陣列</param>
        /// <param name="lables">目前的標籤</param>
        /// <param name="count">總共執行時間</param>
        public TotalForm(int[] list, double[] avgArray, String[] lables, int count)
            : this()
        {
            int listLength = list.Length;

            double[] selectNumber = new double[listLength];
            String[] selectLabel = new String[listLength];

            for (int index = 0; index < listLength; index++)
            {
                selectNumber[index] = avgArray[list[index]];
                selectLabel[index] = lables[list[index]];
            }

            StringBuilder sb = new StringBuilder();
            int max = listLength;
            for (int index = 0; index < max; index++)
                sb.Append(String.Format("{0}\t\t{1}{2}", selectLabel[index],
                    selectNumber[index] / count, Environment.NewLine));

            sb.Append(String.Format("Total secend:{0}", count));
            textBox1.Text = sb.ToString();
            textBox1.ReadOnly = true;
        }

    }
}
