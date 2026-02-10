using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoworkingSystem.backend
{
    public enum DbType
    {
        mysql, mssql
    }

    internal sealed class Config
    {
        // thread safe jer je inicijalizacija u statiku thread safe
        private static readonly Config _instance = new Config();

        public string name { get; }
        public DbType type { get; }
        public string connectionString { get; }

        private Config() {

            string path = Path.Combine(AppContext.BaseDirectory, "config.txt");

            if (!File.Exists(path))
                throw new FileNotFoundException("config.txt nije pronađen", path);

            var lines = File.ReadAllLines(path);

            if (lines.Length < 2)
                throw new Exception("config.txt mora imati najmanje dve linije.");



            name = lines[0].Trim();
            connectionString = lines[1].Trim();
            type = DetectDbType(connectionString);
        }

        static public Config getInstance()
        {
            return Config._instance;
            // aasasdfsafdaf
        }


        private static DbType DetectDbType(string cs)
        {
            var s = cs.ToLowerInvariant();

            // MSSQL indikatori
            if (s.Contains("trustservercertificate") || s.Contains("trusted_connection") || s.Contains("initial catalog"))
                return DbType.mssql;

            // gruba ali korisna heuristika
            if (s.Contains("uid=") || s.Contains("user id=") || s.Contains("port="))
                return DbType.mysql;


            // fallback
            return DbType.mysql;
        }
    }
}

