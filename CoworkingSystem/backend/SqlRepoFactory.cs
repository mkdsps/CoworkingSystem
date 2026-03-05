
using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    class SqlRepoFactory : IRepoFactory
    {
        public IAdminRepo createAdminRepo()
        {
            return new SqlAdminRepo();
        }

        public IKorisniciRepo CreateKorisniciRepo()
        {
            throw new NotImplementedException();
        }

        public ILokacijeRepo CreateLokacijeRepo()
        {
            return new SqlLokacijaRepo();
        }

        public IRezervacijeRepo rezervacijeRepo()
        {
            throw new NotImplementedException();
        }

    }
}
