using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    class ForMessage : SortRepresent.Message.IMessage
    {
        public Form1 f;

        public ForMessage()
        {
        }

        public string Name
        {
            get
            {
                return "for";
            }
            //set
            //{
            //    throw new NotImplementedException();
            //}
        }


        public void PossMessage(int iStartIdx, int iEndIdx)
        {
            f.drawRectangle(iStartIdx, iEndIdx);
        }


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
    }
}
