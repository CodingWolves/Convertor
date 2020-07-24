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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConvertPanel = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FromExtensionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToFormatComboBox = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SaveRadioConvertedFolder = new System.Windows.Forms.RadioButton();
            this.SaveRadioSameFolder = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenButton = new System.Windows.Forms.Button();
            this.SelectFilesButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CovertButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ConvertPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertPanel
            // 
            this.ConvertPanel.Controls.Add(this.statusLabel);
            this.ConvertPanel.Controls.Add(this.label2);
            this.ConvertPanel.Controls.Add(this.FromExtensionComboBox);
            this.ConvertPanel.Controls.Add(this.label1);
            this.ConvertPanel.Controls.Add(this.ToFormatComboBox);
            this.ConvertPanel.Controls.Add(this.progressBar);
            this.ConvertPanel.Controls.Add(this.SaveRadioConvertedFolder);
            this.ConvertPanel.Controls.Add(this.SaveRadioSameFolder);
            this.ConvertPanel.Controls.Add(this.label3);
            this.ConvertPanel.Controls.Add(this.OpenButton);
            this.ConvertPanel.Controls.Add(this.SelectFilesButton);
            this.ConvertPanel.Controls.Add(this.textBox1);
            this.ConvertPanel.Controls.Add(this.CovertButton);
            this.ConvertPanel.Location = new System.Drawing.Point(8, 8);
            this.ConvertPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConvertPanel.Name = "ConvertPanel";
            this.ConvertPanel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConvertPanel.Size = new System.Drawing.Size(397, 176);
            this.ConvertPanel.TabIndex = 0;
            this.ConvertPanel.TabStop = false;
            this.ConvertPanel.Text = "Conversion Panel";
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(274, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 23);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "From Extension";
            // 
            // FromExtensionComboBox
            // 
            this.FromExtensionComboBox.FormattingEnabled = true;
            this.FromExtensionComboBox.Items.AddRange(new object[] {
            "Jpeg",
            "Jpg",
            "Bmp",
            "Gif",
            "Tiff",
            "Icon",
            "Png"});
            this.FromExtensionComboBox.Location = new System.Drawing.Point(45, 76);
            this.FromExtensionComboBox.Name = "FromExtensionComboBox";
            this.FromExtensionComboBox.Size = new System.Drawing.Size(121, 21);
            this.FromExtensionComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "To Image Format";
            // 
            // ToFormatComboBox
            // 
            this.ToFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToFormatComboBox.FormattingEnabled = true;
            this.ToFormatComboBox.Items.AddRange(new object[] {
            "Jpeg",
            "Bmp",
            "Gif",
            "Tiff",
            "Icon",
            "Png"});
            this.ToFormatComboBox.Location = new System.Drawing.Point(230, 76);
            this.ToFormatComboBox.Name = "ToFormatComboBox";
            this.ToFormatComboBox.Size = new System.Drawing.Size(121, 21);
            this.ToFormatComboBox.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(274, 147);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(118, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // SaveRadioConvertedFolder
            // 
            this.SaveRadioConvertedFolder.AutoSize = true;
            this.SaveRadioConvertedFolder.Checked = true;
            this.SaveRadioConvertedFolder.Location = new System.Drawing.Point(102, 153);
            this.SaveRadioConvertedFolder.Name = "SaveRadioConvertedFolder";
            this.SaveRadioConvertedFolder.Size = new System.Drawing.Size(142, 17);
            this.SaveRadioConvertedFolder.TabIndex = 9;
            this.SaveRadioConvertedFolder.TabStop = true;
            this.SaveRadioConvertedFolder.Text = "Save to converted folder";
            this.SaveRadioConvertedFolder.UseVisualStyleBackColor = true;
            // 
            // SaveRadioSameFolder
            // 
            this.SaveRadioSameFolder.AutoSize = true;
            this.SaveRadioSameFolder.Location = new System.Drawing.Point(102, 130);
            this.SaveRadioSameFolder.Name = "SaveRadioSameFolder";
            this.SaveRadioSameFolder.Size = new System.Drawing.Size(119, 17);
            this.SaveRadioSameFolder.TabIndex = 9;
            this.SaveRadioSameFolder.Text = "Save to same folder";
            this.SaveRadioSameFolder.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Folder";
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.OpenButton.Location = new System.Drawing.Point(344, 19);
            this.OpenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(43, 23);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SelectFilesButton
            // 
            this.SelectFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.SelectFilesButton.Location = new System.Drawing.Point(315, 20);
            this.SelectFilesButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectFilesButton.Name = "SelectFilesButton";
            this.SelectFilesButton.Size = new System.Drawing.Size(25, 20);
            this.SelectFilesButton.TabIndex = 1;
            this.SelectFilesButton.Text = "...";
            this.SelectFilesButton.UseVisualStyleBackColor = true;
            this.SelectFilesButton.Click += new System.EventHandler(this.SelectFilesButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 5;
            // 
            // CovertButton
            // 
            this.CovertButton.BackColor = System.Drawing.SystemColors.Control;
            this.CovertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.CovertButton.Location = new System.Drawing.Point(4, 131);
            this.CovertButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CovertButton.Name = "CovertButton";
            this.CovertButton.Size = new System.Drawing.Size(92, 41);
            this.CovertButton.TabIndex = 0;
            this.CovertButton.Text = "Convert";
            this.CovertButton.UseVisualStyleBackColor = false;
            this.CovertButton.Click += new System.EventHandler(this.CovertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 195);
            this.Controls.Add(this.ConvertPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Covertor";
            this.ConvertPanel.ResumeLayout(false);
            this.ConvertPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ConvertPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SelectFilesButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CovertButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton SaveRadioConvertedFolder;
        private System.Windows.Forms.RadioButton SaveRadioSameFolder;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ToFormatComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FromExtensionComboBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button OpenButton;
    }
}

