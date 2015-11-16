namespace Stu
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseBtn = new System.Windows.Forms.Button();
            this.taskBtn = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListView();
            this.pathBtn = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.runTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseBtn
            // 
            this.chooseBtn.Location = new System.Drawing.Point(12, 12);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(75, 23);
            this.chooseBtn.TabIndex = 0;
            this.chooseBtn.Text = "選擇檔案";
            this.chooseBtn.UseVisualStyleBackColor = true;
            this.chooseBtn.Click += new System.EventHandler(this.chooseBtn_Click);
            // 
            // taskBtn
            // 
            this.taskBtn.Location = new System.Drawing.Point(380, 37);
            this.taskBtn.Name = "taskBtn";
            this.taskBtn.Size = new System.Drawing.Size(96, 23);
            this.taskBtn.TabIndex = 1;
            this.taskBtn.Text = "執行";
            this.taskBtn.UseVisualStyleBackColor = true;
            this.taskBtn.Click += new System.EventHandler(this.taskBtn_Click);
            // 
            // fileList
            // 
            this.fileList.Location = new System.Drawing.Point(12, 66);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(464, 238);
            this.fileList.TabIndex = 2;
            this.fileList.UseCompatibleStateImageBehavior = false;
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(108, 12);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(97, 23);
            this.pathBtn.TabIndex = 3;
            this.pathBtn.Text = "選擇輸出路徑";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(211, 17);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 12);
            this.pathLabel.TabIndex = 4;
            // 
            // runTypeCombo
            // 
            this.runTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runTypeCombo.FormattingEnabled = true;
            this.runTypeCombo.Items.AddRange(new object[] {
            "腦波標準",
            "自訂條件"});
            this.runTypeCombo.Location = new System.Drawing.Point(243, 39);
            this.runTypeCombo.Name = "runTypeCombo";
            this.runTypeCombo.Size = new System.Drawing.Size(121, 20);
            this.runTypeCombo.TabIndex = 5;
            this.runTypeCombo.SelectedIndexChanged += new System.EventHandler(this.runTypeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "執行條件：";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(12, 40);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(96, 21);
            this.connectBtn.TabIndex = 7;
            this.connectBtn.Text = "藍芽測試";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(114, 44);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 19);
            this.timeLabel.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 316);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runTypeCombo);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.pathBtn);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.taskBtn);
            this.Controls.Add(this.chooseBtn);
            this.Name = "Main";
            this.Text = "選擇檔案";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.Button taskBtn;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.ComboBox runTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label timeLabel;
    }
}

