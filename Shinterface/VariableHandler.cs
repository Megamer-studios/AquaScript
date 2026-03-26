using System;
using System.Collections.Generic;
using System.Text;

namespace Shinterface
{
    internal class VariableHandler
    {
        public static string HandleStrings(string a) {
           a = a.Replace("{osplatform}", Environment.OSVersion.Platform.ToString());
            a = a.Replace("{osversion}", Environment.OSVersion.VersionString);
            a = a.Replace("{osspm}", Environment.OSVersion.ServicePack);
            a = a.Replace("{pcname}", Environment.MachineName.ToString());
            return a;
        }

        //await NewLine("   OS Platform : " + Environment.OSVersion.Platform.ToString(), Color.Aquamarine, null);
        //await NewLine("   OS Version : " + Environment.OSVersion.VersionString, Color.Aquamarine, null);
        //await NewLine("   OS SP : " + Environment.OSVersion.ServicePack, Color.Aquamarine, null);
        //await NewLine("   PC Name : " + Environment.MachineName, Color.Aquamarine, null);
        //await NewLine("   Is 64bit? : " + Environment.Is64BitOperatingSystem.ToString(), Color.Aquamarine, null);

    }
}
