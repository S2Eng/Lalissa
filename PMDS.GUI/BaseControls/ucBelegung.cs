using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;



namespace PMDS.GUI.BaseControls
{

    public partial class ucBelegung : QS2.Desktop.ControlManagment.BaseControl
    {

        private Belegung        _Belegung = new Belegung();
        public event EventHandler ValueChanged;
        public event EventHandler ValueSaved;
        private bool isLoaded = false;



        public ucBelegung()
        {
            InitializeComponent();

        }

        public void initControl()
        {
            cbAbteilung.SelectedIndex = 0;

            dtVon2.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dt = dtVon2.DateTime;
            dt = dt.AddMonths(1);
            dt = dt.AddDays(-1);
            dtBis2.DateTime = dt;
            RefreshGrid();
            isLoaded = true;
        }


        private Guid IDABTEILUNG 
        { 
            get 
            {
                if (cbAbteilung.SelectedItem == null)
                    return Guid.Empty;
                Guid IDAbteilung = (Guid)cbAbteilung.SelectedItem.DataValue;
                return IDAbteilung;
            } 
        }

        private DateTime VON { get { return dtVon2.DateTime.Date; } set { dtVon2.DateTime = value.Date; } }
        private DateTime BIS { get { return dtBis2.DateTime.Date; } set { dtBis2.DateTime = value.Date; } }
        private int         BETTEN  { get { return Convert.ToInt32(nBetten.Value);} }




        private void cbAbteilung_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            Save();
            RefreshGrid();
            if (ValueSaved != null)
                ValueSaved(this, null);
        }

        public void RefreshGrid()
        {
            _Belegung.Read(IDABTEILUNG, VON, BIS);
            dgMain.DataSource = _Belegung.BELEGUNG_DATATABLE;
        }


        public void Save()
        {
            _Belegung.Write();
        }

        private void btnUeberschreiben2_Click(object sender, EventArgs e)
        {
            _Belegung.Ueberschreiben(IDABTEILUNG, VON, BIS, BETTEN);
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Daten wurden ausgefüllt und gespeichert!", "Ausfüllen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (ValueChanged != null)
                ValueChanged(this, null);
        }

        private void btnAusfuellen2_Click(object sender, EventArgs e)
        {
            _Belegung.Auffuellen(IDABTEILUNG, VON, BIS, BETTEN);
        }

        private void dgMain_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, null);
        }


        private void dtVon2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            Save();
            if (VON > BIS)
                BIS = VON;
            RefreshGrid();

            if (ValueSaved  != null)
                ValueSaved(this, null);

        }

        private void dtBis2_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            Save();
            if (BIS < VON)
                VON = BIS;
            RefreshGrid();

            if (ValueSaved != null)
                ValueSaved(this, null);
        }
    }
}
