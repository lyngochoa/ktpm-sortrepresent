using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent.Message
{
    class ControlCenter
    {
        protected static List<IMessage> listMessage = new List<IMessage>();
        protected Form1 form = new Form1();

        public ControlCenter()
        {
            listMessage.Add(new ForMessage());
            listMessage.Add(new EndForMessage());
            listMessage.Add(new SwapMessage());
            listMessage.Add(new SelectionMessage());
            listMessage.Add(new DeselectMessage());

            int n = listMessage.Count;

            for (int i = 0; i < n; i++)
            {
                listMessage[i].F = form;
            }

            form.ShowDialog();
        }

        public static void PostMessage(string p, int iStartIdx, int iEndIdx)
        {
            int idx = FindMessageFromName(p);

            if (idx != -1)
            {
                listMessage[idx].PostMessage(iStartIdx, iEndIdx);
            }
        }

        private static int FindMessageFromName(string p)
        {
            int n = listMessage.Count;

            for (int i = 0; i < n; i++)
            {
                if (listMessage[i].Name == p)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
