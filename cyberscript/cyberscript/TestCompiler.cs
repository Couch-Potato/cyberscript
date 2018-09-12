using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace cyberscript
{
    class TestCompiler
    {
        public static bool CompileCSharpCode(string sourceFile, string exeFile)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // Build the parameters for source compilation.
            CompilerParameters cp = new CompilerParameters();

            // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.IO.dll");
            cp.ReferencedAssemblies.Add("System.IO.Compression.dll");
            cp.ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll");
            if (File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}/lib.bin"))
            {
                Console.WriteLine("Writing binaries...");
                cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}lib.bin");
                Console.WriteLine($"Wrote {AppDomain.CurrentDomain.BaseDirectory}lib.bin to output");
                cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}bpp_bpp.dll");
                cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}bpp_env.dll");
                cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}cyberscript.exe");
            }
            else
            {
                Console.WriteLine("[!] WARNING: Not able to find Core binaries, you may not be able to run this application as standalone.");
            }
           
            // Generate an executable instead of
            // a class library.
            cp.GenerateExecutable = true;

            // Set the assembly file name to generate.
            cp.OutputAssembly = exeFile + ".exe";

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceFile);
            
            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                //Console.WriteLine("Errors building {0} into {1}",
                  //  sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
               // Console.WriteLine("Source {0} built into {1} successfully.",
                 //   sourceFile, cr.PathToAssembly);
            }

            // Return the results of compilation.
            if (cr.Errors.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
