using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class DirectoryInfo : Info
    {
        public DirectoryInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            //myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Directory"); //Quota Violation
            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Directory WHERE Hidden = True");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"] = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"] = Utils.Query("Description", myWMIQueryObject);
                currDictionary["InstallDate"] = Utils.Query("InstallDate", myWMIQueryObject);
                currDictionary["Name"] = Utils.Query("Name", myWMIQueryObject);
                currDictionary["Status"] = Utils.Query("Status", myWMIQueryObject);
                currDictionary["AccessMask"] = Utils.Query("AccessMask", myWMIQueryObject);
                currDictionary["Archive"] = Utils.Query("Archive", myWMIQueryObject);
                currDictionary["Compressed"] = Utils.Query("Compressed", myWMIQueryObject);
                currDictionary["CompressionMethod"] = Utils.Query("CompressionMethod", myWMIQueryObject);
                currDictionary["CreationClassName"] = Utils.Query("CreationClassName", myWMIQueryObject);
                currDictionary["CreationDate"] = Utils.Query("CreationDate", myWMIQueryObject);
                currDictionary["CSCreationClassName"] = Utils.Query("CSCreationClassName", myWMIQueryObject);
                currDictionary["CSName"] = Utils.Query("CSName", myWMIQueryObject);
                currDictionary["Drive"] = Utils.Query("Drive", myWMIQueryObject);
                currDictionary["EightDotThreeFileName"] = Utils.Query("EightDotThreeFileName", myWMIQueryObject);
                currDictionary["Encrypted"] = Utils.Query("Encrypted", myWMIQueryObject);
                currDictionary["EncryptionMethod"] = Utils.Query("EncryptionMethod", myWMIQueryObject);
                currDictionary["Extension"] = Utils.Query("Extension", myWMIQueryObject);
                currDictionary["FileName"] = Utils.Query("FileName", myWMIQueryObject);
                currDictionary["FileSize"] = Utils.Query("FileSize", myWMIQueryObject);
                currDictionary["FileType"] = Utils.Query("FileType", myWMIQueryObject);
                currDictionary["FSCreationClassName"] = Utils.Query("FSCreationClassName", myWMIQueryObject);
                currDictionary["FSName"] = Utils.Query("FSName", myWMIQueryObject);
                currDictionary["Hidden"] = Utils.Query("Hidden", myWMIQueryObject);
                currDictionary["InUseCount"] = Utils.Query("InUseCount", myWMIQueryObject);
                currDictionary["LastAccessed"] = Utils.Query("LastAccessed", myWMIQueryObject);
                currDictionary["LastModified"] = Utils.Query("LastModified", myWMIQueryObject);
                currDictionary["Path"] = Utils.Query("Path", myWMIQueryObject);
                currDictionary["Readable"] = Utils.Query("Readable", myWMIQueryObject);
                currDictionary["System"] = Utils.Query("System", myWMIQueryObject);
                currDictionary["Writeable"] = Utils.Query("Writeable", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
