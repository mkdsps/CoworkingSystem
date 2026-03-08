using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem
{
    public partial class Form1
    {
        private List<Korisnik> _sviKorisnici = new List<Korisnik>();
        private List<TipClanstva> _sviTipoviClanstva = new List<TipClanstva>();

        private BindingSource _korisniciBindingSource = new BindingSource();

        private Korisnik? _selektovaniKorisnik;

        private void InicijalizujGridKorisnici()
        {
            dgvKorisnici.AutoGenerateColumns = true;
            dgvKorisnici.DataSource = _korisniciBindingSource;
            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKorisnici.MultiSelect = false;
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.AllowUserToAddRows = false;
            dgvKorisnici.AllowUserToDeleteRows = false;
        }

        private void UcitajKorisnike()
        {
            _sviKorisnici = _korisnikService!.GetAll();
            _korisniciBindingSource.DataSource = _sviKorisnici;

            SakrijKoloneKorisnici();

            OcistiSelekcijuGrida(dgvKorisnici);
            _selektovaniKorisnik = null;
        }

        private void SakrijKoloneKorisnici()
        {
            var idKolona = dgvKorisnici.Columns["Id"];
            if (idKolona != null)
                idKolona.Visible = false;

            var passKolona = dgvKorisnici.Columns["PasswordHash"];
            if (passKolona != null)
                passKolona.Visible = false;

            var lokacijaKolona = dgvKorisnici.Columns["LokacijaId"];
            if (lokacijaKolona != null)
                lokacijaKolona.Visible = false;
        }

        private void UcitajTipoveClanstva()
        {
            _sviTipoviClanstva = _tipClanstvaService!.GetAll();

            cmbTipClanstva.Items.Clear();
            cmbTipClanstva.Items.Add("Svi");

            foreach (var tip in _sviTipoviClanstva)
            {
                cmbTipClanstva.Items.Add(tip.Naziv);
            }

            cmbTipClanstva.SelectedIndex = 0;
        }

        private void PopuniStatuse()
        {
            cmbStatusNaloga.Items.Clear();

            cmbStatusNaloga.Items.Add("Svi");
            cmbStatusNaloga.Items.Add("Aktivan");
            cmbStatusNaloga.Items.Add("Pauziran");
            cmbStatusNaloga.Items.Add("Istekao");

            cmbStatusNaloga.SelectedIndex = 0;
        }

        private void FiltrirajKorisnike()
        {
            IEnumerable<Korisnik> rezultat = _sviKorisnici;

            string pretraga = txtPretragaKorisnika.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(pretraga))
            {
                rezultat = rezultat.Where(k =>
                    (k.Ime ?? "").ToLower().Contains(pretraga) ||
                    (k.Prezime ?? "").ToLower().Contains(pretraga));
            }

            if (cmbStatusNaloga.SelectedItem != null &&
                cmbStatusNaloga.SelectedItem.ToString() != "Svi")
            {
                string status = cmbStatusNaloga.SelectedItem.ToString()!;
                rezultat = rezultat.Where(k => k.Status == status);
            }

            if (cmbTipClanstva.SelectedItem != null &&
                cmbTipClanstva.SelectedItem.ToString() != "Svi")
            {
                string nazivTipa = cmbTipClanstva.SelectedItem.ToString()!;

                var tip = _sviTipoviClanstva
                    .FirstOrDefault(t => t.Naziv == nazivTipa);

                if (tip != null)
                {
                    rezultat = rezultat.Where(k => k.TipClanstvaId == tip.Id);
                }
            }

            _korisniciBindingSource.DataSource = rezultat.ToList();

            OcistiSelekcijuGrida(dgvKorisnici);
            _selektovaniKorisnik = null;
        }

        public void OsveziKorisnike()
        {
            UcitajKorisnike();
            FiltrirajKorisnike();
        }

        private void SacuvajSelektovanogKorisnika()
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                _selektovaniKorisnik = null;
                return;
            }

            _selektovaniKorisnik =
                dgvKorisnici.CurrentRow.DataBoundItem as Korisnik;
        }

        private void txtPretragaKorisnika_TextChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void cmbTipClanstva_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void cmbStatusNaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajKorisnike();
        }

        private void dgvKorisnici_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovanogKorisnika();
            OsveziRezervacije();
        }
    }
}
