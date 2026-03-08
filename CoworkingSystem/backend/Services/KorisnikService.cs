using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    internal class KorisnikService
    {
        private readonly IKorisniciRepo _korisnikRepo;

        public KorisnikService(IKorisniciRepo korisnikRepo)
        {
            _korisnikRepo = korisnikRepo;
        }

        public int AddUser(Korisnik k)
        {
            ValidateUser(k, isCreate: true);
            return _korisnikRepo.Insert(k);
        }

        public void UpdateUser(Korisnik k)
        {
            if (k == null) throw new ArgumentNullException(nameof(k));
            if (k.Id <= 0) throw new Exception("Id korisnika je obavezan za izmenu.");

            ValidateUser(k, isCreate: false);
            _korisnikRepo.Update(k);
        }

        public void DeleteUser(int id)
        {
            if (id <= 0) throw new Exception("Neispravan id.");
            _korisnikRepo.Delete(id);
        }




        // read deo..
        public List<Korisnik> GetAll() => _korisnikRepo.GetAll();
        public Korisnik GetByID(int id) => _korisnikRepo.GetByID(id);

        public List<Korisnik> GetUsers(KorisnikFilter filter)
        {
            if (filter == null) return _korisnikRepo.GetAll();
            return _korisnikRepo.Get(filter);
        }



        // helper validacija user-a..
        private static void ValidateUser(Korisnik k, bool isCreate)
        {
            if (k == null) throw new ArgumentNullException(nameof(k));

            if (string.IsNullOrWhiteSpace(k.Ime)) throw new Exception("Ime je obavezno.");
            if (string.IsNullOrWhiteSpace(k.Prezime)) throw new Exception("Prezime je obavezno.");
            if (string.IsNullOrWhiteSpace(k.Email)) throw new Exception("Email je obavezan.");
            if (!k.Email.Contains("@")) throw new Exception("Email nije validan.");
            if (string.IsNullOrWhiteSpace(k.Telefon)) throw new Exception("Telefon je obavezan.");

            if (k.TipClanstvaId <= 0) throw new Exception("Tip članstva je obavezan.");
            if (k.LokacijaId <= 0) throw new Exception("Lokacija je obavezna.");

            // status validacija
            var s = (k.Status ?? "").Trim().ToLower();
            if (s != "Aktivan" && s != "Pauziran" && s != "Istekao")
                throw new Exception("Status mora biti: aktivan, pauziran ili istekao.");

            // datumi
            if (k.DatumIsteka < k.DatumPocetka)
                throw new Exception("Datum isteka ne sme biti pre datuma početka.");
        }
    
    }
}
