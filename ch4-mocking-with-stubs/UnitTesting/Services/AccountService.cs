using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceInterfaces;
using RepositoryInterfaces;

namespace Services
{
    public class AccountService : IAccountService
    {
        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = repository.GetByName(uniqueAccountName);
            account.AddTransaction(transactionAmount);
        }

        private readonly IAccountRepository repository;
    }
}
