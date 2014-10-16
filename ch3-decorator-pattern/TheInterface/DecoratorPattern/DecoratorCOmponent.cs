using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public class DecoratorComponent : IComponent
    {
        public DecoratorComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void Something()
        {
            SomethingElse();
            decoratedComponent.Something();
        }

        private void SomethingElse()
        {

        }

        private readonly IComponent decoratedComponent;
    }
}
