namespace DeepSpeechTranscriberApp
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
            this.labelRecordingInProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonHowToUse = new System.Windows.Forms.Button();
            this.buttonMozillaCommonVoice = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.pictureBoxSpinner = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTranscriptions
            // 
            this.textBoxTranscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranscriptions.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTranscriptions.Location = new System.Drawing.Point(13, 195);
            this.textBoxTranscriptions.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTranscriptions.Multiline = true;
            this.textBoxTranscriptions.Name = "textBoxTranscriptions";
            this.textBoxTranscriptions.Size = new System.Drawing.Size(975, 315);
            this.textBoxTranscriptions.TabIndex = 0;
            this.textBoxTranscriptions.TabStop = false;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecord.BackColor = System.Drawing.Color.Red;
            this.buttonRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRecord.Location = new System.Drawing.Point(741, 518);
            this.buttonRecord.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRecord.MaximumSize = new System.Drawing.Size(115, 54);
            this.buttonRecord.MinimumSize = new System.Drawing.Size(115, 54);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(115, 54);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "Recordio";
            this.buttonRecord.UseVisualStyleBackColor = false;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonStopRecord
            // 
            this.buttonStopRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopRecord.BackColor = System.Drawing.Color.Lavender;
            this.buttonStopRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopRecord.Location = new System.Drawing.Point(873, 518);
            this.buttonStopRecord.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStopRecord.MaximumSize = new System.Drawing.Size(115, 54);
            this.buttonStopRecord.MinimumSize = new System.Drawing.Size(115, 54);
            this.buttonStopRecord.Name = "buttonStopRecord";
            this.buttonStopRecord.Size = new System.Drawing.Size(115, 54);
            this.buttonStopRecord.TabIndex = 2;
            this.buttonStopRecord.Text = "Stop";
            this.buttonStopRecord.UseVisualStyleBackColor = false;
            this.buttonStopRecord.Click += new System.EventHandler(this.buttonStopRecord_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.Lime;
            this.buttonCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(13, 518);
            this.buttonCopyToClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCopyToClipboard.MaximumSize = new System.Drawing.Size(115, 54);
            this.buttonCopyToClipboard.MinimumSize = new System.Drawing.Size(115, 54);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(115, 54);
            this.buttonCopyToClipboard.TabIndex = 3;
            this.buttonCopyToClipboard.Text = "Copïo";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = false;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // labelRecordingInProgress
            // 
            this.labelRecordingInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRecordingInProgress.AutoSize = true;
            this.labelRecordingInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordingInProgress.Location = new System.Drawing.Point(322, 535);
            this.labelRecordingInProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecordingInProgress.Name = "labelRecordingInProgress";
            this.labelRecordingInProgress.Size = new System.Drawing.Size(411, 20);
            this.labelRecordingInProgress.TabIndex = 6;
            this.labelRecordingInProgress.Text = "Yn recordio. Cliciwch ar \'Stop\' wedi i chi orffen siarad.";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-17, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 119);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::TranscriberApp.Properties.Resources.log_pb_tryloyw;
            this.pictureBox2.Location = new System.Drawing.Point(874, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::TranscriberApp.Properties.Resources.WelshGovtlogo;
            this.pictureBox1.Location = new System.Drawing.Point(612, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trawsgrifiwr";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.buttonHowToUse);
            this.panel2.Controls.Add(this.buttonMozillaCommonVoice);
            this.panel2.Controls.Add(this.buttonAbout);
            this.panel2.Location = new System.Drawing.Point(-14, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 71);
            this.panel2.TabIndex = 8;
            // 
            // buttonHowToUse
            // 
            this.buttonHowToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHowToUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.buttonHowToUse.FlatAppearance.BorderSize = 0;
            this.buttonHowToUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHowToUse.ForeColor = System.Drawing.Color.White;
            this.buttonHowToUse.Location = new System.Drawing.Point(27, 8);
            this.buttonHowToUse.Name = "buttonHowToUse";
            this.buttonHowToUse.Size = new System.Drawing.Size(183, 54);
            this.buttonHowToUse.TabIndex = 2;
            this.buttonHowToUse.Text = "Sut i Ddefnyddio";
            this.buttonHowToUse.UseVisualStyleBackColor = false;
            this.buttonHowToUse.Click += new System.EventHandler(this.buttonHowToUse_Click);
            // 
            // buttonMozillaCommonVoice
            // 
            this.buttonMozillaCommonVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMozillaCommonVoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.buttonMozillaCommonVoice.FlatAppearance.BorderSize = 0;
            this.buttonMozillaCommonVoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMozillaCommonVoice.ForeColor = System.Drawing.Color.White;
            this.buttonMozillaCommonVoice.Location = new System.Drawing.Point(624, 8);
            this.buttonMozillaCommonVoice.Name = "buttonMozillaCommonVoice";
            this.buttonMozillaCommonVoice.Size = new System.Drawing.Size(228, 54);
            this.buttonMozillaCommonVoice.TabIndex = 1;
            this.buttonMozillaCommonVoice.Text = "Mozilla CommonVoice";
            this.buttonMozillaCommonVoice.UseVisualStyleBackColor = false;
            this.buttonMozillaCommonVoice.Click += new System.EventHandler(this.buttonCommonVoice_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.Location = new System.Drawing.Point(871, 8);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(131, 54);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "Diolchiadau";
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // pictureBoxSpinner
            // 
            this.pictureBoxSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSpinner.BackColor = System.Drawing.Color.White;
            this.pictureBoxSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxSpinner.Image = global::TranscriberApp.Properties.Resources.loading_bar_animated_gif_transparent_background_6;
            this.pictureBoxSpinner.Location = new System.Drawing.Point(363, 209);
            this.pictureBoxSpinner.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxSpinner.Name = "pictureBoxSpinner";
            this.pictureBoxSpinner.Size = new System.Drawing.Size(289, 248);
            this.pictureBoxSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinner.TabIndex = 5;
            this.pictureBoxSpinner.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelRecordingInProgress);
            this.Controls.Add(this.pictureBoxSpinner);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonStopRecord);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.textBoxTranscriptions);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Trawsgifiwr";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonMozillaCommonVoice;
        private System.Windows.Forms.Button buttonHowToUse;
    }
}

