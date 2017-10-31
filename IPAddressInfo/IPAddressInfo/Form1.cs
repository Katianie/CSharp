using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IPAddressInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string ipWebsite = "http://ipinfo.io/";
            string ipAddress = txtIPAddress.Text;
            IPInfo ipInfo = FindIPInfo(ipWebsite, ipAddress);

            if(ipInfo != null)
            {
                //Clear any previous text
                txtInfo.Clear();

                //Get the IP Address in question.
                txtInfo.AppendText("IP Address: " + ipInfo.IPAddress);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Hostname if available.
                txtInfo.AppendText("Hostname: " + ipInfo.Hostname);
                txtInfo.AppendText(Environment.NewLine);

                //Get the City the IP resides in.
                txtInfo.AppendText("City: " + ipInfo.City);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Region the IP resides in.
                txtInfo.AppendText("Region: " + ipInfo.Region);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Country the IP resides in.
                txtInfo.AppendText("Country: " + ipInfo.Country);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Latitude and Longitude the IP resides in.
                txtInfo.AppendText("Latitude and Longitude: " + ipInfo.LatitudeAndLongitude);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Organization associated with the IP Address.
                txtInfo.AppendText("Organization: " + ipInfo.Organization);
                txtInfo.AppendText(Environment.NewLine);

                //Get the Zip/Postal Code the IP resides in.
                txtInfo.AppendText("Zip/Postal Code: " + ipInfo.ZipCode);
                txtInfo.AppendText(Environment.NewLine);
            }
        }

        public static IPInfo FindIPInfo(string website, string ipAddress)
        {
            WebClient ipWebClient = new WebClient();
            string ipWebInfoStr = string.Empty;
            
            if (ipWebClient != null)
            {
                try
                {
                    ipWebInfoStr = ipWebClient.DownloadString(website + ipAddress);
                    ipWebClient.Dispose();

                    if (ipWebInfoStr == null || ipWebInfoStr == string.Empty)
                    {
                        MessageBox.Show("Error: Failed to get IP Info.");
                        return null;
                    }
                }
                catch (ArgumentNullException exception)
                {
                    MessageBox.Show("Error: Failed to read User input:" + exception.Message);
                    return null;
                }
                catch (WebException exception)
                {
                    MessageBox.Show("Error: Failed to access IP Query website:" + exception.Message);
                    return null;
                }
                catch (NotSupportedException exception)
                {
                    MessageBox.Show("Error: Operation is not supported:" + exception.Message);
                    return null;
                }

                return JsonConvert.DeserializeObject<IPInfo>(ipWebInfoStr);
            }

            return null;
        }
    }
}
