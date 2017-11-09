using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class ComputerSystemInfo : Info
    {
        public ComputerSystemInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            myWMICollection = myWMISearcher.Get();

            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["AdminPasswordStatus"]           = Utils.Query("AdminPasswordStatus", myWMIQueryObject);
                currDictionary["AutomaticManagedPagefile"]      = Utils.Query("AutomaticManagedPagefile", myWMIQueryObject);
                currDictionary["AutomaticResetBootOption"]      = Utils.Query("AutomaticResetBootOption", myWMIQueryObject);
                currDictionary["AutomaticResetCapability"]      = Utils.Query("AutomaticResetCapability", myWMIQueryObject);
                currDictionary["BootOptionOnLimit"]             = Utils.Query("BootOptionOnLimit", myWMIQueryObject);
                currDictionary["BootOptionOnWatchDog"]          = Utils.Query("BootOptionOnWatchDog", myWMIQueryObject);
                currDictionary["BootROMSupported"]              = Utils.Query("BootROMSupported", myWMIQueryObject);
                currDictionary["BootupState"]                   = Utils.Query("BootupState", myWMIQueryObject);
                currDictionary["BootStatus"]                    = Utils.Query("BootStatus", myWMIQueryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["ChassisBootupState"]            = Utils.Query("ChassisBootupState", myWMIQueryObject);
                currDictionary["ChassisSKUNumber"]              = Utils.Query("ChassisSKUNumber", myWMIQueryObject);
                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["CurrentTimeZone"]               = Utils.Query("CurrentTimeZone", myWMIQueryObject);
                currDictionary["DaylightInEffect"]              = Utils.Query("DaylightInEffect", myWMIQueryObject);
                currDictionary["Description"]                   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["DNSHostName"]                   = Utils.Query("DNSHostName", myWMIQueryObject);
                currDictionary["Domain"]                        = Utils.Query("Domain", myWMIQueryObject);
                currDictionary["DomainRole"]                    = Utils.Query("DomainRole", myWMIQueryObject);
                currDictionary["EnableDaylightSavingsTime"]     = Utils.Query("EnableDaylightSavingsTime", myWMIQueryObject);
                currDictionary["FrontPanelResetStatus"]         = Utils.Query("FrontPanelResetStatus", myWMIQueryObject);
                currDictionary["HypervisorPresent"]             = Utils.Query("HypervisorPresent", myWMIQueryObject);
                currDictionary["InfraredSupported"]             = Utils.Query("InfraredSupported", myWMIQueryObject);
                currDictionary["InitialLoadInfo"]               = Utils.Query("InitialLoadInfo", myWMIQueryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["KeyboardPasswordStatus"]        = Utils.Query("KeyboardPasswordStatus", myWMIQueryObject);
                currDictionary["LastLoadInfo"]                  = Utils.Query("LastLoadInfo", myWMIQueryObject);
                currDictionary["Manufacturer"]                  = Utils.Query("Manufacturer", myWMIQueryObject);
                currDictionary["Model"]                         = Utils.Query("Model", myWMIQueryObject);
                currDictionary["Name"]                          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["NameFormat"]                    = Utils.Query("NameFormat", myWMIQueryObject);
                currDictionary["NetworkServerModeEnabled"]      = Utils.Query("NetworkServerModeEnabled", myWMIQueryObject);
                currDictionary["NumberOfLogicalProcessors"]     = Utils.Query("NumberOfLogicalProcessors", myWMIQueryObject);
                currDictionary["NumberOfProcessors"]            = Utils.Query("NumberOfProcessors", myWMIQueryObject);
                currDictionary["OEMLogoBitmap"]                 = Utils.Query("OEMLogoBitmap", myWMIQueryObject);
                currDictionary["OEMStringArray"]                = Utils.Query("OEMStringArray", myWMIQueryObject);
                currDictionary["PartOfDomain"]                  = Utils.Query("PartOfDomain", myWMIQueryObject);
                currDictionary["PauseAfterReset"]               = Utils.Query("PauseAfterReset", myWMIQueryObject);
                currDictionary["PCSystemType"]                  = Utils.Query("PCSystemType", myWMIQueryObject);
                currDictionary["PCSystemTypeEx"]                = Utils.Query("PCSystemTypeEx", myWMIQueryObject);
                currDictionary["PowerManagementCapabilities"]   = Utils.Query("PowerManagementCapabilities", myWMIQueryObject);
                currDictionary["PowerManagementSupported"]      = Utils.Query("PowerManagementSupported", myWMIQueryObject);
                currDictionary["PowerOnPasswordStatus"]         = Utils.Query("PowerOnPasswordStatus", myWMIQueryObject);
                currDictionary["PowerState"]                    = Utils.Query("PowerState", myWMIQueryObject);
                currDictionary["PowerSupplyState"]              = Utils.Query("PowerSupplyState", myWMIQueryObject);
                currDictionary["PrimaryOwnerContact"]           = Utils.Query("PrimaryOwnerContact", myWMIQueryObject);
                currDictionary["PrimaryOwnerName"]              = Utils.Query("PrimaryOwnerName", myWMIQueryObject);
                currDictionary["ResetCapability"]               = Utils.Query("ResetCapability", myWMIQueryObject);
                currDictionary["ResetCount"]                    = Utils.Query("ResetCount", myWMIQueryObject);
                currDictionary["ResetLimit"]                    = Utils.Query("ResetLimit", myWMIQueryObject);
                currDictionary["Roles"]                         = Utils.Query("Roles", myWMIQueryObject);
                currDictionary["Status"]                        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["SupportContactDescription"]     = Utils.Query("SupportContactDescription", myWMIQueryObject);
                currDictionary["SystemFamily"]                  = Utils.Query("SystemFamily", myWMIQueryObject);
                currDictionary["SystemSKUNumber"]               = Utils.Query("SystemSKUNumber", myWMIQueryObject);
                currDictionary["SystemStartupDelay"]            = Utils.Query("SystemStartupDelay", myWMIQueryObject);
                currDictionary["SystemStartupOptions"]          = Utils.Query("SystemStartupOptions", myWMIQueryObject);
                currDictionary["SystemStartupSetting"]          = Utils.Query("SystemStartupSetting", myWMIQueryObject);
                currDictionary["SystemType"]                    = Utils.Query("SystemType", myWMIQueryObject);
                currDictionary["ThermalState"]                  = Utils.Query("ThermalState", myWMIQueryObject);
                currDictionary["TotalPhysicalMemory"]           = Utils.Query("TotalPhysicalMemory", myWMIQueryObject);
                currDictionary["UserName"]                      = Utils.Query("UserName", myWMIQueryObject);
                currDictionary["WakeUpType"]                    = Utils.Query("WakeUpType", myWMIQueryObject);
                currDictionary["Workgroup"]                     = Utils.Query("Workgroup", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
