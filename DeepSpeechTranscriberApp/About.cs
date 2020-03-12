using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DeepSpeechTranscriptionApp
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();   
        }


        public void setUrl(string title, string url)
        {
            this.Text = title;
            this.webBrowser1.Url = new System.Uri(Path.Combine(DeepSpeechTranscriberApp.Program.TRANSCRIBER_APP_URL_BASE, "html", url));
        }


        public void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            String url = e.Url.ToString();
            if (!url.StartsWith(DeepSpeechTranscriberApp.Program.TRANSCRIBER_APP_URL_BASE))
            {
                e.Cancel = true;
                Process.Start(url);
            }             
        }
       
    }

}
