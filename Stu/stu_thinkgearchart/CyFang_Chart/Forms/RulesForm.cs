
using CYFang.Class;
using System;
using System.Windows.Forms;

namespace CYFang.Forms
{
    /// <summary>
    /// 規則頁面
    /// </summary>
    public partial class RulesForm : Form
    {
        /// <summary>
        /// 主表單的變數
        /// </summary>
        private Form1 form;

        private RulesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="form"></param>
        public RulesForm(Form1 form)
            : this()
        {
            this.form = form;

        }

        //公式的重置儲存和刪除輸出項目****************************************************************************************************************************
        /// <summary>
        /// 重置按鈕的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, System.EventArgs e)
        {
            textBoxRules.Text = string.Empty;
            textBoxRuleName.Text = String.Empty;
        }

        /// <summary>
        /// 移除按鈕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBoxRules.SelectedIndex;

                if (index == -1)
                    MessageBox.Show("請選擇要刪除的公式名稱");
                else
                {
                    form.DeleteItem(index + 13);
                    listBoxRules.Items.RemoveAt(index);
                    OutputFile.Config.DeleteRules(OutputFile.Config.GetNames()[index], OutputFile.Config.GetRules()[index]);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("請選擇要刪除的公式名稱");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 儲存按鈕的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxRuleName.Text) == false &&
                String.IsNullOrEmpty(textBoxRules.Text) == false)
            {
                String name = textBoxRuleName.Text;
                String rule = textBoxRules.Text;
                try
                {

                    OutputFile.Config.SaveFile(name, rule);
                    listBoxRules.Items.Add(name);
                    form.AddItem(name);
                    MessageBox.Show("新增成功");
                }
                catch
                {
                    MessageBox.Show("寫入失敗");
                }
            }
            else
                MessageBox.Show("請確認公式名稱或公式有正確輸入");
        }
        //END OFF公式的重置儲存刪除輸出公式***********************************************************************************************************
        /// <summary>
        /// 規則表單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RulesForm_Load(object sender, EventArgs e)
        {
            try
            {
                listBoxRules.Items.Clear();
                listBoxValue.Items.Clear();

                int max = form._Header.Length;
                for (int index = 1; index < max; index++)
                    if (index != 9)
                        listBoxValue.Items.Add(form._Header[index]);
                listBoxRules.Items.AddRange(OutputFile.Config.GetNames());
            }
            catch (NullReferenceException ex)
            {

            }
        }

        /// <summary>
        /// 公式清單連點事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxRules_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = this.listBoxRules.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    textBoxRules.Text = OutputFile.Config.GetRules()[index];
                    textBoxRuleName.Text = OutputFile.Config.GetNames()[index];
                }
            }
            catch (IndexOutOfRangeException ex)
            {

            }
        }


        /// <summary>
        /// 變數清單的點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxValue_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxValue.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                textBoxRules.Text += listBoxValue.Items[index].ToString();
            }
        }

     

    }
}