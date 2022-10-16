using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;






namespace qs2.sitemap.manage.wizardsDevelop
{
    public partial class contRessourcen : UserControl 
    {

        public qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
        public bool  isInEditMode = false;
        public frmRessourcen mainWindow;
        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
        
        public qs2.core.vb.funct funct1 = new qs2.core.vb .funct();
        public string IDApplication = "";
        public string IDParticipant = "";
        public int LastNrAdd = 0;

        public System.Collections.Generic.List<System.Guid> lstAddedRows = new List<Guid>();

        public bool VisibleIsInitialized = false;









        public contRessourcen()
        {
            InitializeComponent();
        }

        public  void initControl()
        {
            this.loadRes();
            this.loadLists();

            this.btnSave.initControl();
            this.btnCancel.initControl();

            this.edit(false);
        }
        public void initControl(string typApplication, string searchString)
        {
            this.comboApplication1.initControlxy(true);
            this.comboApplication1.setApplication(typApplication.ToString());

            //this.cboTyp.Value = core.Enums.eResourceType.Label;
            this.txtSearchRes.Text = searchString.Trim();
            this.loadData();
        }

        public void loadRes()
        {
            this.btnCancel.initControl();
            this.btnSave.initControl();
            this.btnClose.initControl();

            this.btnSearchRes2.initControl();
            this.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Cancel");
            this.btnEdit.Text = qs2.core.language.sqlLanguage.getRes("Edit");
            this.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close");

            this.lblApplication.Text = qs2.core.language.sqlLanguage.getRes("Application");
            this.lblTyp.Text = qs2.core.language.sqlLanguage.getRes("Typ");

            this.ultraTabControlSys.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard;

            this.lblSearchRes.Text = qs2.core.language.sqlLanguage.getRes("Search");

            this.gridRes.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ...";
            qs2.core.ui.loadResGridRessourcen(this.gridRes.DisplayLayout.Bands[0], this.dsLanguage1);

            this.setUIAddNewBox();

            this.exportAsExcelToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ExportAsExcel");
            this.filterToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Filter");

            this.setPictureToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus , 32, 32);
            this.clearPictureToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen , 32, 32);
            //this.openPictureToolStripMenuItem.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_about, 32, 32 );
            //this.exportAsExcelToolStripMenuItem.Image = getRes.getImage(qs2.Resources.getRes.ePicture.ico_excel, 32, 32 );

            this.saveAllLoadedRessourcesToDatabaseToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
            this.clearAllRessourcesFromDatabaseToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

