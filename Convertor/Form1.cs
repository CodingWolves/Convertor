using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convertor
{
    public partial class Form1 : Form
    {
        private static int THREAD_QUEUE = 16;
        private static int THREAD_QUEUE_SLEEP = 20;
        private static int STATUS_INTERVAL = 300; // in milliseconds

        public Form1()
        {
            InitializeComponent();
            ToFormatComboBox.SelectedIndex = 0;
            FromExtensionComboBox.SelectedIndex = 2;
        }

        private void CovertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Choose Folder Path", "Error");
                return;
            }
            if (!Directory.Exists(this.textBox1.Text))
            {
                MessageBox.Show("Incorrect Folder Path", "Error");
                return;
            }

            string folderPath = textBox1.Text;
            string convertedFolderPath = folderPath + "\\converted";
            string[] allFiles = Directory.GetFiles(folderPath);
            if (SaveRadioConvertedFolder.Checked)
            {
                Directory.CreateDirectory(convertedFolderPath);
            }

            statusLabel.Visible = true;
            progressBar.Visible = true;
            progressBar.Maximum = allFiles.Length;
            progressBar.Value = 0;

            ConvertPanel.Enabled = false;

            string toFormatName = (string)ToFormatComboBox.SelectedItem;
            ImageFormat toFormat = ImageConvertor.GetImageFormatByString(toFormatName);
            string fromExtension = FromExtensionComboBox.SelectedItem.ToString().ToLower();

            Console.WriteLine("started at " + DateTime.Now.ToLongTimeString());
            LinkedList<Thread> threadList = new LinkedList<Thread>();

            DateTime startTime = DateTime.Now;

            statusLabel.Text = "Converting";

            int count = 0;

            for (int index = 0; index < allFiles.Length; index++)
            {
                string fileName = allFiles[index];
                progressBar.Value = index;
                if (DateTime.Now.Subtract(startTime).Milliseconds > STATUS_INTERVAL)
                {
                    statusLabel.Text = "Converting" + String.Concat(Enumerable.Repeat(".", (++count % 5)));
                    startTime = DateTime.Now;
                }
                Application.DoEvents();

                if (!Path.GetExtension(fileName).ToLower().Equals("."+fromExtension))
                {
                    continue;
                }

                ImageConvertor imageConvertor;

                if (SaveRadioConvertedFolder.Checked)
                {
                    //ImageConvertor.SaveImageAs(fileName, convertedFolderPath + "\\" + Path.GetFileNameWithoutExtension(fileName) + ".jpg", ImageFormat.Jpeg); // new 430 bmp size 5.93MB , 42 secs on SSD , 242 secs on HDD
                    imageConvertor = new ImageConvertor(fileName, convertedFolderPath + "\\" + Path.GetFileNameWithoutExtension(fileName) + "." + toFormatName, toFormat); // new 430 bmp size 5.93MB , 14 secs on SSD , 122 secs on HDD

                }
                else // (SaveRadioSameFolder.Checked)
                {
                    imageConvertor = new ImageConvertor(fileName, folderPath + "\\" + Path.GetFileNameWithoutExtension(fileName) + "." + toFormatName, toFormat);
                }

                threadList.AddLast(new Thread(new ThreadStart(imageConvertor.SaveImageAs)));
                threadList.Last.Value.Start();

                while (threadList.Count >= THREAD_QUEUE) // Thread Queue, the longest operation is IO so IO Queue
                {
                    Thread.Sleep(THREAD_QUEUE_SLEEP);
                    if (DateTime.Now.Subtract(startTime).Milliseconds > STATUS_INTERVAL)
                    {
                        statusLabel.Text = "Converting" + String.Concat(Enumerable.Repeat(".", (++count % 5)));
                        startTime = DateTime.Now;
                        Application.DoEvents();
                    }
                    RemoveNonLivingThreads(threadList);
                }
            }
            foreach (Thread th in threadList)
                th.Join(); // wait for the last threads to finish

            Console.WriteLine("ended at " + DateTime.Now.ToLongTimeString());

            MessageBox.Show("Converted " + allFiles.Length + " Files", "Conversion Finished");

            statusLabel.Visible = false;
            progressBar.Visible = false;

            ConvertPanel.Enabled = true;
        }

        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.textBox1.Text))
            {
                System.Diagnostics.Process.Start(this.textBox1.Text, null);
            }
            else
            {
                MessageBox.Show("Incorrect Folder Path", "Error");
            }
        }

        private void RemoveNonLivingThreads(LinkedList<Thread> threadList)
        {
            LinkedListNode<Thread> node = threadList.First;

            while (node != null && node.Next != null)
            {
                if (!node.Value.IsAlive)
                {
                    node = node.Next;
                    threadList.Remove(node.Previous);
                }
                else
                    node = node.Next;
            }
        }

        
    }
}
