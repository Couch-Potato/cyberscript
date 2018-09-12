using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace cyberscript
{
    class Compile
    {
        public static Assembly CompileSource(string sourceCode, string name)
        {
            CodeDomProvider cpd = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.IO.dll");
            cp.ReferencedAssemblies.Add("System.IO.Compression.dll");
            cp.ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll");
            cp.ReferencedAssemblies.Add("System.Diagnostics.dll");
            cp.GenerateExecutable = true;
            cp.GenerateInMemory = false;

            if (!Directory.Exists("bin"))
            {
                Directory.CreateDirectory("bin");
            }
            
            // Invoke compilation.
            CompilerResults cr = cpd.CompileAssemblyFromSource(cp, sourceCode);
            
            return cr.CompiledAssembly;
        }
    }
}
