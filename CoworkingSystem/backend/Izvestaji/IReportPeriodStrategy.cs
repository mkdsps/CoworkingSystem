using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Izvestaji
{
    internal interface IReportPeriodStrategy
    {
        string Naziv { get; }

        (DateTime periodOd, DateTime periodDo) IzracunajPeriod(DateTime sada);

        bool TrebaPokrenuti(DateTime? poslednjePokretanje, DateTime sada);
    }
}