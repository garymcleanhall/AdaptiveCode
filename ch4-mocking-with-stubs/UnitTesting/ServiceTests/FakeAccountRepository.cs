using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using RepositoryInterfaces;

namespace ServiceTests
{
    public class FakeAccountRepository : IAccountRepository
    {
        public FakeAccountRepository(Account account)
        {
            this.account = account;
        }

        public Account GetByName(string accountName)
        {
            return account;
        }

        private Account account;
    }
}
