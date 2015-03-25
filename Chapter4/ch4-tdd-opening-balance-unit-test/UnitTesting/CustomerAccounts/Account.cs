using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAccounts
{
    public class Account
    {
        public Account()
        {
            Balance = 200m;
        }

        public void AddTransaction(decimal amount)
        {
            
        }

        public decimal Balance
        {
            get;
            private set;
        }
    }
}
