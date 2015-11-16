namespace Stu.UI
{
    partial class BluetoothList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BluetoothList));
            this.label1 = new System.Windows.Forms.Label();
            this.bluetoothListView = new System.Windows.Forms.ListView();
            this.loaderImage = new System.Windows.Forms.PictureBox();
            this.connectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "連線中的藍芽裝置";
            // 
            // bluetoothListView
            // 
            this.bluetoothListView.Location = new System.Drawing.Point(12, 36);
            this.bluetoothListView.Name = "bluetoothListView";
            this.bluetoothListView.Size = new System.Drawing.Size(277, 117);
            this.bluetoothListView.TabIndex = 1;
            this.bluetoothListView.UseCompatibleStateImageBehavior = false;
            this.bluetoothListView.SelectedIndexChanged += new System.EventHandler(this.bluetoothListView_SelectedIndexChanged);
            // 
            // loaderImage
            // 
            this.loaderImage.Image = ((System.Drawing.Image)(resources.GetObject("loaderImage.Image")));
            this.loaderImage.Location = new System.Drawing.Point(129, 80);
            this.loaderImage.Name = "loaderImage";
            this.loaderImage.Size = new System.Drawing.Size(42, 42);
            this.loaderImage.TabIndex = 2;
            this.loaderImage.TabStop = false;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(214, 159);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "連線";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // BluetoothList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(301, 193);
            this.ControlBox = false;
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.loaderImage);
            this.Controls.Add(this.bluetoothListView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BluetoothList";
            this.Text = "BluetoothList";
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView bluetoothListView;
        private System.Windows.Forms.PictureBox loaderImage;
        private System.Windows.Forms.Button connectBtn;
    }
}