using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories
{
    public interface IAccountFactory
    {
        AccountBase CreateAccount(AccountType accountType);
    }
}
