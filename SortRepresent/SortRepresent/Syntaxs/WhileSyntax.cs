using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Syntaxs
{
    class WhileSyntax : Syntax
    {
        public WhileSyntax()
        {
            this._name = "while";
        }

        public override void Do(System.Xml.XmlNode node)
        {
            XmlNodeList conditionNode = node.ChildNodes;

            int n = conditionNode.Count;

            bool b = true;

            Syntaxs.Syntax syn;

            VirtualMachine machine = VirtualMachine.Instance;

            while(true)
            {
                int i = 0;

                b = true;

                while(conditionNode[i].Name == "condition")
                {
                    syn = machine.getSyntax(conditionNode[i].Name);

                    bool temp = syn.DoCondition(conditionNode[i]);

                    b = b && temp;

                    i++;
                }

                if (b)
                {
                    syn = machine.getSyntax(conditionNode[i].Name);
                    syn.Do(conditionNode[i]);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
