using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using Domain.Repositories;

namespace Services
{
    public class AccountService
    {
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void CreateAccount(AccountType accountType)
        {
            var newAccount = AccountBase.CreateAccount(accountType);
            accountRepository.NewAccount(newAccount);
        }

        private readonly IAccountRepository accountRepository;
    }
}
