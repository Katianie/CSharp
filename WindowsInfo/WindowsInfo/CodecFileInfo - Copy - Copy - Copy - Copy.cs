using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class CodecFileInfo : Info
    {
        public CodecFileInfo() : base()
        {
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CodecFile");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["AccessMask"]            = Utils.Query("AccessMask", queryObject);
                currDictionary["Archive"]               = Utils.Query("Archive", queryObject);
                currDictionary["Caption"]               = Utils.Query("Caption", queryObject);
                currDictionary["Compressed"]            = Utils.Query("Compressed", queryObject);
                currDictionary["CompressionMethod"]     = Utils.Query("CompressionMethod", queryObject);
                currDictionary["CreationClassName"]     = Utils.Query("CreationClassName", queryObject);
                currDictionary["CreationDate"]          = Utils.Query("CreationDate", queryObject);
                currDictionary["CSCreationClassName"]   = Utils.Query("CSCreationClassName", queryObject);
                currDictionary["CSName"]                = Utils.Query("CSName", queryObject);
                currDictionary["Description"]           = Utils.Query("Description", queryObject);
                currDictionary["Drive"]                 = Utils.Query("Drive", queryObject);
                currDictionary["EightDotThreeFileName"] = Utils.Query("EightDotThreeFileName", queryObject);
                currDictionary["Encrypted"]             = Utils.Query("Encrypted", queryObject);
                currDictionary["EncryptionMethod"]      = Utils.Query("EncryptionMethod", queryObject);
                currDictionary["Extension"]             = Utils.Query("Extension", queryObject);
                currDictionary["FileName"]              = Utils.Query("FileName", queryObject);
                currDictionary["FileSize"]              = Utils.Query("FileSize", queryObject);
                currDictionary["FileType"]              = Utils.Query("FileType", queryObject);
                currDictionary["FSCreationClassName"]   = Utils.Query("FSCreationClassName", queryObject);
                currDictionary["FSName"]                = Utils.Query("FSName", queryObject);
                currDictionary["Group"]                 = Utils.Query("Group", queryObject);
                currDictionary["Hidden"]                = Utils.Query("Hidden", queryObject);
                currDictionary["InstallDate"]           = Utils.Query("InstallDate", queryObject);
                currDictionary["InUseCount"]            = Utils.Query("InUseCount", queryObject);
                currDictionary["LastAccessed"]          = Utils.Query("LastAccessed", queryObject);
                currDictionary["LastModified"]          = Utils.Query("LastModified", queryObject);
                currDictionary["Manufacturer"]          = Utils.Query("Manufacturer", queryObject);
                currDictionary["Name"]                  = Utils.Query("Name", queryObject);
                currDictionary["Path"]                  = Utils.Query("Path", queryObject);
                currDictionary["Readable"]              = Utils.Query("Readable", queryObject);
                currDictionary["Status"]                = Utils.Query("Status", queryObject);
                currDictionary["System"]                = Utils.Query("System", queryObject);
                currDictionary["Version"]               = Utils.Query("Version", queryObject);
                currDictionary["Writeable"]             = Utils.Query("Writeable", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
