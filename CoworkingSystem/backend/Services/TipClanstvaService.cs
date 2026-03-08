using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;

namespace CoworkingSystem.backend.Services
{
    internal class TipClanstvaService
    {
        private readonly ITipClanstvaRepo _tipRepo;

        public TipClanstvaService(ITipClanstvaRepo tipRepo)
        {
            _tipRepo = tipRepo;
        }

        // CREATE
        public int AddTipClanstva(TipClanstva tp)
        {
            ValidateTipClanstva(tp);
            return _tipRepo.Insert(tp);
        }

        // READ
        public List<TipClanstva> GetAll() => _tipRepo.GetAll();

        // Jedinstveni nazivi tipova clanstva (za dropdown, filter, itd.)
        public List<string> DistinctNames() => _tipRepo.DistinctNames();

        // VALIDACIJA
        private static void ValidateTipClanstva(TipClanstva tp)
        {
            if (tp == null) throw new ArgumentNullException(nameof(tp));

            // Naziv obavezan
            if (string.IsNullOrWhiteSpace(tp.Naziv))
                throw new Exception("Naziv tipa članstva je obavezan.");

            // Cena: obično >= 0 (ako ne želiš 0, promeni na <= 0)
            if (tp.Cena < 0)
                throw new Exception("Cena ne može biti negativna.");

            // Trajanje mora biti > 0
            if (tp.TrajanjeDana <= 0)
                throw new Exception("Trajanje (broj dana) mora biti veće od 0.");

            // Maks sati mesečno ne sme biti negativno
            if (tp.MaksimalnoSatiMesecno < 0)
                throw new Exception("Maksimalno sati mesečno ne može biti negativno.");

            // Sala - logika
            // Ako DozvolaSale == false -> SaleSatiMesecno treba da bude NULL ili 0
            if (!tp.DozvolaSale)
            {
                if (tp.SaleSatiMesecno.HasValue && tp.SaleSatiMesecno.Value > 0)
                    throw new Exception("Ako sala nije dozvoljena, SaleSatiMesecno mora biti NULL ili 0.");
            }
            else
            {
                // Ako je sala dozvoljena, sati ne smeju biti negativni
                if (tp.SaleSatiMesecno.HasValue && tp.SaleSatiMesecno.Value < 0)
                    throw new Exception("SaleSatiMesecno ne može biti negativno.");
            }

            // Opis: ako nije null, ne sme biti samo whitespace
            if (tp.Opis != null && string.IsNullOrWhiteSpace(tp.Opis))
                throw new Exception("Opis ne može biti prazan string (ili stavi NULL).");

            // Aktivan je bool -> nema validacije
            // DatumKreiranja obično puni baza -> nema validacije ovde
        }

    }
}