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
            this.textBoxTranscriptions.Location = new System.Drawing.Point(12, 12);
            this.textBoxTranscriptions.Multiline = true;
            this.textBoxTranscriptions.Name = "textBoxTranscriptions";
            this.textBoxTranscriptions.Size = new System.Drawing.Size(760, 187);
            this.textBoxTranscriptions.TabIndex = 0;
            // 
            // buttonRecord
            // 
            this.buttonRecord.BackColor = System.Drawing.Color.Red;
            this.buttonRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRecord.Location = new System.Drawing.Point(597, 205);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(86, 44);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Recordio";
            this.buttonRecord.UseVisualStyleBackColor = false;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonStopRecord
            // 
            this.buttonStopRecord.BackColor = System.Drawing.Color.Lavender;
            this.buttonStopRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopRecord.Location = new System.Drawing.Point(689, 205);
            this.buttonStopRecord.Name = "buttonStopRecord";
            this.buttonStopRecord.Size = new System.Drawing.Size(83, 44);
            this.buttonStopRecord.TabIndex = 2;
            this.buttonStopRecord.Text = "Stop";
            this.buttonStopRecord.UseVisualStyleBackColor = false;
            this.buttonStopRecord.Click += new System.EventHandler(this.buttonStopRecord_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.Lime;
            this.buttonCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(12, 205);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(83, 44);
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
            this.pictureBoxSpinner.Location = new System.Drawing.Point(272, 22);
            this.pictureBoxSpinner.Name = "pictureBoxSpinner";
            this.pictureBoxSpinner.Size = new System.Drawing.Size(247, 165);
            this.pictureBoxSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinner.TabIndex = 5;
            this.pictureBoxSpinner.TabStop = false;
            // 
            // labelRecordingInProgress
            // 
            this.labelRecordingInProgress.AutoSize = true;
            this.labelRecordingInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordingInProgress.Location = new System.Drawing.Point(228, 219);
            this.labelRecordingInProgress.Name = "labelRecordingInProgress";
            this.labelRecordingInProgress.Size = new System.Drawing.Size(343, 17);
            this.labelRecordingInProgress.TabIndex = 6;
            this.labelRecordingInProgress.Text = "Yn recordio. Cliciwch ar \'Stop\' wedi i chi orffen siarad.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.labelRecordingInProgress);
            this.Controls.Add(this.pictureBoxSpinner);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonStopRecord);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.textBoxTranscriptions);
            this.MinimumSize = new System.Drawing.Size(800, 300);
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

