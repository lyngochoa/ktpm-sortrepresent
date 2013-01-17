using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortRepresent.Message
{
    class ForSubcriber : ISubscriber
    {
        public string Name
        {
            get 
            {
                return "for";
            }
        }


        public void Notify()
        {
            MessageBox.Show("Da nhan message");
        }
    }
}
