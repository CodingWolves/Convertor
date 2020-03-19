namespace Convertor
{
    partial class Form1
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
            this.Covert = new System.Windows.Forms.GroupBox();
            this.CovertButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SelectFilesButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Covert.SuspendLayout();
            this.SuspendLayout();
            // 
            // Covert
            // 
            this.Covert.Controls.Add(this.textBox2);
            this.Covert.Controls.Add(this.label3);
            this.Covert.Controls.Add(this.SelectFilesButton);
            this.Covert.Controls.Add(this.textBox1);
            this.Covert.Controls.Add(this.CovertButton);
            this.Covert.Location = new System.Drawing.Point(12, 12);
            this.Covert.Name = "Covert";
            this.Covert.Size = new System.Drawing.Size(409, 143);
            this.Covert.TabIndex = 0;
            this.Covert.TabStop = false;
            this.Covert.Text = "BMP to JPG";
            // 
            // CovertButton
            // 
            this.CovertButton.Location = new System.Drawing.Point(6, 76);
            this.CovertButton.Name = "CovertButton";
            this.CovertButton.Size = new System.Drawing.Size(115, 48);
            this.CovertButton.TabIndex = 0;
            this.CovertButton.Text = "Covert";
            this.CovertButton.UseVisualStyleBackColor = true;
            this.CovertButton.Click += new System.EventHandler(this.CovertButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(143, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 26);
            this.textBox1.TabIndex = 5;
            // 
            // SelectFilesButton
            // 
            this.SelectFilesButton.Location = new System.Drawing.Point(358, 32);
            this.SelectFilesButton.Name = "SelectFilesButton";
            this.SelectFilesButton.Size = new System.Drawing.Size(45, 26);
            this.SelectFilesButton.TabIndex = 6;
            this.SelectFilesButton.Text = "...";
            this.SelectFilesButton.UseVisualStyleBackColor = true;
            this.SelectFilesButton.Click += new System.EventHandler(this.SelectFilesButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Folder";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 26);
            this.textBox2.TabIndex = 8;
            this.textBox2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 166);
            this.Controls.Add(this.Covert);
            this.Name = "Form1";
            this.Text = "Covertor";
            this.Covert.ResumeLayout(false);
            this.Covert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Covert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectFilesButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CovertButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

