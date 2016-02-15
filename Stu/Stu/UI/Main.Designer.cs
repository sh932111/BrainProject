namespace Stu.UI
{
    partial class Main
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textUserYearOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textWordNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTestTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.runTypeCombo = new System.Windows.Forms.ComboBox();
            this.labelNorm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.exBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(397, 252);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(257, 28);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "開始測試";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "姓名:";
            // 
            // textUserName
            // 
            this.textUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserName.Location = new System.Drawing.Point(123, 40);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(201, 29);
            this.textUserName.TabIndex = 3;
            // 
            // textUserYearOld
            // 
            this.textUserYearOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserYearOld.Location = new System.Drawing.Point(123, 74);
            this.textUserYearOld.Name = "textUserYearOld";
            this.textUserYearOld.Size = new System.Drawing.Size(201, 29);
            this.textUserYearOld.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "年紀:";
            // 
            // textWordNum
            // 
            this.textWordNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWordNum.Location = new System.Drawing.Point(123, 108);
            this.textWordNum.Name = "textWordNum";
            this.textWordNum.Size = new System.Drawing.Size(201, 29);
            this.textWordNum.TabIndex = 9;
            this.textWordNum.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "單字數:";
            // 
            // textTestTime
            // 
            this.textTestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTestTime.Location = new System.Drawing.Point(123, 141);
            this.textTestTime.Name = "textTestTime";
            this.textTestTime.Size = new System.Drawing.Size(166, 29);
            this.textTestTime.TabIndex = 11;
            this.textTestTime.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "測試時間:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "測驗設定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(295, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "秒";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(342, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "Device";
            // 
            // outputText
            // 
            this.outputText.BackColor = System.Drawing.Color.Snow;
            this.outputText.CausesValidation = false;
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.ForeColor = System.Drawing.Color.DarkRed;
            this.outputText.Location = new System.Drawing.Point(159, 215);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(492, 26);
            this.outputText.TabIndex = 18;
            this.outputText.Text = "路徑：";
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFolderBtn.Location = new System.Drawing.Point(12, 213);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(141, 30);
            this.chooseFolderBtn.TabIndex = 17;
            this.chooseFolderBtn.Text = "選擇輸出的資料夾";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.chooseFolderBtn_Click);
            // 
            // runTypeCombo
            // 
            this.runTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runTypeCombo.FormattingEnabled = true;
            this.runTypeCombo.Items.AddRange(new object[] {
            "腦波標準",
            "自訂條件"});
            this.runTypeCombo.Location = new System.Drawing.Point(123, 181);
            this.runTypeCombo.Name = "runTypeCombo";
            this.runTypeCombo.Size = new System.Drawing.Size(201, 20);
            this.runTypeCombo.TabIndex = 21;
            this.runTypeCombo.SelectedIndexChanged += new System.EventHandler(this.runTypeCombo_SelectedIndexChanged);
            // 
            // labelNorm
            // 
            this.labelNorm.AutoSize = true;
            this.labelNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNorm.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelNorm.Location = new System.Drawing.Point(96, 183);
            this.labelNorm.Name = "labelNorm";
            this.labelNorm.Size = new System.Drawing.Size(0, 16);
            this.labelNorm.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "腦波條件：";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Snow;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CausesValidation = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Maroon;
            this.textBox1.Location = new System.Drawing.Point(17, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(374, 82);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "說明：依序設定測試者的資料及腦波的相關設定，選擇裝置後即可開始測試，歷史紀錄則可以觀看受試者的資訊";
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(397, 314);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(257, 28);
            this.resetBtn.TabIndex = 25;
            this.resetBtn.Text = "重置資料";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // historyBtn
            // 
            this.historyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyBtn.Location = new System.Drawing.Point(397, 283);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(257, 28);
            this.historyBtn.TabIndex = 26;
            this.historyBtn.Text = "歷史紀錄";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // exBtn
            // 
            this.exBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exBtn.Location = new System.Drawing.Point(235, 312);
            this.exBtn.Name = "exBtn";
            this.exBtn.Size = new System.Drawing.Size(121, 28);
            this.exBtn.TabIndex = 27;
            this.exBtn.Text = "詳細說明";
            this.exBtn.UseVisualStyleBackColor = true;
            this.exBtn.Click += new System.EventHandler(this.exBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(666, 349);
            this.Controls.Add(this.exBtn);
            this.Controls.Add(this.historyBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.runTypeCombo);
            this.Controls.Add(this.labelNorm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTestTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textWordNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textUserYearOld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "腦波專注力數位學習系統";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textUserYearOld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textWordNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTestTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button chooseFolderBtn;
        private System.Windows.Forms.ComboBox runTypeCombo;
        private System.Windows.Forms.Label labelNorm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Button exBtn;
    }
}