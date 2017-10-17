using System;
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
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["AdminPasswordStatus"]           = Utils.Query("AdminPasswordStatus", queryObject);
                currDictionary["AutomaticManagedPagefile"]      = Utils.Query("AutomaticManagedPagefile", queryObject);
                currDictionary["AutomaticResetBootOption"]      = Utils.Query("AutomaticResetBootOption", queryObject);
                currDictionary["AutomaticResetCapability"]      = Utils.Query("AutomaticResetCapability", queryObject);
                currDictionary["BootOptionOnLimit"]             = Utils.Query("BootOptionOnLimit", queryObject);
                currDictionary["BootOptionOnWatchDog"]          = Utils.Query("BootOptionOnWatchDog", queryObject);
                currDictionary["BootROMSupported"]              = Utils.Query("BootROMSupported", queryObject);
                currDictionary["BootupState"]                   = Utils.Query("BootupState", queryObject);
                currDictionary["BootStatus"]                    = Utils.Query("BootStatus", queryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", queryObject);
                currDictionary["ChassisBootupState"]            = Utils.Query("ChassisBootupState", queryObject);
                currDictionary["ChassisSKUNumber"]              = Utils.Query("ChassisSKUNumber", queryObject);
                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", queryObject);
                currDictionary["CurrentTimeZone"]               = Utils.Query("CurrentTimeZone", queryObject);
                currDictionary["DaylightInEffect"]              = Utils.Query("DaylightInEffect", queryObject);
                currDictionary["Description"]                   = Utils.Query("Description", queryObject);
                currDictionary["DNSHostName"]                   = Utils.Query("DNSHostName", queryObject);
                currDictionary["Domain"]                        = Utils.Query("Domain", queryObject);
                currDictionary["DomainRole"]                    = Utils.Query("DomainRole", queryObject);
                currDictionary["EnableDaylightSavingsTime"]     = Utils.Query("EnableDaylightSavingsTime", queryObject);
                currDictionary["FrontPanelResetStatus"]         = Utils.Query("FrontPanelResetStatus", queryObject);
                currDictionary["HypervisorPresent"]             = Utils.Query("HypervisorPresent", queryObject);
                currDictionary["InfraredSupported"]             = Utils.Query("InfraredSupported", queryObject);
                currDictionary["InitialLoadInfo"]               = Utils.Query("InitialLoadInfo", queryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", queryObject);
                currDictionary["KeyboardPasswordStatus"]        = Utils.Query("KeyboardPasswordStatus", queryObject);
                currDictionary["LastLoadInfo"]                  = Utils.Query("LastLoadInfo", queryObject);
                currDictionary["Manufacturer"]                  = Utils.Query("Manufacturer", queryObject);
                currDictionary["Model"]                         = Utils.Query("Model", queryObject);
                currDictionary["Name"]                          = Utils.Query("Name", queryObject);
                currDictionary["NameFormat"]                    = Utils.Query("NameFormat", queryObject);
                currDictionary["NetworkServerModeEnabled"]      = Utils.Query("NetworkServerModeEnabled", queryObject);
                currDictionary["NumberOfLogicalProcessors"]     = Utils.Query("NumberOfLogicalProcessors", queryObject);
                currDictionary["NumberOfProcessors"]            = Utils.Query("NumberOfProcessors", queryObject);
                currDictionary["OEMLogoBitmap"]                 = Utils.Query("OEMLogoBitmap", queryObject);
                currDictionary["OEMStringArray"]                = Utils.Query("OEMStringArray", queryObject);
                currDictionary["PartOfDomain"]                  = Utils.Query("PartOfDomain", queryObject);
                currDictionary["PauseAfterReset"]               = Utils.Query("PauseAfterReset", queryObject);
                currDictionary["PCSystemType"]                  = Utils.Query("PCSystemType", queryObject);
                currDictionary["PCSystemTypeEx"]                = Utils.Query("PCSystemTypeEx", queryObject);
                currDictionary["PowerManagementCapabilities"]   = Utils.Query("PowerManagementCapabilities", queryObject);
                currDictionary["PowerManagementSupported"]      = Utils.Query("PowerManagementSupported", queryObject);
                currDictionary["PowerOnPasswordStatus"]         = Utils.Query("PowerOnPasswordStatus", queryObject);
                currDictionary["PowerState"]                    = Utils.Query("PowerState", queryObject);
                currDictionary["PowerSupplyState"]              = Utils.Query("PowerSupplyState", queryObject);
                currDictionary["PrimaryOwnerContact"]           = Utils.Query("PrimaryOwnerContact", queryObject);
                currDictionary["PrimaryOwnerName"]              = Utils.Query("PrimaryOwnerName", queryObject);
                currDictionary["ResetCapability"]               = Utils.Query("ResetCapability", queryObject);
                currDictionary["ResetCount"]                    = Utils.Query("ResetCount", queryObject);
                currDictionary["ResetLimit"]                    = Utils.Query("ResetLimit", queryObject);
                currDictionary["Roles"]                         = Utils.Query("Roles", queryObject);
                currDictionary["Status"]                        = Utils.Query("Status", queryObject);
                currDictionary["SupportContactDescription"]     = Utils.Query("SupportContactDescription", queryObject);
                currDictionary["SystemFamily"]                  = Utils.Query("SystemFamily", queryObject);
                currDictionary["SystemSKUNumber"]               = Utils.Query("SystemSKUNumber", queryObject);
                currDictionary["SystemStartupDelay"]            = Utils.Query("SystemStartupDelay", queryObject);
                currDictionary["SystemStartupOptions"]          = Utils.Query("SystemStartupOptions", queryObject);
                currDictionary["SystemStartupSetting"]          = Utils.Query("SystemStartupSetting", queryObject);
                currDictionary["SystemType"]                    = Utils.Query("SystemType", queryObject);
                currDictionary["ThermalState"]                  = Utils.Query("ThermalState", queryObject);
                currDictionary["TotalPhysicalMemory"]           = Utils.Query("TotalPhysicalMemory", queryObject);
                currDictionary["UserName"]                      = Utils.Query("UserName", queryObject);
                currDictionary["WakeUpType"]                    = Utils.Query("WakeUpType", queryObject);
                currDictionary["Workgroup"]                     = Utils.Query("Workgroup", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
