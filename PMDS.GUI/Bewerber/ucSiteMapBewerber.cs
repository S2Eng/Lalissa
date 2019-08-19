using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;



namespace PMDS.GUI
{

    public partial class ucSiteMapBewerber : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDBewerber = Guid.Empty;

        public static frmKlientEdit frmKlientEdit = null;









        public ucSiteMapBewerber()
        {
            InitializeComponent();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Bewerberliste und Bewerberaufnahmeliste aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefrshControls()
        {
            ucBewerber1.RefreshControl();
            ucBewerberAufnahme1.RefreshControl();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bewerbungsdaten eines Klienten anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private DialogResult ShowKlientBewerbungsdaten(Guid IDPatient)
        {
            KlientDetails klient = new KlientDetails(IDPatient, Aufenthalt.LastByPatient(IDPatient));
            klient.BewerbungaktivJN = true;
            klient.BewerbungDatum = DateTime.Now;
            frmBewerbungsdaten frm = new frmBewerbungsdaten();
            frm.Klient = klient;
            return frm.ShowDialog();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Details eines Klienten anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowKlientDetails2(Guid IDPatient)
        {
            bool prevHist = PMDS.Global.historie.HistorieOn;
            PMDS.Global.historie.HistorieOn = false;

            if (ucSiteMapBewerber.frmKlientEdit == null)
            {
                ucSiteMapBewerber.frmKlientEdit = new frmKlientEdit();
                ucSiteMapBewerber.frmKlientEdit.ucKlientEdit1.isBewerberverwaltung = true;
            }

            ucSiteMapBewerber.frmKlientEdit.ucKlientEdit1.clearIDKlient();
            ucSiteMapBewerber.frmKlientEdit.IDPatient = IDPatient;
            ucSiteMapBewerber.frmKlientEdit.ShowDialog();

            PMDS.Global.historie.HistorieOn= prevHist;

        }

        private void PatientDetailsDelegate(Guid IDPatient, bool BewerberJN)
        {
            _IDBewerber = IDPatient;
            ShowKlientDetails2(IDPatient);
            RefrshControls();
        }

        private void ucBewerber1_PatientDeletedDelegate(Guid IDPatient)
        {
            RefrshControls();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ucBewerberAufnahme1.NeueAufnahme)
            {
                bool prevHist = PMDS.Global.historie.HistorieOn;
                PMDS.Global.historie.HistorieOn = false;

                if (ucSiteMapBewerber.frmKlientEdit == null)
                {
                    ucSiteMapBewerber.frmKlientEdit = new frmKlientEdit();
                    ucSiteMapBewerber.frmKlientEdit.ucKlientEdit1.isBewerberverwaltung = true;
                }

                ucSiteMapBewerber.frmKlientEdit.NewBewerber();
                ucSiteMapBewerber.frmKlientEdit.ShowDialog();
                RefrshControls();

                PMDS.Global.historie.HistorieOn = prevHist;
            }
            else
            {
                if(ShowKlientBewerbungsdaten(ucBewerberAufnahme1.IDPatient) == DialogResult.OK)
                    RefrshControls();
            }
        }

        private void ucBewerberAufnahme1_BewebungsdatenDetailsDelegate(Guid IDPatient)
        {
            if (ShowKlientBewerbungsdaten(IDPatient) == DialogResult.OK)
                RefrshControls();
        }

        private void ucBewerber1_BewerberstatusChangedDelegate(Guid IDPatient)
        {
            ucBewerberAufnahme1.RefreshControl();
        }

        private void tabBewerber_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }
    }
}
