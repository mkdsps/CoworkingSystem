using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlKorisnikRepo : IKorisniciRepo
    {
        private readonly DbManager _dbManager;
        public SqlKorisnikRepo() 
        {
            _dbManager = DbManager.GetInstance();
        }

        public void InsertUser(Korisnik k) // odradi ako hoces da proveris adaptere
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
            //return Convert.ToInt32(result);
        }
    }
}
