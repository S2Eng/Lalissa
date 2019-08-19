//----------------------------------------------------------------------------
/// <summary>
///	ucNotfall.cs
/// Erstellt am:	12.12.2007
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.BusinessLogic;
using System.IO;
using PMDS.Global.db.Pflegeplan;
using PMDS.DB;
using System.Linq;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{


    public partial class ucNotfall : QS2.Desktop.ControlManagment.BaseControl
    {
        private dsSP                        _SP = null;
        private BearbeitungsModus           _mode = BearbeitungsModus.neu;
        private Guid                        _IDAUfenthalt;
        private string                      _originalFreierBericht = "";
        private int                         _writeCount = 0;
        private dsEintrag.EintragDataTable  _massnahmen = null;
        private bool                        _Notfall = false;

        public event EventHandler NaechterZeitpunktChanged;       

        public PMDS.GUI.clAutoUI clAutoUI1 = new clAutoUI();
        public Sturzprotokoll.frmSturz frmSturz1 = null;
        
        public bool DatenerhebungIsInitialized = false;
        
        public frmNotfall MainWindow = null;
        
        private string DekursOriginal = "";
        private string DekursModifiziert = "";
        private ucDatenErhebung ucDatenErhebung1 = null;
        public PMDSBusiness b = new PMDSBusiness();






        public ucNotfall()
        {
            InitializeComponent();
            this.auswahlGruppeComboMulti1.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, true, -1, 0, true);
        }




        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsSP DSSP
        {
            get
            {
                return _SP;
            }
            set
            {
                _SP = value;
                RefreshControl();
                if (_mode == BearbeitungsModus.edit)
                {
                    dtpZeitpunkt.Enabled = false;
                }

                this.InitSturz();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BearbeitungsModus MODE
        {
            set
            {
                _mode = value;
            }
            get
            {
                return _mode;
            }
        }

        public Guid IDAUFENTHALT
        {
            get
            {
                return _IDAUfenthalt;
            }
            set
            {
                _IDAUfenthalt = value;
            }
        }

        private void RefreshControl()
        {
            //this.initDatenerhebung();

            pnlPE.Controls.Clear();

            tbFreierBericht.Text    = DSSP.SP[0].Anmerkung.Trim();
            _originalFreierBericht  = tbFreierBericht.Text;
            DateTime dt = DSSP.SP[0].EreignisZeitpunkt;
            if (dt.Year == 1900)
                dtpZeitpunkt.Value = DateTime.Now;
            else
                dtpZeitpunkt.Value = dt;

            foreach (dsSP.SPPOSRow r in _SP.SPPOS)
                AddFromSPPosRow(r);

            _Notfall = StandardProzeduren.GetNotfallFlag(DSSP.SP[0].IDStandardProzeduren);
            lblWichtig.Visible  = _Notfall;
            auswahlGruppeComboMulti1.Visible   = _Notfall;
            tbFreierBericht.Enabled = !_Notfall;

            if (_Notfall)
                this.lblDekurs.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zum Notfall");
            else
                this.lblDekurs.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zur Standardprozedur");


            try
            {
                string sPath = Path.Combine(ENV.DynReportNotfallBasePath, StandardProzeduren.GetReportPath(DSSP.SP[0].IDStandardProzeduren));
                ucDynReports1.Init(sPath);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void initDatenerhebung()
        {
            try
            {
                if (!this.DatenerhebungIsInitialized)
                {
                    this.ucDatenErhebung1 = new ucDatenErhebung();
                    this.ucDatenErhebung1.FRAMEWORK = null;
                    this.ucDatenErhebung1.Dock = DockStyle.Fill;
                    this.panelDatenerhebung.Controls.Add(this.ucDatenErhebung1);

                    this.ucDatenErhebung1.mainWindowNotfall = this;
                    this.ucDatenErhebung1.IsExternControl = true;
                    //this.ucDatenErhebung1.loadMainSite();

                    this.DatenerhebungIsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucNotfall.initDatenerhebung: " + ex.ToString());
            }
        }

        public void SetUIDatenerhebung(bool bOn)
        {
            try
            {
                frmNotfall frmMain = (frmNotfall)this.ParentForm;
                frmMain.panelBottom.Visible = !bOn;

                //if (bOn)
                //{
                //    this.splitContainer1.Panel1Collapsed = true;
                //}
                //else
                //{
                //    this.splitContainer1.Panel1Collapsed = false;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucNotfall.SetUIDatenerhebung: " + ex.ToString());
            }
        }

        private void AddFromSPPosRow(dsSP.SPPOSRow r)
        {
            ucNotfallM uc               = new ucNotfallM();
            uc.IDAUFENTHALT             = _IDAUfenthalt;
            uc.IDUSER                   = ENV.USERID;
            uc.IDEintrag                = r.IDEintrag;
            uc.Dock                     = DockStyle.Top;
            uc.BorderStyle              = BorderStyle.FixedSingle;
            uc.Tag                      = r;
            uc.NaechterZeitpunktChanged += new EventHandler(uc_NaechterZeitpunktChanged);
            pnlPE.Controls.Add(uc);
            pnlPE.Controls.SetChildIndex(uc, 0);
        }

        void uc_NaechterZeitpunktChanged(object sender, EventArgs e)
        {
            if (NaechterZeitpunktChanged == null)
                return;
            NaechterZeitpunktChanged(sender, e);

        }

        public bool Write(bool bAbschliessen)
        {
            if (!ValidateFields())
                return false;





            DSSP.SP[0].Anmerkung            = tbFreierBericht.Text;
            DSSP.SP[0].EreignisZeitpunkt    = dtpZeitpunkt.DateTime;
            DSSP.SP[0].offenJN              = !bAbschliessen;
            SP sp = new SP();

            if (_mode == BearbeitungsModus.neu && _writeCount == 0)                             // Dekurs zum Notfall wurde neu erstellt
                WriteSPalsFreierBericht();
            else
                WriteFreienBericht();                                                           // Dekurs zu Notfall wurde geändert

            sp.Write(DSSP);                                                                     // Speichern

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                //Für ausgewählte Maßnahmen Pflegeeinträge schreiben 
                foreach (ucNotfallM uc in pnlPE.Controls)
                {
                    if (!uc.CHK_DONE)                                                               // Nicht benutzte ignorieren
                        continue;

                    uc.Write();                                                                     // Pflegeeinträge mit Zusatzwerten erzeugen

                    PMDS.db.Entities.SPPE newSPPE = new PMDS.db.Entities.SPPE();
                    newSPPE.ID = Guid.NewGuid();
                    newSPPE.IDSP = DSSP.SP[0].ID;
                    newSPPE.IDPflegeEintrag = uc.IDPflegeEintrag;

                    db.SPPE.Add(newSPPE);
                    db.SaveChanges();

                    Guid IDGruppe = System.Guid.NewGuid();
                    IQueryable<PMDS.db.Entities.PflegeEintrag> lstPEorig = db.PflegeEintrag.Where(pe => pe.ID == uc.IDPflegeEintrag);
                    PMDS.db.Entities.PflegeEintrag rPEeOriginal = lstPEorig.First();
                    rPEeOriginal.IDGruppe = IDGruppe;
                    db.SaveChanges();

                    System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                    uc.auswahlGruppeComboMulti1.AddCC2(uc.IDPflegeEintrag, false, true, false, System.Guid.Empty, ref lstPEToCopy, true, ref IDGruppe);

                    //this.b.copyUpdateZusatzwertePEIDGruppe(uc.IDPflegeEintrag, db);
                }
            }

            if (!this.clAutoUI1.UpdateData())
            {
                throw new Exception("Write: !this.clAutoUI1.UpdateData() is false!");
            }

            _writeCount++;

            return true;
        }

        private Guid IDSTANDARDPROZEDUREN
        {
            get
            {
                return DSSP.SP[0].IDStandardProzeduren;
            }
        }

        private void WriteSPalsFreierBericht()
        {
            if (!_Notfall)
                return;

            StringBuilder sb = new StringBuilder();
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall: "));
            sb.Append(StandardProzeduren.GetBezeichnung(IDSTANDARDPROZEDUREN));
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" am "));
            sb.Append(dtpZeitpunkt.DateTime.ToShortDateString());
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" um "));
            sb.Append(dtpZeitpunkt.DateTime.ToShortTimeString());
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(". Beschreibung: "));
            sb.Append(tbFreierBericht.Text.ToString());

            WriteFB(sb.ToString(), false);
        }

        private void WriteFreienBericht()
        {
            if (FREIERBERICHTCHANGED)
                WriteFB(tbFreierBericht.Text.Trim(), true);
        }

        private void WriteFB(string sText, bool bPrefix)
        {
            Guid IDPflegeEintrag;
            if(bPrefix)
                sText = StandardProzeduren.GetBezeichnung(IDSTANDARDPROZEDUREN) + ": " + sText;

            System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
            System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
            this.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);

            foreach (Guid idWichtig in lstSelectedCC)
            {
                if (idWichtig != System.Guid.Empty)
                {
                    if (_Notfall)
                        IDPflegeEintrag = PflegeEintrag.NewNotfallBerichtEinfuegen(IDAUFENTHALT, DateTime.Now, sText, idWichtig);
                    else
                        IDPflegeEintrag = PflegeEintrag.NewFreienBerichtEinfuegen(IDAUFENTHALT, DateTime.Now, sText, idWichtig);

                    DSSP.SPPE.AddSPPERow(Guid.NewGuid(), DSSP.SP[0].ID, IDPflegeEintrag);        // Verspeichern welcher Eintrag zu welcher Standardprozedur gehört
                }
            }
        }

        private bool FREIERBERICHTCHANGED 
        {
            get
            {
                string s = tbFreierBericht.Text.Trim();
                if (s.Length == 0 || s == _originalFreierBericht)
                    return false;

                return true;
            }
        }

        public bool ValidateZeitpunkt()
        {
            bool bError = false;
            bool bInfo = true;

            if (dtpZeitpunkt.Value != null)
            {
                if(dtpZeitpunkt.DateTime > DateTime.Now)
                    GuiUtil.ValidateField(dtpZeitpunkt, (dtpZeitpunkt.DateTime <= DateTime.Now), "Datum in der Zukunft ist nicht zulässig", ref bError, bInfo, errorProvider1);
                else
                    GuiUtil.ValidateField(dtpZeitpunkt, (dtpZeitpunkt.DateTime.Hour != 0 || dtpZeitpunkt.DateTime.Minute != 0), "Die Uhrzeit 00:00 ist nicht zulässig", ref bError, bInfo, errorProvider1);
            }
            else
            {
                GuiUtil.ValidateField(dtpZeitpunkt, (dtpZeitpunkt.Value != null), ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            }

            return !bError;
        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            foreach (ucNotfallM uc in pnlPE.Controls)
            {
                if (uc.ValidateFields() == false)
                    bError = true;
            }

            if (ValidateZeitpunkt() == false)
                bError = true;

//            if(_Notfall && _mode == BearbeitungsModus.neu)            // nur im Notfall prüfen os 160425
//                GuiUtil.ValidateField(cbWichtig, (cbWichtig.Text.Length > 0), ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            
            return !bError;
        }


        private void cbmarkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ucNotfallM uc in pnlPE.Controls)
            {
                uc.CHK_DONE = cbmarkAll.Checked;
            }
        }

        public bool IsM_checked
        {
            get
            {
                foreach (ucNotfallM uc in pnlPE.Controls)
                    if (uc.CHK_DONE)
                        return true;
                return false;
            }

        }

        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(dtpZeitpunkt);
