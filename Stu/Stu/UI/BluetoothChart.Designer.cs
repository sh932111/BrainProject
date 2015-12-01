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
            ((System.ComponentModel.ISupportInitialize)(this.brainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // brainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.brainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.brainChart.Legends.Add(legend1);
            this.brainChart.Location = new System.Drawing.Point(0, 67);
            this.brainChart.Name = "brainChart";
            this.brainChart.Size = new System.Drawing.Size(656, 314);
            this.brainChart.TabIndex = 0;
            this.brainChart.Text = "chart1";
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceName.Location = new System.Drawing.Point(12, 9);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(41, 20);
            this.labelDeviceName.TabIndex = 3;
            this.labelDeviceName.Text = "名字";
            // 
            // labelMac
            // 
            this.labelMac.AutoSize = true;
            this.labelMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMac.Location = new System.Drawing.Point(12, 34);
            this.labelMac.Name = "labelMac";
            this.labelMac.Size = new System.Drawing.Size(44, 20);
            this.labelMac.TabIndex = 4;
            this.labelMac.Text = "MAC";
            // 
            // BrainCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(654, 381);
            this.Controls.Add(this.labelMac);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.brainChart);
            this.Name = "BrainCharts";
            this.Text = "BluetoothChart";
            ((System.ComponentModel.ISupportInitialize)(this.brainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart brainChart;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelMac;
    }
}