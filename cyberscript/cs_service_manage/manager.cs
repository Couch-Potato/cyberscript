using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using Microsoft.Win32;

namespace cs_service_manage
{
    public class manager
    {
        public static void Stop(string handle)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.DisplayName == handle)
                {
                    service.Stop();
                }
            }
        }
        public static void Start(string handle)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.DisplayName == handle)
                {
                    service.Start();
                }
            }
        }
        public static void Disable(string handle)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + handle, true);
            key.SetValue("Start", 4);
        }
    }
}
