namespace Stu
{
    partial class RangeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fRangeInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lRangeInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.rangeList = new System.Windows.Forms.ListView();
            this.runBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fRangeInput
            // 
            this.fRangeInput.Location = new System.Drawing.Point(57, 3);
            this.fRangeInput.Name = "fRangeInput";
            this.fRangeInput.Size = new System.Drawing.Size(100, 22);
            this.fRangeInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "範圍：";
            // 
            // lRangeInput
            // 
            this.lRangeInput.Location = new System.Drawing.Point(180, 3);
            this.lRangeInput.Name = "lRangeInput";
            this.lRangeInput.Size = new System.Drawing.Size(100, 22);
            this.lRangeInput.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "~";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(297, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "加入";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // rangeList
            // 
            this.rangeList.Location = new System.Drawing.Point(12, 31);
            this.rangeList.Name = "rangeList";
            this.rangeList.Size = new System.Drawing.Size(360, 159);
            this.rangeList.TabIndex = 5;
            this.rangeList.UseCompatibleStateImageBehavior = false;
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(378, 167);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 6;
            this.runBtn.Text = "執行";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // RangeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 202);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.rangeList);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lRangeInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fRangeInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RangeDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RangeDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fRangeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lRangeInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ListView rangeList;
        private System.Windows.Forms.Button runBtn;
    }
}