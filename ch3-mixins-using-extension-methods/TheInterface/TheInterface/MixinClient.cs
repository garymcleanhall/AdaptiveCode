using Mixins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class MixinClient
    {
        public MixinClient(ITargetInterface target)
        {
            this.target = target;
        }

        public void Run()
        {
            target.DoSomething();
            target.FirstExtensionMethod();
            target.SecondExtensionMethod();
            target.FurtherExtensionMethodA(30);
            target.FurtherExtensionMethodB("Hello!");
        }

        private readonly ITargetInterface target;
    }
}
