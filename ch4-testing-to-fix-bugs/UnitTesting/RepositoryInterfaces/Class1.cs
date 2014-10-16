using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace RepositoryInterfaces
{
    public interface IAccountRepository
    {
        Account GetByName(string accountName);
    }
}
