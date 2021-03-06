﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CelciusToFarenheit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFarToCel_Click(object sender, EventArgs e)
        {
            if (txtFarenheit.Text != null)
            {
                double currFar = double.Parse(txtFarenheit.Text);
                double celCalc = ((5.0 / 9.0) * (currFar - 32));

                lblCelsius.Text = celCalc.ToString();
            }
        }

        private void btnCelToFar_Click(object sender, EventArgs e)
        {
            if (txtCelsius.Text != null)
            {
                double currCel = double.Parse(txtCelsius.Text);
                double farCalc = ((9.0 / 5.0) * currCel + 32);

                lblFarenheit.Text = farCalc.ToString();
            }
        }

    }
}
