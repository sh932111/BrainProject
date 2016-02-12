namespace Stu.UI
{
    partial class OrderList
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
            this.bluetoothListView = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bluetoothListView
            // 
            this.bluetoothListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bluetoothListView.Location = new System.Drawing.Point(12, 41);
            this.bluetoothListView.Name = "bluetoothListView";
            this.bluetoothListView.Size = new System.Drawing.Size(463, 214);
            this.bluetoothListView.TabIndex = 30;
            this.bluetoothListView.UseCompatibleStateImageBehavior = false;
            this.bluetoothListView.SelectedIndexChanged += new System.EventHandler(this.bluetoothListView_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "查詢受試者資訊";
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(488, 262);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bluetoothListView);
            this.Name = "OrderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "歷史紀錄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView bluetoothListView;
        private System.Windows.Forms.Label label8;
    }
}