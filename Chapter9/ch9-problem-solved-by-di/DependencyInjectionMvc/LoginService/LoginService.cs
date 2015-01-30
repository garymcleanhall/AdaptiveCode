using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementations
{
    public class LoginService
    {
        public LoginService()
        {
            connectionString = "Data Source=(local);Initial Catalog=UserDatabase;User ID=user;Password=password";
        }

        public bool CheckCredentials(string username, string password)
        {
            var userAuthenticated = false;
            using(var connection = new SqlConnection(connectionString))
            {
                using(var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "EXEC dbo.check_username_and_password";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    transaction.Commit();
                }
            }
            return userAuthenticated;
        }

        private readonly string connectionString;
    }
}
