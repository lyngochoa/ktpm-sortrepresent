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
            XmlNode conditionNode = node.ChildNodes.Item(0);

            bool b = getConditionValue(conditionNode);

            if (b)
            {
                XmlNode doNode = node.ChildNodes.Item(1);

                VirtualMachine machine = VirtualMachine.Instance;

                Syntaxs.Syntax syn = machine.getSyntax(doNode.Name);

                syn.Do(doNode);
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
