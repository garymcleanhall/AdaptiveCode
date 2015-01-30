using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using ServiceInterfaces;
using RepositoryInterfaces;

namespace Services
{
    public class AccountService : IAccountService
    {
        public AccountService(IAccountRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository", "A valid account repository must be supplied.");

            this.repository = repository;
        }

        public void AddTransactionToAccount(string uniqueAccountName, decimal transactionAmount)
        {
            var account = repository.GetByName(uniqueAccountName);
            if (account != null)
            {
                try
                {
                    account.AddTransaction(transactionAmount);
                }
                catch(DomainException domainException)
                {
                    throw new ServiceException("An exception was thrown by a domain object", domainException);
                }
            }
        }

        private readonly IAccountRepository repository;
    }
}
