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




namespace qs2.ui.print
{


    public partial class frmQryRunReport : Form
    {

        public bool isLoaded = false;




        public frmQryRunReport()
        {
            InitializeComponent();
        }

        private void frmQryRunReport_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string defaultApplication, string defaultParticipant)
        {
            try
            {
                if (!this.isLoaded)
                {
                    this.CancelButton = this.btnClose;

                    this.contQryRunReport1.mainWindow = this;
                    this.loadRes();
                    this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

                    this.contQryRunReport1.initControl(defaultApplication, defaultParticipant);
                    this.isLoaded = true;
                }

                //this.contQryRunReport1.clearData();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes()
        {
            try
            {
                this.Icon = getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Drucken , 32, 32);

                //string IDResFound = qs2.core.language.sqlLanguage.getRes(rSelListEntry.IDRessource, this.IDParticipant, this.IDApplication);
                //this.Text = qs2.core.language.sqlLanguage.getRes("ResultQuery") + (IDResFound.Trim().Equals("") ? " " + rSelListEntry.IDRessource : " " + qs2.core.language.sqlLanguage.getRes(rSelListEntry.IDRessource));

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadTitleWindow(string IDRessource)
        {
            try
            {
                string txt = qs2.core.language.sqlLanguage.getRes("Parameter");
                if (this.contQryRunReport1.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                    txt += " " + qs2.core.language.sqlLanguage.getRes("Query");
                else if (this.contQryRunReport1.typRunQuery == qs2.core.Enums.eTypRunQuery.QueryGroups)
                    txt += " " + qs2.core.language.sqlLanguage.getRes("Report");

                //if (this.contQryRunReport1.rowGridSelList != null)
                //{
                    string translateReportQuery = qs2.core.language.sqlLanguage.getRes(IDRessource);
                    if (translateReportQuery.Trim() == "")
                    {
                        translateReportQuery = IDRessource;
                    }
                    this.Text = txt + " " + translateReportQuery;
                //}
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void run(dsAdmin.tblSelListEntriesRow rSelectedSelListReports, dsAdmin.tblSelListEntriesRow rSelectedSelListQry, 
                                        string Application, string IDParticipant,
                                         ref string protocollForAdmin, ref bool protocolWindow)
        {
            try
            {
                this.contQryRunReport1.clearData();

                this.contQryRunReport1.setVisibleMultiControls(false);
                this.contQryRunReport1.resetDrawParameters();

                qs2.ui.print.infoQry infoQryRunParNew = new qs2.ui.print.infoQry();
                infoQryRunParNew.rSelListQry = rSelectedSelListQry;
                infoQryRunParNew.rSelListReport = rSelectedSelListReports;
                infoQryRunParNew.Participant = IDParticipant;
                infoQryRunParNew.Application = Application;

                qs2.ui.print.infoReport infoReportNew = new qs2.ui.print.infoReport();
                infoReportNew.rSelListReport = rSelectedSelListReports;
                infoReportNew.Application = Application;
                infoReportNew.Participant = IDParticipant;

                int counterPar = 0;
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstAllMCs = new List<design.auto.multiControl.ownMultiControl>();
                this.contQryRunReport1.drawParameters2("", infoQryRunParNew, infoReportNew, true, false, false, ref protocollForAdmin, ref protocolWindow, ref counterPar, false, ref lstAllMCs);
                this.contQryRunReport1.checkMCForParent(ref lstAllMCs);
                this.contQryRunReport1.translateTitle("InputParameters");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void frmQryRunReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Visible = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

    }
}
