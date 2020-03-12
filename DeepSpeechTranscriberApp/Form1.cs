using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DeepSpeechLib;

namespace DeepSpeechTranscriberApp
{
    public partial class Form1 : Form
    {
        DeepSpeechTranscriber _transcriber = new DeepSpeechTranscriber();

        public Form1()
        {
            InitializeComponent();

            AppUpdate appUpdate = new AppUpdate();
            if (appUpdate.IsAvailableUpdate())
                appUpdate.ShowDialog();

            buttonStopRecord.Enabled = false;           
            pictureBoxSpinner.Visible = false;
            labelRecordingInProgress.Visible = false;
            pictureBoxSpinner.BringToFront();

            backgroundWorkerTranscribe.DoWork += new DoWorkEventHandler(Transcribe_DoWork);
            backgroundWorkerTranscribe.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Transcribe_Completed);

        }

      

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            buttonRecord.Enabled = false;
            buttonCopyToClipboard.Enabled = false;
            buttonStopRecord.Enabled = true;
            labelRecordingInProgress.Visible = true;

            this.textBoxTranscriptions.Clear();

            _transcriber.StartRecording();

        }


        private void buttonStopRecord_Click(object sender, EventArgs e)
        {                      
            buttonStopRecord.Enabled = false;            
            pictureBoxSpinner.Visible = true;
            labelRecordingInProgress.Visible = false;

            _transcriber.StopRecording();

            this.backgroundWorkerTranscribe.RunWorkerAsync();   
            
        }


        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(this.textBoxTranscriptions.Text);
        }


        private void Transcribe_DoWork(object sender, DoWorkEventArgs e) 
        {
            Tuple<string, double?, int?, string> sttResult = _transcriber.Transcribe();            
            e.Result = sttResult.Item1;
        }


        private void Transcribe_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            textBoxTranscriptions.Text = e.Result.ToString();
            buttonRecord.Enabled = true;
            buttonCopyToClipboard.Enabled = true;
            pictureBoxSpinner.Visible = false;
        }


        private void buttonAbout_Click(object sender, EventArgs e)
        {
            DeepSpeechTranscriptionApp.About aboutDialog = new DeepSpeechTranscriptionApp.About();            
            aboutDialog.setUrl("Diolchiadau", "about.html");
            aboutDialog.ShowDialog();
        }

       
        private void buttonCommonVoice_Click(object sender, EventArgs e)
        {
            DeepSpeechTranscriptionApp.About aboutDialog = new DeepSpeechTranscriptionApp.About();
            aboutDialog.setUrl("Mozilla CommonVoice", "commonvoice.html");
            aboutDialog.ShowDialog();            
        }


        private void buttonHowToUse_Click(object sender, EventArgs e)
        {
            DeepSpeechTranscriptionApp.About aboutDialog = new DeepSpeechTranscriptionApp.About();
            aboutDialog.setUrl("Sut i Ddefnyddio", "sutiddefnyddio.html");
            aboutDialog.ShowDialog();
        }

    }

}
