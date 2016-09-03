using System.Windows.Forms;
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
            this.label7 = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "連線中的藍芽裝置";
            // 
            // bluetoothListView
            // 
            this.bluetoothListView.CheckBoxes = true;
            this.bluetoothListView.Location = new System.Drawing.Point(12, 72);
            this.bluetoothListView.Name = "bluetoothListView";
            this.bluetoothListView.Size = new System.Drawing.Size(620, 142);
            this.bluetoothListView.TabIndex = 1;
            this.bluetoothListView.UseCompatibleStateImageBehavior = false;
            // 
            // loaderImage
            // 
            this.loaderImage.Image = ((System.Drawing.Image)(resources.GetObject("loaderImage.Image")));
            this.loaderImage.Location = new System.Drawing.Point(301, 121);
            this.loaderImage.Name = "loaderImage";
            this.loaderImage.Size = new System.Drawing.Size(42, 42);
            this.loaderImage.TabIndex = 2;
            this.loaderImage.TabStop = false;
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.LemonChiffon;
            this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Location = new System.Drawing.Point(533, 223);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(99, 33);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "下一步";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Device";
            // 
            // outputText
            // 
            this.outputText.BackColor = System.Drawing.Color.Snow;
            this.outputText.CausesValidation = false;
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.ForeColor = System.Drawing.Color.DarkRed;
            this.outputText.Location = new System.Drawing.Point(137, 226);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(390, 28);
            this.outputText.TabIndex = 20;
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFolderBtn.Location = new System.Drawing.Point(11, 223);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(120, 33);
            this.chooseFolderBtn.TabIndex = 19;
            this.chooseFolderBtn.Text = "輸出資料夾";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.chooseFolderBtn_Click);
            // 
            // BluetoothList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(644, 266);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.loaderImage);
            this.Controls.Add(this.bluetoothListView);
            this.Controls.Add(this.label1);
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
        private Label label7;
        private TextBox outputText;
        private Button chooseFolderBtn;
    }
}