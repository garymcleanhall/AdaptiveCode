using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AsyncDecorator
{
    public class AsyncComponent : IComponent
    {
        public AsyncComponent(IComponent decoratedComponent)
        {
            this.decoratedComponent = decoratedComponent;
        }

        public void Process()
        {
            Task.Run((Action)decoratedComponent.Process);
        }

        private readonly IComponent decoratedComponent;
    }
}
