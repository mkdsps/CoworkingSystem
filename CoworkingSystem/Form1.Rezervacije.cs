using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CoworkingSystem
{
    public partial class Form1
    {
        List<Rezervacija> _sve_rezervacije;
        Rezervacija? _selektovanaRezervacija;

        private BindingSource _rezervacijeBindingSource = new BindingSource();

        private void InicijalizujGridRezervacije()
        {
            dgvRezervacije.AutoGenerateColumns = true;
            dgvRezervacije.DataSource = _rezervacijeBindingSource;
            dgvRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRezervacije.MultiSelect = false;
            dgvRezervacije.ReadOnly = true;
            dgvRezervacije.AllowUserToAddRows = false;
            dgvRezervacije.AllowUserToDeleteRows = false;
        }

        private void UcitajRezervacije()
        {
            OsveziRezervacije();
            SakrijKoloneRezervacije();
        }

        private void SakrijKoloneRezervacije()
        {
            var idKolona = dgvRezervacije.Columns["id"];
            if (idKolona != null)
                idKolona.Visible = false;


            var broj_korisnika = dgvRezervacije.Columns["BrojUcesnika"];
            if (broj_korisnika != null)
                broj_korisnika.Visible = false;

            //var napomenaKolona = dgvRezervacije.Columns["Napomena"];
            //if (napomenaKolona != null)
            //    napomenaKolona.Visible = false;

            //var dkKolona = dgvRezervacije.Columns["DatumKreiranja"];
            //if (dkKolona != null)
            //    dkKolona.Visible = false;

            //var dzKolona = dgvRezervacije.Columns["DatumIzmene"];
            //if (dzKolona != null)
            //    dzKolona.Visible = false;

        }

        private void OsveziRezervacije()
        {
            List<Rezervacija>? poKorisniku = null;
            List<Rezervacija>? poDanuILokaciji = null;

            bool imaKorisnik = _selektovaniKorisnik != null;
            bool imaLokacija = chkDatum.Checked == true;

            if (imaKorisnik)
            {
                int? korisnikId = _selektovaniKorisnik.Id;
                poKorisniku = _rezervacijeService.VratiRezervacijeZaKorisnika(korisnikId);
            }

            if (imaLokacija)
            {
                int? lokacijaId =  _selektovanaLokacija  != null ? _selektovanaLokacija.Id : null;
                DateTime dan = dateTimePicker1.Value.Date;
                poDanuILokaciji = _rezervacijeService.VratiRezervacijeZaDanILokaciju(lokacijaId, dan);
            }

            List<Rezervacija> rezultat;

            if (poKorisniku != null && poDanuILokaciji != null)
            {
                rezultat = poKorisniku
                    .Where(r1 => poDanuILokaciji.Any(r2 => r2.Id == r1.Id))
                    .ToList();
            }
            else if (poKorisniku != null)
            {
                rezultat = poKorisniku;
            }
            else if (poDanuILokaciji != null)
            {
                rezultat = poDanuILokaciji;
            }
            else
            {
                rezultat = new List<Rezervacija>();
            }

            _rezervacijeBindingSource.DataSource = rezultat;
        }

        private void SacuvajSelektovanuRezervaciju()
        {
            if (dgvRezervacije.CurrentRow == null)
            {
                _selektovanaRezervacija = null;
                return;
            }

            _selektovanaRezervacija = dgvRezervacije.CurrentRow.DataBoundItem as Rezervacija;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_selektovanaRezervacija != null)
            {
                _rezervacijeService.OtkaziRezervaciju(_selektovanaRezervacija.Id);
                OsveziRezervacije();
            }

        }

        private void dgvRezervacije_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovanuRezervaciju();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_selektovaniKorisnik == null || _selektovaniResurs == null)
            {
                MessageBox.Show("Moraš selektovati resurs i korisnika");
                return;
            }

            VremeForm form = new VremeForm(
                dateTimePicker1.Value.Date,
                _selektovaniKorisnik.Id,
                _selektovaniResurs.Id
            );

            form.ShowDialog();
            OsveziRezervacije();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_selektovanaRezervacija != null)
            {
                IzmenaRezervacije form = new IzmenaRezervacije(_selektovanaRezervacija);
                form.ShowDialog();
                OsveziRezervacije();
            }
        }
    }
}
