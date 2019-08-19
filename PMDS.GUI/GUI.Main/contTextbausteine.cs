using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;




namespace PMDS.GUI.GUI.Main
{


    public partial class contTextbausteine : UserControl
    {

        public bool abort = true;

        public frmTextbausteine mainForm = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();



        



        public contTextbausteine()
        {
            InitializeComponent();
        }

        private void contTextbausteine_Load(object sender, EventArgs e)
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

                this.gridTextbausteine.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.Textbausteine.KurzbezeichnungColumn.ColumnName].Width = 580;
                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.sqlManange1.getTextbausteine(System.Guid.Empty, Global.db.ERSystem.sqlManange.eTypeTextbausteine.All, ref this.dsKlientenliste1);
                this.gridTextbausteine.Refresh();


            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.loadData: " + ex.ToString());
            }
        }
        public void clearData()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.gridTextbausteine.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.clearData: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                this.sqlManange1.daTextbausteine.Update(this.dsKlientenliste1.Textbausteine);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.saveData: " + ex.ToString());
            }
        }


        public void addEditRow(bool isNew, Global.db.ERSystem.dsKlientenliste.TextbausteineRow rSelTextbausteine)
        {
            try
            {
                PMDS.GUI.GUI.Main.frmTextbausteinAdd frmTextbausteinAdd1 = new frmTextbausteinAdd();
                frmTextbausteinAdd1.initControl();
                frmTextbausteinAdd1.isNew = isNew;
                if (isNew)
                {
                    frmTextbausteinAdd1.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Textbaustein hinzufügen");
                }
                else
                {
                    frmTextbausteinAdd1.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Textbaustein editieren");
                }
                frmTextbausteinAdd1.rTextbausteine = rSelTextbausteine;
                frmTextbausteinAdd1.ShowDialog(this);
                if (!frmTextbausteinAdd1.abort)
                {
                    if (isNew)
                    {
                        PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.LogggedOnUser();
                        Global.db.ERSystem.dsKlientenliste.TextbausteineRow rNewTextbausteine = this.sqlManange1.newRowTextbaustein(ref this.dsKlientenliste1, rUsr.Benutzer1.Trim());
                        rNewTextbausteine.ItemArray = frmTextbausteinAdd1.rTextbausteine.ItemArray;
                    }
                    else
                    {
                    }
                    this.gridTextbausteine.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.addRow: " + ex.ToString());
            }
        }
        public void deleteRow()
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                Global.db.ERSystem.dsKlientenliste.TextbausteineRow rSelTextbausteine = this.getSelectedRow(true, ref gridRow);
                if (rSelTextbausteine != null)
                {
                    rSelTextbausteine.Delete();
                    this.gridTextbausteine.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contTextbausteine.deleteRow: " + ex.ToString());
            }
        }

        public Global.db.ERSystem.dsKlientenliste.TextbausteineRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridTextbausteine.ActiveRow != null)
                {
                    if (this.gridTextbausteine.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridTextbausteine.ActiveRow.ListObject;
                        Global.db.ERSystem.dsKlientenliste.TextbausteineRow rSelRow = (Global.db.ERSystem.dsKlientenliste.TextbausteineRow)v.Row;
                        gridRow = this.gridTextbausteine.ActiveRow;
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
                throw new Exception("contTextbausteine.getSelectedRow: " + ex.ToString());
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addEditRow(true, null);
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

        private void gridTextbausteine_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridTextbausteine))
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    Global.db.ERSystem.dsKlientenliste.TextbausteineRow rSelTextbausteine = this.getSelectedRow(false, ref gridRow);
                    if (rSelTextbausteine != null)
                    {
                        this.addEditRow(false, rSelTextbausteine);
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

        private void gridTextbausteine_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                this.deleteRow(sender, e);
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        public void deleteRow(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
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

        private void gridTextbausteine_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

    }
}
