using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class PageFileUsageInfo : Info
    {
        public PageFileUsageInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PageFileUsage");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]           = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]       = Utils.Query("Description", myWMIQueryObject);
                currDictionary["InstallDate"]       = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["Status"]            = Utils.Query("Status", myWMIQueryObject);
                currDictionary["AllocatedBaseSize"] = Utils.Query("AllocatedBaseSize", myWMIQueryObject);
                currDictionary["CurrentUsage"]      = Utils.Query("CurrentUsage", myWMIQueryObject);
                currDictionary["Name"]              = Utils.Query("Name", myWMIQueryObject);
                currDictionary["PeakUsage"]         = Utils.Query("PeakUsage", myWMIQueryObject);
                currDictionary["TempPageFile"]      = Utils.Query("TempPageFile", myWMIQueryObject);
  
                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
