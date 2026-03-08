using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.front
{
    public partial class LokacijaForma : Form
    {
        private IUiMediator _mediator;

        public LokacijaForma()
        {
            InitializeComponent();
        }

        private void LokacijaForma_Load(object sender, EventArgs e)
        {
            _mediator = new LokacijaMediator(
                new LokacijaService(new SqlLokacijaRepo())
            );

            SetupUi();
        }

        private void SetupUi()
        {
            // checkbox1 koristimo kao "Aktivna"
            chkAktivna.Text = "Aktivna lokacija";
            chkAktivna.Checked = true;

            // max korisnika (int)
            numMaxKorisnika.DecimalPlaces = 0;
            numMaxKorisnika.Minimum = 1;
            numMaxKorisnika.Maximum = 100000;

            // Opis multiline (ako nije u designeru)
            txtOpis.Multiline = true;
            txtOpis.ScrollBars = ScrollBars.Vertical;

            // Hint za radno vreme (nije placeholder, ali bar default)
            // txtRadnoVreme.Text = "08:00-20:00"; // opcionalno
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var lok = new Lokacija
                {
                    Naziv = txtNaziv.Text.Trim(),
                    Adresa = txtAdresa.Text.Trim(),
                    Grad = txtGrad.Text.Trim(),
                    RadnoVreme = txtRadnoVreme.Text.Trim(),
                    MaksimalanBrojKorisnika = (int)numMaxKorisnika.Value,
                    Opis = string.IsNullOrWhiteSpace(txtOpis.Text) ? null : txtOpis.Text.Trim(),
                    Aktivna = chkAktivna.Checked
                };

                var res = _mediator.Send(UiAction.Add, lok);

                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Uspešno dodata lokacija. Id={res.Data}", "OK",
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
            txtNaziv.Text = "";
            txtAdresa.Text = "";
            txtGrad.Text = "";
            txtRadnoVreme.Text = "";
            numMaxKorisnika.Value = 1;
            txtOpis.Text = "";
            chkAktivna.Checked = true;
        }

        // prazni eventovi ako ih designer ima
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e) { }
    }
}