using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_secpol;
namespace secpol
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "ppolicy")
            {
                PrivilegePolicy p = new PrivilegePolicy();
                p.EditPol(args[1], args[2]);
                p.Finished();
            }
            else if (args[0] == "spolicy")
            {
                SecurityPolicy s = new SecurityPolicy();
                s.EditPol(args[1], args[2]);
                s.Finished();
            }
            else
            {
                Console.WriteLine("[!] ERROR: Invalid policy type supplied. You can only do ppolicy or sppolicy");
            }
        }
    }
}
