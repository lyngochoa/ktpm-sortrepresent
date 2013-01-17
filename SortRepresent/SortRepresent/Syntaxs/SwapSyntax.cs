using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Syntaxs
{
    class SwapSyntax : Syntax
    {
        public SwapSyntax()
        {
            _name = "swap";
        }

        public override void Do(System.Xml.XmlNode node)
        {
            string type = node.ChildNodes.Item(0).InnerText;

            string value = node.ChildNodes.Item(1).InnerText;

            string sV1 = value.Substring(0, value.IndexOf(','));
            string sV2 = value.Substring(value.IndexOf(',') + 1);

            VirtualMachine machine = VirtualMachine.Instance;

            int n = int.Parse(machine.getVar(sV1).Value);
            int m = int.Parse(machine.getVar(sV2).Value);

            if (type == "array")
            {
                int t1 = machine.getElement(n);
                int t2 = machine.getElement(m);

                machine.setElement(n, t2);
                machine.setElement(m, t1);

                PossMessage(Name, n, m);
            }
            else 
            {
                machine.setValue(sV1, m.ToString());
                machine.setValue(sV2, n.ToString());
            }
        }

    }
}
