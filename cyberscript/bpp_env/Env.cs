using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bpp_env
{
    public class Env
    {
        public Env()
        {
            if (Directory.Exists("env/"))
            {
                Directory.Delete("env/",true);
            }
            Directory.CreateDirectory("env/");
        }
        public List<Var> vars = new List<Var>();
        public List<CustomCommand> Commands = new List<CustomCommand>();
        public void loadVars()
        {
            vars.Clear();
            foreach (string file in Directory.GetFiles("env/"))
            {
                vars.Add(new Var(file.Split('.')[1], file.Split('.')[0], File.ReadAllText(file)));
            }
        }
        public object getVar(string varname)
        {
            object returned = null;
            loadVars();
            
            foreach (Var v in vars)
            {
               
                if (v.varName == "env/" + varname)
                {
                    
                    if (v.varType == "int")
                    {
                        returned = Convert.ToInt32(v.varObject);
                    }
                    else
                    {
                        Console.WriteLine("[B++] Returning variable " + varname);
                        returned = v.varObject;
                    }
                }
            }
            return returned;
        }
        public void setVar(string varName, object v)
        {
            if (v.GetType() == typeof(int))
            {
                TextWriter tw = new StreamWriter($"env/{varName}.int", false);
                tw.WriteLine(v.ToString());
                tw.Close();
            }else
            {
                TextWriter tw = new StreamWriter($"env/{varName}.string", false);
                tw.WriteLine(v.ToString());
                tw.Close();
            }
        }
    }
    public class Var
    {
        public string varType;
        public string varName;
        public object varObject;
        public Var(string typ, string name, string objectv)
        {
            varType = typ;
            varName = name;
            varObject = objectv;
        }
       
    }
    public class CustomCommand
    {
        public string commandSpace;
        public string command;
        public CustomCommand(string space, string command_)
        {
            commandSpace = space;
            command = command_;
        }
        
    }

}
