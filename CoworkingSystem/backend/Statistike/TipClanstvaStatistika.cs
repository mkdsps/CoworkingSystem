using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Statistike
{
    public class TipClanstvaStatistika
    {
        public int TipClanstvaId { get; set; }
        public string NazivTipaClanstva { get; set; }

        public decimal Cena { get; set; }
        public int TrajanjeDana { get; set; }
        public int? MaksimalnoSatiMesecno { get; set; }
        public bool DozvolaSale { get; set; }
        public int? SaleSatiMesecno { get; set; }

        public int BrojAktivnihKorisnika { get; set; }
        public int BrojSvihKorisnika { get; set; }

        public int UkupanBrojRezervacija { get; set; }
        public double UkupnoSatiKoriscenja { get; set; }
        public double ProsecnoSatiPoKorisniku { get; set; }

        public int BrojRezervacijaSala { get; set; }
        public double UkupnoSatiSala { get; set; }

        public int BrojRezervacijaRadnihMesta { get; set; }
        public double UkupnoSatiRadnihMesta { get; set; }
    }
}
