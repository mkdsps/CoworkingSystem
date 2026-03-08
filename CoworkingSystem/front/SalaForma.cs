using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.front
{
    public partial class SalaForma : Form
    {
        private IUiMediator _mediator;
        private LokacijaService _lokacijaService;

        public SalaForma()
        {
            InitializeComponent();
        }

        private void SalaForma_Load(object sender, EventArgs e)
        {
            // Mediator za sale (koristi Resurs repo)
            _mediator = new SalaMediator(
                new SalaService(new SqlResursiRepo())
            );

            // Lokacije za ComboBox
            _lokacijaService = new LokacijaService(new SqlLokacijaRepo());

            SetupUi();
            LoadLokacije();
        }

        private void SetupUi()
        {
            chkAktivan.Text = "Aktivno";
            chkAktivan.Checked = true;

            cmbLokacija.DropDownStyle = ComboBoxStyle.DropDownList;

            // Kapacitet obavezan i > 0
            numKapacitet.DecimalPlaces = 0;
            numKapacitet.Minimum = 1;
            numKapacitet.Maximum = 10000;

            // Povrsina opciono: 0 -> null
            numPovrsina.DecimalPlaces = 2;
            numPovrsina.Minimum = 0;
            numPovrsina.Maximum = 100000;

            txtOpis.Multiline = true;
            txtOpis.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadLokacije()
        {
            var lokacije = _lokacijaService.GetByActive(true);
            cmbLokacija.DataSource = lokacije;
            cmbLokacija.DisplayMember = "Naziv";
            cmbLokacija.ValueMember = "Id";
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLokacija.SelectedValue == null)
                    throw new Exception("Lokacija je obavezna.");

                int lokacijaId = Convert.ToInt32(cmbLokacija.SelectedValue);

                decimal povVal = numPovrsina.Value;
                decimal? povrsina = povVal == 0 ? (decimal?)null : povVal;

                var sala = new Resurs
                {
                    LokacijaId = lokacijaId,
                    Oznaka = txtOznaka.Text.Trim(),
                    Kapacitet = (int)numKapacitet.Value,
                    Povrsina = povrsina,

                    ImaProjektor = chkProjektor.Checked,
                    ImaTV = chkTV.Checked,
                    ImaTablu = chkTabla.Checked,
                    ImaOnlineOpremu = chkOnline.Checked,

                    Opis = string.IsNullOrWhiteSpace(txtOpis.Text) ? null : txtOpis.Text.Trim(),
                    Aktivan = chkAktivan.Checked
                };

                var res = _mediator.Send(UiAction.Add, sala);

                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Uspešno dodata sala. Id={res.Data}", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtOznaka.Text = "";
            numKapacitet.Value = 1;
            numPovrsina.Value = 0;
            chkProjektor.Checked = false;
            chkTV.Checked = false;
            chkTabla.Checked = false;
            chkOnline.Checked = false;
            txtOpis.Text = "";
            chkAktivan.Checked = true;
        }
    }
}