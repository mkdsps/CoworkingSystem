using CoworkingSystem.backend.Repositories;
using System;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem.backend.Runners
{
    internal class Andra
    {
        public static void Run()
        {
            try
            {
                var korisniciRepo = new SqlKorisnikRepo();
                var sb = new StringBuilder();

                sb.AppendLine("=== TEST KORISNICI SA REZERVACIJAMA ZA LOKACIJU ===");
                sb.AppendLine();

                int lokacijaId = 1;

                var rezultat = korisniciRepo.GetKorisniciSaRezervacijamaNaLokaciji(lokacijaId);

                sb.AppendLine($"Lokacija ID: {lokacijaId}");
                sb.AppendLine($"Ukupno korisnika: {rezultat.Count}");
                sb.AppendLine();

                foreach (var k in rezultat)
                {
                    sb.AppendLine(
                        $"KorisnikId: {k.Id} | " +
                        $"{k.Ime} {k.Prezime} | " +
                        $"Email: {k.Email} | "
                    );
                }

                MessageBox.Show(
                    sb.ToString(),
                    "TEST KORISNICI / LOKACIJA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "TEST FAIL");
            }
        }
    }
}