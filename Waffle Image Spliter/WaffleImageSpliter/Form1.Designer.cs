namespace WaffleImageSpliter
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
            this.lblTileWidthDisplay = new System.Windows.Forms.Label();
            this.lblTileHeightDisplay = new System.Windows.Forms.Label();
            this.txtTileWidth = new System.Windows.Forms.TextBox();
            this.txtTileHeight = new System.Windows.Forms.TextBox();
            this.lblEmptySpaceColorDisplay = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.lblImageToSplitDisplay = new System.Windows.Forms.Label();
            this.btnBrowseForImage = new System.Windows.Forms.Button();
            this.picboxImagePreview = new System.Windows.Forms.PictureBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTilePrefexName = new System.Windows.Forms.Label();
            this.txtPrefexName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTileWidthDisplay
            // 
            this.lblTileWidthDisplay.AutoSize = true;
            this.lblTileWidthDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileWidthDisplay.Location = new System.Drawing.Point(66, 20);
            this.lblTileWidthDisplay.Name = "lblTileWidthDisplay";
            this.lblTileWidthDisplay.Size = new System.Drawing.Size(193, 25);
            this.lblTileWidthDisplay.TabIndex = 0;
            this.lblTileWidthDisplay.Text = "Individual Tile Width:";
            // 
            // lblTileHeightDisplay
            // 
            this.lblTileHeightDisplay.AutoSize = true;
            this.lblTileHeightDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTileHeightDisplay.Location = new System.Drawing.Point(66, 64);
            this.lblTileHeightDisplay.Name = "lblTileHeightDisplay";
            this.lblTileHeightDisplay.Size = new System.Drawing.Size(198, 25);
            this.lblTileHeightDisplay.TabIndex = 1;
            this.lblTileHeightDisplay.Text = "Individual Tile Height:";
            // 
            // txtTileWidth
            // 
            this.txtTileWidth.Location = new System.Drawing.Point(270, 20);
            this.txtTileWidth.Name = "txtTileWidth";
            this.txtTileWidth.Size = new System.Drawing.Size(100, 22);
            this.txtTileWidth.TabIndex = 2;
            // 
            // txtTileHeight
            // 
            this.txtTileHeight.Location = new System.Drawing.Point(270, 64);
            this.txtTileHeight.Name = "txtTileHeight";
            this.txtTileHeight.Size = new System.Drawing.Size(100, 22);
            this.txtTileHeight.TabIndex = 3;
            // 
            // lblEmptySpaceColorDisplay
            // 
            this.lblEmptySpaceColorDisplay.AutoSize = true;
            this.lblEmptySpaceColorDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmptySpaceColorDisplay.Location = new System.Drawing.Point(66, 146);
            this.lblEmptySpaceColorDisplay.Name = "lblEmptySpaceColorDisplay";
            this.lblEmptySpaceColorDisplay.Size = new System.Drawing.Size(187, 25);
            this.lblEmptySpaceColorDisplay.TabIndex = 4;
            this.lblEmptySpaceColorDisplay.Text = "Empty Space Color:";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(270, 146);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(100, 25);
            this.btnSelectColor.TabIndex = 5;
            this.btnSelectColor.Text = "Select Color";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblImageToSplitDisplay
            // 
            this.lblImageToSplitDisplay.AutoSize = true;
            this.lblImageToSplitDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageToSplitDisplay.Location = new System.Drawing.Point(66, 187);
            this.lblImageToSplitDisplay.Name = "lblImageToSplitDisplay";
            this.lblImageToSplitDisplay.Size = new System.Drawing.Size(144, 25);
            this.lblImageToSplitDisplay.TabIndex = 6;
            this.lblImageToSplitDisplay.Text = "Image To Split:";
            // 
            // btnBrowseForImage
            // 
            this.btnBrowseForImage.Location = new System.Drawing.Point(270, 187);
            this.btnBrowseForImage.Name = "btnBrowseForImage";
            this.btnBrowseForImage.Size = new System.Drawing.Size(100, 25);
            this.btnBrowseForImage.TabIndex = 7;
            this.btnBrowseForImage.Text = "Browse...";
            this.btnBrowseForImage.UseVisualStyleBackColor = true;
            this.btnBrowseForImage.Click += new System.EventHandler(this.btnBrowseForImage_Click);
            // 
            // picboxImagePreview
            // 
            this.picboxImagePreview.Location = new System.Drawing.Point(34, 233);
            this.picboxImagePreview.Name = "picboxImagePreview";
            this.picboxImagePreview.Size = new System.Drawing.Size(407, 319);
            this.picboxImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxImagePreview.TabIndex = 8;
            this.picboxImagePreview.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(34, 573);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 35);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(341, 576);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 32);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(150, 583);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 11;
            // 
            // lblTilePrefexName
            // 
            this.lblTilePrefexName.AutoSize = true;
            this.lblTilePrefexName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilePrefexName.Location = new System.Drawing.Point(66, 108);
            this.lblTilePrefexName.Name = "lblTilePrefexName";
            this.lblTilePrefexName.Size = new System.Drawing.Size(168, 25);
            this.lblTilePrefexName.TabIndex = 12;
            this.lblTilePrefexName.Text = "Tile Prefex Name:";
            // 
            // txtPrefexName
            // 
            this.txtPrefexName.Location = new System.Drawing.Point(270, 108);
            this.txtPrefexName.Name = "txtPrefexName";
            this.txtPrefexName.Size = new System.Drawing.Size(100, 22);
            this.txtPrefexName.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 628);
            this.Controls.Add(this.txtPrefexName);
            this.Controls.Add(this.lblTilePrefexName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.picboxImagePreview);
            this.Controls.Add(this.btnBrowseForImage);
            this.Controls.Add(this.lblImageToSplitDisplay);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.lblEmptySpaceColorDisplay);
            this.Controls.Add(this.txtTileHeight);
            this.Controls.Add(this.txtTileWidth);
            this.Controls.Add(this.lblTileHeightDisplay);
            this.Controls.Add(this.lblTileWidthDisplay);
            this.Name = "Form1";
            this.Text = "Waffle Image Spliter";
            ((System.ComponentModel.ISupportInitialize)(this.picboxImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTileWidthDisplay;
        private System.Windows.Forms.Label lblTileHeightDisplay;
        private System.Windows.Forms.TextBox txtTileWidth;
        private System.Windows.Forms.TextBox txtTileHeight;
        private System.Windows.Forms.Label lblEmptySpaceColorDisplay;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.Label lblImageToSplitDisplay;
        private System.Windows.Forms.Button btnBrowseForImage;
        private System.Windows.Forms.PictureBox picboxImagePreview;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTilePrefexName;
        private System.Windows.Forms.TextBox txtPrefexName;
    }
}

