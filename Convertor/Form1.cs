using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoder = System.Text.Encoder;

namespace Convertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CovertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Choose folder");
                return;
            }

            string pathString = textBox1.Text;
            string[] allFiles = Directory.GetFiles(pathString);
            Directory.CreateDirectory(pathString + "\\converted" );
            textBox2.Visible = true;
            int count = 0;
            foreach (var fileName in allFiles)
            {
                count++;
                textBox2.Text = "Loading" + String.Concat(Enumerable.Repeat(".", (count % 5)));
                if (!fileName.EndsWith(".bmp"))
                {
                    continue;
                }
                Image finalBitmap = Image.FromFile(fileName);
                finalBitmap.Save(pathString + 
                                 "\\converted\\" +
                                 Path.GetFileNameWithoutExtension(Path.GetFileName(fileName)) +
                                 ".jpg",
                    ImageFormat.Jpeg);
            }
            textBox2.Visible = false;
        }

        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
