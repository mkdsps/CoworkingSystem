using CoworkingSystem.backend.Modules;
using CoworkingSystem.backend.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem
{
    public partial class Form1
    {
        private List<Resurs> _svaRadnaMesta = new List<Resurs>();
        private List<Resurs> _sveSale = new List<Resurs>();
        private List<Resurs> _resursiZaSelektovanuLokaciju = new List<Resurs>();

        private BindingSource _resursiBindingSource = new BindingSource();

        private Resurs? _selektovaniResurs;

        private void InicijalizujGridResursi()
        {
            dgvResursi.AutoGenerateColumns = true;
            dgvResursi.DataSource = _resursiBindingSource;
            dgvResursi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResursi.MultiSelect = false;
            dgvResursi.ReadOnly = true;
            dgvResursi.AllowUserToAddRows = false;
            dgvResursi.AllowUserToDeleteRows = false;
        }

        private void PopuniTipoveResursa()
        {
            cmbTipResursa.Items.Clear();

            cmbTipResursa.Items.Add("Svi");
            cmbTipResursa.Items.Add("RadnoMesto");
            cmbTipResursa.Items.Add("Sala");

            cmbTipResursa.SelectedIndex = 0;
        }

        private void UcitajResurseZaLokaciju(int lokacijaId)
        {
            _svaRadnaMesta = _radnoMestoService!.GetRadnaMestaByLokacija(lokacijaId);
            _sveSale = _salaService!.GetSaleByLokacija(lokacijaId);

            _resursiZaSelektovanuLokaciju = _svaRadnaMesta
                .Concat(_sveSale)
                .ToList();

            FiltrirajResurse();
        }

        private void FiltrirajResurse()
        {
            IEnumerable<Resurs> rezultat = _resursiZaSelektovanuLokaciju;

            if (cmbTipResursa.SelectedItem != null &&
                cmbTipResursa.SelectedItem.ToString() != "Svi")
            {
                string tip = cmbTipResursa.SelectedItem.ToString()!;
                rezultat = rezultat.Where(r => r.TipResursa == tip);
            }

            _resursiBindingSource.DataSource = rezultat.ToList();

            SakrijKoloneResursa();

            OcistiSelekcijuGrida(dgvResursi);
            _selektovaniResurs = null;
        }

        private void SakrijKoloneResursa()
        {
            //var idKolona = dgvResursi.Columns["Id"];
            //if (idKolona != null)
            //    idKolona.Visible = false;

            var lokacijaKolona = dgvResursi.Columns["LokacijaId"];
            if (lokacijaKolona != null)
                lokacijaKolona.Visible = false;
        }

        private void SacuvajSelektovaniResurs()
        {
            if (dgvResursi.CurrentRow == null)
            {
                _selektovaniResurs = null;
                return;
            }

            _selektovaniResurs =
                dgvResursi.CurrentRow.DataBoundItem as Resurs;
        }

        public void OsveziResurse()
        {
            if (_selektovanaLokacija == null)
            {
                _resursiBindingSource.DataSource = null;
                _selektovaniResurs = null;
                return;
            }

            UcitajResurseZaLokaciju(_selektovanaLokacija.Id);
        }

        private void cmbTipResursa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajResurse();
        }

        private void dgvResursi_SelectionChanged(object sender, EventArgs e)
        {
            SacuvajSelektovaniResurs();
        }

    }
}
