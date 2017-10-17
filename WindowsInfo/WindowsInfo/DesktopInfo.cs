using System;
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
            this.LoadData();
        }

        public override void LoadData()
        {
            Dictionary<string, string> currDictionary;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Desktop");
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject queryObject in collection)
            {
                currDictionary = new Dictionary<string, string>();

                currDictionary["Caption"]               = Utils.Query("Caption", queryObject);
                currDictionary["Description"]           = Utils.Query("Description", queryObject);
                currDictionary["SettingID"]             = Utils.Query("SettingID", queryObject);
                currDictionary["BorderWidth"]           = Utils.Query("BorderWidth", queryObject);
                currDictionary["CoolSwitch"]            = Utils.Query("CoolSwitch", queryObject);
                currDictionary["CursorBlinkRate"]       = Utils.Query("CursorBlinkRate", queryObject);
                currDictionary["DragFullWindows"]       = Utils.Query("DragFullWindows", queryObject);
                currDictionary["GridGranularity"]       = Utils.Query("GridGranularity", queryObject);
                currDictionary["IconSpacing"]           = Utils.Query("IconSpacing", queryObject);
                currDictionary["IconTitleFaceName"]     = Utils.Query("IconTitleFaceName", queryObject);
                currDictionary["IconTitleSize"]         = Utils.Query("IconTitleSize", queryObject);
                currDictionary["IconTitleWrap"]         = Utils.Query("IconTitleWrap", queryObject);
                currDictionary["Name"]                  = Utils.Query("Name", queryObject);
                currDictionary["Pattern"]               = Utils.Query("Pattern", queryObject);
                currDictionary["ScreenSaverActive"]     = Utils.Query("ScreenSaverActive", queryObject);
                currDictionary["ScreenSaverExecutable"] = Utils.Query("ScreenSaverExecutable", queryObject);
                currDictionary["ScreenSaverSecure"]     = Utils.Query("ScreenSaverSecure", queryObject);
                currDictionary["ScreenSaverTimeout"]    = Utils.Query("ScreenSaverTimeout", queryObject);
                currDictionary["Wallpaper"]             = Utils.Query("Wallpaper", queryObject);
                currDictionary["WallpaperStretched"]    = Utils.Query("WallpaperStretched", queryObject);
                currDictionary["WallpaperTiled"]        = Utils.Query("WallpaperTiled", queryObject);

                myData.Add(currDictionary);
            }

            //Remove null or empty values from the final dictionary.
            myData = Utils.RemoveNullsFromListOfDictionaries(ref myData);
        }
    }
}
