using System;
using System.Collections.Generic;
using System.Text;

using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;

namespace CoworkingSystem.backend.Izvestaji
{
    internal static class ReportBootstrap
    {
        public static ExportScheduler KreirajScheduler()
        {
            IResursiRepo resursiRepo = new SqlResursiRepo();
            ITipClanstvaRepo tipClanstvaRepo = new SqlTipClanstvaRepo();
            IKorisniciRepo korisniciRepo = new SqlKorisnikRepo();
            IRezervacijeRepo rezervacijeRepo = new SqlRezervacijeRepo();
            ILokacijeRepo lokacijeRepo = new SqlLokacijaRepo();

            var statistikaService = new StatistikaService(resursiRepo, tipClanstvaRepo,korisniciRepo,rezervacijeRepo,lokacijeRepo);
            var csvExportService = new CsvExportService();

            // OVDE BIRAS KOJI IZVESTAJ HOCES
            IReportPeriodStrategy strategy = new DailyReportStrategy();
            // IReportPeriodStrategy strategy = new MonthlyReportStrategy();

            string folderPutanja = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Izvestaji");

            var observer = new CsvExportObserver(
                strategy,
                statistikaService,
                csvExportService,
                folderPutanja);

            // proverava na svakih 60 sekundi da li je vreme za novi export
            var scheduler = new ExportScheduler(TimeSpan.FromSeconds(60));

            scheduler.Subscribe(observer);

            return scheduler;
        }
    }
}