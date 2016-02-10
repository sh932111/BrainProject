namespace Stu.UI
{
    partial class DoTest
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
            this.finishBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // finishBtn
            // 
            this.finishBtn.BackColor = System.Drawing.Color.IndianRed;
            this.finishBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishBtn.ForeColor = System.Drawing.Color.White;
            this.finishBtn.Location = new System.Drawing.Point(12, 6);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(1160, 50);
            this.finishBtn.TabIndex = 15;
            this.finishBtn.Text = "確認交卷!結算成績";
            this.finishBtn.UseVisualStyleBackColor = false;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // DoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 62);
            this.ControlBox = false;
            this.Controls.Add(this.finishBtn);
            this.Name = "DoTest";
            this.Text = "單字測驗";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finishBtn;
    }
}