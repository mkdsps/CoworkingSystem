using CoworkingSystem.backend.Izvestaji;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.backend.Runners
{
    internal class Lazar
    {
        private static ExportScheduler? _scheduler;

        public static void Run()
        {
            try
            {
                IResursiRepo resursiRepo = new SqlResursiRepo();
                ITipClanstvaRepo tipRepo = new SqlTipClanstvaRepo();

                var statistikaService = new StatistikaService(resursiRepo, tipRepo);
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

                _scheduler = new ExportScheduler(TimeSpan.FromSeconds(60));

                _scheduler.Subscribe(observer);
                _scheduler.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}