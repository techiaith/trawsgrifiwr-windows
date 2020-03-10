using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DeepSpeechLib;

namespace DeepSpeechForm
{
    public partial class Form1 : Form
    {
        DeepSpeechTranscriber _transcriber = new DeepSpeechTranscriber();

        public Form1()
        {
            InitializeComponent();

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

            SoftBlink(labelRecordingInProgress, Color.DarkRed, Color.LightPink, 2000, false);

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


        private async void SoftBlink(Control ctrl, Color c1, Color c2, short CycleTime_ms, bool BkClr)
        {
            var sw = new Stopwatch(); sw.Start();
            short halfCycle = (short)Math.Round(CycleTime_ms * 0.5);
            while (true)
            {
                await Task.Delay(1);
                var n = sw.ElapsedMilliseconds % CycleTime_ms;
                var per = (double)Math.Abs(n - halfCycle) / halfCycle;
                var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
                var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
                var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
                var clr = Color.FromArgb(red, grn, blw);
                if (BkClr) ctrl.BackColor = clr; else ctrl.ForeColor = clr;
            }
        }

    }

}
