using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    public class User : IUser
    {
        public User(Guid id, string name)
        {
            ID = id;
            Name = name;
            sessionExpiry = DateTime.Now;
            IncrementSessionTicket();
        }

        public Guid ID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public void IncrementSessionTicket()
        {
            sessionExpiry.AddMinutes(30);
        }

        public bool IsNull
        {
            get
            {
                return false;
            }
        }

        private DateTime sessionExpiry;
    }
}
