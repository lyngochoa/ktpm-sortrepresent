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

            if (iStartIdx < iEndIdx)
            {
                PostMessage(Name, iStartIdx, iEndIdx - 1);
            }
            else
            {
                if (iStartIdx > iEndIdx)
                {
                    PostMessage(Name, iEndIdx + 1, iStartIdx);
                }
            }

            for (int Idx = iStartIdx; Idx != iEndIdx; )
            {
                PostMessage("select", Idx, Idx);

                syn.Do(child);

                PostMessage("deselect", Idx, Idx);

                Idx = Int32.Parse(machine.getVar(sStartIdx).Value);
            }

            if (iStartIdx > iEndIdx)
            {
                PostMessage("endfor", iEndIdx + 1, iStartIdx);
            }
            else 
            {
                if (iStartIdx < iEndIdx)
                {
                    PostMessage("endfor", iStartIdx, iEndIdx - 1);
                }
                else
                {
                    PostMessage("endfor", iStartIdx - 1, iEndIdx - 1);
                }
            }
        }
    }
}
