using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bpp_env;
using System.IO;
using System.Diagnostics;

namespace bpp_bpp
{
    public class Runner
    {
        public static void Compile(string scriptLocation, Env e)
        {
            Console.WriteLine("[B++] Preparing to compile...");
            string script = File.ReadAllText(scriptLocation);
            foreach (CustomCommand c in e.Commands)
            {
                script = script.Replace($"{c.commandSpace}.{c.command}", $"{c.commandSpace}/{c.command}");
            }
            foreach (string line in File.ReadAllLines(scriptLocation))
            {
                string newLine = line;
                //if we are creating a new variable
                if (line.Contains("var "))
                {
                    //Are we creating a string variable?
                    if (line.Contains('"'))
                    {
                        Console.WriteLine($"[B++] Creating variable {line.Split(' ')[1]} setting trigger to {line.Split('"')[1]}");
                        e.setVar(line.Split(' ')[1], line.Split('"')[1]);
                        newLine = $"{line.Split('"')[1]} > env/{line.Split(' ')[1]}.string";
                    }
                    else
                    {
                        Console.WriteLine($"[B++] Creating variable {line.Split(' ')[1]}");
                        e.setVar(line.Split(' ')[1], Convert.ToInt32(line.Split(' ')[2]));
                        newLine = $"{line.Split(' ')[2]} > env/{line.Split(' ')[1]}.int";
                    }
                }
                //Are we reading a variable?
                if (line.Contains("var."))
                {
                    //Is the variable we are wanting to get an int?
                    object varRef = e.getVar(line.Split('.')[1]);
                    if (typeof(int) == varRef.GetType())
                    {
                        string n = line;
                        newLine = $"set /p /A {line.Split('.')[1]}=<env/{line.Split('.')[1]}.int {Environment.NewLine}" +
                            $"{n.Replace($"var.{line.Split('.')[1]}", $"%{line.Split('.')[1]}%")}";
                    }
                    else
                    {
                        string n = line;
                        newLine = $"set /p {line.Split('.')[1]}=<env/{line.Split('.')[1]}.string {Environment.NewLine}" +
                            $"{n.Replace($"var.{line.Split('.')[1]}", $"%{line.Split('.')[1]}%")}";
                    }
                }
                Console.WriteLine($"[B++] Rewrite {line} > {newLine}");
                script = script.Replace(line, newLine);
            }
            StreamWriter sw = new StreamWriter("build.bat");
            sw.WriteLine(script);
            sw.Close();
            sw.Dispose();
            
        }
        public static void Run(string scriptLocation,Env e)
        {
            Console.WriteLine("[B++] Preparing to compile...");
            string script = File.ReadAllText(scriptLocation);
            foreach (CustomCommand c in e.Commands)
            {
                script = script.Replace($"{c.commandSpace}.{c.command}", $"{c.commandSpace}/{c.command}");
            }
            foreach (string line in File.ReadAllLines(scriptLocation))
            {
                string newLine = line;
                //if we are creating a new variable
                if (line.Contains("var "))
                {
                    //Are we creating a string variable?
                    if (line.Contains('"'))
                    {
                        Console.WriteLine($"[B++] Creating variable {line.Split(' ')[1]} setting trigger to {line.Split('"')[1]}");
                        e.setVar(line.Split(' ')[1], line.Split('"')[1]);
                        newLine = $"{line.Split('"')[1]} > env/{line.Split(' ')[1]}.string";
                    }
                    else
                    {
                        Console.WriteLine($"[B++] Creating variable {line.Split(' ')[1]}");
                        e.setVar(line.Split(' ')[1], Convert.ToInt32(line.Split(' ')[2]));
                        newLine = $"{line.Split(' ')[2]} > env/{line.Split(' ')[1]}.int";
                    }
                }
                //Are we reading a variable?
                if (line.Contains("var."))
                {
                    //Is the variable we are wanting to get an int?
                    object varRef = e.getVar(line.Split('.')[1]);
                    if (typeof(int) == varRef.GetType())
                    {
                        string n = line;
                        newLine = $"set /p /A {line.Split('.')[1]}=<env/{line.Split('.')[1]}.int {Environment.NewLine}" +
                            $"{n.Replace($"var.{line.Split('.')[1]}", $"%{line.Split('.')[1]}%")}";
                    }
                    else
                    {
                        string n = line;
                        newLine = $"set /p {line.Split('.')[1]}=<env/{line.Split('.')[1]}.string {Environment.NewLine}" +
                            $"{n.Replace($"var.{line.Split('.')[1]}", $"%{line.Split('.')[1]}%")}";
                    }
                }
                Console.WriteLine($"[B++] Rewrite {line} > {newLine}");
                script = script.Replace(line, newLine);
            }
            StreamWriter sw = new StreamWriter("build.bat");
            sw.WriteLine(script);
            sw.Close();
            sw.Dispose();
            Process.Start("build.bat");
        }

      
    }
}
