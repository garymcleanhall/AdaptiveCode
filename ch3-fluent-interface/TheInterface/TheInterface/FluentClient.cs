using FluentInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class FluentClient
    {
        public FluentClient(IFluentInterface fluent)
        {
            this.fluent = fluent;
        }

        public void Run()
        {
            // without using fluency
            fluent.DoSomething();
            fluent.DoSomethingElse();
            fluent.DoSomethingElse();
            fluent.DoSomething();
            fluent.ThisMethodIsNotFluent();
            
            // using fluency 
            fluent.DoSomething()
                .DoSomethingElse()
                .DoSomethingElse()
                .DoSomething()
                .ThisMethodIsNotFluent();
        }

        private readonly IFluentInterface fluent;
    }
}
