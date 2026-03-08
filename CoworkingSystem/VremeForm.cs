using CoworkingSystem.backend;
using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem
{
    public partial class VremeForm : Form
    {
        RezervacijeService _rs = new RezervacijeService(new SqlRepoFactory());
        DateTime _dobijeni_date;
        int _id_korisnika, _id_resursa;

        public VremeForm(DateTime dobijeni_date, int id_korisnika, int id_resursa)
        {
            this._dobijeni_date = dobijeni_date;
            this._id_korisnika = id_korisnika;
            this._id_resursa = id_resursa;

            InitializeComponent();
        }


        private void VremeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime pocetak = _dobijeni_date.Date.Add(od_TimePicker.Value.TimeOfDay);
                DateTime kraj = _dobijeni_date.Date.Add(do_TimePicker.Value.TimeOfDay);

                if (kraj <= pocetak)
                {
                    MessageBox.Show("Vreme završetka mora biti posle vremena početka.");
                    return;
                }

                Rezervacija r = new Rezervacija
                {
                    Status = StatusRezervacije.Aktivna,
                    KorisnikId = _id_korisnika,
                    ResursId = _id_resursa,
                    Napomena = textBox1.Text,
                    DatumVremePocetka = pocetak,
                    DatumVremeZavrsetka = kraj
                };

                _rs.dodajRezervaciju(r);

                MessageBox.Show("Rezervacija je uspešno dodata.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void od_TimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
