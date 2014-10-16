using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterface
{
    public interface IFluentInterface
    {
        IFluentInterface DoSomething();

        IFluentInterface DoSomethingElse();

        void ThisMethodIsNotFluent();
    }
}
