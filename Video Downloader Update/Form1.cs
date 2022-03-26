using System;
using VideoLibrary;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Video_Downloader_Update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private bool CheckUrlIsValid(string strUrl)
        {
            return Uri.IsWellFormedUriString(strUrl, UriKind.Absolute);

        }

       
        private async void button1_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(textBox1.Text);
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());
                    button1.Text = "Download Complete";
                    MessageBox.Show("Download Complete");

                }

            }
       
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(textBox1.Text);
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName + ".mp3", await video.GetBytesAsync());
                    button2.Text = "Download Complete";
                    MessageBox.Show("Download Complete");

                 
                }
              

            }
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            var strUrl = Clipboard.GetText();

            if (CheckUrlIsValid(strUrl))
            {
                textBox1.Text = strUrl;

            }
            else
            {
                MessageBox.Show(@"In-Valid Url");
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show("mdshamimh529@gmail.com");
            Process.Start("https://www.gmail.com");
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
          //  MessageBox.Show("Visit My WebSite: "+ "https://shamimsagor.blogspot.com/");
            Process.Start("http://www.miniinstitute.com/");
        }

        private void Downloader_DownloadProgressChanged(object sender, EventArgs e)
        {

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    progressBar1.Increment(1);
        //}
    }

}
