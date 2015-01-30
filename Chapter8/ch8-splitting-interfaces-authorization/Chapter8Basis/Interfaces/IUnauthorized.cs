using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnauthorized
    {
        IAuthorized Login(string username, string password);

        void RequestPasswordReminder(string emailAddress);
    }
}
