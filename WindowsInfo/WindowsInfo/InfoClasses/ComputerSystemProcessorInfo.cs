using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class ComputerSystemProcessorInfo : Info
    {
        public ComputerSystemProcessorInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProcessor");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["PartComponent"]     = Utils.Query("PartComponent", myWMIQueryObject);
                currDictionary["GroupComponent"]    = Utils.Query("GroupComponent", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
