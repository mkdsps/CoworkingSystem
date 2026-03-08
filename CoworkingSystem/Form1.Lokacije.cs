using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem
{
    public partial class Form1
    {
        private List<Lokacija> _sveLokacije = new List<Lokacija>();

        private BindingSource _lokacijeBindingSource = new BindingSource();

        private Lokacija? _selektovanaLokacija;

        private void InicijalizujGridLokacije()
        {
            dgvLokacije.AutoGenerateColumns = true;
            dgvLokacije.DataSource = _lokacijeBindingSource;
            dgvLokacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLokacije.MultiSelect = false;
            dgvLokacije.ReadOnly = true;
            dgvLokacije.AllowUserToAddRows = false;
            dgvLokacije.AllowUserToDeleteRows = false;
        }

        private void UcitajLokacije()
        {
            _sveLokacije = _lokacijaService!.GetAll();
            _lokacijeBindingSource.DataSource = _sveLokacije;

            SakrijKoloneLokacija();

            OcistiSelekcijuGrida(dgvLokacije);
            _selektovanaLokacija = null;
        }

        private void SakrijKoloneLokacija()
        {
            var idKolona = dgvLokacije.Columns["Id"];
            if (idKolona != null)
                idKolona.Visible = false;

            var datumKolona = dgvLokacije.Columns["DatumKreiranja"];
            if (datumKolona != null)
                datumKolona.Visible = false;
        }

        private void SacuvajSelektovanuLokaciju()
        {
            if (dgvLokacije.CurrentRow == null)
            {
                _selektovanaLokacija = null;
                return;
            }

            _selektovanaLokacija =
                dgvLokacije.CurrentRow.DataBoundItem as Lokacija;
        }

        public void OsveziLokacije()
        {
            UcitajLokacije();
        }

        private void dgvLokacije_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovanuLokaciju();

            if (_selektovanaLokacija != null)
            {
                UcitajResurseZaLokaciju(_selektovanaLokacija.Id);
            }
            else
            {
                _resursiZaSelektovanuLokaciju.Clear();
                _resursiBindingSource.DataSource = null;
                _selektovaniResurs = null;
            }
        }

    }
}
