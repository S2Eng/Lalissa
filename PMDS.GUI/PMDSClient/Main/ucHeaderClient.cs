using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.Misc;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;

using PMDS.BusinessLogic;
using PMDS.Global;
using System.Text;
using Infragistics.Win.UltraWinToolbars;
using PMDS.Global.db.Patient;
using PMDS.GUI.Arztabrechnung;
using PMDS.DB;
using System.Linq;

namespace PMDS.GUI.PMDSClient
{

	public class ucHeaderClient : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _LastIDPatient = Guid.Empty;
        private bool _RefreshShouldBeAfterVisible = false;
        private bool _UserLoggedOnPending = false;
        private bool _ButtonInProgress = false;             
        private bool _PreventSelfRefreshing = false;
        private QS2.Desktop.ControlManagment.BaseButton btnKlientenliste;
		private System.ComponentModel.IContainer components;

        private List<Imagesstore> _list = new List<Imagesstore>();
        private List<UltraButton> _buttons = new List<UltraButton>();
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private QS2.Desktop.ControlManagment.BasePanel ucHeader_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHeader_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManagerPlanArchiv;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHeader_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHeader_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ucHeader_Toolbars_Dock_Area_Bottom;
        private QS2.Desktop.ControlManagment.BasePanel panelKlientenListe;
        private PMDS.GUI.BaseControls.Line line3;

        public bool _action = false;


        private System.Drawing.Color activeBackCol = System.Drawing.Color.SkyBlue;
        private System.Drawing.Color activeForeCol = System.Drawing.Color.Black;
        private System.Drawing.Color activeFrameCol = System.Drawing.Color.Transparent;

        private System.Drawing.Color inactiveBackCol = System.Drawing.Color.Transparent;
        private System.Drawing.Color inactiveForeCol = System.Drawing.Color.Black;
        private System.Drawing.Color inactiveFrameCol = System.Drawing.Color.Transparent;

        private System.Drawing.Color hoverBackCol = System.Drawing.Color.Gainsboro;
        private System.Drawing.Color hoverForeCol = System.Drawing.Color.Black;
        private System.Drawing.Color hoverFrameCol = System.Drawing.Color.Transparent;

        private Guid _IDPatient;
        private TerminlisteAnsichtsmodi _LastTerminlisteAnsichtsmodi = TerminlisteAnsichtsmodi.Klientanansicht;

        public event HeaderButtonClickDelegate      HeaderButtonClick;
        public bool _ArztabrechnungJN = false;
        private QS2.Desktop.ControlManagment.BaseButton btnRefresh;
        public bool _ArztabrechnungJNinitialized = false;
        private UltraToolTipManager ultraToolTipManagerWarningMemory;
        public static HeaderButtons lastButtonClicked = HeaderButtons.none;
        public frmMain mainWindow = null;
        private System.Windows.Forms.ToolTip toolTip1;
        private QS2.Desktop.ControlManagment.BasePanel pAll;
        private QS2.Desktop.ControlManagment.BaseButton btnArztabrechnung;
        private QS2.Desktop.ControlManagment.BasePanel pnlArchivTermine;
        private BaseControls.Line line6;
        private QS2.Desktop.ControlManagment.BaseButton btnArchiv;
        private QS2.Desktop.ControlManagment.BaseButton btnTermine;
        private QS2.Desktop.ControlManagment.BasePanel panelPlanungDatenInterv;
        private QS2.Desktop.ControlManagment.BaseButton btnEvaluierung;
        private QS2.Desktop.ControlManagment.BaseButton btnDatenerhebung;
        private QS2.Desktop.ControlManagment.BaseButton btnPlanung;
        private QS2.Desktop.ControlManagment.BaseButton btnIntervention;
        private BaseControls.Line line2;
        private QS2.Desktop.ControlManagment.BasePanel pMiddle;
        private QS2.Desktop.ControlManagment.BaseButton btnBerichte;
        private QS2.Desktop.ControlManagment.BaseButton btnKlient;
        private QS2.Desktop.ControlManagment.BaseButton btnMitverantwortlicherBereich;
        private QS2.Desktop.ControlManagment.BaseButton btnWunddoku;
        private QS2.Desktop.ControlManagment.BasePanel pnlRight;
        private QS2.Desktop.ControlManagment.BaseButton btn‹bergabe;
        private BaseControls.Line line5;
        private BaseControls.Line line1;
        private QS2.Desktop.ControlManagment.BasePanel pLeft;
        private QS2.Desktop.ControlManagment.BasePanel panelKlientenauswahl;
        public PatientUserPicker.contPatientUserPicker contPatientUserPicker1;
        public BaseControls.ucMedizinDaten ucMedizinDaten1;
        private QS2.Desktop.ControlManagment.BaseLabel lblPatRest;
        private QS2.Desktop.ControlManagment.BaseLabel lblAufenthalt;
        private QS2.Desktop.ControlManagment.BaseLabel lblPatName;
        private QS2.Desktop.ControlManagment.BasePanel panelHistorieBereichOnOff;
        private QS2.Desktop.ControlManagment.BaseLabel lblHistorie;
        private Panel panelTop;
        private Panel panelBottom;
        private Panel panelLineHoriz;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();


        public static bool bKlinikChanged = false;










