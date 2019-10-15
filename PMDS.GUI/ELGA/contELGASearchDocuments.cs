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

namespace PMDS.GUI.ELGA
{


    public partial class contELGASearchDocuments : UserControl
    {
        public frmELGASearchDocuments mainWindow = null;
        public bool IsInitialized = false;

        public Guid _IDPatient;
        public bool abort = true;

        public UIGlobal UIGlobal1 = new UIGlobal();





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

                    this.mainWindow.AcceptButton = this.btnSave;
                    this.mainWindow.CancelButton = this.btnAbort;

                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                    this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);




                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.clearUI: " + ex.ToString());
            }
        }


        public void loadData(Nullable<Guid> IDUser, bool isNew, bool editable)
        {
            try
            {
                //PMDS.db.Entities.Benutzer rUsr = this._db.Benutzer.Where(o => o.ID == this._IDUser.Value).First();



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
                //this.errorProvider1.SetError(this.txtELGAUser, "");
                //this.errorProvider1.SetError(this.txtELGAPwd, "");
                //this.errorProvider1.SetError(this.txtELGAPwdWdhlg, "");

                //if (this.txtELGAUser.Text.Trim() == "")
                //{
                //    this.errorProvider1.SetError(this.txtELGAUser, "Error");
                //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Benutzer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                //    return false;
                //}



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
                //PMDS.db.Entities.Benutzer rUsr = this._db.Benutzer.Where(o => o.ID == this._IDUser.Value).First();


                //ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Benutzereinstellungen wurden geändert"), lProt,
                //                                ELGABusiness.eTypeProt.UserSettingsChanged, ELGABusiness.eELGAFunctions.none, "Benutzer", "", this._IDUser);


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASearchDocuments.searchData: " + ex.ToString());
            }
        }


        public bool selectData()
        {
            try
            {


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
                if (this.gridFound.ActiveRow != null)
                {
                    if (this.gridFound.ActiveRow.IsGroupByRow)
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
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile in der Tabelle ausgewählt!");
                    return null;
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
                if (this.selectData())
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
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals(("xy").Trim().ToLower()))
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
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


    }

}

