using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetRequestExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;
            string currLine = "";
            Stream tempStream;
            StreamReader tempStreamReader;
            WebRequest webReq;
            WebProxy webProx;

            if (String.IsNullOrEmpty(url) == false)
            {
                webReq = WebRequest.Create(url);
                webProx = new WebProxy(@"http://127.0.0.1", 80);

                webProx.BypassProxyOnLocal = true;
                webReq.Proxy = webProx;

                tempStream = webReq.GetResponse().GetResponseStream();
                tempStreamReader = new StreamReader(tempStream);

                while (tempStreamReader.EndOfStream == false)
                {
                    currLine += tempStreamReader.ReadLine();
                    currLine += "\n";
                }

                lblDisplay.Text = currLine;

            }
            
        }
    }
}
