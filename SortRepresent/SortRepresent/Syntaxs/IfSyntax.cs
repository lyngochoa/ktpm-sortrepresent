using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SortRepresent.Syntaxs
{
    class IfSyntax : Syntax
    {
        public IfSyntax()
        {
            this._name = "if";
        }

        public override void Do(System.Xml.XmlNode node)
        {
            //base.Do(node);
            XmlNodeList conditionNode = node.ChildNodes;

            int n = conditionNode.Count;

            bool b = true;

            Syntaxs.Syntax syn;

            VirtualMachine machine = VirtualMachine.Instance;

            for (int i = 0; i < n; i++)
            {
                if (conditionNode[i].Name == "condition")
                {
                    syn = machine.getSyntax(conditionNode[i].Name);

                    bool temp = syn.DoCondition(conditionNode[i]);

                    b = b && temp;
                }
                else
                {
                    if (b)
                    {
                        XmlNode doNode = conditionNode[i];

                        syn = machine.getSyntax(doNode.Name);

                        syn.Do(doNode);

                        break;
                    }
                    else
                    {
                        if (conditionNode[i].Name == "else")
                        {
                            syn = machine.getSyntax(conditionNode[i].ChildNodes[0].Name);

                            syn.Do(conditionNode[i].ChildNodes[0]);
                        }
                    }
                }
            }
        }

        private static bool getConditionValue(XmlNode node)
        {
            VirtualMachine machine = VirtualMachine.Instance;

            string type = node.ChildNodes.Item(0).InnerText;

            string value = node.ChildNodes.Item(1).InnerText;

            string compare = node.ChildNodes.Item(2).InnerText;

            string sV1 = value.Substring(0, value.IndexOf(','));
            string sV2 = value.Substring(value.IndexOf(',') + 1);

            int iV1, iV2;

            iV1 = Int32.Parse(machine.getVar(sV1).Value);
            iV2 = Int32.Parse(machine.getVar(sV2).Value);

            if (type == "array")
            {
                iV1 = machine.getElement(iV1);
                iV2 = machine.getElement(iV2);
            }
                        
            if (compare == ">")
            {
                return iV1 > iV2;
            }

            if (compare == ">")
            {
                return iV1 > iV2;
            }

            if (compare == "<")
            {
                return iV1 < iV2;
            }

            if (compare == "==")
            {
                return iV1 == iV2;
            }

            return false;
        }
    }
}
