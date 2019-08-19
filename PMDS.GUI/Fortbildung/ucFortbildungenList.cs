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

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.Engines;




namespace PMDS.GUI.Fortbildung
{



    public partial class ucFortbildungenList : UserControl
    {

        public Nullable<Guid> _IDVeranstalter;
        public Nullable<Guid> _IDBenutzer;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public bool Isinitialized = false;

        public ucVerwaltungFortbildungen mainWindow = null;







        public ucFortbildungenList()
        {
            InitializeComponent();
        }

        private void ucFortbildungenList_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                    this.clearUI();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.mainWindow.ucFortbildungenMain1.tabMain.ActiveTab = this.mainWindow.ucFortbildungenMain1.tabMain.Tabs[0];
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerList1.clearUI();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerDetails1.clearUI2();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungDetails1.clearUI();
                this.mainWindow.ucFortbildungenMain1.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDVeranstalter, Nullable<Guid> IDBenutzer, eTypeFortbildungenUI TypeFortbildungenUI, Nullable<Guid> IDFortbildungToLoad)
        {
            try
            {
                this._IDBenutzer = IDBenutzer;
                this._IDVeranstalter = IDVeranstalter;
                this.tblFortbildungenBindingSource.Clear();
                this.clearUI();
                if (TypeFortbildungenUI == eTypeFortbildungenUI.Veranstalter)
                {
                    this.btnAdd.Visible = true;
                    this.lblSearch.Visible = true;
                    this.txtSearchVeranstalter.Visible = true;
                }
                else if (TypeFortbildungenUI == eTypeFortbildungenUI.Benutzer)
                {
                    this.btnAdd.Visible = true;
                    this.lblSearch.Visible = true;
                    this.txtSearchVeranstalter.Visible = true;
                }
                else
                {
                    this.btnAdd.Visible = false;
                    this.lblSearch.Visible = true;
                    this.txtSearchVeranstalter.Visible = true;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    List<tblFortbildungen> tFortbildungen = null;
                    if (TypeFortbildungenUI == eTypeFortbildungenUI.Benutzer)
                    {
                        tFortbildungen = this.b.loadAllFortbildungenBenutzer(IDBenutzer, db);
                    }
                    else
                    {
                        tFortbildungen = this.b.loadAllFortbildungen(IDVeranstalter, db);
                    }
                    //foreach (tblFortbildungen rFortbildungen in tFortbildungen)
                    //{
                    //    this.tblFortbildungenBindingSource.Add(rFortbildungen);
                    //}
                    this.gridFortbildungen.DataSource = tFortbildungen.ToList();
                }
                this.gridFortbildungen.Refresh();

                this.gridFortbildungen.Selected.Rows.Clear();
                this.gridFortbildungen.ActiveRow = null;

                if (IDFortbildungToLoad != null)
                {
                    foreach (UltraGridRow rGridRow in this.gridFortbildungen.Rows)
                    {
                        tblFortbildungen rSelFortbildung = (tblFortbildungen)rGridRow.ListObject;
                        if (rSelFortbildung.ID.Equals(IDFortbildungToLoad))
                        {
                            this.loadFortbildung(rSelFortbildung.ID, rSelFortbildung.IDVeranstalter, false);
                            this.gridFortbildungen.ActiveRow = rGridRow;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.loadData: " + ex.ToString());
            }
        }
        public void loadFortbildung(Nullable<Guid> IDFortbildungToLoad, Nullable<Guid> IDVeranstalter, bool IsNew)
        {
            try
            {
                this.mainWindow.ucFortbildungenMain1.tabMain.ActiveTab = this.mainWindow.ucFortbildungenMain1.tabMain.Tabs[0];
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerList1.clearUI();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerDetails1.clearUI2();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungDetails1.clearUI();
                this.mainWindow.ucFortbildungenMain1.Visible = true;

                if (IDFortbildungToLoad != null)
                {
                    this.mainWindow.ucFortbildungenMain1.ucFortbildungDetails1.loadData(IDFortbildungToLoad, (Guid)IDVeranstalter, IsNew, this.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this.IsReadOnly());
                    this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerList1.loadUsers(IDFortbildungToLoad, this.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this._IDBenutzer);
                }
                else
                {
                    this.mainWindow.ucFortbildungenMain1.tabMain.SelectedTab = this.mainWindow.ucFortbildungenMain1.tabMain.Tabs[0];
                    this.mainWindow.ucFortbildungenMain1.ucFortbildungDetails1.loadData(null, (Guid)IDVeranstalter, true, this.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this.IsReadOnly());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.loadFortbildung: " + ex.ToString());
            }
        }

        public tblFortbildungen getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridFortbildungen.ActiveRow != null)
                {
                    if (this.gridFortbildungen.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Fortbildung ausgewählt!");
                        return null;
                    }
                    else
                    {
                        tblFortbildungen rSelRow = (tblFortbildungen)this.gridFortbildungen.ActiveRow.ListObject;
                        gridRow = this.gridFortbildungen.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Fortbildung ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.getSelectedRow: " + ex.ToString());
            }
        }

        public void setFilter()
        {
            try
            {
                this.funct1.clearAllFilter(this.gridFortbildungen);
                if (this.txtSearchVeranstalter.Text.Trim() != "")
                {
                    this.funct1.setFilter("Bezeichnung",
                                            FilterLogicalOperator.Or, this.txtSearchVeranstalter.Text.Trim(),
                                            FilterComparisionOperator.StartsWith, this.gridFortbildungen,
                                            this.gridFortbildungen.DisplayLayout.Bands[0].Index);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.setFilter: " + ex.ToString());
            }
        }
        public bool IsReadOnly()
        {
            try
            {
                if (this.mainWindow.ucVeranstalter1._TypeFortbildungenUI == eTypeFortbildungenUI.AlleFortbildungenxy)
                {
                    return true;
                }
                else if (this.mainWindow.ucVeranstalter1._TypeFortbildungenUI == eTypeFortbildungenUI.Benutzer)
                {
                    return true;
                }
                else if (this.mainWindow.ucVeranstalter1._TypeFortbildungenUI == eTypeFortbildungenUI.Veranstalter)
                {
                    return false;
                }
                else
                {
                    throw new Exception("_TypeFortbildungenUI '" + this.mainWindow.ucVeranstalter1._TypeFortbildungenUI.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.IsReadOnly: " + ex.ToString());
            }
        }


        public void add(Guid IDVeranstalter)
        {
            try
            {
                this.loadFortbildung(null, IDVeranstalter, true);

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.add: " + ex.ToString());
            }
        }
        public void delete(tblFortbildungen rSelFortbildung)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Fortbildung wirklich löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<tblFortbildungen> tFortbildungen = db.tblFortbildungen.Where(p => p.ID == rSelFortbildung.ID);
                        tblFortbildungen rFortbildungen = tFortbildungen.First();
                        db.tblFortbildungen.Remove(rFortbildungen);
                        db.SaveChanges();
                        this.loadData(this._IDVeranstalter, this._IDBenutzer, this.mainWindow.ucVeranstalter1._TypeFortbildungenUI, null);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenList.delete: " + ex.ToString());
            }
        }





        private void gridFortbildungen_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {

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
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFortbildungen))
                {
                    UltraGridRow rGridSel = null;
                    tblFortbildungen rSelFortbildung = this.getSelectedRow(false, ref rGridSel);
                    if (rSelFortbildung != null)
                    {
                        this.loadFortbildung(rSelFortbildung.ID, rSelFortbildung.IDVeranstalter, false);
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
        private void gridFortbildungen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridFortbildungen))
                {

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

        private void txtSearchVeranstalter_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.txtSearchVeranstalter.Focused)
                {
                    this.setFilter();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.setFilter();
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDVeranstalterSel = this.mainWindow.ucVeranstalter1.getSelectedVeranstalter(true);
                if (IDVeranstalterSel != null)
                {
                    this.add((Guid)IDVeranstalterSel);
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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                tblFortbildungen rSelFortbildung = this.getSelectedRow(true, ref rGridSel);
                if (rSelFortbildung != null)
                {
                    this.delete(rSelFortbildung);
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