            this.setPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SetFile");
            this.clearPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ClearFile");
            this.openPictureToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenFile");
            this.savePictureAsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SaveFileAs");

        }
        public void setUIAddNewBox()
        {
            this.gridRes.DisplayLayout.AddNewBox.Prompt = qs2.core.language.sqlLanguage.getRes("Add");
            this.gridRes.DisplayLayout.Bands[0].AddButtonCaption = qs2.core.language.sqlLanguage.getRes("Ressource"); ;
        }

        public void loadLists()
        {
            this.dropDownSelListCountries.initControl(false, true );
            this.dropDownApplications1.initControl(false);
            
            this.gridRes.DisplayLayout.Bands[0].Columns[this.dsLanguage1.Ressourcen.IDLanguageUserColumn.ColumnName].ValueList = this.dropDownSelListCountries.ultraDropDownSelLists;
            
            this.dropDownApplications1.loadData();

            qs2.core.generic.getResourceTypes(this.gridRes.DisplayLayout.ValueLists["ResTypes"], this.cboTyp);
            qs2.core.generic.getTypeSub(this.gridRes.DisplayLayout.ValueLists["TypeSub"], null);

            this.comboApplication1.initControlxy(true);
            this.comboApplication1.setApplication(this.IDApplication);

            qs2.core.vb.ui.loadImagesFromRessources(null, this.gridRes.DisplayLayout.ValueLists["Images"]);
            this.gridRes.DisplayLayout.ValueLists["Images"].SortStyle = Infragistics.Win.ValueListSortStyle.Ascending;

            this.cboTyp.Value = core.Enums.eResourceType.Label;
        }

        private void txtSearchRes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (System.Convert.ToInt32(e.KeyChar) == 13)
                    this.loadData();
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
        
        public void loadData()
        {
            try
            {
                this.dsLanguage1.Ressourcen.Rows.Clear();

                core.license.doLicense.eApp enumAppFound = this.comboApplication1.getSelectedApplication();

                core.Enums.eResourceType enumTypResSearch =  core.Enums.eResourceType.All;
                if (this.cboTyp.Value != null)
                    enumTypResSearch = qs2.core.generic.searchEnumRessourcenTyp((String)this.cboTyp.Value);

                this.dropDownSelListCountries.IDParticipant = this.IDParticipant;
                this.dropDownSelListCountries.loadData("CountryID", enumAppFound.ToString());

                this.sqlLanguage1.getLanguage(this.txtSearchRes.Text.Trim(), this.dsLanguage1, core.language.sqlLanguage.eTypSelLang.search, enumTypResSearch, enumAppFound.ToString());
                this.gridRes.Text = qs2.core.language.sqlLanguage.getRes("Ressourcen") + " (" + this.dsLanguage1.Ressourcen.Rows.Count.ToString() + ")";
                
                this.gridRes.Selected.Rows.Clear();
                this.gridRes.ActiveRow = null;

                this.lstAddedRows.Clear();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public bool  save()
        {
            try
            {
                this.gridRes.UpdateData();
                qs2.core.dbBase.setConnection2(this.sqlLanguage1.daLanguage);
                this.sqlLanguage1.daLanguage.Update(this.dsLanguage1.Ressourcen);

                qs2.core.language.sqlLanguage sqlLanguage1 = new qs2.core.language.sqlLanguage();
                sqlLanguage1.loadAllRessources();
                this.lstAddedRows.Clear();

                return true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return false;
            }
        }
        public void edit(bool bEdit)
        {
            try
            {
                this.isInEditMode = bEdit;

                this.btnSave.Enabled = bEdit;
                this.btnCancel.Enabled = bEdit;
                this.btnEdit.Enabled = !bEdit;
                this.btnAddRes.Visible = bEdit;
                if (bEdit)
                {
                    this.gridRes.ContextMenuStrip = this.contextMenuStrip1;
                }
                else
                {
                    this.gridRes.ContextMenuStrip = null;
                }

                qs2.core.ui.editGrid(bEdit, this.gridRes, true, Infragistics.Win.UltraWinGrid.AllowAddNew.Yes);
                this.gridRes.DisplayLayout.AddNewBox.Hidden = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void txtSearchRes_Enter(object sender, EventArgs e)
        {
            this.txtSearchRes.Focus();
        }

        public qs2.core.language.dsLanguage.RessourcenRow getSelRessource( bool msgBox)
        {
            try
            {
                if (this.gridRes.ActiveRow != null)
                {
                    DataRowView v = (DataRowView)this.gridRes.ActiveRow.ListObject;
                    if (v != null)
                    {
                        qs2.core.language.dsLanguage.RessourcenRow rRes = (qs2.core.language.dsLanguage.RessourcenRow)v.Row;
                        return rRes;
                    }
                    return null;
                }
                else
                {
                    if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK  , "");
                    return null;
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void gridRes_AfterRowInsert(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            core.license.doLicense.eApp enumAppFound = this.comboApplication1.getSelectedApplication();
            core.Enums.eResourceType enumTypResSearch = qs2.core.generic.searchEnumRessourcenTyp((String)this.cboTyp.Value);

            e.Row.Cells[this.dsLanguage1.Ressourcen.IDResColumn.ColumnName].Value = "";
            e.Row.Cells[this.dsLanguage1.Ressourcen.EnglishColumn.ColumnName].Value = "";
            e.Row.Cells[this.dsLanguage1.Ressourcen.GermanColumn.ColumnName].Value = "";
            e.Row.Cells[this.dsLanguage1.Ressourcen.UserColumn.ColumnName].Value = "";
            
            e.Row.Cells[this.dsLanguage1.Ressourcen.DescriptionColumn.ColumnName].Value = "";

            e.Row.Cells[this.dsLanguage1.Ressourcen.IDLanguageUserColumn.ColumnName].Value = qs2.core.license.doLicense.eApp.ALL.ToString();
            e.Row.Cells[this.dsLanguage1.Ressourcen.IDApplicationColumn.ColumnName].Value = enumAppFound.ToString();
            e.Row.Cells[this.dsLanguage1.Ressourcen.IDParticipantColumn.ColumnName].Value = qs2.core.license.doLicense.eApp.ALL.ToString();
            e.Row.Cells[this.dsLanguage1.Ressourcen.TypeColumn.ColumnName].Value = enumTypResSearch.ToString();
            e.Row.Cells[this.dsLanguage1.Ressourcen.TypeSubColumn.ColumnName].Value = "";

            e.Row.Cells[this.dsLanguage1.Ressourcen.fileBytesColumn.ColumnName].Value = System.DBNull.Value;
            e.Row.Cells[this.dsLanguage1.Ressourcen.fileTypeColumn.ColumnName].Value = "";

            e.Row.Cells[this.dsLanguage1.Ressourcen.CreatedColumn.ColumnName].Value = System.DateTime.Now;
            e.Row.Cells[this.dsLanguage1.Ressourcen.CreatedUserColumn.ColumnName].Value = qs2.core.vb.actUsr.rUsr.UserName;
        }

        private void gridRes_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                qs2.core.ui.delGridRowYN(e);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public qs2.core.language.dsLanguage.RessourcenRow getSelectedRow(bool msgBox, UltraGridRow selRowGrid)
        {
            try
            {
                if (this.gridRes.ActiveRow != null)
                {
                    if (this.gridRes.ActiveRow.IsGroupByRow || this.gridRes.ActiveRow.IsFilterRow)
                    {
                        if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridRes.ActiveRow.ListObject;
                        qs2.core.language.dsLanguage.RessourcenRow rSelRow = (qs2.core.language.dsLanguage.RessourcenRow)v.Row;
                        selRowGrid = this.gridRes.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (msgBox) qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), MessageBoxButtons.OK, "");
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return null;
            }
        }

        private void btnSaveRes2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.save();
                this.edit(false);
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

        private void btnSearchRes2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.edit(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
                this.edit(false);
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
            this.mainWindow.Close();
        }

        private void exportAsExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.sitemap.export export1 = new qs2.sitemap.export();
                export1.doExport(this.gridRes, Environment.SpecialFolder.Desktop, export.eTypExport.excel, null, "", "", null);
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

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                qs2.core.vb.funct.setFilterGrid(this.gridRes, this.filterToolStripMenuItem.Checked);

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
        
        private void setPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.language.dsLanguage.RessourcenRow rResSel = this.getSelRessource(true);
                if (rResSel != null)
                {
                    string selFiles = this.funct1.selectFile(false, funct.ressourcenFileType, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop));
                    if (selFiles != null)
                    {
                        rResSel.fileBytes = this.funct1.readByteStreamFile(selFiles);
                        rResSel.fileType = System.IO.Path.GetExtension(selFiles);
                        this.clearPictureToolStripMenuItem.Visible = true ;
                        this.openPictureToolStripMenuItem.Visible = true;
                        this.savePictureAsToolStripMenuItem.Visible = true;

                        this.edit(true);
                    }
                }
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
        private void clearPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.language.dsLanguage.RessourcenRow rResSel = this.getSelRessource(true);
                if (rResSel != null)
                {
                    if (!rResSel.IsfileBytesNull ())
                    {
                        rResSel.SetfileBytesNull ();
                        rResSel.fileType = "";
                        this.edit(true);
                    }
                    else
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoFileAssigned"), MessageBoxButtons.OK, "");
                }
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

        private void loadPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.language.dsLanguage.RessourcenRow rResSel = this.getSelRessource(true);
                if (rResSel != null)
                {
                    if (!rResSel.IsfileBytesNull ())
                    {
                        string pictureToOpen = this.funct1.saveFileFromBytes(qs2.core.ENV.PathTemp, "picture.res " + rResSel.IDRes, rResSel.fileType, rResSel.fileBytes);
                        this.funct1.openFile(pictureToOpen, rResSel.fileType, false);
                    }
                    else
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoFileAssigned"), MessageBoxButtons.OK, "");
                }
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

        private void cboTyp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.cboTyp.Focused)
                {
                    this.loadData();
                }
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


        private void savePictureAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.language.dsLanguage.RessourcenRow rResSel = this.getSelRessource(true);
                if (rResSel != null)
                {
                    if (!rResSel.IsfileBytesNull())
                    {
                        string fileToSave  = this.funct1.saveFile(false,  this.funct1.getFileTypForDialog(rResSel.fileType));
                        if (fileToSave != null)
                        {
                            this.funct1.saveFileFromBytes(fileToSave, rResSel.fileBytes, true);
                        }
                    }
                    else
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoFileAssigned"), MessageBoxButtons.OK, "");
                }
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

        private void comboApplication1_evOnChange(string selectedApplication)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData();
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

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ultraCheckEditor1_CheckedValueChanged(object sender, EventArgs e)
        {

        }

        private void gridRes_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString() == this.dsLanguage1.Ressourcen.fileTypeColumn.ColumnName || e.Cell.Column.ToString() == this.dsLanguage1.Ressourcen.fileBytesColumn.ColumnName)
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        private void gridRes_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                this.gridRes.UpdateData();
                e.Cell.Row.Cells[this.dsLanguage1.Ressourcen.LastChangeColumn.ColumnName].Value = DateTime.Now;

                DataRowView v = (DataRowView)e.Cell.Row.ListObject;
                qs2.core.language.dsLanguage.RessourcenRow rResSel = (qs2.core.language.dsLanguage.RessourcenRow)v.Row;
                this.loadImage(rResSel);

            }
            catch (Exception ex)
            {
                throw new Exception("contRessourcen.gridRes_CellChange: " + ex.ToString());
            }
        }

        public void loadImage(qs2.core.language.dsLanguage.RessourcenRow rRes)
        {
            try
            {
                this.picPreview.Image = null;
                if (rRes.Image.Trim() != "")
                {
                    this.picPreview.Image = QS2.Resources.getRes.getImage(rRes.Image.Trim(), rRes.ImageWidth, rRes.ImageHeigth); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contRessourcen.loadImage: " + ex.ToString());
            }
        }

 
        private void btnAddRes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRessource();
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

        public void addRessource()
        {
            core.Enums.eTypeSub AddMode = core.Enums.eTypeSub.Supervisor;
            qs2.core.language.dsLanguage.RessourcenRow rNewRes = this.sqlLanguage1.newRowLanguage(ref this.dsLanguage1, 
                                                                                            "", "", "", "", "", 
                                                                                            core.Enums.eResourceType.Label, AddMode, "");

            core.license.doLicense.eApp enumAppFound = this.comboApplication1.getSelectedApplication();
            core.Enums.eResourceType enumTypResSearch = qs2.core.generic.searchEnumRessourcenTyp((String)this.cboTyp.Value);

            this.LastNrAdd += 1;
            rNewRes.IDRes = "New Ressource " + this.LastNrAdd.ToString();
            rNewRes.IDLanguageUser = qs2.core.license.doLicense.eApp.ALL.ToString();
            rNewRes.IDApplication = enumAppFound.ToString();
            
            rNewRes.Type = enumTypResSearch.ToString();
            rNewRes.Created = System.DateTime.Now;
            rNewRes.CreatedUser = qs2.core.vb.actUsr.rUsr.UserName;

            this.gridRes.Refresh();
            Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = this.gridRes.Rows.GetRowWithListIndex(this.dsLanguage1.Ressourcen.Rows.IndexOf(rNewRes));
            this.gridRes.ActiveRow = gridRow;

            rNewRes.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString();
            rNewRes.CreatedUser = "";
            rNewRes.TypeSub = "";

            this.lstAddedRows.Add(rNewRes.IDGuid);
        }

        private void exportAsXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.vb.ui.ExportGridToXml(this.gridRes, this.dsLanguage1);
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
        private void importFromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.vb.ui.ImportGridToXml(this.gridRes, this.dsLanguage1);
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
        private void clearAllRessourcesFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToDoThisActivity") + "?", MessageBoxButtons.YesNo, "") == DialogResult.Yes)
                {
                    this.sqlLanguage1.sys_deleteAllRessource();
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ActivityPerformed") + "!", MessageBoxButtons.OK, "");
                }
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
        private void saveAllLoadedRessourcesToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToDoThisActivity") + "?", MessageBoxButtons.YesNo, "") == DialogResult.Yes)
                {
                    this.sqlLanguage1.sys_SaveAllRessourcesToDatabase(this.dsLanguage1);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ActivityPerformed") + "!", MessageBoxButtons.OK, "");
                }

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

        private void gridRes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.core.language.dsLanguage.RessourcenRow rSelRes = this.getSelRessource(false);
                if (rSelRes != null)
                {
                    this.loadImage(rSelRes);
                }
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

        private void contRessourcen_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.Visible)
                {
                    if (!this.VisibleIsInitialized)
                    {
                        this.loadData();
                        this.VisibleIsInitialized = true;
                    }
                }

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

        private void copyRessourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                System.Collections.Generic.List<Infragistics.Win.UltraWinGrid.UltraGridRow> rSelected = new List<UltraGridRow>();
                qs2.core.ui.getSelectedGridRows(this.gridRes, rSelected, true);
                if (rSelected.Count == 0)
                {
                }

                if (rSelected.Count > 0)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow rSelRes in rSelected)
                    {
                        DataRowView v = (DataRowView)rSelRes.ListObject;
                        qs2.core.language.dsLanguage.RessourcenRow rRes = (qs2.core.language.dsLanguage.RessourcenRow)v.Row;

                        qs2.core.language.dsLanguage.RessourcenRow rLanguageReturn = null;
                        InsertFromClipboard InsertFromClipboard1 = new InsertFromClipboard();
                        InsertFromClipboard1.CopyRessource(rRes, ref rLanguageReturn);
                    }
                }

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

        private void clearCopiedRowsInRamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                InsertFromClipboard.tSelListEntries.Clear();
                InsertFromClipboard.tRessourcen.Clear();

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

        private void encryptingToClipboardNoLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                InsertFromClipboard InsertFromClipboard1 = new InsertFromClipboard();
                InsertFromClipboard1.encryptToClipboard(false, false);

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
