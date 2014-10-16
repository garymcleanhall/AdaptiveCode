using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using Domain.Repositories;
using Domain.Factories;

namespace Services
{
    public class AccountService
    {
        public AccountService(IAccountFactory accountFactory, IAccountRepository accountRepository)
        {
            this.accountFactory = accountFactory;
            this.accountRepository = accountRepository;
        }

        public void CreateAccount(AccountType accountType)
        {
            var newAccount = accountFactory.CreateAccount(accountType);
            accountRepository.NewAccount(newAccount);
        }

        private readonly IAccountRepository accountRepository;
        private readonly IAccountFactory accountFactory;
    }
}
