using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Syntaxs
{
    public class VarSyntax : Syntax
    {
        public VarSyntax()
        {
            _name = "var";
        }

        public override void Do(XmlNode node)
        {
            //base.Do();
            string strVar = node.InnerText;

            string type = strVar.Substring(0, strVar.IndexOf(' '));

            string name = strVar.Substring(strVar.IndexOf(' ') + 1);

            VirtualMachine machine = VirtualMachine.Instance;

            Variable temp = machine.getVar(name);

            if (temp == null)
            {
                Variable var = new Variable(type, name, null);

                machine.addVar(var);
            }
        }
    }
}
