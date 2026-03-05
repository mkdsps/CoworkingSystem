using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    internal class LokacijaService
    {
        private readonly ILokacijeRepo _lokacijeRepo;

        public LokacijaService(ILokacijeRepo lokacijeRepo)
        {
            _lokacijeRepo = lokacijeRepo ?? throw new ArgumentNullException(nameof(lokacijeRepo));
        }

        public List<Lokacija> GetAll()
            => _lokacijeRepo.GetAll();

        public Lokacija? GetById(int id)
        {
            if (id <= 0) throw new ArgumentException("Neispravan ID lokacije.");
            return _lokacijeRepo.GetById(id);
        }

        public List<Lokacija> GetByActive(bool active)
            => _lokacijeRepo.GetByActive(active);

        public List<LokacijaStatistika> GetLokacijeSaStatistikom(bool? onlyActiveLocations = null)
            => _lokacijeRepo.GetAllStats(onlyActiveLocations);


        public int AddLokacija(string naziv, string adresa, string grad, string radnoVreme,
                              int maksimalanBrojKorisnika, string? opis, bool aktivna = true)
        {
            Validate(naziv, adresa, grad, radnoVreme, maksimalanBrojKorisnika, opis);

            var l = new Lokacija
            {
                Naziv = naziv.Trim(),
                Adresa = adresa.Trim(),
                Grad = grad.Trim(),
                RadnoVreme = radnoVreme.Trim(),
                MaksimalanBrojKorisnika = maksimalanBrojKorisnika,
                Opis = string.IsNullOrWhiteSpace(opis) ? null : opis.Trim(),
                Aktivna = aktivna
            };

            return _lokacijeRepo.Insert(l);
        }

        public void UpdateLokacija(int id, string naziv, string adresa, string grad, string radnoVreme,
                                  int maksimalanBrojKorisnika, string? opis, bool aktivna)
        {
            if (id <= 0) throw new ArgumentException("Neispravan ID lokacije.");

            Validate(naziv, adresa, grad, radnoVreme, maksimalanBrojKorisnika, opis);

            var l = new Lokacija
            {
                Id = id,
                Naziv = naziv.Trim(),
                Adresa = adresa.Trim(),
                Grad = grad.Trim(),
                RadnoVreme = radnoVreme.Trim(),
                MaksimalanBrojKorisnika = maksimalanBrojKorisnika,
                Opis = string.IsNullOrWhiteSpace(opis) ? null : opis.Trim(),
                Aktivna = aktivna
            };

            _lokacijeRepo.Update(l);
        }

        public void DeleteLokacija(int id)
        {
            if (id <= 0) throw new ArgumentException("Neispravan ID lokacije.");
            _lokacijeRepo.Delete(id);
        }

        public void SetAktivna(int id, bool aktivna)
        {
            if (id <= 0) throw new ArgumentException("Neispravan ID lokacije.");
            _lokacijeRepo.SetActive(id, aktivna);
        }

        private static void Validate(string naziv, string adresa, string grad, string radnoVreme,
                                     int maksimalanBrojKorisnika, string? opis)
        {
            if (string.IsNullOrWhiteSpace(naziv))
                throw new ArgumentException("Naziv lokacije je obavezan.");
            if (naziv.Trim().Length > 100)
                throw new ArgumentException("Naziv lokacije može imati najviše 100 karaktera.");

            if (string.IsNullOrWhiteSpace(adresa))
                throw new ArgumentException("Adresa je obavezna.");
            if (adresa.Trim().Length > 200)
                throw new ArgumentException("Adresa može imati najviše 200 karaktera.");

            if (string.IsNullOrWhiteSpace(grad))
                throw new ArgumentException("Grad je obavezan.");
            if (grad.Trim().Length > 100)
                throw new ArgumentException("Grad može imati najviše 100 karaktera.");

            if (string.IsNullOrWhiteSpace(radnoVreme))
                throw new ArgumentException("Radno vreme je obavezno.");
            if (radnoVreme.Trim().Length > 50)
                throw new ArgumentException("Radno vreme može imati najviše 50 karaktera.");

            if (maksimalanBrojKorisnika <= 0)
                throw new ArgumentException("Maksimalan broj korisnika mora biti veći od 0.");

            if (opis != null && opis.Trim().Length > 300)
                throw new ArgumentException("Opis može imati najviše 300 karaktera.");
        }
    }
}
