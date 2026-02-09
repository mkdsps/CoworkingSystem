using System;
using System.Data.Common;

namespace CoworkingSystem.backend.dbConnection
{
    public sealed class DbManager
    {
        private static DbManager? _instance;
        private static readonly object _lock = new object();

        private IDbConnectionFactory _connectionFactory;
        private IDatabaseAdapter _adapter;

        public readonly string BrandName;

        private DbManager()
        {
            Config config = Config.getInstance();
            BrandName = config.name;

            IzaberiTip(config.type, config.connectionString);
        }

        public static DbManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new DbManager();
                }
            }
            return _instance;
        }

        internal DbConnection Connection => _connectionFactory.CreateConnection();
        internal IDatabaseAdapter Adapter => _adapter;

        private void IzaberiTip(DbType type, string connectionString)
        {
            if (DbType.mssql == type)
            {
                _connectionFactory = new MsSqlConnectionFactory(connectionString);
                _adapter = new MsSqlAdapter();
            }
            else if (DbType.mysql == type)
            {
                _connectionFactory = new MySqlConnectionFactory(connectionString);
                _adapter = new MySqlAdapter();
            }
            else
            {
                throw new ArgumentException($"Nepodrzan tip baze: {type}");
            }
        }
    }
}
