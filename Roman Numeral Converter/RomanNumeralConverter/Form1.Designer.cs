namespace RomanNumeralConverter
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
            this.lblNumberDisplay = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblRomanNumeralDisplay = new System.Windows.Forms.Label();
            this.txtRomanNumerals = new System.Windows.Forms.TextBox();
            this.btnRomanToNum = new System.Windows.Forms.Button();
            this.lblNumberDisplay2 = new System.Windows.Forms.Label();
            this.lblRomanNumeralDisplay2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblRomanNumerals = new System.Windows.Forms.Label();
            this.btnNumberToRoman = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumberDisplay
            // 
            this.lblNumberDisplay.AutoSize = true;
            this.lblNumberDisplay.Location = new System.Drawing.Point(12, 54);
            this.lblNumberDisplay.Name = "lblNumberDisplay";
            this.lblNumberDisplay.Size = new System.Drawing.Size(62, 17);
            this.lblNumberDisplay.TabIndex = 0;
            this.lblNumberDisplay.Text = "Number:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(74, 59);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(0, 17);
            this.lblNumber.TabIndex = 1;
            // 
            // lblRomanNumeralDisplay
            // 
            this.lblRomanNumeralDisplay.AutoSize = true;
            this.lblRomanNumeralDisplay.Location = new System.Drawing.Point(224, 56);
            this.lblRomanNumeralDisplay.Name = "lblRomanNumeralDisplay";
            this.lblRomanNumeralDisplay.Size = new System.Drawing.Size(121, 17);
            this.lblRomanNumeralDisplay.TabIndex = 2;
            this.lblRomanNumeralDisplay.Text = "Roman Numerals:";
            // 
            // txtRomanNumerals
            // 
            this.txtRomanNumerals.Location = new System.Drawing.Point(351, 56);
            this.txtRomanNumerals.Name = "txtRomanNumerals";
            this.txtRomanNumerals.Size = new System.Drawing.Size(100, 22);
            this.txtRomanNumerals.TabIndex = 3;
            // 
            // btnRomanToNum
            // 
            this.btnRomanToNum.Location = new System.Drawing.Point(538, 54);
            this.btnRomanToNum.Name = "btnRomanToNum";
            this.btnRomanToNum.Size = new System.Drawing.Size(114, 25);
            this.btnRomanToNum.TabIndex = 4;
            this.btnRomanToNum.Text = "Calculate";
            this.btnRomanToNum.UseVisualStyleBackColor = true;
            this.btnRomanToNum.Click += new System.EventHandler(this.btnRomanToNum_Click);
            // 
            // lblNumberDisplay2
            // 
            this.lblNumberDisplay2.AutoSize = true;
            this.lblNumberDisplay2.Location = new System.Drawing.Point(12, 137);
            this.lblNumberDisplay2.Name = "lblNumberDisplay2";
            this.lblNumberDisplay2.Size = new System.Drawing.Size(62, 17);
            this.lblNumberDisplay2.TabIndex = 5;
            this.lblNumberDisplay2.Text = "Number:";
            // 
            // lblRomanNumeralDisplay2
            // 
            this.lblRomanNumeralDisplay2.AutoSize = true;
            this.lblRomanNumeralDisplay2.Location = new System.Drawing.Point(224, 134);
            this.lblRomanNumeralDisplay2.Name = "lblRomanNumeralDisplay2";
            this.lblRomanNumeralDisplay2.Size = new System.Drawing.Size(121, 17);
            this.lblRomanNumeralDisplay2.TabIndex = 6;
            this.lblRomanNumeralDisplay2.Text = "Roman Numerals:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(77, 137);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 22);
            this.txtNumber.TabIndex = 7;
            // 
            // lblRomanNumerals
            // 
            this.lblRomanNumerals.AutoSize = true;
            this.lblRomanNumerals.Location = new System.Drawing.Point(348, 137);
            this.lblRomanNumerals.Name = "lblRomanNumerals";
            this.lblRomanNumerals.Size = new System.Drawing.Size(0, 17);
            this.lblRomanNumerals.TabIndex = 8;
            // 
            // btnNumberToRoman
            // 
            this.btnNumberToRoman.Location = new System.Drawing.Point(538, 130);
            this.btnNumberToRoman.Name = "btnNumberToRoman";
            this.btnNumberToRoman.Size = new System.Drawing.Size(114, 25);
            this.btnNumberToRoman.TabIndex = 9;
            this.btnNumberToRoman.Text = "Calculate";
            this.btnNumberToRoman.UseVisualStyleBackColor = true;
            this.btnNumberToRoman.Click += new System.EventHandler(this.btnNumberToRoman_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 209);
            this.Controls.Add(this.btnNumberToRoman);
            this.Controls.Add(this.lblRomanNumerals);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblRomanNumeralDisplay2);
            this.Controls.Add(this.lblNumberDisplay2);
            this.Controls.Add(this.btnRomanToNum);
            this.Controls.Add(this.txtRomanNumerals);
            this.Controls.Add(this.lblRomanNumeralDisplay);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblNumberDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberDisplay;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblRomanNumeralDisplay;
        private System.Windows.Forms.TextBox txtRomanNumerals;
        private System.Windows.Forms.Button btnRomanToNum;
        private System.Windows.Forms.Label lblNumberDisplay2;
        private System.Windows.Forms.Label lblRomanNumeralDisplay2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblRomanNumerals;
        private System.Windows.Forms.Button btnNumberToRoman;
    }
}

