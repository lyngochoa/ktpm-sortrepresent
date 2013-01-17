using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    interface ISubscriber
    {
        string Name
        { get; }

        void Notify();
    }
}
