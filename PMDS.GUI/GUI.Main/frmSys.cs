using PMDS.DB;
using PMDS.Global.db.ERSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.GUI.Main
{
    
    public partial class frmSys : Form
    {

        public PMDSBusiness b = new PMDSBusiness();

        


        public frmSys()
        {
            InitializeComponent();
        }

        private void frmSys_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

        private void btnImportResFile_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                PMDS.Global.db.Sys.cSys cSys1 = new Global.db.Sys.cSys();
                int iInserted = 0;
                int iUpdated = 0;
                //if (cSys1.importRessourcenFromITSCont2(this.txtSourceDB.Text.Trim(), this.txtResFileToImport.Text.Trim(), ref iInserted, ref iUpdated))
                if (cSys1.importRessourcenFromITSCont2(this.txtSourceDB.Text.Trim(), ref iInserted, ref iUpdated))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iInserted.ToString() + " Rescources inserted!" + "\r\n" +
                                                                              iUpdated.ToString() + " Rescources updated!", "", MessageBoxButtons.OK);
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

        private void btnCopyOldPlansIntoNewSystemAndDeleteOldPlans_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.Global.db.Sys.cSys cSys1 = new Global.db.Sys.cSys();
                int iInserted = 0;
                string sProt = "";
                int iCounterError = 0;

                if (cSys1.takeOldPlansIntoNewPlanSystemAndDelete(ref iInserted, ref sProt, ref iCounterError))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iInserted.ToString() + " plans inserted/transfered!" + "!", "", MessageBoxButtons.OK);

                    if (sProt.Trim() != "")
                    {
                        PMDS.Calc.UI.Admin.frmProtocoll frmProtocoll1 = new PMDS.Calc.UI.Admin.frmProtocoll();
                        frmProtocoll1.Text = "Transfer plans! (" + iCounterError.ToString() + " + Erros found)";
                        frmProtocoll1.txtProtocoll.Text = sProt.Trim();
                        frmProtocoll1.Show();
                    }
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

        private void btnUpdatePETest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.updateAbteilungBereichForPatientWithLog(false);

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
        private void btnUpdatePE_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.updateAbteilungBereichForPatientWithLog(true);

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

        public void updateAbteilungBereichForPatientWithLog(bool SaveChanges)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.DB.PMDSBusiness.dShowInfo2 += new PMDS.DB.PMDSBusiness.dShowInfoDelegate(this.showInfo);

                string sTitle = "";
                if (SaveChanges)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten und PE - Abteilungen und Bereiche prüfen und updaten");
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten und PE - Abteilungen und Bereiche prüfen");
                }
                string sTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen die Aktivität wirklich durchgeführt werden?");
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sTxt, sTitle, MessageBoxButtons.YesNo, true);
                if (res == DialogResult.Yes)
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    int iCounterUpdatedPatient = 0;
                    int iCounterUpdatedPE = 0;
                    b.sys_UpdateAufenthaltBereichPatient(ref iCounterUpdatedPatient, ref iCounterUpdatedPE, SaveChanges, this.chkNoProtocol.Checked);

                    string sMsg = "";
                    if (SaveChanges)
                    {
                        sMsg = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Patienten und {1} PE upgedated!");
                    }
                    else
                    {
                        sMsg = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Patienten und {1} PE geprüft!");
                    }

                    sMsg = string.Format(sMsg, iCounterUpdatedPatient.ToString(), iCounterUpdatedPE.ToString());
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsg, sTitle, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("updateAbteilungBereichForPatientWithLog: " + ex.ToString());
            }
        }

        public void showInfo(string sInfo)
        {
            try
            {
                this.lblInfoOperation.Text = sInfo.Trim();
                Application.DoEvents();

            }
            catch (Exception ex)
            {
                throw new Exception("frmSys.showInfo: " + ex.ToString());
            }
        }

        private void btnCheckVOAndUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<DateTime> dVon = new DateTime(1900, 1, 1, 0, 0, 0);
                Nullable<DateTime> dBis = new DateTime(2300, 1, 1, 0, 0, 0);
                dsKlientenliste dsKlientenliste1 = new dsKlientenliste();
                sqlManange sqlManage1 = new sqlManange();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tAufenthalt = (from a in db.Aufenthalt
                                       where a.Entlassungszeitpunkt != null
                                       select new
                                       {
                                           a.ID,
                                           a.Entlassungszeitpunkt
                                       });

                    foreach (var rAuf in tAufenthalt)
                    {
                        this.b.checkVOAndUpdate((Guid)rAuf.ID, rAuf.Entlassungszeitpunkt.Value.Date, db);
                    }

                    //sqlManage1.getPatientenStart(System.Guid.Empty, 1, System.Guid.Empty, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                    //foreach (PMDS.Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                    //{
                    //    var tAufenthalt = (from a in db.Aufenthalt
                    //               where a.IDAufenthalt == IDAufenthalt && (vo.DatumVerordnetBis >= EntlassenAm.Date || vo.DatumVerordnetBis == null)
                    //               select new
                    //               {
                    //                   vo.ID
                    //               });

                    //    this.b.checkVOAndUpdate(rKlient.IDAufenthalt, rKlient.)
                    //}
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
    }
}
