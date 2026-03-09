using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;

namespace CoworkingSystem.backend.Services
{
    internal class RadnoMestoService
    {
        private readonly IResursiRepo _resursiRepo;
        private readonly ILokacijeRepo _lokacijeRepo;

        public RadnoMestoService(IResursiRepo resursiRepo, ILokacijeRepo lokacijeRepo)
        {
            _resursiRepo = resursiRepo;
            _lokacijeRepo = lokacijeRepo;
        }

        public int AddRadnoMesto(Resurs radnoMesto)
        {
            ValidateRadnoMesto(radnoMesto);
            radnoMesto.TipResursa = "RadnoMesto";

            int id = _resursiRepo.Insert(radnoMesto);

            _lokacijeRepo.SetActive(radnoMesto.LokacijaId, true);

            return id;
        }

        public void UpdateRadnoMesto(Resurs radnoMesto)
        {
            ValidateRadnoMesto(radnoMesto);
            radnoMesto.TipResursa = "RadnoMesto";

            var staroRadnoMesto = _resursiRepo.GetById(radnoMesto.Id);
            if (staroRadnoMesto == null)
                throw new Exception("Radno mesto ne postoji.");

            _resursiRepo.Update(radnoMesto);

            bool staraLokacijaImaResurse = _resursiRepo.LokacijaImaAktivneResurse(staroRadnoMesto.LokacijaId);
            _lokacijeRepo.SetActive(staroRadnoMesto.LokacijaId, staraLokacijaImaResurse);

            bool novaLokacijaImaResurse = _resursiRepo.LokacijaImaAktivneResurse(radnoMesto.LokacijaId);
            _lokacijeRepo.SetActive(radnoMesto.LokacijaId, novaLokacijaImaResurse);
        }

        public void DeleteRadnoMesto(int id)
        {
            var radnoMesto = _resursiRepo.GetById(id);
            if (radnoMesto == null)
                throw new Exception("Radno mesto ne postoji.");

            int lokacijaId = radnoMesto.LokacijaId;

            _resursiRepo.Delete(id);

            bool imaResurse = _resursiRepo.LokacijaImaAktivneResurse(lokacijaId);
            _lokacijeRepo.SetActive(lokacijaId, imaResurse);
        }

        public void SetActive(int id, bool active)
        {
            var radnoMesto = _resursiRepo.GetById(id);
            if (radnoMesto == null)
                throw new Exception("Radno mesto ne postoji.");

            _resursiRepo.SetActive(id, active);

            bool imaResurse = _resursiRepo.LokacijaImaAktivneResurse(radnoMesto.LokacijaId);
            _lokacijeRepo.SetActive(radnoMesto.LokacijaId, imaResurse);
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