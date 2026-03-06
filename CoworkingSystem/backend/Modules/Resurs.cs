using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    internal class Resurs
    {
        public int Id { get; set; }

        public int LokacijaId { get; set; }

        public string Oznaka { get; set; } = "";

        public string TipResursa { get; set; } = "";

        public string? Opis { get; set; }

        public bool Aktivan { get; set; }

        public string? PodtipStola { get; set; }

        public int? BrojRadnihMesta { get; set; }

        public int? Kapacitet { get; set; }

        public bool? ImaProjektor { get; set; }

        public bool? ImaTV { get; set; }

        public bool? ImaTablu { get; set; }

        public bool? ImaOnlineOpremu { get; set; }

        public decimal? Povrsina { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public Resurs()
        {
            Aktivan = true;
            DatumKreiranja = DateTime.Now;
        }
    }
}