using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using static CoworkingSystem.backend.Modules.KorisnikFilter;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlKorisnikRepo : IKorisniciRepo
    {
        private readonly DbManager _dbManager;
        public SqlKorisnikRepo() 
        {
            _dbManager = DbManager.GetInstance();
        }


        public int Insert(Korisnik k) // odradi ako hoces da proveris adaptere
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            // SQL upit za INSERT
            cmd.CommandText = $@"
                INSERT INTO Korisnici
                    (Ime, Prezime, Email, Telefon, TipClanstvaId, DatumPocetka, DatumIsteka, Status, LokacijaId, Napomena, DatumRegistracije)
                VALUES
                    (@ime, @prezime, @email, @telefon, @tipClanstvaId, @datumPocetka, @datumIsteka, @status, @lokacijaId, @napomena, {_dbManager.Adapter.GetCurrentDateTimeFunction()});
                {_dbManager.Adapter.GetLastInsertIdQuery()}; 
            ";
            // {_dbManager.Adapter.GetLastInsertIdQuery()} sluzi da se dobije id reda posle dodavanj u bazu, josuvek ga ne koristimo....

            // Kreiranje parametara preko adaptera
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@ime", k.Ime));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@prezime", k.Prezime));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@email", k.Email));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@telefon", k.Telefon));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipClanstvaId", k.TipClanstvaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumPocetka", k.DatumPocetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumIsteka", k.DatumIsteka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", k.Status));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", k.LokacijaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@napomena", k.Napomena));

            // ExecuteScalar vraća ID novog korisnika
            object result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public void Update(Korisnik k)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                UPDATE Korisnici
                SET
                    Ime = @ime,
                    Prezime = @prezime,
                    Email = @email,
                    Telefon = @telefon,
                    TipClanstvaId = @tipClanstvaId,
                    DatumPocetka = @datumPocetka,
                    DatumIsteka = @datumIsteka,
                    Status = @status,
                    LokacijaId = @lokacijaId,
                    Napomena = @napomena
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", k.Id));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@ime", k.Ime));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@prezime", k.Prezime));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@email", k.Email));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@telefon", k.Telefon));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipClanstvaId", k.TipClanstvaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumPocetka", k.DatumPocetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumIsteka", k.DatumIsteka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", k.Status));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", k.LokacijaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@napomena", k.Napomena));

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                DELETE FROM Korisnici
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            cmd.ExecuteNonQuery();
        }

        public List<Korisnik> GetAll()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    Id, Ime, Prezime, Email, Telefon,
                    TipClanstvaId, DatumPocetka, DatumIsteka,
                    Status, LokacijaId, Napomena
                FROM Korisnici;
            ";

            using var r = cmd.ExecuteReader();

            var list = new List<Korisnik>();
            while (r.Read())
            {
                //MessageBox.Show(
                //    $"Id={r["Id"]}, TipClanstvaId={r["TipClanstvaId"]}, LokacijaId={r["LokacijaId"]}"
                //);

                var k = new Korisnik
                {
                    Id = GetInt(r, "Id"),
                    Ime = GetString(r, "Ime"),
                    Prezime = GetString(r, "Prezime"),
                    Email = GetString(r, "Email"),
                    Telefon = GetString(r, "Telefon"),
                    TipClanstvaId = GetInt(r, "TipClanstvaId"),
                    DatumPocetka = GetDateTime(r, "DatumPocetka"),
                    DatumIsteka = GetDateTime(r, "DatumIsteka"),
                    Status = GetString(r, "Status"),
                    LokacijaId = GetInt(r, "LokacijaId"),
                    Napomena = GetString(r, "Napomena")
                };

                list.Add(k);
            }

            return list;
        }

        public List<Korisnik> Get(KorisnikFilter filter)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            var whereParts = new List<string>();

            if (filter.LokacijaId.HasValue)
            {
                whereParts.Add("LokacijaId = @lokacijaId");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", filter.LokacijaId.Value));
            }

            if (filter.TipClanstvaId.HasValue)
            {
                whereParts.Add("TipClanstvaId = @tipClanstvaId");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@tipClanstvaId", filter.TipClanstvaId.Value));
            }

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                whereParts.Add("LOWER(Status) = LOWER(@status)");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", filter.Status));
            }

            string whereSql = "";

            if (whereParts.Count > 0)
            {
                whereSql = "WHERE " + string.Join(" AND ", whereParts);
            }

            cmd.CommandText = $@"
                SELECT
                    Id,
                    Ime,
                    Prezime,
                    Email,
                    Telefon,
                    TipClanstvaId,
                    DatumPocetka,
                    DatumIsteka,
                    Status,
                    LokacijaId,
                    Napomena
                FROM Korisnici
                {whereSql};
            ";

            using var r = cmd.ExecuteReader();

            var list = new List<Korisnik>();

            while (r.Read())
            {
                list.Add(new Korisnik
                {
                    Id = GetInt(r, "Id"),
                    Ime = GetString(r, "Ime"),
                    Prezime = GetString(r, "Prezime"),
                    Email = GetString(r, "Email"),
                    Telefon = GetString(r, "Telefon"),
                    TipClanstvaId = GetInt(r, "TipClanstvaId"),
                    DatumPocetka = GetDateTime(r, "DatumPocetka"),
                    DatumIsteka = GetDateTime(r, "DatumIsteka"),
                    Status = GetString(r, "Status"),
                    LokacijaId = GetInt(r, "LokacijaId"),
                    Napomena = GetString(r, "Napomena")
                });
            }

            return list;
        }


        private static int GetInt(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }

        private static string GetString(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? "" : r.GetString(i);
        }

        private static DateTime GetDateTime(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.MinValue : r.GetDateTime(i);
        }

        public Korisnik GetByID(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    Id, Ime, Prezime, Email, Telefon,
                    TipClanstvaId, DatumPocetka, DatumIsteka,
                    Status, LokacijaId, Napomena
                FROM Korisnici
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            using var r = cmd.ExecuteReader();

            if (!r.Read())
                return null;

            var k = new Korisnik
            {
                Id = GetInt(r, "Id"),
                Ime = GetString(r, "Ime"),
                Prezime = GetString(r, "Prezime"),
                Email = GetString(r, "Email"),
                Telefon = GetString(r, "Telefon"),
                TipClanstvaId = GetInt(r, "TipClanstvaId"),
                DatumPocetka = GetDateTime(r, "DatumPocetka"),
                DatumIsteka = GetDateTime(r, "DatumIsteka"),
                Status = GetString(r, "Status"),
                LokacijaId = GetInt(r, "LokacijaId"),
                Napomena = GetString(r, "Napomena")
            };

            return k;
        }
    }
}
