using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsInfo
{
    public abstract class Info
    {
        protected List<Dictionary<string, string>> myData;

        public Info()
        {
            myData = new List<Dictionary<string, string>>();
        }

        public abstract void LoadData();

        public override string ToString()
        {
            string currOutput;
            StringBuilder finishedOutput = new StringBuilder();

            try
            {
                //Print the derived class name so we know where the data came from.
                currOutput = string.Format("===={0}====", this.GetType().Name);
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
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error:{0}", ex.Message);
            }

            return finishedOutput.ToString();
        }
    }
}
