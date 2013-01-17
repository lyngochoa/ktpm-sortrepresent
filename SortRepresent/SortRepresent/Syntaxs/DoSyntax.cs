using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Syntaxs
{
    class DoSyntax : Syntax
    {
        public DoSyntax()
        {
            this._name = "do";
        }

        public override void Do(System.Xml.XmlNode node)
        {
            //base.Do(node);
            VirtualMachine machine = VirtualMachine.Instance;

            int n = node.ChildNodes.Count;

            for (int i = 0; i < n; i++)
            {
                XmlNode temp = node.ChildNodes.Item(i);

                Syntaxs.Syntax syn = machine.getSyntax(temp.Name);

                if (syn != null)
                {
                    syn.Do(temp);
                }
            }
        }
    }
}
