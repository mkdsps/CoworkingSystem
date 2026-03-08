using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.front
{
    public partial class RadnoMestoForma : Form
    {
        private IUiMediator _mediator;
        private LokacijaService _lokacijaService;

        public RadnoMestoForma()
        {
            InitializeComponent();
        }

        private void RadnoMestoForma_Load(object sender, EventArgs e)
        {
            // Mediator za radna mesta (koristi Resurs repo)
            _mediator = new RadnoMestoMediator(
                new RadnoMestoService(new SqlResursiRepo())
            );

            // Treba nam lista lokacija za ComboBox
            _lokacijaService = new LokacijaService(new SqlLokacijaRepo());

            SetupUi();
            LoadLokacije();
        }

        private void SetupUi()
        {
            chkAktivan.Text = "Aktivno";
            chkAktivan.Checked = true;

            cmbLokacija.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbPodtipStola.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPodtipStola.Items.Clear();
            cmbPodtipStola.Items.Add("FleksibilniSto");
            cmbPodtipStola.Items.Add("FiksniSto");
            cmbPodtipStola.SelectedIndex = 0;

            numBrojRadnihMesta.DecimalPlaces = 0;
            numBrojRadnihMesta.Minimum = 0;
            numBrojRadnihMesta.Maximum = 1000;

            txtOpis.Multiline = true;
            txtOpis.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadLokacije()
        {
            var lokacije = _lokacijaService.GetByActive(true); // samo aktivne
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

                // Broj radnih mesta je optional; 0 tretiramo kao "nije postavljeno"
                int? brojRM = (int)numBrojRadnihMesta.Value;
                if (brojRM == 0) brojRM = null;

                var rm = new Resurs
                {
                    LokacijaId = lokacijaId,
                    Oznaka = txtOznaka.Text.Trim(),
                    PodtipStola = cmbPodtipStola.SelectedItem?.ToString(),
                    BrojRadnihMesta = brojRM,
                    Opis = string.IsNullOrWhiteSpace(txtOpis.Text) ? null : txtOpis.Text.Trim(),
                    Aktivan = chkAktivan.Checked
                };

                var res = _mediator.Send(UiAction.Add, rm);

                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Uspešno dodato radno mesto. Id={res.Data}", "OK",
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
            cmbPodtipStola.SelectedIndex = 0;
            numBrojRadnihMesta.Value = 0;
            txtOpis.Text = "";
            chkAktivan.Checked = true;
        }

        private void cmbPodtipStola_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}