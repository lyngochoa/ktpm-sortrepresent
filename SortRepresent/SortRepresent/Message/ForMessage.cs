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


        public void PostMessage(int iStartIdx, int iEndIdx)
        {
            f.recDrawing(iStartIdx, iEndIdx);
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
