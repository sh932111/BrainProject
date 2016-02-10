namespace Stu.UI
{
    partial class Choose
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
            this.chooseFinishBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseFinishBtn
            // 
            this.chooseFinishBtn.BackColor = System.Drawing.Color.IndianRed;
            this.chooseFinishBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFinishBtn.ForeColor = System.Drawing.Color.White;
            this.chooseFinishBtn.Location = new System.Drawing.Point(12, 6);
            this.chooseFinishBtn.Name = "chooseFinishBtn";
            this.chooseFinishBtn.Size = new System.Drawing.Size(1160, 50);
            this.chooseFinishBtn.TabIndex = 0;
            this.chooseFinishBtn.Text = "選擇完成，開始背單字!";
            this.chooseFinishBtn.UseVisualStyleBackColor = false;
            this.chooseFinishBtn.Click += new System.EventHandler(this.chooseFinishBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(429, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "此為可移動視窗，如視線擋住可拖拉移動!";
            // 
            // Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 92);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseFinishBtn);
            this.Name = "Choose";
            this.Text = "選擇單字";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFinishBtn;
        private System.Windows.Forms.Label label1;
    }
}