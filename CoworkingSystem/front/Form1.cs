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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
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
        private void button2_Click(object sender, EventArgs e)
        {
            // Dodaj Korisnika
            using (var f = new CoworkingSystem.front.KorisnikForma())
            {
                f.ShowDialog();
            }

            // posle zatvaranja forme, osveži grid
            LoadKorisniciGrid();
        }

        private void LoadKorisniciGrid()
        {
            try
            {
                var service = new KorisnikService(new SqlKorisnikRepo());
                var list = service.GetAll();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;

                // opciono: malo lepši prikaz
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška pri učitavanju korisnika",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Dodaj Lokaciju
            using var f = new CoworkingSystem.front.LokacijaForma();
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
            using var f = new CoworkingSystem.front.SalaForma();
            f.ShowDialog();
            //MessageBox.Show("Klik radi!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dodaj Radno Mesto
            using var f = new CoworkingSystem.front.RadnoMestoForma();
            f.ShowDialog();
        }
    }
}
