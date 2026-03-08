using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using CoworkingSystem.front;
namespace CoworkingSystem.front
{
    public partial class KorisnikForma : Form
    {
        private IUiMediator _mediator;
        private LokacijaService _lokacijaService;
        private TipClanstvaService _tipClanstvaService;
        private Form1 _form1;

        public KorisnikForma(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void KorisnikForma_Load(object sender, EventArgs e)
        {
            // Repo -> Service -> Mediator
            _mediator = new KorisnikMediator(
                new KorisnikService(new SqlKorisnikRepo())
            );

            _lokacijaService = new LokacijaService(new SqlLokacijaRepo());
            _tipClanstvaService = new TipClanstvaService(new SqlTipClanstvaRepo());

            SetupUi();
            LoadLokacije();
            LoadTipoveClanstva();
        }

        private void SetupUi()
        {
            // status
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Aktivan");
            cmbStatus.Items.Add("Pauziran");
            cmbStatus.Items.Add("Istekao");
            cmbStatus.SelectedIndex = 0;

            // datumi
            dtpDatumPocetka.Format = DateTimePickerFormat.Custom;
            dtpDatumPocetka.CustomFormat = "dd.MM.yyyy";

            dtpDatumIsteka.Format = DateTimePickerFormat.Custom;
            dtpDatumIsteka.CustomFormat = "dd.MM.yyyy";

            // default: datum isteka +30 dana
            dtpDatumPocetka.Value = DateTime.Now.Date;
            dtpDatumIsteka.Value = DateTime.Now.Date.AddDays(30);

            // dropdowns
            cmbLokacija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipClanstva.DropDownStyle = ComboBoxStyle.DropDownList;

            // opis multiline
            txtNapomena.Multiline = true;
            txtNapomena.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadLokacije()
        {
            var lokacije = _lokacijaService.GetByActive(true);
            cmbLokacija.DataSource = lokacije;
            cmbLokacija.DisplayMember = "Naziv";
            cmbLokacija.ValueMember = "Id";
        }

        private void LoadTipoveClanstva()
        {
            var tipovi = _tipClanstvaService.GetAll(); // List<TipClanstva>
            cmbTipClanstva.DataSource = tipovi;
            cmbTipClanstva.DisplayMember = "Naziv";
            cmbTipClanstva.ValueMember = "Id";
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLokacija.SelectedValue == null)
                    throw new Exception("Lokacija je obavezna.");

                if (cmbTipClanstva.SelectedValue == null)
                    throw new Exception("Tip članstva je obavezan.");

                int lokacijaId = Convert.ToInt32(cmbLokacija.SelectedValue);
                int tipClanstvaId = Convert.ToInt32(cmbTipClanstva.SelectedValue);

                var k = new Korisnik
                {
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefon = txtTelefon.Text.Trim(),

                    TipClanstvaId = tipClanstvaId,

                    DatumPocetka = dtpDatumPocetka.Value.Date,
                    DatumIsteka = dtpDatumIsteka.Value.Date,

                    Status = cmbStatus.SelectedItem?.ToString() ?? "Aktivan",
                    Napomena = string.IsNullOrWhiteSpace(txtNapomena.Text) ? null : txtNapomena.Text.Trim()
                };

                var res = _mediator.Send(UiAction.Add, k);

                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Uspešno dodat korisnik. Id={res.Data}", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _form1.OsveziKorisnike();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtNapomena.Text = "";

            cmbStatus.SelectedIndex = 0;
            dtpDatumPocetka.Value = DateTime.Now.Date;
            dtpDatumIsteka.Value = DateTime.Now.Date.AddDays(30);
        }
    }
}