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

namespace PMDS.GUI.BaseControls
{

    public partial class contEintraegeQuickEdit : UserControl
    {

        public bool abort = true;

        public frmEintraegeQuickEdit mainWindow = null;

        public UIGlobal UIGlobal1 = new UIGlobal();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new Global.db.ERSystem.PMDSBusinessUI();

        public string _EintragGruppe = "";
        public int _iEntferntJN = -1;
        public string _EintragText = "";

        public string colTxt = "Txt";







        public contEintraegeQuickEdit()
        {
            InitializeComponent();
        }

        private void contASZMQuickEdit_Load(object sender, EventArgs e)
        {

        }


        public void initControl(string EintragGruppe, int iEntferntJN, string EintragText)
        {
            try
            {
                this._EintragGruppe = EintragGruppe;
                this._iEntferntJN = iEntferntJN;
                this._EintragText = EintragText;

                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;

                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);

                this.mainWindow.Text += " (" + this._EintragGruppe.Trim() + ")";

                this.sqlManange1.initControl();

                if (ENV.adminSecure)
                {
                    //this.gridASZM.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName].Hidden = false;
                }
                else
                {
                }

                this.lblFound.Text = "";

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("contASZMQuickEdit.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.sqlManange1.getEintrag(this.dsKlientenliste1, this._EintragText, null, this._EintragGruppe, this._iEntferntJN, sqlManange.eTypeEintrag.Gruppe);
                this.gridASZM.Refresh();
                foreach (UltraGridRow rGrid in this.gridASZM.Rows)
                {
                    DataRowView v = (DataRowView)rGrid.ListObject;
                    dsKlientenliste.EintragRow rSelRow = (dsKlientenliste.EintragRow)v.Row;

                    rGrid .Cells[this.colTxt.Trim()].Value = rSelRow.Text.Trim() + " (" + rSelRow.Warnhinweis.Trim() + ")";
                }
                
                this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + this.dsKlientenliste1.Eintrag.Rows.Count.ToString() + "";

            }
            catch (Exception ex)
            {
                throw new Exception("contASZMQuickEdit.loadData: " + ex.ToString());
            }
        }

        public bool saveData()
        {
            try
            {
                this.sqlManange1.daEintrag.Update(this.dsKlientenliste1.Eintrag);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contASZMQuickEdit.saveData: " + ex.ToString());
            }
        }


        public dsKlientenliste.EintragRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridASZM.ActiveRow != null)
                {
                    if (this.gridASZM.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridASZM.ActiveRow.ListObject;
                        dsKlientenliste.EintragRow rSelRow = (dsKlientenliste.EintragRow)v.Row;
                        gridRow = this.gridASZM.ActiveRow;
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
                throw new Exception("contASZMQuickEdit.getSelectedRow: " + ex.ToString());
            }
        }




        private void gridASZM_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.dsKlientenliste1.Eintrag.EntferntJNColumn.ColumnName.Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridASZM_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridASZM))
                {
                    UltraGridRow rGridSel = null;
                    dsKlientenliste.EintragRow rSelRow = this.getSelectedRow(false, ref rGridSel);
                    if (rSelRow != null)
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridASZM_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridASZM))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridASZM_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.saveData())
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
        private void btnAbort_Click(object sender, EventArgs e)
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

    }

}

