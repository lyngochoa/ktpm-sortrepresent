using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SortRepresent.Message;
using System.Threading;

namespace SortRepresent.Syntaxs
{
    class ForSyntax : Syntax
    {
        public ForSyntax()
        {
            this._name = "for";
        }

        public override void Do(XmlNode node)
        {
            VirtualMachine machine = VirtualMachine.Instance;

            string sStartIdx = node.ChildNodes.Item(0).InnerText;

            int iStartIdx = Int32.Parse(machine.getVar(sStartIdx).Value);

            string sEndIdx = node.ChildNodes.Item(1).InnerText;

            int iEndIdx = Int32.Parse(machine.getVar(sEndIdx).Value);

            XmlNode child = node.ChildNodes.Item(2);

            Syntaxs.Syntax syn = machine.getSyntax(child.Name);

            if (iStartIdx != iEndIdx)
            {
                PossMessage(Name, iStartIdx, iEndIdx - 1);
            }

            for (int Idx = iStartIdx; Idx != iEndIdx; )
            {
                syn.Do(child);

                Idx = Int32.Parse(machine.getVar(sStartIdx).Value);
            }

            if (iStartIdx != iEndIdx)
            {
                PossMessage("endfor", iStartIdx, iEndIdx - 1);
            }
            else 
            {
                PossMessage("endfor", iStartIdx - 1, iEndIdx - 1);
            }
        }
    }
}
