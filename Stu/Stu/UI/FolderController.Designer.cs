namespace Stu.UI
{
    partial class FolderController
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
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.chooseNumLabel = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(4, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(105, 20);
            this.label.TabIndex = 0;
            this.label.Text = "選擇的數量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "輸出資料夾：";
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFolderBtn.Location = new System.Drawing.Point(112, 56);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(65, 23);
            this.chooseFolderBtn.TabIndex = 2;
            this.chooseFolderBtn.Text = "選擇";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.chooseFolderBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(92, 152);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(85, 31);
            this.runBtn.TabIndex = 3;
            this.runBtn.Text = "執行";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // chooseNumLabel
            // 
            this.chooseNumLabel.AutoSize = true;
            this.chooseNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseNumLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.chooseNumLabel.Location = new System.Drawing.Point(115, 19);
            this.chooseNumLabel.Name = "chooseNumLabel";
            this.chooseNumLabel.Size = new System.Drawing.Size(0, 20);
            this.chooseNumLabel.TabIndex = 4;
            // 
            // outputText
            // 
            this.outputText.BackColor = System.Drawing.SystemColors.Info;
            this.outputText.CausesValidation = false;
            this.outputText.Enabled = false;
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.Location = new System.Drawing.Point(5, 94);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(171, 22);
            this.outputText.TabIndex = 5;
            // 
            // FolderController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.chooseNumLabel);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FolderController";
            this.Text = "FolderController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chooseFolderBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Label chooseNumLabel;
        private System.Windows.Forms.TextBox outputText;
    }
}