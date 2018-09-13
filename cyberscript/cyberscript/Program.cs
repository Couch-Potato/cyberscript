using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using bpp_bpp;
using bpp_env;
using System.IO.Compression;
namespace cyberscript
{
    class Program
    {
        static Env e;
        static void addEnvCommand(string command)
        {
            e.Commands.Add(new CustomCommand("cs", command));
            Console.WriteLine($"Processing trigger for: cs.{command}");
        }
        static void Install()
        {

        }
        
        static void Main(string[] args)
        {
            if (args[0] == "version")
            {
                if (args[1] != null)
                {
                    Console.WriteLine("1.1.0");
                }
                else
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("Cyberscript Version: 1.1.0");
                    Console.WriteLine("Batch Plus Plus: 1.0.3");
                    Console.WriteLine($"Cyberscript installed:  {Directory.Exists("cs").ToString()}");
                    Console.WriteLine("=================================");
                }
                
            }
            else if (args[0] == "install")
            {
                if (Directory.Exists("cs"))
                {
                    Console.WriteLine("Cyberscript is already installed.");
                }
                else
                {
                    Install();
                }
            }
            else if (args[0] == "run")
            {
                Console.WriteLine("Preparing to run file...");
                if (Directory.Exists("cs"))
                {
                    Console.WriteLine("Creating enviornment...");
                    e = new Env();
                    addEnvCommand("services");
                    addEnvCommand("user");
                    addEnvCommand("file");
                    addEnvCommand("audit");
                    addEnvCommand("internet");
                    addEnvCommand("secpol");
                    addEnvCommand("gui");
                    addEnvCommand("firewall");
                    Console.WriteLine("Starting script engine...");
                    Runner.Run(args[1], e);
                }
                else
                {
                    Console.WriteLine("[!] Cyberscript is not installed! Do 'cyberscript install' to install it.");
                }
            }
            else if (args[0] == "compile")
            {
                Console.WriteLine("Creating enviornment...");
                e = new Env();
                addEnvCommand("services");
                addEnvCommand("user");
                addEnvCommand("file");
                addEnvCommand("audit");
                addEnvCommand("internet");
                addEnvCommand("secpol");
                addEnvCommand("gui");
                addEnvCommand("firewall");
                if (Directory.Exists("bin/"))
                {
                    Directory.Delete("bin/", true);
                }
                Directory.CreateDirectory("bin/");
                Console.WriteLine("Preparing compiler...");
                Console.WriteLine("Compressing script libraries... (Cyberscript)");
                if (File.Exists("lib.bin"))
                {
                    File.Delete("lib.bin");
                }
                ZipFile.CreateFromDirectory("cs", "lib.bin");
                
                //string lib = File.ReadAllText("lib.bin");
                Console.WriteLine($"Compiling script... ({args[1]})");
                Runner.Compile(args[1], e);
                string script = File.ReadAllText("build.bat");
                script = script.Replace('"', '☻');
                Console.WriteLine($"Compiling executable... ({args[2]})");
                Console.WriteLine("Reading base...");
                string baseFile = File.ReadAllText("cs/comp/comp.bin");
                //baseFile = baseFile.Replace("%z%", lib);
                baseFile = baseFile.Replace("%b%", script);
                Console.WriteLine("Building...");
                TestCompiler.CompileCSharpCode(baseFile, "bin/"+args[2]);
                
                Console.WriteLine("Done.");
            }

        }
    }
}
