using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class VideoControllerInfo : Info
    {
        public VideoControllerInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["AcceleratorCapabilities"]       = Utils.Query("AcceleratorCapabilities", myWMIQueryObject);
                currDictionary["AdapterCompatibility"]          = Utils.Query("AdapterCompatibility", myWMIQueryObject);
                currDictionary["AdapterDACType"]                = Utils.Query("AdapterDACType", myWMIQueryObject);
                currDictionary["AdapterRAM"]                    = Utils.Query("AdapterRAM", myWMIQueryObject);
                currDictionary["Availability"]                  = Utils.Query("Availability", myWMIQueryObject);
                currDictionary["CapabilityDescriptions"]        = Utils.Query("CapabilityDescriptions", myWMIQueryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["ColorTableEntries"]             = Utils.Query("ColorTableEntries", myWMIQueryObject);
                currDictionary["ConfigManagerErrorCode"]        = Utils.Query("ConfigManagerErrorCode", myWMIQueryObject);
                currDictionary["ConfigManagerUserConfig"]       = Utils.Query("ConfigManagerUserConfig", myWMIQueryObject);
                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["CurrentBitsPerPixel"]           = Utils.Query("CurrentBitsPerPixel", myWMIQueryObject);
                currDictionary["CurrentHorizontalResolution"]   = Utils.Query("CurrentHorizontalResolution", myWMIQueryObject);
                currDictionary["CurrentNumberOfColors"]         = Utils.Query("CurrentNumberOfColors", myWMIQueryObject);
                currDictionary["CurrentNumberOfColumns"]        = Utils.Query("CurrentNumberOfColumns", myWMIQueryObject);
                currDictionary["CurrentNumberOfRows"]           = Utils.Query("CurrentNumberOfRows", myWMIQueryObject);
                currDictionary["CurrentRefreshRate"]            = Utils.Query("CurrentRefreshRate", myWMIQueryObject);
                currDictionary["CurrentScanMode"]               = Utils.Query("CurrentScanMode", myWMIQueryObject);
                currDictionary["CurrentVerticalResolution"]     = Utils.Query("CurrentVerticalResolution", myWMIQueryObject);
                currDictionary["Description"]                   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["DeviceID"]                      = Utils.Query("DeviceID", myWMIQueryObject);
                currDictionary["DeviceSpecificPens"]            = Utils.Query("DeviceSpecificPens", myWMIQueryObject);
                currDictionary["DitherType"]                    = Utils.Query("DitherType", myWMIQueryObject);
                currDictionary["DriverDate"]                    = Utils.Query("DriverDate", myWMIQueryObject);
                currDictionary["DriverVersion"]                 = Utils.Query("DriverVersion", myWMIQueryObject);
                currDictionary["ErrorCleared"]                  = Utils.Query("ErrorCleared", myWMIQueryObject);
                currDictionary["ErrorDescription"]              = Utils.Query("ErrorDescription", myWMIQueryObject);
                currDictionary["ICMIntent"]                     = Utils.Query("ICMIntent", myWMIQueryObject);
                currDictionary["ICMMethod"]                     = Utils.Query("ICMMethod", myWMIQueryObject);
                currDictionary["InfFilename"]                   = Utils.Query("InfFilename", myWMIQueryObject);
                currDictionary["InfSection"]                    = Utils.Query("InfSection", myWMIQueryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["InstalledDisplayDrivers"]       = Utils.Query("InstalledDisplayDrivers", myWMIQueryObject);
                currDictionary["LastErrorCode"]                 = Utils.Query("LastErrorCode", myWMIQueryObject);
                currDictionary["MaxMemorySupported"]            = Utils.Query("MaxMemorySupported", myWMIQueryObject);
                currDictionary["MaxNumberControlled"]           = Utils.Query("MaxNumberControlled", myWMIQueryObject);
                currDictionary["MaxRefreshRate"]                = Utils.Query("MaxRefreshRate", myWMIQueryObject);
                currDictionary["MinRefreshRate"]                = Utils.Query("MinRefreshRate", myWMIQueryObject);
                currDictionary["Monochrome"]                    = Utils.Query("Monochrome", myWMIQueryObject);
                currDictionary["Name"]                          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["NumberOfColorPlanes"]           = Utils.Query("NumberOfColorPlanes", myWMIQueryObject);
                currDictionary["NumberOfVideoPages"]            = Utils.Query("NumberOfVideoPages", myWMIQueryObject);
                currDictionary["PNPDeviceID"]                   = Utils.Query("PNPDeviceID", myWMIQueryObject);
                currDictionary["PowerManagementCapabilities"]   = Utils.Query("PowerManagementCapabilities", myWMIQueryObject);
                currDictionary["PowerManagementSupported"]      = Utils.Query("PowerManagementSupported", myWMIQueryObject);
                currDictionary["ProtocolSupported"]             = Utils.Query("ProtocolSupported", myWMIQueryObject);
                currDictionary["ReservedSystemPaletteEntries"]  = Utils.Query("ReservedSystemPaletteEntries", myWMIQueryObject);
                currDictionary["SpecificationVersion"]          = Utils.Query("SpecificationVersion", myWMIQueryObject);
                currDictionary["Status"]                        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["StatusInfo"]                    = Utils.Query("StatusInfo", myWMIQueryObject);
                currDictionary["SystemCreationClassName"]       = Utils.Query("SystemCreationClassName", myWMIQueryObject);
                currDictionary["SystemName"]                    = Utils.Query("SystemName", myWMIQueryObject);
                currDictionary["SystemPaletteEntries"]          = Utils.Query("SystemPaletteEntries", myWMIQueryObject);
                currDictionary["TimeOfLastReset"]               = Utils.Query("TimeOfLastReset", myWMIQueryObject);
                currDictionary["VideoArchitecture"]             = Utils.Query("VideoArchitecture", myWMIQueryObject);
                currDictionary["VideoMemoryType"]               = Utils.Query("VideoMemoryType", myWMIQueryObject);
                currDictionary["VideoMode"]                     = Utils.Query("VideoMode", myWMIQueryObject);
                currDictionary["VideoModeDescription"]          = Utils.Query("VideoModeDescription", myWMIQueryObject);
                currDictionary["VideoProcessor"]                = Utils.Query("VideoProcessor", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
