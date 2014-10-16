using Controllers;
using ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoorMansDependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(local);Initial Catalog=UserDatabase;User ID=user;Password=password";
            var loginService = new LoginService(connectionString);
            var controller = new LoginController(loginService);
        }
    }
}
