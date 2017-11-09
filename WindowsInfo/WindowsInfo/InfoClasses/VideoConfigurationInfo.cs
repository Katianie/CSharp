using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class VideoConfigurationInfo : Info
    {
        public VideoConfigurationInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoConfiguration");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]                   = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]               = Utils.Query("Description", myWMIQueryObject);
                currDictionary["SettingID"]                 = Utils.Query("SettingID", myWMIQueryObject);
                currDictionary["ActualColorResolution"]     = Utils.Query("ActualColorResolution", myWMIQueryObject);
                currDictionary["AdapterChipType"]           = Utils.Query("AdapterChipType", myWMIQueryObject);
                currDictionary["AdapterCompatibility"]      = Utils.Query("AdapterCompatibility", myWMIQueryObject);
                currDictionary["AdapterDACType"]            = Utils.Query("AdapterDACType", myWMIQueryObject);
                currDictionary["AdapterDescription"]        = Utils.Query("AdapterDescription", myWMIQueryObject);
                currDictionary["AdapterRAM"]                = Utils.Query("AdapterRAM", myWMIQueryObject);
                currDictionary["AdapterType"]               = Utils.Query("AdapterType", myWMIQueryObject);
                currDictionary["BitsPerPixel"]              = Utils.Query("BitsPerPixel", myWMIQueryObject);
                currDictionary["ColorPlanes"]               = Utils.Query("ColorPlanes", myWMIQueryObject);
                currDictionary["ColorTableEntries"]         = Utils.Query("ColorTableEntries", myWMIQueryObject);
                currDictionary["DeviceSpecificPens"]        = Utils.Query("DeviceSpecificPens", myWMIQueryObject);
                currDictionary["DriverDate"]                = Utils.Query("DriverDate", myWMIQueryObject);
                currDictionary["HorizontalResolution"]      = Utils.Query("HorizontalResolution", myWMIQueryObject);
                currDictionary["InfFilename"]               = Utils.Query("InfFilename", myWMIQueryObject);
                currDictionary["InfSection"]                = Utils.Query("InfSection", myWMIQueryObject);
                currDictionary["InstalledDisplayDrivers"]   = Utils.Query("InstalledDisplayDrivers", myWMIQueryObject);
                currDictionary["MonitorManufacturer"]       = Utils.Query("MonitorManufacturer", myWMIQueryObject);
                currDictionary["MonitorType"]               = Utils.Query("MonitorType", myWMIQueryObject);
                currDictionary["Name"]                      = Utils.Query("Name", myWMIQueryObject);
                currDictionary["PixelsPerXLogicalInch"]     = Utils.Query("PixelsPerXLogicalInch", myWMIQueryObject);
                currDictionary["PixelsPerYLogicalInch"]     = Utils.Query("PixelsPerYLogicalInch", myWMIQueryObject);
                currDictionary["RefreshRate"]               = Utils.Query("RefreshRate", myWMIQueryObject);
                currDictionary["ScanMode"]                  = Utils.Query("ScanMode", myWMIQueryObject);
                currDictionary["ScreenHeight"]              = Utils.Query("ScreenHeight", myWMIQueryObject);
                currDictionary["ScreenWidth"]               = Utils.Query("ScreenWidth", myWMIQueryObject);
                currDictionary["SystemPaletteEntries"]      = Utils.Query("SystemPaletteEntries", myWMIQueryObject);
                currDictionary["VerticalResolution"]        = Utils.Query("VerticalResolution", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
