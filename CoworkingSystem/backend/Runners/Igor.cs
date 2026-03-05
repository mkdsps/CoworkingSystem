using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
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
                    Id = 2,
                    Ime = "Neko",
                    Prezime = "Nekic",
                    Email = $"igor_{DateTime.Now:yyyyMMdd_HHmmss}@mail.com",
                    Telefon = "123454",
                    TipClanstvaId = 2,
                    DatumPocetka = DateTime.Now,
                    DatumIsteka = DateTime.Now.AddDays(30),
                    Status = "aktivan",
                    LokacijaId = 1,
                    Napomena = "igor insert"
                };

                KorisnikService ks = new KorisnikService(repo);


                KorisnikFilter kf = new KorisnikFilter();
                kf.TipClanstvaId = 2;
                kf.LokacijaId = 1;

                foreach(var kor in ks.GetUsers(kf))
                    MessageBox.Show($"{kor}");

                ks.DeleteUser(10);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "IGOR FAIL");
            }
        }
    }
}
