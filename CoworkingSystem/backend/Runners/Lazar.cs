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

                IResursiRepo repo = new SqlResursiRepo();
                ILokacijeRepo repoL = new SqlLokacijaRepo();
                SalaService service = new SalaService(repo,repoL);

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