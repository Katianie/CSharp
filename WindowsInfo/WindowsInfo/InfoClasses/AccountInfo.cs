using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class AccountInfo : Info
    {
        public AccountInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Account");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while(collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["Domain"]        = Utils.Query("Domain", myWMIQueryObject);
                currDictionary["InstallDate"]   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["LocalAccount"]  = Utils.Query("LocalAccount", myWMIQueryObject);
                currDictionary["Name"]          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["SID"]           = Utils.Query("SID", myWMIQueryObject);
                currDictionary["SIDType"]       = Utils.Query("SIDType", myWMIQueryObject);
                currDictionary["Status"]        = Utils.Query("Status", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
