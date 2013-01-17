using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SortRepresent.Syntaxs;

namespace SortRepresent
{
    public class VirtualMachine
    {
        private List<Variable> vars = new List<Variable>();
        List<Syntax> syn = new List<Syntax>();
        List<int> a = new List<int>();

        private static VirtualMachine instance;

        private VirtualMachine() 
        {
            syn.Add(new VarSyntax());
            syn.Add(new AssignSyntax());
            syn.Add(new ForSyntax());
            syn.Add(new DoSyntax());
            syn.Add(new IfSyntax());
            syn.Add(new SwapSyntax());
        }

        public static VirtualMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VirtualMachine();
                }

                return instance;
            }
        }

        public void addVar(Variable var)
        {
            vars.Add(var);
        }

        public Variable getVar(string name)
        {
            //Variable var;

            int n = vars.Count;

            for (int i = 0; i < n; i++)
            {
                if (vars[i].Name == name)
                {
                    return vars[i];
                }
            }

            return null;
        }

        public void setValue(string name, string value)
        {
            int n = vars.Count;

            for (int i = 0; i < n; i++)
            {
                if (vars[i].Name == name)
                {
                    vars[i].Value = value;

                    return;
                }
            }
        }

        public Syntax getSyntax(string name)
        { 
            int n = syn.Count;
            for (int i = 0; i < n; i++)
            {
                if (syn[i].Name == name)
                {
                    return syn[i];
                }
            }

            return null;
        }

        public int getElement(int i)
        {
            return a[i];
        }

        public void setElement(int i, int value)
        {
            a[i] = value;
        }

        public void cleanElement()
        {
            a.Clear();
        }

        public void addElement(int value)
        {
            a.Add(value);
        }
    }
}
