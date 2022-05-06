using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Print;
using PMDS.Klient;
using PMDS.Abrechnung.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;
using PMDS.DB;
using PMDS.GUI.Klient;
using System.Threading.Tasks;

namespace PMDS.GUI
{
    public partial class ucBewerbungsdaten : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private bool _valueChangeEnabled = true;
        private KlientDetails _klient;
        private bool _readOnly = false;
        public event EventHandler ValueChanged;
        private bool _BewerberReadonly = false;//Neu nach 05.07.2007 MDA
        public PMDSBusiness b = new PMDSBusiness();

        public class cCboHeimvertrag
        {
            public System.Guid ID;
            public bool IsSachwalter = false;
            public bool bSelection = false;
        }





        public ucBewerbungsdaten()
        {
            try
            {
                InitializeComponent();

                if (DesignMode || !ENV.AppRunning) return;

                RefreshListAbteilungen(System.Guid.Empty);

                PMDS.Global.Heimverträge.cHeimverträge cHeimverträge1 = new Global.Heimverträge.cHeimverträge();
                cHeimverträge1.loadMenü(null, this.cboRTFTemplates);

            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerbungsdaten: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if (_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Klient");

                _valueChangeEnabled = false;
                _klient = value;
                UpdateGUI();
                _valueChangeEnabled = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        public bool BewerberReadOnly
        {
            get { return _BewerberReadonly; }
            set {_BewerberReadonly = value;}
        }

        private void RefreshListAbteilungen(System.Guid IDKlinik)
        {
            try
            {
                cbAbteilung.Items.Clear();
                cbAbteilung.Items.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abteilung"));
                this.cboBereich.Clear();
                this.cboBereich.Value = null;
                
                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                dsAbteilung dsAbteilung1 = new dsAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    if (IDKlinik.Equals(System.Guid.Empty))
                    {
                        cbAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung);
                    }
                    else
                    {
                        cbAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("RefreshListAbteilungen: " + ex.ToString());
            }
        }
        private void setKlinikForIDAbteilung(Guid IDAbteilung)
        {
            try
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Abteilung rAbteilung = b.getAbteilung(IDAbteilung, db);
                    this.cbKlinik.Value = rAbteilung.IDKlinik;
                    this.cbKlinik.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setKlinikForIDAbteilung: " + ex.ToString());
            }
        }

        public async Task<bool> setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxBewerbungsdaten, bOn).ConfigureAwait(false);        //ultraDropDownButtonHeimvertragDrucken
            return true;
        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            this.cbKlinik.Value = null;
            this.loadComboAllKliniken();

            Bewerbungsdatum.Value = Klient.BewerbungDatum;
            cbAktuel.Checked = Klient.BewerbungaktivJN;
            cmbPrioritaet.Text = Klient.Prioritaet;
            cmbPflegeart.Text = Klient.PflegeArt;
            EinzDatum.Value = Klient.EinzugswunschDatum;
            Auszugsdatum.Value = Klient.AuszugswunschDatum;
            txtBewGrund.Text = Klient.BewerbungsGrund;
            txtZimmerw.Text = Klient.Zimmerwunsch;
            txtSonstigew.Text = Klient.SonstigeWuensche;
            txtBemerkung.Text = Klient.BewerberBemerkung;

            //Neu nach 03.09.2008 MDA
            cbAbteilungJN.Checked = Klient.IDAbteilung != Guid.Empty;

            if (!Klient.IDAbteilung.Equals(System.Guid.Empty))
            {
                this.setKlinikForIDAbteilung(Klient.IDAbteilung);
                this.RefreshListAbteilungen(new System.Guid(this.cbKlinik.Value.ToString()));
                cbAbteilung.Value = Klient.IDAbteilung;
            }
            this.loadBereich();
            this.cboBereich.Value = null;
            if (!Klient.IDBereich.Equals(System.Guid.Empty))
            {
                this.cboBereich.Value = Klient.IDBereich;
            }

        }
        public void loadBereich()
        {
            try
            {
                if (this.cbAbteilung.Value != null)
                {
                    this.b.loadCboBereiche((Guid)this.cbAbteilung.Value, this.cboBereich, false);
                }
                else
                {
                    this.b.loadCboBereiche(null, this.cboBereich, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerbungsdaten.loadBereich: " + ex.ToString());
            }
        }

        public dsKlinik.KlinikRow loadComboAllKliniken()
        {
            try
            {
                bool lstKlinikenLoaded = false;
                this.dsKlinik1.Klinik.Clear();
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                return b.loadComboAllKliniken(this.cbKlinik, this.dsKlinik1.Klinik, ref lstKlinikenLoaded, false);

            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerbungsdaten.loadComboAllKliniken: " + ex.ToString());
            }
        }
        public dsKlinik.KlinikRow getSelKlinik(bool withMsgBox)
        {
            try
            {
                //<20120202>
                if (this.cbKlinik.SelectedItem != null)
                {
                    Infragistics.Win.ValueListItem item = this.cbKlinik.SelectedItem;
                    return (dsKlinik.KlinikRow)item.Tag;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einrichtung ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerbungsdaten.getSelKlinik: " + ex.ToString());
            }
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            Klient.BewerbungDatum = Bewerbungsdatum.Value;
            Klient.BewerbungaktivJN = cbAktuel.Checked;
            Klient.Prioritaet = cmbPrioritaet.Text.Trim();
            Klient.PflegeArt = cmbPflegeart.Text.Trim();
            Klient.EinzugswunschDatum = EinzDatum.Value;
            Klient.AuszugswunschDatum = Auszugsdatum.Value;
            Klient.BewerbungsGrund = txtBewGrund.Text.Trim();
            Klient.Zimmerwunsch = txtZimmerw.Text.Trim();
            Klient.SonstigeWuensche = txtSonstigew.Text.Trim();
            Klient.BewerberBemerkung = txtBemerkung.Text.Trim();

            if (cbAbteilungJN.Checked && cbAbteilung.Value != null)
                Klient.IDAbteilung = (Guid)cbAbteilung.Value;
            else
                Klient.IDAbteilung = Guid.Empty;

            if (this.cboBereich.Value != null)
                Klient.IDBereich = (Guid)cboBereich.Value;
            else
                Klient.IDBereich = Guid.Empty;

        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
           return true;
        }

        private void SetReadOnly()
        {
            Bewerbungsdatum.ReadOnly = ReadOnly;
            cbAktuel.Enabled = !ReadOnly;
            cmbPrioritaet.ReadOnly = ReadOnly;
            cmbPflegeart.ReadOnly = ReadOnly;
            EinzDatum.ReadOnly = ReadOnly;
            Auszugsdatum.ReadOnly = ReadOnly;
            txtBewGrund.ReadOnly = ReadOnly;
            txtZimmerw.ReadOnly = ReadOnly;
            txtSonstigew.ReadOnly = ReadOnly;
            txtBemerkung.ReadOnly = ReadOnly;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs args)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn) return;
                if (_valueChangeEnabled && (ValueChanged != null))
                    ValueChanged(sender, args);

                if (this.cbAbteilung.Focused)
                {
                    this.loadBereich();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }

        }

        private void cbAktuel_BeforeCheckStateChanged(object sender, CancelEventArgs e)
        {
            if (_valueChangeEnabled && _BewerberReadonly)
                e.Cancel = true;
        }
        

        private void btnPrintHeimVertrag_Click(object sender, EventArgs e)
        {   
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboRTFTemplates.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formulare: Auswahl erforderlich!", "Formulare", MessageBoxButtons.OK);
                    this.cboRTFTemplates.Focus();
                    return;
                }

                string optVertretenDurch = "";
                if (this.optVertretenDurch.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Vertreten durch: Auswahl erforderlich!", "Vertreten durch", MessageBoxButtons.OK);
                    this.optBefristetUnbefristet.Focus();
                    return;
                }

                optVertretenDurch = this.optVertretenDurch.Value.ToString();
                if (optVertretenDurch.Trim().ToLower() != ("Eigenberechtigt").Trim().ToLower() && this.cbUnterzeichnender.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Unterzeichnender: Auswahl erforderlich!", "Unterzeichnender", MessageBoxButtons.OK);
                    this.cbUnterzeichnender.Focus();
                    return;
                }
                //if (this.cbVertrauensperson.Value == null)
                //{
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Vertrauensperson: Auswahl erforderlich!", "Unterzeichnender", MessageBoxButtons.OK);
                //    this.cbVertrauensperson.Focus();
                //    return;
                //}
                
                Nullable<DateTime> dVertragVon = null;
                if (dateWirksamAb.Value != null)
                    dVertragVon = dateWirksamAb.DateTime.Date;

                bool bBefristet = false;
                if ((string)this.optBefristetUnbefristet.Value == "befristet")
                {
                    bBefristet = true;
                }

                Nullable<DateTime> dVertragBis = null;
                if (bBefristet)
                {
                    if (this.dateBefristetBis.Value == null)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet bis: Datumseingabe erforderlich!", "Befristet bis", MessageBoxButtons.OK);
                        this.dateBefristetBis.Focus();
                        return;
                    }
                }

