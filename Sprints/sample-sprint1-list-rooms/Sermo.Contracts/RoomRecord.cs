using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.Data.Contracts
{
    public class RoomRecord
    {
        public RoomRecord(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
