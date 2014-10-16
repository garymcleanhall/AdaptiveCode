using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class CompositeComponent : IComponent
    {
        public CompositeComponent()
        {
            children = new List<IComponent>();
        }

        public void AddComponent(IComponent component)
        {
            children.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            children.Remove(component);
        }

        public void Something()
        {
            foreach(var child in children)
            {
                child.Something();
            }
        }

        private ICollection<IComponent> children;
    }
}
