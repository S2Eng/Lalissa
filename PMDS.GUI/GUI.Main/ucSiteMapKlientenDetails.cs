using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.BusinessLogic;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinExplorerBar;
using PMDS.Print;
using PMDS.Data.Global;
using CrystalDecisions.CrystalReports.Engine;
using System.Linq;




namespace PMDS.GUI
{


    public partial class ucSiteMapKlientenDetails : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {
        //Neu nach 05.05.2007 MDA
        public bool _ContentChanged = false;
        public ucKlient ucKlient1;
        public static bool alwaysAskForSave = false;
        PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();

        public bool lockRefresh = false;






        public ucSiteMapKlientenDetails()
        {
            InitializeComponent();
        }



        public void initControl()
        {
            this.ucKlient1 = new ucKlient();
            this.ucKlient1.mainSystm = true;
            this.ucKlient1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucKlient1.Dock = DockStyle.Fill;
            this.ucKlient1.ValueChanged += new System.EventHandler(this.ucKlient1_ValueChanged);
            this.ucKlient1.initControl();
            this.panelKlientenakt.Controls.Add(this.ucKlient1);
            this.ucKlient1.MainWindow = this;

            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            //Neu nach 03.07.2007 MDA
            ENV.ENVPatientDatenChanged += new ENVPatientDatenChangedDelegate(ENV_ENVPatientDatenChanged);

            this.ucKlient1.ucRegelungen1.ucSiteMapKlientenDetailsMain = this;
            this.ucPrintArztbrief1.mainWindow = this;
            //bool bArztabrechnungErfassung = ENV.HasRight(UserRights.ArztabrechnungErfassung); 
            //Benutzer ben = new Benutzer(ENV.USERID);
            bool bArztabrechnungErfassung = ENV.HasRight(UserRights.ArztabrechnungErfassung);           //lthArztabrechnung    
            this.ucPrintArztbrief1.Visible = bArztabrechnungErfassung;       
            this.btnDiagnosenliste.Visible = bArztabrechnungErfassung;

            this.ucPrintArztbrief1.Visible = ENV.HasRight(UserRights.ArztbriefDrucken);
            if (!System.IO.File.Exists(ENV.ReportPath + "\\Arztbrief.rpt"))
            {
                this.ucPrintArztbrief1.Visible = false;
            }
            if (!System.IO.File.Exists(ENV.ReportPath + "\\Diagnoseliste.rpt"))
            {
                this.btnDiagnosenliste.Visible = false;
            }

        }
       
