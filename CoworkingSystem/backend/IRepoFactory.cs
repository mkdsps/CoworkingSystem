using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal interface IRepoFactory
    {
        // dodaj za svaki tip repo-a
        public IKorisniciRepo CreateKorisniciRepo();
        public ILokacijeRepo CreateLokacijeRepo();
        public IAdminRepo createAdminRepo();
        public IRezervacijeRepo createRezervacijeRepo();
        public IResursiRepo CreateResursiRepo();
        public ITipClanstvaRepo CreateTipClanstvaRepo();
    }
}
