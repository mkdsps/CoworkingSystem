using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    interface IRezervacijeRepo
    {
        public int Insert(Rezervacija r);
        public void Update(Rezervacija r);
        public void Delete(int id);

        public List<Rezervacija> GetAll();
        public List<Rezervacija> Get(RezervacijaFilter filter);

        public Rezervacija GetByID(int id);

        public bool IsResursDostupan(int resursId, DateTime pocetak, DateTime kraj);

        public bool DaLiKorisnikMozeRezervisati(int korisnikId, DateTime pocetak, DateTime kraj);

        public bool DaLiJeURadnomVremenuLokacije(int lokacijaId, DateTime pocetak, DateTime kraj);

        public int GetLokacijaIdByResursId(int resursId);
    }
}
