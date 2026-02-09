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
                    _instance ??= new DbManager(); // dodeljuje novu vrednost ako je jednako null (??=)
                }
            }
            return _instance;
        }

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
