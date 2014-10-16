using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    public class FluentImplementation : IFluentInterface
    {
        public IFluentInterface DoSomething()
        {
            return this;
        }

        public IFluentInterface DoSomethingElse()
        {
            return this;
        }

        public void ThisMethodIsNotFluent()
        {
            
        }
    }
}
