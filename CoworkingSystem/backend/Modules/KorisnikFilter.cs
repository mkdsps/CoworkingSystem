using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    public class KorisnikFilter
    {
        public int? TipClanstvaId { get; set; }
        public string? Status { get; set; } // "aktivan" | "pauziran" | "istekao" }

    }
}