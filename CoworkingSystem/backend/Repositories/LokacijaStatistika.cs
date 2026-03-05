using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class LokacijaStatistika
    {
        public int LokacijaId { get; set; }
        public string Naziv { get; set; } = "";
        public string Grad { get; set; } = "";

        public int UkupnoRadnihMesta { get; set; }
        public int TrenutnoRezervisano { get; set; }
        public double ProcenatZauzetosti { get; set; }
    }
}
