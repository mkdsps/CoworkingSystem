using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    class SqlRepoFactory : IRepoFactory
    {
        public IKorisniciRepo CreateKorisniciRepo()
        {
            throw new NotImplementedException();
        }

        public IRezervacijeRepo rezervacijeRepo()
        {
            throw new NotImplementedException();
        }
    }
}
