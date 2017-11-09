namespace WindowsInfo
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.prbLoadingBar = new System.Windows.Forms.ProgressBar();
            this.btnGo = new System.Windows.Forms.Button();
            this.stsStatusInfo = new System.Windows.Forms.StatusStrip();
            this.stsStatusInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsStatusInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(10, 10);
            this.txtOutput.MaxLength = 0;
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(479, 360);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // prbLoadingBar
            // 
            this.prbLoadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prbLoadingBar.Location = new System.Drawing.Point(10, 426);
            this.prbLoadingBar.Name = "prbLoadingBar";
            this.prbLoadingBar.Size = new System.Drawing.Size(479, 23);
            this.prbLoadingBar.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(191, 376);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(128, 44);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // stsStatusInfo
            // 
            this.stsStatusInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsStatusInfoLabel});
            this.stsStatusInfo.Location = new System.Drawing.Point(0, 452);
            this.stsStatusInfo.Name = "stsStatusInfo";
            this.stsStatusInfo.Size = new System.Drawing.Size(496, 22);
            this.stsStatusInfo.TabIndex = 3;
            // 
            // stsStatusInfoLabel
            // 
            this.stsStatusInfoLabel.Name = "stsStatusInfoLabel";
            this.stsStatusInfoLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 474);
            this.Controls.Add(this.stsStatusInfo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.prbLoadingBar);
            this.Controls.Add(this.txtOutput);
            this.Name = "frmMain";
            this.Text = "Windows Info";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.stsStatusInfo.ResumeLayout(false);
            this.stsStatusInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ProgressBar prbLoadingBar;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.StatusStrip stsStatusInfo;
        private System.Windows.Forms.ToolStripStatusLabel stsStatusInfoLabel;
    }
}

