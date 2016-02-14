namespace Stu.UI
{
    partial class ShowExDialog
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
            this.nextBtn = new System.Windows.Forms.Button();
            this.titlelabel = new System.Windows.Forms.Label();
            this.showPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.Maroon;
            this.nextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Location = new System.Drawing.Point(17, 505);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(844, 40);
            this.nextBtn.TabIndex = 0;
            this.nextBtn.Text = "我了解了!準備下一步";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelabel.Location = new System.Drawing.Point(12, 9);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(0, 25);
            this.titlelabel.TabIndex = 2;
            // 
            // showPicture
            // 
            this.showPicture.Location = new System.Drawing.Point(12, 37);
            this.showPicture.Name = "showPicture";
            this.showPicture.Size = new System.Drawing.Size(844, 462);
            this.showPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showPicture.TabIndex = 1;
            this.showPicture.TabStop = false;
            // 
            // ShowExDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 543);
            this.ControlBox = false;
            this.Controls.Add(this.titlelabel);
            this.Controls.Add(this.showPicture);
            this.Controls.Add(this.nextBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShowExDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "說明";
            ((System.ComponentModel.ISupportInitialize)(this.showPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.PictureBox showPicture;
        private System.Windows.Forms.Label titlelabel;
    }
}