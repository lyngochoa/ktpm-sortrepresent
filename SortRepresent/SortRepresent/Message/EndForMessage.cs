using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    class EndForMessage : IMessage
    {
        public Form1 f;

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
            get { return "endfor"; }
        }

        public void PossMessage(int iStartIdx, int iEndIdx)
        {
            f.removeRectangle(iStartIdx, iEndIdx);
        }
    }
}
