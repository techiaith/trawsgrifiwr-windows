using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using DeepSpeechLib;
using TranscriberApp;

namespace DeepSpeechTranscriberApp
{
    public partial class Form1 : Form
    {
        DeepSpeechTranscriber _transcriber;
        private String _recognizedText = String.Empty;

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
            this.Text = this.Text + " - v" + appUpdate.getInstalledAppVersion();

            backgroundWorkerTranscribe.DoWork += new DoWorkEventHandler(Transcribe_DoWork);
            backgroundWorkerTranscribe.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Transcribe_Completed);

            _transcriber = new DeepSpeechTranscriber();
            String message = _transcriber.CreateSpeechRecognitionEngine();
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            if (_transcriber.isUsingOnlineDeepSpeech()) {
                this.Text = this.Text + " (MODD PEIRIANT AR-LEIN)";
            }
            else {
                this.Text = this.Text + " (MODD PEIRIANT LLEOL)";
            }
            
        }


        private void buttonRecord_Click(object sender, EventArgs e)
        {
            this._recognizedText = String.Empty;

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


        private async void Transcribe_DoWork(object sender, DoWorkEventArgs e) 
        {
            List<String> sttResult = _transcriber.Transcribe();
            if (sttResult.Count > 0)
            {
                //Recognized text: ar un roedd amodau meg amarch
                //Confidence: -72.9908981323242
                //Item count: 29
                //Timestep: 37 TimeOffset: 0.74 Char: a
                //Timestep : 38 TimeOffset: 0.76 Char: r
                //Timestep : 81 TimeOffset: 1.62 Char:
                String[] resultLines = sttResult[0].Split(Environment.NewLine.ToCharArray());
                this._recognizedText = resultLines[0].Replace("Recognized text:", "").Trim();
                e.Result = this._recognizedText;
            }                
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


        private void textBoxTranscriptions_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this._recognizedText))
            {
                int d = LevenshteinDistance.Calculate(this._recognizedText, this.textBoxTranscriptions.Text);
                double cer = ((double)d / (double)this._recognizedText.Length) * 100;

                this.labelCharacterErrorRate.Text = cer.ToString("N6") + "%";
            } else
            {
                this.labelCharacterErrorRate.Text = String.Empty;
            }
            
        }
    }

}
