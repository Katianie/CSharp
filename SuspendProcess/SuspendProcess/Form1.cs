using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace SuspendProcess
{
    /// <summary>
    /// Class is responsible for the entry point of this WinForm application.
    /// </summary>
    public partial class Form1 : Form
    {
        //Used to set the button text from a different thread.
        delegate void SetTextCallback(string text);

        //Used to enable/disable button from a different thread.
        delegate void SetEnabledCallback(bool text);

        public const string APPLICATION_NAME = "GTA5";
        public const int SUSSPEND_WAIT_TIME_IN_SECONDS = 10;

        private static System.Timers.Timer myTimer;
        private DateTime myStartTime;
        private Process[] myProcesses;

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        public static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        public static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Constructor for initializing the main WinForm.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            myTimer.Interval = 1000; //Call OnTimedEvent every 1 second.
        }

        /// <summary>
        /// Called when the main button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Additional data.</param>
        private void btnMain_Click(object sender, EventArgs e)
        {
            if (btnMain.Enabled == true)
            {
                //Find any and all processes corresponding to APPLICATION_NAME.
                myProcesses = Process.GetProcessesByName(APPLICATION_NAME);

                //Disable the button.
                EnableButton(false);
                //btnMain.Enabled = false;
                //this.Controls.Add(btnMain);

                //Suspend all corresponding processes.
                foreach (Process currProcess in myProcesses)
                {
                    SuspendProcess(currProcess);
                }

                //Start the timer and keep the process suspended for x amount of time.
                StartTimer();
            }
        }

        /// <summary>
        /// Called by a timer every <c>myTimer.Interval</c> milliseconds.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Additional data.</param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            TimeSpan timeElapsed = DateTime.Now - myStartTime;

            this.SetButtonText("Resume in " + (SUSSPEND_WAIT_TIME_IN_SECONDS - timeElapsed.Seconds) + " seconds.");

            //Kill timer after x seconds have passed.
            if(timeElapsed.Seconds >= SUSSPEND_WAIT_TIME_IN_SECONDS)
            {
                StopTimer();

                //Timer has stopped after x seconds, now resume processes.
                ResumeAllProcesses(myProcesses);

                //btnMain.Enabled = true;
                EnableButton(true);
                this.SetButtonText("Suspend Process for 10 Seconds.");
            }
        }

        /// <summary>
        /// Enables/Disables the button from being able to be pressed.
        /// </summary>
        /// <param name="shouldEnable">True if the button should be click-able, false otherwise.</param>
        private void EnableButton(bool shouldEnable)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.btnMain.InvokeRequired == true)
            {
                SetEnabledCallback theCallback = new SetEnabledCallback(EnableButton);
                this.Invoke(theCallback, new object[] { shouldEnable });
            }
            else
            {
                this.btnMain.Enabled = shouldEnable;
            }
        }

        /// <summary>
        /// Resumes all of the provided processes.
        /// </summary>
        /// <param name="processes">An array of processes to resume.</param>
        public void ResumeAllProcesses(Process[] processes)
        {
            if (processes != null)
            {
                //Resume all processes.
                foreach (Process currProcess in myProcesses)
                {
                    ResumeProcess(currProcess);
                }
            }
        }

        /// <summary>
        /// Resume the provided process.
        /// </summary>
        /// <param name="pid">The process ID of the corresponding process to resume.</param>
        public static void ResumeProcess(int pid)
        {
            Process theProcess = Process.GetProcessById(pid);

            ResumeProcess(theProcess);
        }

        /// <summary>
        /// Resumes the provided process.
        /// </summary>
        /// <param name="theProcess">The process to resume.</param>
        public static void ResumeProcess(Process theProcess)
        {
            if (theProcess != null && string.IsNullOrEmpty(theProcess.ProcessName) == false)
            {
                foreach (ProcessThread currProcessThread in theProcess.Threads)
                {
                    IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)currProcessThread.Id);

                    if (pOpenThread != IntPtr.Zero)
                    {
                        int suspendCount = 0;

                        do
                        {
                            suspendCount = ResumeThread(pOpenThread);
                        }
                        while (suspendCount > 0);

                        CloseHandle(pOpenThread);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the text of the main button. This also allows for the text to be set from
        /// outside of the main thread.
        /// </summary>
        /// <param name="text">The text to set the button to.</param>
        private void SetButtonText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.btnMain.InvokeRequired == true)
            {
                SetTextCallback theCallback = new SetTextCallback(SetButtonText);
                this.Invoke(theCallback, new object[] { text });
            }
            else
            {
                this.btnMain.Text = text;
            }
        }

        /// <summary>
        /// Called when we want to start the timer and record the start time.
        /// </summary>
        public void StartTimer()
        {
            //Start the timer.
            myTimer.Enabled = true;
            myStartTime = DateTime.Now;
        }

        /// <summary>
        /// Called when we want to stop the timer.
        /// </summary>
        public void StopTimer()
        {
            myTimer.Enabled = false;
        }

        /// <summary>
        /// Suspends the process corresponding to the provided process ID.
        /// </summary>
        /// <param name="pid">The process ID of the corresponding process to suspend.</param>
        public static void SuspendProcess(int pid)
        {
            Process theProcess = Process.GetProcessById(pid);

            SuspendProcess(theProcess);
        }

        /// <summary>
        /// Suspends the provided process.
        /// </summary>
        /// <param name="theProcess">The process to suspend.</param>
        public static void SuspendProcess(Process theProcess)
        {
            if (theProcess != null && string.IsNullOrEmpty(theProcess.ProcessName) == false)
            {
                foreach (ProcessThread currProcessThread in theProcess.Threads)
                {
                    IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)currProcessThread.Id);

                    if (pOpenThread != IntPtr.Zero)
                    {
                        SuspendThread(pOpenThread);

                        CloseHandle(pOpenThread);
                    }
                }
            }
        }

    }
}
