using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace WindowsInfo
{
    public abstract class Info
    {
        protected ManagementObject myWMIQueryObject;
        protected ManagementObjectSearcher myWMISearcher;
        protected ManagementObjectCollection myWMICollection;
        protected List<Dictionary<string, string>> myData;

        ///Constructor
        public Info()
        {
            myWMIQueryObject = null;
            myWMISearcher = null;
            myWMICollection = null;
            myData = new List<Dictionary<string, string>>();
        }

        ///Functions that MUST be implemented by children.
        public abstract void LoadData();

        ///Functions that MAY be implemented by children.
        public override string ToString()
        {
            string currOutput;
            StringBuilder finishedOutput;

            if (myData.Count > 0)
            {
                finishedOutput = new StringBuilder();

                //Print the derived class name so we know where the data came from.
                currOutput = string.Format("========{0}========", this.GetType().Name);
                finishedOutput.AppendLine(currOutput);
                foreach (Dictionary<string, string> currDictionary in myData)
                {
                    //Go through each item in the dictionary and append the data to the string builder.
                    foreach (KeyValuePair<string, string> currentEntry in currDictionary)
                    {
                        //Efficient string concatenation.
                        currOutput = string.Format("{0}={1}", currentEntry.Key, currentEntry.Value);
                        finishedOutput.AppendLine(currOutput);
                    }

                    finishedOutput.AppendLine();
                }

                return finishedOutput.ToString();
            }

            return null;
        }

        ///Functions
        public void Dispose()
        {
            if(myData != null)
            {
                myData.Clear();
            }

            if(myWMICollection != null)
            {
                myWMICollection.Dispose();
            }

            if (myWMIQueryObject != null)
            {
                myWMIQueryObject.Dispose();
            }

            if (myWMISearcher != null)
            {
                myWMISearcher.Dispose();
            }
        }
    }
}
