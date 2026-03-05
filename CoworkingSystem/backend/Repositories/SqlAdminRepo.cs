using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlAdminRepo : IAdminRepo
    {
        private readonly DbManager _dbManager;

        public SqlAdminRepo()
        {
            _dbManager = DbManager.GetInstance();
        }

        public Administrator? GetActiveByUsername(string username)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                    SELECT Id, KorisnickoIme, LozinkaHash, Email, Ime, Prezime, Aktivan
                    FROM Administratori
                    WHERE KorisnickoIme = @username AND Aktivan = @active
                    ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@username", username.Trim()));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@active", 1));

            using var r = cmd.ExecuteReader();

            if (!r.Read())
                return null;

            return MapAdministrator(r);
        }

        private Administrator MapAdministrator(System.Data.IDataRecord r)
        {
            return new Administrator
            {
                Id = Convert.ToInt32(r["Id"]),
                KorisnickoIme = Convert.ToString(r["KorisnickoIme"]) ?? "",
                LozinkaHash = Convert.ToString(r["LozinkaHash"]) ?? "",
                Email = Convert.ToString(r["Email"]) ?? "",
                Ime = Convert.ToString(r["Ime"]) ?? "",
                Prezime = Convert.ToString(r["Prezime"]) ?? "",
                Aktivan = _dbManager.Adapter.GetBooleanValue(r["Aktivan"])
            };
        }
    }
}
