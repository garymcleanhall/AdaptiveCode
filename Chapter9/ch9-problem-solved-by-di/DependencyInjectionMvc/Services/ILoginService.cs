using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILoginService
    {
        bool CheckCredentials(string username, string password);
    }
}
