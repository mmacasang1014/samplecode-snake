using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class Cell
    {
        public char val
        {
            get;
            set;
        }
        public int x
        {
            get;
            set;
        }
        public int y
        {
            get;
            set;
        }
        public bool visited
        {
            get;
            set;
        }
        public int decay
        {
            get;
            set;
        }

        public void Decay()
        {
            decay -= 1;
            if (decay == 0)
            {
                visited = false;
                val = Level.VOID;
            }
        }

        public void Clear()
        {
            val = Level.VOID;
        }

        public void Set(char newVal)
        {
            val = newVal;
        }
    }
}
