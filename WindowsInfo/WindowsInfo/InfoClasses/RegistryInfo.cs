using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class RegistryInfo : Info
    {
        public RegistryInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Registry");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]       = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]   = Utils.Query("Description", myWMIQueryObject);
                currDictionary["InstallDate"]   = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["Status"]        = Utils.Query("Status", myWMIQueryObject);
                currDictionary["CurrentSize"]   = Utils.Query("CurrentSize", myWMIQueryObject);
                currDictionary["MaximumSize"]   = Utils.Query("MaximumSize", myWMIQueryObject);
                currDictionary["Name"]          = Utils.Query("Name", myWMIQueryObject);
                currDictionary["ProposedSize"]  = Utils.Query("ProposedSize", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
