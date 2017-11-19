using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class Utils
    {
        public static string Query(string propertyName, ManagementObject myWMIQueryObject)
        {
            string[] retVals;
            string retVal = null;
            object data = null;

            if (myWMIQueryObject != null)
            {
                try
                {
                    data = myWMIQueryObject[propertyName];
                }
                catch (Exception ex)
                {
                    //Property not found.
                    Console.Error.WriteLine("Query(): Error, failed to find property!");
                    return null;
                }

                if (data != null)
                {
                    if ((data is string) == true)
                    {
                        retVal = data as string;
                        if (string.IsNullOrEmpty(retVal) == false)
                        {
                            return retVal;
                        }
                    }
                    else if ((data is string[]) == true)
                    {
                        retVals = data as string[];
                        for (int i = 0; i < retVals.Length; i++)
                        {
                            if (string.IsNullOrEmpty(retVals[i]) == false)
                            {
                                retVal += retVals[i];
                            }
                        }

                        return retVal;
                    }
                }
            }

            return null;
        }

        //Removes any entries in the dictionary where the value is null or empty string.
        public static Dictionary<string, string> RemoveNullsFromDictionary(ref Dictionary<string, string> dictionaryWithNulls)
        {
            Dictionary<string, string> retVal = null;

            if (dictionaryWithNulls != null)
            {
                retVal = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> currentEntry in dictionaryWithNulls)
                {
                    if (string.IsNullOrEmpty(currentEntry.Value) == false)
                    {
                        retVal.Add(currentEntry.Key, currentEntry.Value);
                    }
                }

                dictionaryWithNulls.Clear();
            }

            return retVal;
        }

        public static List<Dictionary<string, string>> RemoveNullsFromListOfDictionaries(ref List<Dictionary<string, string>> listOfDictionariesWithNulls)
        {
            Dictionary<string, string> currDictionary;

            if(listOfDictionariesWithNulls != null)
            {
                for (int currDictionaryIndex = 0; currDictionaryIndex < listOfDictionariesWithNulls.Count; currDictionaryIndex++)
                {
                    //Get current dictionary.
                    currDictionary = listOfDictionariesWithNulls[currDictionaryIndex];

                    //Remove any empty string or null values from the dictionary.
                    currDictionary = Utils.RemoveNullsFromDictionary(ref currDictionary);

                    //Re-add the dictionary back to the data list.
                    listOfDictionariesWithNulls[currDictionaryIndex] = currDictionary;
                }
            }

            return listOfDictionariesWithNulls;
        }
    }
}
