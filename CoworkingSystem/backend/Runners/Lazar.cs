using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CoworkingSystem.backend.Runners
{
    internal class Lazar
    {
        public static void Run()
        {
            try
            {
                Debug.WriteLine("=== TEST SALA SERVICE ===");

                IResursiRepo repo = new SqlResursiRepo();
                ILokacijeRepo repoL = new SqlLokacijaRepo();
                SalaService service = new SalaService(repo,repoL);

                
                List<Resurs> sveSale = service.GetAllSale();
                Debug.WriteLine($"Ukupno sala: {sveSale.Count}");

                List<Resurs> saleNaLokaciji = service.GetSaleByLokacija(1);
                Debug.WriteLine($"Sale na lokaciji 1: {saleNaLokaciji.Count}");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}
