using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace cs_secpol
{
    public class SecurityPolicy
    {
        static string tempFile = @"C:\temp.ini";
        public SecurityPolicy()
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
            p.StartInfo.Arguments = String.Format("/export /cfg \"{0}\" /quiet", tempFile);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

        }
        public bool EditPol(string Location, string Value)
        {
            System.Threading.Thread.Sleep(300);
            StringBuilder newCfg = new StringBuilder();
            string[] cfg = File.ReadAllLines(tempFile);
            bool found = false;
            foreach (string line in cfg)
            {
                if (line.Contains(Location))
                {
                    try
                    {
                        newCfg.AppendLine(line.Replace(line.Split(' ')[2], Value));
                        found = true;
                        continue;
                    }
                    catch
                    {
                        newCfg.AppendLine(line.Replace(line.Split('=')[1].Replace(" ", ""), Value));
                    }
                }
                newCfg.AppendLine(line);
            }

            File.WriteAllText(tempFile, newCfg.ToString());
            return found;
        }
        public void Finished()
        {


            Process p2 = new Process();
            p2.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
            p2.StartInfo.Arguments = String.Format("/configure /db secedit.sdb /cfg \"{0}\" /quiet", tempFile);
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.UseShellExecute = false;
            p2.Start();
            p2.WaitForExit();
        }

    }
    public class PrivilegePolicy
    {
        private string tempFile = @"C:\temp2.ini";
        public PrivilegePolicy()
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
            p.StartInfo.Arguments = String.Format("/export /cfg \"{0}\" /quiet", tempFile);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
        }
        public void EditPol(string Location, string Value)
        {
            StringBuilder newCfg = new StringBuilder();
            string[] cfg = File.ReadAllLines(tempFile);

            foreach (string line in cfg)
            {
                if (line.Contains("PasswordComplexity"))
                {
                    newCfg.AppendLine(line.Replace("1", "0"));
                    continue;
                }
                newCfg.AppendLine(line);
            }
            File.WriteAllText(tempFile, newCfg.ToString());

        }
        public void Finished()
        {
            Process p2 = new Process();
            p2.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
            p2.StartInfo.Arguments = String.Format("/configure /db secedit.sdb /cfg \"{0}\" /quiet", tempFile);
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.UseShellExecute = false;
            p2.Start();
            p2.WaitForExit();
        }
    }

}
