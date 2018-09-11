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
            foreach (Var v in vars)
            {
                if (v.varName == varname)
                {
                    if (v.varType == "int")
                    {
                        returned = Convert.ToInt16(v.varObject);
                    }
                    else
                    {
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
               File.WriteAllText($"{varName}.int", v.ToString());
            }else
            {
                File.WriteAllText($"{varName}.string", v.ToString());
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
        public string pointer;
    }

}
