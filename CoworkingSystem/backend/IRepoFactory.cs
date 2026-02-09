using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal interface IRepoFactory
    {
        public IKorisniciRepo CreateKorisniciRepo();
        public IRezervacijeRepo rezervacijeRepo();
        // dodaj za svaki tip repo-a
    }
}
