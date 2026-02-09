using CoworkingSystem.backend;
using CoworkingSystem.backend.dbConnection;
using Microsoft.Data.SqlClient;
using MySqlConnector;
using System;
using System.Windows.Forms;

namespace CoworkingSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DbManager manager = DbManager.GetInstance();
            Config config = Config.getInstance();

            MessageBox.Show(
                $"Brand={config.name}\nType={config.type}\nCS={config.connectionString}",
                "CONFIG DEBUG"
            );


            try
            {
                var repo = new CoworkingSystem.backend.Repositories.SqlKorisnikRepo();

                var k = new CoworkingSystem.backend.Modules.Korisnik
                {
                    Ime = "Test",
                    Prezime = "Korisnik",
                    Email = $"test_{DateTime.Now:yyyyMMdd_HHmmss}@mail.com",
                    Telefon = "060123456",
                    TipClanstvaId = 1,
                    DatumPocetka = DateTime.Now,
                    DatumIsteka = DateTime.Now.AddDays(30),
                    Status = "aktivan",
                    LokacijaId = 1,
                    Napomena = "insert test"
                };

                repo.InsertUser(k);

                MessageBox.Show("INSERT je uspeo ✅", "DB TEST");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "INSERT FAILED ❌");
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            
        }
    }
}
