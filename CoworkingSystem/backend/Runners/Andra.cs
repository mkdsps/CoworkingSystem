using CoworkingSystem.backend.dbConnection;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Linq;
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
                SqlRepoFactory repo = new SqlRepoFactory();
                var rezervacijeService = new RezervacijeService(repo);
                var rezervacijeRepo = repo.createRezervacijeRepo();

                var sb = new StringBuilder();

                sb.AppendLine("=== TEST REZERVACIJA ===");
                sb.AppendLine();

                // Test podaci pretpostavljaju da postoje:
                // KorisnikId = 1
                // ResursId = 1
                // Resurs 1 pripada lokaciji koja radi u terminu ispod

                DateTime datumTesta = DateTime.Today.AddDays(1);

                // =========================
                // 1. KREIRANJE REZERVACIJE
                // =========================
                var novaRezervacija = new Rezervacija
                {
                    KorisnikId = 1,
                    ResursId = 1,
                    DatumVremePocetka = datumTesta.AddHours(10),
                    DatumVremeZavrsetka = datumTesta.AddHours(12),
                    Status = StatusRezervacije.Aktivna,
                    BrojUcesnika = null,
                    Napomena = "Test rezervacija preko RezervacijeService"
                };

                int id = rezervacijeService.dodajRezervaciju(novaRezervacija);

                sb.AppendLine("1. Kreiranje rezervacije");
                sb.AppendLine($"Rezervacija kreirana sa ID: {id}");
                sb.AppendLine(
                    $"Termin: {novaRezervacija.DatumVremePocetka:dd.MM.yyyy HH:mm} - {novaRezervacija.DatumVremeZavrsetka:HH:mm}"
                );
                sb.AppendLine();

                // =========================
                // 2. IZMENA REZERVACIJE
                // =========================
                novaRezervacija.Id = id;
                novaRezervacija.DatumVremePocetka = datumTesta.AddHours(13);
                novaRezervacija.DatumVremeZavrsetka = datumTesta.AddHours(15);
                novaRezervacija.Napomena = "Izmenjena test rezervacija";

                rezervacijeService.IzmeniRezervaciju(novaRezervacija);

                sb.AppendLine("2. Izmena rezervacije");
                sb.AppendLine($"Rezervacija {id} je izmenjena.");
                sb.AppendLine(
                    $"Novi termin: {novaRezervacija.DatumVremePocetka:dd.MM.yyyy HH:mm} - {novaRezervacija.DatumVremeZavrsetka:HH:mm}"
                );
                sb.AppendLine();

                // =========================
                // 3. REZERVACIJE ZA KORISNIKA
                // =========================
                var rezervacijeKorisnika = rezervacijeService.VratiRezervacijeZaKorisnika(1);

                sb.AppendLine("3. Rezervacije za korisnika 1");
                sb.AppendLine($"Ukupno: {rezervacijeKorisnika.Count}");

                foreach (var r in rezervacijeKorisnika.Take(10))
                {
                    sb.AppendLine(
                        $"ID:{r.Id} | Resurs:{r.ResursId} | " +
                        $"{r.DatumVremePocetka:dd.MM HH:mm}-{r.DatumVremeZavrsetka:HH:mm} | " +
                        $"Status:{r.Status}"
                    );
                }

                sb.AppendLine();

                // =========================
                // 4. REZERVACIJE ZA DAN I LOKACIJU
                // =========================
                int lokacijaId = rezervacijeRepo.GetLokacijaIdByResursId(1);
                var rezervacijeZaDan = rezervacijeService.VratiRezervacijeZaDanILokaciju(lokacijaId, datumTesta);

                sb.AppendLine($"4. Rezervacije za datum {datumTesta:dd.MM.yyyy} i lokaciju {lokacijaId}");
                sb.AppendLine($"Ukupno: {rezervacijeZaDan.Count}");

                foreach (var r in rezervacijeZaDan.Take(10))
                {
                    sb.AppendLine(
                        $"ID:{r.Id} | Korisnik:{r.KorisnikId} | Resurs:{r.ResursId} | " +
                        $"{r.DatumVremePocetka:HH:mm}-{r.DatumVremeZavrsetka:HH:mm} | " +
                        $"Status:{r.Status}"
                    );
                }

                sb.AppendLine();

                // =======================================================
                // 5. VALIDACIJA: RESURS JE VEC ZAUZET U DATOM TERMINU
                // =======================================================
                sb.AppendLine("5. Validacija: zauzet resurs u istom terminu");

                int postojecaRezId = rezervacijeService.dodajRezervaciju(new Rezervacija
                {
                    KorisnikId = 1,
                    ResursId = 1,
                    DatumVremePocetka = datumTesta.AddHours(16),
                    DatumVremeZavrsetka = datumTesta.AddHours(18),
                    Status = StatusRezervacije.Aktivna,
                    Napomena = "Baza za test zauzetog resursa"
                });

                try
                {
                    var konfliktnaRezervacija = new Rezervacija
                    {
                        KorisnikId = 1,
                        ResursId = 1,
                        DatumVremePocetka = datumTesta.AddHours(17), // preklapa se
                        DatumVremeZavrsetka = datumTesta.AddHours(19),
                        Status = StatusRezervacije.Aktivna,
                        Napomena = "Ova rezervacija treba da padne - zauzet resurs"
                    };

                    rezervacijeService.dodajRezervaciju(konfliktnaRezervacija);

                    sb.AppendLine("FAIL: Sistem je dozvolio rezervaciju zauzetog resursa.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine("PASS: Sistem je odbio rezervaciju zauzetog resursa.");
                    sb.AppendLine($"Poruka: {ex.Message}");
                }

                sb.AppendLine();

                // =======================================================
                // 6. VALIDACIJA: PREKORACEN DOZVOLJEN BROJ SATI CLANSTVA
                // =======================================================
                sb.AppendLine("6. Validacija: prekoracen broj sati po clanstvu");

                try
                {
                    // Ovaj test pretpostavlja da korisnik 1 ima ogranicenje sati
                    // i da ce kombinacija rezervacija probiti limit.
                    // Po potrebi promeni trajanje ili koristi drugog korisnika
                    // za kog sigurno znas ogranicenje.
                    var predugaRezervacija = new Rezervacija
                    {
                        KorisnikId = 1,
                        ResursId = 1,
                        DatumVremePocetka = datumTesta.AddDays(1).AddHours(8),
                        DatumVremeZavrsetka = datumTesta.AddDays(1).AddHours(20), // 12h
                        Status = StatusRezervacije.Aktivna,
                        Napomena = "Test prekoracenja limita sati"
                    };

                    rezervacijeService.dodajRezervaciju(predugaRezervacija);

                    sb.AppendLine("FAIL: Sistem je dozvolio prekoracenje dozvoljenog broja sati.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine("PASS: Sistem je odbio rezervaciju zbog prekoracenja limita sati.");
                    sb.AppendLine($"Poruka: {ex.Message}");
                }

                sb.AppendLine();

                // =======================================================
                // 7. VALIDACIJA: REZERVACIJA VAN RADNOG VREMENA LOKACIJE
                // =======================================================
                sb.AppendLine("7. Validacija: rezervacija van radnog vremena");

                try
                {
                    // Pretpostavka: lokacija ne radi u 06:00 ili u kasnim vecernjim satima.
                    // Ako radi, promeni na neki termin za koji sigurno ne radi.
                    var vanRadnogVremena = new Rezervacija
                    {
                        KorisnikId = 1,
                        ResursId = 1,
                        DatumVremePocetka = datumTesta.AddDays(2).AddHours(6),
                        DatumVremeZavrsetka = datumTesta.AddDays(2).AddHours(7),
                        Status = StatusRezervacije.Aktivna,
                        Napomena = "Test van radnog vremena"
                    };

                    rezervacijeService.dodajRezervaciju(vanRadnogVremena);

                    sb.AppendLine("FAIL: Sistem je dozvolio rezervaciju van radnog vremena.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine("PASS: Sistem je odbio rezervaciju van radnog vremena.");
                    sb.AppendLine($"Poruka: {ex.Message}");
                }

                sb.AppendLine();

                // =========================
                // 8. OTKAZIVANJE REZERVACIJE
                // =========================
                rezervacijeService.OtkaziRezervaciju(id);

                var rezervacijePosleOtkazivanja = rezervacijeService.VratiRezervacijeZaKorisnika(1);
                var otkazana = rezervacijePosleOtkazivanja.FirstOrDefault(r => r.Id == id);

                sb.AppendLine("8. Otkazivanje rezervacije");
                if (otkazana != null)
                {
                    sb.AppendLine($"Rezervacija {id} je otkazana.");
                    sb.AppendLine($"Status nakon otkazivanja: {otkazana.Status}");
                }
                else
                {
                    sb.AppendLine($"Rezervacija {id} nije pronadjena nakon otkazivanja.");
                }

                // Ciscenje pomocne rezervacije za test konflikta
                try
                {
                    rezervacijeService.OtkaziRezervaciju(postojecaRezId);
                }
                catch
                {
                    // namerno ignorisemo ako je vec obradjena / nije pronadjena
                }

                sb.AppendLine();
                sb.AppendLine("TEST USPESNO ZAVRSEN.");

                MessageBox.Show(
                    sb.ToString(),
                    "Andra TEST",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ANDRA TEST FAIL");
            }
        }
    }
}