using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class SqlTipClanstvaRepo : ITipClanstvaRepo
    {
        private readonly DbManager _dbManager;

        public SqlTipClanstvaRepo()
        {
            _dbManager = DbManager.GetInstance();
        }

        public int Insert(TipClanstva tp)
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = $@"
                INSERT INTO TipoviClanstva
                    (Naziv, Cena, TrajanjeDana, MaksimalnoSatiMesecno, DozvolaSale, SaleSatiMesecno, Opis, Aktivan, DatumKreiranja)
                VALUES
                    (@naziv, @cena, @trajanjeDana, @maksimalnoSatiMesecno, @dozvolaSale, @saleSatiMesecno, @opis, @aktivan, {_dbManager.Adapter.GetCurrentDateTimeFunction()});
                {_dbManager.Adapter.GetLastInsertIdQuery()};
            ";

            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@naziv", tp.Naziv));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@cena", tp.Cena));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@trajanjeDana", tp.TrajanjeDana));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@maksimalnoSatiMesecno", tp.MaksimalnoSatiMesecno));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@dozvolaSale", tp.DozvolaSale));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@saleSatiMesecno", tp.SaleSatiMesecno));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@opis", tp.Opis));
            cmd.Parameters.Add(_dbManager.Adapter.CreateParameter("@aktivan", tp.Aktivan));

            object result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        public List<TipClanstva> GetAll()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT
                    Id,
                    Naziv,
                    Cena,
                    TrajanjeDana,
                    MaksimalnoSatiMesecno,
                    DozvolaSale,
                    SaleSatiMesecno,
                    Opis,
                    Aktivan,
                    DatumKreiranja
                FROM TipoviClanstva;
            ";

            using var r = cmd.ExecuteReader();

            var list = new List<TipClanstva>();

            while (r.Read())
            {
                var tp = new TipClanstva
                {
                    Id = GetInt(r, "Id"),
                    Naziv = GetString(r, "Naziv"),
                    Cena = GetDecimal(r, "Cena"),
                    TrajanjeDana = GetInt(r, "TrajanjeDana"),
                    MaksimalnoSatiMesecno = GetInt(r, "MaksimalnoSatiMesecno"),
                    DozvolaSale = GetBool(r, "DozvolaSale"),
                    SaleSatiMesecno = GetNullableInt(r, "SaleSatiMesecno"),
                    Opis = GetNullableString(r, "Opis"),
                    Aktivan = GetBool(r, "Aktivan"),
                    DatumKreiranja = GetDateTime(r, "DatumKreiranja")
                };

                list.Add(tp);
            }

            return list;
        }

        public List<string> DistinctNames()
        {
            using var conn = _dbManager.Connection;
            conn.Open();

            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
                SELECT DISTINCT Naziv
                FROM TipoviClanstva
                ORDER BY Naziv;
            ";

            using var r = cmd.ExecuteReader();

            var list = new List<string>();

            while (r.Read())
            {
                list.Add(GetString(r, "Naziv"));
            }

            return list;
        }

        private static int GetInt(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetInt32(i);
        }

        private static int? GetNullableInt(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? null : r.GetInt32(i);
        }

        private static string GetString(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? "" : r.GetString(i);
        }

        private static string? GetNullableString(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? null : r.GetString(i);
        }

        private static decimal GetDecimal(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? 0 : r.GetDecimal(i);
        }

        private static bool GetBool(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);

            if (r.IsDBNull(i))
                return false;

            object value = r.GetValue(i);

            if (value is bool b)
                return b;

            if (value is int n)
                return n == 1;

            return Convert.ToBoolean(value);
        }

        private static DateTime GetDateTime(DbDataReader r, string col)
        {
            int i = r.GetOrdinal(col);
            return r.IsDBNull(i) ? DateTime.MinValue : r.GetDateTime(i);
        }
    }
}