                if (dateBefristetBis.Value != null)
                {
                    dVertragBis = (DateTime)dateBefristetBis.Value;
                }

                cCboHeimvertrag cboUnterzeichnender = new cCboHeimvertrag();
                cboUnterzeichnender.bSelection = false;
                cboUnterzeichnender.IsSachwalter = false;
                if (this.cbUnterzeichnender.SelectedItem != null)
                {
                    cboUnterzeichnender = (cCboHeimvertrag)this.cbUnterzeichnender.SelectedItem.Tag;
                    cboUnterzeichnender.bSelection = true;
                }

                cCboHeimvertrag cboVertrauensperson = new cCboHeimvertrag();
                cboVertrauensperson.bSelection = false;
                if (this.cbVertrauensperson.SelectedItem != null)
                {
                    cboVertrauensperson = (cCboHeimvertrag)this.cbVertrauensperson.SelectedItem.Tag;
                    cboVertrauensperson.bSelection = true;
                }
                
              
                PMDS.Global.Heimverträge.cHeimverträge cHeimverträge1 = new Global.Heimverträge.cHeimverträge();
                cHeimverträge1.openDocument(this.cboRTFTemplates.Value.ToString().Trim(), this.cboRTFTemplates.SelectedItem.Tag.ToString(),
                                            cboUnterzeichnender.ID, cboUnterzeichnender.IsSachwalter, cboVertrauensperson.ID, optVertretenDurch.Trim(),
                                            dVertragVon, dVertragBis, bBefristet, cboUnterzeichnender.bSelection, cboVertrauensperson.bSelection);


