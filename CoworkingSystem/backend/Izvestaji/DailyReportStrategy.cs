using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Izvestaji
{
    internal class DailyReportStrategy : IReportPeriodStrategy
    {
        public string Naziv => "Dnevni";

        public (DateTime periodOd, DateTime periodDo) IzracunajPeriod(DateTime sada)
        {
            return (sada.AddDays(1), sada);
        }

        public bool TrebaPokrenuti(DateTime? poslednjePokretanje, DateTime sada)
        {
            if (poslednjePokretanje == null)
                return true;

            return poslednjePokretanje.Value.AddDays(1) <= sada;
        }
    }
}