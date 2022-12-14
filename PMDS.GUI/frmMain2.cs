using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using PMDS.GUI;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinToolbars;
using PMDS.Global.db.ERSystem;
using System.Linq;
using System.IO;
using PMDSClient.Sitemap;
using PMDS.Global.PMDSClient;
using S2Extensions;

namespace PMDS
{
    public class frmMain : frmBase, IPMDSMenuFramework, IPMDSHeader
    {
        private IPMDSGUIObject _topGUI;
        private System.Windows.Forms.Splitter splitter1;
        private PMDS.UI.Sitemap.UIFct UISitemap;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmBase_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmBase_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmBase_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmBase_Toolbars_Dock_Area_Bottom;
        private QS2.Desktop.ControlManagment.BasePanel pnlMain;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        private QS2.Desktop.ControlManagment.BasePanel panelControlGesamt;
        private System.ComponentModel.IContainer components;
        private QS2.Desktop.ControlManagment.BasePanel panelControl;
        private QS2.Desktop.ControlManagment.BaseLabel lblIsLoading;
        private ContextMenuStrip contextMenuStripLogging;
        private ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.FormWindowState prevWindowState = System.Windows.Forms.FormWindowState.Normal;
        private Data.PflegePlan.dsPDxEintraege dsPDxEintraege1;
        private TXTextControl.TextControl textControl1;
        private Timer timerControlManager;
        private ToolStripMenuItem styleAppToolStripMenuItem;
        private Timer timerCheckConnectionAndNetwork;
        private Panel PanelStatusbar;
        private bool _KlientenlisteOnTop = true;
        private PMDS.GUI.Verordnungen.frmVOMain frmVOMain1;
        private PMDS.GUI.Verordnungen.frmVOMain frmVOMain2;
        private ToolStripMenuItem openConfigManagerToolStripMenuItem;
        private static bool newVersionAvailable;
        private static cRights Rights;
        private PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
        private class cRights
        {
            public bool Aufnahme;
            public bool Bewerber;
            public bool ImportGibodat;
            public bool QS2;
            public bool KlientenberichtDrucken;
            public bool Abrechnung = false;
            public bool btnTransferCalcData;
            public bool btnExportCalculations;
            public bool btnVerordnungen;
            public bool btnPatientAufenthalteL?schen;
            public bool SuchtgiftschrankSchluessel;
        }
        private ELGABusiness bElga = new ELGABusiness();
        private Timer timerELGA;
        private static bool IsInitialized;

        public ucHeader ucHeader1;
        public UltraToolbarsManager ultraToolbarsManager1;
        public QS2.Desktop.ControlManagment.BasePanel panelStart;
        public Infragistics.Win.AppStyling.Runtime.AppStylistRuntime appStylistRuntime1;
        public UltraStatusBar ultraStatusBar1;
        public bool CloseAnyway;

        public class cRightsStammdaten
        {
            public bool Einrichtung = false;
            public bool Benutzer = false;
            public bool Gruppenrechte = false;
            public bool VerwaltungEinrichtungUndBenutzer = false;
            public bool VerwaltungFortbildungen = false;

            public bool Auswahllisten = false;
            public bool Zusatzeintr?ge = false;
            public bool Textbausteine = false;
            public bool Dokumentenverwaltung = false;
            public bool ExterneEinrichtungen = false;

            public bool Standardprozeduren = false;
            public bool Assessments = false;
            public bool Medikamente = false;
            public bool Pflegerichtlinien = false;
            public bool ?rzteverwaltung = false;
            public bool Arztabrechnung = false;
            public bool ?rzteZusammenf?hren = false;
            public bool Befundimport = false;

            public bool Quickfilter = false;
            public bool LayoutManager = false;
            public bool MedizinischeTypen = false;
            public bool MedizinscheDialoge = false;
            public bool WundbilderSkalieren = false;

            public bool QS2 = false;
            public bool QS2AbfragebVerwaltenAdmin = false;
            public bool QS2Ressourcen = false;
            public bool QS2InformationenFelderSQLServer = false;
            public bool QS2Kriterien = false;
            public bool QS2Auswahllisten = false;

            public bool Archiveinstellungen = false;
            public bool EMailKonten = false;
            public bool LogManager = false;
        }


