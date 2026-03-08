using System;
using System.Collections.Generic;
using System.Text;

using CoworkingSystem.backend.Services;

namespace CoworkingSystem.backend.Izvestaji
{
    internal class CsvExportObserver : IExportObserver
    {
        private readonly IReportPeriodStrategy _periodStrategy;
        private readonly StatistikaService _statistikaService;
        private readonly CsvExportService _csvExportService;
        private readonly string _folderPutanja;

        private DateTime? _poslednjePokretanje;

        public CsvExportObserver(
            IReportPeriodStrategy periodStrategy,
            StatistikaService statistikaService,
            CsvExportService csvExportService,
            string folderPutanja)
        {
            _periodStrategy = periodStrategy;
            _statistikaService = statistikaService;
            _csvExportService = csvExportService;
            _folderPutanja = folderPutanja;
        }

        public void Update(DateTime sada)
        {
            if (!_periodStrategy.TrebaPokrenuti(_poslednjePokretanje, sada))
                return;

            var (periodOd, periodDo) = _periodStrategy.IzracunajPeriod(sada);

            var statistikaRadnihMesta = _statistikaService.GetStatistikaRadnihMesta(periodOd, periodDo);
            var statistikaSala = _statistikaService.GetStatistikaSala(periodOd, periodDo);
            var statistikaTipovaClanstva = _statistikaService.GetStatistikaTipovaClanstva(periodOd, periodDo);

            _csvExportService.Exportuj(
                _folderPutanja,
                periodOd,
                periodDo,
                statistikaRadnihMesta,
                statistikaSala,
                statistikaTipovaClanstva);

            _poslednjePokretanje = sada;
        }
    }
}