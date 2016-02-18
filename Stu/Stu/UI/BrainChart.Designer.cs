﻿namespace Stu.UI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.label1 = new System.Windows.Forms.Label();
            this.rangeList = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAtt = new System.Windows.Forms.Button();
            this.btnMed = new System.Windows.Forms.Button();
            this.btnFFT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.runTypeCombo = new System.Windows.Forms.ComboBox();
            this.bigBtn = new System.Windows.Forms.Button();
            this.lastBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "腦波條件";
            // 
            // rangeList
            // 
            this.rangeList.FormattingEnabled = true;
            this.rangeList.Location = new System.Drawing.Point(165, 32);
            this.rangeList.Name = "rangeList";
            this.rangeList.Size = new System.Drawing.Size(121, 21);
            this.rangeList.TabIndex = 11;
            this.rangeList.SelectedIndexChanged += new System.EventHandler(this.rangeList_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(2, 59);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(574, 293);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // btnAtt
            // 
            this.btnAtt.Location = new System.Drawing.Point(491, 1);
            this.btnAtt.Name = "btnAtt";
            this.btnAtt.Size = new System.Drawing.Size(75, 23);
            this.btnAtt.TabIndex = 15;
            this.btnAtt.Text = "專注度";
            this.btnAtt.UseVisualStyleBackColor = true;
            this.btnAtt.Click += new System.EventHandler(this.btnAtt_Click);
            // 
            // btnMed
            // 
            this.btnMed.Location = new System.Drawing.Point(491, 30);
            this.btnMed.Name = "btnMed";
            this.btnMed.Size = new System.Drawing.Size(75, 23);
            this.btnMed.TabIndex = 14;
            this.btnMed.Text = "放鬆度";
            this.btnMed.UseVisualStyleBackColor = true;
            this.btnMed.Click += new System.EventHandler(this.btnMed_Click);
            // 
            // btnFFT
            // 
            this.btnFFT.Location = new System.Drawing.Point(401, 30);
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
            this.label2.Location = new System.Drawing.Point(161, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "腦波頻段";
            // 
            // runTypeCombo
            // 
            this.runTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runTypeCombo.FormattingEnabled = true;
            this.runTypeCombo.Items.AddRange(new object[] {
            "腦波標準",
            "自訂條件"});
            this.runTypeCombo.Location = new System.Drawing.Point(16, 32);
            this.runTypeCombo.Name = "runTypeCombo";
            this.runTypeCombo.Size = new System.Drawing.Size(123, 21);
            this.runTypeCombo.TabIndex = 22;
            this.runTypeCombo.SelectedIndexChanged += new System.EventHandler(this.runTypeCombo_SelectedIndexChanged);
            // 
            // bigBtn
            // 
            this.bigBtn.Location = new System.Drawing.Point(522, 355);
            this.bigBtn.Name = "bigBtn";
            this.bigBtn.Size = new System.Drawing.Size(52, 23);
            this.bigBtn.TabIndex = 23;
            this.bigBtn.Text = "放大";
            this.bigBtn.UseVisualStyleBackColor = true;
            this.bigBtn.Click += new System.EventHandler(this.bigBtn_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.Location = new System.Drawing.Point(401, 1);
            this.lastBtn.Name = "lastBtn";
            this.lastBtn.Size = new System.Drawing.Size(75, 23);
            this.lastBtn.TabIndex = 24;
            this.lastBtn.Text = "原始訊號";
            this.lastBtn.UseVisualStyleBackColor = true;
            this.lastBtn.Click += new System.EventHandler(this.lastBtn_Click);
            // 
            // BrainChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(578, 383);
            this.Controls.Add(this.lastBtn);
            this.Controls.Add(this.bigBtn);
            this.Controls.Add(this.runTypeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFFT);
            this.Controls.Add(this.btnAtt);
            this.Controls.Add(this.btnMed);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.rangeList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnAtt;
        private System.Windows.Forms.Button btnMed;
        private System.Windows.Forms.Button btnFFT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox runTypeCombo;
        private System.Windows.Forms.Button bigBtn;
        private System.Windows.Forms.Button lastBtn;
    }
}