namespace Stu.UI
{
    partial class ChartDraw
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.bChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.aChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.brainList = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mChart)).BeginInit();
            this.SuspendLayout();
            // 
            // bChart
            // 
            chartArea1.Name = "ChartArea1";
            this.bChart.ChartAreas.Add(chartArea1);
            this.bChart.Location = new System.Drawing.Point(12, 53);
            this.bChart.Name = "bChart";
            this.bChart.Size = new System.Drawing.Size(742, 404);
            this.bChart.TabIndex = 13;
            this.bChart.Text = "chart1";
            // 
            // aChart
            // 
            chartArea2.Name = "ChartArea1";
            this.aChart.ChartAreas.Add(chartArea2);
            this.aChart.Location = new System.Drawing.Point(760, 41);
            this.aChart.Name = "aChart";
            this.aChart.Size = new System.Drawing.Size(331, 191);
            this.aChart.TabIndex = 14;
            this.aChart.Text = "chart2";
            // 
            // mChart
            // 
            chartArea3.Name = "ChartArea1";
            this.mChart.ChartAreas.Add(chartArea3);
            this.mChart.Location = new System.Drawing.Point(760, 266);
            this.mChart.Name = "mChart";
            this.mChart.Size = new System.Drawing.Size(332, 191);
            this.mChart.TabIndex = 15;
            this.mChart.Text = "chart3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "腦波資料：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(756, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Attention：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(756, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Meditation：";
            // 
            // brainList
            // 
            this.brainList.FormattingEnabled = true;
            this.brainList.Items.AddRange(new object[] {
            "Delta",
            "Theta",
            "Low Alpha",
            "High Alpha",
            "Low Beta",
            "High Beta",
            "Low Gamma",
            "High Gamma\" "});
            this.brainList.Location = new System.Drawing.Point(123, 4);
            this.brainList.MultiColumn = true;
            this.brainList.Name = "brainList";
            this.brainList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.brainList.Size = new System.Drawing.Size(627, 49);
            this.brainList.TabIndex = 19;
            // 
            // ChartDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1100, 468);
            this.ControlBox = false;
            this.Controls.Add(this.brainList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mChart);
            this.Controls.Add(this.aChart);
            this.Controls.Add(this.bChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChartDraw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartDraw";
            ((System.ComponentModel.ISupportInitialize)(this.bChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart bChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart aChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart mChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox brainList;
    }
}