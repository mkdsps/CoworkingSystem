using System;

namespace CoworkingSystem.backend.Modules
{
    internal class TipClanstva
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public int TrajanjeDana { get; set; }
        public int? MaksimalnoSatiMesecno { get; set; }
        public bool DozvolaSale { get; set; }
        public int? SaleSatiMesecno { get; set; }
        public string? Opis { get; set; }
        public bool Aktivan { get; set; }
        public DateTime DatumKreiranja { get; set; }

        public TipClanstva() { }

        public TipClanstva(int id, string naziv, decimal cena, int trajanjeDana,
            int maksimalnoSatiMesecno, bool dozvolaSale, int? saleSatiMesecno,
            string? opis, bool aktivan, DateTime datumKreiranja)
        {
            Id = id;
            Naziv = naziv;
            Cena = cena;
            TrajanjeDana = trajanjeDana;
            MaksimalnoSatiMesecno = maksimalnoSatiMesecno;
            DozvolaSale = dozvolaSale;
            SaleSatiMesecno = saleSatiMesecno;
            Opis = opis;
            Aktivan = aktivan;
            DatumKreiranja = datumKreiranja;
        }

        public override string ToString()
        {
            return $"{Id} | {Naziv} | {Cena}";
        }
    }
}