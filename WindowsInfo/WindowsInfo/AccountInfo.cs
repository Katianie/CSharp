using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class AccountInfo : Info
    {
        public AccountInfo() : base()
        {
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Account");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]       = Utils.Query("Caption", queryObject);
                currDictionary["Description"]   = Utils.Query("Description", queryObject);
                currDictionary["Domain"]        = Utils.Query("Domain", queryObject);
                currDictionary["InstallDate"]   = Utils.Query("InstallDate", queryObject);
                currDictionary["LocalAccount"]  = Utils.Query("LocalAccount", queryObject);
                currDictionary["Name"]          = Utils.Query("Name", queryObject);
                currDictionary["SID"]           = Utils.Query("SID", queryObject);
                currDictionary["SIDType"]       = Utils.Query("SIDType", queryObject);
                currDictionary["Status"]        = Utils.Query("Status", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
