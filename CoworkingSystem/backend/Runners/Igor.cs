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
                RezervacijeService rs = new RezervacijeService(new SqlRepoFactory());


                Rezervacija r = new Rezervacija
                {
                    KorisnikId = 2,
                    ResursId = 1,
                    DatumVremePocetka = new DateTime(2026, 3, 7, 10, 0, 0),
                    DatumVremeZavrsetka = new DateTime(2026, 3, 7, 12, 0, 0),
                    Status = StatusRezervacije.Aktivna,
                    BrojUcesnika = null,
                    Napomena = "Rad na projektu",
                    DatumKreiranja = DateTime.Now,
                    DatumIzmene = null
                };


                rs.dodajRezervaciju(r);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "IGOR FAIL");
            }
        }
    }
}
