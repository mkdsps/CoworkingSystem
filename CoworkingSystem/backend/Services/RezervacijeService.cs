using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    class RezervacijeService
    {
        IRepoFactory _repoFactory;

        public RezervacijeService(IRepoFactory repoFactory)
        {
            _repoFactory = repoFactory;
        }

        public int dodajRezervaciju(Rezervacija rezervacija)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            validate(rezervacija);

            return repo.Insert(rezervacija);
        }

        public void IzmeniRezervaciju(Rezervacija rezervacija)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            validate(rezervacija);

            repo.Update(rezervacija);
        }

        public void OtkaziRezervaciju(int rezervacijaId)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            Rezervacija rezervacija = repo.GetByID(rezervacijaId);
            if (rezervacija == null)
                throw new Exception("Rezervacija ne postoji.");

            rezervacija.Status = StatusRezervacije.Otkazana;
            repo.Update(rezervacija);
        }

        public List<Rezervacija> VratiRezervacijeZaKorisnika(int korisnikId)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            RezervacijaFilter filter = new RezervacijaFilter();
            filter.KorisnikId = korisnikId;

            List<Rezervacija> rezervacije = repo.Get(filter);

            foreach (var r in rezervacije)
            {
                r.Status = IzracunajStatus(r);
            }

            return rezervacije;
        }

        public List<Rezervacija> VratiRezervacijeZaDanILokaciju(int lokacijaId, DateTime dan)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            RezervacijaFilter filter = new RezervacijaFilter();
            filter.LokacijaId = lokacijaId;
            filter.DatumOd = dan.Date;
            filter.DatumDo = dan.Date.AddDays(1);

            List<Rezervacija> rezervacije = repo.Get(filter);

            foreach (var r in rezervacije)
            {
                r.Status = IzracunajStatus(r);
            }

            return rezervacije.OrderBy(r => r.DatumVremePocetka).ToList();
        }

        public void validate(Rezervacija rezervacija)
        {
            IRezervacijeRepo repo = _repoFactory.createRezervacijeRepo();

            if (!repo.DaLiJeURadnomVremenuLokacije(repo.GetLokacijaIdByResursId(rezervacija.ResursId), rezervacija.DatumVremePocetka, rezervacija.DatumVremeZavrsetka))
                throw new Exception("Rezervacija nije u radnom vremenu lokacije.");

            if (!repo.IsResursDostupan(rezervacija.ResursId, rezervacija.DatumVremePocetka, rezervacija.DatumVremeZavrsetka))
                throw new Exception("Resurs nije dostupan u izabranom terminu.");

            if (!repo.DaLiKorisnikMozeRezervisati(rezervacija.KorisnikId, rezervacija.DatumVremePocetka, rezervacija.DatumVremeZavrsetka))
                throw new Exception("Prekoracen broj sati u mesecu");
        
        }

        private StatusRezervacije IzracunajStatus(Rezervacija rezervacija)
        {
            if (rezervacija.Status == StatusRezervacije.Otkazana)
                return StatusRezervacije.Otkazana;

            DateTime sada = DateTime.Now;

            if (rezervacija.DatumVremeZavrsetka < sada)
                return StatusRezervacije.Zavrsena;

            return StatusRezervacije.Aktivna;
        }
    }
}
