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
using PMDS.Global.db.ERSystem;
using System.Data.OleDb;
using PMDS.GUI.VB;
using Infragistics.Win.UltraWinEditors;
using System.IO;
using Infragistics.Win;

namespace PMDS.GUI.BaseControls
{


    public partial class contEditMedizinischeTypen2 : UserControl
    {

        public bool abort = true;

        public string colIco = "Ico";
        public string colIcoOff = "IcoOff";

        public frmEditMedizinischeTypen2 mainWindow = null;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new Global.db.ERSystem.PMDSBusinessUI();






        public contEditMedizinischeTypen2()
        {
            InitializeComponent();
        }


        private void contEditMedizinischeTypen2_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);
                this.btnAbort.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
                this.iconLöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);
                this.iconDeaktiviertLöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                this.sqlManange1.initControl();

                if (ENV.adminSecure)
                {
                    this.btnAdd.Visible = true;
                    this.btnDel.Visible = true;
                    this.gridMedTypen.DisplayLayout.Bands[0].Columns[this.dsManage1.MedizinischeTypen.MedizinischerTypColumn.ColumnName].Hidden = false;
                    //this.gridMedTypen.DisplayLayout.Bands[0].Columns[this.dsManage1.MedizinischeTypen.IconColumn.ColumnName].Hidden = false;
                    //this.gridMedTypen.DisplayLayout.Bands[0].Columns[this.dsManage1.MedizinischeTypen.IconOFFColumn.ColumnName].Hidden = false;
                }
                else
                {
                    this.btnAdd.Visible = false;
                    this.btnDel.Visible = false;
                    this.gridMedTypen.DisplayLayout.Bands[0].Columns[this.dsManage1.MedizinischeTypen.MedizinischerTypColumn.ColumnName].Hidden = true;
                }

                this.lblFound.Text = "";

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.initControl: " + ex.ToString());
            }
        }


        public void loadData()
        {
            try
            {
                this.uPictureBoxPreviewIcon.Image = null;
                this.uPictureBoxPreviewIconOFF.Image = null;

                this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()].ValueListItems.Clear();
                this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()].ValueListItems.Clear();

                this.dsManage1.Clear();
                this.sqlManange1.getMedizinischeTypen(this.dsManage1, null, sqlManange.eTypeMedizinischeDatenLayout.all);
                this.gridMedTypen.Refresh();

                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsManage1.MedizinischeTypen.Rows.Count.ToString() + "";


                ValueListItem itmEmpty = new ValueListItem();
                itmEmpty.DisplayText = " ";
                itmEmpty.DataValue = -1;
                itmEmpty.Appearance.ForeColor = System.Drawing.Color.White;
                this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()].ValueListItems.Add(itmEmpty);

                itmEmpty = new ValueListItem();
                itmEmpty.DisplayText = " ";
                itmEmpty.DataValue = -1;
                itmEmpty.Appearance.ForeColor = System.Drawing.Color.White;
                this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()].ValueListItems.Add(itmEmpty);

                int iCounterImg = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridMedTypen.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsManage.MedizinischeTypenRow rSelRow = (dsManage.MedizinischeTypenRow)v.Row;

                    if (!rSelRow.IsIconNull())
                    {
                        iCounterImg += 1;
                        using (var ms = new MemoryStream(rSelRow.Icon))
                        {
                            Image img = Image.FromStream(ms);
                            ValueListItem itmImg = new ValueListItem();
                            itmImg.DisplayText = " ";
                            itmImg.DataValue = iCounterImg;
                            itmImg.Appearance.Image = img;
                            itmImg.Appearance.ForeColor = System.Drawing.Color.White;
                            itmImg.Appearance.BackColor = System.Drawing.Color.White;
                            this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()].ValueListItems.Add(itmImg);
                        }
                        rGrid.Cells[this.colIco.Trim()].Value = iCounterImg;
                    }
                    else
                    {
                        rGrid.Cells[this.colIco.Trim()].Value = -1;
                    }

                    if (!rSelRow.IsIconOFFNull())
                    {
                        iCounterImg += 1;
                        using (var ms = new MemoryStream(rSelRow.IconOFF))
                        {
                            Image img = Image.FromStream(ms);
                            ValueListItem itmImg = new ValueListItem();
                            itmImg.DisplayText = " ";
                            itmImg.DataValue = iCounterImg;
                            itmImg.Appearance.Image = img;
                            itmImg.Appearance.ForeColor = System.Drawing.Color.White;
                            itmImg.Appearance.BackColor = System.Drawing.Color.White;
                            this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()].ValueListItems.Add(itmImg);
                        }
                        rGrid.Cells[this.colIcoOff.Trim()].Value = iCounterImg;
                    }
                    else
                    {
                        rGrid.Cells[this.colIcoOff.Trim()].Value = -1;
                    }
                }

                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //{
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.loadData: " + ex.ToString());
            }
        }

        public int getMaxPictureNrFromValueList(ValueList valList)
        {
            try
            {
                int iMaxPicNr = 0;
                foreach (ValueListItem itm in valList.ValueListItems)
                {
                    if ((int)itm.DataValue > iMaxPicNr)
                    {
                        iMaxPicNr = (int)itm.DataValue;
                    }
                }

                return iMaxPicNr + 1;

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.getMaxPictureNrFromValueList: " + ex.ToString());
            }
        }

        public void ClearErrorProvider()
        {
            try
            {
                this.errorProvider1.SetError(this.gridMedTypen, "");

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.ClearErrorProvider: " + ex.ToString());
            }
        }
        public bool validateData()
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridMedTypen.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsManage.MedizinischeTypenRow rSelRow = (dsManage.MedizinischeTypenRow)v.Row;

                    if (rSelRow.RowState != DataRowState.Deleted)
                    {
                        if (rSelRow.Beschreibung.Trim() == "")
                        {
                            this.errorProvider1.SetError(this.gridMedTypen, "Error");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }


                this.sqlManange1.daMedizinischeTypen.Update(this.dsManage1.MedizinischeTypen);
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.saveData: " + ex.ToString());
            }
        }


        public void addRow()
        {
            try
            {
                PMDS.Global.db.ERSystem.dsManage.MedizinischeTypenRow rNew = this.sqlManange1.getNewMedizinischeTypen(ref this.dsManage1);
                rNew.Nummer = this.getMaxMedizinischerTyp();
                rNew.MedizinischerTyp = -1;
                rNew.Beschreibung = QS2.Desktop.ControlManagment.ControlManagment.getRes("Neuer med. Typ");

                this.gridMedTypen.Refresh();

                this.uPictureBoxPreviewIcon.Image = null;
                this.uPictureBoxPreviewIconOFF.Image = null;
            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.addRow: " + ex.ToString());
            }
        }
        public int getMaxMedizinischerTyp()
        {
            try
            {
                int MaxNrFound = 0;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in this.gridMedTypen.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsManage.MedizinischeTypenRow rSelRow = (dsManage.MedizinischeTypenRow)v.Row;

                    if (rSelRow.RowState != DataRowState.Deleted)
                    {
                        if (rSelRow.Nummer > MaxNrFound)
                        {
                            MaxNrFound = rSelRow.Nummer;
                        }
                    }
                }

                return MaxNrFound + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.getMaxMedizinischerTyp: " + ex.ToString());
            }
        }

        public void delRows()
        {
            try
            {
                System.Collections.Generic.List<UltraGridRow> lstSelectedRows = new List<UltraGridRow>();
                PMDS.Global.generic.getSelectedGridRows(this.gridMedTypen, lstSelectedRows, true);
                if (lstSelectedRows.Count > 0)
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rGrid in lstSelectedRows)
                            {
                                DataRowView v = (DataRowView)rGrid.ListObject;
                                dsManage.MedizinischeTypenRow rSelRow = (dsManage.MedizinischeTypenRow)v.Row;

                                this.sqlManange1.deleteMedizinischeTypen(rSelRow.ID);
                            }

                            this.loadData();
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.delRows: " + ex.ToString());
            }
        }

        public bool setIcon(dsManage.MedizinischeTypenRow rSelRow, bool setDeacivatedIcon, ref UltraGridRow rGridSel)
        {
            try
            {
                string sFile = this.bUI.selectFilePicture();
                if (sFile.Trim() == "")
                {
                    return false;
                }

                //this.uPictureBoxPreviewIcon.Image = null;
                //this.uPictureBoxPreviewIconOFF.Image = null;

                int imgNr = 0;
                Image image = Image.FromFile(sFile);
                Image imageConverted = image.GetThumbnailImage(16, 16, null, new IntPtr());
                byte[] bImg = this.bUI.imageToByteArray(imageConverted);
                if (!setDeacivatedIcon)
                {
                    imgNr = this.getMaxPictureNrFromValueList(this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()]);
                }
                else
                {
                    imgNr = this.getMaxPictureNrFromValueList(this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()]);
                }

                //using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(sFile)))
                //{
                //    if (!setDeacivatedIcon)
                //    {
                //        imgNr = this.getMaxPictureNrFromValueList(this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()]);
                //    }
                //    else
                //    {
                //        imgNr = this.getMaxPictureNrFromValueList(this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()]);
                //    }
                //    img = Image.FromStream(ms);
                //    bImg = ms.ToArray();
                //}

                ValueListItem itmImg = new ValueListItem();
                itmImg.DisplayText = " ";
                itmImg.DataValue = imgNr;
                itmImg.Appearance.Image = imageConverted;
                itmImg.Appearance.ForeColor = System.Drawing.Color.White;
                itmImg.Appearance.BackColor = System.Drawing.Color.White;

                if (!setDeacivatedIcon)
                {
                    this.gridMedTypen.DisplayLayout.ValueLists[this.colIco.Trim()].ValueListItems.Add(itmImg);
                    rSelRow.Icon = bImg.ToArray();
                    rGridSel.Cells[this.colIco.Trim()].Value = imgNr;
                    this.showPicturePreview(rSelRow.Icon, this.uPictureBoxPreviewIcon, false);
                }
                else
                {
                    this.gridMedTypen.DisplayLayout.ValueLists[this.colIcoOff.Trim()].ValueListItems.Add(itmImg);
                    rSelRow.IconOFF = bImg.ToArray();
                    rGridSel.Cells[this.colIcoOff.Trim()].Value = imgNr;
                    this.showPicturePreview(rSelRow.IconOFF, this.uPictureBoxPreviewIconOFF, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.setIcon: " + ex.ToString());
            }
        }

        public void showPicturePreview(byte[] bImg, UltraPictureBox picViewer, bool noPicture)
        {
            try
            {
                if (!noPicture)
                {
                    using (var ms = new MemoryStream(bImg))
                    {
                        Image imgPreview = Image.FromStream(ms);
                        picViewer.Image = imgPreview;
                        picViewer.BackColor = System.Drawing.Color.Transparent;
                    }
                }
                else
                {
                    picViewer.Image = null;
                    picViewer.BackColor = System.Drawing.Color.Transparent;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contEditMedizinischeTypen2.showPicturePreview: " + ex.ToString());
            }
        }

        public dsManage.MedizinischeTypenRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridMedTypen.ActiveRow != null)
                {
                    if (this.gridMedTypen.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridMedTypen.ActiveRow.ListObject;
                        dsManage.MedizinischeTypenRow rSelRow = (dsManage.MedizinischeTypenRow)v.Row;
                        gridRow = this.gridMedTypen.ActiveRow;
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
                throw new Exception("contEditMedizinischeTypen2.getSelectedRow: " + ex.ToString());
            }
        }




        private void gridMedTypen_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals(("ID").Trim().ToLower()) ||
                        e.Cell.Column.ToString().Trim().ToLower().Equals(this.colIco.Trim().Trim().ToLower()) ||
                        e.Cell.Column.ToString().Trim().ToLower().Equals(this.colIcoOff.Trim().Trim().ToLower()) ||
                        e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsManage1.MedizinischeTypen.IconColumn.ColumnName.Trim().ToLower()) ||
                        e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsManage1.MedizinischeTypen.BeschreibungColumn.ColumnName.Trim().ToLower()) ||
                        e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsManage1.MedizinischeTypen.IconOFFColumn.ColumnName.Trim().ToLower()))
                    {
                        if (ENV.adminSecure)
                        {
                            if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsManage1.MedizinischeTypen.BeschreibungColumn.ColumnName.Trim().ToLower()))
                            {
                                if (ENV.adminSecure)
                                {
                                    e.Cell.Activation = Activation.AllowEdit;
                                }
                                else
                                {
                                    e.Cell.Activation = Activation.NoEdit;
                                }

                            }
                            else
                            {
                                e.Cell.Activation = Activation.NoEdit;
                            }
                        }
                        else
                        {
                            e.Cell.Activation = Activation.NoEdit;
                        }
                    }
                    else
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMedTypen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMedTypen))
                {
                    UltraGridRow rGridSel = null;
                    dsManage.MedizinischeTypenRow rSelRow = this.getSelectedRow(false, ref rGridSel);
                    if (rSelRow != null)
                    {
                        if (!rSelRow.IsIconNull())
                        {
                            this.showPicturePreview(rSelRow.Icon, this.uPictureBoxPreviewIcon, false);
                        }
                        else
                        {
                            this.showPicturePreview(null, this.uPictureBoxPreviewIcon, true);
                        }

                        if (!rSelRow.IsIconOFFNull())
                        {
                            this.showPicturePreview(rSelRow.IconOFF, this.uPictureBoxPreviewIconOFF, false);
                        }
                        else
                        {
                            this.showPicturePreview(null, this.uPictureBoxPreviewIconOFF, true);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMedTypen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMedTypen))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMedTypen_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
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





        private void btnRefresh_Click(object sender, EventArgs e)
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.delRows();

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
                    this.loadData();

                    ENV.SignalMedizinDatenChanged();
                    //this.mainWindow.Close();
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

        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //this.abort = true;
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




        private void iconHochladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //this.gridMedTypen.UpdateData();
                UltraGridRow rGridSel = null;
                dsManage.MedizinischeTypenRow rSelRow = this.getSelectedRow(true, ref rGridSel);
                if (rSelRow != null)
                {
                    this.setIcon(rSelRow, false, ref rGridSel);
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
        private void iconLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                dsManage.MedizinischeTypenRow rSelRow = this.getSelectedRow(true, ref rGridSel);
                if (rSelRow != null)
                {
                    rSelRow.SetIconNull();
                    rGridSel.Cells[this.colIco.Trim()].Value = -1;
                    this.uPictureBoxPreviewIcon.Image = null;
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
        private void iconDeaktiviertHochladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                dsManage.MedizinischeTypenRow rSelRow = this.getSelectedRow(true, ref rGridSel);
                if (rSelRow != null)
                {
                    this.setIcon(rSelRow, true, ref rGridSel);
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
        private void iconDeaktiviertLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                dsManage.MedizinischeTypenRow rSelRow = this.getSelectedRow(true, ref rGridSel);
                if (rSelRow != null)
                {
                    rSelRow.SetIconOFFNull();
                    rGridSel.Cells[this.colIcoOff.Trim()].Value = -1;
                    this.uPictureBoxPreviewIconOFF.Image = null;
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
