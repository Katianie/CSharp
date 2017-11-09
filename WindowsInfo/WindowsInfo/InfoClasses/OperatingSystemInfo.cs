using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class OperatingSystemInfo : Info
    {
        public OperatingSystemInfo() : base()
        {

        }

        public override void LoadData()
        {
            myWMIQueryObject = new ManagementObject("Win32_OperatingSystem=@");
            Dictionary<string, string> currDictionary = new Dictionary<string, string>();

            currDictionary["BuildNumber"]                               = Utils.Query("BuildNumber", myWMIQueryObject);
            currDictionary["BuildType"]                                 = Utils.Query("BuildType", myWMIQueryObject);
            currDictionary["Caption"]                                   = Utils.Query("Caption", myWMIQueryObject);
            currDictionary["CodeSet"]                                   = Utils.Query("CodeSet", myWMIQueryObject);
            currDictionary["CountryCode"]                               = Utils.Query("CountryCode", myWMIQueryObject);
            currDictionary["CreationClassName"]                         = Utils.Query("CreationClassName", myWMIQueryObject);
            currDictionary["CSCreationClassName"]                       = Utils.Query("CSCreationClassName", myWMIQueryObject);
            currDictionary["CSDVersion"]                                = Utils.Query("CSDVersion", myWMIQueryObject);
            currDictionary["CSName"]                                    = Utils.Query("CSName", myWMIQueryObject);
            currDictionary["CurrentTimeZone"]                           = Utils.Query("CurrentTimeZone", myWMIQueryObject);
            currDictionary["DataExecutionPrevention_Available"]         = Utils.Query("DataExecutionPrevention_Available", myWMIQueryObject);
            currDictionary["DataExecutionPrevention_32BitApplications"] = Utils.Query("DataExecutionPrevention_32BitApplications", myWMIQueryObject);
            currDictionary["DataExecutionPrevention_Drivers"]           = Utils.Query("DataExecutionPrevention_Drivers", myWMIQueryObject);
            currDictionary["DataExecutionPrevention_SupportPolicy"]     = Utils.Query("DataExecutionPrevention_SupportPolicy", myWMIQueryObject);
            currDictionary["Debug"]                                     = Utils.Query("Debug", myWMIQueryObject);
            currDictionary["Description"]                               = Utils.Query("Description", myWMIQueryObject);
            currDictionary["Distributed"]                               = Utils.Query("Distributed", myWMIQueryObject);
            currDictionary["EncryptionLevel"]                           = Utils.Query("EncryptionLevel", myWMIQueryObject);
            currDictionary["ForegroundApplicationBoost"]                = Utils.Query("ForegroundApplicationBoost", myWMIQueryObject);
            currDictionary["FreePhysicalMemory"]                        = Utils.Query("FreePhysicalMemory", myWMIQueryObject);
            currDictionary["FreeSpaceInPagingFiles"]                    = Utils.Query("FreeSpaceInPagingFiles", myWMIQueryObject);
            currDictionary["FreeVirtualMemory"]                         = Utils.Query("FreeVirtualMemory", myWMIQueryObject);
            currDictionary["InstallDate"]                               = Utils.Query("InstallDate", myWMIQueryObject);
            currDictionary["LargeSystemCache"]                          = Utils.Query("LargeSystemCache", myWMIQueryObject);
            currDictionary["LastBootUpTime"]                            = Utils.Query("LastBootUpTime", myWMIQueryObject);
            currDictionary["LocalDateTime"]                             = Utils.Query("LocalDateTime", myWMIQueryObject);
            currDictionary["Locale"]                                    = Utils.Query("Locale", myWMIQueryObject);
            currDictionary["Manufacturer"]                              = Utils.Query("Manufacturer", myWMIQueryObject);
            currDictionary["MaxNumberOfProcesses"]                      = Utils.Query("MaxNumberOfProcesses", myWMIQueryObject);
            currDictionary["MaxProcessMemorySize"]                      = Utils.Query("MaxProcessMemorySize", myWMIQueryObject);
            currDictionary["MUILanguages"]                              = Utils.Query("MUILanguages", myWMIQueryObject);
            currDictionary["Name"]                                      = Utils.Query("Name", myWMIQueryObject);
            currDictionary["NumberOfLicensedUsers"]                     = Utils.Query("NumberOfLicensedUsers", myWMIQueryObject);
            currDictionary["NumberOfProcesses"]                         = Utils.Query("NumberOfProcesses", myWMIQueryObject);
            currDictionary["NumberOfUsers"]                             = Utils.Query("NumberOfUsers", myWMIQueryObject);
            currDictionary["OperatingSystemSKU"]                        = Utils.Query("OperatingSystemSKU", myWMIQueryObject);
            currDictionary["Organization"]                              = Utils.Query("Organization", myWMIQueryObject);
            currDictionary["OSArchitecture"]                            = Utils.Query("OSArchitecture", myWMIQueryObject);
            currDictionary["OSLanguage"]                                = Utils.Query("OSLanguage", myWMIQueryObject);
            currDictionary["OSProductSuite"]                            = Utils.Query("OSProductSuite", myWMIQueryObject);
            currDictionary["OSType"]                                    = Utils.Query("OSType", myWMIQueryObject);
            currDictionary["OtherTypeDescription"]                      = Utils.Query("OtherTypeDescription", myWMIQueryObject);
            currDictionary["PAEEnabled"]                                = Utils.Query("PAEEnabled", myWMIQueryObject);
            currDictionary["PlusProductID"]                             = Utils.Query("PlusProductID", myWMIQueryObject);
            currDictionary["PlusVersionNumber"]                         = Utils.Query("PlusVersionNumber", myWMIQueryObject);
            currDictionary["PortableOperatingSystem"]                   = Utils.Query("PortableOperatingSystem", myWMIQueryObject);
            currDictionary["Primary"]                                   = Utils.Query("Primary", myWMIQueryObject);
            currDictionary["ProductType"]                               = Utils.Query("ProductType", myWMIQueryObject);
            currDictionary["RegisteredUser"]                            = Utils.Query("RegisteredUser", myWMIQueryObject);
            currDictionary["SerialNumber"]                              = Utils.Query("SerialNumber", myWMIQueryObject);
            currDictionary["ServicePackMajorVersion"]                   = Utils.Query("ServicePackMajorVersion", myWMIQueryObject);
            currDictionary["ServicePackMinorVersion"]                   = Utils.Query("ServicePackMinorVersion", myWMIQueryObject);
            currDictionary["SizeStoredInPagingFiles"]                   = Utils.Query("SizeStoredInPagingFiles", myWMIQueryObject);
            currDictionary["Status"]                                    = Utils.Query("Status", myWMIQueryObject);
            currDictionary["SuiteMask"]                                 = Utils.Query("SuiteMask", myWMIQueryObject);
            currDictionary["SystemDevice"]                              = Utils.Query("SystemDevice", myWMIQueryObject);
            currDictionary["SystemDirectory"]                           = Utils.Query("SystemDirectory", myWMIQueryObject);
            currDictionary["SystemDrive"]                               = Utils.Query("SystemDrive", myWMIQueryObject);
            currDictionary["TotalSwapSpaceSize"]                        = Utils.Query("TotalSwapSpaceSize", myWMIQueryObject);
            currDictionary["TotalVirtualMemorySize"]                    = Utils.Query("TotalVirtualMemorySize", myWMIQueryObject);
            currDictionary["TotalVisibleMemorySize"]                    = Utils.Query("TotalVisibleMemorySize", myWMIQueryObject);
            currDictionary["Version"]                                   = Utils.Query("Version", myWMIQueryObject);
            currDictionary["WindowsDirectory"]                          = Utils.Query("WindowsDirectory", myWMIQueryObject);
            currDictionary["QuantumLength"]                             = Utils.Query("QuantumLength", myWMIQueryObject);
            currDictionary["QuantumType"]                               = Utils.Query("QuantumType", myWMIQueryObject);

            myData.Add(currDictionary);

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
