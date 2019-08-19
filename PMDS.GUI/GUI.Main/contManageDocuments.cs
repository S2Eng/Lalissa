using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using Infragistics.Win.UltraWinListView;
using PMDS.DB;
using Infragistics.Win.UltraWinGrid;
using System.IO;




namespace PMDS.GUI.GUI.Main
{


    public partial class contManageDocuments : UserControl
    {
        public bool abort = true;

        public frmManageDocuments mainForm = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.Global.db.ERSystem.UISitemaps UISitemaps1 = new Global.db.ERSystem.UISitemaps();

        public UltraListViewItem prev_itmAbteilung = null;
        public Infragistics.Win.UltraWinGrid.UltraGridRow prev_gridRowDokument = null;









        public contManageDocuments()
        {
            InitializeComponent();
        }

        private void contManageDocuments_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.mainForm.CancelButton = this.btnClose;

                this.sqlManange1.initControl();
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                this.auswahlGruppeComboMulti1.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, true, -1, -100000, false);
                //this.gridDocuments.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Textbausteine.KurzbezeichnungColumn.ColumnName].Width = 580;

                this.loadAlleAbteilungen();
                this.loadValueListDocuments();
                this.loadDataGrid();

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.initControl: " + ex.ToString());
            }
        }

        public void loadValueListDocuments()
        {
            try
            {
                this.gridDocuments.DisplayLayout.ValueLists["Documents"].ValueListItems.Clear();
                if (ENV.PathDokumente.Trim() != "" && System.IO.Directory.Exists(ENV.PathDokumente.Trim()))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(ENV.PathDokumente.Trim());
                    foreach (FileInfo fileInfo in dirInfo.GetFiles())
                    {
                        if (fileInfo.Extension.Trim().ToLower().Equals((".pdf").Trim().ToLower()))
                        {
                            string FileNameShort = fileInfo.Name;
                            Infragistics.Win.ValueListItem itm = this.gridDocuments.DisplayLayout.ValueLists["Documents"].ValueListItems.Add(FileNameShort, FileNameShort);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.loadValueListDocuments: " + ex.ToString());
            }
        }

        public void loadAlleAbteilungen()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.lvAbteilungen.Items.Clear();
                    System.Linq.IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = this.PMDSBusiness1.getAllAbteilungen(ENV.IDKlinik, db);
                    foreach (PMDS.db.Entities.Abteilung rAbteilung in tAbteilung)
                    {
                        UltraListViewItem listItem = new UltraListViewItem(rAbteilung.Bezeichnung.Trim(), null, null);
                        listItem.Key = rAbteilung.ID.ToString();
                        listItem.Tag = rAbteilung.ID;
                        listItem.CheckState = CheckState.Unchecked;
                        this.lvAbteilungen.Items.Add(listItem);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.loadAlleAbteilungen: " + ex.ToString());
            }
        }

        public void clearData()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.gridDocuments.Refresh();

                this.dsDokumente2Abteilungen1.Clear();
                this.setAbteilungen(false);
                this.auswahlGruppeComboMulti1.clearSelectedNodes();

                this.prev_gridRowDokument = null;
                this.prev_itmAbteilung = null;
                this.lvAbteilungen.ActiveItem = null;

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.clearData: " + ex.ToString());
            }
        }
        public void loadDataGrid()
        {
            try
            {
                this.clearData();
                this.dsKlientenliste1.Clear();
                this.sqlManange1.getDokumente2(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeDokumente2.All, ref this.dsKlientenliste1, "");
                this.gridDocuments.Refresh();

                this.gridDocuments.ActiveRow = null;

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.loadDataGrid: " + ex.ToString());
            }
        }


        public void setAbteilungen(bool bOn)
        {
            try
            {
                foreach (UltraListViewItem itm in this.lvAbteilungen.Items)
                {
                    if (bOn)
                    {
                        itm.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        itm.CheckState = CheckState.Unchecked;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.setAbteilungen: " + ex.ToString());
            }
        }


        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.gridDocuments, "");
            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.validateData: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                this.ClearErrorProvider();

                foreach (UltraGridRow r in this.gridDocuments .Rows)
                {
                    Global.db.ERSystem.dsKlientenliste.Dokumente2Row rDokument = (Global.db.ERSystem.dsKlientenliste.Dokumente2Row)((System.Data.DataRowView)r.ListObject).Row;
                    if (rDokument.Bezeichnung.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.gridDocuments, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                        this.gridDocuments.ActiveRow = r;
                        return false;
                    }
                    if (rDokument.DokumentenName.Trim() == "")
                    {
                        this.errorProvider1.SetError(this.gridDocuments, "Error");
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dokumentenname: Es wurde kein Name angegeben!", "", MessageBoxButtons.OK);
                        this.gridDocuments.ActiveRow = r;
                        return false;
                    }
                    //if (rDokument.Abteilungen.Trim() == "")
                    //{
                    //    this.errorProvider1.SetError(this.gridDocuments, "Error");
                    //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilungen: Es wurde kein Abteilung ausgewählt!", "", MessageBoxButtons.OK);
                    //    this.gridDocuments.ActiveRow = r;
                    //    return false;
                    //}
                    //if (rDokument.Benutzergruppen.Trim() == "")
                    //{
                    //    this.errorProvider1.SetError(this.gridDocuments, "Error");
                    //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzergruppen: Es wurde keine Benutzergruppen angegeben!", "", MessageBoxButtons.OK);
                    //    this.gridDocuments.ActiveRow = r;
                    //    return false;
                    //}

                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (this.prev_itmAbteilung != null)
                {
                    this.saveBenutzergruppen(this.prev_itmAbteilung);
                }
                if (this.prev_gridRowDokument != null)
                {
                    DataRowView v = (DataRowView)this.prev_gridRowDokument.ListObject;
                    if (v != null)
                    {
                        Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelRow = (Global.db.ERSystem.dsKlientenliste.Dokumente2Row)v.Row;
                        this.saveAbteilungen(rSelRow);
                    }
                    else
                    {
                        string xy = "";
                    }
                }

                if (!this.validateData())
                {
                    return false;
                }

                this.sqlManange1.daDokumente2.Update(this.dsKlientenliste1.Dokumente2);
                this.loadDataGrid();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.saveData: " + ex.ToString());
            }
        }

        public void addRow()
        {
            try
            {
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                Global.db.ERSystem.dsKlientenliste.Dokumente2Row rNew = this.sqlManange1.addNewRowDokumente2(ref this.dsKlientenliste1, rUsr.Benutzer1.Trim());

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.addRow: " + ex.ToString());
            }
        }
        public void deleteRow()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDocument = this.getSelectedRow(true, ref gridRow);
                if (rSelDocument != null)
                {
                    rSelDocument.Delete();
                    this.gridDocuments.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.deleteRow: " + ex.ToString());
            }
        }

        public Global.db.ERSystem.dsKlientenliste.Dokumente2Row getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridDocuments.ActiveRow != null)
                {
                    if (this.gridDocuments.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridDocuments.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelRow = (Global.db.ERSystem.dsKlientenliste.Dokumente2Row)v.Row;
                        gridRow = this.gridDocuments.ActiveRow;
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
                throw new Exception("contManageDocuments.getSelectedRow: " + ex.ToString());
            }
        }


        private void gridDocuments_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                e.DisplayPromptMsg = false;
                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen sie den/die Datensätz/e wirklich löschen?", "Löschen", MessageBoxButtons.YesNo) != DialogResult.Yes)
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

        private void gridDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDocuments))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument = this.getSelectedRow(false, ref gridRow);
                    if (rSelDokument != null)
                    {
                        if (this.prev_itmAbteilung != null)
                        {
                            this.saveBenutzergruppen(this.prev_itmAbteilung);
                        }
                        if (this.prev_gridRowDokument != null)
                        {
                            if (this.prev_gridRowDokument.ListObject != null)
                            {
                                DataRowView v = (DataRowView)this.prev_gridRowDokument.ListObject;
                                Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelRow = (Global.db.ERSystem.dsKlientenliste.Dokumente2Row)v.Row;
                                this.saveAbteilungen(rSelRow);
                            }
                        }
                        this.loadAbteilungen(rSelDokument);
                        this.prev_gridRowDokument = gridRow;
                        this.prev_itmAbteilung = null;
                        this.lvAbteilungen.ActiveItem = null;
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
        private void gridDocuments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDocuments))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument = this.getSelectedRow(false, ref gridRow);
                    if (rSelDokument != null)
                    {
                        //this.addEditRow(false, rSelDokument);
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRow();
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.deleteRow();
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
                this.mainForm.Close();
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
        private void neuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadDataGrid();

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

        private void lvAbteilungen_ItemActivated(object sender, ItemActivatedEventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument = this.getSelectedRow(false, ref gridRow);
                if (rSelDokument != null)
                {
                    if (this.prev_itmAbteilung != null)
                    {
                        this.saveAbteilung(this.prev_itmAbteilung, rSelDokument);
                        this.saveBenutzergruppen(this.prev_itmAbteilung);
                    }
                    this.loadBenutzergruppen(e.Item, rSelDokument);
                    this.prev_itmAbteilung = e.Item;
                }
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridDocuments_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsKlientenliste1.Dokumente2.BezeichnungColumn.ColumnName.Trim().ToLower()) ||
                    e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsKlientenliste1.Dokumente2.DokumentenNameColumn.ColumnName.Trim().ToLower()))
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }



        public void loadAbteilungen(Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument)
        {
            try
            {
                this.dsDokumente2Abteilungen1.Clear();
                this.setAbteilungen(false);
                this.auswahlGruppeComboMulti1.clearSelectedNodes();

                if (rSelDokument.Abteilungen.Trim() != "")
                {
                    this.dsDokumente2Abteilungen1.ReadXml(new StringReader(rSelDokument.Abteilungen.Trim()));

                    Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[] arrAbteilungen = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[])this.dsDokumente2Abteilungen1.Abteilungen.Select("", "");
                    foreach (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung in arrAbteilungen)
                    {
                        foreach (UltraListViewItem itm in this.lvAbteilungen.Items)
                        {
                            if (rAbteilung.IDAbteilung.Equals(new Guid(itm.Key.Trim())))
                            {
//                                itm.CheckState = CheckState.Checked;
                            }
                        }
                    } 
                }

                this.dsDokumente2Abteilungen1.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.loadAbteilungen: " + ex.ToString());
            }
        }
        public void saveAbteilungen(Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument)
        {
            try
            {
                System.IO.StringWriter writer = new System.IO.StringWriter();
                this.dsDokumente2Abteilungen1.WriteXml(writer);
                rSelDokument.Abteilungen = writer.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.saveAbteilungen: " + ex.ToString());
            }
        }
        public void saveAbteilung(UltraListViewItem itm, Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument)
        {
            try
            {
        //        this.auswahlGruppeComboMulti1.clearSelectedNodes();

                Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[] arrAbteilungen = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[])this.dsDokumente2Abteilungen1.Abteilungen.Select("IDAbteilung='" + itm.Key.ToString() + "'", "");
                if (itm.IsSelected == true)
                {
                    Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung = null;
                    if (arrAbteilungen.Length == 0)
                    {
                        rAbteilung = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow)this.dsDokumente2Abteilungen1.Abteilungen.NewRow();
                        rAbteilung.IDAbteilung = new Guid(itm.Key.ToString());
                        this.dsDokumente2Abteilungen1.Abteilungen.Rows.Add(rAbteilung);
                    }
                    else if (arrAbteilungen.Length == 1)
                    {
                        rAbteilung = arrAbteilungen[0];
                    }
                    else if (arrAbteilungen.Length > 1)
                    {
                        throw new Exception("saveAbteilung: arrAbteilungen.Length>1 for IDAbteilung '" + itm.Key.ToString() + "'!");
                    }
                }
                else
                {
                    if (arrAbteilungen.Length > 0)
                    {
                        System.Collections.Generic.List<Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow> lstToDelete = new List<Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow>();
                        foreach (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung in arrAbteilungen)
                        {
                            lstToDelete.Add(rAbteilung);
                        }

                        foreach (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung in lstToDelete)
                        {
                            rAbteilung.Delete();
                        }
                    }
                }

                this.dsDokumente2Abteilungen1.AcceptChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.saveAbteilung: " + ex.ToString());
            }
        }

        public void loadBenutzergruppen(UltraListViewItem itmAbteilung, Global.db.ERSystem.dsKlientenliste.Dokumente2Row rSelDokument)
        {
            try
            {
                if (itmAbteilung != null)
                {
                    this.auswahlGruppeComboMulti1.clearSelectedNodes();

                    string BenutzergruppenTmp = "";
                    Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[] arrBenutzergruppen = (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[])this.dsDokumente2Abteilungen1.Benutzergruppen.Select("IDAbteilung='" + itmAbteilung.Key.ToString() + "'", "");
                    foreach (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rBenutzergruppen in arrBenutzergruppen)
                    {
                        BenutzergruppenTmp += rBenutzergruppen.IDBenutzergruppe.ToString() + ";";
                    }

                    System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                    System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                    System.Collections.Generic.List<Guid> lstGuidsBerufsstand = this.setBerufsstandErstelltFromString(BenutzergruppenTmp.Trim());
                    this.auswahlGruppeComboMulti1.setSelected(lstGuidsBerufsstand, lstIntSelected, lstStrSelected);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.loadBenutzergruppen: " + ex.ToString());
            }
        }
        public void saveBenutzergruppen(UltraListViewItem itm)
        {
            try
            {
                Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[] arrAbteilungen = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[])this.dsDokumente2Abteilungen1.Abteilungen.Select("IDAbteilung='" + itm.Key.ToString() + "'", "");
                if (arrAbteilungen.Length == 1)
                {
                    //Bereits gewählte Benutzergruppen aus der Liste entfernen
                    Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[] arrBenutzergruppen = (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow[])this.dsDokumente2Abteilungen1.Benutzergruppen.Select("IDAbteilung='" + itm.Key.ToString() + "'", "");
                    if (arrBenutzergruppen.Length > 0)
                    {
                        System.Collections.Generic.List<Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow> lstToDelete = new List<Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow>();
                        foreach (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rBenutzergruppe in arrBenutzergruppen)
                        {
                            lstToDelete.Add(rBenutzergruppe);
                        }
                        foreach (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rBenutzergruppe in lstToDelete)
                        {
                            rBenutzergruppe.Delete();
                        }
                    }
                    this.dsDokumente2Abteilungen1.AcceptChanges();

                    System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                    System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                    System.Collections.Generic.List<int> lstZeitbezug = new System.Collections.Generic.List<int>();
                    this.auswahlGruppeComboMulti1.getSelected(ref lstGuid, ref lstZeitbezug, ref lstStrSelected);
                    //string BenutzergruppenTmp = "";
                    foreach (Guid IDBerufsstandSelected in lstGuid)
                    {
                        //BenutzergruppenTmp += IDBerufsstandSelected.ToString() + ";";
                        Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rNewBenutzergruppe = (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow)this.dsDokumente2Abteilungen1.Benutzergruppen.NewRow();
                        rNewBenutzergruppe.IDAbteilung = new Guid(itm.Key.ToString());
                        rNewBenutzergruppe.IDBenutzergruppe = IDBerufsstandSelected;
                        this.dsDokumente2Abteilungen1.Benutzergruppen.Rows.Add(rNewBenutzergruppe);
                    }
                    this.dsDokumente2Abteilungen1.AcceptChanges();
                }
                else if (arrAbteilungen.Length == 0)
                {
                    string xy = "";
                }
                else if (arrAbteilungen.Length > 1)
                {
                    throw new Exception("saveBenutzergruppen: arrAbteilungen.Length>1 for IDAbteilung '" +  itm .Key.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.saveBenutzergruppen: " + ex.ToString());
            }
        }
        public System.Collections.Generic.List<Guid> setBerufsstandErstelltFromString(string slstGuid)
        {
            try
            {
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                this.auswahlGruppeComboMulti1.clearSelectedNodes();
                if (slstGuid.Trim() != "")
                {
                    this.UISitemaps1.getListGuidFromString(slstGuid, ref lstGuid);
                    if (lstGuid.Count > 0)
                    {
                    }
                }
                return lstGuid;
            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.setBerufsstandErstelltFromString: " + ex.ToString());
            }
        }

        private void btnLoeschen_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsDokumente2Abteilungen1.Benutzergruppen.Clear();
                this.dsDokumente2Abteilungen1.Clear();
                Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[] arrAbteilungen = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow[])this.dsDokumente2Abteilungen1.Abteilungen.Select("", "");
                foreach (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilung in arrAbteilungen)
                    this.dsDokumente2Abteilungen1.Abteilungen.Rows.Add(rAbteilung);
                this.dsDokumente2Abteilungen1.AcceptChanges();

                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
                System.Collections.Generic.List<Guid> lstGuidsBerufsstand = new System.Collections.Generic.List<Guid>();
                this.auswahlGruppeComboMulti1.setSelected(lstGuidsBerufsstand, lstIntSelected, lstStrSelected);
            }
            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.btnLoeschen_Click: " + ex.ToString());
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                System.Collections.Generic.List<string> lstStrSelected = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<Guid> lstGuid = new System.Collections.Generic.List<Guid>();
                System.Collections.Generic.List<int> lstZeitbezug = new System.Collections.Generic.List<int>();
                this.auswahlGruppeComboMulti1.getSelected(ref lstGuid, ref lstZeitbezug, ref lstStrSelected);

                this.dsDokumente2Abteilungen1.Benutzergruppen.Clear();
                this.dsDokumente2Abteilungen1.Clear();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Abteilung> tAbteilung = this.PMDSBusiness1.getAllAbteilungen(ENV.IDKlinik, db);
                    foreach (PMDS.db.Entities.Abteilung rAbteilung in tAbteilung)
                    {

                        Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow rAbteilungDoc = (Global.db.ERSystem.dsDokumente2Abteilungen.AbteilungenRow)this.dsDokumente2Abteilungen1.Abteilungen.NewRow();
                        rAbteilungDoc.IDAbteilung = new Guid(rAbteilung.ID.ToString());
                        this.dsDokumente2Abteilungen1.Abteilungen.Rows.Add(rAbteilungDoc);

                        foreach (Guid IDBerufsstandSelected in lstGuid)
                        {
                            Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow rNewBenutzergruppe = (Global.db.ERSystem.dsDokumente2Abteilungen.BenutzergruppenRow)this.dsDokumente2Abteilungen1.Benutzergruppen.NewRow();
                            rNewBenutzergruppe.IDAbteilung = new Guid(rAbteilung.ID.ToString());
                            rNewBenutzergruppe.IDBenutzergruppe = IDBerufsstandSelected;
                            this.dsDokumente2Abteilungen1.Benutzergruppen.Rows.Add(rNewBenutzergruppe);
                        }
                    }
                }

                this.dsDokumente2Abteilungen1.AcceptChanges();
            }

            catch (Exception ex)
            {
                throw new Exception("contManageDocuments.btnCopy_Click: " + ex.ToString());
            }
        }
    }
}
