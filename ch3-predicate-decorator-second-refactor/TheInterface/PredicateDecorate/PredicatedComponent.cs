using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateDecorate
{
    public class PredicatedComponent : IComponent
    {
        public PredicatedComponent(IComponent decoratedComponent, IPredicate predicate)
        {
            this.decoratedComponent = decoratedComponent;
            this.predicate = predicate;
        }
        
        public void Something()
        {
            if (predicate.Test())
            {
                decoratedComponent.Something();
            }
        }

        private readonly IComponent decoratedComponent;
        private readonly IPredicate predicate;
    }
}
