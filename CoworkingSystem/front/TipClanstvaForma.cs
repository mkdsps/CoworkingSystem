using CoworkingSystem.backend.Mediator;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;
using System;
using System.Windows.Forms;

namespace CoworkingSystem.front
{
    public partial class TipClanstvaForma : Form
    {
        private IUiMediator _mediator;

        public TipClanstvaForma()
        {
            InitializeComponent();
        }

        private void TipClanstvaForma_Load(object sender, EventArgs e)
        {
            // Repo -> Service -> Mediator
            _mediator = new TipClanstvaMediator(
                new TipClanstvaService(new SqlTipClanstvaRepo())
            );

            SetupUi();
        }

        private void SetupUi()
        {
            // lep tekst checkbox-a
            checkBox1.Text = "Dozvoljena sala za sastanke";

            // Cena (numericUpDown4) ima 2 decimale (već ima u designeru, ali ostavljamo)
            numericUpDown4.DecimalPlaces = 2;

            // Ostale numeric kontrole su celobrojne
            numericUpDown3.DecimalPlaces = 0; // Trajanje dana
            numericUpDown2.DecimalPlaces = 0; // Maks sati mesečno
            numericUpDown1.DecimalPlaces = 0; // Sati sale mesečno

            // Trajanje dana minimum 1 (već ima u designeru)
            if (numericUpDown3.Minimum < 1)
                numericUpDown3.Minimum = 1;

            // enable/disable sati sale
            numericUpDown1.Enabled = checkBox1.Checked;

            checkBox1.CheckedChanged += (s, e) =>
            {
                numericUpDown1.Enabled = checkBox1.Checked;
                if (!checkBox1.Checked)
                    numericUpDown1.Value = 0;
            };
        }

        // DUGME "Dodaj" (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var tp = new TipClanstva
                {
                    Naziv = txtNaziv.Text.Trim(),
                    Cena = numericUpDown4.Value,
                    TrajanjeDana = (int)numericUpDown3.Value,
                    MaksimalnoSatiMesecno = (int)numericUpDown2.Value,
                    DozvolaSale = checkBox1.Checked,
                    SaleSatiMesecno = checkBox1.Checked ? (int?)(int)numericUpDown1.Value : null,
                    Opis = string.IsNullOrWhiteSpace(txtOpis.Text) ? null : txtOpis.Text.Trim(),
                    Aktivan = true
                };

                var res = _mediator.Send(UiAction.Add, tp);

                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Uspešno dodat tip članstva. Id={res.Data}", "OK",
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
            txtOpis.Text = "";

            numericUpDown4.Value = 0;  // Cena
            numericUpDown3.Value = 1;  // Trajanje
            numericUpDown2.Value = 0;  // Maks sati
            checkBox1.Checked = false;
            numericUpDown1.Value = 0;  // Sati sale
        }

        // ove eventove možeš ostaviti prazne (designer ih je napravio)
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}