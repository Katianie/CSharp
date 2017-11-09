using System;
using System.Collections;
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

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SystemDriver");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["AcceptPause"]             = Utils.Query("AcceptPause", myWMIQueryObject);
                currDictionary["AcceptStop"]              = Utils.Query("AcceptStop", myWMIQueryObject);
                currDictionary["Caption"]                 = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["CreationClassName"]       = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["Description"]             = Utils.Query("Description", myWMIQueryObject);
                currDictionary["DesktopInteract"]         = Utils.Query("DesktopInteract", myWMIQueryObject);
                currDictionary["DisplayName"]             = Utils.Query("DisplayName", myWMIQueryObject);
                currDictionary["ErrorControl"]            = Utils.Query("ErrorControl", myWMIQueryObject);
                currDictionary["ExitCode"]                = Utils.Query("ExitCode", myWMIQueryObject);
                currDictionary["InstallDate"]             = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["Name"]                    = Utils.Query("Name", myWMIQueryObject);
                currDictionary["PathName"]                = Utils.Query("PathName", myWMIQueryObject);
                currDictionary["ServiceSpecificExitCode"] = Utils.Query("ServiceSpecificExitCode", myWMIQueryObject);
                currDictionary["ServiceType"]             = Utils.Query("ServiceType", myWMIQueryObject);
                currDictionary["Started"]                 = Utils.Query("Started", myWMIQueryObject);
                currDictionary["StartMode"]               = Utils.Query("StartMode", myWMIQueryObject);
                currDictionary["StartName"]               = Utils.Query("StartName", myWMIQueryObject);
                currDictionary["State"]                   = Utils.Query("State", myWMIQueryObject);
                currDictionary["Status"]                  = Utils.Query("Status", myWMIQueryObject);
                currDictionary["SystemCreationClassName"] = Utils.Query("SystemCreationClassName", myWMIQueryObject);
                currDictionary["SystemName"]              = Utils.Query("SystemName", myWMIQueryObject);
                currDictionary["TagId"]                   = Utils.Query("TagId", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
