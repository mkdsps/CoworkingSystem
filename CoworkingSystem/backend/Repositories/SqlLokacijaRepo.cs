using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlLokacijaRepo : ILokacijeRepo
    {
        private readonly DbManager _dbManager;
        public SqlLokacijaRepo()
        {
            _dbManager = DbManager.GetInstance();
        }
        public void Delete(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Lokacije WHERE Id = @id;";
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            cmd.ExecuteNonQuery();
        }

        public List<Lokacija> GetAll()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            // Ako adapter vraća prazan string za LIMIT (npr. MSSQL bez potrebe), ovo će i dalje biti OK
            // ali obično GetAll nema limit. Ostavljam bez limita radi jednostavnosti.
            cmd.CommandText = @"
                SELECT Id, Naziv, Adresa, Grad, RadnoVreme, MaksimalanBrojKorisnika, Opis, Aktivna, DatumKreiranja
                FROM Lokacije
                ORDER BY Id DESC;
                ";

            var list = new List<Lokacija>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(MapLokacija(r));
            }

            return list;
        }

        public List<LokacijaStatistika> GetAllStats(bool? onlyActiveLocations = null)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            string nowFn = _dbManager.Adapter.GetCurrentDateTimeFunction();
            string where = onlyActiveLocations.HasValue ? "WHERE l.Aktivna = @lokAktivna" : "";

            cmd.CommandText = $@"
                SELECT
                    l.Id AS LokacijaId,
                    l.Naziv,
                    l.Grad,

                    COUNT(DISTINCT CASE
                        WHEN r.TipResursa = 'RadnoMesto' AND r.Aktivan = 1
                        THEN r.Id
                    END) AS UkupnoRadnihMesta,

                    COUNT(DISTINCT CASE
                        WHEN r.TipResursa = 'RadnoMesto' AND r.Aktivan = 1
                         AND rez.Status = 'Aktivna'
                         AND rez.DatumVremePocetka <= {nowFn}
                         AND rez.DatumVremeZavrsetka >= {nowFn}
                        THEN rez.ResursId
                    END) AS TrenutnoRezervisano

                FROM Lokacije l
                LEFT JOIN Resursi r ON r.LokacijaId = l.Id
                LEFT JOIN Rezervacije rez ON rez.ResursId = r.Id
                {where}
                GROUP BY l.Id, l.Naziv, l.Grad
                ORDER BY l.Id DESC;
                ";

            if (onlyActiveLocations.HasValue)
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokAktivna", onlyActiveLocations.Value));

            var list = new List<LokacijaStatistika>();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                int ukupno = Convert.ToInt32(r["UkupnoRadnihMesta"]);
                int zauzeto = Convert.ToInt32(r["TrenutnoRezervisano"]);

                double procenat = ukupno == 0 ? 0 : (double)zauzeto / ukupno * 100.0;

                list.Add(new LokacijaStatistika
                {
                    LokacijaId = Convert.ToInt32(r["LokacijaId"]),
                    Naziv = Convert.ToString(r["Naziv"]) ?? "",
                    Grad = Convert.ToString(r["Grad"]) ?? "",
                    UkupnoRadnihMesta = ukupno,
                    TrenutnoRezervisano = zauzeto,
                    ProcenatZauzetosti = Math.Round(procenat, 2)
                });
            }

            return list;
        }

        public List<Lokacija> GetByActive(bool active)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Naziv, Adresa, Grad, RadnoVreme, MaksimalanBrojKorisnika, Opis, Aktivna, DatumKreiranja
                FROM Lokacije
                WHERE Aktivna = @aktivna
                ORDER BY Id DESC;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@aktivna", active));

            var list = new List<Lokacija>();
            using var r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(MapLokacija(r));   // koristi tvoju MapLokacija metodu

            return list;
        }

        public Lokacija? GetById(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Naziv, Adresa, Grad, RadnoVreme, MaksimalanBrojKorisnika, Opis, Aktivna, DatumKreiranja
                FROM Lokacije
                WHERE Id = @id;
                ";
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return MapLokacija(r);
        }

        public int Insert(Lokacija lokacija)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = $@"
                INSERT INTO Lokacije
                    (Naziv, Adresa, Grad, RadnoVreme, MaksimalanBrojKorisnika, Opis, Aktivna, DatumKreiranja)
                VALUES
                    (@naziv, @adresa, @grad, @radnoVreme, @maxBroj, @opis, @aktivna, {_dbManager.Adapter.GetCurrentDateTimeFunction()});
                {_dbManager.Adapter.GetLastInsertIdQuery()};
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@naziv", lokacija.Naziv));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@adresa", lokacija.Adresa));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@grad", lokacija.Grad));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@radnoVreme", lokacija.RadnoVreme));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@maxBroj", lokacija.MaksimalanBrojKorisnika));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@opis", (object?)lokacija.Opis ?? DBNull.Value));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@aktivna", lokacija.Aktivna));

            object result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public void SetActive(int id, bool active)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Lokacije SET Aktivna = @aktivna WHERE Id = @id;";
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@aktivna", active));

            cmd.ExecuteNonQuery();
        }

        public void Update(Lokacija lokacija)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE Lokacije
                SET Naziv = @naziv,
                    Adresa = @adresa,
                    Grad = @grad,
                    RadnoVreme = @radnoVreme,
                    MaksimalanBrojKorisnika = @maxBroj,
                    Opis = @opis,
                    Aktivna = @aktivna
                WHERE Id = @id;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", lokacija.Id));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@naziv", lokacija.Naziv));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@adresa", lokacija.Adresa));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@grad", lokacija.Grad));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@radnoVreme", lokacija.RadnoVreme));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@maxBroj", lokacija.MaksimalanBrojKorisnika));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@opis", (object?)lokacija.Opis ?? DBNull.Value));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@aktivna", lokacija.Aktivna));

            cmd.ExecuteNonQuery();
        }

        private Lokacija MapLokacija(IDataRecord r)
        {
            return new Lokacija
            {
                Id = Convert.ToInt32(r["Id"]),
                Naziv = Convert.ToString(r["Naziv"]) ?? "",
                Adresa = Convert.ToString(r["Adresa"]) ?? "",
                Grad = Convert.ToString(r["Grad"]) ?? "",
                RadnoVreme = Convert.ToString(r["RadnoVreme"]) ?? "",
                MaksimalanBrojKorisnika = Convert.ToInt32(r["MaksimalanBrojKorisnika"]),
                Opis = r["Opis"] == DBNull.Value ? null : Convert.ToString(r["Opis"]),
                Aktivna = _dbManager.Adapter.GetBooleanValue(r["Aktivna"]),
                DatumKreiranja = Convert.ToDateTime(r["DatumKreiranja"])
            };
        }
    }
}
