using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class PageFileSettingInfo : Info
    {
        public PageFileSettingInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PageFileSetting");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["SettingID"]     = Utils.Query("SettingID", myWMIQueryObject);
                currDictionary["InitialSize"]   = Utils.Query("InitialSize", myWMIQueryObject);
                currDictionary["MaximumSize"]   = Utils.Query("MaximumSize", myWMIQueryObject);
                currDictionary["Name"]          = Utils.Query("Name", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
