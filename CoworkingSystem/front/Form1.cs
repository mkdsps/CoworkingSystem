using CoworkingSystem.backend;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;

namespace CoworkingSystem
{
    public partial class Form1 : Form
    {
        private KorisnikService? _korisnikService;
        private TipClanstvaService? _tipClanstvaService;
        private LokacijaService? _lokacijaService;
        private RadnoMestoService? _radnoMestoService;
        private SalaService? _salaService;

        private List<Korisnik> _sviKorisnici = new List<Korisnik>();
        private List<TipClanstva> _sviTipoviClanstva = new List<TipClanstva>();
        private List<Lokacija> _sveLokacije = new List<Lokacija>();
        private List<Resurs> _svaRadnaMesta = new List<Resurs>();
        private List<Resurs> _sveSale = new List<Resurs>();
        private List<Resurs> _resursiZaSelektovanuLokaciju = new List<Resurs>();

        private BindingSource _korisniciBindingSource = new BindingSource();
        private BindingSource _lokacijeBindingSource = new BindingSource();
        private BindingSource _resursiBindingSource = new BindingSource();

        private Korisnik? _selektovaniKorisnik;
        private Lokacija? _selektovanaLokacija;
        private Resurs? _selektovaniResurs;
        public Form1()
        {
            InitializeComponent();
        }

