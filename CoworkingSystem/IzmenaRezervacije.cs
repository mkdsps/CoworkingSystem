using CoworkingSystem.backend;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem
{
    public partial class IzmenaRezervacije : Form
    {
        Rezervacija _rezervacija;

        public IzmenaRezervacije(Object r)
        {
            _rezervacija = (Rezervacija)r;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void IzmenaRezervacije_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.Add(_rezervacija.DatumVremePocetka.TimeOfDay);
            dateTimePicker1.Value = DateTime.Today.Add(_rezervacija.DatumVremeZavrsetka.TimeOfDay);

            comboBox1.DataSource = Enum.GetValues(typeof(StatusRezervacije));

            dateTimePicker3.Value = _rezervacija.DatumVremePocetka.Date;
            comboBox1.SelectedItem = _rezervacija.Status;
            textBox1.Text = _rezervacija.Napomena;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime datum = dateTimePicker3.Value.Date;

                DateTime pocetak = datum.Add(dateTimePicker1.Value.TimeOfDay);
                DateTime kraj = datum.Add(dateTimePicker2.Value.TimeOfDay);

                if (kraj <= pocetak)
                {
                    MessageBox.Show("Vreme završetka mora biti posle vremena početka.");
                    return;
                }

                _rezervacija.DatumVremePocetka = pocetak;
                _rezervacija.DatumVremeZavrsetka = kraj;
                _rezervacija.Status = (StatusRezervacije)comboBox1.SelectedItem;
                _rezervacija.Napomena = textBox1.Text;

                RezervacijeService rs = new RezervacijeService(new SqlRepoFactory());
                rs.IzmeniRezervaciju(_rezervacija);

                MessageBox.Show("Rezervacija je uspešno ažurirana.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
