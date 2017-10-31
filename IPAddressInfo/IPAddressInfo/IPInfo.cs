using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IPAddressInfo
{
    public class IPInfo
    {
        private string myIPAddress;
        private string myHostname;
        private string myCity;
        private string myRegion;
        private string myCountry;
        private string myLatitudeAndLongitude;
        private string myOrganization;
        private string myZipCode;

        public IPInfo()
        {
            myIPAddress = string.Empty;
            myHostname = string.Empty;
            myCity = string.Empty;
            myRegion = string.Empty;
            myCountry = string.Empty;
            myLatitudeAndLongitude = string.Empty;
            myOrganization = string.Empty;
            myZipCode = string.Empty;
        }

        public IPInfo(string ipAddress, string hostname, string city, string region, string country, string latitudeAndLongitude, string organization, string zipCode)
        {
            myIPAddress = ipAddress;
            myHostname = hostname;
            myCity = city;
            myRegion = region;
            myCountry = country;
            myLatitudeAndLongitude = latitudeAndLongitude;
            myOrganization = organization;
            myZipCode = zipCode;
        }

        [JsonProperty("ip")]
        public string IPAddress
        {
            get
            {
                return myIPAddress;
            }
            set
            {
                myIPAddress = value;
            }
        }

        [JsonProperty("hostname")]
        public string Hostname
        {
            get
            {
                return myHostname;
            }
            set
            {
                myHostname = value;
            }
        }

        [JsonProperty("city")]
        public string City
        {
            get
            {
                return myCity;
            }
            set
            {
                myCity = value;
            }
        }

        [JsonProperty("region")]
        public string Region
        {
            get
            {
                return myRegion;
            }
            set
            {
                myRegion = value;
            }
        }

        [JsonProperty("country")]
        public string Country
        {
            get
            {
                return myCountry;
            }
            set
            {
                myCountry = value;
            }
        }

        [JsonProperty("loc")]
        public string LatitudeAndLongitude
        {
            get
            {
                return myLatitudeAndLongitude;
            }
            set
            {
                myLatitudeAndLongitude = value;
            }
        }

        [JsonProperty("org")]
        public string Organization
        {
            get
            {
                return myOrganization;
            }
            set
            {
                myOrganization = value;
            }
        }

        [JsonProperty("postal")]
        public string PostalCode
        {
            get
            {
                return myZipCode;
            }
            set
            {
                myZipCode = value;
            }
        }

        //Here in New York, we call it a Zip code.
        public string ZipCode
        {
            get
            {
                return myZipCode;
            }
            set
            {
                myZipCode = value;
            }
        }

        public override string ToString()
        {
            string retVal = string.Empty;

            retVal += "IP Address: " + myIPAddress + "\n";
            retVal += "\nHostname: " + myHostname + "\n";
            retVal += "\nCity: " + myCity + "\n";
            retVal += "\nRegion: " + myRegion + "\n";
            retVal += "\nCountry: " + myCountry + "\n";
            retVal += "\nLatitude and Longitude: " + myLatitudeAndLongitude + "\n";
            retVal += "\nOrganization: " + myOrganization + "\n";
            retVal += "\nZip/Postal Code: " + myZipCode + "\n";

            return retVal;
        }
    }
}
