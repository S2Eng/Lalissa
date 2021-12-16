using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.ERSystem;
using PMDSClient.Sitemap;
using PMDS.DB;
using WCFServicePMDS.BAL2.ELGABAL;
using S2Extensions;

namespace PMDS.GUI.ELGA
{


    public partial class contELGASearchDocuments : UserControl
    {
        public System.Collections.Generic.List<PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow> lDocusSelected = new List<dsManage.ELGASearchDocumentsRow>();
        public frmELGASearchDocuments mainWindow = null;
        public bool IsInitialized = false;

        public Guid _IDPatient;
        public bool abort = true;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public WCFServiceClient WCFServiceClient1 = new WCFServiceClient();

        public string colSelect = "Select";
        public string Stylesheet2 = "ELGA_Stylesheet_v1.0.xsl";

        public ELGABusiness bELGA = new ELGABusiness();






        public contELGASearchDocuments()
        {
            InitializeComponent();
        }

        private void ContELGASearchDocuments_Load(object sender, EventArgs e)
        {

        }

        public void initControl(Guid IDPatient)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._IDPatient = IDPatient;

                    this.mainWindow.AcceptButton = this.btnOK;
                    this.mainWindow.CancelButton = this.btnAbort;

                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                    this.clearUI(true);
                    this.loadData();

                    if (ENV.adminSecure)
                    {
                    }

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI(bool clearGrid)
        {
            try
            {
                this.udteCreatedFrom.Value = null;
                this.udteCreatedTo.Value = null;
 
                if (clearGrid)
                {
                    this.dsManage1.Clear();
                    this.gridFound.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.clearUI: " + ex.ToString());
            }
        }


        public void loadData()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.loadData: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.validateData: " + ex.ToString());
            }
        }

        public bool searchData()
        {
            try
            {
                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return false;
                }
                if (!this.bELGA.ELGAIsActive(this._IDPatient, ENV.IDAUFENTHALT, true))
                {
                    return false;
                }

                if (!this.validateData())
                {
                    return false;
                }

                this.dsManage1.Clear();
                this.gridFound.Refresh();

                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    Nullable<DateTime> dCreatedFrom = null;
                    if (this.udteCreatedFrom.Value != null)
                    {
                        dCreatedFrom = this.udteCreatedFrom.DateTime.Date;
                    }
                    Nullable<DateTime> dCreatedTo = null;
                    if (this.udteCreatedTo.Value != null)
                    {
                        dCreatedTo = this.udteCreatedTo.DateTime.Date;
                    }

                    var rPatient = (from p in db.Patient
                                    where p.ID == this._IDPatient
                                    select new
                                    {
                                        p.ID,
                                        p.Nachname,
                                        p.Vorname
                                    }).First();

                    PMDSBusiness b = new PMDSBusiness();
                    PMDS.db.Entities.Aufenthalt rActAuf= b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);

                    ELGAParOutDto parOuot = WCFServiceClient1.ELGAQueryDocuments(rActAuf.ELGALocalID.Trim(), dCreatedFrom, dCreatedTo, false, "");

                    string sFieldsSearchingGda = "Felder:" + "\r\n";
                    if (this.udteCreatedFrom.Value != null)
                    {
                        sFieldsSearchingGda += "Erstellt von: " + this.udteCreatedFrom.DateTime.Date.ToString("dd.MM.yyyy") + "\r\n";
                    }
                    if (this.udteCreatedTo.Value != null)
                    {
                        sFieldsSearchingGda += "Erstellt bis: " + this.udteCreatedTo.DateTime.Date.ToString("dd.MM.yyyy") + "\r\n";
                    }

