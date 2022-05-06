using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using PMDS.Data.Global;
using System.Linq;
using Infragistics.Win.UltraWinEditors;
using System.Threading.Tasks;

namespace PMDS.GUI
{


    public partial class ucAbrechAufenthKlient : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {

        private bool _valueChangeEnabled = true;
        private KlientDetails _klient;
        public event EventHandler ValueChanged;
        public event EventHandler VersDatenChanged;
        public KlientPflegegeldstufe _pflegestufe; 

        private bool _readOnly = false;

        public bool abrechnungHasChanged = false;

        public PMDS.GUI.Kostentraeger.ucKostentraegerKlient2 ucKostenträgerGrundl;
        public PMDS.GUI.Kostentraeger.ucKostentraegerKlient2 ucKostenträgerTransfer;
        
        public bool _isAbrechnungControlAlone = false;
        private bool _isMainSystem = false;
        private bool _isBewerberJN = false;
        
        private bool _lockValueChanges = false;
        public bool isLoaded = false;

        public ucKlientStammdaten MainWindow = null;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public Nullable<DateTime> dEntlassungszeitpunktOrig = null;
        public Nullable<Guid> IDAufenthaltEntlassen = null;







        public ucAbrechAufenthKlient()
        {
            InitializeComponent();
        }

        public void initControl(bool isAbrechnungControlAlone, bool isMainSystem, bool isBewerberJN)
        {

            if (this.isLoaded)
                return;

            this._isAbrechnungControlAlone = isAbrechnungControlAlone;
            this._isMainSystem = isMainSystem;
            this._isBewerberJN = isBewerberJN;

            if (this._isAbrechnungControlAlone)
            {
                this.panelAufnahmedatum.Visible = false;
                this.panelTop.Visible = false;
                this.panelAufenthalshistorie.Visible = true;
                //this.dtpAufnahmedatum.Enabled = false;

                this.ucKostenträgerGrundl = new PMDS.GUI.Kostentraeger.ucKostentraegerKlient2();
                this.ucKostenträgerGrundl.Dock = DockStyle.Fill;
                this.panelGrundleistung.Controls.Add(this.ucKostenträgerGrundl);
                this.ucKostenträgerGrundl.initControl();
                this.ucKostenträgerGrundl.ValueChanged += new System.EventHandler(this.OnValueChanged);

                this.ucKostenträgerTransfer = new PMDS.GUI.Kostentraeger.ucKostentraegerKlient2();
                this.ucKostenträgerTransfer.Dock = DockStyle.Fill;
                this.panelTransfer.Controls.Add(this.ucKostenträgerTransfer);
                this.ucKostenträgerTransfer.initControl();
                this.ucKostenträgerTransfer.TransferKostentraegerJN = true;
                this.ucKostenträgerTransfer.ValueChanged += new System.EventHandler(this.OnValueChanged);

                this.panelZahler.Visible = true;
            }
            else if (this._isBewerberJN )
            {
                this.panelZahler.Visible = false;
                this.panelTop.Visible = false;
                this.panelUnten.Visible = false;
            }
            else
                this.panelZahler.Visible = false;

            this.isLoaded = true;
        }

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
                _valueChangeEnabled = false;
                _klient = value;
                ucVersichrungsdaten12.Klient = value;
                _pflegestufe = new KlientPflegegeldstufe();
                UpdateGUI();
                if (this._isAbrechnungControlAlone)
                {
                    ucKostenträgerGrundl.IDPatient = _klient.ID;
                    ucKostenträgerTransfer.IDPatient = _klient.ID;
                }

