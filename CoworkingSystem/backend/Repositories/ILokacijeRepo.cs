using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    interface ILokacijeRepo
    {
        List<Lokacija> GetAll();
        List<Lokacija> GetByActive(bool active);
        List<LokacijaStatistika> GetAllStats(bool? onlyActiveLocations = null);
        Lokacija? GetById(int id);

        int Insert(Lokacija lokacija);
        void Update(Lokacija lokacija);
        void Delete(int id);

        void SetActive(int id, bool active);
    }
}
