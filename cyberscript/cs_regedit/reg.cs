using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_regedit
{
    public class reg
    {
        public static void setKey(string path, string key, string value)
        {
            RegistryKey keya = Registry.LocalMachine.OpenSubKey(path, true);
            keya.SetValue(key, value);
        }
        public static void addKey(string path, string key, string value)
        {
            RegistryKey keya = Registry.LocalMachine.CreateSubKey(path, true);
            keya.SetValue(key, value);
        }
    }
}
