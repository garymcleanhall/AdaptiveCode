using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyDecoratorExample
{
    public class LazyComponent : IComponent
    {
        public LazyComponent (Lazy<IComponent> lazyComponent)
        {
            this.lazyComponent = lazyComponent;
        }

        public void Something()
        {
            lazyComponent.Value.Something();
        }

        private readonly Lazy<IComponent> lazyComponent;
    }
}
