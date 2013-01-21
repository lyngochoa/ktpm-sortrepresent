using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    public interface IMessage
    {
        Form1 F{get; set; }

        string Name
        { get; }

        void PostMessage(int iStartIdx, int iEndIdx);
    }
}
