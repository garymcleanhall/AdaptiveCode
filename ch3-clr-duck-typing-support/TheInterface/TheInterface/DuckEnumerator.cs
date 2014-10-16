using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class DuckEnumerator
    {
        int i = 0;

        public bool MoveNext()
        {
            return i++ < 10;
        }

        public int Current
        {
            get
            {
                return i;
            }
        }
    }
}
