using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Statistike
{
    public  class RadnoMestoStatistika
    {
        public int ResursId { get; set; }
        public string Oznaka { get; set; }
        public int LokacijaId { get; set; }
        public string NazivLokacije { get; set; }
        public string PodtipStola { get; set; }   // FleksibilniSto / FiksniSto

        public int UkupanBrojRezervacija { get; set; }
        public double UkupnoSatiKoriscenja { get; set; }
        public double ProsecnoTrajanjeRezervacijeSati { get; set; }
        public double ProcenatZauzetosti { get; set; }

        public int BrojRazlicitihKorisnika { get; set; }
    }
}
