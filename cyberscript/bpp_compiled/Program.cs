using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
namespace bpp_compiled
{
    class Program
    {
        private static void Extract(string ressource, string outputPath)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetCallingAssembly();
            string nameSpace = typeof(Program).Namespace;
            using (Stream stream = assembly.GetManifestResourceStream(nameSpace + ".res." + ressource))
            using (BinaryReader reader = new BinaryReader(stream))
                File.WriteAllBytes(outputPath, reader.ReadBytes((int) stream.Length));﻿
        }
        static void Main(string[] args)
        {
            Console.WriteLine("==============================");
            Console.WriteLine(" Script Made With Cyberscript ");
            Console.WriteLine(" View our project on github!");
            Console.WriteLine("==============================");
            
            string b = @"%b%";
            if (Directory.Exists("env/"))
            {
                Directory.Delete("env/");
                
            }
            Directory.CreateDirectory("env/");
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            if (!Directory.Exists("cs"))
            {
                Console.WriteLine("Extracting Cyberscript binarys");
                Directory.CreateDirectory("cs");
                Extract("lib.bin", AppDomain.CurrentDomain.BaseDirectory + "temp/bin.bin/");
                ZipFile.ExtractToDirectory("temp/bin.bin", "cs/");
            }
            StreamWriter s = new StreamWriter("temp/build.bat");
            s.WriteLine(b.Replace('░', '"'));
            s.Close();
            s.Dispose();
            Process p = Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}/temp/build.bat");
            p.WaitForExit();
        }
    }
}
