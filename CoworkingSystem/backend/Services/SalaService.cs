using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    internal class SalaService
    {
        private readonly IResursiRepo _resursiRepo;
        private readonly ILokacijeRepo _lokacijeRepo;

        public SalaService(IResursiRepo resursiRepo, ILokacijeRepo lokacijeRepo)
        {
            _resursiRepo = resursiRepo;
            _lokacijeRepo = lokacijeRepo;
        }

        public int AddSala(Resurs sala)
        {
            ValidateSala(sala);
            sala.TipResursa = "Sala";
            int id = _resursiRepo.Insert(sala);
            _lokacijeRepo.SetActive(sala.LokacijaId, true);
            return id;
        }

        public void UpdateSala(Resurs sala)
        {
            ValidateSala(sala);
            sala.TipResursa = "Sala";

            var staraSala = _resursiRepo.GetById(sala.Id);
            if (staraSala == null)
                throw new Exception("Sala ne postoji.");

            _resursiRepo.Update(sala);

            bool staraLokacijaImaResurse = _resursiRepo.LokacijaImaAktivneResurse(staraSala.LokacijaId);
            _lokacijeRepo.SetActive(staraSala.LokacijaId, staraLokacijaImaResurse);

            bool novaLokacijaImaResurse = _resursiRepo.LokacijaImaAktivneResurse(sala.LokacijaId);
            _lokacijeRepo.SetActive(sala.LokacijaId, novaLokacijaImaResurse);
        }

        public void DeleteSala(int id)
        {
            var sala = _resursiRepo.GetById(id);
            if (sala == null)
                throw new Exception("Sala ne postoji.");

            int lokacijaId = sala.LokacijaId;

            _resursiRepo.Delete(id);

            bool imaResurse = _resursiRepo.LokacijaImaAktivneResurse(lokacijaId);
            _lokacijeRepo.SetActive(lokacijaId, imaResurse);
        }

        public void SetActive(int id, bool active)
        {
            _resursiRepo.SetActive(id, active);
        }

        public List<Resurs> GetAllSale()
        {
            return _resursiRepo.GetAllSale();
        }

        public List<Resurs> GetSaleByLokacija(int lokacijaId)
        {
            return _resursiRepo.GetSaleByLokacija(lokacijaId);
        }

        public Resurs? GetById(int id)
        {
            return _resursiRepo.GetById(id);
        }

        private void ValidateSala(Resurs sala)
        {
            if (sala == null)
                throw new ArgumentNullException(nameof(sala));

            if (sala.LokacijaId <= 0)
                throw new Exception("Lokacija je obavezna.");

            if (string.IsNullOrWhiteSpace(sala.Oznaka))
                throw new Exception("Oznaka sale je obavezna.");

            if (!sala.Kapacitet.HasValue || sala.Kapacitet <= 0)
                throw new Exception("Kapacitet sale mora biti veci od 0.");

            if (sala.PodtipStola != null)
                throw new Exception("Sala ne sme imati podtip stola.");

            if (sala.BrojRadnihMesta != null)
                throw new Exception("Sala ne sme imati broj radnih mesta.");

            if (sala.Povrsina.HasValue && sala.Povrsina <= 0)
                throw new Exception("Povrsina mora biti veca od 0.");
        }

    }
}
