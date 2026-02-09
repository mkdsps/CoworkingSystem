using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.dbConnection
{
    internal class MsSqlConnectionFactory : IDbConnectionFactory
    {
        public readonly string connectionString;

        public MsSqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
