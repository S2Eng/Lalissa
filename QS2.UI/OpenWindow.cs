using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;




namespace qs2.ui
{


    public class OpenWindow
    {

        public static qs2.ui.pint.contQryRun contQueriesRun;
        public static System.Windows.Forms.Form frmQueriesRun = null;

        public static qs2.ui.pint.contQryRun contReportsRun;
        public static System.Windows.Forms.Form frmReportsRun = null;

        public static qs2.ui.pint.contQryRun contDocumentsRun;
        public static System.Windows.Forms.Form frmDocumentsRun = null;

        public static qs2.ui.print.contQryAdmin contQryAdminUsr;
        public static System.Windows.Forms.Form frmQryAdminUsr = null;

        public static qs2.ui.print.frmQryAdmin frmQryAdmin = null;

        public static qs2.sitemap.manage.wizardsDevelop.frmRessourcen frmRessourcen = null;
        public static qs2.sitemap.workflowAssist.frmInfoFieldDB frmInfoDB = null;
        public static qs2.sitemap.vb.frmSelLists frmSelLists = null;
        public static qs2.sitemap.manage.wizardsDevelop.frmCriterias frmCriteria = null;

        public static QS2.Logging.contLogViewer contLogViewer = null;
        public static System.Windows.Forms.Form frmLogViewer = null;

        public static qs2.core.vb.frmLayoutManager frmLayouts = null;







