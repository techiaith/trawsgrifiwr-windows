namespace DeepSpeechForm
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
            this.textBoxTranscriptions = new System.Windows.Forms.TextBox();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonStopRecord = new System.Windows.Forms.Button();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.backgroundWorkerTranscribe = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxSpinner = new System.Windows.Forms.PictureBox();
            this.labelRecordingInProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTranscriptions
            // 
            this.textBoxTranscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranscriptions.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTranscriptions.Location = new System.Drawing.Point(16, 15);
            this.textBoxTranscriptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTranscriptions.Multiline = true;
            this.textBoxTranscriptions.Name = "textBoxTranscriptions";
            this.textBoxTranscriptions.Size = new System.Drawing.Size(1012, 229);
            this.textBoxTranscriptions.TabIndex = 0;
            this.textBoxTranscriptions.TabStop = false;

            // 
            // buttonRecord
            // 
            this.buttonRecord.BackColor = System.Drawing.Color.Red;
            this.buttonRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRecord.Location = new System.Drawing.Point(796, 252);
            this.buttonRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(115, 54);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Recordio";
            this.buttonRecord.UseVisualStyleBackColor = false;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonStopRecord
            // 
            this.buttonStopRecord.BackColor = System.Drawing.Color.Lavender;
            this.buttonStopRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopRecord.Location = new System.Drawing.Point(919, 252);
            this.buttonStopRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStopRecord.Name = "buttonStopRecord";
            this.buttonStopRecord.Size = new System.Drawing.Size(111, 54);
            this.buttonStopRecord.TabIndex = 2;
            this.buttonStopRecord.Text = "Stop";
            this.buttonStopRecord.UseVisualStyleBackColor = false;
            this.buttonStopRecord.Click += new System.EventHandler(this.buttonStopRecord_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.Lime;
            this.buttonCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(16, 252);
            this.buttonCopyToClipboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(111, 54);
            this.buttonCopyToClipboard.TabIndex = 3;
            this.buttonCopyToClipboard.Text = "Copïo";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = false;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // pictureBoxSpinner
            // 
            this.pictureBoxSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSpinner.BackColor = System.Drawing.Color.White;
            this.pictureBoxSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxSpinner.Image = global::DeepSpeechTranscriptionApp.Properties.Resources.loading_bar_animated_gif_transparent_background_6;
            this.pictureBoxSpinner.Location = new System.Drawing.Point(363, 27);
            this.pictureBoxSpinner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxSpinner.Name = "pictureBoxSpinner";
            this.pictureBoxSpinner.Size = new System.Drawing.Size(329, 203);
            this.pictureBoxSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinner.TabIndex = 5;
            this.pictureBoxSpinner.TabStop = false;
            // 
            // labelRecordingInProgress
            // 
            this.labelRecordingInProgress.AutoSize = true;
            this.labelRecordingInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordingInProgress.Location = new System.Drawing.Point(304, 270);
            this.labelRecordingInProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecordingInProgress.Name = "labelRecordingInProgress";
            this.labelRecordingInProgress.Size = new System.Drawing.Size(411, 20);
            this.labelRecordingInProgress.TabIndex = 6;
            this.labelRecordingInProgress.Text = "Yn recordio. Cliciwch ar \'Stop\' wedi i chi orffen siarad.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 321);
            this.Controls.Add(this.labelRecordingInProgress);
            this.Controls.Add(this.pictureBoxSpinner);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonStopRecord);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.textBoxTranscriptions);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1061, 358);
            this.Name = "Form1";
            this.Text = "Trawsgifiwr";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTranscriptions;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonStopRecord;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranscribe;
        private System.Windows.Forms.PictureBox pictureBoxSpinner;
        private System.Windows.Forms.Label labelRecordingInProgress;
    }
}

