using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent
{
    class InitMethod
    {
        public List<int> GetArrayRandom()
        {
            List<int> arr = new List<int>();
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr.Add(rd.Next(-100,100));
            }
            return arr;
        }
    }
}