        public static void doControl(qs2.core.ENV.eTypApp typFound, Panel PanelToLoad, System.Windows.Forms.Form FrmMain, 
                                     bool ExtendedView)
        {
            try

            {
                if (typFound == qs2.core.ENV.eTypApp.contQuerysRun)
                {
                    if (OpenWindow.contQueriesRun == null)
                    {
                        OpenWindow.contQueriesRun = new qs2.ui.pint.contQryRun();
                        OpenWindow.contQueriesRun.typRunQuery = qs2.core.Enums.eTypRunQuery.QueryGroups;
                        OpenWindow.contQueriesRun.defaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        OpenWindow.contQueriesRun.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        OpenWindow.contQueriesRun.initControl(qs2.core.license.doLicense.rApplication.IDApplication.ToString(), true);
                        OpenWindow.frmQueriesRun = FrmMain;
                        OpenWindow.frmQueriesRun.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Queries, 32, 32);
                        OpenWindow.frmQueriesRun.Text = qs2.core.language.sqlLanguage.getRes("Queries");
                        OpenWindow.loadIntoPanel(OpenWindow.contQueriesRun, PanelToLoad);
                        OpenWindow.contQueriesRun.refreshControl();
                    }
                    OpenWindow.frmQueriesRun.Show();
                    OpenWindow.frmQueriesRun.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.contReportsRun)
                {
                    if (OpenWindow.contReportsRun == null)
                    {
                        OpenWindow.contReportsRun = new qs2.ui.pint.contQryRun();
                        OpenWindow.contReportsRun.typRunQuery = qs2.core.Enums.eTypRunQuery.ReportGroups;
                        OpenWindow.contReportsRun.defaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        OpenWindow.contReportsRun.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        OpenWindow.contReportsRun.initControl(qs2.core.license.doLicense.rApplication.IDApplication.ToString(), true);
                        OpenWindow.frmReportsRun = FrmMain;
                        OpenWindow.frmReportsRun.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Reports, 32, 32);
                        OpenWindow.frmReportsRun.Text = qs2.core.language.sqlLanguage.getRes("Reports");
                        OpenWindow.loadIntoPanel(OpenWindow.contReportsRun, PanelToLoad);
                        OpenWindow.contReportsRun.refreshControl();
                    }
                    OpenWindow.frmReportsRun.Show();
                    OpenWindow.contReportsRun.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.contDocumentsRun)
                {
                    if (OpenWindow.contDocumentsRun == null)
                    {
                        OpenWindow.contDocumentsRun = new qs2.ui.pint.contQryRun();
                        OpenWindow.contDocumentsRun.typRunQuery = qs2.core.Enums.eTypRunQuery.ReportGroups;
                        OpenWindow.contDocumentsRun.defaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        OpenWindow.contDocumentsRun.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        OpenWindow.contDocumentsRun.initControl(qs2.core.license.doLicense.rApplication.IDApplication.ToString(), true);
                        OpenWindow.frmDocumentsRun = FrmMain;
                        OpenWindow.frmDocumentsRun.Icon = getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32);
                        OpenWindow.frmDocumentsRun.Text = qs2.core.language.sqlLanguage.getRes("Documents");
                        OpenWindow.loadIntoPanel(OpenWindow.contDocumentsRun, PanelToLoad);
                        OpenWindow.contDocumentsRun.refreshControl();
                    }
                    OpenWindow.frmReportsRun.Show();
                    OpenWindow.contReportsRun.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.contQuerysUser)
                {
                    if (OpenWindow.contQryAdminUsr == null)
                    {
                        OpenWindow.contQryAdminUsr = new qs2.ui.print.contQryAdmin();
                        OpenWindow.contQryAdminUsr.typeQuery = core.Enums.eTypeQuery.User;
                        OpenWindow.contQryAdminUsr.DefaultApplication = qs2.core.license.doLicense.rApplication.IDApplication.ToString();
                        OpenWindow.contQryAdminUsr.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString();
                        OpenWindow.contQryAdminUsr.initControl(OpenWindow.contQryAdminUsr.DefaultApplication);
                        OpenWindow.contQryAdminUsr.loadQueries(null, true, true);
                        OpenWindow.frmQryAdminUsr = FrmMain;
                        OpenWindow.frmQryAdminUsr.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Criterias, 32, 32);
                        OpenWindow.frmQryAdminUsr.Text = qs2.core.language.sqlLanguage.getRes("ManageQueries");
                        OpenWindow.loadIntoPanel(OpenWindow.contQryAdminUsr, PanelToLoad);
                        OpenWindow.contQryAdminUsr.refreshControl();
                    }
                    OpenWindow.frmQryAdminUsr.Show();
                    OpenWindow.frmQryAdminUsr.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerQuerysAdmin)
                {
                    if (OpenWindow.frmQryAdmin == null)
                    {
                        OpenWindow.frmQryAdmin = new qs2.ui.print.frmQryAdmin();
                        OpenWindow.frmQryAdmin.UnvisibleOnClose = true;
                        OpenWindow.frmQryAdmin.contQryAdmin1.panelButtClose.Visible = false;
                        OpenWindow.frmQryAdmin.contQryAdmin1.contSelListQueries.btnRefreshQuery.Visible = false;
                        OpenWindow.frmQryAdmin.contQryAdmin1.contSelListQueries.btnClearSelection.Visible = false;
                        OpenWindow.frmQryAdmin.contQryAdmin1.comboApplication1.OwnLabelVisible = false;
                        //this.frmQryAdmin_AppMenü.contQryAdmin1.contSelListQueries2.cboQuerySelect.Dock = DockStyle.Left;
                        OpenWindow.frmQryAdmin.contQryAdmin1.typeQuery = core.Enums.eTypeQuery.Admin;
                        OpenWindow.frmQryAdmin.contQryAdmin1.DefaultApplication = qs2.core.license.doLicense.rApplication.IDApplication;
                        OpenWindow.frmQryAdmin.contQryAdmin1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant;
                    }
                    OpenWindow.frmQryAdmin.Show();
                    OpenWindow.frmQryAdmin.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerRessourcen)
                {
                    //if (OpenWindow.frmRessourcen == null)
                    //{
                        OpenWindow.frmRessourcen = new qs2.sitemap.manage.wizardsDevelop.frmRessourcen();
                        OpenWindow.frmRessourcen.contRessourcen1.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString();    //qs2.core.license.doLicense.rApplication.IDApplication;
                        OpenWindow.frmRessourcen.contRessourcen1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant;
                        OpenWindow.frmRessourcen.contRessourcen1.btnClose.Visible = false;
                    //}
                    OpenWindow.frmRessourcen.Show();
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerSysDatabase)
                {
                    //if (OpenWindow.frmInfoDB == null)
                    //{
                        OpenWindow.frmInfoDB = new qs2.sitemap.workflowAssist.frmInfoFieldDB();
                        OpenWindow.frmInfoDB.contInfoFieldDB1.panelButtClose.Visible = false;
                        OpenWindow.frmInfoDB.contInfoFieldDB1.IDApplication = qs2.core.license.doLicense.rApplication.IDApplication;
                        OpenWindow.frmInfoDB.contInfoFieldDB1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant;
                    //}
                    OpenWindow.frmInfoDB.Show();
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerSelLists)
                {
                    if (OpenWindow.frmSelLists == null)
                    {
                        OpenWindow.frmSelLists = new qs2.sitemap.vb.frmSelLists();
                        OpenWindow.frmSelLists.UnvisibleOnClose = true;
                        OpenWindow.frmSelLists.ContSelList1.PanelClose.Visible = false;
                        OpenWindow.frmSelLists.ContSelList1.ComboApplication1.OwnLabelVisible = false;
                        OpenWindow.frmSelLists.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName;
                        OpenWindow.frmSelLists.typeUI = sitemap.vb.frmSelLists.eTypeUI.Administration;
                        OpenWindow.frmSelLists.ContSelList1.defaultApplication = qs2.core.license.doLicense.eApp.ALL.ToString();      //qs2.core.license.doLicense.rApplication.IDApplication;
                        OpenWindow.frmSelLists.ContSelList1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant;
                    }
                    OpenWindow.frmSelLists.Show();
                    OpenWindow.frmSelLists.Visible = true;
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerCriterias)
                {
                    //if (OpenWindow.frmCriteria == null)
                    //{
                        OpenWindow.frmCriteria = new qs2.sitemap.manage.wizardsDevelop.frmCriterias();
                        OpenWindow.frmCriteria.contCriterias1.IDApplication = qs2.core.license.doLicense.rApplication.IDApplication;
                        OpenWindow.frmCriteria.contCriterias1.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant;
                        OpenWindow.frmCriteria.contCriterias1.btnClose.Visible = false;
                    //}
                    OpenWindow.frmCriteria.loadForm(sitemap.manage.wizardsDevelop.contCriterias.eTypeUI.Admin);
                    OpenWindow.frmCriteria.Show();
                }
                else if (typFound == qs2.core.ENV.eTypApp.QS2PopUpContainerLayouts)
                {
                    //if (OpenWindow.frmCriteria == null)
                    //{
                    OpenWindow.frmLayouts = new qs2.core.vb.frmLayoutManager();
                    OpenWindow.frmLayouts.ContLayoutGrid1.cLayoutManager1._LayoutKey = "";
                    OpenWindow.frmLayouts.ContLayoutGrid1.cLayoutManager1.gridUIToSave = null;
                    OpenWindow.frmLayouts.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = cLayoutManager.eTypLayoutGrid.onlyFirstBand;
                    OpenWindow.frmLayouts.initControl("", true, "", ExtendedView);
                    OpenWindow.frmLayouts.Show();

                }
                else if (typFound == qs2.core.ENV.eTypApp.contTexteditor)
                {
                    QS2.Desktop.Txteditor.frmTxtEditor frmTxtEditor1 = new QS2.Desktop.Txteditor.frmTxtEditor();
                    frmTxtEditor1.fFelderEinAus = true;
                    frmTxtEditor1.ds = new DataSet();
                    frmTxtEditor1.Show();
                }
                else
                {
                    throw new Exception("OpenWindow.doControl: typFound '" + typFound.ToString() + " not supported!'");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("OpenWindow.doControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static void loadIntoPanel(Control cont, Panel PanelToLoad)
        {
            PanelToLoad.Controls.Add(cont);
            cont.Dock = DockStyle.Fill;
            cont.BackColor = System.Drawing.Color.Transparent;
        }

    }
}