                this.abrechnungHasChanged = false;
                _valueChangeEnabled = true;
                InitErrorProvider();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ucVersichrungsdaten Versichrungsdaten
        {
            get
            {
                return ucVersichrungsdaten12;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PMDS.GUI.Klient.dsKlientPflegestufe.PatientPflegestufeRow CurrentPatientPflegestufeRow
        {
            get
            {
                return (PMDS.GUI.Klient.dsKlientPflegestufe.PatientPflegestufeRow)UltraGridTools.CurrentSelectedRow(gridPatPflegestufen);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                ucVersichrungsdaten12.ReadOnly = value;
                SetReadOnly();
            }
        }

        public void resetColor()
        {
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.txtVersNr);
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.cboSozVersStatus);
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.cboSozVersLeerGrund);
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.txtSozVersMitversichertBei);
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.cboEinrichtungen);
            GuiUtil.resetColor2(this.ucVersichrungsdaten12.cmbKlasse);
        }


        public void UpdateGUI()
        {
            this._lockValueChanges = true;

            this.resetColor();
            if (!_isAbrechnungControlAlone)
            {
                if (Klient.Aufenthalt != null)
                {
                    dtpAufnahmedatum.Value = Klient.Aufenthalt.Aufnahmezeitpunkt; 
                    txtAusgZahlung.Value = Convert.ToInt32(Klient.Aufenthalt.Ausgleichszahlung * 100); 
                }
                else
                {
                    dtpAufnahmedatum.Value = null;
                    txtAusgZahlung.Value = 0;
                }
            }
            else
            {
                string xy = "";
                dtpAufnahmedatum.Visible = false;
                txtAusgZahlung.Visible = false;
            }


            //Befreiungen
            cbPensionTeilAntrag.Checked = Klient.PensionsteilungsantragJN;
            dtPensTeilAntrag.Value = Klient.DatumPensionsteilungsantrag;
            cbTelBefr.Checked = Klient.TelefongebuehrbefreiungJN;
            cbFernsehBefr.Checked = Klient.FernsehgebuehrbefreiungJN;

            //Grig Patient Pflegestufen
            txtKliNr.Text = Klient.Klientennummer;

            gridPatPflegestufen.DataSource = Klient.PATIENTPFLEGESTUFE.ALL;
            RefreshPflegeStufeValueList();

            if (Klient.AufenthaltZusatz.Count > 0)
            {
                cbSozilhBesch.Checked = Klient.AufenthaltZusatz[0].SozialhilfeBescheidJN;

                if (Klient.AufenthaltZusatz[0].IsSozialhilfeAntragDatumNull())
                    dtSoziAntragDatum.Value = null;
                else
                    dtSoziAntragDatum.Value = Klient.AufenthaltZusatz[0].SozialhilfeAntragDatum;
                txtSozilGZ.Text = Klient.AufenthaltZusatz[0].SozialhilfeBescheidGZ;
            }
            else
            {
                cbSozilhBesch.Checked = false;
                dtSoziAntragDatum.Value = DBNull.Value;
                txtSozilGZ.Text = "";
            }

            this.chkEinzelzimmer.Checked = Klient.Einzelzimmer;
            this.chkSelbstzahler.Checked = Klient.Selbstzahler;

            this.chkKürzungLetzterTagAnwesenheit.Checked = Klient.KürzungLetzterTagAnwesenheit;
            this.chkBehindertenausweis.Checked = Klient.Behindertenausweis;
            this.chkSozialcard.Checked = Klient.Sozialcard;
            Nullable<Guid> IDAdresseSub = Klient.IDAdresseSub;

            this.dEntlassungszeitpunktOrig = null;
            this.IDAufenthaltEntlassen = null;
            this.dtpEntlassungszeitpunkt.Value = null;
            this.lblEntlassungszeitpunkt.Visible = false;
            this.dtpEntlassungszeitpunkt.Visible = false;
            this.dtpEntlassungszeitpunkt.ReadOnly = true;
            //if (!this._isBewerberJN)
            //{
            using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
            {
                if (this.b.checkPatientExists(Klient.ID, db))
                {
                //os191224
                    var rPatInfo = (from p in db.Patient
                                where p.ID == Klient.ID
                                select new
                                { p.Nachname, 
                                    p.Vorname,
                                    p.Betreuungsstufe,
                                    p.BetreuungsstufeAb,
                                    p.BetreuungsstufeBis,
                                    p.TageAbweseneheitOhneKuerzung,
                                    p.ForensischerHintergrund}
                                    ).First();

                    this.cmbBetreuungsstufe.Value = null;
                    this.udteBetreuungsstufeAb.Value = null;
                    this.udteBetreuungsstufBis.Value = null;
                    this.chkForensicherHintergrund.Checked = false;

                    if (!String.IsNullOrWhiteSpace(rPatInfo.Betreuungsstufe))
                    {
                        this.cmbBetreuungsstufe.Text = rPatInfo.Betreuungsstufe.Trim();
                    }

                    if (rPatInfo.BetreuungsstufeAb != null)
                    {
                        this.udteBetreuungsstufeAb.DateTime = rPatInfo.BetreuungsstufeAb.Value;
                    }

                    if (rPatInfo.BetreuungsstufeBis != null)
                    {
                        this.udteBetreuungsstufBis.DateTime = rPatInfo.BetreuungsstufeBis.Value;
                    }

                    if (rPatInfo.ForensischerHintergrund != null)
                    {
                        this.chkForensicherHintergrund.Checked = (bool) rPatInfo.ForensischerHintergrund;
                    }
                    else
                    {
                        this.chkForensicherHintergrund.Checked = false;
                    }

                    this.numTageAbweseneheitOhneKuerzung.Value = rPatInfo.TageAbweseneheitOhneKuerzung;

                    if (PMDS.Global.historie.HistorieOn)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthaltEntlassen = this.b.getAufenthalt(PMDS.Global.ENV.IDAUFENTHALT, db);
                        this.dtpEntlassungszeitpunkt.DateTime = rAufenthaltEntlassen.Entlassungszeitpunkt.Value;
                        this.dEntlassungszeitpunktOrig = this.dtpEntlassungszeitpunkt.DateTime;
                        this.lblEntlassungszeitpunkt.Visible = true;
                        this.dtpEntlassungszeitpunkt.Visible = true;
                        this.IDAufenthaltEntlassen = rAufenthaltEntlassen.ID;
                    }
                }
            }

            if (PMDS.Global.historie.HistorieOn)
            {
                bool bKlientEntlassungszeitpunktÄndern = ENV.HasRight(UserRights.KlientEntlassungszeitpunktÄndern);
                if (bKlientEntlassungszeitpunktÄndern || PMDS.Global.ENV.adminSecure)
                {
                    this.dtpEntlassungszeitpunkt.ReadOnly = false;
                }
                else
                {
                    this.dtpEntlassungszeitpunkt.ReadOnly = true;
                }
            }
            else
            {
                this.dtpEntlassungszeitpunkt.ReadOnly = true;
            }
            if (this._isAbrechnungControlAlone)
            {
                this.dtpEntlassungszeitpunkt.ReadOnly = true;
            }

            Patient pat = new Patient();
            this.readPatientFelderSonstige(Klient.ID );


            this._lockValueChanges = false ;
        }

        public void readPatientFelderSonstige(System.Guid IDPatient)
        {
            Patient pat = new Patient();
            this.uCheckEditorAbwesenheitenHändischBerech.Checked = pat.abwHändBerechJN(IDPatient);
        }

        private void RefreshPflegeStufeValueList()
        {
            _pflegestufe.Read();
            gridPatPflegestufen.DisplayLayout.ValueLists.Clear();
            KlientGuiAction.AddTextTextValuListFromPflegestufe(_pflegestufe.ALL, gridPatPflegestufen, "IDPflegegeldstufe");
            KlientGuiAction.AddTextTextValuListFromPflegestufe(_pflegestufe.ALL, gridPatPflegestufen, "IDPflegegeldstufeAntrag");
        }

        public void UpdateDATA()
        {
            if (!this._isAbrechnungControlAlone)
            {
                if (Klient.Aufenthalt != null)
                {
                    Klient.Aufenthalt.Aufnahmezeitpunkt = dtpAufnahmedatum.DateTime; //Neu nach 08.05.2007
                    Klient.Aufenthalt.Ausgleichszahlung = Convert.ToDouble(Math.Round((double)((int)txtAusgZahlung.Value) / 100, 2, MidpointRounding.AwayFromZero)); //Neu nach 12.12.2007 MDA
                }  
            }

            Klient.PensionsteilungsantragJN = cbPensionTeilAntrag.Checked;
            Klient.DatumPensionsteilungsantrag = dtPensTeilAntrag.Value;
            Klient.TelefongebuehrbefreiungJN = cbTelBefr.Checked;
            Klient.FernsehgebuehrbefreiungJN = cbFernsehBefr.Checked;                           

            if (Klient.AufenthaltZusatz.Count > 0)
            {
                Klient.AufenthaltZusatz[0].SozialhilfeBescheidJN = cbSozilhBesch.Checked;

                if (dtSoziAntragDatum.Value != null)
                    Klient.AufenthaltZusatz[0].SozialhilfeAntragDatum = (DateTime)dtSoziAntragDatum.Value;
                else
                    Klient.AufenthaltZusatz[0].SetSozialhilfeAntragDatumNull();
                Klient.AufenthaltZusatz[0].SozialhilfeBescheidGZ = txtSozilGZ.Text.Trim();
            }
            else
            {
                cbSozilhBesch.Checked = false;
                dtSoziAntragDatum.Value = DBNull.Value;
                txtSozilGZ.Text = "";
            }

            Klient.Einzelzimmer = this.chkEinzelzimmer.Checked;
            Klient.Selbstzahler = this.chkSelbstzahler.Checked;

            Klient.KürzungLetzterTagAnwesenheit = this.chkKürzungLetzterTagAnwesenheit.Checked;
            Klient.Behindertenausweis = this.chkBehindertenausweis.Checked;
            Klient.Sozialcard = this.chkSozialcard.Checked;
            Klient.Klientennummer = txtKliNr.Text.Trim();

            ucVersichrungsdaten12.UpdateDATA();
        }
        public bool save(bool mainSystm, bool isAbrechnung, bool isBewerberJN )
        {
            ReadOnly = false;
            if (!ValidateFields())
                {return false;}
            this.UpdateDATA();
            this.Write(mainSystm, isAbrechnung, isBewerberJN );
            return true;
        }

        private void InitErrorProvider()
        {
            errorProvider1.SetError(dtpAufnahmedatum, "");
            errorProvider1.SetError(dtpAufnahmedatum, "");
        }

        public bool ValidateFields()
        {
            try
            {
                bool bError = false;
                bool bInfo = true;

                if (_isAbrechnungControlAlone)
                {
                    PMDS.BusinessLogic.KlientDetails.searchLastEntlassenenAufenthalt = true;
                }
                if (Klient.Aufenthalt != null) //Neu nach 29.06.2007 MDA
                {
                    PMDS.BusinessLogic.KlientDetails.searchLastEntlassenenAufenthalt = false;

                    bool isWrong = false;
                    GuiUtil.ValidateField(dtpAufnahmedatum, (dtpAufnahmedatum.Text.Length > 0),
                        ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1, ref isWrong);

                    if (!bError)
                    {
                        isWrong = false;
                        GuiUtil.ValidateField(dtpAufnahmedatum, (dtpAufnahmedatum.DateTime <= DateTime.Now),
                                 QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen."), ref bError, bInfo, errorProvider1, ref isWrong);
                    }
                }

                if (this._isAbrechnungControlAlone)
                {
                    if (!bError)
                        bError = !ucKostenträgerGrundl.ValidateFields();
                    if (!bError)
                        bError = !ucKostenträgerTransfer.ValidateFields();
                }

                return !bError;
            }
            catch (Exception ex)
            {
                PMDS.BusinessLogic.KlientDetails.searchLastEntlassenenAufenthalt = false;
                throw new Exception("ucAbrechAufenthaltKlient.ValidateFields: " + ex.ToString());
            }
        }
        public bool validateDataVersNr(ref string MessageTxt, bool withMsgBox)
        {
            try
            {
                PMDSBusinessUI bUI = new PMDSBusinessUI();
                return bUI.validateDataVersNr(this.ucVersichrungsdaten12, this);
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucAbrechAufenthaltKlient.validateDataVersNr: " + ex.ToString());
            }
        }

        public bool Write(bool mainSystm, bool isAbrechnung, bool isBewerberJN)
        {
            if (this._isAbrechnungControlAlone)
            {
                this.Klient.Write(mainSystm, isAbrechnung, isBewerberJN);
                Patient pat = new Patient();
                pat.updatePatient(Klient.ID, this.uCheckEditorAbwesenheitenHändischBerech.Checked);

                if (Klient.Aufenthalt == null)
                    Klient.newAufenthalt();
                if (!isBewerberJN) Klient.WriteAufenthalt(false);
                
                //this.Klient.WriteAufenthalt(false);
                ucKostenträgerGrundl.Save();
                ucKostenträgerTransfer.Save();
            }

            this.abrechnungHasChanged = false;
            return true;
        }

        private void SetReadOnly()
        {
            dtpAufnahmedatum.ReadOnly = ReadOnly; //Neu nach 08.05.2007
            cbFernsehBefr.Enabled = !ReadOnly;
            cbPensionTeilAntrag.Enabled = !ReadOnly;
            cbTelBefr.Enabled = !ReadOnly;
            txtKliNr.Enabled = !ReadOnly;
            // Klient.AbwesenheitenHändischBerech = !ReadOnly;
            dtPensTeilAntrag.ReadOnly = ReadOnly;
            btnAddPflStufe.Enabled = !ReadOnly;
            btnDelPflStufe.Enabled = !ReadOnly;
            btnUpdatePaPflegestufen.Enabled = !ReadOnly;
            
            if (!ReadOnly)
                RequiredFields();
        }

        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(dtpAufnahmedatum);
        }

        private bool AddPatientPflegestufe()
        {
            try
            {
                frmPflegestufe frm = new frmPflegestufe();
                DialogResult res = frm.ShowDialog();

                if (frm.NEUE_PFLEGESTUFE)
                {
                    gridPatPflegestufen.BeginUpdate();
                    RefreshPflegeStufeValueList();
                    gridPatPflegestufen.EndUpdate();
                }

                if (res != DialogResult.OK)
                    return false;

                gridPatPflegestufen.BeginUpdate();
                Klient.PATIENTPFLEGESTUFE.New(frm.PFLEGESTUFE, frm.GUELTIG_AB, frm.ANTRAGSDATUM, frm.BEANTRAGTEPFLEGESTUFE, frm.BESCHEIDDATUM);
                gridPatPflegestufen.EndUpdate();

                if (PMDS.Global.historie.HistorieOn)
                {
                    this.MainWindow.MainWindow.MainWindow.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdatepatientPflegestufe()
        {
            if (_pflegestufe.ALL.Pflegegeldstufe.Rows.Count > 0 && CurrentPatientPflegestufeRow != null)
            {
                
                frmPflegestufe frm = new frmPflegestufe();
                frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
                frm.PFLEGESTUFE_ROW = CurrentPatientPflegestufeRow;
                DialogResult res = frm.ShowDialog();

                if (frm.NEUE_PFLEGESTUFE)
                {
                    gridPatPflegestufen.BeginUpdate();
                    RefreshPflegeStufeValueList();
                    gridPatPflegestufen.EndUpdate();
                }
                
                if (res != DialogResult.OK)
                    return false;

                frm.UpdateData();
                if (PMDS.Global.historie.HistorieOn)
                {
                    this.MainWindow.MainWindow.MainWindow.Save();
                }

                return true;
            }

            return false;
        }

        private bool Delete()
        {
            DataRow[] rows = KlientGuiAction.CurrentSelectedRows(gridPatPflegestufen);

            if (rows != null)
            {

                DialogResult res = KlientGuiAction.DelDialogResult(rows.Length);
                if (res == DialogResult.Yes)
                {
                    foreach (DataRow r in rows)
                    {
                        ((PMDS.GUI.Klient.dsKlientPflegestufe.PatientPflegestufeRow)r).Delete();
                    }
                    return true;
                }
            }
            return false;
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges) return;
            abrechnungHasChanged = true;
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, args);
        }

        protected void OnVersDatenChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges) return;
            if (_valueChangeEnabled && (VersDatenChanged != null))
                VersDatenChanged(sender, args);
        }

        private void gridPatPflegestufen_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (Delete() && ValueChanged != null)
                    ValueChanged(sender, e);
            }
        }

        private void gridPatPflegestufen_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (!ReadOnly)
            {
                if (UpdatepatientPflegestufe())
                    ValueChanged(sender, e);
            }
        }

        private void uCheckEditorAbwesenheitenHändischBerech_CheckedChanged(object sender, EventArgs e)
        {
            abrechnungHasChanged = true;
            if (_valueChangeEnabled && (ValueChanged != null))
                ValueChanged(sender, e);
        }

        public async Task<bool> setControlsAktivDisable2(bool bOn)
        {
            if (this._isMainSystem)
            {
                PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn).ConfigureAwait(false);
                PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBox9, bOn).ConfigureAwait(false);
                PMDS.GUI.BaseControls.historie.OnOffControls(this.ucVersichrungsdaten12.ultraGroupBoxVersicherungsdaten, bOn).ConfigureAwait(false);
                PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn).ConfigureAwait(false);

                if (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.KlientenAktStammdatenAendern))
                {
                    this.panelButtons.Visible = true;
                    btnAddPflStufe.Visible = true;
                    btnDelPflStufe.Visible = true;
                    btnUpdatePaPflegestufen.Visible = true;
                }
                else
                {
                    this.panelButtons.Visible = !bOn;
                    btnAddPflStufe.Visible = !bOn;
                    btnDelPflStufe.Visible = !bOn;
                    btnUpdatePaPflegestufen.Visible = !bOn;
                }
            }
            return true;
        }

        private void btnAddPflStufe_Click(object sender, EventArgs e)
        {
            if (AddPatientPflegestufe())
                ValueChanged(sender, e);
        }

        private void btnDelPflStufe_Click(object sender, EventArgs e)
        {
            if (CurrentPatientPflegestufeRow != null) //Neu nach 27.04.2007
            {
                UltraGridTools.DeleteCurrentSelectedRow(gridPatPflegestufen, false);
                if (PMDS.Global.historie.HistorieOn)
                {
                    this.MainWindow.MainWindow.MainWindow.Save();
                }
                ValueChanged(sender, e);
            }
        }

        private void btnUpdatePaPflegestufen_Click(object sender, EventArgs e)
        {
            if (UpdatepatientPflegestufe())
                ValueChanged(sender, e);
        }

        private void openHistorie()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                frmPatientHistorie auf = new frmPatientHistorie(this._klient.ID, true);
                auf.ShowDialog();
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

        private void btnHistorie_Click(object sender, EventArgs e)
        {

            this.openHistorie();
        }

        private void dtpEntlassungszeitpunkt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.OnValueChanged(sender, e);

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

        private void ucVersichrungsdaten12_Load(object sender, EventArgs e)
        {

        }
    }
}
