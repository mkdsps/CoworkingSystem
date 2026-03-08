using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    internal class RadnoMestoService
    {
        private readonly IResursiRepo _resursiRepo;

        public RadnoMestoService(IResursiRepo resursiRepo)
        {
            _resursiRepo = resursiRepo;
        }

        public int AddRadnoMesto(Resurs radnoMesto)
        {
            ValidateRadnoMesto(radnoMesto);
            radnoMesto.TipResursa = "RadnoMesto";
            return _resursiRepo.Insert(radnoMesto);
        }

        public void UpdateRadnoMesto(Resurs radnoMesto)
        {
            ValidateRadnoMesto(radnoMesto);
            radnoMesto.TipResursa = "RadnoMesto";
            _resursiRepo.Update(radnoMesto);
        }

        public void DeleteRadnoMesto(int id)
        {
            _resursiRepo.Delete(id);
        }

        public void SetActive(int id, bool active)
        {
            _resursiRepo.SetActive(id, active);
        }

        public List<Resurs> GetAllRadnaMesta()
        {
            return _resursiRepo.GetAllRadnaMesta();
        }

        public List<Resurs> GetRadnaMestaByLokacija(int lokacijaId)
        {
            return _resursiRepo.GetRadnaMestaByLokacija(lokacijaId);
        }

        public Resurs? GetById(int id)
        {
            return _resursiRepo.GetById(id);
        }

        private void ValidateRadnoMesto(Resurs radnoMesto)
        {
            if (radnoMesto == null)
                throw new ArgumentNullException(nameof(radnoMesto));

            if (radnoMesto.LokacijaId <= 0)
                throw new Exception("Lokacija je obavezna.");

            if (string.IsNullOrWhiteSpace(radnoMesto.Oznaka))
                throw new Exception("Oznaka radnog mesta je obavezna.");

            if (string.IsNullOrWhiteSpace(radnoMesto.PodtipStola))
                throw new Exception("Podtip stola je obavezan.");

            if (radnoMesto.PodtipStola != "FleksibilniSto" &&
                radnoMesto.PodtipStola != "FiksniSto")
                throw new Exception("Podtip stola mora biti FleksibilniSto ili FiksniSto.");

            if (radnoMesto.BrojRadnihMesta.HasValue && radnoMesto.BrojRadnihMesta < 0)
                throw new Exception("Broj radnih mesta ne moze biti negativan.");

            if (radnoMesto.Kapacitet.HasValue)
                throw new Exception("Radno mesto ne treba da ima kapacitet.");

            if (radnoMesto.ImaProjektor.HasValue ||
                radnoMesto.ImaTV.HasValue ||
                radnoMesto.ImaTablu.HasValue ||
                radnoMesto.ImaOnlineOpremu.HasValue)
                throw new Exception("Radno mesto ne treba da ima opremu sale.");

            if (radnoMesto.Povrsina.HasValue)
                throw new Exception("Radno mesto ne treba da ima povrsinu sale.");
        }

    }
}