        public ucHeaderClient()
		{
			InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
                return;

            try
            {
                this.ucMedizinDaten1.initControls(BaseControls.ucMedizinDaten.eTypeUI.MainTop);
                this.ucMedizinDaten1.NotfallSelected += new NotfallSelectedDelegate(this.ucMedizinDaten2_NotfallSelected);

                //this.ucMedizinDaten2.initControls(BaseControls.ucMedizinDaten.eTypeUI.MedIcons);
                //this.ucMedizinDaten2.NotfallSelected += new NotfallSelectedDelegate(this.ucMedizinDaten2_NotfallSelected);
            }
            catch(Exception ex)
            {
                ENV.HandleException(ex);
            }

            _list.Add(new Imagesstore(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32)));
            _list.Add(new Imagesstore(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Planung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Planung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Planung, 32, 32)));
            _list.Add(new Imagesstore(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Interventionen, 64, 64), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Interventionen, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Interventionen, 32, 32)));
            _list.Add(new Imagesstore(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Evaluierung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Evaluierung, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Evaluierung, 32, 32)));
            _list.Add(new Imagesstore(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Uebergabe, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Uebergabe, 32, 32), QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Uebergabe, 32, 32)));

            _buttons.Add(btnDatenerhebung);
            _buttons.Add(btnPlanung);
            _buttons.Add(btnIntervention);
            _buttons.Add(btnEvaluierung);
            _buttons.Add(btn‹bergabe);
            
            for (int i = 0; i < 5; i++)
            {
                _buttons[i].ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
              //  _buttons[i].Appearance.Image = _list[i]._Normal;
              //  _buttons[i].HotTrackAppearance.Image = _list[i]._Hoover;
                _buttons[i].Tag = i;
            }
            this.btnRefresh.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            PMDS.Global.UIGlobal.setAktivDisable(this.btnRefresh, 1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);
            //PMDS.Global.UIGlobal.setAktiv(this.btnRefresh, 1, activeForeCol, activeFrameCol, activeBackCol);

            btnKlient.Tag = HeaderButtons.Details;      
            btnKlientenliste.Tag = HeaderButtons.Klienten;     
            btnBerichte.Tag = HeaderButtons.Berichte;     
            btnMitverantwortlicherBereich.Tag = HeaderButtons.Medikamente;  
            btnWunddoku.Tag = HeaderButtons.Wunde;        

            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            ENV.UserLoggedOn        += new EventHandler(ENV_UserLoggedOn);
            ENV.PflegePlanChanged   += new PflegePlanChangedDelegate(ENV_PflegePlanChanged);
            ENV.NeuerPatient        += new ENVNeuerPatientDelegate(ENV_NeuerPatient);              // Abfangen wenn ein neuer Klient hinzugef¸gt wird
            ENV.KlientChanged       += new EventHandler(ENV_KlientChanged);                        // Zur Zeit nur wegen der Pflegestufenanzeige  benˆtigt

            ultraToolTipManager1.AutoPopDelay = ENV._PPToolTipDuration;
            ultraToolTipManager1.InitialDelay = ENV._PPToolTipDelay;

            //this.contPatientUserPicker1.MainWindowHeader2 = this;     //lthnew
        }

        void ENV_KlientChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshPatLabel();

                this.ucMedizinDaten1.Refresh(IDPATIENT, false);
                //this.ucMedizinDaten2.Refresh(IDPATIENT);

                PMDSBusinessComm.checkCommAsyncForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);
                if (ucHeader.bKlinikChanged)
                {
                    if (this.contPatientUserPicker1.contSelectPatienten != null)
                    {
                        this.contPatientUserPicker1.contSelectPatienten.initControlData();
                    }
                    ucHeader.bKlinikChanged = false;
                }
                this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, true, eTypePatientenUserPickerChanged.MainPickerLeftTop);
                this.contPatientUserPicker1.selectUserPatient(IDPATIENT);

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.ENV_KlientChanged: " + ex.ToString());
            }
        }

        void ENV_NeuerPatient(Guid IDPatient)
        {
            //_RefreshShouldBeAfterVisible = true;
            //ucPatientGroupPicker1.RefreshGUI(true);
            //ucPatientGroupPicker1.SetPatientID(IDPatient);
        }

        void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine)
        {
            try
            {
                if (PMDS.Global.historie.HistorieOn)
                    RefreshControl(IDPatient, true, clickGridTermine);
                else if (ENV.AnsichtsModus != _LastTerminlisteAnsichtsmodi)
                    RefreshControl(IDPatient, true, clickGridTermine);
                else if ((_LastIDPatient == IDPatient && !(_LastIDPatient == Guid.Empty && IDPatient == Guid.Empty)) || _PreventSelfRefreshing)
                {
                    //Patient pat = new Patient(IDPatient);
                    RefreshControl(IDPatient, true, clickGridTermine);
                }
                else
                {
                    RefreshControl(IDPatient, true, clickGridTermine);
                }

                if (refreshPicker)
                {
                    PMDSBusinessComm.checkCommAsyncForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);
                    if (ucHeader.bKlinikChanged)
                    {
                        if (this.contPatientUserPicker1.contSelectPatienten != null)
                        {
                            this.contPatientUserPicker1.contSelectPatienten.initControlData();
                        }
                        ucHeader.bKlinikChanged = false;
                    }
                    this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, true, eTypePatientenUserPickerChanged.MainPickerLeftTop);
                    this.contPatientUserPicker1.selectUserPatient(IDPATIENT);
                }
                else
                {
                    bool NoRefresPicker = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }


        void ucMedizinDaten2_NotfallSelected(Guid IDSP)
        {
            Patient pat = new Patient(_IDPatient);
            frmNotfall frm = new frmNotfall(pat.Aufenthalt.ID, IDSP, BearbeitungsModus.edit);
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            ENV.SignalMedizinischerStateChanged(999);
        }


        void ENV_PflegePlanChanged(Guid IDAufenthalt)
        {
            RefreshPatientInfo(false, false, false);
        }

        void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            if (this.Visible)
                ProcessUserLoggedOn(true );
            else
                _UserLoggedOnPending = true;

            if (!this._ArztabrechnungJNinitialized)
            {
                bool bArztabrechnungErfassung = ENV.HasRight(UserRights.ArztabrechnungErfassung);     
                //Benutzer ben = new Benutzer(ENV.USERID);
                this._ArztabrechnungJN = bArztabrechnungErfassung;
                this.btnArztabrechnung.Visible = bArztabrechnungErfassung;
                this._ArztabrechnungJNinitialized = true;
            }
        }

        private void ProcessUserLoggedOn( bool  refresh)
        {
            ShowHideButtons();
        }

        
        private void RefreshControl(Guid IDPatient, bool bSelectKlient, bool clickGridTermine)
        {
            this.checkMemory();
            _LastIDPatient = IDPatient;

            _RefreshShouldBeAfterVisible = true;
            
            _IDPatient = IDPatient;
         //setUIToHistorie(PMDS.Global.historie.HistorieOn, false );
            RefreshPatientInfo(bSelectKlient, false, clickGridTermine);

            this.lblAufenthalt.Text = "";
            if (ENV.CurrentIDPatient != System.Guid.Empty)
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    Patient pat = new Patient(ENV.CurrentIDPatient);
                    if (((DateTime)pat.Aufenthalt.Entlassungszeitpunkt) != null)
                    {
                        this.lblAufenthalt.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Aufenthalt von ") + pat.Aufenthalt.Aufnahmezeitpunkt.ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ") + ((DateTime)pat.Aufenthalt.Entlassungszeitpunkt).ToString("dd.MM.yyyy");
                    }
                }
            }

            if (!this.Visible)
                return;
            _IDPatient = IDPatient;
            ShowHideButtons();

            if (ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Bereichsansicht)
            {
                lblPatName.Visible = true;
                this.contPatientUserPicker1.Visible = false;

                panelHistorieBereichOnOff.Visible = true;
                lblAufenthalt.Visible = false;
                _LastTerminlisteAnsichtsmodi = TerminlisteAnsichtsmodi.Bereichsansicht;
                //this.btn3.Text = "Interventionen Bereichsansicht"; 

                if (IDPatient != null && IDPATIENT != System.Guid.Empty)
                {
                    this.btnArztabrechnung.Visible = this._ArztabrechnungJN;        
                }
                else
                {
                    this.btnArztabrechnung.Visible = false;      
                }
            }
            else
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    lblPatName.Visible = true;
                    this.contPatientUserPicker1.Visible = false;
                }
                else
                {
                    lblPatName.Visible = false;
                    this.contPatientUserPicker1.Visible = true;
                }
                if (this.IDPATIENT != System.Guid.Empty)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        //os191224
                        var rPatInfo = (from p in db.Patient
                                        where p.ID == IDPatient
                                        select new
                                        { p.Nachname, p.Vorname }
                                           ).First();
                        //PMDS.db.Entities.Patient rPatient = this.b.getPatient(this.IDPATIENT, db);
                        this.lblPatName.Text = rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim();
                    }
                }
                else
                {
                    this.lblPatName.Text = "";
                }

                lblAufenthalt.Visible = true;
                this.btnIntervention.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen");
                this.btn‹bergabe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("‹bergabe");
                _LastTerminlisteAnsichtsmodi = TerminlisteAnsichtsmodi.Klientanansicht;
                if (PMDS.Global.historie.HistorieOn)
                {
                    panelHistorieBereichOnOff.Visible = true;
                    lblHistorie.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie");
                }
                else
                {
                    panelHistorieBereichOnOff.Visible = false;
                    lblHistorie.Text = "";
                }
                this.btnArztabrechnung.Visible = this._ArztabrechnungJN;         
            }
        }        

        private void ShowHideButtons()
        {
            bool b = IDPATIENT != Guid.Empty;               // Kein Klient selektiert ==> alle Buttons grau bis auf die Klientenliste

            this.ucMedizinDaten1.Visible = b;
            //this.ucMedizinDaten2.Visible = b;               // Medizinische Daten nur dann wenn Klient selektiert ist 

            for (int i = 0; i < 2; i++)
                _buttons[i].Enabled = b;

            btnEvaluierung.Enabled = b;                     // Evaluierung nur wenn einer sekektiert ist
            btnKlient.Enabled = b;
            btnBerichte.Enabled = b;
            //btn18.Enabled = b; //ƒnderung nach 30.07.2007 MDA
            btnWunddoku.Enabled = b;

            // Die Rechte verarbeiten
            if (IDPATIENT != Guid.Empty)
            {
                btnWunddoku.Enabled = ENV.HasRight(UserRights.PflegePlanungAnzeigen);
                btnMitverantwortlicherBereich.Enabled = ENV.HasRight(UserRights.MedikamenteVorbereiten);
                btnPlanung.Enabled = ENV.HasRight(UserRights.PflegePlanungAnzeigen);
                btnEvaluierung.Enabled = ENV.HasRight(UserRights.EvaluierungAnzeigen);
                btn‹bergabe.Enabled = ENV.HasRight(UserRights.Uebergabe);
                btnKlient.Enabled = ENV.HasRight(UserRights.KlientenAktStammdatenAnzeigen);
                btnDatenerhebung.Enabled = ENV.HasRight(UserRights.DatenerhebungAnzeigen);

                if (!PMDS.Global.historie.HistorieOn)
                {
                    this.btnArchiv.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                    this.btnTermine.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                }
            }
            else
            {
                if (ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    this.btnArchiv.Visible = false;
                    this.btnTermine.Visible = false;
                }

                else
                {
                    this.btnArchiv.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                    this.btnTermine.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                }
            
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPATIENT
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                //RefreshPatientInfo(true, false);
            }
        }

        public void RefreshPatientInfo(bool bSelectKlient, bool toolTip, bool clickGridTermine)
        {
            ultraToolTipManager1.Enabled = _IDPatient != Guid.Empty && ENV.ShowPPToolTip;

            if (_IDPatient == Guid.Empty)
            {
                lblPatName.Text = ENV.String("INFO_NO_KLINETSELECTED");
                lblPatRest.Text = "";
                return;
            }
            try
            {
                Patient pat = RefreshPatLabel();

                this.ucMedizinDaten1.Refresh(IDPATIENT, clickGridTermine);

                if(ENV.ShowPPToolTip)
                    SetPlanungsTooltip(pat.Aufenthalt.ID);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
               
            }
        }

        public void clearPatientInfo()
        {
            try
            {
                lblPatName.Text = ENV.String("INFO_NO_KLINETSELECTED");
                lblPatRest.Text = "";

                this.lblHistorie.Text = "";
                this.lblPatRest.Text = "";
                this.lblAufenthalt.Text = "";

                //this.ucMedizinDaten1.Refresh(IDPATIENT);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {

            }
        }

        public void refreshMedizinDaten( )
        {
            try
            {
                this.ucMedizinDaten1.Refresh(IDPATIENT, false);
                //this.ucMedizinDaten2.Refresh(IDPATIENT);

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.refreshMedizinDaten: " + ex.ToString());
            }
        }


        public void setUIHeaderToHistorieBereich(bool bHistOn, bool toolTip, bool bereichsansicht, bool RefreshGui)
        {
           
            Rectangle formRect = this.Bounds;
            Point topLeftOfForm = formRect.Location;

            Rectangle controlRect = this.RectangleToScreen(lblPatName.Bounds);
            Point lowerRightCorner = new Point(controlRect.Right, controlRect.Top );

            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
            //this.lblHistorie.Appearance.TextHAlign = HAlign.Center;

            if (PMDS.Global.historie.HistorieOn)
            {
                this.contPatientUserPicker1.Visible = false;
                this.lblPatName.Visible = true;

                panelHistorieBereichOnOff.Visible = true;
                panelKlientenauswahl.Visible = true;
                this.ucMedizinDaten1.Visible = false;
                btnIntervention.Visible = true;
                btn‹bergabe.Visible = true;
                this.btnArchiv.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                this.btnTermine.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                this.lblAufenthalt.Visible = true;
            }
            else
            {
                this.contPatientUserPicker1.Visible = ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Klientanansicht;

                panelHistorieBereichOnOff.Visible = false;
                panelKlientenauswahl.Visible = true;
                this.ucMedizinDaten1.Visible = true;
                btnIntervention.Visible = true;
                btn‹bergabe.Visible = true;
                this.btnArchiv.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                this.btnTermine.Visible = ENV.HasRight(UserRights.ArchivTerminMail);
                this.lblAufenthalt.Visible = false;
            }

            if (toolTip)
            {
                this.ultraToolTipManager1.SetUltraToolTip(this.lblPatName, ultraToolTipInfo2);
                this.ultraToolTipManager1.ShowToolTip(lblPatName, true, lowerRightCorner);
            }

            if (RefreshGui)
            {

            }
           
        }
        public void setUIHeaderTextBreichsansicht (bool  bereichJN, System.Guid _idAbteilung, System.Guid _idBereich)
        {
            string txt = "";
            //this.lblHistorie.Appearance.TextHAlign = HAlign.Left;
            if (bereichJN)
            {
                if (_idAbteilung == System.Guid.Empty && _idBereich == System.Guid.Empty)
                {
                    Klinik  kl = new Klinik(System.Guid .Empty );
                        
                    DB.DBKlinik DBKlinik1 = new DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinik = DBKlinik1.loadKlinik(ENV.IDKlinik, true);
                     txt += rKlinik.Bezeichnung;

                    //this.lblHistorie.Text = " " + kl.Bezeichnung;
                    //this.btn3.Text = "Interventionen " + "\r\n" + kl.Bezeichnung;
                    //this.btn5.Text = "‹bergabe " + "\r\n" + kl.Bezeichnung;
                }
                else
                {
                    PMDS.DB.DBAbteilung abt = new DB.DBAbteilung();
                 
                    if (_idAbteilung != System.Guid.Empty) txt  += abt.getAbteilungBez(_idAbteilung);
                    if (_idBereich != System.Guid.Empty) txt  += " / " + abt.getBereichBez(_idBereich);


                    //Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipTxtInt = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    //toolTipTxtInt.ToolTipTitle = "Interventionen";
                    //toolTipTxtInt.ToolTipText = "Interventionen f¸r " + txt;
                    //this.ultraToolTipManager2.SetUltraToolTip(this.btn3, toolTipTxtInt);

                    //Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipTxt‹ber = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    //toolTipTxt‹ber.ToolTipTitle = "‹bergabe";
                    //toolTipTxt‹ber.ToolTipText = "‹bergabe f¸r " + txt;
                    //this.ultraToolTipManager2.SetUltraToolTip(this.btn5, toolTipTxt‹ber);

                    //Infragistics.Win.UltraWinToolTip.UltraToolTipInfo toolTipTxtMitVer = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                    //toolTipTxtMitVer.ToolTipTitle = "Mitverantwortlicher Bereich";
                    //toolTipTxtMitVer.ToolTipText = "Mitverantwortlicher Bereich f¸r " + txt;
                    //this.ultraToolTipManager2.SetUltraToolTip(this.btn18, toolTipTxtMitVer);
                }
                
                if (txt.Length > 25)
                {
                    this.lblHistorie.Text = "" + txt.Substring(0, 25) + "...";
                }
                else
                {
                    this.lblHistorie.Text = "" + txt;
                }

                if (txt.Length > 12)
                {
                    this.btnIntervention.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen ") + "\r\n" + txt.Substring(0, 12) + "...";
                    this.btn‹bergabe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("‹bergabe ") + "\r\n" + txt.Substring(0, 12) + "...";
                }
                else
                {
                    this.btnIntervention.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen ") + "\r\n" + txt;
                    this.btn‹bergabe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("‹bergabe ") + "\r\n" + txt;
                }
            }
            else
            {
                this.btnIntervention.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen");
            }
        }

        private Patient RefreshPatLabel()
        {
            Patient pat = new Patient(IDPATIENT);

            string sAlter = "";
            if (pat.Geburtsdatum != null)
            {
                int iAlter = PMDS.DB.PMDSBusiness.GetAgeFromDate((DateTime)pat.Geburtsdatum);
                sAlter = "A:" + iAlter.ToString() + "   ";
            }

            lblPatName.Text = pat.FullName;
            lblPatRest.Text = "Geb. " + ((DateTime)pat.Geburtsdatum).ToShortDateString();
            //lblPatRest.Text += "\r\n";
            lblPatRest.Text += "   ";
            lblPatRest.Text += sAlter + Patient.AktuellePflegeStufeText(_IDPatient);

            return pat;
        }

        private void SetPlanungsTooltip(Guid IDAufenthalt)
        {
            UltraToolTipInfo info = new UltraToolTipInfo();
            PDxResource[] ra = Aufenthalt.GetAllResourceEntries(IDAufenthalt);
            if (ra.Length == 0)
            {
                info.ToolTipText = ENV.String("INFO_KEINE_RESOURCEN");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (PDxResource r in ra)
                {
                    sb.Append(r._Klartext);
                    sb.Append(Environment.NewLine);
                    string sTemp = new string('=', (int)(r._Klartext.Length * 0.8f));
                    sb.Append(sTemp);
                    sb.Append(Environment.NewLine);

                    // Jetzt alle Zeilen einger¸ckt
                    string[] sa = r._Resource.Split(Environment.NewLine.ToCharArray());
                    foreach (string s in sa)
                    {
                        if (s.Length == 0)
                            continue;
                        sb.Append("    ");
                        sb.Append(s.Replace(Environment.NewLine, ""));
                        sb.Append(Environment.NewLine);
                    }
                    sb.Append(Environment.NewLine);
                }
                info.ToolTipText = sb.ToString();
            }

            ultraToolTipManager1.SetUltraToolTip(btnPlanung, info);
        }

        public string LEFTINFO 
		{
			get { return ""; }
			set {  }
		}

		public string MIDDLEINFO 
		{
			get { return ""; }
			set {  }
		}

		public string RIGHTINFO 
		{
			get { return ""; }
			set {  }
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpTerminArchiv");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("popUpTerminArchiv");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DokumentAblegen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DokumentAblegen");
            this.btnKlientenliste = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnRefresh = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelKlientenListe = new QS2.Desktop.ControlManagment.BasePanel();
            this.line3 = new PMDS.GUI.BaseControls.Line();
            this.ucHeader_Fill_Panel = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnArztabrechnung = new QS2.Desktop.ControlManagment.BaseButton();
            this.pnlArchivTermine = new QS2.Desktop.ControlManagment.BasePanel();
            this.line6 = new PMDS.GUI.BaseControls.Line();
            this.btnArchiv = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnTermine = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelPlanungDatenInterv = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnEvaluierung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDatenerhebung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnPlanung = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnIntervention = new QS2.Desktop.ControlManagment.BaseButton();
            this.line2 = new PMDS.GUI.BaseControls.Line();
            this.pMiddle = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnBerichte = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnKlient = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnMitverantwortlicherBereich = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnWunddoku = new QS2.Desktop.ControlManagment.BaseButton();
            this.pnlRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.btn‹bergabe = new QS2.Desktop.ControlManagment.BaseButton();
            this.line5 = new PMDS.GUI.BaseControls.Line();
            this.line1 = new PMDS.GUI.BaseControls.Line();
            this.pLeft = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelKlientenauswahl = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblPatRest = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAufenthalt = new QS2.Desktop.ControlManagment.BaseLabel();
            this.contPatientUserPicker1 = new PMDS.GUI.PatientUserPicker.contPatientUserPicker();
            this.lblPatName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelHistorieBereichOnOff = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblHistorie = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelLineHoriz = new System.Windows.Forms.Panel();
            this.ucMedizinDaten1 = new PMDS.GUI.BaseControls.ucMedizinDaten();
            this._ucHeader_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManagerPlanArchiv = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._ucHeader_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucHeader_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ucHeader_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolTipManagerWarningMemory = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelKlientenListe.SuspendLayout();
            this.ucHeader_Fill_Panel.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.pAll.SuspendLayout();
            this.pnlArchivTermine.SuspendLayout();
            this.panelPlanungDatenInterv.SuspendLayout();
            this.pMiddle.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.panelKlientenauswahl.SuspendLayout();
            this.panelHistorieBereichOnOff.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManagerPlanArchiv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKlientenliste
            // 
            this.btnKlientenliste.AcceptsFocus = false;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.btnKlientenliste.Appearance = appearance1;
            this.btnKlientenliste.AutoWorkLayout = false;
            this.btnKlientenliste.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKlientenliste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKlientenliste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKlientenliste.ImageSize = new System.Drawing.Size(40, 40);
            this.btnKlientenliste.IsStandardControl = false;
            this.btnKlientenliste.Location = new System.Drawing.Point(3, 6);
            this.btnKlientenliste.Name = "btnKlientenliste";
            this.btnKlientenliste.ShowFocusRect = false;
            this.btnKlientenliste.ShowOutline = false;
            this.btnKlientenliste.Size = new System.Drawing.Size(77, 55);
            this.btnKlientenliste.TabIndex = 24;
            this.btnKlientenliste.Text = "Klienten Liste";
            this.btnKlientenliste.UseAppStyling = false;
            this.btnKlientenliste.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnKlientenliste.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnKlientenliste.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnKlientenliste.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AcceptsFocus = false;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance2.TextVAlignAsString = "Bottom";
            this.btnRefresh.Appearance = appearance2;
            this.btnRefresh.AutoWorkLayout = false;
            this.btnRefresh.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRefresh.IsStandardControl = false;
            this.btnRefresh.Location = new System.Drawing.Point(3, 67);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowFocusRect = false;
            this.btnRefresh.ShowOutline = false;
            this.btnRefresh.Size = new System.Drawing.Size(77, 28);
            this.btnRefresh.TabIndex = 34;
            this.btnRefresh.UseAppStyling = false;
            this.btnRefresh.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnRefresh.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnRefresh.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Office2013;
            this.ultraToolTipManager1.InitialDelay = 0;
            this.ultraToolTipManager1.ToolTipImage = Infragistics.Win.ToolTipImage.Info;
            this.ultraToolTipManager1.ToolTipTitle = "Vorhandene Ressourcen";
            // 
            // panelKlientenListe
            // 
            this.panelKlientenListe.BackColor = System.Drawing.Color.Transparent;
            this.panelKlientenListe.Controls.Add(this.btnRefresh);
            this.panelKlientenListe.Controls.Add(this.line3);
            this.panelKlientenListe.Controls.Add(this.btnKlientenliste);
            this.panelKlientenListe.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelKlientenListe.Location = new System.Drawing.Point(1199, 0);
            this.panelKlientenListe.Name = "panelKlientenListe";
            this.panelKlientenListe.Size = new System.Drawing.Size(84, 110);
            this.panelKlientenListe.TabIndex = 28;
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.Black;
            this.line3.Dock = System.Windows.Forms.DockStyle.Left;
            this.line3.Location = new System.Drawing.Point(0, 0);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(1, 110);
            this.line3.TabIndex = 25;
            this.line3.Visible = false;
            // 
            // ucHeader_Fill_Panel
            // 
            this.ucHeader_Fill_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucHeader_Fill_Panel.BackColor = System.Drawing.Color.White;
            this.ucHeader_Fill_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucHeader_Fill_Panel.Controls.Add(this.panelTop);
            this.ucHeader_Fill_Panel.Controls.Add(this.panelBottom);
            this.ucHeader_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucHeader_Fill_Panel.Location = new System.Drawing.Point(4, 2);
            this.ucHeader_Fill_Panel.Name = "ucHeader_Fill_Panel";
            this.ucHeader_Fill_Panel.Size = new System.Drawing.Size(1285, 139);
            this.ucHeader_Fill_Panel.TabIndex = 0;
            this.ucHeader_Fill_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.ucHeader_Fill_Panel_Paint);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.pAll);
            this.panelTop.Controls.Add(this.panelKlientenListe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1283, 110);
            this.panelTop.TabIndex = 32;
            // 
            // pAll
            // 
            this.pAll.BackColor = System.Drawing.Color.Transparent;
            this.pAll.Controls.Add(this.btnArztabrechnung);
            this.pAll.Controls.Add(this.pnlArchivTermine);
            this.pAll.Controls.Add(this.panelPlanungDatenInterv);
            this.pAll.Controls.Add(this.line2);
            this.pAll.Controls.Add(this.pMiddle);
            this.pAll.Controls.Add(this.pnlRight);
            this.pAll.Controls.Add(this.line1);
            this.pAll.Controls.Add(this.pLeft);
            this.pAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAll.Location = new System.Drawing.Point(0, 0);
            this.pAll.Name = "pAll";
            this.pAll.Size = new System.Drawing.Size(1199, 110);
            this.pAll.TabIndex = 20;
            this.pAll.Paint += new System.Windows.Forms.PaintEventHandler(this.pAll_Paint);
            // 
            // btnArztabrechnung
            // 
            this.btnArztabrechnung.AcceptsFocus = false;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance3.TextVAlignAsString = "Bottom";
            this.btnArztabrechnung.Appearance = appearance3;
            this.btnArztabrechnung.AutoWorkLayout = false;
            this.btnArztabrechnung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnArztabrechnung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArztabrechnung.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArztabrechnung.ImageSize = new System.Drawing.Size(20, 20);
            this.btnArztabrechnung.IsStandardControl = false;
            this.btnArztabrechnung.Location = new System.Drawing.Point(1005, 5);
            this.btnArztabrechnung.Name = "btnArztabrechnung";
            this.btnArztabrechnung.ShowFocusRect = false;
            this.btnArztabrechnung.ShowOutline = false;
            this.btnArztabrechnung.Size = new System.Drawing.Size(71, 42);
            this.btnArztabrechnung.TabIndex = 33;
            this.btnArztabrechnung.Text = "Arztabrechnung";
            this.btnArztabrechnung.UseAppStyling = false;
            this.btnArztabrechnung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnArztabrechnung.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnArztabrechnung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnArztabrechnung.Click += new System.EventHandler(this.btnArztabrechnung_Click);
            // 
            // pnlArchivTermine
            // 
            this.pnlArchivTermine.BackColor = System.Drawing.Color.Transparent;
            this.pnlArchivTermine.Controls.Add(this.line6);
            this.pnlArchivTermine.Controls.Add(this.btnArchiv);
            this.pnlArchivTermine.Controls.Add(this.btnTermine);
            this.pnlArchivTermine.Location = new System.Drawing.Point(930, 0);
            this.pnlArchivTermine.Name = "pnlArchivTermine";
            this.pnlArchivTermine.Size = new System.Drawing.Size(70, 106);
            this.pnlArchivTermine.TabIndex = 32;
            // 
            // line6
            // 
            this.line6.BackColor = System.Drawing.Color.Black;
            this.line6.Dock = System.Windows.Forms.DockStyle.Left;
            this.line6.Location = new System.Drawing.Point(0, 0);
            this.line6.Name = "line6";
            this.line6.Size = new System.Drawing.Size(1, 106);
            this.line6.TabIndex = 24;
            // 
            // btnArchiv
            // 
            this.btnArchiv.AcceptsFocus = false;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance4.TextVAlignAsString = "Bottom";
            this.btnArchiv.Appearance = appearance4;
            this.btnArchiv.AutoWorkLayout = false;
            this.btnArchiv.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnArchiv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchiv.ImageSize = new System.Drawing.Size(20, 20);
            this.btnArchiv.IsStandardControl = false;
            this.btnArchiv.Location = new System.Drawing.Point(3, 5);
            this.btnArchiv.Name = "btnArchiv";
            this.btnArchiv.ShowFocusRect = false;
            this.btnArchiv.ShowOutline = false;
            this.btnArchiv.Size = new System.Drawing.Size(62, 42);
            this.btnArchiv.TabIndex = 29;
            this.btnArchiv.Text = "Archiv";
            this.btnArchiv.UseAppStyling = false;
            this.btnArchiv.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnArchiv.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnArchiv.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnArchiv.Click += new System.EventHandler(this.neuesDokument);
            // 
            // btnTermine
            // 
            this.btnTermine.AcceptsFocus = false;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance5.TextVAlignAsString = "Bottom";
            this.btnTermine.Appearance = appearance5;
            this.btnTermine.AutoWorkLayout = false;
            this.btnTermine.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnTermine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTermine.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTermine.ImageSize = new System.Drawing.Size(20, 20);
            this.btnTermine.IsStandardControl = false;
            this.btnTermine.Location = new System.Drawing.Point(3, 53);
            this.btnTermine.Name = "btnTermine";
            this.btnTermine.ShowFocusRect = false;
            this.btnTermine.ShowOutline = false;
            this.btnTermine.Size = new System.Drawing.Size(62, 42);
            this.btnTermine.TabIndex = 30;
            this.btnTermine.Text = "Termine";
            this.btnTermine.UseAppStyling = false;
            this.btnTermine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnTermine.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnTermine.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnTermine.Click += new System.EventHandler(this.neuerTermin);
            // 
            // panelPlanungDatenInterv
            // 
            this.panelPlanungDatenInterv.BackColor = System.Drawing.Color.Transparent;
            this.panelPlanungDatenInterv.Controls.Add(this.btnEvaluierung);
            this.panelPlanungDatenInterv.Controls.Add(this.btnDatenerhebung);
            this.panelPlanungDatenInterv.Controls.Add(this.btnPlanung);
            this.panelPlanungDatenInterv.Controls.Add(this.btnIntervention);
            this.panelPlanungDatenInterv.Location = new System.Drawing.Point(463, 0);
            this.panelPlanungDatenInterv.MinimumSize = new System.Drawing.Size(330, 0);
            this.panelPlanungDatenInterv.Name = "panelPlanungDatenInterv";
            this.panelPlanungDatenInterv.Size = new System.Drawing.Size(360, 106);
            this.panelPlanungDatenInterv.TabIndex = 23;
            // 
            // btnEvaluierung
            // 
            this.btnEvaluierung.AcceptsFocus = false;
            appearance6.FontData.SizeInPoints = 8F;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance6.TextVAlignAsString = "Middle";
            this.btnEvaluierung.Appearance = appearance6;
            this.btnEvaluierung.AutoWorkLayout = false;
            this.btnEvaluierung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnEvaluierung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvaluierung.ImageSize = new System.Drawing.Size(40, 40);
            this.btnEvaluierung.IsStandardControl = false;
            this.btnEvaluierung.Location = new System.Drawing.Point(279, 6);
            this.btnEvaluierung.Name = "btnEvaluierung";
            this.btnEvaluierung.ShowFocusRect = false;
            this.btnEvaluierung.ShowOutline = false;
            this.btnEvaluierung.Size = new System.Drawing.Size(82, 88);
            this.btnEvaluierung.TabIndex = 22;
            this.btnEvaluierung.Tag = "";
            this.btnEvaluierung.Text = "Evaluierung";
            this.btnEvaluierung.UseAppStyling = false;
            this.btnEvaluierung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnEvaluierung.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnEvaluierung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnEvaluierung.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnDatenerhebung
            // 
            this.btnDatenerhebung.AcceptsFocus = false;
            appearance7.AlphaLevel = ((short)(255));
            appearance7.FontData.SizeInPoints = 8F;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance7.TextVAlignAsString = "Middle";
            this.btnDatenerhebung.Appearance = appearance7;
            this.btnDatenerhebung.AutoWorkLayout = false;
            this.btnDatenerhebung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnDatenerhebung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatenerhebung.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDatenerhebung.IsStandardControl = false;
            this.btnDatenerhebung.Location = new System.Drawing.Point(4, 6);
            this.btnDatenerhebung.Name = "btnDatenerhebung";
            this.btnDatenerhebung.ShowFocusRect = false;
            this.btnDatenerhebung.ShowOutline = false;
            this.btnDatenerhebung.Size = new System.Drawing.Size(87, 88);
            this.btnDatenerhebung.TabIndex = 19;
            this.btnDatenerhebung.Text = "Datenerhebung";
            this.btnDatenerhebung.UseAppStyling = false;
            this.btnDatenerhebung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnDatenerhebung.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnDatenerhebung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnDatenerhebung.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnPlanung
            // 
            this.btnPlanung.AcceptsFocus = false;
            appearance8.FontData.SizeInPoints = 8F;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance8.TextVAlignAsString = "Middle";
            this.btnPlanung.Appearance = appearance8;
            this.btnPlanung.AutoWorkLayout = false;
            this.btnPlanung.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnPlanung.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanung.ImageSize = new System.Drawing.Size(40, 40);
            this.btnPlanung.IsStandardControl = false;
            this.btnPlanung.Location = new System.Drawing.Point(96, 6);
            this.btnPlanung.Name = "btnPlanung";
            this.btnPlanung.ShowFocusRect = false;
            this.btnPlanung.ShowOutline = false;
            this.btnPlanung.Size = new System.Drawing.Size(82, 88);
            this.btnPlanung.TabIndex = 20;
            this.btnPlanung.Text = "Planung";
            this.btnPlanung.UseAppStyling = false;
            this.btnPlanung.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnPlanung.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnPlanung.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnPlanung.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnIntervention
            // 
            this.btnIntervention.AcceptsFocus = false;
            appearance9.FontData.SizeInPoints = 8F;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance9.TextVAlignAsString = "Middle";
            this.btnIntervention.Appearance = appearance9;
            this.btnIntervention.AutoWorkLayout = false;
            this.btnIntervention.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnIntervention.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntervention.ImageSize = new System.Drawing.Size(40, 40);
            this.btnIntervention.IsStandardControl = false;
            this.btnIntervention.Location = new System.Drawing.Point(184, 6);
            this.btnIntervention.Name = "btnIntervention";
            this.btnIntervention.ShowFocusRect = false;
            this.btnIntervention.ShowOutline = false;
            this.btnIntervention.Size = new System.Drawing.Size(89, 88);
            this.btnIntervention.TabIndex = 21;
            this.btnIntervention.Text = "Intervention";
            this.btnIntervention.UseAppStyling = false;
            this.btnIntervention.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnIntervention.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnIntervention.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnIntervention.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.Black;
            this.line2.Dock = System.Windows.Forms.DockStyle.Left;
            this.line2.Location = new System.Drawing.Point(461, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(1, 110);
            this.line2.TabIndex = 15;
            // 
            // pMiddle
            // 
            this.pMiddle.BackColor = System.Drawing.Color.Transparent;
            this.pMiddle.Controls.Add(this.btnBerichte);
            this.pMiddle.Controls.Add(this.btnKlient);
            this.pMiddle.Controls.Add(this.btnMitverantwortlicherBereich);
            this.pMiddle.Controls.Add(this.btnWunddoku);
            this.pMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMiddle.Location = new System.Drawing.Point(329, 0);
            this.pMiddle.Name = "pMiddle";
            this.pMiddle.Size = new System.Drawing.Size(132, 110);
            this.pMiddle.TabIndex = 18;
            // 
            // btnBerichte
            // 
            this.btnBerichte.AcceptsFocus = false;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance10.TextVAlignAsString = "Bottom";
            this.btnBerichte.Appearance = appearance10;
            this.btnBerichte.AutoWorkLayout = false;
            this.btnBerichte.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBerichte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBerichte.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBerichte.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBerichte.IsStandardControl = false;
            this.btnBerichte.Location = new System.Drawing.Point(68, 5);
            this.btnBerichte.Name = "btnBerichte";
            this.btnBerichte.ShowFocusRect = false;
            this.btnBerichte.ShowOutline = false;
            this.btnBerichte.Size = new System.Drawing.Size(60, 43);
            this.btnBerichte.TabIndex = 24;
            this.btnBerichte.Text = "Berichte";
            this.btnBerichte.UseAppStyling = false;
            this.btnBerichte.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnBerichte.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnBerichte.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBerichte.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnKlient
            // 
            this.btnKlient.AcceptsFocus = false;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance11.TextVAlignAsString = "Bottom";
            this.btnKlient.Appearance = appearance11;
            this.btnKlient.AutoWorkLayout = false;
            this.btnKlient.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKlient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKlient.ImageSize = new System.Drawing.Size(20, 20);
            this.btnKlient.IsStandardControl = false;
            this.btnKlient.Location = new System.Drawing.Point(3, 5);
            this.btnKlient.Name = "btnKlient";
            this.btnKlient.ShowFocusRect = false;
            this.btnKlient.ShowOutline = false;
            this.btnKlient.Size = new System.Drawing.Size(62, 42);
            this.btnKlient.TabIndex = 23;
            this.btnKlient.Text = "Klient";
            this.btnKlient.UseAppStyling = false;
            this.btnKlient.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnKlient.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnKlient.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnKlient.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // btnMitverantwortlicherBereich
            // 
            this.btnMitverantwortlicherBereich.AcceptsFocus = false;
            appearance12.BackColor = System.Drawing.Color.Transparent;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance12.TextVAlignAsString = "Bottom";
            this.btnMitverantwortlicherBereich.Appearance = appearance12;
            this.btnMitverantwortlicherBereich.AutoWorkLayout = false;
            this.btnMitverantwortlicherBereich.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnMitverantwortlicherBereich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMitverantwortlicherBereich.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMitverantwortlicherBereich.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMitverantwortlicherBereich.IsStandardControl = false;
            this.btnMitverantwortlicherBereich.Location = new System.Drawing.Point(3, 53);
            this.btnMitverantwortlicherBereich.Name = "btnMitverantwortlicherBereich";
            this.btnMitverantwortlicherBereich.ShowFocusRect = false;
            this.btnMitverantwortlicherBereich.ShowOutline = false;
            this.btnMitverantwortlicherBereich.Size = new System.Drawing.Size(62, 42);
            this.btnMitverantwortlicherBereich.TabIndex = 25;
            this.btnMitverantwortlicherBereich.Text = "Mitv. Bereich";
            this.btnMitverantwortlicherBereich.UseAppStyling = false;
            this.btnMitverantwortlicherBereich.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnMitverantwortlicherBereich.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnMitverantwortlicherBereich.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnMitverantwortlicherBereich.Click += new System.EventHandler(this.ultraButton1_Click);
            this.btnMitverantwortlicherBereich.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn18_MouseUp);
            // 
            // btnWunddoku
            // 
            this.btnWunddoku.AcceptsFocus = false;
            appearance13.BackColor = System.Drawing.Color.Transparent;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance13.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance13.TextVAlignAsString = "Bottom";
            this.btnWunddoku.Appearance = appearance13;
            this.btnWunddoku.AutoWorkLayout = false;
            this.btnWunddoku.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnWunddoku.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWunddoku.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWunddoku.ImageSize = new System.Drawing.Size(20, 20);
            this.btnWunddoku.IsStandardControl = false;
            this.btnWunddoku.Location = new System.Drawing.Point(68, 54);
            this.btnWunddoku.Name = "btnWunddoku";
            this.btnWunddoku.ShowFocusRect = false;
            this.btnWunddoku.ShowOutline = false;
            this.btnWunddoku.Size = new System.Drawing.Size(60, 42);
            this.btnWunddoku.TabIndex = 26;
            this.btnWunddoku.Text = "Wund-Doku";
            this.btnWunddoku.UseAppStyling = false;
            this.btnWunddoku.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnWunddoku.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnWunddoku.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnWunddoku.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.btn‹bergabe);
            this.pnlRight.Controls.Add(this.line5);
            this.pnlRight.Location = new System.Drawing.Point(829, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(100, 106);
            this.pnlRight.TabIndex = 22;
            // 
            // btn‹bergabe
            // 
            this.btn‹bergabe.AcceptsFocus = false;
            appearance14.FontData.SizeInPoints = 8F;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance14.TextVAlignAsString = "Middle";
            this.btn‹bergabe.Appearance = appearance14;
            this.btn‹bergabe.AutoWorkLayout = false;
            this.btn‹bergabe.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btn‹bergabe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn‹bergabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn‹bergabe.ImageSize = new System.Drawing.Size(40, 40);
            this.btn‹bergabe.IsStandardControl = false;
            this.btn‹bergabe.Location = new System.Drawing.Point(6, 6);
            this.btn‹bergabe.Name = "btn‹bergabe";
            this.btn‹bergabe.ShowFocusRect = false;
            this.btn‹bergabe.ShowOutline = false;
            this.btn‹bergabe.Size = new System.Drawing.Size(89, 87);
            this.btn‹bergabe.TabIndex = 23;
            this.btn‹bergabe.Tag = "";
            this.btn‹bergabe.Text = "‹bergabe";
            this.btn‹bergabe.UseAppStyling = false;
            this.btn‹bergabe.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btn‹bergabe.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn‹bergabe.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btn‹bergabe.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // line5
            // 
            this.line5.BackColor = System.Drawing.Color.Black;
            this.line5.Dock = System.Windows.Forms.DockStyle.Left;
            this.line5.Location = new System.Drawing.Point(0, 0);
            this.line5.Name = "line5";
            this.line5.Size = new System.Drawing.Size(1, 106);
            this.line5.TabIndex = 24;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Black;
            this.line1.Dock = System.Windows.Forms.DockStyle.Left;
            this.line1.Location = new System.Drawing.Point(328, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1, 110);
            this.line1.TabIndex = 14;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.Transparent;
            this.pLeft.Controls.Add(this.panelKlientenauswahl);
            this.pLeft.Controls.Add(this.panelHistorieBereichOnOff);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(328, 110);
            this.pLeft.TabIndex = 17;
            this.pLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pLeft_Paint);
            // 
            // panelKlientenauswahl
            // 
            this.panelKlientenauswahl.Controls.Add(this.lblPatRest);
            this.panelKlientenauswahl.Controls.Add(this.lblAufenthalt);
            this.panelKlientenauswahl.Controls.Add(this.contPatientUserPicker1);
            this.panelKlientenauswahl.Controls.Add(this.lblPatName);
            this.panelKlientenauswahl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKlientenauswahl.Location = new System.Drawing.Point(0, 21);
            this.panelKlientenauswahl.Name = "panelKlientenauswahl";
            this.panelKlientenauswahl.Size = new System.Drawing.Size(328, 89);
            this.panelKlientenauswahl.TabIndex = 32;
            // 
            // lblPatRest
            // 
            this.lblPatRest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.FontData.SizeInPoints = 9F;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.lblPatRest.Appearance = appearance15;
            this.lblPatRest.Font = new System.Drawing.Font("Arial", 7F);
            this.lblPatRest.Location = new System.Drawing.Point(5, 32);
            this.lblPatRest.Name = "lblPatRest";
            this.lblPatRest.Size = new System.Drawing.Size(315, 17);
            this.lblPatRest.TabIndex = 2;
            this.lblPatRest.Text = "01.01.1960 PS6";
            // 
            // lblAufenthalt
            // 
            this.lblAufenthalt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.ForeColor = System.Drawing.Color.Black;
            this.lblAufenthalt.Appearance = appearance16;
            this.lblAufenthalt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAufenthalt.Location = new System.Drawing.Point(5, 53);
            this.lblAufenthalt.Name = "lblAufenthalt";
            this.lblAufenthalt.Size = new System.Drawing.Size(315, 30);
            this.lblAufenthalt.TabIndex = 29;
            this.lblAufenthalt.Visible = false;
            // 
            // contPatientUserPicker1
            // 
            this.contPatientUserPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contPatientUserPicker1.BackColor = System.Drawing.Color.White;
            this.contPatientUserPicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contPatientUserPicker1.Location = new System.Drawing.Point(4, 4);
            this.contPatientUserPicker1.Name = "contPatientUserPicker1";
            this.contPatientUserPicker1.Size = new System.Drawing.Size(319, 25);
            this.contPatientUserPicker1.TabIndex = 34;
            // 
            // lblPatName
            // 
            this.lblPatName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.FontData.BoldAsString = "True";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.lblPatName.Appearance = appearance17;
            this.lblPatName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPatName.Location = new System.Drawing.Point(5, 4);
            this.lblPatName.Name = "lblPatName";
            this.lblPatName.Size = new System.Drawing.Size(315, 23);
            this.lblPatName.TabIndex = 1;
            this.lblPatName.Text = "Keinen Klienten ausgew‰hlt";
            // 
            // panelHistorieBereichOnOff
            // 
            this.panelHistorieBereichOnOff.BackColor = System.Drawing.Color.Transparent;
            this.panelHistorieBereichOnOff.Controls.Add(this.lblHistorie);
            this.panelHistorieBereichOnOff.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistorieBereichOnOff.Location = new System.Drawing.Point(0, 0);
            this.panelHistorieBereichOnOff.Name = "panelHistorieBereichOnOff";
            this.panelHistorieBereichOnOff.Size = new System.Drawing.Size(328, 21);
            this.panelHistorieBereichOnOff.TabIndex = 31;
            this.panelHistorieBereichOnOff.Visible = false;
            // 
            // lblHistorie
            // 
            this.lblHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.BackColor2 = System.Drawing.Color.Transparent;
            appearance18.FontData.SizeInPoints = 12F;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Bottom";
            this.lblHistorie.Appearance = appearance18;
            this.lblHistorie.ImageSize = new System.Drawing.Size(24, 24);
            this.lblHistorie.Location = new System.Drawing.Point(4, 0);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(316, 21);
            this.lblHistorie.TabIndex = 29;
            this.lblHistorie.Text = "Historie";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.panelLineHoriz);
            this.panelBottom.Controls.Add(this.ucMedizinDaten1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 110);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1283, 27);
            this.panelBottom.TabIndex = 31;
            // 
            // panelLineHoriz
            // 
            this.panelLineHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLineHoriz.BackColor = System.Drawing.Color.Black;
            this.panelLineHoriz.Location = new System.Drawing.Point(1, 0);
            this.panelLineHoriz.Name = "panelLineHoriz";
            this.panelLineHoriz.Size = new System.Drawing.Size(1280, 1);
            this.panelLineHoriz.TabIndex = 34;
            // 
            // ucMedizinDaten1
            // 
            this.ucMedizinDaten1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMedizinDaten1.BackColor = System.Drawing.Color.Transparent;
            this.ucMedizinDaten1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMedizinDaten1.Location = new System.Drawing.Point(5, 4);
            this.ucMedizinDaten1.Name = "ucMedizinDaten1";
            this.ucMedizinDaten1.Size = new System.Drawing.Size(1274, 19);
            this.ucMedizinDaten1.TabIndex = 26;
            // 
            // _ucHeader_Toolbars_Dock_Area_Left
            // 
            this._ucHeader_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHeader_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White;
            this._ucHeader_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ucHeader_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHeader_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._ucHeader_Toolbars_Dock_Area_Left.Name = "_ucHeader_Toolbars_Dock_Area_Left";
            this._ucHeader_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 141);
            this._ucHeader_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManagerPlanArchiv;
            // 
            // ultraToolbarsManagerPlanArchiv
            // 
            this.ultraToolbarsManagerPlanArchiv.DesignerFlags = 1;
            this.ultraToolbarsManagerPlanArchiv.DockWithinContainer = this;
            this.ultraToolbarsManagerPlanArchiv.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            ultraToolbar1.Visible = false;
            this.ultraToolbarsManagerPlanArchiv.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            popupMenuTool1.SharedPropsInternal.Caption = "Termin/Archiv";
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3});
            buttonTool1.SharedPropsInternal.Caption = "Dokument ablegen";
            this.ultraToolbarsManagerPlanArchiv.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            buttonTool1});
            this.ultraToolbarsManagerPlanArchiv.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _ucHeader_Toolbars_Dock_Area_Right
            // 
            this._ucHeader_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHeader_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White;
            this._ucHeader_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ucHeader_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHeader_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1293, 0);
            this._ucHeader_Toolbars_Dock_Area_Right.Name = "_ucHeader_Toolbars_Dock_Area_Right";
            this._ucHeader_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 141);
            this._ucHeader_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManagerPlanArchiv;
            // 
            // _ucHeader_Toolbars_Dock_Area_Top
            // 
            this._ucHeader_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHeader_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White;
            this._ucHeader_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ucHeader_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHeader_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ucHeader_Toolbars_Dock_Area_Top.Name = "_ucHeader_Toolbars_Dock_Area_Top";
            this._ucHeader_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1293, 0);
            this._ucHeader_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManagerPlanArchiv;
            // 
            // _ucHeader_Toolbars_Dock_Area_Bottom
            // 
            this._ucHeader_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ucHeader_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White;
            this._ucHeader_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ucHeader_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ucHeader_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 141);
            this._ucHeader_Toolbars_Dock_Area_Bottom.Name = "_ucHeader_Toolbars_Dock_Area_Bottom";
            this._ucHeader_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1293, 0);
            this._ucHeader_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManagerPlanArchiv;
            // 
            // ultraToolTipManagerWarningMemory
            // 
            this.ultraToolTipManagerWarningMemory.AutoPopDelay = 0;
            this.ultraToolTipManagerWarningMemory.ContainingControl = this;
            this.ultraToolTipManagerWarningMemory.InitialDelay = 0;
            this.ultraToolTipManagerWarningMemory.ToolTipImage = Infragistics.Win.ToolTipImage.Warning;
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // ucHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucHeader_Fill_Panel);
            this.Controls.Add(this._ucHeader_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ucHeader_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ucHeader_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._ucHeader_Toolbars_Dock_Area_Top);
            this.Name = "ucHeader";
            this.Size = new System.Drawing.Size(1293, 141);
            this.Load += new System.EventHandler(this.ucHeader_Load);
            this.VisibleChanged += new System.EventHandler(this.ucHeader_VisibleChanged);
            this.Resize += new System.EventHandler(this.ucHeader_Resize);
            this.panelKlientenListe.ResumeLayout(false);
            this.ucHeader_Fill_Panel.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.pAll.ResumeLayout(false);
            this.pnlArchivTermine.ResumeLayout(false);
            this.panelPlanungDatenInterv.ResumeLayout(false);
            this.pMiddle.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.panelKlientenauswahl.ResumeLayout(false);
            this.panelHistorieBereichOnOff.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManagerPlanArchiv)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

	    
		private void ucHeader_Resize(object sender, System.EventArgs e)
		{
           
		}

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.contPatientUserPicker1.contSelectPatienten.TreeLockItemChangedReadyLoad)
                {
                    return;
                }

                this.Cursor = Cursors.Default;

                if (!this._action) return;

                if (_ButtonInProgress)
                    return;
                    _ButtonInProgress = true;
                    int i = (int)((UltraButton)sender).Tag;
                    ProcessButton1_5(i);

                // Event feuern
                if (HeaderButtonClick != null)
                {
                    //HeaderButtons h = (HeaderButtons)i;
                    //ucHeader.lastButtonClicked = h;
                    //HeaderButtonClick(h, true);
                    //this.checkMemory();                         //lthnew
                }
                        
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally 
            {
                _ButtonInProgress = false;
                this.Cursor = Cursors.WaitCursor  ;
            }
        }

        public void ProcessButton1_5(int ineu)
        {
            try
            {
                this.setButtonsDeaktive();
                
                if (ineu < 6)
                    PMDS.Global.UIGlobal.setAktiv(_buttons[ineu], ineu, activeForeCol, activeFrameCol, activeBackCol);
                else if (ineu == (int)HeaderButtons.Details)      // Details soll auch markiert bleiben
                    PMDS.Global.UIGlobal.setAktiv(btnKlient, -1, activeForeCol, activeFrameCol, activeBackCol);
                else if (ineu == (int)HeaderButtons.Berichte)      // Berichte soll auch markiert bleiben
                    PMDS.Global.UIGlobal.setAktiv(btnBerichte, -1, activeForeCol, activeFrameCol, activeBackCol);
                else if (ineu == (int)HeaderButtons.Medikamente)      // Medikamente soll auch markiert bleiben
                    PMDS.Global.UIGlobal.setAktiv(btnMitverantwortlicherBereich, -1, activeForeCol, activeFrameCol, activeBackCol);
                else if (ineu == (int)HeaderButtons.Wunde)      // Wunde soll auch markiert bleiben
                    PMDS.Global.UIGlobal.setAktiv(btnWunddoku, -1, activeForeCol, activeFrameCol, activeBackCol);
                
            }
            catch (Exception ex)
            {
                throw new Exception("ProcessButton1_5: " + ex.ToString());
            }
        }
        public void setButtonsDeaktive()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Color aktBorderCol = activeFrameCol;
                    Color hotTrackBackCol = hoverBackCol;
                    PMDS.Global.UIGlobal.setAktivDisable(_buttons[i], i, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);
                }

                PMDS.Global.UIGlobal.setAktivDisable(btnKlientenliste, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);
                PMDS.Global.UIGlobal.setAktivDisable(btnKlient, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);                // Details button
                PMDS.Global.UIGlobal.setAktivDisable(btnBerichte, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);                // Berichte Button
                PMDS.Global.UIGlobal.setAktivDisable(btnMitverantwortlicherBereich, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);                // Mitverantwortlicher Bereich Button
                PMDS.Global.UIGlobal.setAktivDisable(btnWunddoku, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);                // Wunde

                PMDS.Global.UIGlobal.setAktivDisable(btnArchiv, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);
                PMDS.Global.UIGlobal.setAktivDisable(btnTermine, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);
                PMDS.Global.UIGlobal.setAktivDisable(this.btnArztabrechnung, -1, activeForeCol, hoverBackCol, activeFrameCol, inactiveBackCol, UIElementButtonStyle.Flat);

            }
            catch (Exception ex)
            {
                throw new Exception("setButtonsDeaktive: " + ex.ToString());
            }
        }

        private class Imagesstore
        {

            public Imagesstore(Bitmap Normal, Bitmap Hoover, Bitmap Select)
            {
                _Normal = Normal;
                _Hoover = Hoover;
                _Select = Select;
            }
            public Bitmap _Normal;
            public Bitmap _Hoover;
            public Bitmap _Select;
        }

        public enum HeaderButtons
        {
            Anamnese = 0,
            Planung = 1,
            Durchf¸hrung = 2,
            Evaluierung = 3,
            Uebergabe = 4,
            intervHistorie = 5,
            Details = 14,
            Klienten = 15,
            Medikamente = 17,
            Wunde =18,
            Berichte    = 19,

            none = 100
        }

        public delegate void HeaderButtonClickDelegate(HeaderButtons Button, bool refreshData);

        private void pAll_Paint(object sender, PaintEventArgs e)
        {
        
        }

        //new picker
        public void PickerValueChanged(Guid IDPatient)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _PreventSelfRefreshing = true;


                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Aufenthalt rActAuf = this.b.getAktuellerAufenthaltPatient(IDPatient, false, db);

                    if (PMDS.Global.historie.HistorieOn)
                    {
                        PMDS.Global.historie hist = new PMDS.Global.historie();
                        hist.IDAufenthalt = rActAuf.ID;
                    }
                    else
                    {
                        ENV.setIDAUFENTHALT = rActAuf.ID;
                    }
                    ENV.setIDAUFENTHALT = Aufenthalt.LastByPatient(IDPatient);

                    //AskForSave();

                    ENV.setCurrentIDPatient = IDPatient;
                    this.IDPATIENT = ENV.CurrentIDPatient;

                    ENV.sendPatientChanged(eCurrentPatientChange.PickerLinksOben, false, false);
                    //RefreshControl(ENV.CurrentIDPatient, false);
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                throw new Exception("PickerValueChanged: " + ex.ToString());
            }
            finally
            {
                _PreventSelfRefreshing = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void ucHeader_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnDatenerhebung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 64, 64);
                this.btnPlanung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Planung, 64, 64);
                this.btnIntervention.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Interventionen, 64, 64);
                this.btnEvaluierung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Evaluierung, 64, 64);
                this.btn‹bergabe.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Uebergabe, 64, 64);
                this.btnKlientenliste.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Klientenliste, 64, 64);
                this.btnKlient.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);
                this.btnBerichte.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);
                this.btnMitverantwortlicherBereich.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_MitverantworticherBereich, 32, 32);
                this.btnWunddoku.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Wunddoku, 32, 32);
                this.btnArchiv.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Archiv, 32, 32);
                this.btnTermine.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kliententermine, 32, 32);
                //lthArztabrechnung
                this.btnArztabrechnung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Abrechnung.ico_Abrechnung, 32, 32);
                this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void ucHeader_VisibleChanged(object sender, EventArgs e)
        {
            if (_RefreshShouldBeAfterVisible && this.Visible)
            {
                if (ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Bereichsansicht)
                    RefreshPatientInfo(false, true, false);
                else
                    if (PMDS.Global.historie.HistorieOn) RefreshPatientInfo(true, true, false); 
                
                ShowHideButtons();
                _RefreshShouldBeAfterVisible = false;
            }

            if (_UserLoggedOnPending && this.Visible)
            {
                ProcessUserLoggedOn(false  );
                _UserLoggedOnPending = false;
            }
        }

        private void pLeft_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            if (_ButtonInProgress)
                return;
            try
            {
                _ButtonInProgress = true;
                int i = (int)((UltraButton)sender).Tag;
                ProcessButton1_5(i);

                if (HeaderButtonClick != null)
                    HeaderButtonClick((HeaderButtons)i, true);
            }
            finally
            {
                _ButtonInProgress = false;
            }
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (!this._action) return;

            PMDS.BusinessLogic.Patient pat = new PMDS.BusinessLogic.Patient(ENV.CurrentIDPatient);
            string bezPatient = pat.Vorname + " " + pat.Nachname;

            switch (e.Tool.Key)
            {
                case "DokumentAblegen":
                    this.neuesDokument();
                    break;

            }

        }

        private void neuerTermin(object sender, EventArgs e)
        {
            try
            {
                this.checkMemory();
                this.setButtonsDeaktive();
                PMDS.Global.UIGlobal.setAktiv(btnTermine, -1, activeForeCol, activeFrameCol, activeBackCol);
                GuiAction.archivTerminMail(false, false, false, false);

                //PMDS.BusinessLogic.Patient pat = new PMDS.BusinessLogic.Patient(ENV.CurrentIDPatient);
                //string bezPatient = pat.Vorname + " " + pat.Nachname;

                //if (PMDS.Global.ENV.VersionPlanArchive == 1)
                //{
                //    PMDS.GUI.VB.cMailTermine clManagTermine = new PMDS.GUI.VB.cMailTermine();
                //    clManagTermine.Termin_Neu(DateTime.Now, DateTime.Now, ENV.CurrentIDPatient.ToString(), bezPatient, null, null);
                //}
                //else if (PMDS.Global.ENV.VersionPlanArchive == 2)
                //{
                //    PMDS.GUI.VB.General gen = new VB.General();
                //    PMDS.GUI.VB.compPlan compPlanTmp = new VB.compPlan();
                //    PMDS.GUI.VB.dsPlan.planObjectDataTable tPlanObject = new VB.dsPlan.planObjectDataTable();
                //    PMDS.GUI.VB.dsPlan.planObjectRow newPlanObject = compPlanTmp.getNewRowPlanObject(tPlanObject);
                //    newPlanObject.IDObject = ENV.CurrentIDPatient;

                //    string sBezeichnung = "";
                //    string sFileType = "";
                //    byte[] byt = null;
                //    gen.newMessage(DateTime.Now, DateTime.Now, tPlanObject, null, System.Guid.NewGuid(), false, false,
                //                    sBezeichnung, sFileType, byt, false, false);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("neuerTermin: " + ex.ToString());
            }
        }

        private void neuesDokument(object sender, EventArgs e)
        {
            try
            {
                this.checkMemory();
                this.setButtonsDeaktive();
                PMDS.Global.UIGlobal.setAktiv(this.btnArchiv , -1, activeForeCol, activeFrameCol, activeBackCol);
                GuiAction.archivTerminMail(false, false, true, false);

                ////PMDS.BusinessLogic.Patient pat = new PMDS.BusinessLogic.Patient(ENV.CurrentIDPatient);
                ////string bezPatient = pat.Vorname + " " + pat.Nachname;

                ////PMDS.GUI.VB.frmArchivAbleg frm = new PMDS.GUI.VB.frmArchivAbleg();
                ////ArrayList arrObject = new ArrayList();
                ////PMDS.GUI.VB.clObject aktObj = new PMDS.GUI.VB.clObject();
                ////aktObj.id = ENV.CurrentIDPatient.ToString();
                ////aktObj.bezeichnung = bezPatient;

                ////arrObject.Add(aktObj);
                ////frm.contArchivDokumentAblegen.objects = arrObject;

                ////frm.ShowDialog(this);


                //////PMDS.GUI.VB.frmArchAbleg frm = new PMDS.GUI.VB.frmArchAbleg();
                //////ArrayList arrObject = new ArrayList();
                //////PMDS.GUI.VB.clObject aktObj = new PMDS.GUI.VB.clObject();
                //////aktObj.id = ENV.CurrentIDPatient.ToString();
                //////aktObj.bezeichnung = bezPatient;
                //////arrObject.Add(aktObj);

                //////PMDS.GUI.VB.compDoku compDokuTmp = new VB.compDoku();
                //////PMDS.GUI.VB.dbArchiv.archObjectDataTable tArchivObjects = new VB.dbArchiv.archObjectDataTable();
                //////PMDS.GUI.VB.dbArchiv.archObjectRow newArchObject = compDokuTmp.getNewRowArchObject(tArchivObjects);
                //////newArchObject.IDObject = ENV.CurrentIDPatient;

                //////PMDS.GUI.VB.clFileInfo clFileInfo1 = new VB.clFileInfo();
                //////clFileInfo1.tArchObject = tArchivObjects;
                //////frm.ContArchAbleg1.arrFilesToSave.Add(clFileInfo1);

                //////frm.ShowDialog(this);

            }
            catch (Exception ex)
            {
                throw new Exception("neuesDokument: " + ex.ToString());
            }
        }

        private void uDropDownButtArchivTermin_Click(object sender, EventArgs e)
        {

        }

        private void ucPatientGroupPicker1_Load(object sender, EventArgs e)
        {

        }

        private void btn18_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void neuerTermin()
        {

        }

        private void neuesDokument()
        {

        }


        private void btnArztabrechnung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;   

                this.checkMemory();
                if (ENV.CurrentIDPatient == null || ENV.CurrentIDPatient == Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Patient ausgew‰hlt!", "", MessageBoxButtons.OK);
                    return;
                }

                PMDS.GUI.Arztabrechnung.frmArztabrechnungDetail frmArztabrechnungDetail1 = new Arztabrechnung.frmArztabrechnungDetail();
                frmArztabrechnungDetail1.initControl(true, null,ENV.CurrentIDPatient, ENV.USERID, false);
                frmArztabrechnungDetail1.ShowDialog(this);

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.btnArztabrechnung_Click: " + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.RefreshData(false);

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

        public void RefreshData(bool bRefreshPicker)
        {
            try
            {
                if (_ButtonInProgress)
                    return;

                _ButtonInProgress = true;

                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    _PreventSelfRefreshing = true;
                    ENV.sendPatientChanged(eCurrentPatientChange.PickerLinksOben, bRefreshPicker, false);

                    //if (HeaderButtonClick != null)
                    //    HeaderButtonClick(ucHeader.lastButtonClicked, false);
                }
                else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    //if (HeaderButtonClick != null)
                    //    HeaderButtonClick(ucHeader.lastButtonClicked, true);   //lthNew
                }
            }
            catch (Exception ex)
            {
                _ButtonInProgress = false;
                ucSiteMapKlientenDetails.alwaysAskForSave = false;
                throw new Exception("ucHeader.RefreshData: " + ex.ToString());
            }
            finally
            {
                _ButtonInProgress = false;
                ucSiteMapKlientenDetails.alwaysAskForSave = false;
                _PreventSelfRefreshing = false;
            }
        }

        public void checkAnsichtsmodusxyxy(SiteEvents e, ref bool used)
        {
            try
            {
                switch (e)
                {
                    case SiteEvents.Bereichsansicht:
                        if (GuiWorkflow._LastBereichsansicht == eUITypeTermine.Interventionen)
                        {
                            GuiWorkflow.ShowInterventionenBereich();
                            ProcessButton1_5((int)ucHeader.HeaderButtons.Durchf¸hrung);
                            break;
                        }
                        else if (GuiWorkflow._LastBereichsansicht == eUITypeTermine.‹bergabe)
                        {
                            GuiWorkflow.Show‹bergabeBereich();
                            ProcessButton1_5((int)ucHeader.HeaderButtons.Uebergabe);
                            break;
                        }
                        else
                        {
                            GuiWorkflow.ShowInterventionenBereich();
                            ProcessButton1_5((int)ucHeader.HeaderButtons.Durchf¸hrung);
                            break;
                        }

                    case SiteEvents.KlientenDetails:
                        GuiWorkflow._guiworkflow.initKlintenakt(false);
                        ENV.AnsichtsModus = TerminlisteAnsichtsmodi.Klientanansicht;
                        GuiWorkflow.ShowKlientenDetails();
                        ProcessButton1_5((int)ucHeader.HeaderButtons.Details);
                        break;

                    case SiteEvents.KlientenDetailsLastSelectedGroup:
                        GuiWorkflow._guiworkflow.initKlintenakt(false);
                        //ShowLastGroup();
                        break;

                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.checkAnsichtsmodus: " + ex.ToString());
            }
        }


        public void checkMemory()
        {
            try
            {
                PMDS.Data.Global.db.checkMemorySizeAppClient(ref this.mainWindow.lblTxtMemory, ref this.mainWindow.pBarMemoryUsage,
                                                            ref this.ultraToolTipManagerWarningMemory);          

            }
            catch (Exception ex)
            {
                throw new Exception("ucHeader.checkMemory: " + ex.ToString());
            }
        }

        private void ucHeader_Fill_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
