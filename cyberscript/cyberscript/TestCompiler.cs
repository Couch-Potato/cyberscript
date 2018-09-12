using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}/lib.bin");
            cp.EmbeddedResources.Add($"{AppDomain.CurrentDomain.BaseDirectory}/cyberscript.exe");
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
