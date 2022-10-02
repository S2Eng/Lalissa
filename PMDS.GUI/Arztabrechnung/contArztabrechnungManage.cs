using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.ERSystem;
using PMDS.Global;
using PMDS.db.Entities;
using PMDS.DB;
using Infragistics.Win.UltraWinListView;
//lthArztabrechnung   neues Form integrieren in PMDS.int (Neuer Ordner Arzabrechnung in PMDS.GUI)



namespace PMDS.GUI.Arztabrechnung
{


    public partial class contArztabrechnungManage : UserControl
    {
        
        public frmArztabrechnungManage mainWindow = null;
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.db.Entities.ERModellPMDSEntities db = null;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public enum eTypeAction
        {
            deleteRows = 0,

        }





        public contArztabrechnungManage()
        {
            InitializeComponent();
        }

        private void contArztabrechnungManage_Load(object sender, EventArgs e)
        {
            try
            {

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
                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                this.sqlManange1.initControl();

                this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, false, eTypePatientenUserPickerChanged.none);
                this.contPatientUserPicker1.selectUserPatient(null);

                this.db = PMDSBusiness.getDBContext();
                this.clearUI();
                this.setUIGrid();
                this.loadCombos();

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.initControl: " + ex.ToString());
            }
        }
        public void setUIGrid()
        {
            try
            {
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.DatumColumn.ColumnName].Header.VisiblePosition = 0;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns["Patient"].Header.VisiblePosition = 1;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns["Benutzer"].Header.VisiblePosition = 2;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.Leistung1Column.ColumnName].Header.VisiblePosition = 3;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.Leistung2Column.ColumnName].Header.VisiblePosition = 4;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.Leistung3Column.ColumnName].Header.VisiblePosition = 5;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.AnmerkungColumn.ColumnName].Header.VisiblePosition = 6;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.KrankenkasseColumn.ColumnName].Header.VisiblePosition = 7;
                this.gridArztabrechnung.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Arztabrechnung.SVNrColumn.ColumnName].Header.VisiblePosition = 8;
            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.clearUI: " + ex.ToString());
            }
        }
        public void clearUI()
        {
            try
            {
                this.txtLeistungen.Text = "";
                this.txtAnmerkung.Text = "";

                this.cboBenutzer.Value = null;
                this.contPatientUserPicker1.selectUserPatient(null);

                DateTime datVon = DateTime.Now.AddDays(-1);
                this.dteVon.Value = datVon.Date;
                this.dteBis.Value = null;              
                
            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.clearUI: " + ex.ToString());
            }
        }
        public void loadCombos()
        {
            try
            {
                //this.dsKlientenliste1.Clear();
                //this.sqlManange1.getPatientenStart(Settings.USERID, 0, System.Guid.Empty, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);
                //foreach (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient in dsKlientenliste1.vKlientenliste)
                //{
                //    Infragistics.Win.ValueListItem itm = this.cboPatient.Items.Add(rKlient.IDKlient, rKlient.PatientName.Trim());
                //}

                this.cboBenutzer.Items.Clear();
                IQueryable<Benutzer> tBenutzer = db.Benutzer.OrderBy(p => p.Vorname).OrderBy(p => p.Nachname);
                if (tBenutzer.Count() > 0)
                {
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {
                        bool bArztabrechnungErfassung = ENV.HasRightUser(UserRights.ArztabrechnungErfassung, rBenutzer.ID);               //lthArztabrechnung  
                        //if (rBenutzer.ArztabrechnungJN)
                        if (bArztabrechnungErfassung)
                        {
                            Infragistics.Win.ValueListItem itm = this.cboBenutzer.Items.Add(rBenutzer.ID, rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " [" + rBenutzer.Benutzer1.Trim() + "]");
                        }
                    }
                } 

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.loadCombos: " + ex.ToString());
            }
        }
        public void loadData()
        {
            try
            {
                if (this.cboBenutzer.Value != null && this.cboBenutzer.Value.GetType() != typeof(Guid))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Falsche Eingabe!", "", MessageBoxButtons.OK);
                    return;
                }


                this.dsKlientenliste1.Clear();

                Nullable<Guid> IDBenutzer = null;
                if (this.cboBenutzer.Value != null && this.cboBenutzer.Value.GetType() == typeof(Guid))
                {
                    IDBenutzer = (Guid)this.cboBenutzer.Value;
                }
                
                Nullable<Guid> IDPatient = null;
                System.Collections.Generic.List<Guid> lstSelectedUsersPatients = this.contPatientUserPicker1.contSelectPatienten.getList();
                if (lstSelectedUsersPatients.Count == 1)
                {
                    IDPatient = lstSelectedUsersPatients[0];
                }

                Nullable<DateTime> dVon = null;
                if (this.dteVon.Value != null)
                {
                    dVon = this.dteVon.DateTime;
                }

                Nullable<DateTime> dBis = null;
                if (this.dteBis.Value != null)
                {
                    dBis = this.dteBis.DateTime;
                }

                string sLeistungen = "";
                if (this.txtLeistungen.Text.Trim() != "")
                {
                    sLeistungen = this.txtLeistungen.Text.Trim();
                }

                string sAnmerkungen = "";
                if (this.txtAnmerkung.Text.Trim() != "")
                {
                    sAnmerkungen = this.txtAnmerkung.Text.Trim();
                }

                //db.Configuration.LazyLoadingEnabled = false;
                this.sqlManange1.getArztabrechnung2(this.dsKlientenliste1, IDBenutzer, sAnmerkungen, sLeistungen, dVon, dBis, IDPatient, null, "", null);
                foreach (UltraGridRow rowGrid in this.gridArztabrechnung.Rows)
                {
                    dsKlientenliste.ArztabrechnungRow rArztabrechnung = (dsKlientenliste.ArztabrechnungRow)((System.Data.DataRowView)rowGrid.ListObject).Row;

                    var rPatient = (from p in db.Patient
                               where p.ID == rArztabrechnung.IDPatient
                                    select new
                               {
                                    p.ID,
                                    p.Nachname,
                                    p.Vorname
                               }).First();

                    //PMDS.db.Entities.Patient rPatient = this.b.getPatient(rArztabrechnung.IDPatient, this.db);
                    rowGrid.Cells["Patient"].Value = rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim();

                    var rBenutzer = (from b in db.Benutzer
                                    where b.ID == rArztabrechnung.IDBenutzer
                                    select new
                                    {
                                        b.ID,
                                        b.Nachname,
                                        b.Vorname
                                    }).First();

                    //PMDS.db.Entities.Benutzer rBenutzer = this.b.getUser(rArztabrechnung.IDBenutzer, this.db);
                    rowGrid.Cells["Benutzer"].Value = rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim();
                }

                this.gridArztabrechnung.Refresh();
                this.lblFound.Text = "Gefunden: " + this.gridArztabrechnung.Rows.Count.ToString() + "";

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.loadData: " + ex.ToString());
            }
        }
        public void openDetail(bool IsNew, Nullable<Guid> IDArztabrechnung)
        {
            try
            {
                frmArztabrechnungDetail frmArztabrechnungDetail1 = new Arztabrechnung.frmArztabrechnungDetail();
                if (IsNew)
                {
                    Nullable<Guid> IDPatientSelected = null;
                    System.Collections.Generic.List<Guid> lstSelectedUsersPatients = this.contPatientUserPicker1.contSelectPatienten.getList();
                    if (lstSelectedUsersPatients.Count == 1)
                    {
                        IDPatientSelected = lstSelectedUsersPatients[0];
                    }

                    Guid IDUserTmp;
                    if (this.cboBenutzer.Value != null)
                    {
                        IDUserTmp = (Guid)this.cboBenutzer.Value;
                    }
                    else
                    {
                        IDUserTmp = ENV.USERID;
                    }
                    frmArztabrechnungDetail1.initControl(IsNew, null, IDPatientSelected, IDUserTmp, true);
                }
                else
                {
                    frmArztabrechnungDetail1.initControl(IsNew, IDArztabrechnung, null, System.Guid.Empty, true);
                }

                frmArztabrechnungDetail1.ShowDialog(this);
                if (!frmArztabrechnungDetail1.contArztabrechnung1.abort)
                {
                    this.loadData();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.openDetail: " + ex.ToString());
            }
        }
        public void addNew()
        {
            try
            {
                this.openDetail(true, null);

            }
            catch (Exception ex)
            {
                throw new Exception("contArztabrechnungManage.addNew: " + ex.ToString());
            }
        }
        public void doAction(eTypeAction TypeAction, bool msgBox)
        {
            try
            {
                DialogResult res = DialogResult.Yes;
                if (msgBox)
                {                                         
                    if (TypeAction == eTypeAction.deleteRows)
                    {
                        res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Aktivität wirklich durchführen?", "", MessageBoxButtons.YesNo);
                        if (res == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        throw new Exception("doAction: TypeAction '" + TypeAction.ToString() + "' now allowed!");
                    }
                }
                
                if (res == DialogResult.Yes)
                {
                    UltraGridRow[] arrSelected = PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(this.gridArztabrechnung, true);
                    int anzDel = 0;
                    foreach (UltraGridRow rToDel in arrSelected)
                    {
                        dsKlientenliste.ArztabrechnungRow r = (dsKlientenliste.ArztabrechnungRow)((System.Data.DataRowView)rToDel.ListObject).Row;
                        if (TypeAction == eTypeAction.deleteRows)
                        {
                            this.sqlManange1.deleteArztabrechnung(r.ID);
                            anzDel += 1;
                        }
                        else
                        {
                            throw new Exception("doAction: TypeAction '" + TypeAction.ToString() + "' now allowed!");
                        }
                    }

                    if (TypeAction == eTypeAction.deleteRows)
                    {
                        this.loadData();
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox(anzDel.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(". Zeile/n gelöscht!"), "", MessageBoxButtons.OK, true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.doAction: " + ex.ToString());
            }
        }


        public dsKlientenliste.ArztabrechnungRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridArztabrechnung.ActiveRow != null)
                {
                    if (this.gridArztabrechnung.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridArztabrechnung.ActiveRow.ListObject;
                        dsKlientenliste.ArztabrechnungRow rSelRow = (dsKlientenliste.ArztabrechnungRow)v.Row;
                        return rSelRow;
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
                throw new Exception("ucFortbildungenList.getSelectedRow: " + ex.ToString());
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addNew();
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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.doAction(eTypeAction.deleteRows, true);

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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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



        private void gridFortbildungen_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                e.Cell.Activation = Activation.NoEdit;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridFortbildungen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridArztabrechnung))
                {

                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void lblResetSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.clearUI();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void gridFortbildungen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridArztabrechnung))
                {
                    UltraGridRow rGridSel = null;
                    dsKlientenliste.ArztabrechnungRow rSelArztabrechnung = this.getSelectedRow(true, ref rGridSel);
                    if (rSelArztabrechnung != null)
                    {
                        this.openDetail(false, rSelArztabrechnung.ID);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridArztabrechnung_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void cboBenutzer_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


    }

}