                    string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokumentensuche wurde durchgeführt") + "\r\n" + sFieldsSearchingGda;
                    ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokumentensuche"), null,
                                                    ELGABusiness.eTypeProt.ELGAQueryDocuments, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, this._IDPatient, rActAuf.ID, sProt);

                    if (parOuot.bErrorsFound)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(parOuot.MessageException.Trim() , "ELGA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (parOuot.lDocuments.Count > 0)
                        {
                            foreach (ELGADocumentsDTO elgaDocu in parOuot.lDocuments)
                            {
                                bool bDocuOK = true;
                                if (!this.chkStorniert.Checked && elgaDocu.DocStatus.sEquals("Deprecated", S2Extensions.Enums.eCompareMode.Contains))
                                {
                                    bDocuOK = false;
                                }
                                if (bDocuOK)
                                {
                                    dsManage.ELGASearchDocumentsRow rDocu = this.sqlManange1.getNewELGADocument(ref this.dsManage1);
                                    rDocu.Dokument = elgaDocu.Documentname.Trim();
                                    rDocu.SetErstelltAmNull();
                                    rDocu.UUID = elgaDocu.UUID.Trim();
                                    rDocu.UniqueID = elgaDocu.UniqueId.Trim();
                                    rDocu.LocigalID = elgaDocu.LogicalId.Trim();
                                    rDocu.Author = elgaDocu.Author.Trim();
                                    rDocu.Description = elgaDocu.Description.Trim();
                                    rDocu.DocStatus = elgaDocu.DocStatus.Trim();
                                    rDocu.Version = elgaDocu.Version.Trim();
                                    rDocu.CreationTime = elgaDocu.CreationTime.Trim();
                                    rDocu.Size = elgaDocu.Size;
                                    rDocu.Stylesheet = "";                              
                                    rDocu.TypeFile = elgaDocu.TypeFile.Trim();
                                    rDocu.IDPatient = rPatient.ID;
                                    rDocu.IDAufenthalt = rActAuf.ID;
                                    rDocu.ELGAPatientLocalID = rActAuf.ELGALocalID.Trim();
                                }
                            }
                        }
                    }

                    DataTable docus = this.dsManage1.ELGASearchDocuments;
                    docus.DefaultView.Sort = "CreationTime desc";
                    this.gridFound.DataSource = docus;
                    this.gridFound.Refresh();
                    foreach (UltraGridRow rGrid in this.gridFound.Rows)
                    {
                        DataRowView v = (DataRowView)rGrid.ListObject;
                        dsManage.ELGASearchDocumentsRow rSelRow = (dsManage.ELGASearchDocumentsRow)v.Row;
                        rGrid.Cells["Storniert"].Value = rSelRow.DocStatus.sEquals("Deprecated", S2Extensions.Enums.eCompareMode.Contains);
                    }

                    this.gridFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokumente gefunden") + " (" + this.gridFound.Rows.Count.ToString() + ")";
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.searchData: " + ex.ToString());
            }
        }

        public bool selectData(bool withMsgBox)
        {
            try
            {
                this.errorProvider1.SetError(this.gridFound, "");
                this.lDocusSelected.Clear();

                foreach (UltraGridRow rGrid in this.gridFound.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow rSelRow = (PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow)v.Row;

                    if ((bool)rGrid.Cells[this.colSelect.Trim()].Value == true)
                    {
                        this.lDocusSelected.Add(rSelRow);
                    }
                }

                if (lDocusSelected.Count == 0)
                {
                    this.errorProvider1.SetError(this.gridFound, "Error");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Dokumente ausgewählt!", "", MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.selectData: " + ex.ToString());
            }
        }

        public PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridFound.ActiveRow == null || this.gridFound.ActiveRow.IsGroupByRow)
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile in der Tabelle ausgewählt!");
                    return null;
                }
                else
                {
                    DataRowView v = (DataRowView)this.gridFound.ActiveRow.ListObject;
                    PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow rSelRow = (PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow)v.Row;
                    return rSelRow;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.getSelectedRow: " + ex.ToString());
            }
        }
          

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.searchData();

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
        private void BtnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.selectData(true))
                {
                    this.abort = false;
                    this.mainWindow.Close();
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

        private void openCDADocument()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                PMDS.Global.db.ERSystem.dsManage.ELGASearchDocumentsRow rSelDocu = this.getSelectedRow(true, ref gridRow);
                if (rSelDocu != null)
                {
                    this.bELGA.openCDADocument(rSelDocu.UniqueID.Trim(), rSelDocu.ELGAPatientLocalID.Trim(), rSelDocu.Stylesheet.Trim(), rSelDocu.TypeFile.Trim(), rSelDocu.Dokument.Trim());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.openCDADocument: " + ex.ToString());
            }
        }


        private void GridFound_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.sEquals(this.colSelect))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFound))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridFound_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFound))
                {
                    if (this.selectData(false))
                    {
                        this.abort = false;
                        this.mainWindow.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnOpenCDADocu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openCDADocument();

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

