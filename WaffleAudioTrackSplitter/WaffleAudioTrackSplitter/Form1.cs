using System;
using System.Text;
using System.Windows.Forms;

namespace WaffleAudioTrackSplitter
{
    /// <summary>
    /// Class is responsible for the entry point of this WinForm application.
    /// </summary>
    public partial class frmMain : Form
    {
        private static AudioSplitter myAudioSplitter;
        private static TrackTextParser myTrackTextParser;

        private delegate void UpdateLoadingBarDelegate(uint val);

        /// <summary>
        /// Constructor for initializing the WinForm.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the application first loads.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Additional data.</param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            StringBuilder textBoxExampleStr = new StringBuilder();

            textBoxExampleStr.AppendLine("<Start Time> <Track Name>");
            textBoxExampleStr.AppendLine("0:00 Party Animals - Have you ever been mellow");
            textBoxExampleStr.AppendLine("3:04 DJ Paul Elstak - Don't leave me alone");
            textBoxExampleStr.AppendLine("6:33 Love Decade - See me jumping");
            textBoxExampleStr.AppendLine("10:27 Dominion - Salted Popcorn");
            textBoxExampleStr.AppendLine("15:20 DJ Omar Santana - Time To Motivate(Happy Mix)");
            textBoxExampleStr.AppendLine("20:11 Cherrish - Burning Up");
            textBoxExampleStr.AppendLine("24:38 Elips - Don't try");
            textBoxExampleStr.AppendLine("28:35 Pulp Shock - Far away");
            textBoxExampleStr.AppendLine("32:14 Rob's Project - Loving you");
            textBoxExampleStr.AppendLine("35:45 Q - Tex - Can't get enough");
            textBoxExampleStr.AppendLine("39:38 DJ Promo - Sing it louder");
            textBoxExampleStr.AppendLine("43:54 Profound - 4 O'clock");
            textBoxExampleStr.AppendLine("49:17 Creasemaster & Slamdog - Bump The Bass");
            textBoxExampleStr.AppendLine("53:40 Dougal & Eruption - Partytime");
            textBoxExampleStr.AppendLine("59:16 Cixx - Clap Your Hands");
            textBoxExampleStr.AppendLine("1:04:42 The right place - Big Deal");

            txtTrackText.Text = textBoxExampleStr.ToString();
        }

        /// <summary>
        /// Called when the "start split" button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Additional data.</param>
        private void btnStartSplit_Click(object sender, EventArgs e)
        {
            //Ensure all the user input is provided and valid.
            if(ValidateUserInput() == true)
            {
                //Disable the button now that we are starting the splitting.
                btnStartSplit.Enabled = false;

                //Start parsing the track text user input.
                myTrackTextParser = new TrackTextParser(txtTrackText.Text);

                //Ensure the tracks were successfully parsed.
                if (myTrackTextParser.ParsedTrackNames != null && myTrackTextParser.ParsedTrackStartTimes != null)
                {
                    if(myTrackTextParser.ParsedTrackNames.Count == myTrackTextParser.ParsedTrackStartTimes.Count)
                    {
                        myAudioSplitter = new AudioSplitter(txtAudoFilePath.Text, myTrackTextParser.ParsedTrackNames, myTrackTextParser.ParsedTrackStartTimes);
                        myAudioSplitter.OnProcessCompleted += OnProcessCompleteCallback;

                        myAudioSplitter.StartSplitting();
                    }
                    else
                    {
                        MessageBox.Show("Error: The number of tracks must match the number of start times.");

                        //Re-enable the start button.
                        btnStartSplit.Enabled = true;
                    } 
                }
            }
        }

        /// <summary>
        /// Called when the browse button is clicked. This allows the user to specify a .MP3 file
        /// to be processed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Additional data.</param>
        private void btnBrowseForAudioFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Browse audio file to split";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAudoFilePath.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Ensures the file path to the main file and the track text 
        /// is valid. If not valid, Presents the user message box 
        /// letting them know there is something wrong.
        /// </summary>
        /// <returns>True if all user input is valid, false otherwise.</returns>
        private bool ValidateUserInput()
        {
            char[] invalidCharacters;

            if(string.IsNullOrEmpty(txtTrackText.Text) == true)
            {
                MessageBox.Show("Error: You must provide start times and track names.");
                return false;
            }
            else if(string.IsNullOrEmpty(txtAudoFilePath.Text) == true || txtAudoFilePath.Text.Contains(".mp3") == false)
            {
                MessageBox.Show("Error: You must provide an .mp3 file to split.");
                return false;
            }
            else
            {
                invalidCharacters = new char[] { '!', '?', '@', '#', '%', '^', '*', '<', '>' };
                if (txtTrackText.Text.IndexOfAny(invalidCharacters) != -1)
                {
                    MessageBox.Show("Error: Track names cannot contain invalid characters:\n" + new string(invalidCharacters));
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Delegate called each time a track is produced, this notifies the progrss bar
        /// to update its current value.
        /// </summary>
        private void OnProcessCompleteCallback()
        {
            double percentile = 0.0;
            if(myAudioSplitter != null)
            {
                percentile = (double)myAudioSplitter.NumTracksProcessed / (double)myAudioSplitter.NumTracks;

                //Notifies the progress bar to call a delegate function. This delegate then updates the value of the component.
                prgLoadingBar.Invoke(new UpdateLoadingBarDelegate(UpdateLoadingBar), (uint)(percentile * 100));
            }
        }

        /// <summary>
        /// Directly modifies the progress bar's current value. Also re-enables the start split button
        /// once the progress bar has reached 100%.
        /// </summary>
        /// <param name="value">The value to update the progress bar with.</param>
        private void UpdateLoadingBar(uint value)
        {
            prgLoadingBar.Value = (int)value;

            if (value >= 100U)
            {
                //Re-enable the button since we are done splitting.
                btnStartSplit.Enabled = true;
            }
        }

    }
}
