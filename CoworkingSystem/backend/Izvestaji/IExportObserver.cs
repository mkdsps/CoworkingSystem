using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Izvestaji
{
    internal interface IExportObserver
    {
        void Update(DateTime sada);
    }
}