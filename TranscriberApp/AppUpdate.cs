using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace DeepSpeechTranscriberApp
{
    public partial class AppUpdate : Form
    {
       
        public AppUpdate()
        {
            InitializeComponent();
        }

        public bool IsAvailableUpdate()
        {
            bool result = false;

            if (!makeCheck())
                return result;

            var webRequest = WebRequest.Create(Path.Combine(DeepSpeechTranscriberApp.Program.TRANSCRIBER_APP_URL_BASE, "version.txt"));

            try
            {
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    String strContent = reader.ReadToEnd();
                    strContent = strContent.Trim();
                    Version latestVersion = new Version(strContent);
                    
                    Version installedVersion = new Version(getInstalledAppVersion());

                    if (installedVersion < latestVersion)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception exc)
            {

            }

            return result;

        }


        public String getInstalledAppVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            Version installedVersion = new Version(fileVersionInfo.ProductVersion);
            return installedVersion.ToString();
        }


        private bool makeCheck()
        {
            Random random = new Random();
            int r = random.Next(1, 3);
            if (r == 2)
                return true;
            else
                return false;
        }


        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(DeepSpeechTranscriberApp.Program.TRANSCRIBER_APP_URL_BASE);
        }

    }

}
