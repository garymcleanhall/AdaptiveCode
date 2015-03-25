using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    public class NullUser : IUser
    {
        public void IncrementSessionTicket()
        {
            // do nothing
        }

        public string Name
        {
            get
            {
                return "unknown";
            }
        }
    }
}
