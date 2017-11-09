using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class EnvironmentInfo : Info
    {
        public EnvironmentInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Environment");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]           = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]       = Utils.Query("Description", myWMIQueryObject);
                currDictionary["InstallDate"]       = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["Name"]              = Utils.Query("Name", myWMIQueryObject);
                currDictionary["Status"]            = Utils.Query("Status", myWMIQueryObject);
                currDictionary["SystemVariable"]    = Utils.Query("SystemVariable", myWMIQueryObject);
                currDictionary["UserName"]          = Utils.Query("UserName", myWMIQueryObject);
                currDictionary["VariableValue"]     = Utils.Query("VariableValue", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
