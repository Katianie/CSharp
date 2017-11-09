using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class DesktopMonitorInfo : Info
    {
        public DesktopMonitorInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Availability"]                  = Utils.Query("Availability", myWMIQueryObject);
                currDictionary["Bandwidth"]                     = Utils.Query("Bandwidth", myWMIQueryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["ConfigManagerErrorCode"]        = Utils.Query("ConfigManagerErrorCode", myWMIQueryObject);
                currDictionary["ConfigManagerUserConfig"]       = Utils.Query("ConfigManagerUserConfig", myWMIQueryObject);
                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["Description"]                   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["DeviceID"]                      = Utils.Query("DeviceID", myWMIQueryObject);
                currDictionary["DisplayType"]                   = Utils.Query("DisplayType", myWMIQueryObject);
                currDictionary["ErrorCleared"]                  = Utils.Query("ErrorCleared", myWMIQueryObject);
                currDictionary["ErrorDescription"]              = Utils.Query("ErrorDescription", myWMIQueryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["IsLocked"]                      = Utils.Query("IsLocked", myWMIQueryObject);
                currDictionary["LastErrorCode"]                 = Utils.Query("LastErrorCode", myWMIQueryObject);
                currDictionary["MonitorManufacturer"]           = Utils.Query("MonitorManufacturer", myWMIQueryObject);
                currDictionary["MonitorType"]                   = Utils.Query("MonitorType", myWMIQueryObject);
                currDictionary["Name"]                          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["PixelsPerXLogicalInch"]         = Utils.Query("PixelsPerXLogicalInch", myWMIQueryObject);
                currDictionary["PixelsPerYLogicalInch"]         = Utils.Query("PixelsPerYLogicalInch", myWMIQueryObject);
                currDictionary["PNPDeviceID"]                   = Utils.Query("PNPDeviceID", myWMIQueryObject);
                currDictionary["PowerManagementCapabilities"]   = Utils.Query("PowerManagementCapabilities", myWMIQueryObject);
                currDictionary["PowerManagementSupported"]      = Utils.Query("PowerManagementSupported", myWMIQueryObject);
                currDictionary["ScreenHeight"]                  = Utils.Query("ScreenHeight", myWMIQueryObject);
                currDictionary["ScreenWidth"]                   = Utils.Query("ScreenWidth", myWMIQueryObject);
                currDictionary["Status"]                        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["StatusInfo"]                    = Utils.Query("StatusInfo", myWMIQueryObject);
                currDictionary["SystemCreationClassName"]       = Utils.Query("SystemCreationClassName", myWMIQueryObject);
                currDictionary["SystemName"]                    = Utils.Query("SystemName", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
