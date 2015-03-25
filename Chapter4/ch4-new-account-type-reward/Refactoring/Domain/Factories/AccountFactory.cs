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
            AccountBase account = null;
            switch (accountType)
            {
                case AccountType.Bronze:
                    account = new BronzeAccount();
                    break;
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            }
            return account;
        }
    }
}
