/** Who_is_that_Actor
* This program will allow a user to put in two movies and
* get back a list of actors/actresses/staff members that 
* were involved in both movies.
*
* This was uploaded to Katianie.com, Feel free to use this
* code and share it with others, Just give me credit ^_^.
*
* Eddie O'Hagan
* Copyright © 2013 Katianie.com
*/
using System;
using System.Collections;
using System.Windows.Forms;

namespace Who_is_that_Actor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

			pbLoadingBar.Visible = true;

            // Set Minimum to 0 so bar is empty.
            pbLoadingBar.Minimum = 0;
			
            // Set Maximum to the total number of stages/checkpoints.
            pbLoadingBar.Maximum = 9;
			
            // Set the initial value of the ProgressBar.
            pbLoadingBar.Value = 0;
			
            // Set the Step property to a value of 1 to represent each file being copied.
            pbLoadingBar.Step = 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IMDBReader imdbReader = null;
            ArrayList actorsInCommon = null;

            // Set the initial value of the ProgressBar.
            pbLoadingBar.Value = 0;
            //Reset the text window
            rtbDisplay.Text = "";

            if(string.IsNullOrEmpty(txtFirst.Text) == true)
            {
                MessageBox.Show(this, "Please enter a value for the first movie");
                return;
            }

            if (string.IsNullOrEmpty(txtSecond.Text) == true)
            {
                MessageBox.Show(this, "Please enter a value for the second movie");
                return;
            }

            if (txtFirst == txtSecond)
            {
                MessageBox.Show(this, "Movie's cannot be the same.");
                return;
            }

            try
            {
                //Attempt to read IMDB pages
                imdbReader = new IMDBReader(this, txtFirst.Text.Trim(), txtSecond.Text.Trim());
            }
            catch (Exception)
            {
                //There was an error but the user has already been told so.
            }

            if(imdbReader != null)
            {
                pbLoadingBar.PerformStep();

                actorsInCommon = imdbReader.GetActorsInCommon();
            }
            
            if(actorsInCommon != null)
            {
                if (actorsInCommon.Count == 0)
                {
                    rtbDisplay.Text = "No Actors/Actresses in common";
                }

                for (int i = 0; i < actorsInCommon.Count; i++)
                {
                    rtbDisplay.Text += actorsInCommon[i] + "\n";
                }
            }

        }

        public ProgressBar GetLoadingBar()
        {
            return pbLoadingBar;
        }

        public CheckBox GetFilmAndProdCheckBox()
        {
            return chkFilmAndProd;
        }
    }
}
