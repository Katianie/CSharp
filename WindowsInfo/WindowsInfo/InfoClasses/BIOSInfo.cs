using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class BIOSInfo : Info
    {
        public BIOSInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["BiosCharacteristics"]               = Utils.Query("BiosCharacteristics", myWMIQueryObject);
                currDictionary["BIOSVersion"]                       = Utils.Query("BIOSVersion", myWMIQueryObject);
                currDictionary["BuildNumber"]                       = Utils.Query("BuildNumber", myWMIQueryObject);
                currDictionary["Caption"]                           = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["CodeSet"]                           = Utils.Query("CodeSet", myWMIQueryObject);
                currDictionary["CurrentLanguage"]                   = Utils.Query("CurrentLanguage", myWMIQueryObject);
                currDictionary["Description"]                       = Utils.Query("Description", myWMIQueryObject);
                currDictionary["EmbeddedControllerMajorVersion"]    = Utils.Query("EmbeddedControllerMajorVersion", myWMIQueryObject);
                currDictionary["EmbeddedControllerMinorVersion"]    = Utils.Query("EmbeddedControllerMinorVersion", myWMIQueryObject);
                currDictionary["IdentificationCode"]                = Utils.Query("IdentificationCode", myWMIQueryObject);
                currDictionary["InstallableLanguages"]              = Utils.Query("InstallableLanguages", myWMIQueryObject);
                currDictionary["InstallDate"]                       = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["LanguageEdition"]                   = Utils.Query("LanguageEdition", myWMIQueryObject);
                currDictionary["ListOfLanguages"]                   = Utils.Query("ListOfLanguages", myWMIQueryObject);
                currDictionary["Manufacturer"]                      = Utils.Query("Manufacturer", myWMIQueryObject);
                currDictionary["Name"]                              = Utils.Query("Name", myWMIQueryObject);
                currDictionary["OtherTargetOS"]                     = Utils.Query("OtherTargetOS", myWMIQueryObject);
                currDictionary["PrimaryBIOS"]                       = Utils.Query("PrimaryBIOS", myWMIQueryObject);
                currDictionary["ReleaseDate"]                       = Utils.Query("ReleaseDate", myWMIQueryObject);
                currDictionary["SerialNumber"]                      = Utils.Query("SerialNumber", myWMIQueryObject);
                currDictionary["SMBIOSBIOSVersion"]                 = Utils.Query("SMBIOSBIOSVersion", myWMIQueryObject);
                currDictionary["SMBIOSMajorVersion"]                = Utils.Query("SMBIOSMajorVersion", myWMIQueryObject);
                currDictionary["SMBIOSMinorVersion"]                = Utils.Query("SMBIOSMinorVersion", myWMIQueryObject);
                currDictionary["SMBIOSPresent"]                     = Utils.Query("SMBIOSPresent", myWMIQueryObject);
                currDictionary["SoftwareElementID"]                 = Utils.Query("SoftwareElementID", myWMIQueryObject);
                currDictionary["SoftwareElementState"]              = Utils.Query("SoftwareElementState", myWMIQueryObject);
                currDictionary["Status"]                            = Utils.Query("Status", myWMIQueryObject);
                currDictionary["SystemBiosMajorVersion"]            = Utils.Query("SystemBiosMajorVersion", myWMIQueryObject);
                currDictionary["SystemBiosMinorVersion"]            = Utils.Query("SystemBiosMinorVersion", myWMIQueryObject);
                currDictionary["TargetOperatingSystem"]             = Utils.Query("TargetOperatingSystem", myWMIQueryObject);
                currDictionary["Version"]                           = Utils.Query("Version", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
