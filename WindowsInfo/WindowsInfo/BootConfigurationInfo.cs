using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class BootConfigurationInfo : Info
    {
        public BootConfigurationInfo() : base()
        {
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BootConfiguration");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]           = Utils.Query("Caption", queryObject);
                currDictionary["Description"]       = Utils.Query("Description", queryObject);
                currDictionary["SettingID"]         = Utils.Query("SettingID", queryObject);
                currDictionary["BootDirectory"]     = Utils.Query("BootDirectory", queryObject);
                currDictionary["ConfigurationPath"] = Utils.Query("ConfigurationPath", queryObject);
                currDictionary["LastDrive"]         = Utils.Query("LastDrive", queryObject);
                currDictionary["Name"]              = Utils.Query("Name", queryObject);
                currDictionary["ScratchDirectory"]  = Utils.Query("ScratchDirectory", queryObject);
                currDictionary["TempDirectory"]     = Utils.Query("TempDirectory", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
