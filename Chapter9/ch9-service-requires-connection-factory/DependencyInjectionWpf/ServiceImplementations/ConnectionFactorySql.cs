using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using ServiceInterfaces;

namespace ServiceImplementations
{
    public class ConnectionFactorySql : IConnectionFactory
    {
        public ConnectionFactorySql(ISettings settings)
        {
            this.settings = settings;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(settings.GetSetting("TaskDatabaseConnectionString"));
        }

        private readonly ISettings settings;
    }
}
