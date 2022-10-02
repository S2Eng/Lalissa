using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.GUI.Calc.Calc.UI.Other;

namespace PMDS.Calc.UI.Admin
{

    public partial class frmMainCalc : QS2.Desktop.ControlManagment.baseForm 
    {

        PMDS.UI.Sitemap.UIFct sitemap;
        PMDS.Calc.Logic.Sql sql = new PMDS.Calc.Logic.Sql();
        public bool nurDepot = false;
        public System.Windows.Forms.FormWindowState prevWindowState = System.Windows.Forms.FormWindowState.Normal;

        //public QS2.Desktop.ControlManagment.ControlWorker ControlWorker = new QS2.Desktop.ControlManagment.ControlWorker();
        //public QS2.Desktop.ControlManagment.ControlManagment ControlManagment = new QS2.Desktop.ControlManagment.ControlManagment();

        public static TXTextControl.TextControl editorTmp = null;






        public frmMainCalc()
        {
            InitializeComponent();
        }

        public void initControl( bool nurDepot)
        {
            try
            {
                this.sitemap = new PMDS.UI.Sitemap.UIFct();
                frmMainCalc.editorTmp = this.textControl1;

                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
                ControlManagment1.autoTranslateToolbars(this.ultraToolbarsManager1, null, this);

                this.ultraToolbarsManager1.Tools["btnDoAbw"].SharedProps.Visible = (!nurDepot || ENV.adminSecure);
                //this.ultraToolbarsManager1.Tools["buttJahrAbBuch"].SharedProps.Visible = (nurDepot || ENV.adminSecure);
                //this.ultraToolbarsManager1.Tools["popUpAmdmin"].SharedProps.Visible = PMDS.Global.ENV.adminSecure;
                this.ultraToolbarsManager1.Tools["popVorTxtControl"].SharedProps.Visible = PMDS.Global.ENV.adminSecure;
                this.ultraStatusBar1.Panels["Laden"].Visible = PMDS.Global.ENV.adminSecure;
                this.ultraStatusBar1.Panels["Config"].Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Text;

                this.ultraToolbarsManager1.Tools["buttJahrAbBuch"].SharedProps.Visible = (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.AbrechnungErweiterteFunktionen) || ENV.adminSecure);
                this.ultraToolbarsManager1.Tools["popUpAmdmin"].SharedProps.Visible = (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.AbrechnungErweiterteFunktionen) || ENV.adminSecure);
                this.ultraToolbarsManager1.Tools["btnRechNrManage"].SharedProps.Visible = (PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.AbrechnungErweiterteFunktionen) || ENV.adminSecure);
                
                ultraToolbarsManager1.Tools["btnTransferCalcData"].SharedProps.Visible = (ENV.HasRight(UserRights.Abrechnungen‹berspielen) || ENV.adminSecure);
                ultraToolbarsManager1.Tools["btnExportCalculations"].SharedProps.Visible = (ENV.HasRight(UserRights.AbrechnungenExportieren) || ENV.adminSecure);
                ultraToolbarsManager1.Tools["btnControlDesigner"].SharedProps.Visible = ENV.adminSecure;
                
                this.ucStartseite21.initControl(nurDepot);
                PMDS.UI.Sitemap.UIFct Sitemap = new PMDS.UI.Sitemap.UIFct();

