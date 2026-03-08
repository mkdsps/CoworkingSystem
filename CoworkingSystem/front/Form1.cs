using CoworkingSystem.backend;
using CoworkingSystem.backend.Repositories;
using CoworkingSystem.backend.Services;

namespace CoworkingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config cnf = Config.getInstance();
            label1.Text = cnf.name;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";

            InicijalizujServise();

            InicijalizujGridKorisnici();
            InicijalizujGridLokacije();
            InicijalizujGridResursi();

            InicijalizujGridRezervacije();

            UcitajTipoveClanstva();
            PopuniStatuse();
            PopuniTipoveResursa();

            UcitajKorisnike();
            UcitajLokacije();
            PopuniLokacijeZaFilterKorisnika();
            UcitajRezervacije();
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Dodaj Korisnika
            using (var f = new CoworkingSystem.front.KorisnikForma(this))
            {
                f.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Dodaj Lokaciju
            using var f = new CoworkingSystem.front.LokacijaForma(this);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Dodaj Tip Članstva
            using var f = new CoworkingSystem.front.TipClanstvaForma();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Dodaj Salu
            using var f = new CoworkingSystem.front.SalaForma(this);
            f.ShowDialog();
            //MessageBox.Show("Klik radi!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dodaj Radno Mesto
            using var f = new CoworkingSystem.front.RadnoMestoForma(this);
            f.ShowDialog();
        }


        private void OcistiSelekcijuGrida(DataGridView dgv)
        {
            dgv.CurrentCell = null;
            dgv.ClearSelection();
        }

        private void chkDatum_CheckedChanged(object sender, EventArgs e)
        {
            OsveziRezervacije();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            OsveziRezervacije();
        }

        private void dgvRezervacije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SacuvajSelektovanuRezervaciju();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
