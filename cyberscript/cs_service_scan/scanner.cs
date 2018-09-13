using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
namespace cs_service_scan
{
    public class scanner
    {
        static ServiceController sc;
        public static List<string> getServices()
        {
            List<string> serv = new List<string>();
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                serv.Add(service.DisplayName);
            }
            return serv;
        }
        public static ServiceDetails getService(string handleName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.DisplayName == handleName)
                {
                    return new ServiceDetails(service.ServiceName, service.ServiceHandle.ToString(), service.Status.ToString(), service.ServiceType.ToString());
                }
            }
            return null;
        }
    }
    public class ServiceDetails
    {
        public string serviceName;
        public string serviceHandle;
        public string serviceStatus;
        public string serviceType;
        public ServiceDetails(string a, string b, string c, string d)
        {
            serviceName = a;
            serviceHandle = b;
            serviceStatus = c;
            serviceType = d;
        }
    }
}
