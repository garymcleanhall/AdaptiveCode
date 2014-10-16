using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtypeCovariance
{
    public class UserRepository : EntityRepository
    {
        public override User GetByID(Guid id)
        {
            return new User();
        }
    }
}
