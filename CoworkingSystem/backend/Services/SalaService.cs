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

        public SalaService(IResursiRepo resursiRepo)
        {
            _resursiRepo = resursiRepo;
        }

        public int AddSala(Resurs sala)
        {
            ValidateSala(sala);
            sala.TipResursa = "Sala";
            return _resursiRepo.Insert(sala);
        }

        public void UpdateSala(Resurs sala)
        {
            ValidateSala(sala);
            sala.TipResursa = "Sala";
            _resursiRepo.Update(sala);
        }

        public void DeleteSala(int id)
        {
            _resursiRepo.Delete(id);
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
