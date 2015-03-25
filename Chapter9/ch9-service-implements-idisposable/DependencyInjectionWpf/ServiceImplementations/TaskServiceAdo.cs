using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using ServiceInterfaces;

namespace ServiceImplementations
{
    public class TaskServiceAdo : ITaskService, IDisposable
    {
        public TaskServiceAdo(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            var allTasks = new List<TaskDto>();

            connection.Open();

            try
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[get_all_tasks]";

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            allTasks.Add(
                                new TaskDto
                                {
                                    ID = reader.GetInt32(IDIndex),
                                    Description = reader.GetString(DescriptionIndex),
                                    Priority = reader.GetString(PriorityIndex),
                                    DueDate = reader.GetDateTime(DueDateIndex),
                                    Completed = reader.GetBoolean(CompletedIndex)
                                }
                            );
                        }
                    }
                }
            }
            finally 
            {
                connection.Close();
            }

            return allTasks;
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        private readonly IDbConnection connection;

        private const int IDIndex = 0;
        private const int DescriptionIndex = 1;
        private const int PriorityIndex = 2;
        private const int DueDateIndex = 3;
        private const int CompletedIndex = 4;
    }
}
