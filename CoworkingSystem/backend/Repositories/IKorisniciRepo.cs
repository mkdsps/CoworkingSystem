using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;
using System.Text;
using static CoworkingSystem.backend.Modules.KorisnikFilter;

namespace CoworkingSystem.backend.Repositories
{
    interface IKorisniciRepo
    {
        public int Insert(Korisnik k);
        public void Update(Korisnik k);
        public void Delete(int id);

        public List<Korisnik> GetAll();
        public List<Korisnik> Get(KorisnikFilter filter);

        public Korisnik GetByID(int id);

        public List<Korisnik> GetKorisniciSaRezervacijamaNaLokaciji(int lokacijaId);

    }
}
