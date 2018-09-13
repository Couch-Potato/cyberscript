using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_regedit;
namespace registry
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "set")
            {
                reg.setKey(args[1], args[2], args[3]);
            }
            else if (args[0] == "add")
            {
                reg.addKey(args[1], args[2], args[3]);
            }
        }
    }
}
