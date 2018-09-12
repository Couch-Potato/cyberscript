using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
namespace bpp_compiled
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================");
            Console.WriteLine(" Script Made With Cyberscript ");
            Console.WriteLine(" View our project on github!");
            Console.WriteLine("==============================");
            string z = @"%z%";
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
                StreamWriter st = new StreamWriter("temp/bin.bin");
                st.WriteLine("z");
                st.Close();
                st.Dispose();
                z = null;
                ZipFile.ExtractToDirectory("temp/bin.bin", "cs/");
            }
            StreamWriter s = new StreamWriter("temp/build.bat");
            s.WriteLine(b);
            s.Close();
            s.Dispose();
            Process.Start("temp/build.bat");
            Console.ReadLine();
        }
    }
}
