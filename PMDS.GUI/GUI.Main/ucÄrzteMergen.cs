using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;




namespace PMDS.GUI.GUI.Main
{



    public partial class ucÄrzteMergen : UserControl
    {

        public bool abort = true;
        public bool MergeOn = false;

        public frmÄrzteMergen mainWindow = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public string colTarget = "Ziel";
        public string colSource = "Quelle";
        
        public class cMerge
        {
            public Nullable<Guid> IDArzt = null;
            public System.Collections.Generic.List<Guid> lstÄrzteSources = new List<Guid>();
        }

        public Infragistics.Win.UltraWinGrid.UltraGridRow prev_gridRowTarget = null;
        public Global.db.ERSystem.dsKlientenliste.AerzteRow prev_rSelArztTarget = null;










        public ucÄrzteMergen()
        {
            InitializeComponent();
        }

        private void ucÄrzteMergen_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                this.mainWindow.CancelButton = this.btnClose;

                this.sqlManange1.initControl();

                this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                this.MergeOn = true;
                this.setUI();
                this.clearData(true);
                this.loadDataTarget();
            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.initControl: " + ex.ToString());
            }
        }

        public void clearData(bool ClearSearch)
        {
            try
            {
                this.dsKlientenlisteTarget.Aerzte.Clear();
                this.gridÄrzteTarget.Refresh();
                this.lblFound.Text = "";

                this.prev_rSelArztTarget = null;
                this.prev_gridRowTarget = null;

                if (ClearSearch)
                {
                    this.txtSearch.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.clearData: " + ex.ToString());
            }
        }

        public void loadDataTarget()
        {
            try
            {
                this.clearData(false);
                this.dsKlientenlisteSource.Aerzte.Clear();
                this.gridÄrzteSource.Refresh();

                this.sqlManange1.getÄrzte(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeÄrzte.All, ref this.dsKlientenlisteTarget, this.txtSearch.Text .Trim());
                this.gridÄrzteTarget.Refresh();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridArztTarget in this.gridÄrzteTarget.Rows)
                {
                    DataRowView v = (DataRowView)rGridArztTarget.ListObject;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rArztTarget = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;

                    cMerge NewMerge = new cMerge();
                    NewMerge.IDArzt = rArztTarget.ID;
                    rGridArztTarget.Tag = NewMerge; 
                }
                
                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsKlientenlisteTarget.Aerzte.Rows.Count.ToString() + "";
            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.loadDataTarget: " + ex.ToString());
            }
        }
        public void loadDataSource(Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArztTarget, Infragistics.Win.UltraWinGrid.UltraGridRow gridRowSelArztTarget)
        {
            try
            {
                this.dsKlientenlisteSource.Aerzte .Clear();
                cMerge Merge = (cMerge)gridRowSelArztTarget.Tag;

                this.sqlManange1.getÄrzte(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeÄrzte.All, ref this.dsKlientenlisteSource, "");
                this.gridÄrzteSource.Refresh();
                System.Collections.Generic.List<Global.db.ERSystem.dsKlientenliste.AerzteRow> lstToDeleteSource = new List<Global.db.ERSystem.dsKlientenliste.AerzteRow>();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridArztSource in this.gridÄrzteSource.Rows)
                {
                    DataRowView v = (DataRowView)rGridArztSource.ListObject;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rArztSource = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;

                    if (rArztSource.ID.Equals(rSelArztTarget.ID))
                    {
                        lstToDeleteSource.Add(rArztSource);
                    }
                    foreach (Guid IDArztSourceSelected in Merge.lstÄrzteSources)
                    {
                        if (rArztSource.ID.Equals(IDArztSourceSelected))
                        {
                            rGridArztSource.Cells[this.colSource].Value = true;
                        }
                    }
                }
                foreach (Global.db.ERSystem.dsKlientenliste.AerzteRow rGridArztQuelleToDelete in lstToDeleteSource)
                {
                    rGridArztQuelleToDelete.Delete();
                }
                this.gridÄrzteSource.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.loadDataSource: " + ex.ToString());
            }
        }

        public void saveSelectedRowsQuelle(Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArztTarget, Infragistics.Win.UltraWinGrid.UltraGridRow gridRowSelArztTarget)
        {
            try
            {
                cMerge MergeTarget = (cMerge)gridRowSelArztTarget.Tag;
                MergeTarget.lstÄrzteSources.Clear();

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridArztSource in this.gridÄrzteSource.Rows)
                {
                    DataRowView v = (DataRowView)rGridArztSource.ListObject;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rArztSource = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;

                    bool bSourceSelected = (bool)rGridArztSource.Cells[this.colSource].Value;
                    if (bSourceSelected)
                    {
                        MergeTarget.lstÄrzteSources.Add(rArztSource.ID);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.saveSelectedRowsQuelle: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                if (this.prev_rSelArztTarget != null)
                {
                    this.saveSelectedRowsQuelle(this.prev_rSelArztTarget, this.prev_gridRowTarget);
                }

                int iCounterÄrzteDeleted = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGridArztTarget in this.gridÄrzteTarget.Rows)
                {
                    DataRowView v = (DataRowView)rGridArztTarget.ListObject;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rArztTarget = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;
                    cMerge MergeTarget = (cMerge)rGridArztTarget.Tag;
                    bool bTargetSelected = (bool)rGridArztTarget.Cells[this.colTarget].Value;
                    if (bTargetSelected)
                    {
                        foreach (Guid IDArztSource in MergeTarget.lstÄrzteSources)
                        {
                            using (PMDS.db.Entities.ERModellPMDSEntities dbUpdate = PMDSBusiness.getDBContext())
                            {
                                Aerzte rAerzteSource = this.PMDSBusiness1.getArzt(IDArztSource, dbUpdate);
                                if (rAerzteSource != null)
                                {
                                    System.Linq.IQueryable<PatientAerzte> tPatientAerzteSource = this.PMDSBusiness1.getPatientÄrtze(IDArztSource, dbUpdate);
                                    System.Linq.IQueryable<RezeptEintrag> tRezeptEintrag = this.PMDSBusiness1.getRezeptEintrag(IDArztSource, dbUpdate);

                                    if (rAerzteSource.IDAdresse != null)
                                    {
                                        Adresse rAdresse = this.PMDSBusiness1.getAdresse(rAerzteSource.IDAdresse.Value, dbUpdate);
                                        dbUpdate.Adresse.Remove(rAdresse);
                                    }
                                    if (rAerzteSource.IDKontakt != null)
                                    {
                                        Kontakt rKontakt = this.PMDSBusiness1.getKontakt(rAerzteSource.IDKontakt.Value, dbUpdate);
                                        dbUpdate.Kontakt.Remove(rKontakt);
                                    }
                                    foreach (PatientAerzte rPatientAerzte in tPatientAerzteSource)
                                    {
                                        rPatientAerzte.IDAerzte = rArztTarget.ID;
                                    }
                                    foreach (RezeptEintrag rRezeptEintrag in tRezeptEintrag)
                                    {
                                        rRezeptEintrag.IDAerzte = rArztTarget.ID;
                                    }
                                    dbUpdate.Aerzte.Remove(rAerzteSource);

                                    dbUpdate.SaveChanges();
                                    iCounterÄrzteDeleted += 1;
                                }
                            }
                        }
                    }
                }

                if (iCounterÄrzteDeleted > 0)
                {
                    this.loadDataTarget();
                }
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterÄrzteDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(". Ärzte gelöscht bzw. zusammengeführt!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS"), MessageBoxButtons.OK, true);
                return true;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.saveData: " + ex.ToString());
            }
        }

        public void setUI()
        {
            try
            {
                if (this.MergeOn)
                    this.MergeOn = false;
                else
                    this.MergeOn = true;

                this.gridÄrzteSource.Visible = this.MergeOn;
                this.btnSave.Visible = this.MergeOn;
                this.gridÄrzteTarget.DisplayLayout.Bands[0].Columns[this.colTarget.Trim()].Hidden = !this.MergeOn;
                this.gridÄrzteTarget.DisplayLayout.Bands[0].Columns[this.colTarget.Trim()].Header.VisiblePosition = 0;
                this.gridÄrzteSource.DisplayLayout.Bands[0].Columns[this.colSource.Trim()].Header.VisiblePosition = 0;

                this.gridÄrzteSource.Visible = this.MergeOn;
                this.btnSave.Visible = this.MergeOn;
                this.btnClose.Visible = this.MergeOn;

                if (this.MergeOn)
                {
                    this.mainWindow.Width = 1050;
                    this.gridÄrzteTarget.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Ziel");
                    this.gridÄrzteSource.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Quelle");
                }
                else
                {
                    this.mainWindow.Width = 546;
                    this.gridÄrzteTarget.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Ziel");
                    this.gridÄrzteSource.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Quelle");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.setUI: " + ex.ToString());
            }
        }

        public Global.db.ERSystem.dsKlientenliste.AerzteRow getSelectedRowArztTarget(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridÄrzteTarget.ActiveRow != null)
                {
                    if (this.gridÄrzteTarget.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridÄrzteTarget.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.AerzteRow rSelRow = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;
                        gridRow = this.gridÄrzteTarget.ActiveRow;
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
                throw new Exception("ucÄrzteMergen.getSelectedRowArztTarget: " + ex.ToString());
            }
        }
        public Global.db.ERSystem.dsKlientenliste.AerzteRow getSelectedÄrzteSource(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridÄrzteSource.ActiveRow != null)
                {
                    if (this.gridÄrzteSource.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridÄrzteSource.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.AerzteRow rSelRow = (Global.db.ERSystem.dsKlientenliste.AerzteRow)v.Row;
                        gridRow = this.gridÄrzteSource.ActiveRow;
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
                throw new Exception("ucÄrzteMergen.getSelectedÄrzteSource: " + ex.ToString());
            }
        }

        public bool editArzt(Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArzt)
        {
            try
            {
                PMDS.DB.Global.DBAerzte DBAerzte1 = new DB.Global.DBAerzte();
                PMDS.Global.db.Global.dsAerzte dsAerzte1 = DBAerzte1.AerzteByID(rSelArzt.ID);
                PMDS.Global.db.Global.dsAerzte.AerzteRow rArztFromDB = (PMDS.Global.db.Global.dsAerzte.AerzteRow)dsAerzte1.Aerzte.Rows[0];

                //PMDS.BusinessLogic.Aerzte Aerzte = new BusinessLogic.Aerzte();
                PMDS.BusinessLogic.Arzt Arzt = new PMDS.BusinessLogic.Arzt(rSelArzt.ID, rSelArzt.IDAdresse, rSelArzt.IDKontakt);
                //Aerzte._ListAerzte.Add(Arzt);
                //PMDS.BusinessLogic.Arzt Arzt = Aerzte.GetArzt(rSelArzt.ID);

                frmArzt frm = new frmArzt();
                frm.AllowEdit(ENV.HasRight(UserRights.KlientenAktStammdatenAendern));
                frm.Arzt = Arzt;
                frm.AerzteRow = rArztFromDB;
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    DBAerzte1.daAerzteByID.Update(dsAerzte1.Aerzte);
                    Arzt.Adresse.Write();
                    Arzt.Kontakt.Write();

                    Global.db.ERSystem.dsKlientenliste dsKlientenlisteRead = new Global.db.ERSystem.dsKlientenliste();
                    Global.db.ERSystem.sqlManange sqlManangeRead = new Global.db.ERSystem.sqlManange();
                    sqlManangeRead.initControl();
                    sqlManangeRead.getÄrzte(rSelArzt.ID, Global.db.ERSystem.sqlManange.eTypeÄrzte.ID, ref dsKlientenlisteRead, "");
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rArztDB = (Global.db.ERSystem.dsKlientenliste.AerzteRow)dsKlientenlisteRead.Aerzte.Rows[0];

                    rSelArzt.Nachname = rArztDB.Nachname;
                    rSelArzt.Vorname = rArztDB.Vorname;
                    rSelArzt.Fachrichtung = rArztDB.Fachrichtung;
                    rSelArzt.Titel = rArztDB.Titel;

                    this.gridÄrzteTarget.Refresh();
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.getSelectedRowArzt: " + ex.ToString());
            }
        }



        private void gridÄrzte_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colTarget.Trim().ToLower()))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridÄrzte_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridÄrzteTarget))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRowTarget = null;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArztTarget = this.getSelectedRowArztTarget(false, ref gridRowTarget);
                    if (rSelArztTarget != null)
                    {
                        if (this.MergeOn)
                        {
                            if (this.prev_rSelArztTarget != null)
                            {
                                this.saveSelectedRowsQuelle(this.prev_rSelArztTarget, this.prev_gridRowTarget); 
                            }

                            this.loadDataSource(rSelArztTarget, gridRowTarget);

                            this.prev_gridRowTarget = gridRowTarget;
                            this.prev_rSelArztTarget = rSelArztTarget;
                        }
                        else
                        {
                            this.dsKlientenlisteSource.Aerzte.Clear();
                            this.gridÄrzteSource.Refresh();
                        }
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
        private void gridÄrzte_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridÄrzteTarget))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArzt = this.getSelectedRowArztTarget(false, ref gridRow);
                    if (rSelArzt != null)
                    {
                        this.editArzt(rSelArzt);
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
        private void gridÄrzteSource_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridÄrzteSource))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArzt = this.getSelectedÄrzteSource(false, ref gridRow);
                    if (rSelArzt != null)
                    {
                        this.editArzt(rSelArzt);
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

        private void gridMergeÄrzte_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colSource.Trim().ToLower()))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMergeÄrzte_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridÄrzteSource))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.AerzteRow rSelArzt = this.getSelectedÄrzteSource(false, ref gridRow);
                    if (rSelArzt != null)
                    {
                        //if (gridÄrzteSource.ActiveCell != null)
                        //{
                        //    if (gridÄrzteSource.ActiveCell.Column.ToString().Trim().ToLower().Equals(this.colQuelle.Trim().ToLower()))
                        //    {
                        //        bool vZielMerge = (bool)gridÄrzteSource.ActiveCell.Value;
                        //        if (vZielMerge = true)
                        //        {
                        //            foreach (Global.db.ERSystem.dsKlientenliste.AerzteRow rMergeArztAct in this.dsKlientenlisteSource.Aerzte)
                        //            {
                        //                if (!rMergeArztAct.ID.Equals(gridÄrzteSource.ActiveCell.Row.Cells["ID"].Value))
                        //                {
                        //                    //gridMergeÄrzte.ActiveCell.Row.Cells[this.dsKlientenliste1.ÄrzteMerge.ZielColumn.ColumnName].Value = false;
                        //                    //rMergeArztAct.Ziel = false;
                        //                }
                        //                else
                        //                {
                        //                    string xy = "";
                        //                }
                        //                this.gridÄrzteSource.Refresh();
                        //            }
                        //        }
                        //    }
                        //}
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



        private void btnZusammenführen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setUI();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadDataTarget();
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
