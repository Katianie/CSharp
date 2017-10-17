using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class SystemDriverInfo : Info
    {
        public SystemDriverInfo() : base()
        {
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["AcceptPause"]             = Utils.Query("AcceptPause", queryObject);
                currDictionary["AcceptStop"]              = Utils.Query("AcceptStop", queryObject);
                currDictionary["Caption"]                 = Utils.Query("Caption", queryObject);
                currDictionary["CreationClassName"]       = Utils.Query("CreationClassName", queryObject);
                currDictionary["Description"]             = Utils.Query("Description", queryObject);
                currDictionary["DesktopInteract"]         = Utils.Query("DesktopInteract", queryObject);
                currDictionary["DisplayName"]             = Utils.Query("DisplayName", queryObject);
                currDictionary["ErrorControl"]            = Utils.Query("ErrorControl", queryObject);
                currDictionary["ExitCode"]                = Utils.Query("ExitCode", queryObject);
                currDictionary["InstallDate"]             = Utils.Query("InstallDate", queryObject);
                currDictionary["Name"]                    = Utils.Query("Name", queryObject);
                currDictionary["PathName"]                = Utils.Query("PathName", queryObject);
                currDictionary["ServiceSpecificExitCode"] = Utils.Query("ServiceSpecificExitCode", queryObject);
                currDictionary["ServiceType"]             = Utils.Query("ServiceType", queryObject);
                currDictionary["Started"]                 = Utils.Query("Started", queryObject);
                currDictionary["StartMode"]               = Utils.Query("StartMode", queryObject);
                currDictionary["StartName"]               = Utils.Query("StartName", queryObject);
                currDictionary["State"]                   = Utils.Query("State", queryObject);
                currDictionary["Status"]                  = Utils.Query("Status", queryObject);
                currDictionary["SystemCreationClassName"] = Utils.Query("SystemCreationClassName", queryObject);
                currDictionary["SystemName"]              = Utils.Query("SystemName", queryObject);
                currDictionary["TagId"]                   = Utils.Query("TagId", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