//            GuiUtil.ValidateRequired(cbWichtig);        //os 160425
        }

        private void ucNotfall_Load(object sender, EventArgs e)
        {
            RequiredFields();
        }

        private bool MarkierteMelden()
        {
            // Alle zum melden melden + Plausibilitätsprüfung
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!ValidateFields())
                    return false;
                Write(false);                                                 // Innerhalb des Controls den Vorgang standardmäßig abschließen
                cbmarkAll.Checked       = false;                              // Checkboxen zurücksetzen
                auswahlGruppeComboMulti1.Enabled       = false;                              // Erstmaliges schreiben ist entscheidend
                dtpZeitpunkt.Enabled    = false;                              // Zeitpunkt einmal vergeben
                _originalFreierBericht  = tbFreierBericht.Text.Trim();        // Für weiteren freien Bericht merken

                cbmarkAll_CheckedChanged(this, EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
                return false;
            }
        }

        private void btnMelden_Click(object sender, EventArgs e)
        {
            MarkierteMelden();
        }

        private void btnAddM_Click(object sender, EventArgs e)
        {
            if (_massnahmen == null)
                _massnahmen = new PDx().KATALOGE['M'].EINTRAEGE;

            frmPicker picker = new frmPicker(_massnahmen, "Text", "ID", -1, false);
            picker.Text = ENV.String("GUI.SEARCH_MASSNAHME");
            if (picker.ShowDialog() != DialogResult.OK)
                return;

            Guid IDEintrag = (Guid)picker.Value;
            dsSP.SPPOSRow r = DSSP.SPPOS.AddSPPOSRow(Guid.NewGuid(), DSSP.SP[0].ID, IDEintrag, false, "", ENV.USERID, ENV.USERID, DateTime.Now, DateTime.Now, false, DateTime.Now);
            r.SetwiederumamNull();
            AddFromSPPosRow(r);

        }

        public void RemoveReplacerDelegate()
        {
            ucDynReports1.RemoveReplacerDelegate();
        }

        private void btnSturz_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmSturz1.Show();
                this.frmSturz1.contSturz1.loadData();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void InitSturz()
        {
            try
            {
                this.frmSturz1 = new Sturzprotokoll.frmSturz();
                this.frmSturz1.contSturz1.mainWindow = frmSturz1;
                dsSP.SPRow rSp = (dsSP.SPRow)_SP.SP.Rows[0];
                this.clAutoUI1.IDSP = rSp.ID;
                this.clAutoUI1.IDPatient = PMDS.Global.ENV.CurrentIDPatient;
                this.frmSturz1.contSturz1.clAutoUI1 = this.clAutoUI1;
                this.frmSturz1.contSturz1.InitControl();
                //frmSturz1.contSturz1.loadData();
                //frmSturz1.ShowDialog(this);
                //if (!frmSturz1.contSturz1.abort)
                //{
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("InitSturz: " + ex.ToString());
            }
        }

        private void tbFreierBericht_ValueChanged(object sender, EventArgs e)
        {
            DekursModifiziert = tbFreierBericht.Text;
        }

        private void auswahlGruppeComboMulti1_AfterCheck(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
            System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
            this.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);

            if (lstSelectedCC.Count > 0 || !_Notfall)  //
            {
                tbFreierBericht.Enabled = true;
            }
            else
            {

                if (_originalFreierBericht != tbFreierBericht.Text.Trim())
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben alle Einträge in 'Wichtig für' zurückgesetzt. Ihre Änderungen im Dekurs werden ebenfalls zurückgesetzt.");
                    tbFreierBericht.Text = _originalFreierBericht;
                }

                tbFreierBericht.Enabled = false;
            }
        }

        private void tabMainNotfall_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
        {
            try
            {
                if (e.Tab.Key.Trim().ToLower().Equals(("Protkolle").Trim().ToLower()))
                {
                    this.initDatenerhebung();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }           
        }

    }

}
