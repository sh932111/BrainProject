using System;
using System.Windows.Forms;
using System.Linq;

namespace CYFang.Forms
{
    public partial class SelectForm : Form
    {
        private String[] headers;
        private int[] selectNumber;

        private SelectForm()
        {
            InitializeComponent();
        }

        public SelectForm(String[] headers, String[] names)
            : this()
        {
            if (headers != null)
            {
                headers[0] = String.Empty;
                headers[9] = headers[0];


                foreach (String header in headers)
                    if (checkedListBox1.Items.Contains(header) == false &&
                        String.IsNullOrEmpty(header) == false)
                        checkedListBox1.Items.Add(header);
            }

            if (names != null)
                foreach (String header in names)
                    if (checkedListBox1.Items.Contains(header) == false &&
                        String.IsNullOrEmpty(header) == false)
                        checkedListBox1.Items.Add(header);
        }


        protected internal String[] GetHeaders() { return headers; }
        protected internal int[] GetSelect() { return selectNumber; }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int max = checkedListBox1.Items.Count;
            if (max == -1 || max == 0)
                return;

            var headers = (from a in checkedListBox1.Items.Cast<String>()
                           where checkedListBox1.GetItemChecked(checkedListBox1.FindString
                               (a)) == true
                           select a).ToArray();
            var selectNumber = (from a in checkedListBox1.Items.Cast<String>()
                                where checkedListBox1.GetItemChecked(checkedListBox1.FindString
                                    (a)) == true
                                select checkedListBox1.FindString
                                    (a)).ToArray();


            if (headers.Length > 0)
                this.headers = headers;

            if (selectNumber.Length > 0)
                this.selectNumber = selectNumber;

            this.Close();
        }
    }
}
