using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qs2.design.auto.print
{
    public partial class contSqlConsoleForAdmin : UserControl
    {
        public string _sqlCommandForAdmin = "";
        public qs2.ui.print.infoQry _infoQryRunPar = null;
        public frmSqlConsoleForAdmin mainForm = null;

        private bool _bShowGUI;

        public contSqlConsoleForAdmin()
        {
            InitializeComponent();
        }

        public void initControl(string sqlCommandForAdmin, qs2.ui.print.infoQry infoQryRunPar, bool bShowGUI)
        {
            try
            {
                _bShowGUI = bShowGUI;
                if (_bShowGUI)
                {
                    this.mainForm.CancelButton = this.btnClose;
                    this.mainForm.AcceptButton = this.btnExceuteSql;
                }

                this.contTable1.initControl(false, qs2.ui.print.contTable.eTypeUI.Query, false);
                this.contTable1.btnClose.Visible = false;
                this._sqlCommandForAdmin = sqlCommandForAdmin;
                this._infoQryRunPar = infoQryRunPar;

                this.btnExceuteSql.Text = qs2.core.language.sqlLanguage.getRes("ExceuteSql");
                this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");
                this.gridResult.Text = qs2.core.language.sqlLanguage.getRes("Result");

                this.txtSql.Text = this._sqlCommandForAdmin.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("contSqlConsoleForAdmin.initControl: " + ex.ToString());
            }
        }

        public void exceuteSql()
        {
            try
            {
                string protocol = "";
                if (_bShowGUI)
                {
                    this.contTable1.clearUI();
                }

                DataSet ds = new DataSet();
                qs2.core.dbBase.fillDataSet(this.txtSql.Text.Trim(), ref ds, this._infoQryRunPar.rSelListQry.IDRessource, "dsResultExceuteQueryQS2");

                qs2.ui.print.infoQry infoQryRunPar = new qs2.ui.print.infoQry();
                infoQryRunPar.rSelListQry = null;
                infoQryRunPar.rSelListReport = null;
                infoQryRunPar.Participant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim();
                infoQryRunPar.Application = qs2.core.license.doLicense.rApplication.IDApplication.Trim();

                this.contTable1.infoQryRunPar = infoQryRunPar;
                if (!String.IsNullOrWhiteSpace(protocol))
                {
                    this.contTable1.lblProtocol.Visible = true;

                    this.contTable1.ProtocollText = protocol.Trim();
                    this.contTable1.ProtocollTitle = "Info: Problems with Query";
                    this.contTable1.lblProtocol.Text = "Errors"; 
                }
                this.contTable1.ResultQryIsTranslated = false;
                this.contTable1.IDApplicationTmp = qs2.core.license.doLicense.rApplication.IDApplication.Trim();
                this.contTable1.IDParticipantTmp = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim();
                this.contTable1.Sql = this.txtSql.Text;
                this.contTable1.parameters = infoQryRunPar.parametersSql;
                this.contTable1.AllParametersAsTxtFromSqlCommand = "";
                this.contTable1.doUnvisibleGuid = true;
                this.contTable1.doTable(this._infoQryRunPar.rSelListQry.IDRessource, ds, ref protocol, true);
            }
            catch (Exception ex)
            {
                throw new Exception("contSqlConsoleForAdmin.exceuteSql: " + ex.ToString());
            }
        }

        private void btnExceuteSql_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.exceuteSql();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainForm.Close();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
