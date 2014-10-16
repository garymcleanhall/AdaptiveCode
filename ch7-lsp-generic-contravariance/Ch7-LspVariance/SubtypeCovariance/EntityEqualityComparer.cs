using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtypeCovariance
{
    public class EntityEqualityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity left, Entity right)
        {
            return left.ID == right.ID;
        }

        public int GetHashCode(Entity obj)
        {
            return obj.GetHashCode();
        }
    }
}
