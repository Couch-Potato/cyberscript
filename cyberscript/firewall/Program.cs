using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firewall
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "add")
            {
                cs_firewall.firewall.firewallDo(Convert.ToInt16(args[1]));
            }
            else if (args[0] == "on")
            {
                cs_firewall.firewall.firewallDo();
            }
        }
    }
}
