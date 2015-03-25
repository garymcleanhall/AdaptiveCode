using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ClashingMethodSignatures
    {
        public void MethodA()
        {

        }

        // This would cause a clash with the method above:
        //public void MethodA()
        //{

        //}

        // As would this: return values are not considered
        //public int MethodA()
        //{
        //    return 0;
        //}

        public int MethodB(int x)
        {
            return x;
        }

        // There is no clash here: the parameters differ.
        // This is an overload of the previous MethodB.
        public int MethodB(int x, int y)
        {
            return x + y;
        }
    }
}
