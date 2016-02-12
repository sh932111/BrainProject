namespace Stu.UI
{
    partial class BrainCharts
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.brainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelMac = new System.Windows.Forms.Label();
            this.rangeList = new System.Windows.Forms.ComboBox();
            this.fileBtn = new System.Windows.Forms.Button();
            this.showNumCombo = new System.Windows.Forms.ComboBox();
            this.indexCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMed = new System.Windows.Forms.Button();
            this.btnAtt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.brainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // brainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.brainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.brainChart.Legends.Add(legend1);
            this.brainChart.Location = new System.Drawing.Point(2, 60);
            this.brainChart.Name = "brainChart";
            this.brainChart.Size = new System.Drawing.Size(574, 306);
            this.brainChart.TabIndex = 0;
            this.brainChart.Text = "chart1";
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceName.Location = new System.Drawing.Point(535, 0);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(41, 20);
            this.labelDeviceName.TabIndex = 3;
            this.labelDeviceName.Text = "名字";
            this.labelDeviceName.Visible = false;
            // 
            // labelMac
            // 
            this.labelMac.AutoSize = true;
            this.labelMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMac.Location = new System.Drawing.Point(532, 19);
            this.labelMac.Name = "labelMac";
            this.labelMac.Size = new System.Drawing.Size(44, 20);
            this.labelMac.TabIndex = 4;
            this.labelMac.Text = "MAC";
            this.labelMac.Visible = false;
            // 
            // rangeList
            // 
            this.rangeList.FormattingEnabled = true;
            this.rangeList.Location = new System.Drawing.Point(12, 33);
            this.rangeList.Name = "rangeList";
            this.rangeList.Size = new System.Drawing.Size(121, 21);
            this.rangeList.TabIndex = 5;
            this.rangeList.SelectedIndexChanged += new System.EventHandler(this.rangeList_SelectedIndexChanged);
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(501, 34);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(75, 23);
            this.fileBtn.TabIndex = 6;
            this.fileBtn.Text = "選擇檔案";
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Visible = false;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // showNumCombo
            // 
            this.showNumCombo.FormattingEnabled = true;
            this.showNumCombo.Items.AddRange(new object[] {
            "1000",
            "500",
            "200",
            "100",
            "50",
            "30",
            "10"});
            this.showNumCombo.Location = new System.Drawing.Point(445, 8);
            this.showNumCombo.Name = "showNumCombo";
            this.showNumCombo.Size = new System.Drawing.Size(121, 21);
            this.showNumCombo.TabIndex = 7;
            this.showNumCombo.SelectedIndexChanged += new System.EventHandler(this.showNumCombo_SelectedIndexChanged);
            // 
            // indexCombo
            // 
            this.indexCombo.FormattingEnabled = true;
            this.indexCombo.Location = new System.Drawing.Point(445, 33);
            this.indexCombo.Name = "indexCombo";
            this.indexCombo.Size = new System.Drawing.Size(121, 21);
            this.indexCombo.TabIndex = 8;
            this.indexCombo.SelectedIndexChanged += new System.EventHandler(this.indexCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "腦波頻段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "顯示數量:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "顯示頁碼:";
            // 
            // btnMed
            // 
            this.btnMed.Location = new System.Drawing.Point(242, 31);
            this.btnMed.Name = "btnMed";
            this.btnMed.Size = new System.Drawing.Size(75, 23);
            this.btnMed.TabIndex = 12;
            this.btnMed.Text = "放鬆度";
            this.btnMed.UseVisualStyleBackColor = true;
            this.btnMed.Click += new System.EventHandler(this.btnMed_Click);
            // 
            // btnAtt
            // 
            this.btnAtt.Location = new System.Drawing.Point(161, 31);
            this.btnAtt.Name = "btnAtt";
            this.btnAtt.Size = new System.Drawing.Size(75, 23);
            this.btnAtt.TabIndex = 13;
            this.btnAtt.Text = "專注度";
            this.btnAtt.UseVisualStyleBackColor = true;
            this.btnAtt.Click += new System.EventHandler(this.btnAtt_Click);
            // 
            // BrainCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(578, 368);
            this.Controls.Add(this.btnAtt);
            this.Controls.Add(this.btnMed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indexCombo);
            this.Controls.Add(this.showNumCombo);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.rangeList);
            this.Controls.Add(this.labelMac);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.brainChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrainCharts";
            this.Text = "BluetoothChart";
            this.ResizeEnd += new System.EventHandler(this.BrainCharts_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.brainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart brainChart;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelMac;
        private System.Windows.Forms.ComboBox rangeList;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.ComboBox showNumCombo;
        private System.Windows.Forms.ComboBox indexCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMed;
        private System.Windows.Forms.Button btnAtt;
    }
}