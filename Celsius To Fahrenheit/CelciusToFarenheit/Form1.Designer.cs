namespace CelciusToFarenheit
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
            this.lblCelsiusDisplay = new System.Windows.Forms.Label();
            this.lblCelsius = new System.Windows.Forms.Label();
            this.txtFarenheit = new System.Windows.Forms.TextBox();
            this.lblFarenheitDisplay = new System.Windows.Forms.Label();
            this.lblFarenheitDisplay2 = new System.Windows.Forms.Label();
            this.lblFarenheit = new System.Windows.Forms.Label();
            this.lblCelsiusDisplay2 = new System.Windows.Forms.Label();
            this.txtCelsius = new System.Windows.Forms.TextBox();
            this.btnFarToCel = new System.Windows.Forms.Button();
            this.btnCelToFar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCelsiusDisplay
            // 
            this.lblCelsiusDisplay.AutoSize = true;
            this.lblCelsiusDisplay.Location = new System.Drawing.Point(12, 9);
            this.lblCelsiusDisplay.Name = "lblCelsiusDisplay";
            this.lblCelsiusDisplay.Size = new System.Drawing.Size(57, 17);
            this.lblCelsiusDisplay.TabIndex = 0;
            this.lblCelsiusDisplay.Text = "Celsius:";
            // 
            // lblCelsius
            // 
            this.lblCelsius.AutoSize = true;
            this.lblCelsius.Location = new System.Drawing.Point(69, 9);
            this.lblCelsius.Name = "lblCelsius";
            this.lblCelsius.Size = new System.Drawing.Size(0, 17);
            this.lblCelsius.TabIndex = 1;
            // 
            // txtFarenheit
            // 
            this.txtFarenheit.Location = new System.Drawing.Point(293, 6);
            this.txtFarenheit.Name = "txtFarenheit";
            this.txtFarenheit.Size = new System.Drawing.Size(100, 22);
            this.txtFarenheit.TabIndex = 2;
            // 
            // lblFarenheitDisplay
            // 
            this.lblFarenheitDisplay.AutoSize = true;
            this.lblFarenheitDisplay.Location = new System.Drawing.Point(215, 6);
            this.lblFarenheitDisplay.Name = "lblFarenheitDisplay";
            this.lblFarenheitDisplay.Size = new System.Drawing.Size(72, 17);
            this.lblFarenheitDisplay.TabIndex = 3;
            this.lblFarenheitDisplay.Text = "Farenheit:";
            // 
            // lblFarenheitDisplay2
            // 
            this.lblFarenheitDisplay2.AutoSize = true;
            this.lblFarenheitDisplay2.Location = new System.Drawing.Point(215, 101);
            this.lblFarenheitDisplay2.Name = "lblFarenheitDisplay2";
            this.lblFarenheitDisplay2.Size = new System.Drawing.Size(72, 17);
            this.lblFarenheitDisplay2.TabIndex = 4;
            this.lblFarenheitDisplay2.Text = "Farenheit:";
            // 
            // lblFarenheit
            // 
            this.lblFarenheit.AutoSize = true;
            this.lblFarenheit.Location = new System.Drawing.Point(287, 101);
            this.lblFarenheit.Name = "lblFarenheit";
            this.lblFarenheit.Size = new System.Drawing.Size(0, 17);
            this.lblFarenheit.TabIndex = 5;
            // 
            // lblCelsiusDisplay2
            // 
            this.lblCelsiusDisplay2.AutoSize = true;
            this.lblCelsiusDisplay2.Location = new System.Drawing.Point(12, 98);
            this.lblCelsiusDisplay2.Name = "lblCelsiusDisplay2";
            this.lblCelsiusDisplay2.Size = new System.Drawing.Size(57, 17);
            this.lblCelsiusDisplay2.TabIndex = 6;
            this.lblCelsiusDisplay2.Text = "Celsius:";
            // 
            // txtCelsius
            // 
            this.txtCelsius.Location = new System.Drawing.Point(75, 96);
            this.txtCelsius.Name = "txtCelsius";
            this.txtCelsius.Size = new System.Drawing.Size(100, 22);
            this.txtCelsius.TabIndex = 7;
            // 
            // btnFarToCel
            // 
            this.btnFarToCel.Location = new System.Drawing.Point(443, 6);
            this.btnFarToCel.Name = "btnFarToCel";
            this.btnFarToCel.Size = new System.Drawing.Size(112, 25);
            this.btnFarToCel.TabIndex = 8;
            this.btnFarToCel.Text = "Calculate";
            this.btnFarToCel.UseVisualStyleBackColor = true;
            this.btnFarToCel.Click += new System.EventHandler(this.btnFarToCel_Click);
            // 
            // btnCelToFar
            // 
            this.btnCelToFar.Location = new System.Drawing.Point(443, 96);
            this.btnCelToFar.Name = "btnCelToFar";
            this.btnCelToFar.Size = new System.Drawing.Size(112, 25);
            this.btnCelToFar.TabIndex = 9;
            this.btnCelToFar.Text = "Calculate";
            this.btnCelToFar.UseVisualStyleBackColor = true;
            this.btnCelToFar.Click += new System.EventHandler(this.btnCelToFar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 130);
            this.Controls.Add(this.btnCelToFar);
            this.Controls.Add(this.btnFarToCel);
            this.Controls.Add(this.txtCelsius);
            this.Controls.Add(this.lblCelsiusDisplay2);
            this.Controls.Add(this.lblFarenheit);
            this.Controls.Add(this.lblFarenheitDisplay2);
            this.Controls.Add(this.lblFarenheitDisplay);
            this.Controls.Add(this.txtFarenheit);
            this.Controls.Add(this.lblCelsius);
            this.Controls.Add(this.lblCelsiusDisplay);
            this.Name = "Form1";
            this.Text = "Celsius to Farenheit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCelsiusDisplay;
        private System.Windows.Forms.Label lblCelsius;
        private System.Windows.Forms.TextBox txtFarenheit;
        private System.Windows.Forms.Label lblFarenheitDisplay;
        private System.Windows.Forms.Label lblFarenheitDisplay2;
        private System.Windows.Forms.Label lblFarenheit;
        private System.Windows.Forms.Label lblCelsiusDisplay2;
        private System.Windows.Forms.TextBox txtCelsius;
        private System.Windows.Forms.Button btnFarToCel;
        private System.Windows.Forms.Button btnCelToFar;
    }
}