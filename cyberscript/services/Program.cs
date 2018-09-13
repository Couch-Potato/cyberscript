using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_service_scan;
using cs_service_manage;
namespace services
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "list")
            {
                foreach (string s in scanner.getServices())
                {
                    Console.WriteLine(s);
                }
            }
            if (args[0] == "get")
            {
                Console.WriteLine(scanner.getService(args[1]));
            }
            if (args[0] == "stop")
            {
                manager.Stop(args[1]);
            }
            if (args[0] == "start")
            {
                manager.Start(args[1]);
            }
            if (args[0] == "disable")
            {
                manager.Disable(args[1]);
            }
        }
    }
}
