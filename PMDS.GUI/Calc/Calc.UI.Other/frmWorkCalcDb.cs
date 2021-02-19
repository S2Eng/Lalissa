using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Calc.Logic;
using PMDS.DB;
using PMDS.Global.db.Patient;





namespace PMDS.Calc.UI.Admin
{
    //<20120101>
    public partial class frmWorkCalcDb : QS2.Desktop.ControlManagment.baseForm      
    {

        public PMDS.Calc.Logic.workCalcDb sqlOperations1 = new PMDS.Calc.Logic.workCalcDb();

        public PMDS.Calc.Logic.workCalcDb.eTypUI typUI = PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb;

        public bool isKostLoaded = false;

        private PMDS.Calc.Logic.dbExport dbExport1 = new PMDS.Calc.Logic.dbExport();
        private System.Collections.Generic.List<String> lstColsNotExportCalcs = new System.Collections.Generic.List<String>();
        private System.Collections.Generic.List<String> lstColsNotExportKost = new System.Collections.Generic.List<String>();
      
        public bool _isInEditMode = false;
                
        public int _iErrorsReadCalcs = 0;
        public PMDS.UI.Sitemap.UIFct UIFct1 = null;
        public string _sProt = "";







        public frmWorkCalcDb()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }

        private void frmJahresAb_Load(object sender, EventArgs e)
        {
        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Editor, 32, 32);
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }

                this.AcceptButton = this.butStart;
                this.CancelButton = this.btnClose;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                PMDS.Calc.Logic.Sql.CONNECTION = RBU.DataBase.CONNECTION;
                
                PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                dsKlinik.KlinikRow rActuelKlinik = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

                this.edit(false);

                if (this.typUI == PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb)
                {
                    this.Size = new Size(400, 180);
                    this.butStart.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Überspielen");
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnungen überspielen für ") + rActuelKlinik.Bezeichnung.Trim() + "";
                    this.ultraTabControl1.UseAppStyling = false;
                    this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;
                    this.gridCalcs.Visible = false;
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    this.MinimizeBox = false;
                    this.MaximizeBox = false;
                    this.btnSearch.Visible = false;
                    this.exportAlsExcelToolStripMenuItem.Visible = false;
                    this.butStart.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abgezeichnet, 32, 32);

                    this.erweiterteAnsichtToolStripMenuItem.Visible = false;
                    this.editierenToolStripMenuItem.Visible = false;
                    this.btnOpenBill.Visible = false;
                    this.btnOpenCalcDb.Visible = false;
                    this.udteFrom.Value = null;
                    this.udteTo.Value = null;
                    this.lblCountCalcErrors.Visible = false;
                    this.chkFilterCalcs.Visible = false;
                    this.chkFilterKost.Visible = false;

                    this.alleToolStripMenuItem.Visible = false;
                    this.keineToolStripMenuItem.Visible = false;
                    this.gridCalcs.DisplayLayout.Bands[0].Columns["Select"].Hidden = true;

                }
                else if (this.typUI == PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs)
                {
                    this.Size = new Size(1009, 578);
                    
                    this.butStart.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Export Csv");
                    this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Export Abrechnungen für ") + rActuelKlinik.Bezeichnung.Trim() + "";
                    this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Default;
                    this.gridCalcs.Visible = true;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.MinimizeBox = true;
                    this.MaximizeBox = true;
                    this.btnSearch.Visible = true;
                    this.exportAlsExcelToolStripMenuItem.Visible = true;
                    this.butStart.Appearance.Image = null;

                    DateTime dNowFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime dNowLast = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(dNowFirst.Year, dNowFirst.Month));

                    this.erweiterteAnsichtToolStripMenuItem.Visible = true;
                    this.editierenToolStripMenuItem.Visible = true;
                    this.btnOpenBill.Visible = true;
                    this.btnOpenCalcDb.Visible = true;
                    this.udteFrom.Value = dNowFirst.AddMonths(-1);
                    this.udteTo.Value = dNowLast;       //dNow.AddMonths(1);
                    this.lblCountCalcErrors.Visible = true;
                    this.chkFilterCalcs.Visible = true;
                    this.chkFilterKost.Visible = true;

                    this.alleToolStripMenuItem.Visible = true;
                    this.keineToolStripMenuItem.Visible = true;
                    this.gridCalcs.DisplayLayout.Bands[0].Columns["Select"].Hidden = false;
                }
                else
                {
                    throw new Exception("frmJahresAb_Load: Type-UI " + this.typUI.ToString() + " is wrong!");
                }

                this.UIFct1 = new PMDS.UI.Sitemap.UIFct();
                this.lstColsNotExportCalcs.Add("IDBill");
                this.lstColsNotExportCalcs.Add("IDBillHeader");
                this.lstColsNotExportCalcs.Add("IDKostIntern");
                this.lstColsNotExportCalcs.Add("IDSR");
                this.lstColsNotExportCalcs.Add("TypBill");
                this.lstColsNotExportCalcs.Add("ExportiertJN");

                this.lstColsNotExportKost.Add("IDKostenträger");
                this.lstColsNotExportKost.Add("Message");

                this.erwAnsicht(true, 1);

                this.lblCountCalc.Text = "";
                this.lblCountKost.Text = "";
                this.lblCountCalcErrors.Text = "";

                this.chkFilterCalcs.Checked = false;
                this.setFilterGridCalcs(false);
                this.setFilterGridKost(false);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        

        private void butStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.typUI == PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb)
                {
                    this.transferDatabases();
                }
                else if (this.typUI == PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs)
                {
                    this.exportCalcsAsCsv();
                }
                else
                {
                    throw new Exception("butStart_Click: Type-UI " + this.typUI.ToString() + " is wrong!");
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

        private void AbrechTabelleNeuErstellen()
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Abrechnungstabellen wirklich erstellen?" + "\r\n" +
                                    "(Hinweis: Bereits überspielte Abrechnungsdaten werden gelöscht!)", "Abrechnungstabellen erstellen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sqlTotalResult = "";
                    if (this.sqlOperations1.createTablesFromDs(ref sqlTotalResult))
                    {
                        if (sqlTotalResult.Trim() != "")
                        {
                            frmProtocoll frmProtocoll1 = new frmProtocoll();
                            frmProtocoll1.txtProtocoll.Text = sqlTotalResult.Trim();
                            frmProtocoll1.Show();
                        }
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abrechnungstabellen wurden erfolgreich erstellt!", "Abrechnungstabellen erstellen", MessageBoxButtons.OK);
                    }
                    else
                        throw new Exception("abrechnungstabellenInSqlServerNeuEinspielenToolStripMenuItem_Click: Error Transfer Table-Structure for Calc to Db!");
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void transferDatabases()
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Abrechnungen wirklich überspielen?", "Abrechnungen überspielen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object dFrom = null;
                    if (this.udteFrom.Value != null)
                    {
                        dFrom = (DateTime)this.udteFrom.Value;
                    }
                    object dTo = null;
                    if (this.udteTo.Value != null)
                    {
                        dTo = (DateTime)this.udteTo.Value;
                    }

                    Nullable<DateTime> dFromRechDatum = null;
                    if (this.udteFromRechDat.Value != null)
                    {
                        dFromRechDatum = (DateTime)this.udteFromRechDat.Value;
                    }
                    Nullable<DateTime> dToRechDatum = null;
                    if (this.udteToRechDat.Value != null)
                    {
                        dToRechDatum = (DateTime)this.udteToRechDat.Value;
                    }

                    int iErrors = 0;
                    string sqlTotalResult = "";
                    int countRowsTotalCopied = 0;
                    int countDbTotalCopied = 0;

                    dsKlinik dsKlinik1 = new dsKlinik();
                    PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

                    this._sProt = "";
                    double SumBruttoSRAll = 0;
                    if (this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.CopyDb, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.Rechnung, PMDS.Calc.Logic.eBillStatus.freigegeben,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref iErrors, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked))
                    {
                        if (PMDS.Global.ENV.adminSecure)
                        {
                            string sMsgBoxTranslate = "{0} Abrechnungen wurden überspielt!" + "\r\n" +
                                                        "({1} Zeilen insgesamt!)";
                            sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, countDbTotalCopied.ToString(), countRowsTotalCopied.ToString());
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Abrechnungen überspielen", MessageBoxButtons.OK);

                            if (sqlTotalResult.Trim() != "")
                            {
                                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen das Überspielungsprotokoll öffnen?", "Abrechnungen überspielen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    frmProtocoll frmProtocoll1 = new frmProtocoll();
                                    frmProtocoll1.txtProtocoll.Text = sqlTotalResult.Trim();
                                    frmProtocoll1.Show();

                                    //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                    //startInfo.FileName = "notepad.exe";
                                    //startInfo.Arguments = sqlTotalResult.Trim();
                                    //System.Diagnostics.Process.Start(startInfo);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("transferDatabases: Error Transfer Calc-Data to Db!");
                    }

                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.typUI == PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs)
                {
                    this.searchCalcs();
                }
                else
                {
                    throw new Exception("btnSearch_Click: Type-UI " + this.typUI.ToString() + " is wrong!");
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

        public void selectAllNone(bool bOn)
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridCalcs.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    PMDS.Calc.Logic.dsExport.ExportBMDRow rSelExport = (PMDS.Calc.Logic.dsExport.ExportBMDRow)v.Row;

                    rGrid.Cells["Select"].Value = bOn;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("selectAllNone: " + ex.ToString());
            }
        }


        public void searchCalcs()
        {
            try
            {
                    object dFrom = null;
                    if (this.udteFrom.Value != null)
                    {
                        dFrom = (DateTime)this.udteFrom.Value;
                    }
                    object dTo = null;
                    if (this.udteTo.Value != null)
                    {
                        dTo = (DateTime)this.udteTo.Value;
                    }

                Nullable<DateTime> dFromRechDatum = null;
                if (this.udteFromRechDat.Value != null)
                {
                    dFromRechDatum = (DateTime)this.udteFromRechDat.Value;
                }
                Nullable<DateTime> dToRechDatum = null;
                if (this.udteToRechDat.Value != null)
                {
                    dToRechDatum = (DateTime)this.udteToRechDat.Value;
                }

                double SumBruttoSRAll = 0;
                string sqlTotalResult = "";
                    int countRowsTotalCopied = 0;
                    int countDbTotalCopied = 0;
                    this._iErrorsReadCalcs = 0;
                    
                    this.dsExport1.ExportBMD.Rows.Clear();
                    
                    dsKlinik dsKlinik1 = new dsKlinik();
                    PMDS.DB.DBKlinik DBKlinik1 = new PMDS.DB.DBKlinik();
                    dsKlinik.KlinikRow rKlinikActuell = DBKlinik1.loadKlinik(PMDS.Global.ENV.IDKlinik, true);

                this._sProt = "";

                    //<20120111-2> Storno integriert
                this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref this.dsExport1, 
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.Rechnung , PMDS.Calc.Logic.eBillStatus .freigegeben,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);
                    this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref  this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.Rechnung, PMDS.Calc.Logic.eBillStatus.storniert ,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);

                    this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref  this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.Sammelrechnung , PMDS.Calc.Logic.eBillStatus.freigegeben,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);
                    this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref  this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.Sammelrechnung, PMDS.Calc.Logic.eBillStatus.storniert ,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);

                    this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref  this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.FreieRechnung, PMDS.Calc.Logic.eBillStatus.freigegeben,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);
                    this.sqlOperations1.doCalcDatabases(PMDS.Calc.Logic.workCalcDb.eTypUI.ExportCalcs, ref dFrom, ref dTo, ref dFromRechDatum, ref dToRechDatum, ref  this.dsExport1,
                                                              ref sqlTotalResult, ref countRowsTotalCopied,
                                                              ref countDbTotalCopied, PMDS.Calc.Logic.eBillTyp.FreieRechnung, PMDS.Calc.Logic.eBillStatus.storniert ,
                                                              rKlinikActuell.Bereich.Trim(), PMDS.Global.ENV.typRechNr, ref this._iErrorsReadCalcs, PMDS.Global.ENV.IDKlinik, ref this._sProt, ref SumBruttoSRAll, this.BillsExportiertJN.Checked);

                    this.gridCalcs.Refresh();
                    
                    
                this.gridCalcs.DisplayLayout.Bands[0].Columns[this.dsExport1.ExportBMD.IDBillColumn.ColumnName].Hidden = true;
                this.gridCalcs.DisplayLayout.Bands[0].Columns[this.dsExport1.ExportBMD.IDBillHeaderColumn.ColumnName].Hidden = true;
                this.gridCalcs.DisplayLayout.Bands[0].Columns[this.dsExport1.ExportBMD.IDKostInternColumn.ColumnName].Hidden = true;
                this.gridCalcs.DisplayLayout.Bands[0].Columns[this.dsExport1.ExportBMD.IDSRColumn.ColumnName].Hidden = true;
                
                this.setCountCalcs(this._iErrorsReadCalcs);
                //string sTxtSumBruttoAllSR = "SR - Brutto all: " + SumBruttoSRAll.ToString();
                //this._sProt += "\r\n" + sTxtSumBruttoAllSR + "\r\n";

                this.selectAllNone(true);

                if (this._sProt.Trim() != "")
                {
                    frmProtocoll frmProtocoll1 = new frmProtocoll();
                    frmProtocoll1.txtProtocoll.Text = this._sProt.Trim();
                    frmProtocoll1.Show();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void setCountCalcs(int iErrors)
        {
            try
            {
                this.lblCountCalc.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.gridCalcs.Rows.Count.ToString();
                if (iErrors == 0)
                {
                    this.lblCountCalcErrors.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Meldungen");
                    this.lblCountCalcErrors.Appearance.ForeColor = System.Drawing.Color.DarkGray;
                }
                else
                {
                    this.lblCountCalcErrors.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldungen: ") + iErrors.ToString();
                    this.lblCountCalcErrors.Appearance.ForeColor = System.Drawing.Color.Firebrick;
                }
             }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void setCountKost()
        {
            try
            {
                this.lblCountKost.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.gridKost.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void exportCalcsAsCsv()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;


                dsExport dsExport1 = new dsExport();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridCalcs.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    PMDS.Calc.Logic.dsExport.ExportBMDRow rSelExport = (PMDS.Calc.Logic.dsExport.ExportBMDRow)v.Row;

                    if ((bool)rGrid.Cells["Select"].Value == true)
                    {
                        dsExport.ExportBMDRow rExportBMDRCopy = (dsExport.ExportBMDRow)dsExport1.ExportBMD.NewRow();
                        rExportBMDRCopy.ItemArray = rSelExport.ItemArray;
                        dsExport1.ExportBMD.Rows.Add(rExportBMDRCopy);
                    }
                }

                PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
                export.exportGrid(this.gridCalcs, PMDS.GUI.VB.gridExport.eTyp.csv, dsExport1, this.dsExport1.ExportBMD.TableName, this.lstColsNotExportCalcs, "");

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    foreach (dsExport.ExportBMDRow rExportBMD in dsExport1.ExportBMD)
                    {
                        PMDS.db.Entities.bills rBills = db.bills.Where(b => b.ID == rExportBMD.IDBill).First();
                        rBills.ExportiertJN = true;
                        db.SaveChanges();
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

        private void lblExportKostenträgerAsExcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool erwAnsichtLastStatus = this.erweiterteAnsichtToolStripMenuItem.Checked;
                this.erwAnsicht(false, 0);

                PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
                export.exportGrid(this.gridKost, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", this.lstColsNotExportKost, "");

                if (erwAnsichtLastStatus)
                {
                    this.erwAnsicht(true, 0);
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
        private void lblExportKostenträgerAsCsv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
                export.exportGrid(this.gridKost, PMDS.GUI.VB.gridExport.eTyp.csv, this.dsExport1,
                                    this.dsExport1.ExportKostentraeger.TableName, this.lstColsNotExportKost, "");
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


        private void ultraTabControl1_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                

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
        private void btnRefreshKost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadKostenträger();

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

        public void edit(bool bEdit)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._isInEditMode = bEdit;
                if (bEdit) 
                {
                    this.gridCalcs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    this.gridKost.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                }
                else
                {
                    this.gridCalcs.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    this.gridKost.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
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

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ultraTabControl1.SelectedTab.Index == 0)
                {

                }
                else if (this.ultraTabControl1.SelectedTab.Index == 1)
                {
                    if (!this.isKostLoaded)
                    {
                        this.isKostLoaded = true;
                        this.loadKostenträger();
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

        public void loadKostenträger()
        {
            try
            {
                PMDS.Calc.UI.Admin.WorkCalcDb.CalcExport CalcExport1 = new PMDS.Calc.UI.Admin.WorkCalcDb.CalcExport();
                CalcExport1.loadKostenträger(ref this.dsExport1, (Infragistics.Win.UltraWinGrid.UltraGrid) this.gridKost);
                this.setCountKost();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public  void selectAllxy(bool bSelect, DataTable dtToSet)
        {
            try
            {
                foreach (System.Data.DataRow rowFound in dtToSet.Rows)
                {
                    if (bSelect)
                    {
                        rowFound["Select"] = true;
                    }
                    else
                    {
                        rowFound["Select"] = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridCalcs_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                this.BeforeCellActivate(sender, e);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridKost_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                this.BeforeCellActivate(sender, e);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Row.IsGroupByRow || e.Cell.IsFilterRowCell)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString() == "Select")
                    {
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    }
                    else
                    {
                        if (this._isInEditMode)
                        {
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        }
                        else
                        {
                            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnOpenCalcDb_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow  gridRow = null;
                PMDS.Calc.Logic.dsExport.ExportBMDRow rExportBMD = this.getSelectedRow(true, ref gridRow);
                if (rExportBMD != null)
                {
                    PMDS.Calc.UI.Admin.generic.Calc.genericCalc genericCalc1 = new PMDS.Calc.UI.Admin.generic.Calc.genericCalc();
                    genericCalc1.openDbCalc(rExportBMD.IDBillHeader);
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

        public PMDS.Calc.Logic.dsExport.ExportBMDRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridCalcs.ActiveRow != null)
                {
                    if (this.gridCalcs.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridCalcs.ActiveRow.ListObject;
                        PMDS.Calc.Logic.dsExport.ExportBMDRow rSelExport = (PMDS.Calc.Logic.dsExport.ExportBMDRow)v.Row;
                        gridRow = this.gridCalcs.ActiveRow;
                        return rSelExport;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return null;
            }
        }


        private void gridCalcs_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            this.deleteRow(sender, e);
        }
        private void gridKost_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            this.deleteRow(sender, e);
        }
        public  void deleteRow(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                e.DisplayPromptMsg = false;
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen sie den/die Datensätz/e wirklich löschen?", "Löschen",  MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
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

        private void btnOpenBill_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openBill(true);

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
        public void openBill(bool withMsgBox)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                PMDS.Calc.Logic.dsExport.ExportBMDRow rExportBMD = this.getSelectedRow(withMsgBox, ref gridRow);
                if (rExportBMD != null)
                {
                    PMDS.Calc.UI.Admin.generic.Calc.genericCalc genericCalc1 = new PMDS.Calc.UI.Admin.generic.Calc.genericCalc();
                    genericCalc1.openBill(withMsgBox, rExportBMD.TypBill, rExportBMD.IDKostIntern, ref this.editor, rExportBMD.IDBillHeader, gridRow);
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

        private void gridCalcs_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                this.setCountCalcs(this._iErrorsReadCalcs);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridKost_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                this.setCountKost();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void erweiterteAnsichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.erwAnsicht(this.erweiterteAnsichtToolStripMenuItem.Checked, this.ultraTabControl1.SelectedTab.Index);
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

        public void erwAnsicht(bool bOn, int activeIndexxy)
        {
            try
            {
                foreach (string colName in this.lstColsNotExportCalcs)
                {
                    if (PMDS.Global.ENV.adminSecure)
                    {
                        this.gridCalcs.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn;
                    }
                    else
                    {
                        if (colName.StartsWith("ID", StringComparison.CurrentCultureIgnoreCase))
                        {
                            this.gridCalcs.DisplayLayout.Bands[0].Columns[colName].Hidden = true;
                        }
                        else
                        {
                            this.gridCalcs.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn;
                        }
                    }
                }
                foreach (string colName in this.lstColsNotExportKost)
                {
                    if (PMDS.Global.ENV.adminSecure)
                    {
                        this.gridKost.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn;
                    }
                    else
                    {
                        if (colName.StartsWith("ID", StringComparison.CurrentCultureIgnoreCase))
                        {
                            this.gridKost.DisplayLayout.Bands[0].Columns[colName].Hidden = true;
                        }
                        else
                        {
                            this.gridKost.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn; 
                        }
                    }
                }

                //if (activeIndex == 0)
                //{
                //    foreach (string colName in this.lstColsNotExportCalcs)
                //    {
                //        this.gridCalcs.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn;
                //    }
                //}
                //else if (activeIndex  == 1)
                //{
                //    foreach (string colName in this.lstColsNotExportKost)
                //    {
                //        this.gridKost.DisplayLayout.Bands[0].Columns[colName].Hidden = !bOn;
                //    }
                //}
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setFilterGridCalcs(this.chkFilterCalcs.Checked);
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
        private void chkFilterCalcsKost_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setFilterGridKost(this.chkFilterKost.Checked);
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

        public void setFilterGridCalcs(bool bOn)
        {
            try
            {
                PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();
                buildUI1.setFilterGridKomplex((Infragistics.Win.UltraWinGrid.UltraGrid)this.gridCalcs, bOn, true, false);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void setFilterGridKost(bool bOn)
        {
            try
            {
                PMDS.GUI.VB.buildUI buildUI1 = new PMDS.GUI.VB.buildUI();
                buildUI1.setFilterGridKomplex((Infragistics.Win.UltraWinGrid.UltraGrid)this.gridKost, bOn, true, false);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void editierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.edit(this.editierenToolStripMenuItem.Checked);
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

        private void gridCalcs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.UIFct1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid) this.gridCalcs))
                {
                    this.openBill(false);
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

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (e.Tool.Key.Trim().Equals(("AbrechTabellenErstellen")))
                {
                    this.AbrechTabelleNeuErstellen();
                }
                else if (e.Tool.Key.Trim().Equals(("btnClose")))
                {
                    this.Close();
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

        private void protocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                frmProt.initControl();
                frmProt.Show();
                frmProt.ContProtocol1.setText(this._sProt);
                frmProt.Text = "Transfer database protocol";
                
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

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(true);

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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectAllNone(false);

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

        private void exportAlsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                bool erwAnsichtLastStatus = this.erweiterteAnsichtToolStripMenuItem.Checked;
                this.erwAnsicht(false, 0);

                PMDS.GUI.VB.gridExport export = new PMDS.GUI.VB.gridExport();
                export.exportGrid(this.gridCalcs, PMDS.GUI.VB.gridExport.eTyp.excel, null, "", this.lstColsNotExportCalcs, "");

                if (erwAnsichtLastStatus)
                {
                    this.erwAnsicht(true, 0);
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
