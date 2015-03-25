using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public class AccountFactory : IAccountFactory
    {
        public AccountBase CreateAccount(AccountType accountType)
        {
            var objectHandle = Activator.CreateInstance(null, string.Format("{0}Account", accountType.ToString()));
            return (AccountBase)objectHandle.Unwrap();
        }
    }
}
