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
            this.LoadData();
        }

        public override void LoadData()
        {
            ManagementObject queryObject = new ManagementObject("Win32_OperatingSystem=@");
            Dictionary<string, string> currDictionary = new Dictionary<string, string>();

            currDictionary["BuildNumber"]                               = Utils.Query("BuildNumber", queryObject);
            currDictionary["BuildType"]                                 = Utils.Query("BuildType", queryObject);
            currDictionary["Caption"]                                   = Utils.Query("Caption", queryObject);
            currDictionary["CodeSet"]                                   = Utils.Query("CodeSet", queryObject);
            currDictionary["CountryCode"]                               = Utils.Query("CountryCode", queryObject);
            currDictionary["CreationClassName"]                         = Utils.Query("CreationClassName", queryObject);
            currDictionary["CSCreationClassName"]                       = Utils.Query("CSCreationClassName", queryObject);
            currDictionary["CSDVersion"]                                = Utils.Query("CSDVersion", queryObject);
            currDictionary["CSName"]                                    = Utils.Query("CSName", queryObject);
            currDictionary["CurrentTimeZone"]                           = Utils.Query("CurrentTimeZone", queryObject);
            currDictionary["DataExecutionPrevention_Available"]         = Utils.Query("DataExecutionPrevention_Available", queryObject);
            currDictionary["DataExecutionPrevention_32BitApplications"] = Utils.Query("DataExecutionPrevention_32BitApplications", queryObject);
            currDictionary["DataExecutionPrevention_Drivers"]           = Utils.Query("DataExecutionPrevention_Drivers", queryObject);
            currDictionary["DataExecutionPrevention_SupportPolicy"]     = Utils.Query("DataExecutionPrevention_SupportPolicy", queryObject);
            currDictionary["Debug"]                                     = Utils.Query("Debug", queryObject);
            currDictionary["Description"]                               = Utils.Query("Description", queryObject);
            currDictionary["Distributed"]                               = Utils.Query("Distributed", queryObject);
            currDictionary["EncryptionLevel"]                           = Utils.Query("EncryptionLevel", queryObject);
            currDictionary["ForegroundApplicationBoost"]                = Utils.Query("ForegroundApplicationBoost", queryObject);
            currDictionary["FreePhysicalMemory"]                        = Utils.Query("FreePhysicalMemory", queryObject);
            currDictionary["FreeSpaceInPagingFiles"]                    = Utils.Query("FreeSpaceInPagingFiles", queryObject);
            currDictionary["FreeVirtualMemory"]                         = Utils.Query("FreeVirtualMemory", queryObject);
            currDictionary["InstallDate"]                               = Utils.Query("InstallDate", queryObject);
            currDictionary["LargeSystemCache"]                          = Utils.Query("LargeSystemCache", queryObject);
            currDictionary["LastBootUpTime"]                            = Utils.Query("LastBootUpTime", queryObject);
            currDictionary["LocalDateTime"]                             = Utils.Query("LocalDateTime", queryObject);
            currDictionary["Locale"]                                    = Utils.Query("Locale", queryObject);
            currDictionary["Manufacturer"]                              = Utils.Query("Manufacturer", queryObject);
            currDictionary["MaxNumberOfProcesses"]                      = Utils.Query("MaxNumberOfProcesses", queryObject);
            currDictionary["MaxProcessMemorySize"]                      = Utils.Query("MaxProcessMemorySize", queryObject);
            currDictionary["MUILanguages"]                              = Utils.Query("MUILanguages", queryObject);
            currDictionary["Name"]                                      = Utils.Query("Name", queryObject);
            currDictionary["NumberOfLicensedUsers"]                     = Utils.Query("NumberOfLicensedUsers", queryObject);
            currDictionary["NumberOfProcesses"]                         = Utils.Query("NumberOfProcesses", queryObject);
            currDictionary["NumberOfUsers"]                             = Utils.Query("NumberOfUsers", queryObject);
            currDictionary["OperatingSystemSKU"]                        = Utils.Query("OperatingSystemSKU", queryObject);
            currDictionary["Organization"]                              = Utils.Query("Organization", queryObject);
            currDictionary["OSArchitecture"]                            = Utils.Query("OSArchitecture", queryObject);
            currDictionary["OSLanguage"]                                = Utils.Query("OSLanguage", queryObject);
            currDictionary["OSProductSuite"]                            = Utils.Query("OSProductSuite", queryObject);
            currDictionary["OSType"]                                    = Utils.Query("OSType", queryObject);
            currDictionary["OtherTypeDescription"]                      = Utils.Query("OtherTypeDescription", queryObject);
            currDictionary["PAEEnabled"]                                = Utils.Query("PAEEnabled", queryObject);
            currDictionary["PlusProductID"]                             = Utils.Query("PlusProductID", queryObject);
            currDictionary["PlusVersionNumber"]                         = Utils.Query("PlusVersionNumber", queryObject);
            currDictionary["PortableOperatingSystem"]                   = Utils.Query("PortableOperatingSystem", queryObject);
            currDictionary["Primary"]                                   = Utils.Query("Primary", queryObject);
            currDictionary["ProductType"]                               = Utils.Query("ProductType", queryObject);
            currDictionary["RegisteredUser"]                            = Utils.Query("RegisteredUser", queryObject);
            currDictionary["SerialNumber"]                              = Utils.Query("SerialNumber", queryObject);
            currDictionary["ServicePackMajorVersion"]                   = Utils.Query("ServicePackMajorVersion", queryObject);
            currDictionary["ServicePackMinorVersion"]                   = Utils.Query("ServicePackMinorVersion", queryObject);
            currDictionary["SizeStoredInPagingFiles"]                   = Utils.Query("SizeStoredInPagingFiles", queryObject);
            currDictionary["Status"]                                    = Utils.Query("Status", queryObject);
            currDictionary["SuiteMask"]                                 = Utils.Query("SuiteMask", queryObject);
            currDictionary["SystemDevice"]                              = Utils.Query("SystemDevice", queryObject);
            currDictionary["SystemDirectory"]                           = Utils.Query("SystemDirectory", queryObject);
            currDictionary["SystemDrive"]                               = Utils.Query("SystemDrive", queryObject);
            currDictionary["TotalSwapSpaceSize"]                        = Utils.Query("TotalSwapSpaceSize", queryObject);
            currDictionary["TotalVirtualMemorySize"]                    = Utils.Query("TotalVirtualMemorySize", queryObject);
            currDictionary["TotalVisibleMemorySize"]                    = Utils.Query("TotalVisibleMemorySize", queryObject);
            currDictionary["Version"]                                   = Utils.Query("Version", queryObject);
            currDictionary["WindowsDirectory"]                          = Utils.Query("WindowsDirectory", queryObject);
            currDictionary["QuantumLength"]                             = Utils.Query("QuantumLength", queryObject);
            currDictionary["QuantumType"]                               = Utils.Query("QuantumType", queryObject);

            myData.Add(currDictionary);

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
