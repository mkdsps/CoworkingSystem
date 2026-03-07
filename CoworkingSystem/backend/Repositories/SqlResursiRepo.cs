using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlResursiRepo : IResursiRepo
    {
        private readonly DbManager _dbManager;

        public SqlResursiRepo()
        {
            _dbManager = DbManager.GetInstance();
        }

        public int Insert(Resurs resurs)
        {
            throw new NotImplementedException();
        }

        public void Update(Resurs resurs)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Resurs> GetAll()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                ORDER BY Id DESC;
                ";

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;
        }

        public Resurs? GetById(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE Id = @id;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            using var r = cmd.ExecuteReader();

            if (r.Read())
            {
                return MapResurs(r);
            }

            return null;
        }

        public List<Resurs> GetByLokacija(int lokacijaId)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE LokacijaId = @lokacijaId
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(
                _dbManager.Adapter.CreateParameter("@lokacijaId", lokacijaId)
            );

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;
        }

        public List<Resurs> GetAllRadnaMesta()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE TipResursa = @tipResursa
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipResursa", "RadnoMesto"));

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;
        }

        public List<Resurs> GetRadnaMestaByLokacija(int lokacijaId)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE LokacijaId = @lokacijaId
                  AND TipResursa = @tipResursa
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", lokacijaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipResursa", "RadnoMesto"));

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;
        }

        public List<Resurs> GetAllSale()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE TipResursa = @tipResursa
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipResursa", "Sala"));

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;

        }

        public List<Resurs> GetSaleByLokacija(int lokacijaId)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM Resursi
                WHERE LokacijaId = @lokacijaId
                  AND TipResursa = @tipResursa
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", lokacijaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipResursa", "Sala"));

            var list = new List<Resurs>();

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapResurs(r));
            }

            return list;
        }

        public void SetActive(int id, bool active)
        {
            throw new NotImplementedException();
        }

        private Resurs MapResurs(DbDataReader reader)
        {
            Resurs r = new Resurs();

            r.Id = Convert.ToInt32(reader["Id"]);
            r.LokacijaId = Convert.ToInt32(reader["LokacijaId"]);
            r.Oznaka = reader["Oznaka"].ToString() ?? "";
            r.TipResursa = reader["TipResursa"].ToString() ?? "";
            r.Opis = reader["Opis"] as string;
            r.Aktivan = Convert.ToBoolean(reader["Aktivan"]);

            r.PodtipStola = reader["PodtipStola"] as string;

            r.BrojRadnihMesta = reader["BrojRadnihMesta"] != DBNull.Value
                ? Convert.ToInt32(reader["BrojRadnihMesta"])
                : null;

            r.Kapacitet = reader["Kapacitet"] != DBNull.Value
                ? Convert.ToInt32(reader["Kapacitet"])
                : null;

            r.ImaProjektor = reader["ImaProjektor"] != DBNull.Value
                ? Convert.ToBoolean(reader["ImaProjektor"])
                : null;

            r.ImaTV = reader["ImaTV"] != DBNull.Value
                ? Convert.ToBoolean(reader["ImaTV"])
                : null;

            r.ImaTablu = reader["ImaTablu"] != DBNull.Value
                ? Convert.ToBoolean(reader["ImaTablu"])
                : null;

            r.ImaOnlineOpremu = reader["ImaOnlineOpremu"] != DBNull.Value
                ? Convert.ToBoolean(reader["ImaOnlineOpremu"])
                : null;

            r.Povrsina = reader["Povrsina"] != DBNull.Value
                ? Convert.ToDecimal(reader["Povrsina"])
                : null;

            r.DatumKreiranja = Convert.ToDateTime(reader["DatumKreiranja"]);

            return r;
        }
    }
}