using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;

namespace CoworkingSystem.backend.Services
{
    internal class StatistikaService
    {
        private readonly IResursiRepo _resursiRepo;
        private readonly ITipClanstvaRepo _tipClanstvaRepo;

        public StatistikaService(IResursiRepo resursiRepo, ITipClanstvaRepo tipClanstvaRepo)
        {
            _resursiRepo = resursiRepo;
            _tipClanstvaRepo = tipClanstvaRepo;
        }

        public List<RadnoMestoStatistika> GetStatistikaRadnihMesta(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<RadnoMestoStatistika>();


            return rezultat;
        }

        public List<SalaStatistika> GetStatistikaSala(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<SalaStatistika>();

            return rezultat;
        }

        public List<TipClanstvaStatistika> GetStatistikaTipovaClanstva(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<TipClanstvaStatistika>();

            return rezultat;
        }

        private void ValidatePeriod(DateTime periodOd, DateTime periodDo)
        {
            if (periodOd >= periodDo)
                throw new Exception("Pocetni datum perioda mora biti manji od krajnjeg datuma.");
        }
    }
}