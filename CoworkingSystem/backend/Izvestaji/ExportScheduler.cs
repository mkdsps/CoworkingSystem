using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;

namespace CoworkingSystem.backend.Izvestaji
{
    internal class ExportScheduler : IDisposable
    {
        private readonly List<IExportObserver> _observers = new();
        private readonly System.Threading.Timer _timer;

        public ExportScheduler(TimeSpan intervalProvere)
        {
            _timer = new System.Threading.Timer(Proveri, null, Timeout.Infinite, Timeout.Infinite);
            IntervalProvere = intervalProvere;
        }

        public TimeSpan IntervalProvere { get; }

        public void Subscribe(IExportObserver observer)
        {
            _observers.Add(observer);
        }

        public void Start()
        {
            _timer.Change(TimeSpan.Zero, IntervalProvere);
        }

        public void Stop()
        {
            _timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }

        private void Proveri(object? state)
        {
            DateTime sada = DateTime.Now;

            foreach (var observer in _observers)
            {
                observer.Update(sada);
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}