using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinTree;
//using Infragistics.Win.UltraWinGrid;
//using S2.Controls;
using Infragistics.Win;
using System.IO;
using PMDS.DB;
using System.Linq;
using Infragistics.Win.UltraWinToolTip;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucPflegeplan2 : QS2.Desktop.ControlManagment.BaseControl, ISave, IReadOnly
    {
        //Neu nach 12.09.2008 MDA
        private enum PflegePlanState
        {
            Bearbeiten,
            Hinzufuegen
        }


        private PflegePlanModi _PflegePlanMode = PflegePlanModi.PflegePlan;
        private Guid _IDAufenthalt;
        private Aufenthalt _Aufenthalt;
        private Patient _patient;
        private PMDS.BusinessLogic.PflegePlan _PflegePlan;
        private bool _bReadOnly = false;
        private bool _showerledigteatstartup = false;  //Gernot%%
        private bool _bUseTransaction = true;
        private bool _bChangeInProgress = false;             // Signalisiert dass etwas verändert wurde (zum Speichern etc...)
        private bool _ContentChanged = false;
        private PDxSelectionArgs _AktivePDx = null;
        private bool _RessourceChanged = false;
        private bool _valueChangeEnabled = true;
        private Zeitbereich _Zeitbereich = new Zeitbereich();
        private dsZeitbereich.ZeitbereichDataTable _ZeitbereichDT = new dsZeitbereich.ZeitbereichDataTable();

        public event evPlanungÄndern planungÄndern;
        
        public event EventHandler ValueChanged;
        //Neu nach 12.09.2008 MDA
        private PflegePlanModus _PflegePlanModus = PflegePlanModus.Normal;
        private PflegePlanState _PfState = PflegePlanState.Bearbeiten;
        private bool _AddMissingASZM = false;
        private IWizardPage _CurrentTransferPDxControl;
        private Control _CurrentControl = null;
        //Neu nach 09.10.2008 MDA
        private bool _ZusateintragChanged = false;
        private ZusatzGruppe _ZusatzGruppe;

        public static System.Collections.Generic.List<DB.PMDSBusiness.cVerordnungen> lstVerordnungen = new List<DB.PMDSBusiness.cVerordnungen>();
        public PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();






        public ucPflegeplan2()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;
            UpdateLegend();
            ucPflegeplanTreeView1.ExpandAll = false;
            ucPflegeplanTreeView1.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
            ucPflegeplanTreeView1.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            ucASZMTransfer21.EditMode = true;
            ucASZMTransferPDx1.Visible = false;
            ucWunde1.Visible = false;
            _CurrentTransferPDxControl = (IWizardPage)ucASZMTransferPDx1;
            ucWunde1.Dock = DockStyle.Fill;
            ucAdditionalASZMToPDx1.Dock = DockStyle.Top;

            ENV.ZusatzeintragChanged += new ZusatzeintragChangedDelegate(ENV_ZusatzeintragChanged);

            this.btnOnOffInfo.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, QS2.Resources.getRes.ePicTyp.ico);
            this.OnOffInfo("0");

            this.btnMedikamente.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Medikamente_01, QS2.Resources.getRes.ePicTyp.ico);
            this.btnVerordnungen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verordnungen_03, QS2.Resources.getRes.ePicTyp.ico);
            this.btnVerordnungen2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verordnungen_03, QS2.Resources.getRes.ePicTyp.ico);

            this.ucPflegeplanTreeView1.mainWindow = this;
            this.ucASZMTransfer21.mainWindow = this;

            UltraToolTipInfo info = new UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnVerordnungen, info);
            this.ultraToolTipManager1.SetUltraToolTip(this.btnVerordnungen2, info);

            info = new UltraToolTipInfo();
            info.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente");
            this.ultraToolTipManager1.SetUltraToolTip(this.btnMedikamente, info);

        }

        

        void ENV_ZusatzeintragChanged(bool changed)
        {
            if (!Visible) return;
            _ZusateintragChanged = changed;

            this.btnPDx.Enabled = !changed;
            this.btnEndPDx.Enabled = !changed;
            this.btnAddMissingASZM.Enabled = !changed;

            if (changed)
            {
                cbErledigte.Enabled = false;
                grpFilter.Enabled = false;
            }
            else
            {
                cbErledigte.Enabled = !_ContentChanged;
                grpFilter.Enabled = _ContentChanged;

                if (_ContentChanged)
                    ContentChanged();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModi PflegePlanMode
        {
            get { return _PflegePlanMode; }
            set 
            { 
                _PflegePlanMode = value;
                ucASZMTransfer21.PflegePlanMode = value;
                PrepareControlsForMode(); 
            }
        }

        //Neu nach 12.09.2008 MDA
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return _PflegePlanModus; }
            set
            {
                _PflegePlanModus = value;
                _CurrentTransferPDxControl = _PflegePlanModus == PflegePlanModus.Normal ? (IWizardPage)ucASZMTransferPDx1 : (IWizardPage)ucWunde1;
                ucPflegeplanTreeView1.PFLEGEPLANMODUS = _PflegePlanModus;
                ucPDxSearch21.PFLEGEPLANMODUS = _PflegePlanModus;
                ucASZMTransferPDx1.PFLEGEPLANMODUS = _PflegePlanModus;
                _PfState = PflegePlanState.Bearbeiten;
                ucASZMTransferPDx1.Visible = false;
                ucWunde1.Visible = false;
                this.btnPDx.Text = _PflegePlanModus == PflegePlanModus.Normal ? "&Pflegedefinitionen hinzufügen" : "&Wunden hinzufügen";
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Der zu bearbeitende Pflegeplan (Pflegeplan ist Aufenthaltsbezogen)
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Aufenthalt AUFENTHALT
        {
            get
            {
                return _Aufenthalt;
            }
            set
            {
                if (DesignMode)
                    return;

                if (value == null)
                    return;

                _PflegePlan = null;
                _ZusatzGruppe = null;
                _Aufenthalt = value;
                _IDAufenthalt = _Aufenthalt.ID;
                _patient = new Patient(_Aufenthalt.IDPatient);
                _ZeitbereichDT = _Zeitbereich.Read();
                _PfState = PflegePlanState.Bearbeiten;
                RefreshControl();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Der zu bearbeitende Pflegeplan (Pflegeplan ist Aufenthaltsbezogen)
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAUFENTHALT
        {
            get
            {
                return _IDAufenthalt;
            }
            set
            {
                this.btnVerordnungen.Visible = (this._PflegePlanModus == PflegePlanModus.Wunde);
                this.btnMedikamente.Visible = (this._PflegePlanModus == PflegePlanModus.Wunde);
        
                if (!ENV.lic_VO)
                {
                    this.btnVerordnungen.Visible = false;
                }

                if (value == Guid.Empty)
                    return;
                _IDAufenthalt = value;
                if (value == Guid.Empty)
                    return;
                if (DesignMode)
                    return;

                _Aufenthalt = new Aufenthalt(_IDAufenthalt);
                _PflegePlan = null;
                _ZusatzGruppe = null;
                _patient = new Patient(AUFENTHALT.IDPatient);
                _ZeitbereichDT = _Zeitbereich.Read();
                _PfState = PflegePlanState.Bearbeiten;
                RefreshControl();
            }
        }

        public bool ShowErledigteAtStartup
        {
            get { return _showerledigteatstartup; }
            set { _showerledigteatstartup = value; }
        }

        #region ISave

        public void AllowEdit(bool bSwitch)
        {
            this.btnSavexyxyxy.Enabled = bSwitch;
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Speichert die Änderungen 
        /// </summary>
        //----------------------------------------------------------------------------
        public bool Save()
        {
            bool retVal = true;
            if (_PflegePlan != null)
            {
                //Änderungen der bereits ausgewählte PDX oder ASZM übernehmen
                retVal = PflegePlanTools.BeforePflegePlanNodeSelected((ITreeview)ucPflegeplanTreeView1, ucASZMTransfer21, _CurrentTransferPDxControl, tbRessourcen, lblError, false);
                
                if(retVal)
                    retVal = ValidateFields();

                if (retVal)
                {
                    if (ucPflegeplanTreeView1.ARG != null || ucPflegeplanTreeView1.PDX_SARG != null)
                    {
                        if (ucPflegeplanTreeView1.IsPDx)
                        {
                            _CurrentTransferPDxControl.UpdateDATA();
                        }
                        else
                        {
                            ucASZMTransfer21.UpdateDATA();
                        }
                    }

                    if (!this.validateData())
                    {
                        return false;
                    }

                    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                    {


                        if (PFLEGEPLANMODUS == PflegePlanModus.Wunde)
                        {
                            if (!ucWunde1.ucWunddoku1.ValidateFields())
                                return false;
                        }


                        //if (ucPflegeplanTreeView1.PDX_SELARGS == null || ucPflegeplanTreeView1.ARGS == null) return;
                        PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                        b.savePlanung(ucPflegeplanTreeView1.PDX_SELARGS, ENV.CurrentIDPatient, false, this.IDAUFENTHALT, this.tbRessourcen.Text.Trim(), ref ucPflegeplan2.lstVerordnungen);
                        b.savePlanungVerordnungen(ref ucPflegeplan2.lstVerordnungen);

                        string Protocoll = "";
                        b.correctPdxBezeichnungInInterventionen(ENV.CurrentIDPatient, false, this.IDAUFENTHALT, false, ref Protocoll);

                        if (PFLEGEPLANMODUS == PflegePlanModus.Wunde)
                        {
                            if (ucWunde1.IDAufenthaltPDx == Guid.Empty)
                            {
                                if (!this.checkWundKopfIsSaved())  //nur bei Neuanlage einer Wunde - nicht bei Änderung.
                                {
                                    System.Collections.Generic.List<Guid> lstIDWichtig = PMDS.Global.Tools.GetWichtigFuerDefaults(eDekursDefaults.NeueWunde.ToString());

                                    string Klartext = this.ucPflegeplanTreeView1.ActivPDX.Klartext;
                                    string Lokalisierung = this.ucPflegeplanTreeView1.ActivPDX.Lokalisierung;
                                    string LokalisierungSeite = this.ucPflegeplanTreeView1.ActivPDX.LokalisierungSeite;
                                    string txtDekursWundeNeu = Klartext + ", " + Lokalisierung + " " + LokalisierungSeite;

                                    //Dekurs "Neue Wunde" schreiben
                                    PMDS.db.Entities.PflegeEintrag rPflegeEintrag = this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Wunde wurde erfasst.") + "\n\r" + txtDekursWundeNeu, false, ENV.CurrentIDPatient, PflegeEintragTyp.WUNDEN);
                                    PMDS.db.Entities.PflegeEintrag rPEUpdate2 = b.getPflegeEintrag(rPflegeEintrag.ID, db);
                                    rPEUpdate2.IDGruppe = Guid.NewGuid();

                                    foreach (Guid IDWichtig in lstIDWichtig)    //Dekurs "Neue Wunde" mit IDWichtig schreiben
                                    {
                                        PMDS.db.Entities.PflegeEintrag rPflegeEintragWichtig = this.b.writeDekurs(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Wunde wurde erfasst.") + "\n\r" + txtDekursWundeNeu, false, ENV.CurrentIDPatient, PflegeEintragTyp.WUNDEN);
                                        PMDS.db.Entities.PflegeEintrag rPEUpdate = b.getPflegeEintrag(rPflegeEintragWichtig.ID, db);
                                        rPEUpdate.IDWichtig = IDWichtig;
                                        rPEUpdate.Wichtig = 0;
                                        rPEUpdate.CC = true;
                                        rPEUpdate.IDGruppe = rPEUpdate2.IDGruppe;
                                        rPEUpdate.IDDekurs = rPEUpdate2.ID;
                                    }
                                    db.SaveChanges();
                                }
                            }
                            ucWunde1.Save(); 
                        }

                        if (_ZusatzGruppe != null)
                            _ZusatzGruppe.Write();  
                    }
                }
            }      
            
            if (retVal)
            {
                _ContentChanged = false;
                _bChangeInProgress = false;
                cbErledigte.Enabled = true;
                grpFilter.Enabled = true;
                //Nach dem Speichern die Daten aktualisieren um beendete zuzeigen wenn beendete anzeigen ausgewählt ist.
                //und neue ASZM's die IDPflegePlan zu verspeichern.
                RefreshControl();
            }
            return retVal;
        }


        public bool checkWundKopfIsSaved()
        {
            try
            {
                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count > 1)
                {
                    throw new Exception("btnMedikamente_Click: ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count < 1 not allowed!");
                }
                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count == 1)
                {
                    if (this.ucPflegeplanTreeView1.ActivPDX.IDAufenthaltPDX.Equals(System.Guid.Empty))
                    {
                        //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die PDx!", "", MessageBoxButtons.OK);
                        return false;
                    }

                    dsWunde.WundeKopfRow rWundeKopf = (dsWunde.WundeKopfRow)ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows[0];
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = db.WundeKopf.Where(p => p.ID == rWundeKopf.ID);
                        if (tWundeKopf.Count() == 1)
                        {
                            return true;
                        }
                        else if (tWundeKopf.Count() > 1)
                        {
                            throw new Exception("ucPflegeplan22.btnMedikamente_Click: tWundeKopf.Count() > 1 for IDWundePos " + rWundeKopf.ID.ToString() + "!");
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("checkWundKopfIsSaved: " + ex.ToString());
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen speichern bzw. Eintrag zu Anzeige ind Interventionsliste
        /// [lth]
        /// </summary>
        //----------------------------------------------------------------------------
        private void speichernPflegeeintrag(PflegeEintragTyp typ)
        {
            if (!ucPflegeplanTreeView1.IsPDx)
            {
                ASZMSelectionArgs arg = ucPflegeplanTreeView1.ARG;
                if (arg != null)
                {
                    PflegeEintrag pe = new PflegeEintrag();
                    pe.New();
                    pe.IDAufenthalt = ENV.IDAUFENTHALT;
                    pe.IDBenutzer = ENV.USERID;
                    pe.IDEintrag = arg.IDEintrag;
                    pe.IDEvaluierung = ENV.CurrentIDEvaluierung;
                    pe.IDPflegePlan = arg.IDPflegePlan;
                    pe.DatumErstellt = DateTime.Now;
                    pe.DurchgefuehrtJN = true;
                    pe.EintragsTyp = typ;
                    pe.EvalStatus = ZielEvaluierungsStatus.Erreicht_weiterwiebisher;
                    pe.EintragsTyp = PflegeEintragTyp.PLANUNG;
                    pe.PflegeplanText = "Planungsänderung";
                    pe.Text = "Planungsänderung";
                    pe.Wichtig = PflegeEintragWichtig.NONE;
                    pe.Zeitpunkt = DateTime.Now;
                    pe.IDWichtig = Guid.Empty;                      // wegen FK constraint
                    pe.IDBerufsstand = ENV.BERUFID;               
                    pe.Write();

                    PMDS.DB.DBPflegePlan db = new PMDS.DB.DBPflegePlan();
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liest die Werte ernauert aus dre DB ohne vorher zu speichern
        /// </summary>
        //----------------------------------------------------------------------------
        public void Undo()
        {
            _ContentChanged = false;
            _bChangeInProgress = false;
            cbErledigte.Enabled = true;
            grpFilter.Enabled = true;
            _ZusateintragChanged = false;
            _PfState = PflegePlanState.Bearbeiten;
            if (_PflegePlan == null)
                return;
            ucWunde1.Undo();
            RefreshControl();
            this.setUIPanelVOMedikamete();
        }

        public bool IsChanged
        {
            get { return _ContentChanged; }
        }

        public bool ValidateFields()
        {
            bool bError = false;
            foreach (PDxSelectionArgs pdxSA in ucPflegeplanTreeView1.PDX_SELARGS)
            {
                bError = !PflegePlanTools.ValidatePDxArg(pdxSA);

                if (bError)
                {
                    ucPflegeplanTreeView1.PDX_SARG = pdxSA;
                    _CurrentTransferPDxControl.ValidateFields();
                }

                //ASZM Ebene prüfen
                if (!bError && pdxSA.ARGS != null)
                {
                    foreach (ASZMSelectionArgs a in pdxSA.ARGS)
                    {
                        bError = !PflegePlanTools.ValidateASZMARGS(a, _ZusatzGruppe);

                        if (bError)
                        {
                            ucPflegeplanTreeView1.ARG = a;
                            ucASZMTransfer21.ValidateFields();
                            break;
                        }
                    }
                }

                if (bError) break;
            }

            return !bError;
        }
        #endregion

        public bool ReadOnly
        {
            get
            {
                return _bReadOnly;
            }
            set
            {
                _bReadOnly = value;
                if (_bReadOnly == true)   //Gernot%% nur bei Historie, sonst haben alle Pflegehelfer die beendeten vor Augen
                {
                    if (_showerledigteatstartup && PMDS.Global.historie.HistorieOn)
                        cbErledigte.Checked = true;
                    //btnPrint.Visible = false;
                }
                else
                    btnPrint.Visible = true;
            }
        }


        private void InsertPPEntrysxyxy()
        {
            if (ucPflegeplanTreeView1.ARG != null || ucPflegeplanTreeView1.PDX_SARG != null)
            {
                if (ucPflegeplanTreeView1.IsPDx)
                {
                    _CurrentTransferPDxControl.UpdateDATA();
                }
                else
                {
                    ucASZMTransfer21.UpdateDATA();
                }
            }
            //if (ucPflegeplanTreeView1.PDX_SELARGS == null || ucPflegeplanTreeView1.ARGS == null) return;
            //System.Collections.Generic.List<Guid> lstIDPflegeplan = new List<Guid>();


            //List<dsPflegePlan.PflegePlanRow> list = new List<dsPflegePlan.PflegePlanRow>(); //Liste von Pflegaplan Rows die zu beenden sind
            //List<ASZMSelectionArgs> listArgs = new List<ASZMSelectionArgs>(); //Liste von ASZM's die zum Updaten oder Hinzuzufägen sind
            //dsPflegePlanPDx.PflegePlanPDxRow[] pfPDXRows;
            //dsPflegePlan.PflegePlanRow[] pfRows, pfRows2;
            //string erledigteAnzeigen = cbErledigte.Checked ? "" : " and ErledigtJN = 0 ";
            //bool zeitBereich;
            //foreach (PDxSelectionArgs pdxArg in ucPflegeplanTreeView1.PDX_SELARGS)
            //{
            //    if (pdxArg.ARGS == null || pdxArg.ErledigtJN) continue;
 
            //    pfPDXRows = (dsPflegePlanPDx.PflegePlanPDxRow[])_PflegePlan.PFLEGEPLANPDX.Select("IDAufenthaltPDX = '" + pdxArg.IDAufenthaltPDX.ToString() +
            //            "' and IDPDX = '" + pdxArg.IDPDX.ToString() + "'" + erledigteAnzeigen);

            //    foreach (dsPflegePlanPDx.PflegePlanPDxRow row in pfPDXRows)
            //    {
            //        pfRows = (dsPflegePlan.PflegePlanRow[])_PflegePlan.PFLEGEPLAN_EINTRAEGE.Select("ID = '" + row.IDPflegePlan.ToString() + "'" + erledigteAnzeigen);

            //        foreach (dsPflegePlan.PflegePlanRow r in pfRows)
            //        {
            //            if (r.ErledigtJN) continue;
            //            if (r.UntertaegigeJN && !r.IsIDUntertaegigeGruppeNull())
            //            {
            //                pfRows2 = (dsPflegePlan.PflegePlanRow[])_PflegePlan.PFLEGEPLAN_EINTRAEGE.Select("IDUntertaegigeGruppe = '" + r.IDUntertaegigeGruppe.ToString() + "'" + erledigteAnzeigen, "StartDatum");
            //                if (pfRows2.Length > 0)
            //                {
            //                    zeitBereich = pfRows2[0].IsIDZeitbereichNull() ? false : true;
            //                    foreach (ASZMSelectionArgs arg in pdxArg.ARGS)
            //                    {
            //                        if (arg.IsEditedFromuser)
            //                        {
            //                            lstIDPflegeplan.Add(arg.IDPflegePlan);

            //                            if (arg.UNTERTAEGIG != null)
            //                            {
            //                                if (arg.UNTERTAEGIG.Length != 1)
            //                                {
            //                                    string xy = "";
            //                                }
            //                            }

            //                            if (arg.ErledigtJN || arg.IDPflegePlan != r.ID) continue;
                                    
            //                            if (arg.UNTERTAEGIG != null || arg.ZEITBEREICH != null)
            //                            {
            //                                int n = 0;
            //                                if (arg.UNTERTAEGIG != null)
            //                                {
            //                                    if (zeitBereich)
            //                                    {
            //                                        foreach (dsPflegePlan.PflegePlanRow r2 in pfRows2)
            //                                            list.Add(r2);
            //                                    }
            //                                    else
            //                                        n = pfRows2.Length - arg.UNTERTAEGIG.Length;
            //                                }
            //                                else if (arg.ZEITBEREICH != null)
            //                                {
            //                                    if (!zeitBereich)
            //                                    {
            //                                        foreach (dsPflegePlan.PflegePlanRow r2 in pfRows2)
            //                                            list.Add(r2);
            //                                    }
            //                                    else
            //                                        n = pfRows2.Length - arg.ZEITBEREICH.Length;
            //                                }
            //                                if (n > 0)
            //                                {
            //                                    int idx = arg.UNTERTAEGIG != null ? arg.UNTERTAEGIG.Length : arg.ZEITBEREICH.Length;
            //                                    while (idx < pfRows2.Length)
            //                                    {
            //                                        list.Add(pfRows2[idx]);
            //                                        idx++;
            //                                    }
            //                                }
            //                            }
            //                            else if (pfRows2[0].OhneZeitBezug != arg.OhneZeitBezug)
            //                            {
            //                                foreach (dsPflegePlan.PflegePlanRow r2 in pfRows2)
            //                                    list.Add(r2);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else 
            //            {
            //                foreach (ASZMSelectionArgs arg in pdxArg.ARGS)
            //                {
            //                    if (arg.ErledigtJN || arg.IDPflegePlan != r.ID) continue;
            //                    if (arg.IsEditedFromuser)
            //                    {
            //                        if (r.OhneZeitBezug != arg.OhneZeitBezug)
            //                            list.Add(r);
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    foreach (ASZMSelectionArgs arg in pdxArg.ARGS)
            //    {
            //        if (arg.ErledigtJN) continue;
            //        if (!arg.IsEditedFromuser)
            //        {
            //            continue;
            //        }

            //        arg.LokalisierungJN = pdxArg.LokalisierungJN;
            //        arg.Lokalisierung = pdxArg.LokalisierungJN ? pdxArg .Lokalisierung : "";
            //        arg.LokalisierungSeite = pdxArg.LokalisierungJN ? pdxArg.LokalisierungSeite : "";
            //        arg.WundeJN = pdxArg.WundeJN;

            //        if (arg.StartDatum.Year == 1900)
            //        {
            //            //if (pdxArg.StartDatum.Year == 1900)
            //            //{

            //            //}
            //            arg.StartDatum = pdxArg.StartDatum;
            //            arg.Resourceklient = pdxArg.Resourceklient;      //[lth]
            //        }

            //        //if (arg.StartDatum.Year == 1900)
            //        //{
            //        //    arg.StartDatum = DateTime.Now;
            //        //}

            //        if (arg.IDPDX == Guid.Empty)
            //            arg.ISPDX = false;
            //        else
            //            arg.ISPDX = true;

            //        if (arg.IDUntertaegigGruppe != Guid.Empty)
            //        {
            //            foreach (dsPflegePlan.PflegePlanRow r in list)
            //            {
            //                if (!r.IsIDUntertaegigeGruppeNull() && r.IDUntertaegigeGruppe == arg.IDUntertaegigGruppe)
            //                {
            //                    //Alle Einträge in list werden beendet. Daher alle ARG's mit gleicher IDUntertaegigGruppe müssen initialsiert werden
            //                    //Daten vorbereiten für ein Insert.
            //                    arg.IDUntertaegigGruppe = Guid.Empty;
            //                    arg.IDPflegePlan = Guid.Empty;
            //                }
            //            }
            //        }

            //        listArgs.Add(arg);
            //    }
            //}
            
            ////rausgenommen -> unnötig das bereits beim Löschen IDPflegeplan beendet! 
            ////Beenden von entfernte Einträge
            //if (list.Count > 0)
            //{
            //    using (PMDS.Transaction.DBTransaction trans = new PMDS.Transaction.DBTransaction())
            //    {
            //        PflegePlanTools.ProcessEndM(_PflegePlan, list);   //lthxy
            //        trans.Commit();
            //    }

            //    //Pflegeplan aktualisieren um neue und Bearbeite Einträge übernehmen zu können
            //    _PflegePlan.Refresh();
            //}

            ////Bearbeitete und neue pflegeplaneintäge übernehmen
            //foreach (ASZMSelectionArgs arg in listArgs)
            //{
            //    if (arg.IsEditedFromuser)
            //    {
            //        InsertPPEntry(arg);
            //    }
            //}

        }

        private void RefreshControl()
        {
            try
            {
                _ZusateintragChanged = false;
                ShowOrHideControls();
                ucPflegeplan2.lstVerordnungen = new List<DB.PMDSBusiness.cVerordnungen>();

                if (_PflegePlan == null)
                {
                    _PflegePlan = new PMDS.BusinessLogic.PflegePlan(_IDAufenthalt);
                    _PflegePlan.Read(_PflegePlanModus);
                }
                else
                    _PflegePlan.Refresh(_PflegePlanModus);

                _ZusatzGruppe = new ZusatzGruppe("MASS", false);
                ucASZMTransfer21.ZusatzGruppe = _ZusatzGruppe;
                
                _valueChangeEnabled = false;
                tbDefinition.Text = "";
                tbRessourcen.Text = "";
                ucPDxSearch21.PFLEGEPLAN = _PflegePlan;
                FillTreeView();
                UpdateFilters();
                tbRessourcen.Enabled = true;        // ucPflegeplanTreeView1.PDX_SELARGS.Length > 0;
                this.btnAddMissingASZM.Enabled = true;

                this.btnPDx.Enabled = true;

                _valueChangeEnabled = true;
                this.panelButtonsRechtsUnten.Visible = true ;
                this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);
                //this.SetColorASZM();

                this.setUIPanelVOMedikamete();

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }
        public void SetColorASZMxy()
        {
            try
            {
                //this.ucPflegeplanTreeView1.tv.UseAppStyling = false;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nod in this.ucPflegeplanTreeView1.tv.Nodes)
                {
                    PMDS.Global.PDxSelectionArgs notTg = (PMDS.Global.PDxSelectionArgs)nod.Tag;
                    nod.Override.NodeAppearance.ForeColor = Color.DarkBlue;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nod2 in nod.Nodes)
                    {
                        PMDS.Global.EintragGruppe notTg2 = (PMDS.Global.EintragGruppe)nod2.Tag;
                        nod2.Override.NodeAppearance.ForeColor = Color.DarkBlue;

                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nod3 in nod2.Nodes)
                        {
                            PMDS.Global.ASZMSelectionArgs nodTg3 = (PMDS.Global.ASZMSelectionArgs)nod3.Tag;
                            nod3.Override.NodeAppearance.ForeColor = Color.DarkBlue;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("SetColorASZM: " + e.ToString());
            }
        }

        //Neu nach 15.09.2008 MDA
        private void ShowOrHideControls()
        {
            // os 29.9.2011: Recht berücksichtigen
            bool TrueWithRight = true && ENV.HasRight(UserRights.PflegePlanungAendern);
            bool FalseWithRight = false;

            if (_PfState == PflegePlanState.Bearbeiten)
            {

                this.uGridBagLayPanelPflegeplanDef.BackColor = System.Drawing.Color.Transparent;

                this.btnPDx.Visible = TrueWithRight;
                this.panelObenLinks.Visible = TrueWithRight;
                this.pnlAddPlDef3.Visible = FalseWithRight;
                this.btnAddMissingASZM3.Visible = FalseWithRight;

                ucPflegeplanTreeView1.Visible = true;

                this.pnlAddMissingASZM.Visible = FalseWithRight;
                this.pnlEndPDx.Visible = FalseWithRight;
                              

                if (_PflegePlanModus == PflegePlanModus.Normal)
                    ucASZMTransferPDx1.Visible = FalseWithRight;
                else
                    ucWunde1.Visible = FalseWithRight;
                ucASZMTransfer21.Visible = FalseWithRight;

                this.pnlAddPlDef3.Visible = TrueWithRight;

                pnlLegende.Visible = TrueWithRight;

                if (_PflegePlanModus == PflegePlanModus.Normal)
                    ucASZMTransferPDx1.AddlokalisierungEnabled = TrueWithRight;
                ucPDxSearch21.Visible = FalseWithRight;
                this.ultraGridBagLayoutPanelNeuanlage.Visible = FalseWithRight;

                ucASZMTransfer21.EditMode = TrueWithRight;
                _AddMissingASZM = FalseWithRight;
            }
            else
            {
                this.uGridBagLayPanelPflegeplanDef.BackColor = System.Drawing.Color.LightSteelBlue;
                //ucASZMTransferPDx1
                ucPDxSearch21.Visible = TrueWithRight;
                this.pnlAddPlDef3.Visible = FalseWithRight;
                this.btnAddMissingASZM3.Visible = FalseWithRight;
                this.ultraGridBagLayoutPanelNeuanlage.Visible = TrueWithRight;
                ucPflegeplanTreeView1.Visible = FalseWithRight;

                if (_PflegePlanModus == PflegePlanModus.Normal)
                    ucASZMTransferPDx1.Visible = FalseWithRight;
                else
                    ucWunde1.Visible = FalseWithRight;

                if (_PflegePlanModus == PflegePlanModus.Normal)
                    ucASZMTransferPDx1.AddlokalisierungEnabled = FalseWithRight;
                ucASZMTransfer21.Visible = FalseWithRight;
                ucASZMTransfer21.EditMode = FalseWithRight;
                tbDefinition.Text = "";
                pnlLegende.Visible = FalseWithRight;
                this.btnPDx.Visible = FalseWithRight;
                this.panelObenLinks.Visible = FalseWithRight;

                this.pnlEndPDx.Visible = FalseWithRight;
                this.pnlAddMissingASZM.Visible = FalseWithRight;
                this.pnlAddPlDef3.Visible = !_AddMissingASZM;

                ucASZMTransferPDx1.Visible = false;           //lthxy   Alle Controls rechts wegblenden bei Suchmodus

            }

            //pnlDef.Visible = _PflegePlanModus == PflegePlanModus.Normal;

            Application.DoEvents();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Je nach Recht die einzelnen aktionen unterdrücken setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void ProcessRights()
        {
            ReadOnly = !ENV.HasRight(UserRights.PflegePlanungAendern);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das Control für die entsprechenden Modi herrichten
        /// </summary>
        //----------------------------------------------------------------------------
        private void PrepareControlsForMode()
        {
            if (_PflegePlanMode == PflegePlanModi.Evaluierung)
                grpRessourcen.Text = "Letzte Evaluierungsergebnisse";
            else
                grpRessourcen.Text = "Ressource";
            
            tbRessourcen.Visible = _PflegePlanMode == PflegePlanModi.PflegePlan;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Legende aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateLegend()
        {
            legDelete.COLOR = ENVCOLOR.EINTRAG_DELETED_FORE_COLOR;
            legEnded.COLOR = ENVCOLOR.EINTRAG_ENDED_FORE_COLOR;
            legNotOriginal.COLOR = ENVCOLOR.EINTRAG_CURRENT_NOT_ORIGINAL_FORE_COLOR;
            legNormal.COLOR = ENVCOLOR.EINTRAG_CURRENT_FORE_COLOR;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegediagnosen im Treeview anzeigen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillTreeView()
        {
            ucPflegeplanTreeView1.ErledigteAnzeigenJN = cbErledigte.Checked;
            ucPflegeplanTreeView1.PFLEGEPLAN = _PflegePlan;
            ucPDxSearch21.PflegeplanPDXSelArgs = ucPflegeplanTreeView1.PDX_SELARGS;

            if (ucPflegeplanTreeView1.PDX_SELARGS == null || ucPflegeplanTreeView1.PDX_SELARGS.Length == 0)
            {
                ucWunde1.IDAufenthaltPDx = Guid.Empty;
                ucASZMTransferPDx1.Visible = false;         
            }

        }

        //Neu nach 15.05.2007 MDA
        private void SetBtnEndAddMissingASZMEnabled()
        {
            this.btnAddMissingASZM.Text = "+";

            this.pnlAddMissingASZM.Visible = false;

            if (ucPflegeplanTreeView1.ActiveKatalogEditModes == KatalogEditModes.All)
            {
                //Änderung nach 16.09.2008 MDA
                //Bei Wunden nur Ziele oder Maßnahmen hinzufügen.
                this.btnAddMissingASZM.Text = _PflegePlanModus == PflegePlanModus.Normal ? "ASZM +" : "AZM +";
            }
            else
            {
                this.btnAddMissingASZM.Text = ucPflegeplanTreeView1.ActiveKatalogEditModes.ToString() + " +";
            }

            this.pnlAddMissingASZM.Visible = true;

            //Bereits beendete PDX und ASZM, können nicht nochmal beendet werden
            //Zu beendete PDX können keine ASZM's hinzugefügt werden.
            //Die Buttons entsprechend anzeigen oder verstecken.
            if (ucPflegeplanTreeView1.Visible)
            {
                if (ucPflegeplanTreeView1.ARG != null || ucPflegeplanTreeView1.PDX_SARG != null)
                {
                    if (ucPflegeplanTreeView1.IsPDx)
                        this.pnlAddMissingASZM.Visible = !ucPflegeplanTreeView1.PDX_SARG.ErledigtJN;
                    else if (ucPflegeplanTreeView1.CurrentPDX != null)
                        this.pnlAddMissingASZM.Visible = !ucPflegeplanTreeView1.CurrentPDX.ErledigtJN;
                    else
                        this.pnlAddMissingASZM.Visible = false;
                }
                else if (ucPflegeplanTreeView1.CurrentPDX != null)
                    this.pnlAddMissingASZM.Visible = !ucPflegeplanTreeView1.CurrentPDX.ErledigtJN;
                else
                    this.pnlAddMissingASZM.Visible = false;
            }
            else
            {
                this.pnlAddMissingASZM.Visible = false;
                this.pnlEndPDx.Visible = false;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Filter entsprechende den Checkboxen setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateFilters()
        {
            ucPflegeplanTreeView1.HideOrShowEintragGruppe("A", !cbA.Checked);
            ucPflegeplanTreeView1.HideOrShowEintragGruppe("S", !cbS.Checked);
            ucPflegeplanTreeView1.HideOrShowEintragGruppe("R", !cbR.Checked);
            ucPflegeplanTreeView1.HideOrShowEintragGruppe("Z", !cbZ.Checked);
            ucPflegeplanTreeView1.HideOrShowEintragGruppe("M", !cbM.Checked);
            
            ucPDxSearch21.HideOrShowEintragGruppe("A", !cbA.Checked);
            ucPDxSearch21.HideOrShowEintragGruppe("S", !cbS.Checked);
            ucPDxSearch21.HideOrShowEintragGruppe("R", !cbR.Checked);
            ucPDxSearch21.HideOrShowEintragGruppe("Z", !cbZ.Checked);
            ucPDxSearch21.HideOrShowEintragGruppe("M", !cbM.Checked);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wird Aufgerufen wenn sich irgendwo was ändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ContentChanged()
        {
            _ContentChanged = true;

            this.btnSavexyxyxy.Enabled = ENV.HasRight(UserRights.PflegePlanungAendern);
            this.btnRefresh.Enabled = true;

            if (_ZusateintragChanged) return;
            cbErledigte.Enabled = false;
            grpFilter.Enabled = false;
            _bChangeInProgress = true;
            if (ValueChanged != null)
                ValueChanged(this, null);

        }

        private void TransferLokalisierung(PDxSelectionArgs arg)
        {
            if (arg == null || arg.ARGS == null) return;
            foreach (ASZMSelectionArgs sa in arg.ARGS)
            {
                sa.LokalisierungJN = arg.LokalisierungJN;
                sa.Lokalisierung = arg.Lokalisierung;
                sa.LokalisierungSeite = arg.LokalisierungSeite;

                if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX)
                    sa.EvalStartDatum = arg.EvalStartDatum;
            }
        }

        private void EndPflegePlanUI()
        {
            try
            {
                if (_bChangeInProgress)
                {
                    MessageSaveBevore();
                    return;
                }

                if (PflegePlanTools.EndPflegePlanUIxy(_PflegePlan, ucPflegeplanTreeView1))
                {
                    _PflegePlan.Write(ENV.USERID, _bUseTransaction, true);    //lthxy  Sollte irgendwie raus da neues Speichermodell Planung
                    RefreshControl();
                    ENV.SignalPflegePlanChanged(_IDAufenthalt);
                }
                else
                {
                    _PflegePlan.Refresh();
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        private void MessageSaveBevore()
        {
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
        }

        private void cbErledigte_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControl();
        }

        private void uc_TreeviewAfterNodeSelectEventHandler(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
          try
            {
                this.Cursor = Cursors.WaitCursor;
                
                ITreeview uc = (sender is ucPflegeplanTreeView) ? (ITreeview)ucPflegeplanTreeView1 : ucPDxSearch21.CurrentTreeView;
                if (uc == null) return;
                lblError.Visible = false;
                
                SetBtnEndAddMissingASZMEnabled();//Neu nach 31.03.2008 MDA
                _valueChangeEnabled = false;

                if (_PflegePlanModus == PflegePlanModus.Wunde && uc.IsPDx && uc.PDX_SARG != null)
                {
                    dsAufenthaltPDx.AufenthaltPDxRow[] rows = (dsAufenthaltPDx.AufenthaltPDxRow[])_PflegePlan.AUFENTHALTPDX.Select("ID = '" + uc.PDX_SARG.IDAufenthaltPDX.ToString() + "'");

                    if (_PfState == PflegePlanState.Hinzufuegen || (rows.Length == 0 && _PfState == PflegePlanState.Bearbeiten))
                    {
                        _CurrentTransferPDxControl = (IWizardPage)ucASZMTransferPDx1;
                        ucWunde1.Visible = false;
                    }
                    else
                    {
                        _CurrentTransferPDxControl = (IWizardPage)ucWunde1;
                        ucASZMTransferPDx1.Visible = false;
                    }
                }
                
                PflegePlanTools.AfterPflegePlanNodeSelected(uc, ucASZMTransfer21, _CurrentTransferPDxControl, ref _AktivePDx,
                                                            tbRessourcen, _RessourceChanged, lblError, tbDefinition,
                                                            (this._PfState == PflegePlanState.Bearbeiten ? false:true), this._PflegePlanModus, this);
                _valueChangeEnabled = true;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void uc_TreeviewBeforeNodeSelectEventArgs(object sender, Infragistics.Win.UltraWinTree.BeforeSelectEventArgs e)
        {
            ITreeview uc = (sender is ucPflegeplanTreeView) ? (ITreeview)ucPflegeplanTreeView1 : ucPDxSearch21.CurrentTreeView;
            if (uc == null) return;

            if (_ZusateintragChanged)
            {
                e.Cancel = true;
                //TreeNode wieder selectieren
                CancelTreeSelection(sender);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Änderungen in Zusatzwerte speichern.", "Speichern", MessageBoxButtons.OK);
                return;
            }

            if (ucAdditionalASZMToPDx1.Visible)
            {
                e.Cancel = true;
                //TreeNode wieder selectieren
                CancelTreeSelection(sender);
                return;
            }

            bool validate = true;

            ucPflegeplanTreeView treeView = null;
            if (sender is ucPflegeplanTreeView)
                treeView = (ucPflegeplanTreeView)sender;
            
            if (treeView != null && _PflegePlanModus == PflegePlanModus.Wunde)
            {
                if (e.NewSelections.Count > 0)
                {
                    UltraTreeNode tn = e.NewSelections[0];
                    while (tn.Parent != null)
                        tn = tn.Parent;

                    PDxSelectionArgs pdx = (PDxSelectionArgs)tn.Tag;
                    if (treeView.ActivPDX != null && treeView.ActivPDX.IDAufenthaltPDX == pdx.IDAufenthaltPDX) validate = false;

                }
            }
 
            if(validate)
                validate = (_valueChangeEnabled && (sender is ucPflegeplanTreeView)) ? true : false;

            //Neu nach 09.10.2008 MDA
            //Wenn Zusatzeintäge eine Maßnahme geädert sind dann eine Prüfung ist nötig
            if (!validate) validate = _ZusateintragChanged;
            
            if (!PflegePlanTools.BeforePflegePlanNodeSelected(uc, ucASZMTransfer21, _CurrentTransferPDxControl, tbRessourcen, lblError, validate))
            {
                e.Cancel = true;
                //TreeNode wieder selectieren
                CancelTreeSelection(sender);
            }
        }

        private void CancelTreeSelection(object sender)
        {
            if (sender is ucPflegeplanTreeView)
                ucPflegeplanTreeView1.AktivNode = ucPflegeplanTreeView1.AktivNode;
            else if(sender is ucPDxSearch2)
                ucPDxSearch21.ActivTreeView.AktivNode = ucPDxSearch21.ActivTreeView.AktivNode;
        }

        private void ucASZMTransferPDx1_PDxValueChanged(object sender, EventArgs e)
        {
            if (_PflegePlanModus == PflegePlanModus.Wunde)          // RBU: Bei Wunde kann sich nur die Wunde selbst geändert haben == Speichern anzeigen
            {
                if (ucPDxSearch21.Visible)
                {
                    TransferLokalisierung(ucPDxSearch21.CurrentTreeView.PDX_SARG);
                    ucPDxSearch21.UpdateActivPDxTreeNodeImage();
                }
                else if (ucPflegeplanTreeView1.Visible)
                {
                    ucASZMTransferPDx1.UpdateDATA();
                    TransferLokalisierung(ucASZMTransferPDx1.PDX_SARG);
                    ucPflegeplanTreeView1.UpdateTreeNodeImage();
                    ContentChanged();
                }
                return;
            }

            _CurrentTransferPDxControl.UpdateDATA();
            if (!ucPflegeplanTreeView1.Visible) return;
            if (_PflegePlanModus == PflegePlanModus.Normal)
                TransferLokalisierung(ucASZMTransferPDx1.PDX_SARG);
            
            ucPflegeplanTreeView1.UpdateTreeNodeImage();
            ContentChanged();
        }

        private void ucASZMTransferPDx1_PDxZusaetzlicheLokalisierung(object sender, EventArgs e)
        {
            if (!ucPflegeplanTreeView1.Visible) return;
            ucASZMTransferPDx1.UpdateDATA();
            ucPflegeplanTreeView1.AddLokalisierungFromActualPDx("", "");
            ContentChanged();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Filter aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void cbFilter_CheckedValueChanged(object sender, System.EventArgs e)
        {
            UpdateFilters();
        }

        private void ucPDxSearch21_PDXSelected(PDxSelectionArgs[] pdxArgs)
        {
            ucASZMTransferPDx1.Enabled = true;
            _PfState = PflegePlanState.Bearbeiten;
            ucASZMTransferPDx1.Visible = false;
            ucWunde1.Visible = false;
            _CurrentTransferPDxControl = _PflegePlanModus == PflegePlanModus.Normal ? (IWizardPage)ucASZMTransferPDx1 : (IWizardPage)ucWunde1;
            
            ShowOrHideControls();
            
            //Änderungen der bereits ausgewählte PDX oder ASZM übernehmen
            if (ucPDxSearch21.CurrentTreeView != null)
                PflegePlanTools.BeforePflegePlanNodeSelected(ucPDxSearch21.CurrentTreeView, ucASZMTransfer21, _CurrentTransferPDxControl, tbRessourcen, lblError, false);

            if (pdxArgs == null)
            {
                _valueChangeEnabled = false;
                PflegePlanTools.AfterPflegePlanNodeSelected((ITreeview)ucPflegeplanTreeView1, ucASZMTransfer21, _CurrentTransferPDxControl, ref _AktivePDx,
                                                        tbRessourcen, _RessourceChanged, lblError, tbDefinition,
                                                        (this._PfState == PflegePlanState.Bearbeiten ? false : true), this._PflegePlanModus, this);
                _valueChangeEnabled = true;
                SetBtnEndAddMissingASZMEnabled();
                return;
            }

            if (ucPDxSearch21.PDX_SELARGS != null)
            {
                ucPflegeplanTreeView1.AddASZMToCurrentPDx(pdxArgs);
            }
            else
            {
                foreach (PDxSelectionArgs pdxArg in pdxArgs)
                {
                    if (pdxArg.Lokalisierung == null ) pdxArg.Lokalisierung = "";
                    if (pdxArg.LokalisierungSeite == null) pdxArg.LokalisierungSeite = "";
                    if (pdxArg.ARGS == null) continue;
                    foreach (ASZMSelectionArgs arg in pdxArg.ARGS)
                    {
                        arg.WundeJN = pdxArg.WundeJN;
                        arg.Lokalisierung = pdxArg.Lokalisierung;
                        arg.LokalisierungSeite = pdxArg.LokalisierungSeite;
                        if (arg.IDPDX == Guid.Empty)
                            arg.ISPDX = false;
                        else
                            arg.ISPDX = true;


                    }
                }
                ucPflegeplanTreeView1.AddPDxArgs(pdxArgs);
            }

            SetBtnEndAddMissingASZMEnabled();//Neu nach 31.03.2008 MDA
            tbRessourcen.Enabled = true;    // ucPflegeplanTreeView1.PDX_SELARGS.Length > 0;
            _valueChangeEnabled = false;
            PflegePlanTools.AfterPflegePlanNodeSelected((ITreeview)ucPflegeplanTreeView1, ucASZMTransfer21, _CurrentTransferPDxControl, ref _AktivePDx,
                                                        tbRessourcen, _RessourceChanged, lblError, tbDefinition,
                                                        (this._PfState == PflegePlanState.Bearbeiten ? false : true), this._PflegePlanModus, this);
            _valueChangeEnabled = true;

            if (pdxArgs.Length > 0)
                ContentChanged();
        }

        private void ucPflegeplan2_Load(object sender, EventArgs e)
        {
            this.ucPDxSearch21.mainWindow = this;

            if (DesignMode || !ENV.AppRunning) return;

            ucPDxSearch21.Location = ucPflegeplanTreeView1.Location;
            ucPDxSearch21.Size = ucPflegeplanTreeView1.Size;
            ucPDxSearch21.Anchor = ucPflegeplanTreeView1.Anchor;

            this.ucASZMTransfer21.Dock = DockStyle.Fill;
            this.ucWunde1.Dock = DockStyle.Fill;
            this.ucAdditionalASZMToPDx1.Dock = DockStyle.Top ;
            this.ucASZMTransferPDx1.Dock = DockStyle.Fill;
            
        }

        private void tbRessourcen_TextChanged(object sender, EventArgs e)
        {
            if(_valueChangeEnabled)
                ContentChanged();
        }
        private void ucPflegeplanTreeView1_TreeviewAfterCheckEventHandler(object sender, NodeEventArgs e)
        {
            PDxSelectionArgs[] pdxArgs = ucPflegeplanTreeView1.GetSelectedPDX();
            ASZMSelectionArgs[] aszms = ucPflegeplanTreeView1.GetSelectedASZM();
            bool enabled = (pdxArgs == null || pdxArgs.Length == 0) && (aszms == null || aszms.Length == 0);
            
            this.btnAddMissingASZM.Enabled = enabled;

            this.btnPDx.Enabled = enabled;
            cbErledigte.Enabled = enabled;
            this.pnlEndPDx.Visible = !enabled;
        }
        
        private void ucAdditionalASZMToPDx1_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            ucAdditionalASZMToPDx1.Visible = false;
            if (_CurrentControl != null)
                _CurrentControl.Visible = true;

            ucPDxSearch21.EnableOkCancelButtons(true);

            if(IDEintrag != Guid.Empty)
                ucPDxSearch21.AddASZMToPDx(IDPdx, IDEintrag, gruppe, demStandardHinzufuegen, IDAbteilungen);
        }

        private void ucPDxSearch21_AddNewASZM(Guid IDPDX, KatalogEditModes editMode)
        {
            if (lblError.Visible)
                _CurrentControl = lblError;
            else if (ucASZMTransferPDx1.Visible)
                _CurrentControl = ucASZMTransferPDx1;
            else if (ucASZMTransfer21.Visible)
                _CurrentControl = ucASZMTransfer21;
            else if (ucWunde1.Visible)
                _CurrentControl = ucWunde1;

            ucAdditionalASZMToPDx1.SetPDxAndMode(IDPDX, editMode);
            ucAdditionalASZMToPDx1.Visible = true;
            ucASZMTransfer21.Visible = false;
            ucPDxSearch21.EnableOkCancelButtons(false);
        }

        private void PflegedefinitionHinzufügen()
        {
            this.panelButtonsRechtsUnten.Visible = false;
            _PfState = PflegePlanState.Hinzufuegen;
            _CurrentTransferPDxControl = ucASZMTransferPDx1;
            ucASZMTransferPDx1.AddlokalisierungEnabled = false;
            ShowOrHideControls();
            ucPDxSearch21.PDX_SELARGS = null;
            ucPDxSearch21.KatalogEditMode = KatalogEditModes.All;
            ucPDxSearch21.Suchmode = true;
            ucPDxSearch21.RefreshControl();
            UpdateFilters();
        }

        private void pdxLöschen()
        {
            EndPflegePlanUI();
            this.btnAddMissingASZM.Enabled = true;
            this.btnPDx.Enabled = true;
            cbErledigte.Enabled = true;
        }

        private void aktionPflegeplanÄndern(string typ )
        {
             if (typ == "N") 
             {
                 this.pdsHinzufügen();
             }
             else if (typ == "ASZM_Löschen")
             {
                 this.pdxLöschen();
             }
             else if (typ == "ASZM_Neu")
             {
                 this.aszmAdd ();
             }
             else if (typ == "P")
             {
                 this.print();
             }
        }

        private void pdsHinzufügen()
        {
            _PfState = PflegePlanState.Hinzufuegen;
            _CurrentTransferPDxControl = ucASZMTransferPDx1;
            ucASZMTransferPDx1.AddlokalisierungEnabled = false;
            ucASZMTransferPDx1.Enabled = false;
            _AddMissingASZM = true;
            ShowOrHideControls();
            ucPDxSearch21.Condition = SearchCondition.AND;
            ucPDxSearch21.SearchIN = SearchIN.Pflegediagnosen;
            ucPDxSearch21.KatalogEditMode = ucPflegeplanTreeView1.ActiveKatalogEditModes;
            ucPDxSearch21.Suchmode = false;
            ucPDxSearch21.RefreshControl();

            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            list.Add(ucPflegeplanTreeView1.CurrentPDX);
            ucPDxSearch21.PDX_SELARGS = list.ToArray();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (_bChangeInProgress)
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE_PRINT"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            
            //if (this._PflegePlanModus == PflegePlanModus.Normal)
            //{
            //    GuiActionPflegePlan.PrintPflegePlanPDxOrientated(IDAUFENTHALT, cbErledigte.Checked);
            //}
            //else
            //{
            //    frmDynReports frm = new frmDynReports(ENV.DynReportWundePath );
            //    frm.ShowDialog();
            //}
        }
        private void print()
        {
            if (_bChangeInProgress)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE_PRINT"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                return;
            }
            
            if (this._PflegePlanModus == PflegePlanModus.Normal)        //<20120216> IDKlinik und IDAbteilung dazu
            {
                GuiActionPflegePlan.PrintPflegePlanPDxOrientated(IDAUFENTHALT, cbErledigte.Checked);
            }
            else
            {
                frmDynReports frm = new frmDynReports(ENV.DynReportWundePath );
                frm.ShowDialog();
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            this.panelButtonGesamt.Visible = !bOn;
            this.pnlButtonsOben.Visible = !bOn;
            this.tbRessourcen.ReadOnly = bOn;

            ucASZMTransfer21.setControlsAktivDisable (PMDS.Global.historie.HistorieOn);
            ucAdditionalASZMToPDx1.setControlsAktivDisable (PMDS.Global.historie.HistorieOn);
            ucASZMTransferPDx1.setControlsAktivDisable (PMDS.Global.historie.HistorieOn);
            ucWunde1.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

            ucPflegeplanTreeView1.setControlsAktivDisable(bOn);


        }

        private void aszmAdd()
        {
            this.panelButtonsRechtsUnten.Visible = false;
            _PfState = PflegePlanState.Hinzufuegen;
            _CurrentTransferPDxControl = ucASZMTransferPDx1;
            ucASZMTransferPDx1.AddlokalisierungEnabled = false;
            ucASZMTransferPDx1.Enabled = false;
            _AddMissingASZM = true;
            ShowOrHideControls();
            ucPDxSearch21.Condition = SearchCondition.AND;
            ucPDxSearch21.SearchIN = SearchIN.Pflegediagnosen;
            ucPDxSearch21.KatalogEditMode = ucPflegeplanTreeView1.ActiveKatalogEditModes;
            ucPDxSearch21.Suchmode = false;
            ucPDxSearch21.RefreshControl();

            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            list.Add(ucPflegeplanTreeView1.CurrentPDX);
            ucPDxSearch21.PDX_SELARGS = list.ToArray();

        }

        private void ucPDxSearch21_pflegeplanÄndern(string typ)
        {
            this.aktionPflegeplanÄndern(typ);
        }

        private void ucPflegeplanTreeView1_Load(object sender, EventArgs e)
        {

        }

        private void pnlPDX_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPDx_Click(object sender, EventArgs e)
        {
            this.PflegedefinitionHinzufügen();
        }

        private void ucPDxSearch21_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAddMissingASZM_Click(object sender, EventArgs e)
        {
            this.aktionPflegeplanÄndern("ASZM_Neu");
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.planungÄndern("Save");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.planungÄndern("Refresh");
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            this.planungÄndern("Save");
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            this.planungÄndern("Refresh");
        }


        private void btnEndPDx_Click(object sender, EventArgs e)
        {
            this.pdxLöschen();
        }

        private void ucAdditionalASZMToPDx1_Load(object sender, EventArgs e)
        {

        }

        public bool validateData()
        {
            try
            {
                string InfoErrors = "";
                bool bError = false;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode nodPdx in this.ucPflegeplanTreeView1.tv.Nodes)
                {
                    PMDS.Global.PDxSelectionArgs tgPdx = (PMDS.Global.PDxSelectionArgs)nodPdx.Tag;
                    if (tgPdx.LokalisierungJN && (tgPdx.Lokalisierung.Trim() == "" || tgPdx.LokalisierungSeite.Trim() == ""))
                    {
                        string sTxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierung: Angabe erforderlich");
                        sTxtTmp += ": " + tgPdx.Text.Trim() + "" +  "\r\n" + "\r\n";
                        InfoErrors += sTxtTmp;
                        bError = true;
                    }

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode TypeEG in nodPdx.Nodes)
                    {
                        PMDS.Global.EintragGruppe EintragGruppe1 = (PMDS.Global.EintragGruppe)TypeEG.Tag;
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode aszm in TypeEG.Nodes)
                        {
                            PMDS.Global.ASZMSelectionArgs tgAszm = (PMDS.Global.ASZMSelectionArgs)aszm.Tag;
                            if (EintragGruppe1 == EintragGruppe.M && tgAszm.WochenTage == 0)
                            {
                                string sTxtTmp = QS2.Desktop.ControlManagment.ControlManagment.getRes("Wochentage: Angabe erforderlich");
                                sTxtTmp += ": " + tgPdx.Text.Trim() + " - " + tgAszm.Text.Trim() + "\r\n" + "\r\n";
                                InfoErrors += sTxtTmp;
                                bError = true;
                            }
                        }
                    }
                }

                if (bError)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(InfoErrors, "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Error, true);
                    return false;
                }
                else
                {
                    return true;
                }
               
            }
            catch (Exception e)
            {
                throw new Exception("validateData: " + e.ToString());
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.planungÄndern("Save");
                this.setUIPanelVOMedikamete();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        public void setUIPanelVOMedikamete()
        {
            try
            {
                if (this._PflegePlanModus == PflegePlanModus.Wunde)
                {
                    if (ucWunde1.IDAufenthaltPDx == System.Guid.Empty)
                    {
                        this.panelVOMedikamente.Visible = false;
                    }
                    else
                    {
                        this.panelVOMedikamente.Visible = true;
                    }
                }
                else
                {
                    this.panelVOMedikamente.Visible = false;
                }

                if (!ENV.lic_VO)
                {
                    this.panelVOMedikamente.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("setUIPanelVOMedikamete: " + ex.ToString());
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.planungÄndern("Refresh");
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.print();
            this.Cursor = Cursors.Default ;
        }

        private void ucWunde1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddMissingASZM3_Click(object sender, EventArgs e)
        {
            this.ucPDxSearch21.btnAddMissingASZM2();
        }

        private void pnlButtonsOben_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucASZMTransfer21_ASZMValueChanged_1(object sender, EventArgs e)
        {
            if (!ucPflegeplanTreeView1.Visible) return;

            this.ucASZMTransfer21.ARG.IsEditedFromuser = true;
            this.ucASZMTransfer21.ARG.IsEditedFromUserTime = DateTime.Now;

            //this.ucPDxSearch21.tvSpecific.ActivePDx.IsEditedFromuser = true;

            ucPflegeplanTreeView1.UpdateTreeNodeImage();
            ContentChanged();
        }

        private void btnOnOffInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.btnOnOffInfo.Tag.ToString().Trim().Equals("0"))
                {
                    this.btnOnOffInfo.Tag = "1";
                }
                else
                {
                    this.btnOnOffInfo.Tag = "0";
                }
                this.OnOffInfo(this.btnOnOffInfo.Tag.ToString());
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void OnOffInfo(string sTag)
        {
            try
            {
                if (sTag.Trim().Equals("0"))
                {
                    this.pnlDef2.Visible = false;
                }
                else
                {
                    this.pnlDef2.Visible = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("OnOffInfo: " + ex.ToString());
            }
        }

        private void pnlDef_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVerordnungen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count > 1)
                {
                    throw new Exception("btnVerordnungen_Click: ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count < 1 not allowed!");
                }
                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count == 1)
                {
                    if (this.ucPflegeplanTreeView1.ActivPDX.IDAufenthaltPDX.Equals(System.Guid.Empty))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die PDx!", "", MessageBoxButtons.OK);
                        return;
                    }

                    dsWunde.WundeKopfRow rWundeKopf = (dsWunde.WundeKopfRow)ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows[0];
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = db.WundeKopf.Where(p => p.ID == rWundeKopf.ID);
                        if (tWundeKopf.Count() == 1)
                        {
                            Guid IDAufenthaltTmp;
                            PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(ENV.CurrentIDPatient, false, db);
                            IDAufenthaltTmp = rAufenthalt.ID;
                            //this.ucPflegeplanTreeView1.ActivPDX
                            PMDS.GUI.Verordnungen.frmVOErfassen frmVOErfassen1 = new Verordnungen.frmVOErfassen();
                            frmVOErfassen1.initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI.VOErfassenWunde, true, false, null);
                            frmVOErfassen1.ucVOErfassen1.search2(IDAufenthaltTmp, null, null, rWundeKopf.ID);
                            frmVOErfassen1.ShowDialog(this);
                            if (!frmVOErfassen1.ucVOErfassen1.abort)
                            {
                            }
                        }
                        else if (tWundeKopf.Count() > 1)
                        {
                            throw new Exception("ucPflegeplan22.btnVerordnungen_Click: tWundeKopf.Count() > 1 for IDWundePos " + rWundeKopf.ID.ToString() + "!");
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die Wundbeschreibung!", "", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wunde vorher speichern!", "PMDS", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnMedikamente_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count > 1)
                {
                    throw new Exception("btnMedikamente_Click: ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count < 1 not allowed!");
                }
                if (ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows.Count == 1)
                {
                    if (this.ucPflegeplanTreeView1.ActivPDX.IDAufenthaltPDX.Equals(System.Guid.Empty))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die PDx!", "", MessageBoxButtons.OK);
                        return;
                    }

                    dsWunde.WundeKopfRow rWundeKopf = (dsWunde.WundeKopfRow)ucWunde1.ucWunddoku1.dsWunde1.WundeKopf.Rows[0];
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = db.WundeKopf.Where(p => p.ID == rWundeKopf.ID);
                        if (tWundeKopf.Count() == 1)
                        {
                            PMDS.GUI.Medikament.frmRezeptEintragMedDaten frmRezeptEintragMedDaten1 = new Medikament.frmRezeptEintragMedDaten();
                            frmRezeptEintragMedDaten1.initControl(rWundeKopf.ID, Medikament.ucRezeptEintragMedDaten.eTypeUI.WundeKopf);
                            frmRezeptEintragMedDaten1.ShowDialog(this);
                            if (!frmRezeptEintragMedDaten1.ucRezeptEintragMedDaten1.abort)
                            {
                                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDWundeKopf == rWundeKopf.ID && o.IDRezepteintrag != null && o.IDVerordnung == null);
                                if (tRezeptEintragMedDaten.Count() > 0)
                                {
                                    foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                                    {
                                        string lstMedDaten = "";
                                        int NumberMedDaten = 0;
                                        string lstWunden = "";
                                        int NumberWunde = 0;
                                        this.b2.saveAnzeigeGridRezeptEintrag(rRezeptEintragMedDaten2.IDRezepteintrag.Value, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunde);
                                    }
                                    db.SaveChanges();
                                }
                            }
                        }
                        else if (tWundeKopf.Count() > 1)
                        {
                            throw new Exception("ucPflegeplan22.btnMedikamente_Click: tWundeKopf.Count() > 1 for IDWundePos " + rWundeKopf.ID.ToString() + "!");
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die Wundbeschreibung!", "", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wunde vorher speichern!", "PMDS", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnVerordnungen2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.ucASZMTransfer21.ucPflegePlanSingleEdit21.btnVerordnungenClick();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }


}

