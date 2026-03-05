using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    internal class Lokacija
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Grad { get; set; }

        public string RadnoVreme { get; set; }

        public int MaksimalanBrojKorisnika { get; set; }

        public string? Opis { get; set; }

        public bool Aktivna { get; set; } = true;

        public DateTime DatumKreiranja { get; set; } = DateTime.Now;

        public Lokacija() { }

    }
}
