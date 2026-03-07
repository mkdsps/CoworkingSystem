using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Runners
{
    internal class Lazar
    {
        public static void Run()
        {
            try
            {
                var repo = new SqlResursiRepo();

                List<Resurs> resursi = repo.GetAll();

                System.Diagnostics.Debug.WriteLine($"Ukupno resursa: {resursi.Count}");

                foreach (Resurs r in resursi)
                {
                    System.Diagnostics.Debug.WriteLine($"{r.Id} {r.Oznaka} {r.TipResursa}");
                }

                Resurs? resurs = repo.GetById(10);
                if (resurs != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Resurs sa ID 10: {resurs.Oznaka} {resurs.TipResursa}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Resurs sa ID 10 nije pronađen.");
                }

                var radnaMesta = repo.GetRadnaMestaByLokacija(1);
                System.Diagnostics.Debug.WriteLine("=== Radna mesta na lokaciji 1 ===");
                foreach (var r in radnaMesta)
                {
                    System.Diagnostics.Debug.WriteLine($"{r.Id} {r.Oznaka} {r.TipResursa}");
                }

                var sale = repo.GetSaleByLokacija(2);
                System.Diagnostics.Debug.WriteLine("=== Sale na lokaciji 2 ===");
                foreach (var r in sale)
                {
                    System.Diagnostics.Debug.WriteLine($"{r.Id} {r.Oznaka} {r.TipResursa}");
                }

                var svaRadnaMesta = repo.GetAllRadnaMesta();
                System.Diagnostics.Debug.WriteLine("=== Sva radna mesta ===");
                foreach (var r in svaRadnaMesta)
                {
                    System.Diagnostics.Debug.WriteLine($"{r.Id} {r.Oznaka} {r.TipResursa}");
                }

                var sveSale = repo.GetAllSale();
                System.Diagnostics.Debug.WriteLine("=== Sve sale ===");
                foreach (var r in sveSale)
                {
                    System.Diagnostics.Debug.WriteLine($"{r.Id} {r.Oznaka} {r.TipResursa}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}
