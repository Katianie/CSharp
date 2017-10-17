namespace Archive_Searcher
{
    partial class frmArchiveSearcher
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
            this.rbtnPanel = new System.Windows.Forms.Panel();
            this.rbtnContains = new System.Windows.Forms.RadioButton();
            this.rbtnSpecific = new System.Windows.Forms.RadioButton();
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.chkPanel = new System.Windows.Forms.Panel();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnPanel.SuspendLayout();
            this.chkPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnPanel
            // 
            this.rbtnPanel.Controls.Add(this.rbtnContains);
            this.rbtnPanel.Controls.Add(this.rbtnSpecific);
            this.rbtnPanel.Location = new System.Drawing.Point(919, 12);
            this.rbtnPanel.Name = "rbtnPanel";
            this.rbtnPanel.Size = new System.Drawing.Size(112, 71);
            this.rbtnPanel.TabIndex = 0;
            // 
            // rbtnContains
            // 
            this.rbtnContains.AutoSize = true;
            this.rbtnContains.Location = new System.Drawing.Point(3, 40);
            this.rbtnContains.Name = "rbtnContains";
            this.rbtnContains.Size = new System.Drawing.Size(103, 17);
            this.rbtnContains.TabIndex = 1;
            this.rbtnContains.TabStop = true;
            this.rbtnContains.Text = "Contains Search";
            this.rbtnContains.UseVisualStyleBackColor = true;
            this.rbtnContains.CheckedChanged += new System.EventHandler(this.rbtnContains_CheckedChanged);
            // 
            // rbtnSpecific
            // 
            this.rbtnSpecific.AutoSize = true;
            this.rbtnSpecific.Location = new System.Drawing.Point(3, 17);
            this.rbtnSpecific.Name = "rbtnSpecific";
            this.rbtnSpecific.Size = new System.Drawing.Size(100, 17);
            this.rbtnSpecific.TabIndex = 0;
            this.rbtnSpecific.TabStop = true;
            this.rbtnSpecific.Text = "Specific Search";
            this.rbtnSpecific.UseVisualStyleBackColor = true;
            this.rbtnSpecific.CheckedChanged += new System.EventHandler(this.rbtnSpecific_CheckedChanged);
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Location = new System.Drawing.Point(62, 29);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(726, 20);
            this.txtSearchBar.TabIndex = 1;
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 29);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // txtConsole
            // 
            this.txtConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtConsole.Location = new System.Drawing.Point(0, 149);
            this.txtConsole.MaxLength = 327670000;
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(1043, 395);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.WordWrap = false;
            this.txtConsole.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(361, 72);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(112, 40);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // chkPanel
            // 
            this.chkPanel.Controls.Add(this.chkCase);
            this.chkPanel.Location = new System.Drawing.Point(794, 15);
            this.chkPanel.Name = "chkPanel";
            this.chkPanel.Size = new System.Drawing.Size(119, 68);
            this.chkPanel.TabIndex = 5;
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(3, 17);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(83, 17);
            this.chkCase.TabIndex = 0;
            this.chkCase.Text = "Ignore Case";
            this.chkCase.UseVisualStyleBackColor = true;
            this.chkCase.CheckedChanged += new System.EventHandler(this.chkCase_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // frmArchiveSearcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 544);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkPanel);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.rbtnPanel);
            this.Name = "frmArchiveSearcher";
            this.Text = "Archive Searcher";
            this.Load += new System.EventHandler(this.frmArchiveSearcher_Load);
            this.rbtnPanel.ResumeLayout(false);
            this.rbtnPanel.PerformLayout();
            this.chkPanel.ResumeLayout(false);
            this.chkPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel rbtnPanel;
        private System.Windows.Forms.RadioButton rbtnContains;
        private System.Windows.Forms.RadioButton rbtnSpecific;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Panel chkPanel;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.Label label1;
    }
}