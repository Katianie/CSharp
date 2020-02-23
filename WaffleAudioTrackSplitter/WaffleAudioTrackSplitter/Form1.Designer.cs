namespace WaffleAudioTrackSplitter
{
    partial class frmMain
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
            this.btnStartSplit = new System.Windows.Forms.Button();
            this.txtTrackText = new System.Windows.Forms.TextBox();
            this.txtAudoFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseForAudioFile = new System.Windows.Forms.Button();
            this.lblAudoFilePath = new System.Windows.Forms.Label();
            this.prgLoadingBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnStartSplit
            // 
            this.btnStartSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartSplit.Location = new System.Drawing.Point(172, 375);
            this.btnStartSplit.Name = "btnStartSplit";
            this.btnStartSplit.Size = new System.Drawing.Size(166, 59);
            this.btnStartSplit.TabIndex = 4;
            this.btnStartSplit.Text = "Split Audio File Into Tracks";
            this.btnStartSplit.Click += new System.EventHandler(this.btnStartSplit_Click);
            // 
            // txtTrackText
            // 
            this.txtTrackText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackText.Location = new System.Drawing.Point(12, 113);
            this.txtTrackText.MaxLength = 2147483647;
            this.txtTrackText.Multiline = true;
            this.txtTrackText.Name = "txtTrackText";
            this.txtTrackText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTrackText.Size = new System.Drawing.Size(472, 256);
            this.txtTrackText.TabIndex = 3;
            // 
            // txtAudoFilePath
            // 
            this.txtAudoFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAudoFilePath.Location = new System.Drawing.Point(121, 48);
            this.txtAudoFilePath.Name = "txtAudoFilePath";
            this.txtAudoFilePath.Size = new System.Drawing.Size(256, 20);
            this.txtAudoFilePath.TabIndex = 1;
            // 
            // btnBrowseForAudioFile
            // 
            this.btnBrowseForAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForAudioFile.Location = new System.Drawing.Point(383, 41);
            this.btnBrowseForAudioFile.Name = "btnBrowseForAudioFile";
            this.btnBrowseForAudioFile.Size = new System.Drawing.Size(32, 32);
            this.btnBrowseForAudioFile.TabIndex = 2;
            this.btnBrowseForAudioFile.Text = "...";
            this.btnBrowseForAudioFile.UseVisualStyleBackColor = true;
            this.btnBrowseForAudioFile.Click += new System.EventHandler(this.btnBrowseForAudioFile_Click);
            // 
            // lblAudoFilePath
            // 
            this.lblAudoFilePath.AutoSize = true;
            this.lblAudoFilePath.Location = new System.Drawing.Point(59, 51);
            this.lblAudoFilePath.Name = "lblAudoFilePath";
            this.lblAudoFilePath.Size = new System.Drawing.Size(56, 13);
            this.lblAudoFilePath.TabIndex = 4;
            this.lblAudoFilePath.Text = "Audio File:";
            // 
            // prgLoadingBar
            // 
            this.prgLoadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgLoadingBar.Location = new System.Drawing.Point(12, 440);
            this.prgLoadingBar.Name = "prgLoadingBar";
            this.prgLoadingBar.Size = new System.Drawing.Size(472, 23);
            this.prgLoadingBar.Step = 1;
            this.prgLoadingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgLoadingBar.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 473);
            this.Controls.Add(this.prgLoadingBar);
            this.Controls.Add(this.lblAudoFilePath);
            this.Controls.Add(this.btnBrowseForAudioFile);
            this.Controls.Add(this.txtAudoFilePath);
            this.Controls.Add(this.txtTrackText);
            this.Controls.Add(this.btnStartSplit);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "frmMain";
            this.Text = "Waffle Audio Track Splitter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button btnStartSplit;
        private System.Windows.Forms.TextBox txtTrackText;
        private System.Windows.Forms.TextBox txtAudoFilePath;
        private System.Windows.Forms.Button btnBrowseForAudioFile;
        private System.Windows.Forms.Label lblAudoFilePath;
        private System.Windows.Forms.ProgressBar prgLoadingBar;
    }
}