        public frmMain()
        {
            try
            {
                System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                InitializeComponent();
                System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;

                if (!DesignMode)
                {
                    this.ucHeader1.mainWindow = this;
                }

                this.ultraToolbarsManager1.Tools["btnPatientAufenthalteL?schen"].SharedProps.Visible = false;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void initControl()
        {
            try
            {
                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);
                ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
                ucHeader1.HeaderButtonClick += new ucHeader.HeaderButtonClickDelegate(ucHeader1_HeaderButtonClick);
                GuiAction.GuiActionDone += new GuiActionDoneDelegate(GuiAction_GuiActionDone);
                ENV.NotfallChanged += new EventHandler(ENV_NotfallChanged);
                ENV.sendMainChanged += new sendMainChangedDelegate(this.mainEventReceive);

                this.ultraToolbarsManager1.Tools["btnVerordnungen"].SharedProps.Visible = ENV.lic_VO;
                this.ultraToolbarsManager1.Tools["btnVerordnungen2"].SharedProps.Visible = ENV.lic_VO;
                this.ultraToolbarsManager1.Tools["btnSTAMP"].SharedProps.Visible = ENV.lic_STAMP;
            }
            catch (Exception ex)
            {
                throw new Exception("frmMain2.initControl: " + ex.ToString());
            }
        }

        public void setRights(ref bool AnyMen?ItemVerwaltung)
        {
            if (frmMain.Rights == null)
            {
                frmMain.Rights = new cRights
                {
                    Aufnahme = ENV.HasRight(UserRights.Aufnahme),
                    Bewerber = ENV.HasRight(UserRights.BewerberStarten),
                    ImportGibodat = ENV.HasRight(UserRights.ImportGibodat),
                    QS2 = ENV.HasRight(UserRights.QS2),
                    KlientenberichtDrucken = ENV.HasRight(UserRights.KlientenberichtDrucken),
                    btnTransferCalcData = (ENV.HasRight(UserRights.Abrechnungen?berspielen) || ENV.adminSecure),
                    btnExportCalculations = ENV.HasRight(UserRights.AbrechnungenExportieren) || ENV.adminSecure,
                    SuchtgiftschrankSchluessel = ENV.HasRight(UserRights.SuchtgiftschrankSchluessel),
                    btnVerordnungen = ENV.lic_VO,
                    btnPatientAufenthalteL?schen = ENV.HasRight(UserRights.deleteKlient) || ENV.adminSecure
                };
            }

            this.ultraToolbarsManager1.Tools["Aufnahme"].SharedProps.Visible = frmMain.Rights.Aufnahme;
            this.ultraToolbarsManager1.Tools["Bewerber"].SharedProps.Visible = frmMain.Rights.Bewerber;
            this.ultraToolbarsManager1.Tools["ImportGibodat"].SharedProps.Visible = frmMain.Rights.ImportGibodat;
            this.ultraToolbarsManager1.Tools["btnQS2Reports"].SharedProps.Visible = false;
            this.ultraToolbarsManager1.Tools["btnQS2Queries"].SharedProps.Visible = frmMain.Rights.QS2;
            this.ultraToolbarsManager1.Tools["btnQS2ManageQueriesUser"].SharedProps.Visible = frmMain.Rights.QS2;
            this.ultraToolbarsManager1.Tools["DatenarchivierungAlle"].SharedProps.Visible = frmMain.Rights.KlientenberichtDrucken;
            this.ultraToolbarsManager1.Tools["btnTransferCalcData"].SharedProps.Visible = frmMain.Rights.btnTransferCalcData;
            this.ultraToolbarsManager1.Tools["btnExportCalculations"].SharedProps.Visible = frmMain.Rights.btnExportCalculations;
            this.ultraToolbarsManager1.Tools["btnSuchtgiftschrankSchl?ssel"].SharedProps.Visible = frmMain.Rights.SuchtgiftschrankSchluessel;
            this.ultraToolbarsManager1.Tools["btnVerordnungen"].SharedProps.Visible = frmMain.Rights.btnVerordnungen;
            this.ultraToolbarsManager1.Tools["btnPatientAufenthalteL?schen"].SharedProps.Visible = frmMain.Rights.btnPatientAufenthalteL?schen;
            this.ultraToolbarsManager1.Tools["btnQS2Reports"].SharedProps.Visible = false;
            this.ultraToolbarsManager1.Tools["btnQS2Queries"].SharedProps.Visible = frmMain.Rights.QS2;
            this.ultraToolbarsManager1.Tools["btnQS2ManageQueriesUser"].SharedProps.Visible = frmMain.Rights.QS2;

            AnyMen?ItemVerwaltung = (frmMain.Rights.Aufnahme || frmMain.Rights.Bewerber || frmMain.Rights.ImportGibodat || frmMain.Rights.QS2 || frmMain.Rights.KlientenberichtDrucken ||
                            frmMain.Rights.btnTransferCalcData || frmMain.Rights.btnExportCalculations || frmMain.Rights.btnVerordnungen || frmMain.Rights.btnPatientAufenthalteL?schen || frmMain.Rights.SuchtgiftschrankSchluessel);

            if (!IsInitialized)
            {
                ELGABusiness.BenutzerDTOS1 ben = bElga.getELGASettingsForUser(ENV.USERID);
                ultraToolbarsManager1.Tools["btnELGAPasswort?ndern"].SharedProps.Visible = ENV.lic_ELGA && ben.Elgaactive && !ben.IsGeneric;
                IsInitialized = true;
            }
        }

        public void setRightsStammdaten(out bool AnyMen?ItemStammdaten, out bool AllMen?ItemsStammdaten, out cRightsStammdaten RightsStammdaten)
        {

            AnyMen?ItemStammdaten = false;
            AllMen?ItemsStammdaten = false;
            RightsStammdaten = new cRightsStammdaten
            {
                Einrichtung = ENV.HasRight(UserRights.EinrichtungVerwalten),
                Benutzer = ENV.HasRight(UserRights.ManageUser) || ENV.adminSecure,
                Gruppenrechte = ENV.HasRight(UserRights.ManageUser) || ENV.adminSecure, //ultraToolbarsManager1.Tools["Gruppenrechte"].SharedProps.Visible = Settings.HasRight(UserRights.ManageUser);
                VerwaltungEinrichtungUndBenutzer = ENV.HasRight(UserRights.ManageUser) || ENV.adminSecure, //ultraToolbarsManager1.Tools["btnVerwaltungKlinikenUser"].SharedProps.Visible = Settings.HasRight(UserRights.ManageUser);
                VerwaltungFortbildungen = ENV.HasRight(UserRights.ManageUser) || ENV.adminSecure, //ultraToolbarsManager1.Tools["btnVerwaltungFortbildungen"].SharedProps.Visible = Settings.HasRight(UserRights.ManageUser);
                Auswahllisten = ENV.HasRight(UserRights.AuswahllistenVerwalten),
                Zusatzeintr?ge = ENV.HasRight(UserRights.ZusatzEintraegeVerwalten),
                Textbausteine = ENV.HasRight(UserRights.TextbausteineVerwalten),
                Dokumentenverwaltung = ENV.HasRight(UserRights.Dokumentenverwaltung),
                ExterneEinrichtungen = ENV.HasRight(UserRights.ExterneEinrichungenVerwalten),
                Standardprozeduren = ENV.HasRight(UserRights.StandardprozedurenVerwalten),
                Assessments = ENV.HasRight(UserRights.AssessmentsVerwalten),
                Medikamente = ENV.HasRight(UserRights.MedikamenteVerwalten),
                Pflegerichtlinien = ENV.HasRight(UserRights.PflegerichtlinienVerwalten),
                ?rzteverwaltung = ENV.HasRight(UserRights.AerzteVerwalten),
                Arztabrechnung = ENV.HasRight(UserRights.Arztabrechnung),
                ?rzteZusammenf?hren = ENV.HasRight(UserRights.?rzteZusammenf?hren),
                Befundimport = ENV.HasRight(UserRights.Befundimport),
                Quickfilter = ENV.HasRight(UserRights.QuickfilterVerwalten),
                LayoutManager = ENV.HasRight(UserRights.LayoutmanagerVerwalten),
                MedizinischeTypen = ENV.HasRight(UserRights.MedizinischeTypenVerwalten),
                MedizinscheDialoge = ENV.HasRight(UserRights.MedizinischeDialogeVerwalten),
                WundbilderSkalieren = ENV.HasRight(UserRights.WundbilderSkalieren),
                QS2 = ENV.HasRight(UserRights.QS2Verwalten),
                QS2AbfragebVerwaltenAdmin = ENV.HasRight(UserRights.QS2Verwalten),
                QS2Ressourcen = ENV.HasRight(UserRights.QS2Verwalten),
                QS2InformationenFelderSQLServer = ENV.HasRight(UserRights.QS2Verwalten),
                QS2Kriterien = ENV.HasRight(UserRights.QS2Verwalten),
                QS2Auswahllisten = ENV.HasRight(UserRights.QS2Verwalten),
                Archiveinstellungen = ENV.HasRight(UserRights.ArchiveinstellungenVerwalten),
                EMailKonten = ENV.HasRight(UserRights.EMailKontenVerwalten),
                LogManager = false
            };

            AnyMen?ItemStammdaten =
            (
                RightsStammdaten.Einrichtung ||
                RightsStammdaten.Benutzer ||
                RightsStammdaten.Gruppenrechte ||
                RightsStammdaten.VerwaltungEinrichtungUndBenutzer ||
                RightsStammdaten.VerwaltungFortbildungen ||

                RightsStammdaten.Auswahllisten ||
                RightsStammdaten.Zusatzeintr?ge ||
                RightsStammdaten.Textbausteine ||
                RightsStammdaten.Dokumentenverwaltung ||
                RightsStammdaten.ExterneEinrichtungen ||

                RightsStammdaten.Standardprozeduren ||
                RightsStammdaten.Assessments ||
                RightsStammdaten.Medikamente ||
                RightsStammdaten.Pflegerichtlinien ||
                RightsStammdaten.?rzteverwaltung ||
                RightsStammdaten.Arztabrechnung ||
                RightsStammdaten.?rzteZusammenf?hren ||
                RightsStammdaten.Befundimport ||

                RightsStammdaten.Quickfilter ||
                RightsStammdaten.LayoutManager ||
                RightsStammdaten.MedizinischeTypen ||
                RightsStammdaten.MedizinscheDialoge ||
                RightsStammdaten.WundbilderSkalieren ||

                RightsStammdaten.QS2 ||
                RightsStammdaten.QS2AbfragebVerwaltenAdmin ||
                RightsStammdaten.QS2Ressourcen ||
                RightsStammdaten.QS2InformationenFelderSQLServer ||
                RightsStammdaten.QS2Kriterien ||
                RightsStammdaten.QS2Auswahllisten ||

                RightsStammdaten.Archiveinstellungen ||
                RightsStammdaten.EMailKonten ||
                RightsStammdaten.LogManager
            );

            AllMen?ItemsStammdaten =
            (
                !RightsStammdaten.Einrichtung &&        
                
                //Benutzer-Items immer extra

                //!RightsStammdaten.Auswahllisten &&    //bestehendes Recht vor 08/22-kann das Men? nicht steuern
                !RightsStammdaten.Zusatzeintr?ge &&
                !RightsStammdaten.Textbausteine &&
                !RightsStammdaten.Dokumentenverwaltung &&
                !RightsStammdaten.ExterneEinrichtungen &&

                !RightsStammdaten.Standardprozeduren &&
                !RightsStammdaten.Assessments &&
                !RightsStammdaten.Medikamente &&
                !RightsStammdaten.Pflegerichtlinien &&
                !RightsStammdaten.?rzteverwaltung &&
                !RightsStammdaten.Arztabrechnung &&
                !RightsStammdaten.?rzteZusammenf?hren &&
                !RightsStammdaten.Befundimport &&

                !RightsStammdaten.Quickfilter &&
                //!RightsStammdaten.LayoutManager &&    //bestehendes Recht vor 08/22-kann das Men? nicht steuern
                !RightsStammdaten.MedizinischeTypen &&
                !RightsStammdaten.MedizinscheDialoge &&
                !RightsStammdaten.WundbilderSkalieren &&

                !RightsStammdaten.QS2 &&
                !RightsStammdaten.QS2AbfragebVerwaltenAdmin &&
                !RightsStammdaten.QS2Ressourcen &&
                !RightsStammdaten.QS2InformationenFelderSQLServer &&
                !RightsStammdaten.QS2Kriterien &&
                !RightsStammdaten.QS2Auswahllisten &&

                !RightsStammdaten.Archiveinstellungen &&
                !RightsStammdaten.EMailKonten           
                //LogManager nicht relevant (immer ausgeblendet)
            ) || ENV.adminSecure;
        }

        public void action(bool bOnOff)
        {
            this.ucHeader1._action = bOnOff;
        }

        public void mainEventReceive(eSendMain typ, cParDelegSendMain ParDelegSendMain)
        {
            try
            {
                if (typ == eSendMain.medizinDataChanged)
                {
                    this.ucHeader1.refreshMedizinDaten();
                }
                else if (typ == eSendMain.ShowMessagesUnread)
                {
                    if (ParDelegSendMain.foundUnreadedMessages > 0)
                    {
                        var TxtMessaged = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten") + " (" + ParDelegSendMain.foundUnreadedMessages.ToString() + ")";
                        var TxtMessagedunreaded = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungelesene Nachrichten") + ": " + ParDelegSendMain.foundUnreadedMessages.ToString() + "";
                        PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.btnMessages.Invoke((MethodInvoker)delegate { PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.btnMessages.Text = TxtMessaged; });
                        this.ultraStatusBar1.Invoke((MethodInvoker)delegate { this.ultraStatusBar1.Panels["UnreadedMessages"].Text = TxtMessagedunreaded; });
                        if (PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1 != null)
                        {
                            PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.ultraStatusBar1.Invoke((MethodInvoker)delegate { PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.ultraStatusBar1.Panels["UnreadedMessages"].Text = TxtMessagedunreaded; });
                            if (PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1 != null && (ParDelegSendMain.foundUnreadedMessages > 0))
                            {
                                PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.ultraStatusBar1.Invoke((MethodInvoker)delegate { PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.contMessenger1.lblNewMessages.Visible = true; });
                            }
                        }
                    }
                    else
                    {
                        var TxtMessaged = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten");
                        PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.btnMessages.Invoke((MethodInvoker)delegate { PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.btnMessages.Text = TxtMessaged; });
                        this.ultraStatusBar1.Invoke((MethodInvoker)delegate { this.ultraStatusBar1.Panels["UnreadedMessages"].Text = ""; });
                        if (PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1 != null)
                        {
                            PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.ultraStatusBar1.Invoke( (MethodInvoker) delegate { PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.frmMessenger1.ultraStatusBar1.Panels["UnreadedMessages"].Text = ""; });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string checkException1 = "Invoke oder BeginInvoke kann f?r ein Steuerelement erst aufgerufen werden, wenn das Fensterhandle erstellt wurde";
                string checkException2 = "Zielthread ist nicht mehr vorhanden";
                if (ex.ToString().Trim().ToLower().Contains(checkException1.Trim().ToLower()) || ex.ToString().Trim().ToLower().Contains(checkException2.Trim().ToLower()))
                {
                    string exStr = ex.ToString();
                }
                else
                {
                    PMDS.Global.ENV.HandleException(ex);
                }
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Notfall Definition wurde ver?ndert
        /// </summary>
        //----------------------------------------------------------------------------
        void ENV_NotfallChanged(object sender, EventArgs e)
        {
            RefreshNotfallMenues();
        }

        void GuiAction_GuiActionDone(SiteEvents ev)
        {
            switch (ev)
            {
                case SiteEvents.Versetzen:
                    RefreshStatusbarAbteilung(ENV.CurrentIDPatient);
                    break;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Header Kn?pfe verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        void ucHeader1_HeaderButtonClick(ucHeader.HeaderButtons Button, bool refreshData)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (Button)
                {
                    case ucHeader.HeaderButtons.Anamnese:
                        GuiWorkflow._guiworkflow.initDatenerhebung();
                        GuiWorkflow.ShowAssesment();
                        break;
                    case ucHeader.HeaderButtons.Planung:
                        GuiWorkflow._guiworkflow.initPflegeplanung2();
                        GuiWorkflow.ShowPflegePlan();
                        break;

                    case ucHeader.HeaderButtons.Durchf?hrung:
                        if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                        {
                            GuiWorkflow.ShowInterventionen(refreshData);
                        }
                        else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                        {
                            GuiWorkflow.ShowInterventionenBereich();

                        }
                        break;

                    case ucHeader.HeaderButtons.Uebergabe:
                        if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Klientanansicht)
                        {
                            GuiWorkflow.Show?bergabe(refreshData);
                        }
                        else if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                        {
                            GuiWorkflow.Show?bergabeBereich();
                        }
                        break;

                    case ucHeader.HeaderButtons.Evaluierung:
                        GuiWorkflow._guiworkflow.initEvaluierung();
                        GuiWorkflow.ShowEvaluierung();
                        break;

                    case ucHeader.HeaderButtons.Details:
                        GuiWorkflow._guiworkflow.initKlintenakt(false);
                        GuiWorkflow.ShowKlientenDetails();
                        break;

                    case ucHeader.HeaderButtons.Klienten:
                        GuiWorkflow._guiworkflow.initKlintenakt(false);
                        GuiWorkflow.ShowKlienten();
                        break;

                    case ucHeader.HeaderButtons.intervHistorie:
                        GuiWorkflow.ShowInterventionen(true);
                        break;

                    case ucHeader.HeaderButtons.Berichte:
                        GuiWorkflow._guiworkflow.initBerichte();
                        GuiWorkflow.ShowBerichte();
                        break;

                    case ucHeader.HeaderButtons.Medikamente:
                        GuiWorkflow._guiworkflow.initMedikamentierungsbereich();
                        GuiWorkflow.ShowMedikamenteStammdaten();
                        break;

                    case ucHeader.HeaderButtons.Wunde:
                        GuiWorkflow._guiworkflow.initWunddoku();
                        GuiWorkflow.ShowWunde();
                        break;

                    default:
                        break;

                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void ShowHideMenuVerwaltung(bool bKlientenListeOnTop)
        {
            bool AnyMen?ItemVerwaltung = false;
            this.setRights(ref AnyMen?ItemVerwaltung);
            bool bShowVerwaltung = AnyMen?ItemVerwaltung && bKlientenListeOnTop;
            ultraToolbarsManager1.Tools["Verwaltung"].SharedProps.Visible = bShowVerwaltung;     
            ultraToolbarsManager1.Tools["mnuKlient"].SharedProps.Visible = !ultraToolbarsManager1.Tools["Verwaltung"].SharedProps.Visible;
            ultraToolbarsManager1.Tools["Klientenliste"].SharedProps.Visible = true;

            if (PMDS.Global.historie.HistorieOn)
            {
                ultraToolbarsManager1.Tools["Urlaub"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["Bezugsperson"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["NotfallprozedurenListe"].SharedProps.Visible = false;
                ultraToolbarsManager1.Tools["StandardprozedurenListe"].SharedProps.Visible = false;
            }
            else
            {
                ultraToolbarsManager1.Tools["Bewerber"].SharedProps.Visible = ENV.HasRight(UserRights.BewerberStarten);
                ultraToolbarsManager1.Tools["Urlaub"].SharedProps.Visible = ENV.HasRight(UserRights.Urlaube);
                ultraToolbarsManager1.Tools["Bezugsperson"].SharedProps.Visible = ENV.HasRight(UserRights.BezugspersonAendern);
                ultraToolbarsManager1.Tools["NotfallprozedurenListe"].SharedProps.Visible = ultraToolbarsManager1.Tools["mnuKlient"].SharedProps.Visible;
                ultraToolbarsManager1.Tools["StandardprozedurenListe"].SharedProps.Visible = ultraToolbarsManager1.Tools["mnuKlient"].SharedProps.Visible;
                ultraToolbarsManager1.Tools["DatenarchivierungAlle"].SharedProps.Visible = ENV.HasRight(UserRights.KlientenberichtDrucken);
                ultraToolbarsManager1.Tools["DatenarchivierungKlient"].SharedProps.Visible = ENV.HasRight(UserRights.KlientenberichtDrucken);
            }

            GuiWorkflow.checkUserAcitvity();
            ultraToolbarsManager1.Tools["btnLoadDesignMode"].SharedProps.Visible = ENV.adminSecure;

            if (ENV.adminSecure)
            {
                ultraToolbarsManager1.Tools["Standardpflegeplaene"].SharedProps.Visible = true;
                ultraToolbarsManager1.Tools["mnuStammdaten"].SharedProps.Visible = true;
                ultraToolbarsManager1.Tools["mnuHilfstabellen"].SharedProps.Visible = true;
                ultraToolbarsManager1.Tools["btnRechteAbteilungenBereiche"].SharedProps.Visible = true;
            }
            else
            {
                bool Men?Standardpflegep?ne = ENV.HasRight(UserRights.Men?Standardpflegep?ne);
                bool Men?Stammdaten = ENV.HasRight(UserRights.Men?Stammdaten);
                bool Men?Hilfstabellen = ENV.HasRight(UserRights.Men?Hilfstabellen);
                bool Men?RechteAbteilungenBereiche = ENV.HasRight(UserRights.RechteAbteilungenBereiche);

                ultraToolbarsManager1.Tools["TextVerschluesseln"].SharedProps.Visible = Men?Stammdaten;

                ultraToolbarsManager1.Tools["Standardpflegeplaene"].SharedProps.Visible = Men?Standardpflegep?ne;
                ultraToolbarsManager1.Tools["mnuStammdaten"].SharedProps.Visible = Men?Stammdaten;
                ultraToolbarsManager1.Tools["mnuHilfstabellen"].SharedProps.Visible = Men?Hilfstabellen;
                ultraToolbarsManager1.Tools["btnRechteAbteilungenBereiche"].SharedProps.Visible = Men?RechteAbteilungenBereiche;

                if (!Men?Standardpflegep?ne && !Men?Stammdaten && !Men?Hilfstabellen && !Men?RechteAbteilungenBereiche)
                {
                    ultraToolbarsManager1.Tools["Grunddaten"].SharedProps.Visible = false;
                }
                else
                {
                    ultraToolbarsManager1.Tools["Grunddaten"].SharedProps.Visible = true;
                }
            }

            if (bKlientenListeOnTop)
            {
                UltraStatusPanel panelAbt = ultraStatusBar1.Panels["Abteilung"];
                panelAbt.Text = "";
            }
        }

 
        //----------------------------------------------------------------------------
        /// <summary>
        /// Anzeigen/ verstecken des Men?s Benutzerwechsel (Darf nur bei Klientenliste aktiv sein)
        /// Abrechnung
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideMenuBenutzerwechsel(bool bKlientenListeOnTop)
        {
            ultraToolbarsManager1.Tools["Benutzerwechsel"].SharedProps.Visible = true; // bKlientenListeOnTop;
            ultraToolbarsManager1.Tools["Arbeitsstationsperren"].SharedProps.Visible = true;  //bKlientenListeOnTop;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Handler wenn die Patientenauswahl ge?ndert wird
        /// </summary>
        //----------------------------------------------------------------------------
        void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine)
        {
            ultraToolbarsManager1.Tools["Extras"].SharedProps.Enabled = Guid.Empty != IDPatient;
            ultraToolbarsManager1.Tools["mnuKlient"].SharedProps.Enabled = Guid.Empty != IDPatient;

            // Aufnahme muss immer da sein.....
            ultraToolbarsManager1.Tools["Entlassen"].SharedProps.Visible = ENV.HasRight(UserRights.Entlassung) && Guid.Empty != IDPatient;
            ultraToolbarsManager1.Tools["Versetzen"].SharedProps.Visible = ENV.HasRight(UserRights.Versetzung) && Guid.Empty != IDPatient;
            ultraToolbarsManager1.Tools["Bereichsversetzung"].SharedProps.Visible = ENV.HasRight(UserRights.Versetzung) && Guid.Empty != IDPatient;
            ultraToolbarsManager1.Tools["btnSTAMP"].SharedProps.Visible = ENV.HasRight(UserRights.STAMPMeldung);

            // Wenn der Klient gewechselt wird, dann die Abteilung setzen und das RMOptional setzen

            if (IDPatient != Guid.Empty)
            {
                BusinessLogic.Patient p = new BusinessLogic.Patient(IDPatient);
                ENV.ABTEILUNG = p.Aufenthalt.Verlauf.IDAbteilung_Nach;
                ENV.ABTEILUNG_RMOPTIONAL = KlinikAbteilungen.IsAbteilungRMOptional(ENV.ABTEILUNG);
            }

            RefreshStatusbarAbteilung(IDPatient);
        }

        private void RefreshStatusbarAbteilung(Guid IDPatient)
        {
            UltraStatusPanel panelAbt = ultraStatusBar1.Panels["Abteilung"];
            if (IDPatient != Guid.Empty)
                panelAbt.Text = ENV.String("GUI.STATUS_ABT", GuiUtil.Abteilung());
            else
                panelAbt.Text = "";
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dispose
        /// </summary>
        //----------------------------------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Programm");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuKlient");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Verwaltung");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Grunddaten");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NotfallprozedurenListe");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("StandardprozedurenListe");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("tbMain");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuKlient");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Programm");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Klientenliste");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Benutzerwechsel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Passwort");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool186 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnELGAPasswort?ndern");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Arbeitsstationsperren");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool135 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnLoadDesignMode");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool168 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextVerschluesseln");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool155 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2QueryExpress");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool108 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Texteditor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("About");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Beenden");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Beenden");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Arbeitsstationsperren");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Benutzerwechsel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Passwort");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("About");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool10 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Grunddaten");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool11 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Standardpflegeplaene");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool12 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuStammdaten");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool13 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHilfstabellen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRechteAbteilungenBereiche");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool14 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Extras");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Klientenaktionen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Klientenliste");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Barcodeverarbeitung");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool15 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Standardpflegeplaene");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ASZMVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDXZuordnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Top10");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool16 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuStammdaten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool119 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KlinikVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BenutzerVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool99 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Gruppenrechte");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool106 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerwaltungKlinikenUser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool167 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerwaltungFortbildungen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool161 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Auswahllisten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool162 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zusatzeintraege");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnTextbausteine");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageDocuments");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("EinrichtungenVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool166 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Standardprozeduren");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool160 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Formulare");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool109 = new Infragistics.Win.UltraWinToolbars.ButtonTool("MedikamenteVerwalten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool165 = new Infragistics.Win.UltraWinToolbars.ButtonTool("LinkDokumenteVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn?rzteverwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool170 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnArztabrechnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn?rzteMergen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool101 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnImportBefunde");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool111 = new Infragistics.Win.UltraWinToolbars.ButtonTool("QuickFilter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool158 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnLayoutManager");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool163 = new Infragistics.Win.UltraWinToolbars.ButtonTool("MedizinischetypenVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool164 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Medizinische_Dialoge");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool182 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnWundBilderScale");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool146 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2ManageQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool150 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Ressourcen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool153 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2InformationFieldsSqlServer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool152 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Criterias");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool151 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2SelLists");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool129 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ArchivStammdaten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool174 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnUserAccounts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool154 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2LogManager");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool17 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuHilfstabellen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Massnahmenserien");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool74 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DienstZeiten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zeitbereich");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zeitbereichserien");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("QuickMeldung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ASZMVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDXZuordnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Top10");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("KlinikVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AbteilungenVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BereicheVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DienstZeiten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("EinrichtungenVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BenutzerVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Formulare");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Gruppenrechte");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Benutzerrechte");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("MedikamenteVerwalten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool58 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Auswahllisten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool59 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Massnahmenserien");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool60 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zusatzeintraege");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool61 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Farben");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool62 = new Infragistics.Win.UltraWinToolbars.ButtonTool("QuickFilter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool63 = new Infragistics.Win.UltraWinToolbars.ButtonTool("QuickMeldung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool64 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Entlassen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool65 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Versetzen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool66 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bereichsversetzung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool67 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Urlaub");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool68 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pflegeplan");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool69 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Historie");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool70 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Orem");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool71 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bemerkung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool72 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bezugsperson");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool73 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aufgaben");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool75 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegebericht");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool76 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegeplanPDx");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool77 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegeplanPDxOnlyOpen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool78 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OREMVerlauf");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool79 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ZusatzWertVerlauf");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool80 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Konfigurieren");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool81 = new Infragistics.Win.UltraWinToolbars.ButtonTool("R?cksetzen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool82 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Speichern");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool18 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Aktionen");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool19 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Daten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool83 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Historie");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool84 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Orem");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool85 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bemerkung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool86 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bezugsperson");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool87 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aufgaben");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool20 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Drucken");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool88 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPflegeBegleitschreiben");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool89 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegebericht");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool90 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintBrief");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool91 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegeplanPDx");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool92 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DruckenPflegeplanPDxOnlyOpen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool93 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OREMVerlauf");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool94 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ZusatzWertVerlauf");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool21 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Konfiguration");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool95 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Konfigurieren");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool96 = new Infragistics.Win.UltraWinToolbars.ButtonTool("R?cksetzen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool97 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Speichern");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool22 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuKlient");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool98 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Urlaub");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bezugsperson");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool100 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSearchMedikamente");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HistorieKlient");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DatenarchivierungKlient");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool176 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerordnungen2");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool191 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnPSE");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool102 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintBrief");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool103 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPflegeBegleitschreiben");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool104 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RezepteVerwalten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool105 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ZusatzeintraegeZuordnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool112 = new Infragistics.Win.UltraWinToolbars.ButtonTool("MedizinischetypenVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool113 = new Infragistics.Win.UltraWinToolbars.ButtonTool("LinkDokumenteVerwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool114 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool115 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aufnahme");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool25 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Verwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool116 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Aufnahme");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool120 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bewerber");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ImportGibodat");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool149 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Reports");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool148 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Queries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool147 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2ManageQueriesUser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool184 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Blackout-Pr?vention");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DatenarchivierungAlle");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Abrechnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool117 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnTransferCalcData");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool133 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnExportCalculations");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool172 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSuchtgiftschrankSchl?ssel");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool178 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerordnungen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool193 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSTAMP");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool188 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAbrechnungInkoProdukte");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool183 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnPatientAufenthalteL?schen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool122 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Medizinische_Dialoge");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool123 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Standardprozeduren");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool124 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool2");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool125 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Bewerber");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool126 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Abrechnung");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool26 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("NotfallprozedurenListe");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool27 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("StandardprozedurenListe");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool127 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zeitbereich");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool128 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Zeitbereichserien");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool130 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ArchivStammdaten");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Texteditor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("HistorieKlient");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DatenarchivierungAlle");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool110 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DatenarchivierungKlient");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool121 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnTransferCalcData");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool132 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnExportCalculations");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ImportGibodat");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool134 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnLoadDesignMode");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool136 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Queries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool137 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Reports");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool138 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2ManageQueriesUser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool139 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2ManageQueries");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool140 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Ressourcen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool141 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2SelLists");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool142 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2Criterias");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool143 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2InformationFieldsSqlServer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool144 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2QueryExpress");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool145 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnQS2LogManager");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool159 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnLayoutManager");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRechteAbteilungenBereiche");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool107 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnImportBefunde");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnTextbausteine");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn?rzteMergen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnManageDocuments");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerwaltungKlinikenUser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool118 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerwaltungFortbildungen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool169 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextVerschluesseln");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool171 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnArztabrechnung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool173 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSuchtgiftschrankSchl?ssel");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("btnHeimvertr?ge");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool175 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnUserAccounts");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btn?rzteverwaltung");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool131 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSearchMedikamente");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool177 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerordnungen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool179 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnVerordnungen2");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool180 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnPatientAufenthalteL?schen");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool181 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnWundBilderScale");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool185 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Blackout-Pr?vention");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool187 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnELGAPasswort?ndern");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool189 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAbrechnungInkoPauschale");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool190 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAbrechnungInkoProdukte");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool192 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnPSE");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool194 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSTAMP");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStripLogging = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._frmBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._frmBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlMain = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.panelControlGesamt = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelControl = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucHeader1 = new PMDS.GUI.ucHeader();
            this.lblIsLoading = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelStart = new QS2.Desktop.ControlManagment.BasePanel();
            this.textControl1 = new TXTextControl.TextControl();
            this.dsPDxEintraege1 = new PMDS.Data.PflegePlan.dsPDxEintraege();
            this.timerControlManager = new System.Windows.Forms.Timer(this.components);
            this.appStylistRuntime1 = new Infragistics.Win.AppStyling.Runtime.AppStylistRuntime(this.components);
            this.timerCheckConnectionAndNetwork = new System.Windows.Forms.Timer(this.components);
            this.PanelStatusbar = new System.Windows.Forms.Panel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.timerELGA = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.panelControlGesamt.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintraege1)).BeginInit();
            this.PanelStatusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitter1.Location = new System.Drawing.Point(0, 20);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 670);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // contextMenuStripLogging
            // 
            this.contextMenuStripLogging.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggingToolStripMenuItem,
            this.styleAppToolStripMenuItem,
            this.openConfigManagerToolStripMenuItem});
            this.contextMenuStripLogging.Name = "contextMenuStrip1";
            this.contextMenuStripLogging.Size = new System.Drawing.Size(198, 70);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.CheckOnClick = true;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.loggingToolStripMenuItem.Text = "Logging";
            // 
            // styleAppToolStripMenuItem
            // 
            this.styleAppToolStripMenuItem.Name = "styleAppToolStripMenuItem";
            this.styleAppToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.styleAppToolStripMenuItem.Text = "Style app";
            this.styleAppToolStripMenuItem.Click += new System.EventHandler(this.styleAppToolStripMenuItem_Click);
            // 
            // _frmBase_Toolbars_Dock_Area_Left
            // 
            this._frmBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.WhiteSmoke;
            this._frmBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Black;
            this._frmBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 20);
            this._frmBase_Toolbars_Dock_Area_Left.Name = "_frmBase_Toolbars_Dock_Area_Left";
            this._frmBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 670);
            this._frmBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.FontData.Name = "Microsoft Sans Serif";
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.ultraToolbarsManager1.Appearance = appearance1;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(PMDS.GUI.frmBase);
            this.ultraToolbarsManager1.LockToolbars = true;
            appearance7.BackColor = System.Drawing.Color.White;
            this.ultraToolbarsManager1.MenuSettings.Appearance = appearance7;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(337, 244);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(165, 99);
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            popupMenuTool7});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "MainMenu";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Floating;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.FloatingLocation = new System.Drawing.Point(542, 354);
            ultraToolbar2.FloatingSize = new System.Drawing.Size(102, 40);
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool8});
            ultraToolbar2.Text = "tbMain";
            ultraToolbar2.Visible = false;
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool9.SharedPropsInternal.Caption = "Datei";
            popupMenuTool9.SharedPropsInternal.Category = "Programm";
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool135.InstanceProps.IsFirstInGroup = true;
            buttonTool155.InstanceProps.IsFirstInGroup = true;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool4,
            buttonTool186,
            buttonTool3,
            buttonTool135,
            buttonTool168,
            buttonTool155,
            buttonTool108,
            buttonTool5,
            buttonTool6});
            buttonTool7.SharedPropsInternal.Caption = "Beenden";
            buttonTool7.SharedPropsInternal.Category = "Programm";
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            buttonTool8.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            buttonTool8.SharedPropsInternal.Caption = "Arbeitsstation sperren";
            buttonTool8.SharedPropsInternal.Category = "Programm";
            buttonTool9.SharedPropsInternal.Caption = "Abmelden";
            buttonTool9.SharedPropsInternal.Category = "Programm";
            buttonTool10.SharedPropsInternal.Caption = "PMDS-Passwort ?ndern";
            buttonTool10.SharedPropsInternal.Category = "Programm";
            buttonTool11.SharedPropsInternal.Caption = "?ber PMDS";
            buttonTool11.SharedPropsInternal.Category = "Programm";
            popupMenuTool10.SharedPropsInternal.Caption = "Grunddaten";
            buttonTool25.InstanceProps.IsFirstInGroup = true;
            popupMenuTool10.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool11,
            popupMenuTool12,
            popupMenuTool13,
            buttonTool25});
            popupMenuTool14.SharedPropsInternal.Caption = "Extras";
            buttonTool16.SharedPropsInternal.Caption = "Klientenaktionen";
            buttonTool17.SharedPropsInternal.Caption = "Klientenliste";
            buttonTool18.SharedPropsInternal.Caption = "Barcodeverarbeitung";
            popupMenuTool15.SharedPropsInternal.Caption = "Standardpflegepl?ne";
            buttonTool21.InstanceProps.IsFirstInGroup = true;
            popupMenuTool15.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool19,
            buttonTool20,
            buttonTool21});
            popupMenuTool16.SharedPropsInternal.Caption = "Stammdaten";
            buttonTool161.InstanceProps.IsFirstInGroup = true;
            buttonTool166.InstanceProps.IsFirstInGroup = true;
            buttonTool111.InstanceProps.IsFirstInGroup = true;
            buttonTool129.InstanceProps.IsFirstInGroup = true;
            popupMenuTool16.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool119,
            buttonTool27,
            buttonTool99,
            buttonTool106,
            buttonTool167,
            buttonTool161,
            buttonTool162,
            buttonTool35,
            buttonTool41,
            buttonTool26,
            buttonTool166,
            buttonTool160,
            buttonTool109,
            buttonTool165,
            buttonTool14,
            buttonTool170,
            buttonTool39,
            buttonTool101,
            buttonTool111,
            buttonTool158,
            buttonTool163,
            buttonTool164,
            buttonTool182,
            buttonTool146,
            buttonTool150,
            buttonTool153,
            buttonTool152,
            buttonTool151,
            buttonTool129,
            buttonTool174,
            buttonTool154});
            popupMenuTool17.SharedPropsInternal.Caption = "Zeitreihen verwalten";
            buttonTool33.InstanceProps.IsFirstInGroup = true;
            popupMenuTool17.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool33,
            buttonTool74,
            buttonTool43,
            buttonTool44,
            buttonTool38});
            buttonTool45.SharedPropsInternal.Caption = "ASRZM-Katalog";
            buttonTool46.SharedPropsInternal.Caption = "Pflegediagnosen";
            buttonTool47.SharedPropsInternal.Caption = "Favoritengruppen";
            buttonTool48.SharedPropsInternal.Caption = "Einrichtung";
            buttonTool49.SharedPropsInternal.Caption = "Abteilungen";
            buttonTool50.SharedPropsInternal.Caption = "Bereiche";
            buttonTool51.SharedPropsInternal.Caption = "Dienstzeiten";
            buttonTool52.SharedPropsInternal.Caption = "Externe Einrichtungen";
            buttonTool53.SharedPropsInternal.Caption = "Benutzer";
            buttonTool54.SharedPropsInternal.Caption = "Assessments";
            buttonTool55.SharedPropsInternal.Caption = "Gruppenrechte";
            buttonTool56.SharedPropsInternal.Caption = "Benutzerrechte";
            buttonTool57.SharedPropsInternal.Caption = "Medikamente";
            buttonTool58.SharedPropsInternal.Caption = "Auswahllisten";
            buttonTool59.SharedPropsInternal.Caption = "Ma?nahmenserien";
            buttonTool60.SharedPropsInternal.Caption = "Zusatzeintr?ge";
            buttonTool61.SharedPropsInternal.Caption = "Farben";
            buttonTool62.SharedPropsInternal.Caption = "Quickfilter";
            buttonTool63.SharedPropsInternal.Caption = "Quickmeldungen";
            buttonTool64.SharedPropsInternal.Caption = "Entlassen";
            buttonTool65.SharedPropsInternal.Caption = "Versetzen in andere Abteilung";
            buttonTool66.SharedPropsInternal.Caption = "Versetzen in anderen Bereich";
            buttonTool67.SharedPropsInternal.Caption = "Abwesenheiten";
            buttonTool68.SharedPropsInternal.Caption = "Pflegeplan";
            buttonTool69.SharedPropsInternal.Caption = "Historie";
            buttonTool70.SharedPropsInternal.Caption = "Klassifizierung nach Orem";
            buttonTool71.SharedPropsInternal.Caption = "Bemerkung";
            buttonTool72.SharedPropsInternal.Caption = "Bezugsperson";
            buttonTool73.SharedPropsInternal.Caption = "Aufgaben";
            buttonTool75.SharedPropsInternal.Caption = "Pflegebericht";
            buttonTool76.SharedPropsInternal.Caption = "Pflegeplan gesamt";
            buttonTool77.SharedPropsInternal.Caption = "Pflegeplan aktuell";
            buttonTool78.SharedPropsInternal.Caption = "OREM Verlauf";
            buttonTool79.SharedPropsInternal.Caption = "Zusatzwerte Verlauf";
            buttonTool80.SharedPropsInternal.Caption = "Konfigurieren";
            buttonTool81.SharedPropsInternal.Caption = "R?cksetzen";
            buttonTool82.SharedPropsInternal.Caption = "Speichern";
            popupMenuTool18.SharedPropsInternal.Caption = "Aktionen";
            popupMenuTool19.SharedPropsInternal.Caption = "Daten";
            popupMenuTool19.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool83,
            buttonTool84,
            buttonTool85,
            buttonTool86,
            buttonTool87});
            popupMenuTool20.SharedPropsInternal.Caption = "Drucken";
            popupMenuTool20.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool88,
            buttonTool89,
            buttonTool90,
            buttonTool91,
            buttonTool92,
            buttonTool93,
            buttonTool94});
            popupMenuTool21.SharedPropsInternal.Caption = "Layout";
            popupMenuTool21.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool95,
            buttonTool96,
            buttonTool97});
            popupMenuTool22.SharedPropsInternal.Caption = "Klient";
            buttonTool100.InstanceProps.IsFirstInGroup = true;
            buttonTool24.InstanceProps.IsFirstInGroup = true;
            buttonTool36.InstanceProps.IsFirstInGroup = true;
            buttonTool176.InstanceProps.IsFirstInGroup = true;
            popupMenuTool22.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool98,
            buttonTool15,
            buttonTool100,
            buttonTool24,
            buttonTool36,
            buttonTool176,
            buttonTool191});
            buttonTool102.SharedPropsInternal.Caption = "Pflegebrief";
            buttonTool103.SharedPropsInternal.Caption = "Pflegebegleitschreiben";
            buttonTool104.SharedPropsInternal.Caption = "?rztliche Verordnungen";
            buttonTool105.SharedPropsInternal.Caption = "Zusatzeintr?ge Zuordnung";
            buttonTool112.SharedPropsInternal.Caption = "Medizinische Typen";
            buttonTool113.SharedPropsInternal.Caption = "Pflegerichtlinien";
            buttonTool114.SharedPropsInternal.Caption = "ButtonTool1";
            buttonTool115.SharedPropsInternal.Caption = "Aufnahme";
            popupMenuTool25.SharedPropsInternal.Caption = "Verwaltung";
            buttonTool149.InstanceProps.IsFirstInGroup = true;
            buttonTool184.InstanceProps.IsFirstInGroup = true;
            buttonTool29.InstanceProps.IsFirstInGroup = true;
            buttonTool172.InstanceProps.IsFirstInGroup = true;
            buttonTool178.InstanceProps.IsFirstInGroup = true;
            buttonTool183.InstanceProps.IsFirstInGroup = true;
            popupMenuTool25.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool116,
            buttonTool120,
            buttonTool34,
            buttonTool149,
            buttonTool148,
            buttonTool147,
            buttonTool184,
            buttonTool30,
            buttonTool29,
            buttonTool117,
            buttonTool133,
            buttonTool172,
            buttonTool178,
            buttonTool193,
            buttonTool188,
            buttonTool183});
            buttonTool122.SharedPropsInternal.Caption = "Medizinische  Dialoge";
            buttonTool123.SharedPropsInternal.Caption = "Standardprozeduren";
            buttonTool124.SharedPropsInternal.Caption = "ButtonTool2";
            buttonTool125.SharedPropsInternal.Caption = "Bewerber";
            buttonTool126.SharedPropsInternal.Caption = "Abrechnung";
            popupMenuTool26.SharedPropsInternal.Caption = "Notfallprozeduren";
            popupMenuTool27.SharedPropsInternal.Caption = "Standardprozeduren";
            buttonTool127.SharedPropsInternal.Caption = "Zeitbereiche";
            buttonTool128.SharedPropsInternal.Caption = "Zeitbereichserien";
            buttonTool130.SharedPropsInternal.Caption = "Archiveinstellungen";
            buttonTool12.SharedPropsInternal.Caption = "Texteditor";
            buttonTool22.SharedPropsInternal.Caption = "Historische Daten";
            buttonTool31.SharedPropsInternal.Caption = "Datenarchivierung alle Klienten";
            buttonTool110.SharedPropsInternal.Caption = "Datenarchivierung";
            buttonTool121.SharedPropsInternal.Caption = "Abrechnungen als SQL-Tabellen ?berspielen";
            buttonTool132.SharedPropsInternal.Caption = "Abrechnungen -> BMD exportieren";
            buttonTool23.SharedPropsInternal.Caption = "Import Gibodat";
            buttonTool134.SharedPropsInternal.Caption = "UI Designer";
            buttonTool136.SharedPropsInternal.Caption = "QS2-Abfragen";
            buttonTool137.SharedPropsInternal.Caption = "QS2-Berichte";
            buttonTool138.SharedPropsInternal.Caption = "QS2-Abfragen verwalten (Benutzer)";
            buttonTool139.SharedPropsInternal.Caption = "QS2-Abfragen verwalten (Admin)";
            buttonTool140.SharedPropsInternal.Caption = "QS2-Ressourcen";
            buttonTool141.SharedPropsInternal.Caption = "QS-Auswahllisten";
            buttonTool142.SharedPropsInternal.Caption = "QS2-Kriterien";
            buttonTool143.SharedPropsInternal.Caption = "QS2-Information Felder Sql-Server";
            buttonTool144.SharedPropsInternal.Caption = "Query-Express";
            buttonTool145.SharedPropsInternal.Caption = "Log-Manager";
            buttonTool159.SharedPropsInternal.Caption = "Layout-Manager";
            buttonTool28.SharedPropsInternal.Caption = "Rechte Abteilungen und Bereiche";
            buttonTool107.SharedPropsInternal.Caption = "Befundimport (EDIFACT)";
            buttonTool32.SharedPropsInternal.Caption = "Textbausteine";
            buttonTool37.SharedPropsInternal.Caption = "?rzte zusammenf?hren";
            buttonTool40.SharedPropsInternal.Caption = "Dokumentenverwaltung";
            buttonTool42.SharedPropsInternal.Caption = "Verwaltung Einrichtungen und Benutzer";
            buttonTool118.SharedPropsInternal.Caption = "Verwaltung Fortbildungen";
            buttonTool169.SharedPropsInternal.Caption = "Text verschl?sseln";
            buttonTool171.SharedPropsInternal.Caption = "Arztabrechnung";
            buttonTool173.SharedPropsInternal.Caption = "Suchtgiftschrank-Schl?ssel";
            popupMenuTool3.SharedPropsInternal.Caption = "Heimvertr?ge";
            buttonTool175.SharedPropsInternal.Caption = "E-Mail Konten";
            buttonTool13.SharedPropsInternal.Caption = "?rzteverwaltung";
            buttonTool131.SharedPropsInternal.Caption = "Suche Medikamente";
            buttonTool177.SharedPropsInternal.Caption = "Verordnungen";
            buttonTool179.SharedPropsInternal.Caption = "Verordnungen";
            buttonTool180.SharedPropsInternal.Caption = "Patient und Aufenthalte l?schen";
            buttonTool181.SharedPropsInternal.Caption = "Wundbilder skalieren";
            buttonTool185.SharedPropsInternal.Caption = "Blackout-Pr?vention";
            buttonTool187.SharedPropsInternal.Caption = "ELGA-Passwort ?ndern";
            buttonTool189.SharedPropsInternal.Caption = "Abrechnung Inko-Pauschale";
            buttonTool190.SharedPropsInternal.Caption = "Abrechnung Inko-Produkt-Pauschale";
            buttonTool192.SharedPropsInternal.Caption = "Pflegestufen-Einsch?tzung";
            buttonTool194.SharedPropsInternal.Caption = "STAMP-Meldung";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool9,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            popupMenuTool10,
            popupMenuTool14,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            popupMenuTool15,
            popupMenuTool16,
            popupMenuTool17,
            buttonTool45,
            buttonTool46,
            buttonTool47,
            buttonTool48,
            buttonTool49,
            buttonTool50,
            buttonTool51,
            buttonTool52,
            buttonTool53,
            buttonTool54,
            buttonTool55,
            buttonTool56,
            buttonTool57,
            buttonTool58,
            buttonTool59,
            buttonTool60,
            buttonTool61,
            buttonTool62,
            buttonTool63,
            buttonTool64,
            buttonTool65,
            buttonTool66,
            buttonTool67,
            buttonTool68,
            buttonTool69,
            buttonTool70,
            buttonTool71,
            buttonTool72,
            buttonTool73,
            buttonTool75,
            buttonTool76,
            buttonTool77,
            buttonTool78,
            buttonTool79,
            buttonTool80,
            buttonTool81,
            buttonTool82,
            popupMenuTool18,
            popupMenuTool19,
            popupMenuTool20,
            popupMenuTool21,
            popupMenuTool22,
            buttonTool102,
            buttonTool103,
            buttonTool104,
            buttonTool105,
            buttonTool112,
            buttonTool113,
            buttonTool114,
            buttonTool115,
            popupMenuTool25,
            buttonTool122,
            buttonTool123,
            buttonTool124,
            buttonTool125,
            buttonTool126,
            popupMenuTool26,
            popupMenuTool27,
            buttonTool127,
            buttonTool128,
            buttonTool130,
            buttonTool12,
            buttonTool22,
            buttonTool31,
            buttonTool110,
            buttonTool121,
            buttonTool132,
            buttonTool23,
            buttonTool134,
            buttonTool136,
            buttonTool137,
            buttonTool138,
            buttonTool139,
            buttonTool140,
            buttonTool141,
            buttonTool142,
            buttonTool143,
            buttonTool144,
            buttonTool145,
            buttonTool159,
            buttonTool28,
            buttonTool107,
            buttonTool32,
            buttonTool37,
            buttonTool40,
            buttonTool42,
            buttonTool118,
            buttonTool169,
            buttonTool171,
            buttonTool173,
            popupMenuTool3,
            buttonTool175,
            buttonTool13,
            buttonTool131,
            buttonTool177,
            buttonTool179,
            buttonTool180,
            buttonTool181,
            buttonTool185,
            buttonTool187,
            buttonTool189,
            buttonTool190,
            buttonTool192,
            buttonTool194});
            this.ultraToolbarsManager1.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ultraToolbarsManager1_ToolClick);
            // 
            // _frmBase_Toolbars_Dock_Area_Right
            // 
            this._frmBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.WhiteSmoke;
            this._frmBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.Color.Black;
            this._frmBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1008, 20);
            this._frmBase_Toolbars_Dock_Area_Right.Name = "_frmBase_Toolbars_Dock_Area_Right";
            this._frmBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 670);
            this._frmBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmBase_Toolbars_Dock_Area_Top
            // 
            this._frmBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.WhiteSmoke;
            this._frmBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.Color.Black;
            this._frmBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._frmBase_Toolbars_Dock_Area_Top.Name = "_frmBase_Toolbars_Dock_Area_Top";
            this._frmBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1008, 20);
            this._frmBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _frmBase_Toolbars_Dock_Area_Bottom
            // 
            this._frmBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._frmBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this._frmBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.Color.Black;
            this._frmBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 690);
            this._frmBase_Toolbars_Dock_Area_Bottom.Name = "_frmBase_Toolbars_Dock_Area_Bottom";
            this._frmBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1008, 0);
            this._frmBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(594, 130);
            this.pnlMain.TabIndex = 25;
            // 
            // ultraGridBagLayoutManager1
            // 
            this.ultraGridBagLayoutManager1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutManager1.ExpandToFitWidth = true;
            // 
            // panelControlGesamt
            // 
            this.panelControlGesamt.BackColor = System.Drawing.Color.Gainsboro;
            this.panelControlGesamt.Controls.Add(this.panelControl);
            this.panelControlGesamt.Controls.Add(this.ucHeader1);
            this.panelControlGesamt.Controls.Add(this.lblIsLoading);
            this.panelControlGesamt.Location = new System.Drawing.Point(164, 273);
            this.panelControlGesamt.Name = "panelControlGesamt";
            this.panelControlGesamt.Size = new System.Drawing.Size(594, 262);
            this.panelControlGesamt.TabIndex = 30;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.Gainsboro;
            this.panelControl.Controls.Add(this.pnlMain);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 132);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(594, 130);
            this.panelControl.TabIndex = 26;
            // 
            // ucHeader1
            // 
            this.ucHeader1.BackColor = System.Drawing.Color.White;
            this.ucHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeader1.LEFTINFO = "";
            this.ucHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucHeader1.Margin = new System.Windows.Forms.Padding(5);
            this.ucHeader1.MIDDLEINFO = "";
            this.ucHeader1.Name = "ucHeader1";
            this.ucHeader1.RIGHTINFO = "";
            this.ucHeader1.Size = new System.Drawing.Size(594, 132);
            this.ucHeader1.TabIndex = 0;
            // 
            // lblIsLoading
            // 
            appearance6.ForeColor = System.Drawing.Color.Gray;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.lblIsLoading.Appearance = appearance6;
            this.lblIsLoading.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblIsLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIsLoading.Location = new System.Drawing.Point(0, 0);
            this.lblIsLoading.Name = "lblIsLoading";
            this.lblIsLoading.Size = new System.Drawing.Size(594, 262);
            this.lblIsLoading.TabIndex = 40;
            this.lblIsLoading.Text = "Daten werden geladen\r\nBitte warten ...";
            // 
            // panelStart
            // 
            this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStart.BackColor = System.Drawing.Color.White;
            this.panelStart.Location = new System.Drawing.Point(0, 21);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(1006, 641);
            this.panelStart.TabIndex = 35;
            this.panelStart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStart_Paint);
            // 
            // textControl1
            // 
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(903, 43);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03D;
            this.textControl1.PageMargins.Left = 79.03D;
            this.textControl1.PageMargins.Right = 79.03D;
            this.textControl1.PageMargins.Top = 79.03D;
            this.textControl1.Size = new System.Drawing.Size(101, 45);
            this.textControl1.TabIndex = 0;
            this.textControl1.UserNames = null;
            // 
            // dsPDxEintraege1
            // 
            this.dsPDxEintraege1.DataSetName = "dsPDxEintraege";
            this.dsPDxEintraege1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timerControlManager
            // 
            this.timerControlManager.Interval = 1000;
            this.timerControlManager.Tick += new System.EventHandler(this.timerControlManager_Tick);
            // 
            // timerCheckConnectionAndNetwork
            // 
            this.timerCheckConnectionAndNetwork.Interval = 10000;
            this.timerCheckConnectionAndNetwork.Tick += new System.EventHandler(this.timerCheckConnectionAndNetwork_Tick);
            // 
            // PanelStatusbar
            // 
            this.PanelStatusbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelStatusbar.BackColor = System.Drawing.Color.Transparent;
            this.PanelStatusbar.Controls.Add(this.ultraStatusBar1);
            this.PanelStatusbar.Location = new System.Drawing.Point(-1, 662);
            this.PanelStatusbar.Name = "PanelStatusbar";
            this.PanelStatusbar.Size = new System.Drawing.Size(1009, 24);
            this.PanelStatusbar.TabIndex = 40;
            // 
            // ultraStatusBar1
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.ultraStatusBar1.Appearance = appearance2;
            this.ultraStatusBar1.ContextMenuStrip = this.contextMenuStripLogging;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 6);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            appearance3.BorderColor = System.Drawing.Color.White;
            this.ultraStatusBar1.PanelAppearance = appearance3;
            ultraStatusPanel1.Key = "User";
            ultraStatusPanel1.ToolTipText = "Angemeldeter Benutzer";
            ultraStatusPanel1.Width = 200;
            ultraStatusPanel1.WrapText = Infragistics.Win.DefaultableBoolean.False;
            ultraStatusPanel2.Key = "Abteilung";
            ultraStatusPanel2.ToolTipText = "Aktuelle Abteilung";
            ultraStatusPanel2.Width = 200;
            ultraStatusPanel2.WrapText = Infragistics.Win.DefaultableBoolean.False;
            ultraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel4.Width = 40;
            ultraStatusPanel8.Key = "UnreadedMessages";
            ultraStatusPanel8.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            appearance4.FontData.SizeInPoints = 7F;
            ultraStatusPanel5.Appearance = appearance4;
            ultraStatusPanel5.Key = "Config";
            ultraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            ultraStatusPanel5.Text = "Config";
            appearance5.FontData.SizeInPoints = 7F;
            ultraStatusPanel6.Appearance = appearance5;
            ultraStatusPanel6.Key = "Laden";
            ultraStatusPanel6.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            ultraStatusPanel6.Text = "Laden";
            ultraStatusPanel6.ToolTipText = "pmds.config neu laden";
            ultraStatusPanel9.Width = 70;
            ultraStatusPanel7.Key = "statELGA";
            ultraStatusPanel7.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            ultraStatusPanel7.Visible = false;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel8,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel9,
            ultraStatusPanel7});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1009, 18);
            this.ultraStatusBar1.TabIndex = 22;
            this.ultraStatusBar1.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.ultraStatusBar2_ButtonClick);
            // 
            // timerELGA
            // 
            this.timerELGA.Interval = 300000;
            this.timerELGA.Tick += new System.EventHandler(this.TimerELGA_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.PanelStatusbar);
            this.Controls.Add(this.panelControlGesamt);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this._frmBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._frmBase_Toolbars_Dock_Area_Top);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(947, 683);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMDS";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMainModern_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainModern_FormClosing);
            this.Load += new System.EventHandler(this.frmMainModern_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMainModern_ResizeEnd);
            this.VisibleChanged += new System.EventHandler(this.frmMainModern_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainModern_KeyDown);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.MyLayout);
            this.Resize += new System.EventHandler(this.frmMainModern_Resize_1);
            this.contextMenuStripLogging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.panelControlGesamt.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxEintraege1)).EndInit();
            this.PanelStatusbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region IPMDSHeader Member

        //----------------------------------------------------------------------------
        /// <summary>
        /// Linker Info Text
        /// </summary>
        //----------------------------------------------------------------------------
        public string LEFTINFO
        {
            set { ucHeader1.LEFTINFO = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Mittlerer  Info Text
        /// </summary>
        //----------------------------------------------------------------------------
        public string MIDDLEINFO
        {
            set { ucHeader1.MIDDLEINFO = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// rechter Info Text
        /// </summary>
        //----------------------------------------------------------------------------
        public string RIGHTINFO
        {
            set { ucHeader1.RIGHTINFO = value; }
        }

        public void ShowOnlyHeader(bool bShow)
        {
            ucHeader1.Visible = true;       // bShow;
            if (bShow)
            {
                this.ucHeader1.Height = 132;
                this.panelControlGesamt.Dock = DockStyle.None;
                this.panelStart.Dock = DockStyle.None;

                this.panelControlGesamt.Left = 0;
                this.panelControlGesamt.Top = 21;
                this.panelControlGesamt.Width = this.Width - 15;
                this.panelControlGesamt.Height = this.Height - 60 - this.PanelStatusbar.Height;
                this.panelControlGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));

                this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                this.panelStart.Height = 0;
                this.panelStart.Width = 0;
            }
            else
            {
                this.ucHeader1.Height = 132;
                this.panelStart.Dock = DockStyle.None;
                this.panelControlGesamt.Dock = DockStyle.None;

                this.panelStart.Left = 0;
                this.panelStart.Top = 21;
                this.panelStart.Width = this.Width - 5;
                this.panelStart.Height = this.Height - 60 - this.PanelStatusbar.Height;
                this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));

                this.panelControlGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                this.panelControlGesamt.Height = 0;
                this.panelControlGesamt.Width = 0;
            }

            this.panelControl.Dock = DockStyle.None;
            this.panelControl.Height = 0;
            this.panelControl.Width = 0;
            this.Show();

            Application.DoEvents();
        }
        public void ShowControlAndHeader(bool bShow)
        {
            if (bShow)
            {
                this.panelControl.Dock = DockStyle.Fill;
                Application.DoEvents();
            }
            else
            {
                this.panelControl.Dock = DockStyle.None;
                this.panelControl.Height = 0;
                this.panelControl.Width = 0;
            }
        }
        public void ShowGesamtarchiv(bool bShow)
        {
            if (bShow)
            {
                this.ucHeader1.Height = 0;
                this.panelControlGesamt.Dock = DockStyle.None;
                this.panelStart.Dock = DockStyle.None;

                this.panelControlGesamt.Left = 0;
                this.panelControlGesamt.Top = 21;
                this.panelControlGesamt.Width = this.Width - 15;
                this.panelControlGesamt.Height = this.Height - 60 - this.PanelStatusbar.Height;
                this.panelControlGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));

                this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                this.panelStart.Height = 0;
                this.panelStart.Width = 0;
            }
            else
            {
                this.ucHeader1.Height = 0;
                this.panelStart.Dock = DockStyle.None;
                this.panelControlGesamt.Dock = DockStyle.None;

                this.panelStart.Left = 0;
                this.panelStart.Top = 21;
                this.panelStart.Width = this.Width - 5;
                this.panelStart.Height = this.Height - 60 - this.PanelStatusbar.Height;
                this.panelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom)));

                this.panelControlGesamt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                this.panelControlGesamt.Height = 0;
                this.panelControlGesamt.Width = 0;
            }

            this.panelControl.Dock = DockStyle.Fill;
            //Application.DoEvents();
        }


        #endregion

        #region IPMDSMenuFramework

        //----------------------------------------------------------------------------
        /// <summary>
        /// Header ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        public IPMDSHeader HEADER
        {
            get { return this; }
        }

        //public void setHistorieUI(bool bOn, SiteEvents currentMode)
        //{
        //    foreach (Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup grp in this.MainBar.Groups)
        //    {
        //        if (currentMode == SiteEvents.Uebergabe)
        //        {
        //            if (grp.Key.ToString() == SiteGroups.historieRefresh.ToString() )
        //            {
        //                grp.Visible = false ;
        //            }
        //            if (grp.Key.ToString() == SiteGroups.Print.ToString())
        //            {
        //                grp.Visible = !bOn;
        //            }
        //        }
        //        else
        //        {
        //            if (grp.Key.ToString() == SiteGroups.historieRefresh.ToString() || grp.Key.ToString() == SiteGroups.Print.ToString())
        //            {
        //                grp.Visible = !bOn;
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }

        //    if (bOn)
        //    {
        //        if (currentMode == SiteEvents.Uebergabe)
        //        {
        //            this.MainBar.Groups[SiteGroups.historieRefresh.ToString()].Visible = false;
        //            this.MainBar.Groups[SiteGroups.Print.ToString()].Visible = true;
        //            this.MainBar.Groups[SiteGroups.Termine2.ToString()].Visible = false;
        //            this.MainBar.Groups[SiteGroups.Termine.ToString()].Visible = true;
        //            this.MainBar.Groups[SiteGroups.Termine.ToString()].Items[3].Visible = false;
        //        }
        //        else
        //        {
        //            this.MainBar.Groups[SiteGroups.historieRefresh.ToString()].Visible = true;
        //            this.MainBar.Groups[SiteGroups.Print.ToString()].Visible = true;
        //            this.MainBar.Groups[SiteGroups.Termine2.ToString()].Visible = false;
        //            this.MainBar.Groups[SiteGroups.Termine.ToString()].Visible = false;

        //        }
        //    }
        //    else
        //    {
        //        this.MainBar.Groups[SiteGroups.historieRefresh.ToString()].Visible = false;
        //        this.MainBar.Groups[SiteGroups.Print.ToString()].Visible = true;
        //        this.MainBar.Groups[SiteGroups.Termine2.ToString()].Visible = true;
        //    }

        //    this.MainBar.Groups[SiteGroups.historieRefresh.ToString()].Text = "Termine";
        //}


        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI Object im Framework einh?ngen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddObject(IPMDSGUIObject o)
        {
            Control c = o.CONTROL;
            c.Dock = DockStyle.Fill;
            c.Visible = false;

            o.FRAMEWORK = this;
            pnlMain.Controls.Add(c);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein Objekt in den Vordergrund bringen
        /// </summary>
        //----------------------------------------------------------------------------
        public void BringOnTop(IPMDSGUIObject o)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                UpdateColors();

                this._KlientenlisteOnTop = o.AREA == "SITEMAP_START";
                ucHeader1.LEFTINFO = o.AREA;
                ShowHideMenuVerwaltung(o.AREA == "SITEMAP_START");
                ShowHideMenuBenutzerwechsel(o.AREA == "SITEMAP_START");

                if (o.GetType() == typeof(PMDS.GUI.ucMedikamenteMainPicker))
                {
                    PMDS.GUI.ucMedikamenteMainPicker contMed = (PMDS.GUI.ucMedikamenteMainPicker)o;
                    ucMed1Verschreiben ucMed1Verschreiben1 = (ucMed1Verschreiben)contMed.ucMedikamenteStammdaten1._aControls[(int)MedikationMode.MedVerschreiben1];
                }

                if (_topGUI != null)                    
                {
                    _topGUI.CONTROL.Hide();
                    _topGUI.DetachFramework();
                }

                o.AttachFramework();
                o.CONTROL.Show();       //os-Performance !!!    2,3 Sekunden
                this.panelControl.Dock = DockStyle.Fill;
                //Application.DoEvents();

                _topGUI = o;
                PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart._showFirst = false;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion //IPMDSMenuFramework



        private void frmMainModern_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.panelStart.BringToFront();

                ENV.TaskbarPosition TaskbarPos = ENV.TaskbarPosition.Ausgeblendet;     //0 = ausgeblendet, 1 = unten, 2 = rechts, 3 = links
                int TaskbarHeight = 0;
                int TaskbarWidth = 0;
                System.Drawing.Rectangle UsableScreen = System.Windows.Forms.Screen.GetWorkingArea(this);
                System.Drawing.Rectangle FullScreen = System.Windows.Forms.Screen.GetBounds(this);

                if (!DesignMode)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                    ControlManagment1.autoTranslateToolbars(this.ultraToolbarsManager1, null, this);
                }

                //Taskbarposition ermitteln (geht nur, wenn eine eingeblendet ist)
                if (UsableScreen.X == 0 && UsableScreen.Y == 0)  // Taskbar rechts, unten oder ausgeblendet
                {
                    if (UsableScreen.Height < FullScreen.Height)
                    {
                        TaskbarPos = ENV.TaskbarPosition.Unten;
                        TaskbarHeight = FullScreen.Height - UsableScreen.Height;
                        TaskbarWidth = FullScreen.Width;
                    }

                    if (UsableScreen.Width < FullScreen.Width)
                    {
                        TaskbarPos = ENV.TaskbarPosition.Rechts;
                        TaskbarHeight = FullScreen.Height;
                        TaskbarWidth = FullScreen.Width - UsableScreen.Width;
                    }
                }

                if (UsableScreen.X > 0)         //Taskbar links
                {
                    TaskbarPos = ENV.TaskbarPosition.Links;
                    TaskbarHeight = FullScreen.Height;
                    TaskbarWidth = FullScreen.Width - UsableScreen.Width;
                }

                if (UsableScreen.Y > 0)         //Taskbar oben
                {
                    TaskbarPos = ENV.TaskbarPosition.Oben;
                    TaskbarHeight = FullScreen.Height - UsableScreen.Height;
                    TaskbarWidth = FullScreen.Width;
                }

                this.Location = new Point(UsableScreen.X, UsableScreen.Y);
                this.Width = UsableScreen.Width;
                this.Height = UsableScreen.Height;
                
                //Minimumsize abh?ngig von der Taskbar-Position festlegen
                if (TaskbarPos == ENV.TaskbarPosition.Oben || TaskbarPos == ENV.TaskbarPosition.Unten)
                {
                    this.MinimumSize = new Size(1024, 768 - TaskbarHeight);
                }
                else if (TaskbarPos == ENV.TaskbarPosition.Links || TaskbarPos == ENV.TaskbarPosition.Rechts)
                {
                    this.MinimumSize = new Size(1024 - TaskbarWidth, 768);
                }
                else
                {
                    this.MinimumSize = new Size(1024, 737);
                }

                if (ENV.CheckScreenSize && (UsableScreen.Width < 1200 || UsableScreen.Height < 737))
                {
                    string sMsgBoxTranslate = "Die verf?gbare Arbeitsfl?che Ihres Bildschirms ({0} * {1}" +
                                            ") ist kleiner als die empfohlene Mindestaufl?sung (1200 * 737)\n\r" +
                                            "Bei einigen Funktionen wird die Anzeige nicht vollst?ndig sein.";
                    sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, UsableScreen.Width.ToString(), UsableScreen.Height.ToString());
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Wichtiger Hinweis zur Anzeige Ihres Ger?tes!");
                }

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                if (ENV.DEMO)
                    this.Text = this.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes(" DEMO Version");

                this.UISitemap = new PMDS.UI.Sitemap.UIFct();
                if (!PMDS.Global.ENV.adminSecure)
                {
                    this.ultraStatusBar1.Panels["Laden"].Visible = false;
                    this.ultraStatusBar1.Panels["Config"].Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Text;
                }

                this.UISitemap.infoRuntimStatusbar(ref this.ultraStatusBar1);
                PMDS.BusinessLogic.Standardzeiten.InitStandardzeiten();

                if (ENV.PathDokumente.Trim() != "" && !System.IO.Directory.Exists(ENV.PathDokumente.Trim()))
                {
                    this.ultraToolbarsManager1.Tools["btnManageDocuments"].SharedProps.Visible = false;
                }

                this.timerCheckConnectionAndNetwork.Enabled = true;
                this.timerCheckConnectionAndNetwork.Start();

                if (ENV.lic_ELGA && PMDSClientWrapper.WCFServiceOnOff)
                {
                    this.timerELGA.Interval = 3 * 1000;  
                    this.timerELGA.Enabled = true;
                    this.timerELGA.Start();
                }
                else
                {
                    this.timerELGA.Enabled = false;
                    this.timerELGA.Stop();
                    this.bElga.setStatusbarOnOff(this.ultraStatusBar1, false);
                }

                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(this.th_checkNewVersion));
                t.Start();

                if (!ENV.adminSecure)
                {
                    this.ultraStatusBar1.ContextMenuStrip = null;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }

        public void setHeaderUI(bool RefreshGui)
        {
            this.ucHeader1.setUIHeaderToHistorieBereich(PMDS.Global.historie.HistorieOn, false, false, RefreshGui);
        }

        private void frmMainModern_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int iDekursEntw?rfeOffen = 0;
                bool bEndPMDS = false;
                
                this.checkListeDekursEntw?rfe(ref iDekursEntw?rfeOffen, ref bEndPMDS, this.CloseAnyway);
                
                if (iDekursEntw?rfeOffen > 0)
                {
                    if (bEndPMDS)
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        PMDSBusiness1.checkEndAnonymLogIn();

                        WCFServiceClient WCFServiceClient1 = new WCFServiceClient();
                        WCFServiceClient1.ELGALogOut(ENV.USERID, ENV.lic_ELGA);

                        if (!PMDS.Global.ENV.WCFServiceDebugMode)
                        {
                            WCFServiceClient wcf = new WCFServiceClient();
                            wcf.stopCheckWCFServiceLocal(false);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (this.CloseAnyway)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MAIN.ASK_FOR_CLOSE"),
                                                            ENV.String("MAIN.DIALOGTITLE_ASK_FOR_CLOSE"),
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question, true);

                        e.Cancel = (res == DialogResult.No ? true : false);
                    }

                    if (!e.Cancel)
                    {
                        PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                        PMDSBusiness1.checkEndAnonymLogIn();
                        PMDS.DB.PMDSBusinessComm.closeAllThreads = true;
                        PMDS.DB.PMDSBusinessComm.threadLoadData = null;

                        WCFServiceClient WCFServiceClient1 = new WCFServiceClient();
                        WCFServiceClient1.ELGALogOut(ENV.USERID, ENV.lic_ELGA);

                        if (!PMDS.Global.ENV.WCFServiceDebugMode)
                        {
                            WCFServiceClient wcf = new WCFServiceClient();
                            wcf.stopCheckWCFServiceLocal(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void checkListeDekursEntw?rfe(ref int iDekursEntw?rfeOffen, ref bool bEndPMDS, bool CloseAnyway, Nullable<DateTime> IDTimeRepeat = null)
        {
            if (CloseAnyway)
            {
                iDekursEntw?rfeOffen = 0;
                bEndPMDS = true;
                return;
            }

            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<db.Entities.PflegeEintragEntwurf> tPflegeEintragEntwurf = this.b.getPflegeEintragEntw?rf(this.b.LogggedOnUser(db).ID, db);
                    if (tPflegeEintragEntwurf.Count() > 0)
                    {
                        iDekursEntw?rfeOffen = tPflegeEintragEntwurf.Count();
                        if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es sind noch Dekursentw?rfe offen!" + "\r\n" +
                                                                                        "Wollen Sie PMDS trotzdem beenden?", "Hinweis", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            bEndPMDS = true;
                            return;
                        }
                        else
                        {
                            if (ucTermineEx.frmDekurseListeDistinct == null)
                            {
                                ucTermineEx.frmDekurseListeDistinct = new GUI.GUI.Main.frmDekurseListe();
                                ucTermineEx.frmDekurseListeDistinct.initControl(GUI.GUI.Main.ucDekurseListe.eTypeUI.All, null);
                            }
                            ucTermineEx.frmDekurseListeDistinct.ucDekurseListe1.loadData();
                            ucTermineEx.frmDekurseListeDistinct.TopMost = true;
                            ucTermineEx.frmDekurseListeDistinct.Show();
                            ucTermineEx.frmDekurseListeDistinct.Visible = true;
                            ucTermineEx.frmDekurseListeDistinct.TopMost = false;

                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "frmMain2.checkListeDekursEntw?rfe"))
                {
                    this.checkListeDekursEntw?rfe(ref iDekursEntw?rfeOffen, ref bEndPMDS, true, IDTime);
                }
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Auswahl der Hauptbar verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        private void MainBar_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            // Die reingeh?ngten Men?s sind im Tag des Objektes verspeichert. 
            // Hier ist auch der delegate hinterlegt (_Click)
            if (e.Item.Tag is PMDSMenuEntry)
            {
                PMDSMenuEntry m = (PMDSMenuEntry)e.Item.Tag;
                if (m.Click != null)
                    m.Click(m);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Tasten weiterleiten
        /// </summary>
        //----------------------------------------------------------------------------
        private void frmMainModern_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (_topGUI != null)
                    _topGUI.ProcessKeyEvent(e);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Statuszeile aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshStatusBar()
        {
            // Panels ermitteln
            UltraStatusPanel panelUser = ultraStatusBar1.Panels["User"];
            UltraStatusPanel panelAbt = ultraStatusBar1.Panels["Abteilung"];

            // datenbank anzeigen
            panelUser.Text = ENV.String("GUI.STATUS_USER", new BusinessLogic.Benutzer(ENV.USERID).FullName);
            panelAbt.Text = ENV.String("GUI.STATUS_ABT", GuiUtil.Abteilung());
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuer Benutzer angemeldet, StatusInfo aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            RefreshStatusBar();
            ShowHideMenus();
            RefreshNotfallMenues();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Sp Men?s generieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshNotfallMenues()
        {
            try
            {
                PopupMenuTool npm = (PopupMenuTool)ultraToolbarsManager1.Tools["NotfallprozedurenListe"];
                PopupMenuTool spm = (PopupMenuTool)ultraToolbarsManager1.Tools["StandardprozedurenListe"];

                List<ToolBase> al = new List<ToolBase>();
                foreach (ToolBase b in npm.Tools)
                    al.Add(b);

                foreach (ToolBase b in spm.Tools)
                    al.Add(b);

                foreach (ToolBase b in al)
                    ultraToolbarsManager1.Tools.Remove(b);

                npm.Tools.Clear();
                spm.Tools.Clear();

                BusinessLogic.StandardProzeduren sp = new BusinessLogic.StandardProzeduren();
                sp.Read();
                if (sp.ALL.StandardProzeduren.Count == 0)
                    return;

                foreach (dsStandardProzeduren.StandardProzedurenRow r in sp.ALL.StandardProzeduren)
                {
                    if (!r.Unterdr?cken)
                    {
                        ButtonTool b = new ButtonTool(r.ID.ToString());
                        b.SharedProps.Caption = r.Name;
                        ToolBase[] atb = new ToolBase[] { b };
                        ultraToolbarsManager1.Tools.Add(b);
                        if (r.NotfallJN)
                            npm.Tools.AddRange(atb);
                        else
                            spm.Tools.AddRange(atb);
                    }
                }

                npm.SharedProps.Visible = npm.Tools.Count > 0;
                spm.SharedProps.Visible = spm.Tools.Count > 0;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Men?s je nach Rechte anzeigen / verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowHideMenus()
        {
            GuiWorkflow.mainWindow = this;

            // Hauptmen?s ein/ausblenden
            ultraToolbarsManager1.Tools["Drucken"].SharedProps.Visible = ENV.HasRight(UserRights.DruckenInterneBerichte);

            // Untermen?s
            ultraToolbarsManager1.Tools["Aufnahme"].SharedProps.Visible = ENV.HasRight(UserRights.Aufnahme);
            ultraToolbarsManager1.Tools["Entlassen"].SharedProps.Visible = ENV.HasRight(UserRights.Entlassung);
            ultraToolbarsManager1.Tools["Versetzen"].SharedProps.Visible = ENV.HasRight(UserRights.Versetzung);
            ultraToolbarsManager1.Tools["Bereichsversetzung"].SharedProps.Visible = ENV.HasRight(UserRights.Versetzung);
            ultraToolbarsManager1.Tools["Abrechnung"].SharedProps.Visible = false;          // Settings.HasRight(UserRights.AbrechnungStarten);
            ultraToolbarsManager1.Tools["ImportGibodat"].SharedProps.Visible = ENV.HasRight(UserRights.ImportGibodat);
            ultraToolbarsManager1.Tools["btnSTAMP"].SharedProps.Visible = ENV.HasRight(UserRights.STAMPMeldung);
            ultraToolbarsManager1.Tools["RezepteVerwalten"].SharedProps.Visible = ENV.HasRight(UserRights.RezepteVerwalten);
            ultraToolbarsManager1.Tools["Historie"].SharedProps.Visible = ENV.HasRight(UserRights.Historie);
            ultraToolbarsManager1.Tools["Bemerkung"].SharedProps.Visible = ENV.HasRight(UserRights.Rueckmelden);
            ultraToolbarsManager1.Tools["Urlaub"].SharedProps.Visible = ENV.HasRight(UserRights.Urlaube);
            ultraToolbarsManager1.Tools["Bezugsperson"].SharedProps.Visible = ENV.HasRight(UserRights.BezugspersonAendern);
            ultraToolbarsManager1.Tools["Barcodeverarbeitung"].SharedProps.Visible = false; // Settings.HasRight(UserRights.BarcodeVerarbeitung); ;
            ultraToolbarsManager1.Tools["DatenarchivierungKlient"].SharedProps.Visible = (ENV.HasRight(UserRights.Historie) && (ENV.ArchivPath != "")) || ENV.adminSecure;
            ultraToolbarsManager1.Tools["DatenarchivierungAlle"].SharedProps.Visible = (ENV.HasRight(UserRights.Historie) && (ENV.ArchivPath != "")) || ENV.adminSecure;
            ultraToolbarsManager1.Tools["btnTransferCalcData"].SharedProps.Visible = ENV.HasRight(UserRights.Abrechnungen?berspielen) || ENV.adminSecure;
            ultraToolbarsManager1.Tools["btnExportCalculations"].SharedProps.Visible = ENV.HasRight(UserRights.AbrechnungenExportieren) || ENV.adminSecure;

            //Men? Verwaltung
            bool AnyMen?ItemVerwaltung = false;
            this.setRights(ref AnyMen?ItemVerwaltung);
            ultraToolbarsManager1.Tools["Verwaltung"].SharedProps.Visible = AnyMen?ItemVerwaltung;

            //Men? Grundaten
            ultraToolbarsManager1.Tools["Grunddaten"].SharedProps.Visible = ENV.HasRight(UserRights.Stammdatenverwaltung);
            
            //Men?-Item Stammdaten
            this.setRightsStammdaten(out bool AnyMen?ItemStammdaten, out bool AllMen?ItemsStammdaten, out cRightsStammdaten RightsStammaten);
            ultraToolbarsManager1.Tools["mnuStammdaten"].SharedProps.Visible = AnyMen?ItemStammdaten || AllMen?ItemsStammdaten || ENV.HasRight(UserRights.Men?Stammdaten);
            ultraToolbarsManager1.Tools["KlinikVerwaltung"].SharedProps.Visible = RightsStammaten.Einrichtung || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["BenutzerVerwaltung"].SharedProps.Visible = RightsStammaten.Benutzer;
            ultraToolbarsManager1.Tools["Gruppenrechte"].SharedProps.Visible = RightsStammaten.Gruppenrechte;
            ultraToolbarsManager1.Tools["btnVerwaltungKlinikenUser"].SharedProps.Visible = RightsStammaten.VerwaltungEinrichtungUndBenutzer;
            ultraToolbarsManager1.Tools["btnVerwaltungFortbildungen"].SharedProps.Visible = RightsStammaten.VerwaltungFortbildungen;
            ultraToolbarsManager1.Tools["Auswahllisten"].SharedProps.Visible = RightsStammaten.Auswahllisten || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["Zusatzeintraege"].SharedProps.Visible = RightsStammaten.Zusatzeintr?ge || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnTextbausteine"].SharedProps.Visible = RightsStammaten.Textbausteine || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnManageDocuments"].SharedProps.Visible = RightsStammaten.Dokumentenverwaltung || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["EinrichtungenVerwaltung"].SharedProps.Visible = RightsStammaten.ExterneEinrichtungen || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["Standardprozeduren"].SharedProps.Visible = RightsStammaten.Standardprozeduren || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["Formulare"].SharedProps.Visible = RightsStammaten.Assessments || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["MedikamenteVerwalten"].SharedProps.Visible = RightsStammaten.Medikamente || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["LinkDokumenteVerwaltung"].SharedProps.Visible = RightsStammaten.Pflegerichtlinien || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btn?rzteverwaltung"].SharedProps.Visible = RightsStammaten.?rzteverwaltung || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnArztabrechnung"].SharedProps.Visible = RightsStammaten.Arztabrechnung || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btn?rzteMergen"].SharedProps.Visible = RightsStammaten.?rzteZusammenf?hren || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnImportBefunde"].SharedProps.Visible = RightsStammaten.Befundimport || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["QuickFilter"].SharedProps.Visible = RightsStammaten.Quickfilter || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnLayoutManager"].SharedProps.Visible = RightsStammaten.LayoutManager || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["MedizinischetypenVerwaltung"].SharedProps.Visible = RightsStammaten.MedizinischeTypen || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["Medizinische_Dialoge"].SharedProps.Visible = RightsStammaten.MedizinscheDialoge || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnWundBilderScale"].SharedProps.Visible = RightsStammaten.WundbilderSkalieren || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2ManageQueries"].SharedProps.Visible = RightsStammaten.QS2AbfragebVerwaltenAdmin || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2Ressourcen"].SharedProps.Visible = RightsStammaten.QS2Ressourcen || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2InformationFieldsSqlServer"].SharedProps.Visible = RightsStammaten.QS2InformationenFelderSQLServer || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2Criterias"].SharedProps.Visible = RightsStammaten.QS2Kriterien || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2SelLists"].SharedProps.Visible = RightsStammaten.QS2Auswahllisten || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["ArchivStammdaten"].SharedProps.Visible = RightsStammaten.Archiveinstellungen || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnUserAccounts"].SharedProps.Visible = RightsStammaten.EMailKonten || AllMen?ItemsStammdaten;
            ultraToolbarsManager1.Tools["btnQS2LogManager"].SharedProps.Visible = RightsStammaten.LogManager;
        }

        private void ucQuickNavigator1_SiteMapEvent(PMDS.Global.SiteEvents e, ref bool used)
		{
			switch(e)
			{
				// Arbeitsstation sperren
				case SiteEvents.Lock:
					frmLoginLocked.ProcessLocked();
					break;

				// neu anloggen
				case SiteEvents.LogOn:
					frmLogin.ProcessLogin();
					break;

				// Passwort ?ndern
				case SiteEvents.Password:
					GuiAction.ChangePassword(false, true);
					break;

				case SiteEvents.About:
					new frmAbout().Show();
					break;

				// Programm beenden
				case SiteEvents.End:
					Form.ActiveForm.Close();
					break;

                case SiteEvents.TextVerschluesseln:
                    break;

				// Weiterleiten
				default:
					GuiAction.ActionFromEvent(e);
					break;
			}
		}

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool bUsed = false;
                switch (e.Tool.Key)
                {
                    case "Programm":
                        break;

                    case "Formulare":
                        PMDS.GUI.GUI.Main.frmFormularManager frmFormularManager1 = new GUI.GUI.Main.frmFormularManager();
                        frmFormularManager1.initControl();
                        frmFormularManager1.Show();
                        break;

                    case "Beenden":
                        ucQuickNavigator1_SiteMapEvent(SiteEvents.End, ref bUsed);
                        break;

                    case "btn?rzteverwaltung":
                        System.Collections.Generic.List<PMDS.DB.PMDSBusiness.c?rzteMehrfachauswahl> lst?rzteMehrfachauswahl = new List<PMDS.DB.PMDSBusiness.c?rzteMehrfachauswahl>();
                        using (frmAerzteEdit frmAerzteEdit1 = new frmAerzteEdit())
                        {
                            BusinessLogic.Aerzte aerzte = new BusinessLogic.Aerzte();
                            aerzte.Read();
                            frmAerzteEdit1.CLASS_AERZTE = aerzte;
                            frmAerzteEdit1.btnKlientenMehrfachauswahl.Visible = true;
                            DialogResult res = frmAerzteEdit1.ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                KlientGuiAction KlientGuiAction1 = new KlientGuiAction();
                                KlientGuiAction1.doUIDienst?bergabe(frmAerzteEdit1.lstPatienteSelected2, ref lst?rzteMehrfachauswahl, frmAerzteEdit1.CurrentArztRow.ID, null, null);
                                KlientGuiAction1.checkWrite?rzteMehrfachauswahl(ref lst?rzteMehrfachauswahl, null);
                            }
                        }
                        break;
                        
                    case "btnVerordnungen":
                        this.frmVOMain1 = new GUI.Verordnungen.frmVOMain();
                        frmVOMain1.initControl(!this._KlientenlisteOnTop);
                        this.frmVOMain1.TopMost = true;
                        this.frmVOMain1.Show();
                        this.frmVOMain1.Visible = true;
                        this.frmVOMain1.TopMost = false;
                        break;

                    case "btnVerordnungen2":
                        this.frmVOMain2 = new GUI.Verordnungen.frmVOMain();
                        frmVOMain2.initControl(!this._KlientenlisteOnTop);
                        this.frmVOMain2.TopMost = true;
                        this.frmVOMain2.Show();
                        this.frmVOMain2.Visible = true;
                        this.frmVOMain2.TopMost = false;
                        break;

                    case "btnPatientAufenthalteL?schen":
                        using (PMDS.GUI.Klient.frmPatientDelete frmPatientDelete1 = new GUI.Klient.frmPatientDelete())
                        {
                            frmPatientDelete1.initControl(ENV.CurrentIDPatient);
                            frmPatientDelete1.ShowDialog(this);
                            if (!frmPatientDelete1.contPatientDelete1.abort)
                            {
                                PMDS.GUI.GuiAction.refreshGridPatientenStart();
                            }
                        }
                        break;
                        
                    case "Arbeitsstationsperren":
                        this.Visible = false;
                        frmLock frmLock1 = new frmLock();
                        frmLock1.ShowDialog(this);
                        if (frmLock1.TimeOutElapsed && !frmLock1.PasswordOk)
                        {                            
                            this.CloseAnyway = true;
                            this.Close();
                        }
                        else
                            this.Visible = true;
                        frmLock1.Dispose();
                        break;

                    case "btnELGAPasswort?ndern":
                        GuiAction.ChangePassword(true, true);
                        break;

                    case "Benutzerwechsel":
                        PMDS.Global.UIGlobal.NewLogIn("pmds", true);
                        break;
                    
                    case "Passwort":
                        ucQuickNavigator1_SiteMapEvent(SiteEvents.Password, ref bUsed);
                        break;
                    
                    case "btnTransferCalcData":
                        PMDS.Calc.UI.Admin.frmWorkCalcDb frmCopyCalcDb1 = new PMDS.Calc.UI.Admin.frmWorkCalcDb();
                        frmCopyCalcDb1.typUI = PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb;
                        frmCopyCalcDb1.initControl();
                        frmCopyCalcDb1.ShowDialog();
                        break;
                    
                    case "btnExportCalculations":
                        PMDS.Calc.UI.Admin.frmWorkCalcDb frmCopyCalcDb2 = new PMDS.Calc.UI.Admin.frmWorkCalcDb();
                        frmCopyCalcDb2.typUI = PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs;
                        frmCopyCalcDb2.initControl();
                        frmCopyCalcDb2.Show();
                        break;

                    case "About":
                        ucQuickNavigator1_SiteMapEvent(SiteEvents.About, ref bUsed);
                        break;

                    case "Klientenliste":
                        GuiWorkflow.ShowKlienten();
                        break;

                    case "Verwaltung":
                        break;
                    case "Medizinische_Dialoge":       
                        GuiAction.MedizinischeDialoge();
                        break;
                    case "Standardprozeduren":        
                        GuiAction.Standardprozeduren();
                        break;
                    case "Bewerber":        
                        GuiAction.Bewerberverwaltung();
                        break;

                    case "ArchivStammdaten":
                        PMDS.GUI.VB.frmStammdaten frm2 = new PMDS.GUI.VB.frmStammdaten();
                        frm2.ShowDialog(this);
                        break;

                    case "btnUserAccounts":
                        PMDS.GUI.VB.frmUserAccounts frm = new GUI.VB.frmUserAccounts();
                        frm.initControl();
                        frm.Show();
                        break;

                    case "Texteditor":
                        QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                        frmEditor.Show();
                        break;

                    case "HistorieKlient":
                        GuiAction.PatientAufenthaltInfo(ENV.CurrentIDPatient );
                        break;

                    case "btnVerwaltungKlinikenUser":
                        PMDS.GUI.Klient.frmVerwaltungKlinikenUser frmVerwaltungKlinikenUser1 = new GUI.Klient.frmVerwaltungKlinikenUser();
                        frmVerwaltungKlinikenUser1.initControl();
                        if (PMDS.Global.ENV.adminSecure)
                        {
                            frmVerwaltungKlinikenUser1.Show();
                        }
                        else
                        {
                            frmVerwaltungKlinikenUser1.ShowDialog(this);
                        }
                        break;
                        
                    case "DatenarchivierungAlle":
                        frmDatenExport frmExportAll = new frmDatenExport();
                        frmExportAll.Init(Guid.Empty, PMDS.Global.ENV.IDKlinik, ENV.eKlientenberichtTyp.full, ENV.eDatenexportTyp.alle);
                        frmExportAll.Show();
                        break;

                    case "Blackout-Pr?vention":
                        frmDatenExport frmExportBP = new frmDatenExport();
                        frmExportBP.Init(Guid.Empty, PMDS.Global.ENV.IDKlinik, ENV.eKlientenberichtTyp.blackoutprevention, ENV.eDatenexportTyp.aktiv);
                        frmExportBP.Show();
                        break;

                    case "DatenarchivierungKlient":
                        frmDatenExport frmExportKlient = new frmDatenExport();
                        frmExportKlient.Init(ENV.CurrentIDPatient, PMDS.Global.ENV.IDKlinik, ENV.eKlientenberichtTyp.full, ENV.eDatenexportTyp.alle);
                        frmExportKlient.Show();
                        break;
                    
                    case "ImportGibodat":
                        PMDS.GUI.VB.frmImportGibodat frmImportGibodat1 = new PMDS.GUI.VB.frmImportGibodat();
                        frmImportGibodat1.ShowDialog(this);
                        break;

                    case "btnTextbausteine":
                        PMDS.GUI.GUI.Main.frmTextbausteine frmTextbausteine1 = new GUI.GUI.Main.frmTextbausteine();
                        frmTextbausteine1.initControl();
                        frmTextbausteine1.ShowDialog(this);
                        break;
                    
                    case "btnManageDocuments":
                        PMDS.GUI.GUI.Main.frmManageDocuments frmManageDocuments1 = new GUI.GUI.Main.frmManageDocuments();
                        frmManageDocuments1.initControl();
                        frmManageDocuments1.ShowDialog(this);
                        break;

                    case "btnArztabrechnung": 
                        PMDS.GUI.Arztabrechnung.frmArztabrechnungManage frmArztabrechnungManage1 = new GUI.Arztabrechnung.frmArztabrechnungManage();
                        frmArztabrechnungManage1.initControl();
                        frmArztabrechnungManage1.Show();
                        break;

                    case "btnVerwaltungFortbildungen":
                        PMDS.GUI.Fortbildung.frmVerwaltungFortbildungen frmVerwaltungFortbildungen1 = new GUI.Fortbildung.frmVerwaltungFortbildungen();
                        frmVerwaltungFortbildungen1.initControl();
                        frmVerwaltungFortbildungen1.Show();

                        break;
                    case "btn?rzteMergen":
                        PMDS.GUI.GUI.Main.frm?rzteMergen frm?rzteMergen1 = new GUI.GUI.Main.frm?rzteMergen();
                        frm?rzteMergen1.initControl();
                        frm?rzteMergen1.Show();
                        break;

                    case "btnWundBilderScale":
                        PMDS.GUI.BaseControls.frmWundBilderScale frmWundBilderScale1 = new PMDS.GUI.BaseControls.frmWundBilderScale();
                        frmWundBilderScale1.initControl();
                        frmWundBilderScale1.Show();
                        break;

                    case "btnQS2Queries":
                        frmQS2 frmQS2Queries = new frmQS2();
                        frmQS2Queries.UnvisibleOnClose = true;
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.contQuerysRun, frmQS2Queries.panelControl, frmQS2Queries, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2Reports":
                        frmQS2 frmQS21Reports = new frmQS2();
                        frmQS21Reports.UnvisibleOnClose = true;
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.contReportsRun, frmQS21Reports.panelControl, frmQS21Reports, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2ManageQueriesUser":
                        frmQS2 frmQS2QueriesUser = new frmQS2();
                        frmQS2QueriesUser.UnvisibleOnClose = true;
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.contQuerysUser, frmQS2QueriesUser.panelControl, frmQS2QueriesUser, PMDS.Global.ENV.adminSecure);
                        break;  

                    case "btnQS2ManageQueries":
                        frmQS2 frmQS2ManageQueriesUser = new frmQS2();
                        frmQS2ManageQueriesUser.UnvisibleOnClose = true;
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerQuerysAdmin, frmQS2ManageQueriesUser.panelControl, frmQS2ManageQueriesUser, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2Ressourcen":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerRessourcen, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2SelLists":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerSelLists, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnLayoutManager":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerLayouts, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2Criterias":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "xy":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnQS2InformationFieldsSqlServer":
                        qs2.ui.OpenWindow.doControl(qs2.core.ENV.eTypApp.QS2PopUpContainerSysDatabase, null, null, PMDS.Global.ENV.adminSecure);
                        break;

                    case "btnRechteAbteilungenBereiche":
                        using (frmBenutzer frmBenutzer1 = new frmBenutzer(true))
                        {
                            frmBenutzer1.ShowDialog(this);
                            break;
                        }

                    case "btnImportBefunde":
                        PMDS.Global.UI.Befunde.frmImportBefunde frmImportBefunde1 = new Global.UI.Befunde.frmImportBefunde();
                        frmImportBefunde1.initControl();
                        frmImportBefunde1.Show();
                        break;

                    case "btnSuchtgiftschrankSchl?ssel":
                        using (PMDS.GUI.GUI.Main.frmSuchtgiftschrankSchl?ssel frmSuchtgiftschrankSchl?ssel1 = new GUI.GUI.Main.frmSuchtgiftschrankSchl?ssel())
                        {
                            frmSuchtgiftschrankSchl?ssel1.initControl();
                            frmSuchtgiftschrankSchl?ssel1.ShowDialog(this);
                            break;
                        }

                    case "btnAbrechnungInkoProdukte":
                        using (PMDS.GUI.ELDA.frmELDA frmELDA = new PMDS.GUI.ELDA.frmELDA())
                        {
                            frmELDA.ShowDialog(this);
                            break;
                        }

                    case "btnSTAMP":
                            PMDS.GUI.STAMP.frmSTAMPMeldung frmSTAMPMeldung = new PMDS.GUI.STAMP.frmSTAMPMeldung();
                            frmSTAMPMeldung.Show(this);
                            break;

                    case "btnHeimvertr?ge":
                        break;

                    case "btnSearchMedikamente":
                        PMDS.GUI.Medikament.frmMedikamenteSuche frmMedikamenteSuche1 = new GUI.Medikament.frmMedikamenteSuche();
                        frmMedikamenteSuche1.initControl();
                        frmMedikamenteSuche1.Show();
                        break;

                    case "btnPSE":
                        using (PMDS.GUI.PflegestufenEinschaetzung.frmPflegestufenEinschaetzung frmPSE = new PMDS.GUI.PflegestufenEinschaetzung.frmPflegestufenEinschaetzung())
                        {
                            frmPSE.ShowDialog(this);
                            break;
                        }

                    default:
                        // pr?fen auf Notfall
                        if (e.Tool.OwningMenu != null)
                        {
                            switch (e.Tool.OwningMenu.Key)
                            {
                                case "NotfallprozedurenListe":
                                case "StandardprozedurenListe":
                                    GuiAction.Notfall(new Guid(e.Tool.Key), ENV.IDAUFENTHALT, BearbeitungsModus.neu);
                                    return;
                            }
                        }

                        SiteEventArgs args = new SiteEventArgs();
                        args.IDPatient = ENV.CurrentIDPatient;
                        args.IDAufenthalt = BusinessLogic.Aufenthalt.LastByPatient(ENV.CurrentIDPatient);

                        GuiAction.ActionFromEvent((SiteEvents)Enum.Parse(typeof(SiteEvents), e.Tool.Key, true), args, null, null);
                        break;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmMainModern_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void showInfoStatusBar(bool infoLoad, string txt, bool ein)
        {
            try
            {
                if (this.ultraStatusBar1.Panels[3].Text != null && !this.ultraStatusBar1.Panels[3].Disposed)
                {
                    if (ein)
                    {
                        if (infoLoad)
                        {
                            this.ultraStatusBar1.Panels[3].Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Daten werden geladen ...");
                        }
                        else
                        {
                            this.ultraStatusBar1.Panels[3].Text = txt;
                        }
                    }
                    else
                    {
                        if (infoLoad)
                        {
                            this.ultraStatusBar1.Panels[3].Text = "";
                        }
                        else
                        {
                            this.ultraStatusBar1.Panels[3].Text = "";
                        }
                    }
                }
                this.ultraStatusBar1.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("frmMainQS2.ShowInfoStatusBar: " + ex.ToString());
            }
        }

        private void ultraStatusBar1_ButtonClick(object sender, PanelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.UISitemap.doRuntimStatusbar(e.Panel.Key);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MyLayout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            try
            {
                if (this.prevWindowState == FormWindowState.Minimized && this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Normal;
                }
                this.prevWindowState = this.WindowState;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void timerControlManager_Tick(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmMainModern_Resize_1(object sender, EventArgs e)
        {
            try
            {
                if (PMDS.GUI.GuiWorkflow._guiworkflow != null)
                {
                    PMDS.GUI.GuiWorkflow._guiworkflow.setWidthHeigtSiteMapStart(this.panelStart.Width, this.panelStart.Height);
                }

                if (this.Visible)
                {
                    ENV.fMainWindowResized(this.Size);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmMainModern_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //Settings.fMainWindowResized(this.Size);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmMainModern_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    ENV.fMainWindowResized(this.Size);
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void panelStart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void styleAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.appStylistRuntime1.ShowRuntimeApplicationStylingEditor(this, "AppStylist Run-time");

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void timerCheckConnectionAndNetwork_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible && frmMain.newVersionAvailable)
                {
                    this.timerCheckConnectionAndNetwork.Enabled = false;
                    this.timerCheckConnectionAndNetwork.Stop();

                    frmMain.newVersionAvailable = false;

                    PMDS.GUI.GUI.Main.frmInfoNewVersion frmInfoNewVersion1 = new GUI.GUI.Main.frmInfoNewVersion();
                    frmInfoNewVersion1.TopMost = true;
                    frmInfoNewVersion1.Show();
                    frmInfoNewVersion1.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void th_checkNewVersion()
        {
            try
            {
                if (ENV.StartFromShare.Trim() == "0")
                {
                    var dirInfo = new  DirectoryInfo(PMDS.Global.ENV.path_bin);
                    var binDir = dirInfo.Name;
                    var pathVersionRunning = dirInfo.Parent.Name;
                    System.Collections.Generic.List<string> lstDatabasesActDeact = new List<string>();
                    var sActualVersion = PMDS.Global.Other.cConfig.readConfig(ENV.ConfigFileLauncher, "ActualVersion", false, ref lstDatabasesActDeact);
                    var sUpdateVersion = PMDS.Global.Other.cConfig.readConfig(ENV.ConfigFileLauncher, "UpdateVersion", false, ref lstDatabasesActDeact);
                    if (sUpdateVersion.Trim() != "")
                    {
                        sActualVersion = sUpdateVersion;
                    }

                    if (!binDir.sEquals("debug") && !pathVersionRunning.sEquals(sActualVersion))
                    {
                        qs2.core.generic.WaitMilli(8000);
                        frmMain.newVersionAvailable = true;
                    }
                    else
                    {
                        this.timerCheckConnectionAndNetwork.Enabled = false;
                        this.timerCheckConnectionAndNetwork.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void TextException3()
        {
            try
            {
                AppException.throwException("TextException3: " + "Test own Exception!!", 1005);

            }
            catch (Exception ex)
            {
                AppException.throwException(ex, "TextException3: ", 2, "");
            }
        }
        public void TextException2()
        {
            try
            {
                this.TextException3();
            }
            catch (Exception ex)
            {
                AppException.throwException(ex, "", 3, "");
            }
        }

        private void ultraStatusBar2_ButtonClick(object sender, PanelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Panel.Key == "Config")
                {
                    this.UISitemap.doRuntimStatusbar(e.Panel.Key);
                }
                else if (e.Panel.Key == "UnreadedMessages")
                {
                    PMDS.GUI.GuiWorkflow._guiworkflow._SitemapStart.openMessenger();
                }
                else if (e.Panel.Key == "statELGA")
                {
                    bElga.handleLogIn(this.ultraStatusBar1, true, false);
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void TimerELGA_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    if (!WCFServiceClient.IsInitialized)
                    {
                        return;
                    }

                    if (ELGABusiness.ELGALogInInitializedAtStart == null || !ELGABusiness.ELGALogInInitializedAtStart.Value)
                    {
                        this.timerELGA.Stop();
                        this.timerELGA.Interval = 5 * 1000;      //300 * 1000;
                        this.bElga.setStatusbarOnOff(this.ultraStatusBar1, true);
                        bElga.handleLogIn(this.ultraStatusBar1, false, false);
                        ELGABusiness.ELGALogInInitializedAtStart = true;
                        this.timerELGA.Start();
                    }
                    else
                    {
                        if (ELGABusiness.ELGALogInInitializedAtStart.Value)
                        {
                            if (ELGABusiness.ELGAStatusbarStatus != null && ELGABusiness.ELGAStatusbarStatus.SessionStopped)
                            {
                                this.timerELGA.Enabled = false;
                                this.timerELGA.Stop();
                            }
                            this.bElga.handleLogIn(this.ultraStatusBar1, false, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}
