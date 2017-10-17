using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace WindowsInfo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Info[] allTheInfo;

            prbLoadingBar.Maximum = 9;
            prbLoadingBar.Minimum = 0;

            //Load all the information.
            allTheInfo = this.LoadAllInfo();

            //Write the information to the text box.
            txtOutput.Clear();
            for (int currInfoIndex = 0; currInfoIndex < allTheInfo.Length; currInfoIndex++)
            {
                txtOutput.Text += allTheInfo[currInfoIndex].ToString() + '\n';
            }

            //If an output file exists, write to it.
            if(File.Exists("output.txt") == true)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("output.txt", FileMode.Open)))
                {
                    writer.Write(txtOutput.Text);
                }
            }
        }

        public Info[] LoadAllInfo()
        {
            Info[] allTheInfo = new Info[9];

            allTheInfo[0] = new AccountInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[1] = new BootConfigurationInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[2] = new CodecFileInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[3] = new ComputerSystemInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[4] = new DirectoryInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[5] = new DesktopInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[6] = new OperatingSystemInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[7] = new SystemDriverInfo();
            prbLoadingBar.PerformStep();

            allTheInfo[8] = new SystemProcessesInfo();
            prbLoadingBar.PerformStep();

            return allTheInfo;
        }
    }
}
