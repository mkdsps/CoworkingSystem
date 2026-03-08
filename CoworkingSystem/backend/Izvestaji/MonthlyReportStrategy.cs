using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Izvestaji
{
    internal class MonthlyReportStrategy : IReportPeriodStrategy
    {
        public string Naziv => "Mesecni";

        public (DateTime periodOd, DateTime periodDo) IzracunajPeriod(DateTime sada)
        {
            return (sada.AddMonths(-1), sada);
        }

        public bool TrebaPokrenuti(DateTime? poslednjePokretanje, DateTime sada)
        {
            if (poslednjePokretanje == null)
                return true;

            return poslednjePokretanje.Value.AddMonths(1) <= sada;
        }
    }
}