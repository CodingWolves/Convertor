using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Convertor
{
    public partial class Convertor : Form
    {
        private const int THREAD_QUEUE = 16;
        private const int THREAD_QUEUE_SLEEP = 20; // in milliseconds
        private const int STATUS_UPDATE_INTERVAL = 300; // in milliseconds

        public Convertor()
        {
            InitializeComponent();
            ToFormatComboBox.SelectedIndex = 0;
            FromExtensionComboBox.SelectedIndex = 0;
        }

        private void CovertButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Choose Folder Path", "Error");
                return;
            }
            if(!Directory.Exists(this.textBox1.Text))
            {
                MessageBox.Show("Incorrect Folder Path", "Error");
                return;
            }

            string sourceFolderPath = textBox1.Text;
            string convertedFolderPath = sourceFolderPath + "\\converted";
            string[] sourceFiles = Directory.GetFiles(sourceFolderPath);
            if(SaveRadioConvertedFolder.Checked)
            {
                Directory.CreateDirectory(convertedFolderPath);
            }

            statusLabel.Visible = true;
            progressBar.Visible = true;
            progressBar.Maximum = sourceFiles.Length;
            progressBar.Value = 0;

            ConvertPanel.Enabled = false;

            string toFormatName = (string)ToFormatComboBox.SelectedItem;
            ImageFormat toFormat = ImageConvertor.GetImageFormatByString(toFormatName);
            string fromExtension = FromExtensionComboBox.SelectedItem.ToString().ToLower();

            LinkedList<Thread> threadList = new LinkedList<Thread>();

            DateTime lastIntervalTime = DateTime.Now;

            statusLabel.Text = "Converting";

            int count = 0;
            int convertedCount = 0;

            for(int index = 0; index < sourceFiles.Length; index++)
            {
                string sourceFilePath = sourceFiles[index];
                string resultFilePath;

                // Form status and progressBar update
                void FormUpdate()
                {
                    progressBar.Value = index;
                    if(DateTime.Now.Subtract(lastIntervalTime).Milliseconds > STATUS_UPDATE_INTERVAL)
                    {
                        statusLabel.Text = "Converting" + String.Concat(Enumerable.Repeat(".", (++count % 5)));
                        lastIntervalTime = DateTime.Now;
                    }
                    Application.DoEvents();
                }

                FormUpdate();

                // continue if the source file extension is not the one I'm looking for (.jpg != .bmp)
                if(!Path.GetExtension(sourceFilePath).ToLower().Equals("." + fromExtension))
                {
                    continue;
                }
                convertedCount++;

                resultFilePath = SaveRadioConvertedFolder.Checked ? convertedFolderPath : sourceFolderPath;
                resultFilePath += "\\" + Path.GetFileNameWithoutExtension(sourceFilePath) + "." + toFormatName.ToLower();

                ImageConvertor imageConvertor = new ImageConvertor(sourceFilePath, resultFilePath, toFormat);

                // using sequential io     = 430 bmp size 5.93MB to jpg, 42 secs on SSD , 242 secs on HDD
                // using multi-threaded io = 430 bmp size 5.93MB to jpg, 14 secs on SSD , 122 secs on HDD
                threadList.AddLast(new Thread(new ThreadStart(imageConvertor.ConvertImage)));
                threadList.Last.Value.Start();

                while(threadList.Count >= THREAD_QUEUE) // Thread Queue, the longest operation is IO so IO Queue
                {
                    Thread.Sleep(THREAD_QUEUE_SLEEP);
                    FormUpdate();
                    RemoveNonLivingThreads(threadList);
                }
            }
            foreach(Thread th in threadList)
            {
                th.Join(); // wait for the last threads to finish
            }

            MessageBox.Show("Converted " + convertedCount + " Files", "Conversion Finished");

            statusLabel.Visible = false;
            progressBar.Visible = false;

            ConvertPanel.Enabled = true;
        }

        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(this.textBox1.Text))
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

            while(node != null && node.Next != null)
            {
                node = node.Next;
                if(!node.Previous.Value.IsAlive)
                {
                    threadList.Remove(node.Previous);
                }
            }
            if(node != null && !node.Value.IsAlive)
            {
                threadList.Remove(node);
            }
        }
    }
}
