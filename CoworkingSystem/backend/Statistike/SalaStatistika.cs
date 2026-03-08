using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Statistike
{
    public class SalaStatistika
    {
        public int ResursId { get; set; }
        public string Oznaka { get; set; }
        public int LokacijaId { get; set; }
        public string NazivLokacije { get; set; }

        public int Kapacitet { get; set; }

        public int UkupanBrojRezervacija { get; set; }
        public double UkupnoSatiKoriscenja { get; set; }
        public double ProsecnoTrajanjeRezervacijeSati { get; set; }
        public double ProcenatZauzetosti { get; set; }

        public int UkupanBrojUcesnika { get; set; }
        public double ProsecanBrojUcesnika { get; set; }
        public int BrojRazlicitihKorisnika { get; set; }
    }
}
