using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInfo
{
    public class DesktopInfo : Info
    {
        public DesktopInfo() : base()
        {

        }

        public override void LoadData()
        {
            IEnumerator collectionEnumerator;
            Dictionary<string, string> currDictionary;

            myWMISearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Desktop");
            myWMICollection = myWMISearcher.Get();
            collectionEnumerator = myWMICollection.GetEnumerator();

            while (collectionEnumerator.MoveNext())
            {
                myWMIQueryObject = (ManagementObject)collectionEnumerator.Current;
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]               = Utils.Query("Caption", myWMIQueryObject);
                currDictionary["Description"]           = Utils.Query("Description", myWMIQueryObject);
                currDictionary["SettingID"]             = Utils.Query("SettingID", myWMIQueryObject);
                currDictionary["BorderWidth"]           = Utils.Query("BorderWidth", myWMIQueryObject);
                currDictionary["CoolSwitch"]            = Utils.Query("CoolSwitch", myWMIQueryObject);
                currDictionary["CursorBlinkRate"]       = Utils.Query("CursorBlinkRate", myWMIQueryObject);
                currDictionary["DragFullWindows"]       = Utils.Query("DragFullWindows", myWMIQueryObject);
                currDictionary["GridGranularity"]       = Utils.Query("GridGranularity", myWMIQueryObject);
                currDictionary["IconSpacing"]           = Utils.Query("IconSpacing", myWMIQueryObject);
                currDictionary["IconTitleFaceName"]     = Utils.Query("IconTitleFaceName", myWMIQueryObject);
                currDictionary["IconTitleSize"]         = Utils.Query("IconTitleSize", myWMIQueryObject);
                currDictionary["IconTitleWrap"]         = Utils.Query("IconTitleWrap", myWMIQueryObject);
                currDictionary["Name"]                  = Utils.Query("Name", myWMIQueryObject);
                currDictionary["Pattern"]               = Utils.Query("Pattern", myWMIQueryObject);
                currDictionary["ScreenSaverActive"]     = Utils.Query("ScreenSaverActive", myWMIQueryObject);
                currDictionary["ScreenSaverExecutable"] = Utils.Query("ScreenSaverExecutable", myWMIQueryObject);
                currDictionary["ScreenSaverSecure"]     = Utils.Query("ScreenSaverSecure", myWMIQueryObject);
                currDictionary["ScreenSaverTimeout"]    = Utils.Query("ScreenSaverTimeout", myWMIQueryObject);
                currDictionary["Wallpaper"]             = Utils.Query("Wallpaper", myWMIQueryObject);
                currDictionary["WallpaperStretched"]    = Utils.Query("WallpaperStretched", myWMIQueryObject);
                currDictionary["WallpaperTiled"]        = Utils.Query("WallpaperTiled", myWMIQueryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
