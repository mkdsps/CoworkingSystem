using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Modules
{
    public class RezervacijaFilter
    {
        public int? KorisnikId { get; set; }
        public int? ResursId { get; set; }
        public int? LokacijaId { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }

        public DateTime? Dan { get; set; }

        public StatusRezervacije? Status { get; set; }

        public RezervacijaFilter()
        {
        }
    }


}