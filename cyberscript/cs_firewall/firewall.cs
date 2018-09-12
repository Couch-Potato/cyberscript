using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
namespace cs_firewall
{
    public class firewall
    {
        static INetFwRule firewallRule;
        static INetFwMgr fwMgr;
        static INetFwPolicy2 firewallPolicy;
        public static void firewallDo(int port)
        {

            firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            fwMgr = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWMgr"));
                firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

                
               
                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";
                firewallRule.Name = "Auto_Deny_" + port.ToString();
                firewallRule.Description = "Cyberscript " + DateTime.Now.ToString("HH:mm:ss tt");
                firewallRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                firewallRule.LocalPorts = port.ToString();
                firewallPolicy.Rules.Add(firewallRule);
           

        }
        public static void firewallDo()
        {
            firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL] = true;
            fwMgr = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWMgr"));
           
            fwMgr.LocalPolicy.CurrentProfile.FirewallEnabled = true;
            
        }
    }
}
