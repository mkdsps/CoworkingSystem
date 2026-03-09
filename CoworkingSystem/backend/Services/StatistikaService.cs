using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Statistike;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoworkingSystem.backend.Services
{
    internal class StatistikaService
    {
        private readonly IResursiRepo _resursiRepo;
        private readonly ITipClanstvaRepo _tipClanstvaRepo;
        private readonly IKorisniciRepo _korisniciRepo;
        private readonly IRezervacijeRepo _rezervacijeRepo;
        private readonly ILokacijeRepo _lokacijeRepo;

        public StatistikaService(
            IResursiRepo resursiRepo,
            ITipClanstvaRepo tipClanstvaRepo,
            IKorisniciRepo korisniciRepo,
            IRezervacijeRepo rezervacijeRepo,
            ILokacijeRepo lokacijeRepo)
        {
            _resursiRepo = resursiRepo;
            _tipClanstvaRepo = tipClanstvaRepo;
            _korisniciRepo = korisniciRepo;
            _rezervacijeRepo = rezervacijeRepo;
            _lokacijeRepo = lokacijeRepo;
        }

        public List<RadnoMestoStatistika> GetStatistikaRadnihMesta(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<RadnoMestoStatistika>();

            var radnaMesta = _resursiRepo.GetAll()
                .Where(r => r.TipResursa == "RadnoMesto")
                .ToList();

            var rezervacije = _rezervacijeRepo.GetAll();
            var lokacije = _lokacijeRepo.GetAll();

            double ukupnoSatiPerioda = (periodDo - periodOd).TotalHours;

            foreach (var rm in radnaMesta)
            {
                var rezervacijeResursa = rezervacije
                    .Where(r =>
                        r.ResursId == rm.Id &&
                        r.Status != StatusRezervacije.Otkazana &&
                        DaLiSePreklapa(r.DatumVremePocetka, r.DatumVremeZavrsetka, periodOd, periodDo))
                    .ToList();

                double ukupnoSatiKoriscenja = rezervacijeResursa
                    .Sum(r => IzracunajSatePreklapanja(
                        r.DatumVremePocetka,
                        r.DatumVremeZavrsetka,
                        periodOd,
                        periodDo));

                int ukupanBrojRezervacija = rezervacijeResursa.Count;

                double prosecnoTrajanje = ukupanBrojRezervacija == 0
                    ? 0
                    : ukupnoSatiKoriscenja / ukupanBrojRezervacija;

                double procenatZauzetosti = ukupnoSatiPerioda <= 0
                    ? 0
                    : (ukupnoSatiKoriscenja / ukupnoSatiPerioda) * 100.0;

                int brojRazlicitihKorisnika = rezervacijeResursa
                    .Select(r => r.KorisnikId)
                    .Distinct()
                    .Count();

                var lokacija = lokacije.FirstOrDefault(l => l.Id == rm.LokacijaId);

                rezultat.Add(new RadnoMestoStatistika
                {
                    ResursId = rm.Id,
                    Oznaka = rm.Oznaka,
                    LokacijaId = rm.LokacijaId,
                    NazivLokacije = lokacija?.Naziv ?? "",
                    PodtipStola = rm.PodtipStola ?? "",
                    UkupanBrojRezervacija = ukupanBrojRezervacija,
                    UkupnoSatiKoriscenja = ukupnoSatiKoriscenja,
                    ProsecnoTrajanjeRezervacijeSati = prosecnoTrajanje,
                    ProcenatZauzetosti = procenatZauzetosti,
                    BrojRazlicitihKorisnika = brojRazlicitihKorisnika
                });
            }

            return rezultat;
        }

        public List<SalaStatistika> GetStatistikaSala(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<SalaStatistika>();

            var sale = _resursiRepo.GetAll()
                .Where(r => r.TipResursa == "Sala")
                .ToList();

            var rezervacije = _rezervacijeRepo.GetAll();
            var lokacije = _lokacijeRepo.GetAll();

            double ukupnoSatiPerioda = (periodDo - periodOd).TotalHours;

            foreach (var sala in sale)
            {
                var rezervacijeSale = rezervacije
                    .Where(r =>
                        r.ResursId == sala.Id &&
                        r.Status != StatusRezervacije.Otkazana &&
                        DaLiSePreklapa(r.DatumVremePocetka, r.DatumVremeZavrsetka, periodOd, periodDo))
                    .ToList();

                double ukupnoSatiKoriscenja = rezervacijeSale
                    .Sum(r => IzracunajSatePreklapanja(
                        r.DatumVremePocetka,
                        r.DatumVremeZavrsetka,
                        periodOd,
                        periodDo));

                int ukupanBrojRezervacija = rezervacijeSale.Count;

                double prosecnoTrajanje = ukupanBrojRezervacija == 0
                    ? 0
                    : ukupnoSatiKoriscenja / ukupanBrojRezervacija;

                double procenatZauzetosti = ukupnoSatiPerioda <= 0
                    ? 0
                    : (ukupnoSatiKoriscenja / ukupnoSatiPerioda) * 100.0;

                int ukupanBrojUcesnika = rezervacijeSale.Sum(r => r.BrojUcesnika ?? 0);

                double prosecanBrojUcesnika = ukupanBrojRezervacija == 0
                    ? 0
                    : (double)ukupanBrojUcesnika / ukupanBrojRezervacija;

                int brojRazlicitihKorisnika = rezervacijeSale
                    .Select(r => r.KorisnikId)
                    .Distinct()
                    .Count();

                var lokacija = lokacije.FirstOrDefault(l => l.Id == sala.LokacijaId);

                rezultat.Add(new SalaStatistika
                {
                    ResursId = sala.Id,
                    Oznaka = sala.Oznaka,
                    LokacijaId = sala.LokacijaId,
                    NazivLokacije = lokacija?.Naziv ?? "",
                    Kapacitet = sala.Kapacitet ?? 0,
                    UkupanBrojRezervacija = ukupanBrojRezervacija,
                    UkupnoSatiKoriscenja = ukupnoSatiKoriscenja,
                    ProsecnoTrajanjeRezervacijeSati = prosecnoTrajanje,
                    ProcenatZauzetosti = procenatZauzetosti,
                    UkupanBrojUcesnika = ukupanBrojUcesnika,
                    ProsecanBrojUcesnika = prosecanBrojUcesnika,
                    BrojRazlicitihKorisnika = brojRazlicitihKorisnika
                });
            }

            return rezultat;
        }

        public List<TipClanstvaStatistika> GetStatistikaTipovaClanstva(DateTime periodOd, DateTime periodDo)
        {
            ValidatePeriod(periodOd, periodDo);

            var rezultat = new List<TipClanstvaStatistika>();

            var tipoviClanstva = _tipClanstvaRepo.GetAll();
            var korisnici = _korisniciRepo.GetAll();
            var rezervacije = _rezervacijeRepo.GetAll();
            var resursi = _resursiRepo.GetAll();

            foreach (var tip in tipoviClanstva)
            {
                var korisniciTipa = korisnici
                    .Where(k => k.TipClanstvaId == tip.Id)
                    .ToList();

                var korisnikIds = korisniciTipa
                    .Select(k => k.Id)
                    .ToHashSet();

                var rezervacijeTipa = rezervacije
                    .Where(r =>
                        korisnikIds.Contains(r.KorisnikId) &&
                        r.Status != StatusRezervacije.Otkazana &&
                        DaLiSePreklapa(r.DatumVremePocetka, r.DatumVremeZavrsetka, periodOd, periodDo))
                    .ToList();

                double ukupnoSatiKoriscenja = rezervacijeTipa
                    .Sum(r => IzracunajSatePreklapanja(
                        r.DatumVremePocetka,
                        r.DatumVremeZavrsetka,
                        periodOd,
                        periodDo));

                int brojSvihKorisnika = korisniciTipa.Count;

                int brojAktivnihKorisnika = korisniciTipa
                    .Count(k => k.Status == "Aktivan");

                double prosecnoSatiPoKorisniku = brojSvihKorisnika == 0
                    ? 0
                    : ukupnoSatiKoriscenja / brojSvihKorisnika;

                var rezervacijeSala = rezervacijeTipa
                    .Where(r =>
                    {
                        var resurs = resursi.FirstOrDefault(x => x.Id == r.ResursId);
                        return resurs != null && resurs.TipResursa == "Sala";
                    })
                    .ToList();

                var rezervacijeRadnihMesta = rezervacijeTipa
                    .Where(r =>
                    {
                        var resurs = resursi.FirstOrDefault(x => x.Id == r.ResursId);
                        return resurs != null && resurs.TipResursa == "RadnoMesto";
                    })
                    .ToList();

                double ukupnoSatiSala = rezervacijeSala
                    .Sum(r => IzracunajSatePreklapanja(
                        r.DatumVremePocetka,
                        r.DatumVremeZavrsetka,
                        periodOd,
                        periodDo));

                double ukupnoSatiRadnihMesta = rezervacijeRadnihMesta
                    .Sum(r => IzracunajSatePreklapanja(
                        r.DatumVremePocetka,
                        r.DatumVremeZavrsetka,
                        periodOd,
                        periodDo));

                rezultat.Add(new TipClanstvaStatistika
                {
                    TipClanstvaId = tip.Id,
                    NazivTipaClanstva = tip.Naziv,
                    Cena = tip.Cena,
                    TrajanjeDana = tip.TrajanjeDana,
                    MaksimalnoSatiMesecno = tip.MaksimalnoSatiMesecno,
                    DozvolaSale = tip.DozvolaSale,
                    SaleSatiMesecno = tip.SaleSatiMesecno,
                    BrojAktivnihKorisnika = brojAktivnihKorisnika,
                    BrojSvihKorisnika = brojSvihKorisnika,
                    UkupanBrojRezervacija = rezervacijeTipa.Count,
                    UkupnoSatiKoriscenja = ukupnoSatiKoriscenja,
                    ProsecnoSatiPoKorisniku = prosecnoSatiPoKorisniku,
                    BrojRezervacijaSala = rezervacijeSala.Count,
                    UkupnoSatiSala = ukupnoSatiSala,
                    BrojRezervacijaRadnihMesta = rezervacijeRadnihMesta.Count,
                    UkupnoSatiRadnihMesta = ukupnoSatiRadnihMesta
                });
            }

            return rezultat;
        }

        private void ValidatePeriod(DateTime periodOd, DateTime periodDo)
        {
            if (periodOd >= periodDo)
                throw new Exception("Pocetni datum perioda mora biti manji od krajnjeg datuma.");
        }

        private bool DaLiSePreklapa(DateTime pocetak1, DateTime kraj1, DateTime pocetak2, DateTime kraj2)
        {
            return pocetak1 < kraj2 && kraj1 > pocetak2;
        }

        private double IzracunajSatePreklapanja(DateTime pocetakRez, DateTime krajRez, DateTime periodOd, DateTime periodDo)
        {
            var stvarniPocetak = pocetakRez > periodOd ? pocetakRez : periodOd;
            var stvarniKraj = krajRez < periodDo ? krajRez : periodDo;

            if (stvarniPocetak >= stvarniKraj)
                return 0;

            return (stvarniKraj - stvarniPocetak).TotalHours;
        }
    }
}