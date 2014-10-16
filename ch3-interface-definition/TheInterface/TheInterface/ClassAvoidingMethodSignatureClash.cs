using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ClassAvoidingMethodSignatureClash : IInterfaceOne
    {
        public void MethodOne()
        {
            // original implementation
        }

        void IInterfaceOne.MethodOne()
        {
            // new implementation
        }
    }
}
