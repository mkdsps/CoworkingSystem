using System;
using System.Collections.Generic;
using System.Text;

using CoworkingSystem.backend.Modules;

namespace CoworkingSystem.backend.Repositories
{
    internal interface IResursiRepo
    {
        int Insert(Resurs resurs);

        void Update(Resurs resurs);

        void Delete(int id);

        List<Resurs> GetAll();

        Resurs? GetById(int id);

        List<Resurs> GetByLokacija(int lokacijaId);

        List<Resurs> GetAllRadnaMesta();

        List<Resurs> GetRadnaMestaByLokacija(int lokacijaId);

        List<Resurs> GetAllSale();

        List<Resurs> GetSaleByLokacija(int lokacijaId);

        void SetActive(int id, bool active);

        bool LokacijaImaAktivneResurse(int lokacijaId);
    }
}