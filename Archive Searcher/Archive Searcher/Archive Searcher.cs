using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Archive_Searcher
{
    public partial class frmArchiveSearcher : Form
    {
        //Search Types
        public const int SPECIFIC_SEARCH = 1; //Look for exactly what the user typed
        public const int CONTAINS_SEARCH = 2; //Look to see if that word appears anywhere in the file

        //Other Constants
        public const int MAX_LINE_COUNT = 180; //I made this more than 200, The program stack overflowed
        public const string DIRECTORY_LISTING = "Katianie Archive Search"; //This is the folder where the user has put their archive files

        private static int mySearchType;
        private static int myCurrentLineNum;
        private static string[] myFilePaths;

        private string myCurrentDrive; //The first occurrence the search found the specified text in (ex: hd1.txt)
        private string myCurrentFilePath; //The full file path of the file talked about above.
        private bool myIgnoreCase;

        public frmArchiveSearcher()
        {
            mySearchType = 0;
            myCurrentLineNum = 0;
            myIgnoreCase = false;

            InitializeComponent();
        }

        private void frmArchiveSearcher_Load(object sender, EventArgs e)
        {
            String path = Directory.GetCurrentDirectory() + @"\" + DIRECTORY_LISTING;

            myFilePaths = Directory.GetFiles(path);
        }

        private void rbtnContains_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton containsButton = sender as RadioButton;

            if (containsButton != null && containsButton.Checked)
            {
                mySearchType = CONTAINS_SEARCH;
            }
        }

        private void rbtnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton specificButton = sender as RadioButton;

            if (specificButton != null && specificButton.Checked)
            {
                mySearchType = SPECIFIC_SEARCH;
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            String theSearchString = txtSearchBar.Text;
            String currentLine;
            StreamReader sr;
            int lastIndex;

            //Reset the console before we write to it in case theres stuff from last search
            txtConsole.Clear();
            myCurrentLineNum = 0;

            if (theSearchString == null)
            {
                return;
            }
            
            //Go through all of the files in a directory
            foreach (string currFilePath in myFilePaths)
            {
                try
                {
                    sr = new StreamReader(currFilePath);

                    while (!sr.EndOfStream)
                    {
                        currentLine = sr.ReadLine();

                        if (mySearchType == SPECIFIC_SEARCH)
                        {
                            //To ignore case I take the all lowercase versions of both strings and compare them
                            if(myIgnoreCase)
                            {
                                if ( (currentLine.ToLower()).Equals( (theSearchString.ToLower()) ) )
                                {
                                    myCurrentFilePath = string.Copy(currentLine);

                                    //We only want the last part of the path.
                                    lastIndex = currFilePath.LastIndexOf(@"\");
                                    myCurrentDrive = currFilePath.Substring(lastIndex + 1);

                                    myCurrentLineNum++;

                                    if (myCurrentLineNum <= MAX_LINE_COUNT)
                                    {
                                        txtConsole.AppendText(myCurrentLineNum + ": " + "\t|Archive Name: " + myCurrentDrive + "\t|Full Path: " + myCurrentFilePath + "|\n");
                                    }
                                }
                            }
                            else
                            {
                                if (currentLine.Equals(theSearchString))
                                {
                                    myCurrentFilePath = string.Copy(currentLine);

                                    //We only want the last part of the path.
                                    lastIndex = currFilePath.LastIndexOf(@"\");
                                    myCurrentDrive = currFilePath.Substring(lastIndex + 1);

                                    myCurrentLineNum++;

                                    if (myCurrentLineNum <= MAX_LINE_COUNT)
                                    {
                                        txtConsole.AppendText(myCurrentLineNum + ": " + "\t|Archive Name: " + myCurrentDrive + "\t|Full Path: " + myCurrentFilePath + "|\n");
                                    }
                                }
                            }
                           
                        }
                        else if (mySearchType == CONTAINS_SEARCH)
                        {
                            //To ignore case I take the all lowercase versions of both strings and compare them
                            if(myIgnoreCase)
                            {
                                if ( (currentLine.ToLower()).Contains( (theSearchString.ToLower()) ) )
                                {
                                    myCurrentFilePath = string.Copy(currentLine);

                                    //We only want the last part of the path.
                                    lastIndex = currFilePath.LastIndexOf(@"\");
                                    myCurrentDrive = currFilePath.Substring(lastIndex + 1);

                                    myCurrentLineNum++;

                                    if (myCurrentLineNum <= MAX_LINE_COUNT)
                                    {
                                        txtConsole.AppendText(myCurrentLineNum + ": " + "\t|Archive Name: " + myCurrentDrive + "\t|Full Path: " + myCurrentFilePath + "|\n");
                                    }
                                }
                            }
                            else
                            {
                                if (currentLine.Contains(theSearchString))
                                {
                                    myCurrentFilePath = string.Copy(currentLine);

                                    //We only want the last part of the path.
                                    lastIndex = currFilePath.LastIndexOf(@"\");
                                    myCurrentDrive = currFilePath.Substring(lastIndex + 1);

                                    myCurrentLineNum++;

                                    if (myCurrentLineNum <= MAX_LINE_COUNT)
                                    {
                                        txtConsole.AppendText(myCurrentLineNum + ": " + "\t|Archive Name: " + myCurrentDrive + "\t|Full Path: " + myCurrentFilePath + "|\n");
                                    }
                                }

                            }

                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                }

            }//End foreach

            txtConsole.AppendText("====================================================FINISHED SEARCHING====================================================");
        }

        private void chkCase_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox theCheckBox = sender as CheckBox;

            if(theCheckBox != null)
            {
                myIgnoreCase = theCheckBox.Checked;
            }
        }


    }

}
