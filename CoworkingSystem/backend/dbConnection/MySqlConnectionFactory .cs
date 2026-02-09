using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.dbConnection
{
    internal class MySqlConnectionFactory : IDbConnectionFactory
    {
        public readonly string connectionString;
        public MySqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
