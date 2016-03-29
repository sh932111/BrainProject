namespace Stu.UI
{
    partial class BrainChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeList = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnFFT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.runTypeCombo = new System.Windows.Forms.ComboBox();
            this.bigBtn = new System.Windows.Forms.Button();
            this.lastBtn = new System.Windows.Forms.Button();
            this.lastCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboFFT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMax = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "腦波條件";
            // 
            // rangeList
            // 
            this.rangeList.FormattingEnabled = true;
            this.rangeList.Location = new System.Drawing.Point(120, 66);
            this.rangeList.Name = "rangeList";
            this.rangeList.Size = new System.Drawing.Size(121, 21);
            this.rangeList.TabIndex = 11;
            this.rangeList.SelectedIndexChanged += new System.EventHandler(this.rangeList_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(2, 91);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(603, 293);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // btnFFT
            // 
            this.btnFFT.Location = new System.Drawing.Point(217, 9);
            this.btnFFT.Name = "btnFFT";
            this.btnFFT.Size = new System.Drawing.Size(75, 23);
            this.btnFFT.TabIndex = 16;
            this.btnFFT.Text = "FFT頻譜";
            this.btnFFT.UseVisualStyleBackColor = true;
            this.btnFFT.Click += new System.EventHandler(this.btnFFT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "腦波頻段(時間)";
            // 
            // runTypeCombo
            // 
            this.runTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runTypeCombo.FormattingEnabled = true;
            this.runTypeCombo.Items.AddRange(new object[] {
            "腦波標準",
            "自訂條件"});
            this.runTypeCombo.Location = new System.Drawing.Point(8, 65);
            this.runTypeCombo.Name = "runTypeCombo";
            this.runTypeCombo.Size = new System.Drawing.Size(106, 21);
            this.runTypeCombo.TabIndex = 22;
            this.runTypeCombo.SelectedIndexChanged += new System.EventHandler(this.runTypeCombo_SelectedIndexChanged);
            // 
            // bigBtn
            // 
            this.bigBtn.Location = new System.Drawing.Point(518, 390);
            this.bigBtn.Name = "bigBtn";
            this.bigBtn.Size = new System.Drawing.Size(80, 23);
            this.bigBtn.TabIndex = 23;
            this.bigBtn.Text = "另開視窗";
            this.bigBtn.UseVisualStyleBackColor = true;
            this.bigBtn.Click += new System.EventHandler(this.bigBtn_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.Location = new System.Drawing.Point(120, 9);
            this.lastBtn.Name = "lastBtn";
            this.lastBtn.Size = new System.Drawing.Size(75, 23);
            this.lastBtn.TabIndex = 24;
            this.lastBtn.Text = "原始訊號";
            this.lastBtn.UseVisualStyleBackColor = true;
            this.lastBtn.Click += new System.EventHandler(this.lastBtn_Click);
            // 
            // lastCombo
            // 
            this.lastCombo.FormattingEnabled = true;
            this.lastCombo.Items.AddRange(new object[] {
            "Delta",
            "Theta",
            "Low Alpha",
            "High Alpha",
            "Low Beta",
            "High Beta\t",
            "Low Gamma",
            "High Gamma",
            "專注度",
            "放鬆度"});
            this.lastCombo.Location = new System.Drawing.Point(399, 62);
            this.lastCombo.Name = "lastCombo";
            this.lastCombo.Size = new System.Drawing.Size(97, 21);
            this.lastCombo.TabIndex = 25;
            this.lastCombo.SelectedIndexChanged += new System.EventHandler(this.lastCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "原始頻段";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "腦波頻段(頻率)";
            // 
            // comboFFT
            // 
            this.comboFFT.FormattingEnabled = true;
            this.comboFFT.Location = new System.Drawing.Point(261, 65);
            this.comboFFT.Name = "comboFFT";
            this.comboFFT.Size = new System.Drawing.Size(121, 21);
            this.comboFFT.TabIndex = 27;
            this.comboFFT.SelectedIndexChanged += new System.EventHandler(this.comboFFT_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Y MAX";
            // 
            // comboMax
            // 
            this.comboMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMax.FormattingEnabled = true;
            this.comboMax.Items.AddRange(new object[] {
            "100000",
            "120000",
            "140000",
            "160000",
            "180000",
            "200000",
            "300000",
            "500000",
            "1000000"});
            this.comboMax.Location = new System.Drawing.Point(509, 63);
            this.comboMax.Name = "comboMax";
            this.comboMax.Size = new System.Drawing.Size(89, 21);
            this.comboMax.TabIndex = 30;
            this.comboMax.SelectedIndexChanged += new System.EventHandler(this.comboMax_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "腦波資訊";
            // 
            // BrainChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(607, 418);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboFFT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastCombo);
            this.Controls.Add(this.lastBtn);
            this.Controls.Add(this.bigBtn);
            this.Controls.Add(this.runTypeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFFT);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.rangeList);
            this.Controls.Add(this.label1);
            this.Name = "BrainChart";
            this.Text = "BrainChart";
            this.Resize += new System.EventHandler(this.BrainChart_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rangeList;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnFFT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox runTypeCombo;
        private System.Windows.Forms.Button bigBtn;
        private System.Windows.Forms.Button lastBtn;
        private System.Windows.Forms.ComboBox lastCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboFFT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboMax;
        private System.Windows.Forms.Label label9;
    }
}