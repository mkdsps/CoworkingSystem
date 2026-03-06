using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem.backend.Runners
{
    internal class Smilja
    {
        public static void Run()
        {
            try
            {
                var repo = new SqlTipClanstvaRepo();
                var ts = new TipClanstvaService(repo);

                // TEST INSERT (može da se ponavlja Naziv - zato DISTINCT služi za listu naziva)
                var tp = new TipClanstva
                {
                    // Id ne moraš da setuješ ako je auto-increment u bazi
                    Naziv = "Dnevni paket",
                    Cena = 1500m,
                    TrajanjeDana = 1,
                    MaksimalnoSatiMesecno = 10,
                    DozvolaSale = false,
                    SaleSatiMesecno = null,   // jer DozvolaSale = false
                    Opis = "Test insert iz Smilja runner-a",
                    Aktivan = true
                    // DatumKreiranja puni baza (CURRENT_TIMESTAMP) u INSERT-u
                };

                int newId = ts.AddTipClanstva(tp);
                MessageBox.Show($"Ubačen TipClanstva. NewId = {newId}", "SMILJA INSERT OK");

                // GET ALL
                var all = ts.GetAll();
                foreach (var x in all)
                    MessageBox.Show($"{x}", "SMILJA GET ALL");

                // DISTINCT NAMES (jedinstveni nazivi za dropdown)
                var names = ts.DistinctNames();
                MessageBox.Show(string.Join(", ", names), "SMILJA DISTINCT NAMES");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "SMILJA FAIL");
            }
        }
    }
}