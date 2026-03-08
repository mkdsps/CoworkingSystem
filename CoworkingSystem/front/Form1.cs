using CoworkingSystem.backend;
using CoworkingSystem.backend.Modules;
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

            InicijalizujServise();

            InicijalizujGridKorisnici();
            InicijalizujGridLokacije();
            InicijalizujGridResursi();

            UcitajTipoveClanstva();
            PopuniStatuse();
            PopuniTipoveResursa();

            UcitajKorisnike();
            UcitajLokacije();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void OcistiSelekcijuGrida(DataGridView dgv)
        {
            dgv.CurrentCell = null;
            dgv.ClearSelection();
        }
    }
}
