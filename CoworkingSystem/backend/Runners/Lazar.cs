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
                    System.Diagnostics.Debug.WriteLine($"Resurs sa ID 7: {resurs.Oznaka} {resurs.TipResursa}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Resurs sa ID 7 nije pronađen.");
                }

                //Console.WriteLine("=== KRAJ TESTA ===");                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}
