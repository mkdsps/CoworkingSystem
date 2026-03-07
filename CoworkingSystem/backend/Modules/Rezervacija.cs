using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    internal class Rezervacija
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }

        public int ResursId { get; set; }


        public DateTime DatumVremePocetka { get; set; }

        public DateTime DatumVremeZavrsetka { get; set; }

        public StatusRezervacije Status { get; set; }

        public int? BrojUcesnika { get; set; }

        public string Napomena { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public DateTime? DatumIzmene { get; set; }
    }

    public enum StatusRezervacije
    {
        Aktivna,
        Zavrsena,
        Otkazana
    }

}
