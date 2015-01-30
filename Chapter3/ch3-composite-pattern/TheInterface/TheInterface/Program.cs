using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompositePattern;

namespace TheInterface
{
    class Program
    {
        static IComponent component;

        static void Main(string[] args)
        {
            var composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new Leaf());
            composite.AddComponent(new Leaf());

            component = composite;
            composite.Something();
        }

        public void AlternativeComposite()
        {
            var composite = new CompositeComponent();
            composite.AddComponent(new Leaf());
            composite.AddComponent(new SecondTypeOfLeaf());
            composite.AddComponent(new AThirdLeafType());

            component = composite;
            composite.Something();
        }
    }
}