                Sitemap.setStatusbar(ref this.ultraStatusBar1, true );
                Sitemap.infoRuntimStatusbar(ref this.ultraStatusBar1);

            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
        }

        private void frmAbrechnung_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if (ucStartseite21.CURRENTOBJECT is ISave)
                //{
                //    ISave c = (ISave)ucStartseite21.CURRENTOBJECT;

                //    if (c.IsChanged)
                //    {
                //        DialogResult res = ENV.AskForSave();

                //        if (res == DialogResult.Cancel)
                //        {
                //            e.Cancel = true;
                //        }
                //        else if (res == DialogResult.Yes)
                //        {
                //            e.Cancel = !c.Save();
                //        }

                //    }

                //    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Abrechnungssystem wirklich beenden?", "PMDS Abrechnung", MessageBoxButtons.YesNo) != DialogResult.Yes)
                //    {
                //        e.Cancel = true;
                //    }
                //}

                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Abrechnungssystem wirklich beenden?", "PMDS Abrechnung", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                    PMDSBusiness1.checkEndAnonymLogIn();
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmAbrechnung_Load(object sender, EventArgs e)
        {
            try
            {

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

                //Minimumsize abh‰ngig von der Taskbar-Position festlegen
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
                    string sMsgBoxTranslate = "Die verf¸gbare Arbeitsfl‰che Ihres Bildschirms ({0} * {1}" +
                                            ") ist kleiner als die empfohlene Mindestauflˆsung (1200 * 737)\n\r" +
                                            "Bei einigen Funktionen wird die Anzeige nicht vollst‰ndig sein.";
                    sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, UsableScreen.Width.ToString(), UsableScreen.Height.ToString());
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Wichtiger Hinweis zur Anzeige Ihres Ger‰tes!");
                }


                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                PMDS.Global.UIGlobal.mainWindowLeft = this.Left;
                PMDS.Global.UIGlobal.mainWindowTop = this.Top;
                PMDS.Global.UIGlobal.mainWindowWidth = this.Width;

                this.initControl(this.nurDepot);
            }
            catch (Exception theException)
            {
                PMDS.Global.UIGlobal.infoStart.Close();
                PMDS.Global.ENV.HandleException(theException); 
            }
            finally
            {
                PMDS.Global.UIGlobal.infoStart.Close();
            }
        }

        private void frmAbrechnung_Resize(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmAbrechnung_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                PMDS.Global.UIGlobal.mainWindowLeft = this.Left;
                PMDS.Global.UIGlobal.mainWindowTop = this.Top;
                PMDS.Global.UIGlobal.mainWindowWidth = this.Width;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmAbrechnung_MaximumSizeChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmAbrechnung_MinimumSizeChanged(object sender, EventArgs e)
        {
        }

        private void frmAbrechnung_ClientSizeChanged(object sender, EventArgs e)
        {
            try
            {
                PMDS.Global.UIGlobal.mainWindowLeft = this.Left;
                PMDS.Global.UIGlobal.mainWindowTop = this.Top;
                PMDS.Global.UIGlobal.mainWindowWidth = this.Width;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                switch (e.Tool.Key)
                {
                    case "bBeenden":
                        this.Close();
                        break;

                    case "bAbout":
                        frmAbout frm = new frmAbout();
                        frm.Show();
                        Application.DoEvents();
                        break;

                    case "bEditor":
                        QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                        frmEditor.Show();
                        break;

                    case "btnDoAbw":
                        frmAbw‹bersp frmGetAbw = new frmAbw‹bersp();
                        frmGetAbw.Show();
                        break;

                    case "btnTransferCalcData":
                        using (frmWorkCalcDb frmCopyCalcDb1 = new frmWorkCalcDb())
                        {
                            frmCopyCalcDb1.typUI = PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb;
                            frmCopyCalcDb1.initControl();
                            frmCopyCalcDb1.ShowDialog();
                        }
                        break;

                    case "btnExportCalculations":       //BMD-Export
                        frmWorkCalcDb frmCopyCalcDb2 = new frmWorkCalcDb();
                        frmCopyCalcDb2.BMDExportTyp = (PMDS.Calc.Logic.workCalcDb.eBMDExportTyp)ENV.BMDExportTyp;
                        frmCopyCalcDb2.FSW_FiBuKonto = ENV.FSW_FiBuKonto;
                        frmCopyCalcDb2.typUI = PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs;
                        frmCopyCalcDb2.initControl();
                        frmCopyCalcDb2.Show();
                        break;

                    case "buttJahrAbBuch":
                        using (frmJahresAb frmAbDepot = new frmJahresAb())
                        {
                            frmAbDepot.typ = frmJahresAb.eTyp.booking;
                            frmAbDepot.ShowDialog(this);
                            if (frmAbDepot.apport)
                                return;
                            else
                                this.jahresAbBooking(frmAbDepot.dtBis.DateTime);
                        }
                        break;

                    case "buttJahrAbDepot":
                        using (frmJahresAb frmAbBooking = new frmJahresAb())
                        {
                            frmAbBooking.typ = frmJahresAb.eTyp.depot;
                            frmAbBooking.ShowDialog(this);
                            if (frmAbBooking.apport)
                                return;
                            else
                                this.jahresAbDepot(frmAbBooking.dtBis.DateTime, frmAbBooking.chkNurAbgerech.Checked);
                        }
                        break;

                    case "btnRechNrManage":
                        using (PMDS.GUI.Calc.Calc.UI.Main.frmManageRechNr frmManageRechNr1 = new GUI.Calc.Calc.UI.Main.frmManageRechNr())
                        {
                            frmManageRechNr1.initControl();
                            frmManageRechNr1.ShowDialog(this);
                        }
                        break;

                    case "admin_delDBAll":
                        if (this.sitemap.question2(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich die gesamte Abrechnungs- und Buchungsdatenbank lˆschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Admin"))) this.sql.admin_clearCalcDB();
                        break;                  

                    case "admin_delSRAll":
                        if (this.sitemap.question2(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Sammelabrechnungen lˆschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Admin"))) this.sql.admin_clearAllSR();
                        break;
                        
                    case "admin_delDepotAll":
                        if (this.sitemap.question2(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Depotgeldabrechnungen lˆschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Admin"))) this.sql.admin_clearAllDepot();
                        break;
                        
                    case "resetNumbersCalc":
                        if (this.sitemap.question2(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Rechnungsnummern lˆschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Admin"))) this.sql.admin_clearAllRechNr();
                        break;
                        

                    case "openRechnungRtf":
                        this.sitemap.openBillTemp(PMDS.Calc.Logic.bill.rechnungRTF, false);
                        break;

                    case "openDaylistRtf":
                        this.sitemap.openBillTemp(PMDS.Calc.Logic.daylist.daylistRTF, false);
                        break;

                    case "openBookingsRtf":
                        this.sitemap.openBillTemp(PMDS.Calc.Logic.booking.bookingRTF, false);
                        break;

                    case "openJahresAbRtf":
                        this.sitemap.openBillTemp(PMDS.Calc.Logic.doDepotgeld.jahresAbRTF, false);
                        break;

                    case "btnControlDesigner":
                        //PMDS.DB.Global.EntityQueries.businessFramework db = new DB.Global.EntityQueries.businessFramework();
                        ////this.ControlManagment.run(this, this.components, null,
                        ////                        QS2.Desktop.ControlManagment.ControlManagment.eTypeRessourcesRun.DesktopManagement.ToString(),
                        ////                        qs2.core.license.doLicense.eApp.PMDS.ToString(),
                        ////                        QS2.Desktop.ControlManagment.ControlManagment.eControlGroup.Booking,
                        ////                        qs2.core.Enums.eResourceType.ImageEnum);

                        QS2.Desktop.ControlManagment.ControlManagment.LoadControlDesigner("");
                        break;

                    case "btnListePatientenEntlassen":
                        frmListePatientenEntlassen frmListePatientenEntlassen1 = new frmListePatientenEntlassen();
                        frmListePatientenEntlassen1.initControl();
                        frmListePatientenEntlassen1.Show();
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


        private void jahresAbDepot(DateTime bis, bool nurAbgerech)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //System.Collections.Generic.List<string> lstKl = this.sitemap.loadAllKlientenProdHistLst(true);
                PMDS.Calc.Logic.doDepotgeld depot = new PMDS.Calc.Logic.doDepotgeld();
                depot.doJahresAb(bis, nurAbgerech, PMDS.Global.ENV.IDKlinik);
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
        private void jahresAbBooking(DateTime bis)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //System.Collections.Generic.List<string> lstKl = this.sitemap.loadAllKlientenProdHistLst(true);
                PMDS.Calc.Logic.booking booking = new PMDS.Calc.Logic.booking();
                booking.doJahresAb(bis, PMDS.Global.ENV.IDKlinik);
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

        private void ultraStatusBar1_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.sitemap.doRuntimStatusbar(e.Panel.Key);
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

        private void ultraStatusBar1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Layout(object sender, LayoutEventArgs e)
        {
            try
            {
                this.Refresh();
                Application.DoEvents();
                //this.ucStartseite21.ucKlient‹bersicht1.ucKlientenverwaltung3.ucRechnungenKlient1.RedrawConrol();
                //this.ucStartseite21.ucKlient‹bersicht1.ucKlientenverwaltung3.panelAbrechnungsdaten.Dock = DockStyle.None;
                //this.ucStartseite21.ucKlient‹bersicht1.ucKlientenverwaltung3.panelAbrechnungsdaten.Width = 1;
                //this.ucStartseite21.ucKlient‹bersicht1.ucKlientenverwaltung3.panelAbrechnungsdaten.Dock = DockStyle.Fill;


                //if (this.prevWindowState == FormWindowState.Minimized && this.WindowState == FormWindowState.Normal)
                //{
                //    //this.WindowState = FormWindowState.Maximized;
                //    //this.WindowState = FormWindowState.Normal;

                //    //                this.Width += 1;
                //    //                this.Width -= 1;
                //}
                //this.prevWindowState = this.WindowState;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmMain_ResizeBegin(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState != FormWindowState.Minimized)
                //{
                //    this.Width += 1;
                //    //this.Width -= 1;
                //}
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
                //if (QS2.Desktop.ControlManagment.ControlWorker.isBack)
                //{
                //    this.ControlWorker.run(Application.OpenForms, this.components, PMDS.Global.ENV.TypeRessourcesRun);
                //}
                //else
                //{
                //    string xy = "";
                //}

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
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


    }
}