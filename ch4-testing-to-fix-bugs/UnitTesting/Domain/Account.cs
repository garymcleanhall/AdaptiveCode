using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Account
    {
        public virtual void AddTransaction(decimal amount)
        {
            Balance += amount;
        }

        public decimal Balance
        {
            get;
            private set;
        }
    }
}
