using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Runners
{
    internal class Igor
    {
        public static void Run()
        {
            try
            {
                var repo = new SqlKorisnikRepo();
                var k = new Korisnik
                {
                    Ime = "Igor",
                    Prezime = "Test",
                    Email = $"igor_{DateTime.Now:yyyyMMdd_HHmmss}@mail.com",
                    Telefon = "060000000",
                    TipClanstvaId = 1,
                    DatumPocetka = DateTime.Now,
                    DatumIsteka = DateTime.Now.AddDays(30),
                    Status = "aktivan",
                    LokacijaId = 1,
                    Napomena = "igor insert"
                };

                repo.InsertUser(k);
                MessageBox.Show("IGOR INSERT OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "IGOR FAIL");
            }
        }
    }
}
