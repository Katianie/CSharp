using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class DiskPartitionInfo : Info
    {
        public DiskPartitionInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskPartition");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["AdditionalAvailability"]        = Utils.Query("AdditionalAvailability", myWMIQueryObject);
                currDictionary["Availability"]                  = Utils.Query("Availability", myWMIQueryObject);
                currDictionary["PowerManagementCapabilities"]   = Utils.Query("PowerManagementCapabilities", myWMIQueryObject);
                currDictionary["IdentifyingDescriptions"]       = Utils.Query("IdentifyingDescriptions", myWMIQueryObject);
                currDictionary["MaxQuiesceTime"]                = Utils.Query("MaxQuiesceTime", myWMIQueryObject);
                currDictionary["OtherIdentifyingInfo"]          = Utils.Query("OtherIdentifyingInfo", myWMIQueryObject);
                currDictionary["StatusInfo"]                    = Utils.Query("StatusInfo", myWMIQueryObject);
                currDictionary["PowerOnHours"]                  = Utils.Query("PowerOnHours", myWMIQueryObject);
                currDictionary["TotalPowerOnHours"]             = Utils.Query("TotalPowerOnHours", myWMIQueryObject);
                currDictionary["Access"]                        = Utils.Query("Access", myWMIQueryObject);
                currDictionary["BlockSize"]                     = Utils.Query("BlockSize", myWMIQueryObject);
                currDictionary["Bootable"]                      = Utils.Query("Bootable", myWMIQueryObject);
                currDictionary["BootPartition"]                 = Utils.Query("BootPartition", myWMIQueryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["ConfigManagerErrorCode"]        = Utils.Query("ConfigManagerErrorCode", myWMIQueryObject);
                currDictionary["ConfigManagerUserConfig"]       = Utils.Query("ConfigManagerUserConfig", myWMIQueryObject);
                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["Description"]                   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["DeviceID"]                      = Utils.Query("DeviceID", myWMIQueryObject);
                currDictionary["DiskIndex"]                     = Utils.Query("DiskIndex", myWMIQueryObject);
                currDictionary["ErrorCleared"]                  = Utils.Query("ErrorCleared", myWMIQueryObject);
                currDictionary["ErrorDescription"]              = Utils.Query("ErrorDescription", myWMIQueryObject);
                currDictionary["ErrorMethodology"]              = Utils.Query("ErrorMethodology", myWMIQueryObject);
                currDictionary["HiddenSectors"]                 = Utils.Query("HiddenSectors", myWMIQueryObject);
                currDictionary["Index"]                         = Utils.Query("Index", myWMIQueryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["LastErrorCode"]                 = Utils.Query("LastErrorCode", myWMIQueryObject);
                currDictionary["Name"]                          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["NumberOfBlocks"]                = Utils.Query("NumberOfBlocks", myWMIQueryObject);
                currDictionary["PNPDeviceID"]                   = Utils.Query("PNPDeviceID", myWMIQueryObject);
                currDictionary["PowerManagementSupported"]      = Utils.Query("PowerManagementSupported", myWMIQueryObject);
                currDictionary["PrimaryPartition"]              = Utils.Query("PrimaryPartition", myWMIQueryObject);
                currDictionary["Purpose"]                       = Utils.Query("Purpose", myWMIQueryObject);
                currDictionary["RewritePartition"]              = Utils.Query("RewritePartition", myWMIQueryObject);
                currDictionary["Size"]                          = Utils.Query("Size", myWMIQueryObject);
                currDictionary["StartingOffset"]                = Utils.Query("StartingOffset", myWMIQueryObject);
                currDictionary["Status"]                        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["SystemCreationClassName"]       = Utils.Query("SystemCreationClassName", myWMIQueryObject);
                currDictionary["SystemName"]                    = Utils.Query("SystemName", myWMIQueryObject);
                currDictionary["Type"]                          = Utils.Query("Type", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
