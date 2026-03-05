using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    public class KorisnikFilter
    {
        public int? LokacijaId { get; set; }
        public int? TipClanstvaId { get; set; }
        public string? Status { get; set; } // "aktivan" | "pauziran" | "istekao" }

    }
}