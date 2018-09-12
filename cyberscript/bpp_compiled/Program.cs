using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
namespace bpp_compiled
{
    class Program
    {
        public static void Extract(String filename, String location)
        {
            //  Assembly assembly = Assembly.GetExecutingAssembly();
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            // Stream stream = assembly.GetManifestResourceStream("bpp_compiled"); // or whatever 
            // string my_namespace = a.GetName().Name.ToString();
            Stream resFilestream = a.GetManifestResourceStream(filename);
            if (resFilestream != null)
            {
                BinaryReader br = new BinaryReader(resFilestream);
                FileStream fs = new FileStream(location, FileMode.Create); // say 
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                bw.Write(ba);
                br.Close();
                bw.Close();
                resFilestream.Close();
            }


        }
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
                Directory.Delete("env/", true);

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
                Extract("lib.bin", AppDomain.CurrentDomain.BaseDirectory + "/temp/lib.bin");
                ZipFile.ExtractToDirectory("temp/lib.bin", "cs/");
                Extract("cyberscript.exe", AppDomain.CurrentDomain.BaseDirectory + "/cyberscript.exe");
            }
            StreamWriter s = new StreamWriter("temp/build.bat");
            s.WriteLine(b.Replace('☻', '"'));
            s.Close();
            s.Dispose();
            Process p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/temp/build.bat");
            p.WaitForExit();
        }
    }
}
