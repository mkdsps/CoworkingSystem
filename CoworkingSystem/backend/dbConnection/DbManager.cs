using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoworkingSystem.backend.dbConnection
{
    public sealed class DbManager
    {
        private static DbManager? _instance;
        private static readonly object _lock = new object();

        private readonly IDbConnectionFactory _connectionFactory;
        public readonly string BrandName;


        private DbManager()
        {
            Config config = Config.getInstance();
            BrandName = config.name;

            _connectionFactory = CreateFactory(config.type, config.connectionString);
        }


        public static DbManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new DbManager(); // dodeljuje novu vrednost ako je jednako null (??=)
                }
            }
            return _instance;
        }

        private IDbConnectionFactory CreateFactory(DbType type, string connectionString)
        {
            if (DbType.mysql == type)
                return new MsSqlConnectionFactory(connectionString);

            else if (DbType.mssql == type)
                return new MySqlConnectionFactory(connectionString);

            throw new ArgumentException($"Nepodrzan tip baze: {type}");
        }
    }
}
