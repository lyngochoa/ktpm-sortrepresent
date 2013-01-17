using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    class SwapMessage : IMessage
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
            get { return "swap"; }
        }

        public void PossMessage(int iStartIdx, int iEndIdx)
        {
            f.moveButtonToChange(iStartIdx, iEndIdx);
        }
    }
}
