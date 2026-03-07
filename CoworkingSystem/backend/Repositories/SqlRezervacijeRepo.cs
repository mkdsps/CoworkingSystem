using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlRezervacijeRepo : IRezervacijeRepo
    {
        private readonly DbManager _dbManager;

        public SqlRezervacijeRepo()
        {
            _dbManager = DbManager.GetInstance();
        }

        public int Insert(Rezervacija r)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = $@"
                    INSERT INTO Rezervacije
                        (KorisnikId, ResursId, DatumVremePocetka, DatumVremeZavrsetka, Status, BrojUcesnika, Napomena, DatumKreiranja, DatumIzmene)
                    VALUES
                        (@korisnikId, @resursId, @pocetak, @kraj, @status, @brojUcesnika, @napomena, {_dbManager.Adapter.GetCurrentDateTimeFunction()}, @datumIzmene);
                    {_dbManager.Adapter.GetLastInsertIdQuery()};
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@korisnikId", r.KorisnikId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@resursId", r.ResursId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@pocetak", r.DatumVremePocetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@kraj", r.DatumVremeZavrsetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", r.Status.ToString()));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@brojUcesnika", (object?)r.BrojUcesnika ?? DBNull.Value));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@napomena", (object?)r.Napomena ?? DBNull.Value));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumIzmene", (object?)r.DatumIzmene ?? DBNull.Value));

            object result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public void Update(Rezervacija r)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = $@"
                    UPDATE Rezervacije
                    SET KorisnikId = @korisnikId,
                        ResursId = @resursId,
                        DatumVremePocetka = @pocetak,
                        DatumVremeZavrsetka = @kraj,
                        Status = @status,
                        BrojUcesnika = @brojUcesnika,
                        Napomena = @napomena,
                        DatumIzmene = {_dbManager.Adapter.GetCurrentDateTimeFunction()}
                    WHERE Id = @id;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", r.Id));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@korisnikId", r.KorisnikId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@resursId", r.ResursId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@pocetak", r.DatumVremePocetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@kraj", r.DatumVremeZavrsetka));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", r.Status.ToString()));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@brojUcesnika", (object?)r.BrojUcesnika ?? DBNull.Value));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@napomena", (object?)r.Napomena ?? DBNull.Value));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Rezervacije WHERE Id = @id;";
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            cmd.ExecuteNonQuery();
        }

        public List<Rezervacija> GetAll()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                    SELECT Id, KorisnikId, ResursId, DatumVremePocetka, DatumVremeZavrsetka,
                           Status, BrojUcesnika, Napomena, DatumKreiranja, DatumIzmene
                    FROM Rezervacije
                    ORDER BY Id DESC;
                ";

            var list = new List<Rezervacija>();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(MapRezervacija(reader));
            }

            return list;
        }

        public List<Rezervacija> Get(RezervacijaFilter filter)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            var conditions = new List<string>();

            cmd.CommandText = @"
                    SELECT rez.Id, rez.KorisnikId, rez.ResursId, rez.DatumVremePocetka, rez.DatumVremeZavrsetka,
                           rez.Status, rez.BrojUcesnika, rez.Napomena, rez.DatumKreiranja, rez.DatumIzmene
                    FROM Rezervacije rez
                    INNER JOIN Resursi res ON rez.ResursId = res.Id
                ";

            if (filter.KorisnikId.HasValue)
            {
                conditions.Add("rez.KorisnikId = @korisnikId");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@korisnikId", filter.KorisnikId.Value));
            }

            if (filter.ResursId.HasValue)
            {
                conditions.Add("rez.ResursId = @resursId");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@resursId", filter.ResursId.Value));
            }

            if (filter.LokacijaId.HasValue)
            {
                conditions.Add("res.LokacijaId = @lokacijaId");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@lokacijaId", filter.LokacijaId.Value));
            }

            if (filter.DatumOd.HasValue)
            {
                conditions.Add("rez.DatumVremePocetka >= @datumOd");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumOd", filter.DatumOd.Value));
            }

            if (filter.DatumDo.HasValue)
            {
                conditions.Add("rez.DatumVremeZavrsetka <= @datumDo");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@datumDo", filter.DatumDo.Value));
            }

            if (filter.Dan.HasValue)
            {
                DateTime pocetakDana = filter.Dan.Value.Date;
                DateTime krajDana = pocetakDana.AddDays(1);

                conditions.Add("rez.DatumVremePocetka < @krajDana AND rez.DatumVremeZavrsetka > @pocetakDana");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@pocetakDana", pocetakDana));
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@krajDana", krajDana));
            }

            if (filter.Status.HasValue)
            {
                conditions.Add("rez.Status = @status");
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@status", filter.Status.Value.ToString()));
            }

            if (conditions.Count > 0)
            {
                cmd.CommandText += " WHERE " + string.Join(" AND ", conditions);
            }

            cmd.CommandText += " ORDER BY rez.DatumVremePocetka ASC;";

            var list = new List<Rezervacija>();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(MapRezervacija(reader));
            }

            return list;
        }

        public Rezervacija GetByID(int id)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, KorisnikId, ResursId, DatumVremePocetka, DatumVremeZavrsetka,
                       Status, BrojUcesnika, Napomena, DatumKreiranja, DatumIzmene
                FROM Rezervacije
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return MapRezervacija(reader);
        }

        private Rezervacija MapRezervacija(IDataRecord r)
        {
            return new Rezervacija
            {
                Id = Convert.ToInt32(r["Id"]),
                KorisnikId = Convert.ToInt32(r["KorisnikId"]),
                ResursId = Convert.ToInt32(r["ResursId"]),
                DatumVremePocetka = Convert.ToDateTime(r["DatumVremePocetka"]),
                DatumVremeZavrsetka = Convert.ToDateTime(r["DatumVremeZavrsetka"]),
                Status = Enum.Parse<StatusRezervacije>(Convert.ToString(r["Status"])),
                BrojUcesnika = r["BrojUcesnika"] == DBNull.Value ? null : Convert.ToInt32(r["BrojUcesnika"]),
                Napomena = r["Napomena"] == DBNull.Value ? null : Convert.ToString(r["Napomena"]),
                DatumKreiranja = Convert.ToDateTime(r["DatumKreiranja"]),
                DatumIzmene = r["DatumIzmene"] == DBNull.Value ? null : Convert.ToDateTime(r["DatumIzmene"])
            };
        }

        public bool IsResursDostupan(int resursId, DateTime pocetak, DateTime kraj)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                    SELECT 1
                    FROM Rezervacije
                    WHERE ResursId = @IdResursa
                      AND Status <> 'Otkazana'
                      AND DatumVremePocetka < @NoviKraj
                      AND DatumVremeZavrsetka > @NoviPocetak;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@IdResursa", resursId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@NoviPocetak", pocetak));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@NoviKraj", kraj));

            object result = cmd.ExecuteScalar();

            return result == null;
        }

        public bool DaLiKorisnikMozeRezervisati(int korisnikId, DateTime pocetak, DateTime kraj)
        {
            if (korisnikId <= 0)
                return false;

            if (pocetak >= kraj)
                return false;

            using var conn = _dbManager.Connection;
            conn.Open();

            double ukupnoSatiUTomMesecu = 0;

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"
            SELECT COALESCE(SUM({_dbManager.Adapter.GetTimeDifferenceInHours("DatumVremePocetka", "DatumVremeZavrsetka")}), 0)
            FROM Rezervacije
            WHERE KorisnikId = @IDKorisnika
              AND Status <> 'Otkazana'
              AND YEAR(DatumVremePocetka) = YEAR(@Datum)
              AND MONTH(DatumVremePocetka) = MONTH(@Datum);
        ";

                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@IDKorisnika", korisnikId));
                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@Datum", pocetak));

                object result = cmd.ExecuteScalar();

                ukupnoSatiUTomMesecu = (result == null || result == DBNull.Value)
                    ? 0
                    : Convert.ToDouble(result);
            }

            double satiNoveRezervacije = (kraj - pocetak).TotalHours;

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT tc.MaksimalnoSatiMesecno
            FROM Korisnici k
            INNER JOIN TipoviClanstva tc ON k.TipClanstvaId = tc.Id
            WHERE k.Id = @IDKorisnika;
        ";

                cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@IDKorisnika", korisnikId));

                object result = cmd.ExecuteScalar();

                if (result == null)
                    return false;

                if (result == DBNull.Value)
                    return true; // ovo ostavi samo ako NULL znači "neograničeno"

                double maksimalnoSatiMesecno = Convert.ToDouble(result);

                return (ukupnoSatiUTomMesecu + satiNoveRezervacije) <= maksimalnoSatiMesecno;
            }
        }


        public bool DaLiJeURadnomVremenuLokacije(int lokacijaId, DateTime pocetak, DateTime kraj)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            string vremePocetka = _dbManager.Adapter.GetTimePartExpression("@DatumVremePocetka");
            string vremeZavrsetka = _dbManager.Adapter.GetTimePartExpression("@DatumVremeZavrsetka");
            string radnoVremePocetak = _dbManager.Adapter.GetRadnoVremeStartExpression("l.RadnoVreme");
            string radnoVremeKraj = _dbManager.Adapter.GetRadnoVremeEndExpression("l.RadnoVreme");

            cmd.CommandText = $@"
        SELECT 1
        FROM Lokacije l
        WHERE l.Id = @LokacijaId
          AND {vremePocetka} >= {radnoVremePocetak}
          AND {vremeZavrsetka} <= {radnoVremeKraj};
    ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@LokacijaId", lokacijaId));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@DatumVremePocetka", pocetak));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@DatumVremeZavrsetka", kraj));

            return cmd.ExecuteScalar() != null;
        }

        public int GetLokacijaIdByResursId(int resursId)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();
                        cmd.CommandText = @"
                    SELECT LokacijaId
                    FROM Resursi
                    WHERE Id = @resursId;
                ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@resursId", resursId));

            object result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
                throw new Exception("Resurs ne postoji ili nema lokaciju.");

            return Convert.ToInt32(result);
        }
    }
}
