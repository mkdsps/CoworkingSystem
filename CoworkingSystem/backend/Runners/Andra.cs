using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Runners
{
    internal class Andra
    {
        
        public static void Run()
        {
            try
            {
                SqlRepoFactory repo = new SqlRepoFactory();
                var service = new LokacijaService(repo.CreateLokacijeRepo());
                var loginService = new AdminService(repo.createAdminRepo());
                var log = loginService.Validate("andrija", "admin123");
                if(log)
                {
                    MessageBox.Show("USPESNO");
                }
                else
                {
                    MessageBox.Show("NIJE");
                }

                var all = service.GetLokacijeSaStatistikom();

                var activeOnly = service.GetLokacijeSaStatistikom(onlyActiveLocations: true);

                var sb = new StringBuilder();
                sb.AppendLine("=== Lokacije sa statistikama ===");
                sb.AppendLine($"Sve lokacije: {all.Count}");
                sb.AppendLine($"Samo aktivne: {activeOnly.Count}");
                sb.AppendLine();

                if (all.Count == 0)
                {
                    sb.AppendLine("Nema lokacija u bazi. Ubaci bar jednu lokaciju i radna mesta.");
                    MessageBox.Show(sb.ToString(), "Test statistike", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Prikaži prvih par (da ne bude predugačko)
                foreach (var x in all.Take(5))
                {
                    sb.AppendLine(
                        $"{x.LokacijaId} | {x.Naziv} ({x.Grad})" +
                        $" -> Ukupno desk: {x.UkupnoRadnihMesta}," +
                        $" Trenutno zauzeto: {x.TrenutnoRezervisano}," +
                        $" Zauzetost: {x.ProcenatZauzetosti}%"
                    );
                }

                MessageBox.Show(sb.ToString(), "Test statistike OK", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "IGOR FAIL");
            }
        }
    }
}
