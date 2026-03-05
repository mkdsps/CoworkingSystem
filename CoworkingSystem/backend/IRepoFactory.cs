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
        public IRezervacijeRepo rezervacijeRepo();
        public ILokacijeRepo CreateLokacijeRepo();
    }
}