                //PMDS.Print.ReportManager.PrintHeimVertrag(Klient.IDPatient, Wirksamkeitvon, cboZimmerart.Text, bBefristet, befristetbis,
                //                                                cbUnterzeichnender.Text != null ? cbUnterzeichnender.Text : "",
                //                                                cbVertrauensperson.Text != null ? cbVertrauensperson.Text : "", !bBefristet);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnPrintHeimVertrag_orig()
        {
            //bool befristetJN;
            //bool unbefristetjn; // nötig für den Report der für die Dynreport gemacht wurde
            //DateTime befristetbis;

            //if (Auszugsdatum.Value == null)
            //{
            //    befristetJN = false; unbefristetjn = true;
            //    befristetbis = DateTime.Now;
            //}

            //else
            //{
            //    befristetJN = true; unbefristetjn = false;
            //    befristetbis = (DateTime)Auszugsdatum.Value;
            //}



            //DateTime Wirksamkeitvon;

            //if (EinzDatum.Value == null)
            //    Wirksamkeitvon = DateTime.Now.AddYears(-100);
            //else Wirksamkeitvon = (DateTime)EinzDatum.Value;

            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    ReportManager.PrintHeimVertrag(Klient.IDPatient, Wirksamkeitvon, txtZimmerw.Text, befristetJN, this.chkVertragsdauerBefristet.Checked,
            //        cbUnterzeichnender.Text != null ? cbUnterzeichnender.Text : "", cbVertrauensperson.Text != null ? cbVertrauensperson.Text : "", this.chkVertragsdauerUnbefristet.Checked);

            //}
            //catch (Exception ex)
            //{
            //    ENV.HandleException(ex);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Arrow;
            //}
        }

        private void ultraDropDownButton1_DroppingDown(object sender, CancelEventArgs e)
        {
            this.optBefristetUnbefristet.Value = "befristet";
            
            int zaehlvariable=0;
            this.cbUnterzeichnender.Items.Clear();
            this.cbVertrauensperson.Items.Clear();
            this.cbUnterzeichnender.Text = "";
            this.cbVertrauensperson.Text = "";
            this.cboZimmerart.Text = "";

            this.dateBefristetBis.Value = null;
            this.optBefristetUnbefristet.Value = "unbefristet";
            this.setUIBefristetnbefristet();
            
            foreach (dsKlientSachwalter.SachwalterRow r in Klient.KLIENT_SACHWALTER.Sachwalter)
            {
                Infragistics.Win.ValueListItem itm = this.cbUnterzeichnender.Items.Add((zaehlvariable++), r.Name);
                cCboHeimvertrag CboHeimvertrag = new cCboHeimvertrag();
                CboHeimvertrag.ID = r.ID;
                CboHeimvertrag.IsSachwalter = true;
                itm.Tag = CboHeimvertrag;
            }
            foreach (dsKontaktpersonen.KontaktpersonRow row in Klient.KLIENT_KONTAKTPERSONEN.Kontaktperson)
            {
                Infragistics.Win.ValueListItem itm = this.cbUnterzeichnender.Items.Add(zaehlvariable++, row.Name);
                cCboHeimvertrag CboHeimvertrag = new cCboHeimvertrag();
                CboHeimvertrag.ID = row.ID;
                CboHeimvertrag.IsSachwalter = false;
                itm.Tag = CboHeimvertrag;
            }

            //foreach (PMDS.Data.Global.dsAerzte.AerzteRow row in Klient.CLASS_AERZTE.AERZTE.Aerzte )
            //{
            //    //this.cbVertrauensperson.Items.Add(zaehlvariable++, row.Vorname + " " + row.Nachname);
            //}

            foreach (dsKontaktpersonen.KontaktpersonRow row in Klient.KLIENT_KONTAKTPERSONEN.Kontaktperson)
            {
                if (row.VerstaendigenJN)
                {
                    Infragistics.Win.ValueListItem itm = this.cbVertrauensperson.Items.Add(zaehlvariable++, row.Name);
                    cCboHeimvertrag CboHeimvertrag = new cCboHeimvertrag();
                    CboHeimvertrag.ID = row.ID;
                    CboHeimvertrag.IsSachwalter = false;
                    itm.Tag = CboHeimvertrag;
                }
            }

            //KlientDetails  klient = new KlientDetails(p.ID, p.Aufenthalt.ID );
            Patient p = new Patient (ENV.CurrentIDPatient );
            if (Klient.Aufenthalt != null)
            {
                this.dateWirksamAb.Value = p.Aufenthalt.Aufnahmezeitpunkt; //Neu nach 08.05.2007
            }
            else
            {
                this.dateWirksamAb.Value = null ;
            }

        }

        private void cbAbteilungJN_CheckedChanged(object sender, EventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            this.cbKlinik.Visible = cbAbteilungJN.Checked;
            cbAbteilung.Visible = cbAbteilungJN.Checked;
            this.cboBereich.Visible = cbAbteilungJN.Checked;
            this.lblKlinik.Visible = cbAbteilungJN.Checked;
            this.lblAbteilung.Visible = cbAbteilungJN.Checked;
            this.lblBereich.Visible = cbAbteilungJN.Checked;

            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        private void ultraDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void ucBewerbungsdaten_Load(object sender, EventArgs e)
        {

        }

        private void ultraGroupBoxBewerbungsdaten_Click(object sender, EventArgs e)
        {

        }

        private void pnlPrintHeimVertrag_Paint(object sender, PaintEventArgs e)
        {

        }

        private void optBefristetUnbefristet_ValueChanged(object sender, EventArgs e)
        {
            if (optBefristetUnbefristet.Focused) setUIBefristetnbefristet();
        }

        private void setUIBefristetnbefristet()
        {
            if (this.optBefristetUnbefristet.Value.ToString() == "befristet")
            {
                this.dateBefristetBis.Enabled = true;
                this.lblBefristetBis .Enabled = true;
                this.dateBefristetBis.Value = DateTime.Now;
            }
            else
            {
                this.dateBefristetBis.Enabled = false;
                this.lblBefristetBis.Enabled = false;
                this.dateBefristetBis.Value = null;
            }

        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cbKlinik_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbKlinik.Focused)
                {
                    if (PMDS.Global.historie.HistorieOn) return;
                    if (_valueChangeEnabled && (ValueChanged != null))
                        ValueChanged(sender, e);

                    dsKlinik.KlinikRow rKlinik = this.getSelKlinik(true);
                    if (rKlinik != null)
                    {
                        this.RefreshListAbteilungen(rKlinik.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }
}