        //Neu nach 03.07.2007 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn die Daten des Aktuellen Klienten geändert wurden, dann die Datenanzeige aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        void ENV_ENVPatientDatenChanged(Guid IDPatient)
        {
            if (ENV.CurrentIDPatient == IDPatient)
                RefreshPatient();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die ID des Klienten in der Auswahl wurde geändert
        /// </summary>
        //----------------------------------------------------------------------------
        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine)
        {
            try
            {
                lockRefresh = false;
                //Änderung nach 03.07.2007 MDA
                if ((ucKlient1.Klient != null && IDPatient != Guid.Empty && IDPatient != ucKlient1.Klient.ID) || ucSiteMapKlientenDetails.alwaysAskForSave)
                    AskForSave();

                if (this.Visible && ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    this.lockRefresh = true;
                    RefreshPatient();
                }

            }
            catch (Exception ex)
            {
                this.lockRefresh = false;
                throw new Exception("ucSiteMapKlientenDetails.ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Genereller Handler
        /// </summary>
        //----------------------------------------------------------------------------
        private void commonHandler(PMDSMenuEntry sender)
        {
            switch (sender.SiteEvent)
            {

                // Arbeitsstation sperren
                case SiteEvents.Lock:
                    frmLoginLocked.ProcessLocked();
                    break;

                // neu anloggen
                case SiteEvents.LogOn:
                    frmLogin.ProcessLogin();
                    break;

                // Passwort ändern
                case SiteEvents.Password:
                    GuiAction.ChangePassword();
                    break;

                case SiteEvents.About:
                    new frmAbout().Show();
                    break;

                // Programm beenden
                case SiteEvents.End:
                    Form.ActiveForm.Close();
                    break;


                // Witerleiten
                default:
                    GuiAction.ActionFromEvent(sender.SiteEvent);
                    break;
            }
        }

        public void AskForSave()
        {
            try
            {
                if (_ContentChanged)
                {
                    if (PMDS.Global.historie.HistorieOn || !ENV.HasRight(UserRights.KlientenAktStammdatenAendern))
                    {
                        this._ContentChanged = false;
                        ProcessSave(false);
                    }
                    else
                    {
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                                    ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                                    MessageBoxButtons.YesNo,
                                                                                                    MessageBoxIcon.Question, true);       

                        if (res == DialogResult.Yes)
                            ProcessSave(true);

                        else if (res == DialogResult.No)
                            ProcessSave(false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapKlientenDetails.AskForSave: " + ex.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen speichern
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSave(bool save)
        {
            if (save)
                Save();
            else
                Undo();
        }

        #region IPMDSGUIObject Members


        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf von außen verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {
           
        }
        

        //----------------------------------------------------------------------------
        /// <summary>
        /// CONTROL
        /// </summary>
        //----------------------------------------------------------------------------
        public Control CONTROL
        {
            get { return this; }
        }

        public void Undo()
        {
            //Änderung nach 29.06.2007 MDA
            Guid currentAufenthalt = ucKlient1.Klient.Aufenthalt != null ? ucKlient1.Klient.Aufenthalt.ID : Guid.Empty;
            ucKlient1.Klient = new KlientDetails(ucKlient1.Klient.ID, currentAufenthalt);
            btnSave2.Enabled = false;
            btnundo2.Enabled = false;

            //Neu nach 05.05.2007 MDA
            _ContentChanged = false;
        }


        public bool validateData(ref string MessageTxt, bool withMsgBox)
        {
            try
            {
                if (this.ucKlient1.ucKlientStammdaten1.cbRezeptGeb.Checked)
                {
                    //if (!this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_UnbefristetJN.Checked && !this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_BefristetJN.Checked &&
                    //    !this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_WiderrufJN.Checked &&
                    //    !this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_RegoJN.Checked)
                    //{
                    //    this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                    //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Bitte geben Sie Details für die Rezeptgebührenbefreiung an!", "Speichern");
                    //    //return false;
                    //}

                    //Es muss genau ein Häkchen gesetzt sein
                    if ((this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_UnbefristetJN.Checked ? 1 : 0) +
                        (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_BefristetJN.Checked ? 1 : 0) +
                        (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_WiderrufJN.Checked ? 1 : 0) +
                        (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_RegoJN.Checked ? 1 : 0) != 1 )
                    {
                        this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es muss genau ein Grund für die Rezeptgebührenbefreiung angegeben werden.", "Speichern");
                        //return false;
                    }

                    if (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_RegoJN.Checked)
                    {
                        if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.Value == null || this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb.Value == null)
                        {
                            this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                            if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb.Value == null)
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb);
                            if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.Value == null)
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis);

                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab und Rego bis müssen angegeben werden.", "Speichern");
                            return false;
                        }
                        else
                        {
                            if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.Value != null && this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb.Value != null &&
                                this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb.DateTime.Date > this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.DateTime.Date)
                            {
                                this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoAb);
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab darf nicht größer als Rego bis sein.", "Speichern");
                                return false;
                            }
                        }
                    }

                    if (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_BefristetJN.Checked)
                    {
                        if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.Value == null || this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb.Value == null)
                        {
                            this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                            if ( this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb.Value == null)
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb);
                            if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.Value == null)
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis);

                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab und befristet bis müssen angegeben werden.", "Speichern");
                            return false;
                        }
                        else
                        {
                            if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.Value != null && this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb.Value != null &&
                                this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb.DateTime.Date > this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.DateTime.Date)
                            {
                                this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                                GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetAb);
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab darf nicht grösser als befristet bis sein.", "Speichern");
                                return false;
                            }
                        }
                    }

                    if (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_WiderrufJN.Checked)
                    {
                        if (this.ucKlient1.ucKlientStammdaten1.cboRezGebBef_WiderrufGrund.Text.Trim() == "")
                        {
                            this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Rezeptgebührenbefreiung"];
                            GuiUtil.setColor(this.ucKlient1.ucKlientStammdaten1.cboRezGebBef_WiderrufGrund);
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Grund für Rezeptgebührenbefreiung muss angeführt werden.", "Speichern");
                            return false;
                        }
                    }
                }

                if (!this.ucKlient1.ucKlientStammdaten1.ucAbrechAufenthKlient1.validateDataVersNr(ref MessageTxt, withMsgBox))
                {
                    this.ucKlient1.ucKlientStammdaten1.tabStammdaten.SelectedTab = this.ucKlient1.ucKlientStammdaten1.tabStammdaten.Tabs["Aufenthalt"];
                    return false;
                }

                int iELGAHausarzt = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.ucKlient1.ucKlientStammdaten1.gridAerzte.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    var rPatAerzte = (PMDS.Global.db.Global.dsPatientAerzte.PatientAerzteRow)v.Row;
                    if (rPatAerzte.RowState != DataRowState.Deleted)
                    {
                        if (rPatAerzte.ELGA_HausarztJN)
                            iELGAHausarzt += 1;
                    }
                }
                if (iELGAHausarzt > 1)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Patienten wurden mehr als ein ELGA-Hausarzt angegeben!" + "\r\n" +
                                                                                "", "", MessageBoxButtons.OK);
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapKlientenDetails.validateData: " + ex.ToString());
            }
        }

        public bool Save()
        {
            try
            {
                this.ucKlient1.ucKlientStammdaten1.checkFieldDatRezGebBefRegoBis(null, null, false);
                this.ucKlient1.ucKlientStammdaten1.KlientUIEventsLocked = true;

                string MessageTxt = "";
                if (!PMDS.Global.historie.HistorieOn)
                {
                    if (!this.validateData(ref MessageTxt, false))
                        return false;
                    if (!ucKlient1.ValidateFields())
                        return false;
                    if (!this.ucKlient1.ucKlientStammdaten1.ucVOErfassen1.validateData(ref MessageTxt))
                        return false;
                }

                ucKlient1.UpdateDATA();
                ucKlient1.Write();

                if (!this.ucKlient1.isBewerberJN && !this.ucKlient1.ucKlientStammdaten1._isAbrechnung && this.ucKlient1.ucKlientStammdaten1._mainSystem && PMDS.Global.ENV.lic_ELGA)
                {
                    this.ucKlient1.ucKlientStammdaten1.contELGAKlient1.saveData();
                }

                bool writeDekursSprachenChanged = false;
                bool abweseneheitBeendetChanged = false;
                string txtSprachenGeändert = "";
                this.ucKlient1.ucKlientStammdaten1.SaveER(ref writeDekursSprachenChanged, ref abweseneheitBeendetChanged, ucKlient1.Klient.Aufenthalt.ID, ref txtSprachenGeändert);

                //this.ucKlient1.ucKlientStammdaten1.ucVOErfassen1.saveData();

                btnSave2.Enabled = false;
                btnundo2.Enabled = false;
                _ContentChanged = false;

                ucKlient1.checkRefresMedDatentypen();

                //Patient pat = new Patient(this.ucKlient1.Klient.ID);
                //PMDS.GUI.GuiWorkflow.HeaderMain.SetlblAbwesend(pat);
                
                ENV.SignalKlientChanged();
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                //if (this.ucKlient1.PictureHasChanged)
                //{
                //    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                //    {
                //        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db, QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient: '")  + pat.FullName.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' - Bild wurde geändert!") , DateTime.Now, null, null,
                //                        ENV.IDAUFENTHALT, null, PflegeEintragTyp.MEDIKAMENT,
                //                        null, ENV.CurrentIDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten-Stammdaten Änderung"));
                //        db.SaveChanges();
                //    }
                //}
                //if (this.ucKlient1.PictureDeleted)
                //{
                //    using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                //    {
                //        PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db, QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient: '") + pat.FullName.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' - Bild wurde gelöscht!"), DateTime.Now, null, null,
                //                        ENV.IDAUFENTHALT, null, PflegeEintragTyp.MEDIKAMENT,
                //                        null, ENV.CurrentIDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten-Stammdaten Änderung"));
                //        db.SaveChanges();
                //    }
                //}
                this.ucKlient1.ucMedizinischeDaten1.UpdateMehrfachauswahlPatienten();

                this.ucKlient1.PictureHasChanged = false;
                this.ucKlient1.PictureDeleted = false;
                this.ucKlient1.ucKlientStammdaten1.loadPatientenverfügung();
                
                foreach (ucKlientStammdaten.cKontakteChanged KontakteChanged in ucKlientStammdaten.lstKontakteChanged)
                {
                    b.AddPflegeeintragSimple2(KontakteChanged.txt, KontakteChanged.title, PflegeEintragTyp.DEKURS, KontakteChanged.IDPatient, this.ucKlient1.isBewerberJN);
                }
                ucKlientStammdaten.lstKontakteChanged.Clear();
                //this.CheckForRezeptgebührbefreiung(this.ucKlient1.Klient.ID);     //wird beim Refresh durchgeführt
                this.ucKlient1.ucKlientStammdaten1.KlientUIEventsLocked = false;

                this.ucKlient1.checkWriteDekurs(ref writeDekursSprachenChanged, ref txtSprachenGeändert);
                this.ucKlient1.checkWriteÄrzteMehrfachauswahl();

                this.RefreshPatient();

                //ENV.SignalMedizinDatenChanged();            //lthRefreshMedData
                return true;
            }
            catch (Exception e)
            {
                this.ucKlient1.ucKlientStammdaten1.KlientUIEventsLocked = false;
                throw new Exception("ucSiteMapKlientenDetails.Save: " + e.ToString());
            }
        }

        public void CheckForRezeptgebührbefreiung(Guid IDKlient)
        {
            try
            {
                if (this.ucKlient1.ucKlientStammdaten1.cbRezeptGeb.Checked)
                {
                    if (this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.Value != null && this.ucKlient1.ucKlientStammdaten1.datRezGebBef_RegoBis.DateTime.Date < DateTime.Now.Date)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            var rPatInfo = (from p in db.Patient
                                            where p.ID == IDKlient
                                            select new
                                            { p.Nachname, p.Vorname }
                                        ).First();
                            
                            //Patient pat = new Patient(this.ucKlient1.Klient.ID);
                            Nullable<Guid> IDAbteilung = null;
                            Nullable<Guid> IDBereich = null;
                            if (!this.ucKlient1.isBewerberJN)
                                this.b.getIDAbteilungIDBereichNachAnsichtsmodus(ref IDAbteilung, ref IDBereich, IDKlient, db);
                            
                            PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db, rPatInfo.Vorname + " " + rPatInfo.Nachname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Rezeptgebührenbefreiung Rego abgelaufen!"), DateTime.Now, null, IDBereich,
                                            ENV.IDAUFENTHALT, null, PflegeEintragTyp.Klient,
                                            null, IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"));
                            db.SaveChanges();

                            PMDS.db.Entities.Patient rPatient = b.getPatient2(IDKlient, db);
                            rPatient.RezeptgebuehrbefreiungJN = false;
                            rPatient.RezGebBef_RegoJN = false;
                            rPatient.RezGebBef_RegoAb = null;
                            rPatient.RezGebBef_RegoBis = null;

                            //Oberfläche korrigieren
                            this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_RegoJN.Checked = false;
                            this.ucKlient1.ucKlientStammdaten1.cbRezeptGeb.Checked = false;
                            db.SaveChanges();

                        }
                    }

                    if (this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_BefristetJN.Checked && this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.DateTime.Date < DateTime.Now.Date)
                    {
                        //Patient pat = new Patient(this.ucKlient1.Klient.ID);
                        using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                        {
                            var rPatInfo = (from p in db.Patient
                                            where p.ID == IDKlient
                                            select new
                                            { p.Nachname, p.Vorname }
                                           ).First();
                            Nullable<Guid> IDAbteilung = null;
                            Nullable<Guid> IDBereich = null;
                            if (!this.ucKlient1.isBewerberJN)
                                this.b.getIDAbteilungIDBereichNachAnsichtsmodus(ref IDAbteilung, ref IDBereich, IDKlient, db);

                            string sMsgText = rPatInfo.Vorname + " " + rPatInfo.Nachname + 
                                    QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Rezeptgebührenbefreiung befristet abgelaufen!") +
                                    " (" + this.ucKlient1.ucKlientStammdaten1.datRezGebBef_BefristetBis.DateTime.Date.ToString("dd.MM.yyyy") + ")";
                           
                            PMDS.db.Entities.PflegeEintrag rPflegeEintrag = b.AddPflegeeintrag(db,sMsgText, DateTime.Now, null, IDBereich,
                                            ENV.IDAUFENTHALT, null, PflegeEintragTyp.Klient,
                                            null, IDAbteilung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung"));
                            db.SaveChanges();

                            PMDS.db.Entities.Patient rPatient = b.getPatient2(IDKlient, db);
                            rPatient.RezeptgebuehrbefreiungJN = false;
                            rPatient.RezGebBef_BefristetJN = false;

                            //Oberfläche korrigieren
                            this.ucKlient1.ucKlientStammdaten1.chkRezGebBef_BefristetJN.Checked = false;
                            this.ucKlient1.ucKlientStammdaten1.cbRezeptGeb.Checked = false;
                            db.SaveChanges();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("writePEForRezeptgebührbefreiung: " + ex.ToString());
            }
        }

        public string AREA
        {
            get { return ENV.String("GUI_AREA_SITEMAP_START"); }
        }

        private IPMDSMenuFramework _framework;

        //----------------------------------------------------------------------------
        /// <summary>
        /// FRAMEWORK
        /// </summary>
        //----------------------------------------------------------------------------
        public IPMDSMenuFramework FRAMEWORK
        {
            get { return _framework; }
            set { _framework = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// in Framework einhängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AttachFramework()
        {
            try
            {
                _framework.HEADER.action(false);
                _framework.HEADER.ShowOnlyHeader(true);  

                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                UpdateActions();

                // os: 30.09.2011 Recht KlientenstammdatenÄndern berücksichtigen
                // Bei Historie = true:  und ENV.HasRight(UserRights.KlientenAktStammdatenAendern = false -> Controls deaktivieren
                //bool bOn = PMDS.Global.historie.HistorieOn;
                //if (!bOn) bOn =  !ENV.HasRight(UserRights.KlientenAktStammdatenAendern);

                if (!PMDS.Global.historie.HistorieOn)
                {
                    bool bOn = ENV.HasRight(UserRights.KlientenAktStammdatenAendern);
                    setControlsAktivDisable((bOn));
                }
                else
                {
                    bool bOn = ENV.HasRight(UserRights.HistorischeDatenÄndern);
                    setControlsAktivDisable((bOn));
                }

            }
            catch (Exception ex)
            {
                _framework.HEADER.ShowControlAndHeader(true);
                ENV.HandleException(ex);
            }
            finally
            {
                _framework.HEADER.action(true);
            }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            this.panelButtons.Visible = bOn;
            this.ucKlient1.setControlsAktivDisable(!bOn);
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// aus Framework aushängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void DetachFramework()
        {
            //Neu nach 05.05.2007 MDA
            AskForSave();

            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Keyboard Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        public void ProcessKeyEvent(KeyEventArgs e)
        {
            //			switch(e.KeyCode) 
            //			{
            //				case Keys.L:								
            //					HandleLabelEvent(SiteEvents.Terminliste);
            //					e.Handled = true;
            //					break;
            //			}
        }

        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktionen aktualisieren weil sich ein Benutzer neu angemeldet hat
        /// </summary>
        //----------------------------------------------------------------------------
        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            UpdateActions();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// erlaubte Aktionen ein/ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateActions()
        {
            //neu nach 26.04.2007 MDA

            //nach User Rechte Tab Stammdaten anzeigen oder ausblenden
            //ucKlient1.StammdatenVisible = ENV.HasRight(UserRights.KlientenAktStammdatenAnzeigen);
            
            //Stammdaten ReadOnly setzen
            //ucKlient1.StammdatenReadOnly = !ENV.HasRight(UserRights.KlientenAktStammdatenAendern);
            
            //Sonstige Visible
            //ucKlient1.SonstigeVisible = ENV.HasRight(UserRights.KlientenAktSonstigeAnzeigen);
            
            //Sonstige ReadOnly
            //ucKlient1.SonstigeReadOnly = !ENV.HasRight(UserRights.KlientenAktSonstigeAendern);
            
            this.panelKeinRecht .Visible = false;

            if (!ENV.HasRight(UserRights.KlientenAktStammdatenAnzeigen))
            {
                panelKeinRecht.Visible = true;
                ultraGridBagLayoutPanelKlient.Visible = false;
            }
        }


        private void ucSiteMapKlientenDetails_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.Visible)
                    return;

                //if ((ucKlient1.Klient.ID != ENV.CurrentIDPatient || ucKlient1.Klient.Aufenthalt.ID != Aufenthalt.LastByPatient(ENV.CurrentIDPatient)))
                //{
                //KlientDetails klient = new KlientDetails(ENV.CurrentIDPatient, Aufenthalt.LastByPatient(ENV.CurrentIDPatient));
                //ucKlient1.Klient = klient;
                if (!this.lockRefresh)
                {
                    RefreshPatient();

                }
                //}
                this.lockRefresh = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapKlientenDetails_VisibleChanged: " + ex.ToString());
            }
        }

        public void RefreshPatient()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ucKlient1.SuspendLayout();
                ucKlient1.Visible = false;
                
                //if (ucKlient1.Klient.ID != ENV.CurrentIDPatient)
                //{
                if (ENV.CurrentIDPatient != Guid.Empty)
                {
                    KlientDetails klient = new KlientDetails(ENV.CurrentIDPatient, Aufenthalt.LastByPatient(ENV.CurrentIDPatient), true);
                    ucKlient1.Klient = klient;          //os-Performance !!!!!!
                    CheckForRezeptgebührbefreiung(ucKlient1.Klient.ID);
                    ucKlient1.ResumeLayout();
                    ucKlient1.Visible = true;
 
                    UpdateActions();
                    btnSave2.Enabled = false;
                    btnundo2.Enabled = false;

                    _ContentChanged = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapKlientenDetails_RefreshPatient(): " + ex.ToString());
            }
            finally
            {
                ucKlient1.Visible = true;
                ucKlient1.ResumeLayout();
                this.Cursor = Cursors.Default;
                Application.DoEvents();
            }
        }

        private void ucKlient1_ValueChanged(object sender, EventArgs e)
        {
            //Neu nach 05.05.2007 MDA
            _ContentChanged = true;

            btnundo2.Enabled = true;
            btnSave2.Enabled = true;
        }

        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stammdatenblatt drucken  {{{eng}}} 24.10.2007
        /// </summary>
        //-----------------------------------------------------------------------------------------------------
        private void ucPrintStammDatenBlatt1_btnPrintStammdatenKlicked(bool Freiheit, bool Versicherung, bool Med, bool Kontakt, bool Sachwalter, bool Arzt,bool Regelung,bool Pflegestufe,bool Kostentraeger,bool Verwahrung,bool Hilfsmittel,bool Dienstleister,bool Reha)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.Print.ReportManager.PrintStammdatenblatt(ENV.CurrentIDPatient, Aufenthalt.LastByPatient(ENV.CurrentIDPatient), Freiheit, Versicherung, Med, Kontakt, Sachwalter, Arzt, Regelung, Pflegestufe, Kostentraeger, Verwahrung, Hilfsmittel, Dienstleister, Reha);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Save();
            			}
			catch(Exception ex )
			{
                ENV.HandleException(ex);
			}
			finally 
			{
				this.Cursor = Cursors.Default;
			}
        }
        private void btnundo2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Undo();
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

        public void printArztbrief()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;       //lthArztabrechnung

                PMDS.DynReportsForms.frmPrintArztbrief frmPrintArztbrief1 = new PMDS.DynReportsForms.frmPrintArztbrief();
                DialogResult res = frmPrintArztbrief1.ShowDialog();
                if (res != DialogResult.OK)
                    return;

                //List<PMDS.Print.CR.BerichtParameter> BERICHTPARAMETER = new List<Print.CR.BerichtParameter>();
                //List<PMDS.Print.CR.BerichtParameter> lPars = BERICHTPARAMETER;
                //if (frmPrintArztbrief1 != null)
                //{
                //    foreach (PMDS.Print.CR.BerichtParameter p in frmPrintArztbrief1.GetBERICHTPARAMETER())
                //    {
                //        lPars.Add(p);
                //    }
                //}

                PMDS.Print.ReportManager.PrintArztbrief(frmPrintArztbrief1.cbETo.Text.Trim (), frmPrintArztbrief1.txtAnmerkungen.Text.Trim(), 
                                                        ENV.CurrentIDPatient, ENV.USERID, ENV.IDAUFENTHALT, frmPrintArztbrief1.txtText.Text.Trim(),
                                                        this.ucPrintArztbrief1.chkDiagnosenJN.Checked , this.ucPrintArztbrief1.chkMedikamenteJN .Checked);

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

        private void btnDiagnosenliste_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;       //lthArztabrechnung
                PMDS.Print.ReportManager.PrintDiagnoseliste(ENV.CurrentIDPatient, ENV.USERID, ENV.IDAUFENTHALT);

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

        private void btnPrintMedBlatt_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;       //lthArztabrechnung

                dsRezeptEintrag.RezeptEintragDataTable dt = null;
                ReportDocument d = ReportManager.GetMedikamentenBlatt(dt, ENV.IDAUFENTHALT, true);
                frmPrintPreview frm = new frmPrintPreview(d);
                frm.Show();

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
    }

}
