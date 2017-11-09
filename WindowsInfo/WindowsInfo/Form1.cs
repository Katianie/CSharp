using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsInfo
{
    public partial class frmMain : Form
    {
        public const int NUM_INFO_ITEMS = 29;
        public const int NUM_DOTS_FOR_STATUS = 15;
        public const int MILISECONDS_BETWEEN_STATUS_REFRESH = 200;
        private BackgroundWorker myLoaderThread;
        private BackgroundWorker myStatusBarThread;
        private Info[] myTotalInfo;
        private bool myIsLoading;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            stsStatusInfoLabel.Text = "Initializing...";
            stsStatusInfo.Refresh();

            //Called by windows when the Form is first shown.
            myTotalInfo = new Info[NUM_INFO_ITEMS];

            myTotalInfo[0] = new AccountInfo(); //slow
            myTotalInfo[1] = new BIOSInfo();
            myTotalInfo[2] = new BootConfigurationInfo();
            myTotalInfo[3] = new CodecFileInfo();
            myTotalInfo[4] = new ComputerSystemInfo();
            myTotalInfo[5] = new ComputerSystemProcessorInfo();
            myTotalInfo[6] = new DirectoryInfo(); //slow
            myTotalInfo[7] = new DesktopInfo();
            myTotalInfo[8] = new DesktopMonitorInfo();
            myTotalInfo[9] = new DiskPartitionInfo();
            myTotalInfo[10] = new EnvironmentInfo();
            myTotalInfo[11] = new LoggedOnUserInfo();
            myTotalInfo[12] = new LogonSessionInfo();
            myTotalInfo[13] = new OperatingSystemInfo();
            myTotalInfo[14] = new PageFileInfo();
            myTotalInfo[15] = new PageFileUsageInfo();
            myTotalInfo[16] = new PageFileSettingInfo();
            myTotalInfo[17] = new ProcessesInfo();
            myTotalInfo[18] = new RegistryInfo();
            myTotalInfo[19] = new SessionInfo();
            myTotalInfo[20] = new SystemAccountInfo();
            myTotalInfo[21] = new SystemBIOSInfo();
            myTotalInfo[22] = new SystemBootConfigurationInfo();
            myTotalInfo[23] = new SystemDriverInfo();
            myTotalInfo[24] = new SystemProcessesInfo();
            myTotalInfo[25] = new SystemUsersInfo();
            myTotalInfo[26] = new UserAccountInfo(); //slow
            myTotalInfo[27] = new VideoConfigurationInfo();
            myTotalInfo[28] = new VideoControllerInfo();

            //Set default values for GUI Components.
            prbLoadingBar.Value = 0;
            prbLoadingBar.Minimum = 0;
            prbLoadingBar.Maximum = NUM_INFO_ITEMS;

            //Put the loading of info on a background thread so we can still update the GUI.
            myLoaderThread = new BackgroundWorker();
            myLoaderThread.WorkerReportsProgress = true;
            myLoaderThread.WorkerSupportsCancellation = true;
            myLoaderThread.ProgressChanged += OnLoaderThreadUpdate;
            myLoaderThread.DoWork += OnLoadInfo;
            myLoaderThread.RunWorkerCompleted += OnLoaderCompleted;

            myStatusBarThread = new BackgroundWorker();
            myStatusBarThread.WorkerReportsProgress = true;
            myStatusBarThread.WorkerSupportsCancellation = true;
            myStatusBarThread.ProgressChanged += OnStatusBarThreadUpdate;
            myStatusBarThread.DoWork += OnUpdateStatusBar;

            myIsLoading = false;

            stsStatusInfoLabel.Text = "Ready!";
            stsStatusInfo.Refresh();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            myLoaderThread.CancelAsync();
            myStatusBarThread.CancelAsync();

            for(int currInfoIndex = 0; currInfoIndex < NUM_INFO_ITEMS; currInfoIndex++)
            {
                myTotalInfo[currInfoIndex].Dispose();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;

            if (myIsLoading == false)
            {
                myLoaderThread.RunWorkerAsync();
                myStatusBarThread.RunWorkerAsync();
                myIsLoading = true;
            }
        }

        //Called when the progress bar should be updated.
        private void OnLoaderThreadUpdate(object sender, ProgressChangedEventArgs e)
        {
            prbLoadingBar.Value = e.ProgressPercentage;
            txtOutput.Text += myTotalInfo[prbLoadingBar.Value - 1];
        }

        //Called by the Loader Thread when the user presses the GO button.
        private void OnLoadInfo(object sender, DoWorkEventArgs eventArg)
        {
            try
            {
                for (int i = 0; i < myTotalInfo.Length && myLoaderThread.CancellationPending == false; i++)
                {
                    //Go through each class and load its data.
                    myTotalInfo[i].LoadData();
                    
                    //Update the progress bar.
                    myLoaderThread.ReportProgress(i + 1);
                }

                if(myLoaderThread.CancellationPending == true)
                {
                    eventArg.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                //Pokémon exception handling.
                MessageBox.Show(string.Format("Error attempting to load data:{0}", ex.Message));
            }

            btnGo.Enabled = true;
        }

        private void OnLoaderCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Done loading so set flag.
            myIsLoading = false;
            btnGo.Enabled = true;

            //Write the output to a file.
            WriteInfoToFile();
        }

        private void OnStatusBarThreadUpdate(object sender, ProgressChangedEventArgs e)
        {
            if(myIsLoading == true)
            {
                if (e.ProgressPercentage == 0)
                {
                    stsStatusInfoLabel.Text = "Loading";
                }
                else
                {
                    //Append a dot every so often so the user can visually see the GUI updating in real time.
                    for (int i = 0; i <= e.ProgressPercentage; i++)
                    {
                        stsStatusInfoLabel.Text += ".";
                    }
                }
            }
            else
            {
                stsStatusInfoLabel.Text = "Complete!";
            }

            stsStatusInfo.Refresh();
        }

        private void OnUpdateStatusBar(object sender, DoWorkEventArgs e)
        {
            for (int currDotNum = 0; myLoaderThread.IsBusy == true; currDotNum++)
            {
                if (currDotNum != 0 && currDotNum % NUM_DOTS_FOR_STATUS == 0)
                {
                    currDotNum = 0;
                }

                myStatusBarThread.ReportProgress(currDotNum);

                //Wait (200) milliseconds on status thread.
                Thread.Sleep(MILISECONDS_BETWEEN_STATUS_REFRESH);
            }
        }

        ///Functions
        public void WriteInfoToFile()
        {
            //Binary writer is faster.
            using (BinaryWriter writer = new BinaryWriter(File.Open("output.txt", FileMode.OpenOrCreate)))
            {
                writer.Write(txtOutput.Text);
            }
        }
    }
}
