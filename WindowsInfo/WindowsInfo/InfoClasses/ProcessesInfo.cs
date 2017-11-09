using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class ProcessesInfo : Info
    {
        public ProcessesInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["CreationClassName"]             = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["Caption"]                       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["CommandLine"]                   = Utils.Query("CommandLine", myWMIQueryObject);
                currDictionary["CreationDate"]                  = Utils.Query("CreationDate", myWMIQueryObject);
                currDictionary["CSCreationClassName"]           = Utils.Query("CSCreationClassName", myWMIQueryObject);
                currDictionary["CSName"]                        = Utils.Query("CSName", myWMIQueryObject);
                currDictionary["Description"]                   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["ExecutablePath"]                = Utils.Query("ExecutablePath", myWMIQueryObject);
                currDictionary["ExecutionState"]                = Utils.Query("ExecutionState", myWMIQueryObject);
                currDictionary["Handle"]                        = Utils.Query("Handle", myWMIQueryObject);
                currDictionary["HandleCount"]                   = Utils.Query("HandleCount", myWMIQueryObject);
                currDictionary["InstallDate"]                   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["KernelModeTime"]                = Utils.Query("KernelModeTime", myWMIQueryObject);
                currDictionary["MaximumWorkingSetSize"]         = Utils.Query("MaximumWorkingSetSize", myWMIQueryObject);
                currDictionary["MinimumWorkingSetSize"]         = Utils.Query("MinimumWorkingSetSize", myWMIQueryObject);
                currDictionary["Name"]                          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["OSCreationClassName"]           = Utils.Query("OSCreationClassName", myWMIQueryObject);
                currDictionary["OSName"]                        = Utils.Query("OSName", myWMIQueryObject);
                currDictionary["OtherOperationCount"]           = Utils.Query("OtherOperationCount", myWMIQueryObject);
                currDictionary["OtherTransferCount"]            = Utils.Query("OtherTransferCount", myWMIQueryObject);
                currDictionary["PageFaults"]                    = Utils.Query("PageFaults", myWMIQueryObject);
                currDictionary["PageFileUsage"]                 = Utils.Query("PageFileUsage", myWMIQueryObject);
                currDictionary["ParentProcessId"]               = Utils.Query("ParentProcessId", myWMIQueryObject);
                currDictionary["PeakPageFileUsage"]             = Utils.Query("PeakPageFileUsage", myWMIQueryObject);
                currDictionary["PeakVirtualSize"]               = Utils.Query("PeakVirtualSize", myWMIQueryObject);
                currDictionary["PeakWorkingSetSize"]            = Utils.Query("PeakWorkingSetSize", myWMIQueryObject);
                currDictionary["Priority"]                      = Utils.Query("Priority", myWMIQueryObject);
                currDictionary["PrivatePageCount"]              = Utils.Query("PrivatePageCount", myWMIQueryObject);
                currDictionary["ProcessId"]                     = Utils.Query("ProcessId", myWMIQueryObject);
                currDictionary["QuotaNonPagedPoolUsage"]        = Utils.Query("QuotaNonPagedPoolUsage", myWMIQueryObject);
                currDictionary["QuotaPagedPoolUsage"]           = Utils.Query("QuotaPagedPoolUsage", myWMIQueryObject);
                currDictionary["QuotaPeakNonPagedPoolUsage"]    = Utils.Query("QuotaPeakNonPagedPoolUsage", myWMIQueryObject);
                currDictionary["QuotaPeakPagedPoolUsage"]       = Utils.Query("QuotaPeakPagedPoolUsage", myWMIQueryObject);
                currDictionary["ReadOperationCount"]            = Utils.Query("ReadOperationCount", myWMIQueryObject);
                currDictionary["ReadTransferCount"]             = Utils.Query("ReadTransferCount", myWMIQueryObject);
                currDictionary["SessionId"]                     = Utils.Query("SessionId", myWMIQueryObject);
                currDictionary["Status"]                        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["TerminationDate"]               = Utils.Query("TerminationDate", myWMIQueryObject);
                currDictionary["ThreadCount"]                   = Utils.Query("ThreadCount", myWMIQueryObject);
                currDictionary["UserModeTime"]                  = Utils.Query("UserModeTime", myWMIQueryObject);
                currDictionary["VirtualSize"]                   = Utils.Query("VirtualSize", myWMIQueryObject);
                currDictionary["WindowsVersion"]                = Utils.Query("WindowsVersion", myWMIQueryObject);
                currDictionary["WorkingSetSize"]                = Utils.Query("WorkingSetSize", myWMIQueryObject);
                currDictionary["WriteOperationCount"]           = Utils.Query("WriteOperationCount", myWMIQueryObject);
                currDictionary["WriteTransferCount"]            = Utils.Query("WriteTransferCount", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
