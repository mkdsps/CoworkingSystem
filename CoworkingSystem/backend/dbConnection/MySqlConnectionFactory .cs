using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.dbConnection
{
    internal class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        public MySqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
