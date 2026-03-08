using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem
{
    public partial class Form1
    {
        private KorisnikService? _korisnikService;
        private TipClanstvaService? _tipClanstvaService;
        private LokacijaService? _lokacijaService;
        private RadnoMestoService? _radnoMestoService;
        private SalaService? _salaService;

        private void InicijalizujServise()
        {
            IKorisniciRepo korisniciRepo = new SqlKorisnikRepo();
            ITipClanstvaRepo tipRepo = new SqlTipClanstvaRepo();
            ILokacijeRepo lokacijeRepo = new SqlLokacijaRepo();
            IResursiRepo resursiRepo = new SqlResursiRepo();

            _korisnikService = new KorisnikService(korisniciRepo);
            _tipClanstvaService = new TipClanstvaService(tipRepo);
            _lokacijaService = new LokacijaService(lokacijeRepo);
            _radnoMestoService = new RadnoMestoService(resursiRepo,lokacijeRepo);
            _salaService = new SalaService(resursiRepo,lokacijeRepo);
        }
    }
}
