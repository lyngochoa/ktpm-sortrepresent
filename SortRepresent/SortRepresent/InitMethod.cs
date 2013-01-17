using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent
{
    class InitMethod
    {
        public void GetArrayRandom()
        {
            VirtualMachine machine = VirtualMachine.Instance;

            machine.cleanElement();

            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                machine.addElement(rd.Next(-100,100));
            }
        }
    }
}
