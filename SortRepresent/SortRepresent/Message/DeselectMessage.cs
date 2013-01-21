using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    class DeselectMessage : IMessage
    {
        Form1 f;

        public Form1 F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
            }
        }

        public string Name
        {
            get { return "deselect"; }
        }

        public void PostMessage(int iStartIdx, int iEndIdx)
        {
            f.ResetColorButton(iStartIdx);
        }
    }
}
