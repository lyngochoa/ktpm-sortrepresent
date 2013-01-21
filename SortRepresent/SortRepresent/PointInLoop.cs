using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortRepresent
{
    class PointInLoop
    {
        private int _i;

        public int I
        {
            get { return _i; }
            set { _i = value; }
        }

        private int _j;

        public int J
        {
            get { return _j; }
            set { _j = value; }
        }

        public PointInLoop(int i, int j)
        {
            _i = i;

            _j = j;
        }
    }
}
