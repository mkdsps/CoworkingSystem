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
                Debug.WriteLine("=== TEST RADNO MESTO SERVICE ===");

                IResursiRepo repo = new SqlResursiRepo();
                RadnoMestoService service = new RadnoMestoService(repo);

                List<Resurs> svaRadnaMesta = service.GetAllRadnaMesta();
                Debug.WriteLine($"Ukupno radnih mesta: {svaRadnaMesta.Count}");

                List<Resurs> radnaMestaNaLokaciji = service.GetRadnaMestaByLokacija(2);
                Debug.WriteLine($"Radna mesta na lokaciji 1: {radnaMestaNaLokaciji.Count}");

                foreach (var rm in radnaMestaNaLokaciji)
                {
                    Debug.WriteLine($"Radno mesto ID: {rm.Id}, Oznaka: {rm.Oznaka}, Aktivan: {rm.Aktivan}");
                }

                Debug.WriteLine("=== KRAJ TESTA RADNO MESTO SERVICE ===");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "LAZAR FAIL");
            }
        }
    }
}