        private void InicijalizujServise()
        {
            IKorisniciRepo korisniciRepo = new SqlKorisnikRepo();
            ITipClanstvaRepo tipRepo = new SqlTipClanstvaRepo();
            ILokacijeRepo lokacijeRepo = new SqlLokacijaRepo();
            IResursiRepo resursiRepo = new SqlResursiRepo();

            _korisnikService = new KorisnikService(korisniciRepo);
            _tipClanstvaService = new TipClanstvaService(tipRepo);
            _lokacijaService = new LokacijaService(lokacijeRepo);
            _radnoMestoService = new RadnoMestoService(resursiRepo);
            _salaService = new SalaService(resursiRepo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";

            InicijalizujServise();

            InicijalizujGrid();
            InicijalizujGridLokacije();
            InicijalizujGridResursa();

            UcitajTipoveClanstva();
            PopuniStatuse();
            PopuniTipoveResursa();

            UcitajKorisnike();
            UcitajLokacije();


        }

        private void InicijalizujGrid()
        {
            dgvKorisnici.AutoGenerateColumns = true;

            dgvKorisnici.DataSource = _korisniciBindingSource;

            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvKorisnici.MultiSelect = false;

            dgvKorisnici.ReadOnly = true;
        }

        private void InicijalizujGridLokacije()
        {
            dgvLokacije.AutoGenerateColumns = true;
            dgvLokacije.DataSource = _lokacijeBindingSource;
            dgvLokacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLokacije.MultiSelect = false;
            dgvLokacije.ReadOnly = true;
            dgvLokacije.AllowUserToAddRows = false;
            dgvLokacije.AllowUserToDeleteRows = false;
            dgvLokacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void InicijalizujGridResursa()
        {
            dgvResursi.AutoGenerateColumns = true;
            dgvResursi.DataSource = _resursiBindingSource;
            dgvResursi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResursi.MultiSelect = false;
            dgvResursi.ReadOnly = true;
            dgvResursi.AllowUserToAddRows = false;
            dgvResursi.AllowUserToDeleteRows = false;
            dgvResursi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void PopuniTipoveResursa()
        {
            cmbTipResursa.Items.Clear();

            cmbTipResursa.Items.Add("Svi");
            cmbTipResursa.Items.Add("RadnoMesto");
            cmbTipResursa.Items.Add("Sala");

            cmbTipResursa.SelectedIndex = 0;
        }

        private void UcitajResurseZaLokaciju(int lokacijaId)
        {
            _svaRadnaMesta = _radnoMestoService!.GetRadnaMestaByLokacija(lokacijaId);
            _sveSale = _salaService!.GetSaleByLokacija(lokacijaId);

            _resursiZaSelektovanuLokaciju = _svaRadnaMesta
                .Concat(_sveSale)
                .ToList();

            FiltrirajResurse();
        }

        private void FiltrirajResurse()
        {
            IEnumerable<Resurs> rezultat = _resursiZaSelektovanuLokaciju;

            if (cmbTipResursa.SelectedItem is string tip && tip != "Svi")
            {
                rezultat = rezultat.Where(r => r.TipResursa == tip);
            }

            _resursiBindingSource.DataSource = rezultat.ToList();

            SakrijKoloneResursa();

            OcistiSelekcijuGrida(dgvResursi);
            _selektovaniResurs = null;
        }

        private void SakrijKoloneResursa()
        {
            var idKolona = dgvResursi.Columns["Id"];
            if (idKolona != null)
                idKolona.Visible = false;

            var lokacijaKolona = dgvResursi.Columns["LokacijaId"];
            if (lokacijaKolona != null)
                lokacijaKolona.Visible = false;

            var datumKolona = dgvResursi.Columns["DatumKreiranja"];
            if (datumKolona != null)
                datumKolona.Visible = false;
        }

        private void SacuvajSelektovaniResurs()
        {
            if (dgvResursi.CurrentRow == null)
            {
                _selektovaniResurs = null;
                return;
            }

            _selektovaniResurs =
                dgvResursi.CurrentRow.DataBoundItem as Resurs;
        }


        private void UcitajLokacije()
        {
            _sveLokacije = _lokacijaService!.GetAll();

            _lokacijeBindingSource.DataSource = _sveLokacije;

            SakrijKoloneLokacija();

            OcistiSelekcijuGrida(dgvLokacije);
            _selektovanaLokacija = null;
        }

        private void SakrijKoloneLokacija()
        {
            var idKolona = dgvLokacije.Columns["Id"];
            if (idKolona != null)
                idKolona.Visible = false;

            var datumKolona = dgvLokacije.Columns["DatumKreiranja"];
            if (datumKolona != null)
                datumKolona.Visible = false;
        }

        private void SacuvajSelektovanuLokaciju()
        {
            if (dgvLokacije.CurrentRow == null)
            {
                _selektovanaLokacija = null;
                return;
            }

            _selektovanaLokacija =
                dgvLokacije.CurrentRow.DataBoundItem as Lokacija;
        }

        private void UcitajKorisnike()
        {
            _sviKorisnici = _korisnikService!.GetAll();

            _korisniciBindingSource.DataSource = _sviKorisnici;

            SakrijKolone();

            OcistiSelekcijuGrida(dgvKorisnici);
            _selektovaniKorisnik = null;
        }

        private void SakrijKolone()
        {
            var idKolona = dgvKorisnici.Columns["Id"];
            if (idKolona != null)
                idKolona.Visible = false;

            var passKolona = dgvKorisnici.Columns["PasswordHash"];
            if (passKolona != null)
                passKolona.Visible = false;

            var lokacijaKolona = dgvKorisnici.Columns["LokacijaId"];
            if (lokacijaKolona != null)
                lokacijaKolona.Visible = false;
        }

        private void UcitajTipoveClanstva()
        {
            _sviTipoviClanstva = _tipClanstvaService!.GetAll();

            cmbTipClanstva.Items.Clear();

            cmbTipClanstva.Items.Add("Svi");

            foreach (var tip in _sviTipoviClanstva)
            {
                cmbTipClanstva.Items.Add(tip.Naziv);
            }

            cmbTipClanstva.SelectedIndex = 0;
        }

        private void PopuniStatuse()
        {
            cmbStatusNaloga.Items.Clear();

            cmbStatusNaloga.Items.Add("Svi");
            cmbStatusNaloga.Items.Add("Aktivan");
            cmbStatusNaloga.Items.Add("Pauziran");
            cmbStatusNaloga.Items.Add("Istekao");


            cmbStatusNaloga.SelectedIndex = 0;
        }

        private void FiltrirajKorisnike()
        {
            IEnumerable<Korisnik> rezultat = _sviKorisnici;

            string pretraga = txtPretragaKorisnika.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(pretraga))
            {
                rezultat = rezultat.Where(k =>
                    k.Ime.ToLower().Contains(pretraga) ||
                    k.Prezime.ToLower().Contains(pretraga));
            }

            if (cmbStatusNaloga.SelectedItem != null &&
                cmbStatusNaloga.SelectedItem.ToString() != "Svi")
            {
                string status = cmbStatusNaloga.SelectedItem.ToString()!;

                rezultat = rezultat.Where(k => k.Status == status);
            }

            if (cmbTipClanstva.SelectedItem != null &&
                cmbTipClanstva.SelectedItem.ToString() != "Svi")
            {
                string nazivTipa = cmbTipClanstva.SelectedItem.ToString()!;

                var tip = _sviTipoviClanstva
                    .FirstOrDefault(t => t.Naziv == nazivTipa);

                if (tip != null)
                {
                    rezultat = rezultat.Where(k => k.TipClanstvaId == tip.Id);
                }
            }

            _korisniciBindingSource.DataSource = rezultat.ToList();
        }

        public void OsveziKorisnike()
        {
            UcitajKorisnike();
            FiltrirajKorisnike();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtPretragaKorisnika_TextChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void cmbTipClanstva_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void cmbStatusNaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void SacuvajSelektovanogKorisnika()
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                _selektovaniKorisnik = null;
                return;
            }

            _selektovaniKorisnik =
                dgvKorisnici.CurrentRow.DataBoundItem as Korisnik;

        }

        private void dgvKorisnici_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovanogKorisnika();
        }

        private void dgvLokacije_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovanuLokaciju();

            if (_selektovanaLokacija != null)
            {
                UcitajResurseZaLokaciju(_selektovanaLokacija.Id);
            }
            else
            {
                _resursiZaSelektovanuLokaciju.Clear();
                _resursiBindingSource.DataSource = null;
            }
        }

        public void OsveziLokacije()
        {
            UcitajLokacije();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvResursi_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovaniResurs();
        }

        private void cmbTipResursa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajResurse();
        }

        public void OsveziResurse()
        {
            if (_selektovanaLokacija == null)
            {
                _resursiBindingSource.DataSource = null;
                return;
            }

            UcitajResurseZaLokaciju(_selektovanaLokacija.Id);
        }

        private void OcistiSelekcijuGrida(DataGridView dgv)
        {
            dgv.CurrentCell = null;
            dgv.ClearSelection();
        }
    }
}
