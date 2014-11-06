using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;

using Sermo.Contracts;

namespace Sermo.AdoNet
{
    public class AdoNetRoomRepository : IRoomRepository
    {
        public AdoNetRoomRepository(IApplicationSettings applicationSettings, DbProviderFactory databaseFactory)
        {
            Contract.Requires<ArgumentNullException>(applicationSettings != null);
            Contract.Requires<ArgumentNullException>(databaseFactory != null);

            this.applicationSettings = applicationSettings;
            this.databaseFactory = databaseFactory; 
        }

        public void CreateRoom(string name)
        {
            using(var connection = databaseFactory.CreateConnection())
            {
                connection.ConnectionString = applicationSettings.GetValue("SermoConnectionString");
                connection.Open();

                using(var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "dbo.create_room";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Transaction = transaction;
                    var parameter = command.CreateParameter();
                    parameter.DbType = DbType.String;
                    parameter.ParameterName = "name";
                    parameter.Value = name;
                    command.Parameters.Add(parameter);

                    command.ExecuteNonQuery();
                }
            }
        }

        private readonly IApplicationSettings applicationSettings;
        private readonly DbProviderFactory databaseFactory;
    }
}
