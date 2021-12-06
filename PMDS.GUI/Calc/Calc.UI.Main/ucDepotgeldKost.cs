using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;

using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Abrechnung.Global;





namespace PMDS.GUI
{


    public partial class ucDepotgeldKost : QS2.Desktop.ControlManagment.BaseControl
    {

        private PatientTaschengeldKostentraeger _patTaschengeldKostentraeger;
        private PMDS.Global.db.Global.ds_abrechnung.dsPatientTaschengeldKostentraeger _ds;

        public System.Guid IDKlient;
        public PMDS.Klient.frmDepotgeldKost mainWindow;




        public ucDepotgeldKost()
        {
            InitializeComponent();
        }
        public void  initControl()
        {
            _patTaschengeldKostentraeger = new PatientTaschengeldKostentraeger();
            _ds = new PMDS.Global.db.Global.ds_abrechnung.dsPatientTaschengeldKostentraeger();
            PMDS.GUI.UltraGridTools.AddBenutzerValueList(dgMain, "IDBenutzer");
        }

        public bool Save()
        {
            try
            {
                if (!ValidateFields())
                    return false;

                this.dgMain.UpdateData();
                _patTaschengeldKostentraeger.Update(_ds);
                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
             
        public void loadData()
        {
             _ds = _patTaschengeldKostentraeger.Read(IDKlient);
            _ds.PatientTaschengeldKostentraeger.IDKostentraegerColumn.AllowDBNull = true;
            _ds.PatientTaschengeldKostentraeger.GueltigABColumn.AllowDBNull = true;
            _ds.PatientTaschengeldKostentraeger.GueltigBisColumn.AllowDBNull = true;
            _ds.PatientTaschengeldKostentraeger.BetragColumn.AllowDBNull = true;
            _ds.PatientTaschengeldKostentraeger.ErfasstAmColumn.AllowDBNull = true;
            _ds.PatientTaschengeldKostentraeger.IDBenutzerColumn.AllowDBNull = true;
            dgMain.DataSource = _ds;

            UltraGridTools.AddTaschengeldKostentraegerValueList(dgMain, "IDKostentraeger", true, true, ENV.IDKlinik, IDKlient);
        }
        

        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow row in dgMain.Rows)
            {
                if (row.IsGroupByRow || row.IsDeleted) continue;

                //row.Cells["GueltigAB"].Value = ((DateTime)row.Cells["GueltigAB"].Value).Date;
                //row.Cells["GueltigBis"].Value = ((DateTime)row.Cells["GueltigBis"].Value).Date;

                if ((double)row.Cells["Betrag"].Value != (double)100000) row.Cells["Betrag"].Value = (double)100000;

                foreach (UltraGridCell cell in row.Cells)
                {
                    if (!ValidateField(cell))
                    {
                        bError = true;
                        break;
                    }
                }

                if (bError) break;
            }

            return !bError;
        }
        private bool ValidateField(UltraGridCell cell)
        {
            bool bError = false;

            if (cell == null || cell.Row.ListObject == null)
                return !bError;

            DataRowView v = (DataRowView)cell.Row.ListObject;
            dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow r = (dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow)v.Row;
            dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerDataTable dt = (dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerDataTable)r.Table;

            r.SetColumnError(cell.Column.Index, "");
            DateTime bis = !r.IsGueltigBisNull() ? r.GueltigBis : abrech.GueltigBis;

            if (cell.Column.Key == dt.IDKostentraegerColumn.ColumnName || 
                cell.Column.Key == dt.GueltigABColumn.ColumnName ||
                cell.Column.Key == dt.GueltigBisColumn.ColumnName || 
                cell.Column.Key == dt.BetragColumn.ColumnName ||
                cell.Column.Key == dt.ErfasstAmColumn.ColumnName ||
                cell.Column.Key == dt.IDBenutzerColumn.ColumnName
               )
            {
                if (cell.Column.Key == dt.IDKostentraegerColumn.ColumnName || cell.Column.Key == dt.IDBenutzerColumn.ColumnName)
                {
                    Guid id = (cell.EditorResolved.IsInEditMode) ? (Guid)cell.EditorResolved.Value : (Guid)cell.Value;

                    GuiUtil.ValidateField(dgMain, id != Guid.Empty,
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                }
                else if(cell.Column.Key != dt.GueltigBisColumn.ColumnName)
                {
                    GuiUtil.ValidateField(dgMain, cell.Text.Trim().Length > 0,
                                         ENV.String("GUI.E_NO_TEXT"), ref bError, false, null);
                }

                if (bError)
                    r.SetColumnError(cell.Column.Index, ENV.String("GUI.E_NO_TEXT"));

                if(!bError && (cell.Column.Key == dt.GueltigABColumn.ColumnName || cell.Column.Key == dt.GueltigBisColumn.ColumnName))
                {
                    string txt = "";
                    if (cell.Column.Key == dt.GueltigBisColumn.ColumnName)
                    {
                        txt = "Das Datum Gültig bis darf nicht vor dem " + r.GueltigAB.ToString("dd.MM.yyyy") + " liegen. Bitte ändern"; 
                        GuiUtil.ValidateField(dgMain, r.GueltigAB <= bis,
                                             txt, ref bError, false, null);

                        //if (!bError && cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value != DBNull.Value)
                        //{
                        //    DateTime t = new DateTime(1900, 1, 1);
                        //    DateTime.TryParse(cell.Text.Trim(), out t);
                        //    t = (cell.Text.Trim() != "" && t != new DateTime(1900, 1, 1)) ? t : abrech.GueltigBis;
                        //    DateTime dtAbgBis = (DateTime)cell.Row.Cells[dt.AbgerechnetBisColumn.ColumnName].Value;
                        //    txt = "Es wurde bereits bis " + dtAbgBis.ToString("dd.MM.yyyy") +
                        //                 " abgerechnet. Das Datum Gültig bis darf nicht kleiner als " + dtAbgBis.ToString("dd.MM.yyyy");
                        //    GuiUtil.ValidateField(dgMain, t >= dtAbgBis, txt, ref bError, false, null);

                        //    if (bError)
                        //        r.SetColumnError(cell.Column.Index, txt);
                        //}
                    }

                    if (bError)
                        r.SetColumnError(cell.Column.Index, txt);

                    if (!bError)
                    {
                        StringBuilder sb;
                        DateTime prBis;
                        dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow[] rows = (dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow[])_ds.PatientTaschengeldKostentraeger.Select("", "GueltigAB, GueltigBis");
                        foreach (dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow pr in rows)
                        {
                            if (pr.RowState == DataRowState.Deleted) continue;

                            if (pr.ID == r.ID) continue;
                            prBis = pr.IsGueltigBisNull() ? abrech.GueltigBis : pr.GueltigBis;

                            sb = new StringBuilder();
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Für der Zeitraum ") + r.GueltigAB.ToString("dd.MM.yyyy"));
                            
                            if (!r.IsGueltigBisNull())
                                sb.Append(" - " + bis.ToString("dd.MM.yyyy"));
                            
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits ein Kostenträger. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern."));

                            GuiUtil.ValidateField(dgMain, (bis.Date < pr.GueltigAB.Date || r.GueltigAB.Date > prBis.Date),
                                                 sb.ToString(), ref bError, false, null);
                            if (bError)
                            {
                                r.SetColumnError(dt.GueltigABColumn, sb.ToString());
                                r.SetColumnError(dt.GueltigBisColumn, sb.ToString());
                                break;
                            }
                        }
                    }
                }
            }

            if (bError)
            {
                dgMain.ActiveCell = cell;
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
            return !bError;
        }

        private void AddElement()
        {
            dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow r = _patTaschengeldKostentraeger.New(_ds.PatientTaschengeldKostentraeger, IDKlient);
            PMDS.GUI.UltraGridTools.SelectFieldInLastRowForEdit(dgMain, "IDKostentraeger");

            this.valueChanged();
        }

        private void RemoveSelected()
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in dgMain.Selected.Rows)
                al.Add(r);

            if (al.Count == 0 && dgMain.ActiveRow != null && !dgMain.ActiveRow.IsFilteredOut)
                al.Add(dgMain.ActiveRow);

            UltraGridRow[] ra = (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
            if (ra.Length == 0)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (PMDS.GUI.UltraGridTools.AskRowDelete() != DialogResult.Yes)
                return;

            using (dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerDataTable dt = new dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerDataTable())
            {
                ArrayList al2 = new ArrayList();
                bool del = false;
                foreach (UltraGridRow r in ra)
                {
                    r.Delete(false);
                    del = true;
                }

                if (del)
                {
                    this.valueChanged();
                }

                if (dgMain.Rows.Count > 0)
                {
                    dgMain.ActiveRow = dgMain.Rows[0];
                    dgMain.ActiveRow.Selected = true;
                }
                else
                    dgMain.ActiveRow = null;
            }
        }

        private void InitCellsActivation()
        {
                dgMain.ActiveRow.Cells[_ds.PatientTaschengeldKostentraeger.IDKostentraegerColumn.ColumnName].Activation = Activation.AllowEdit;
                dgMain.ActiveRow.Cells[_ds.PatientTaschengeldKostentraeger.GueltigABColumn.ColumnName].Activation = Activation.AllowEdit;
                dgMain.ActiveRow.Cells[_ds.PatientTaschengeldKostentraeger.ErfasstAmColumn.ColumnName].Activation = Activation.AllowEdit;
                dgMain.ActiveRow.Cells[_ds.PatientTaschengeldKostentraeger.IDBenutzerColumn.ColumnName].Activation = Activation.AllowEdit;
                dgMain.ActiveRow.Cells[_ds.PatientTaschengeldKostentraeger.BetragColumn.ColumnName].Activation = Activation.AllowEdit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddElement();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            RemoveSelected();
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            this.valueChanged();
        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            InitCellsActivation();
        }

        private void dgMain_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            if (dgMain.ActiveCell == null || 
                (dgMain.ActiveCell.Column.Key != "GueltigAB" && 
                dgMain.ActiveCell.Column.Key != "GueltigBis" &&
                dgMain.ActiveCell.Column.Key != "ErfasstAm")) return;

            if (!dgMain.ActiveCell.EditorResolved.IsValid)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                dgMain.ActiveCell.Value = DBNull.Value;
                e.Cancel = true;
                dgMain.Select();
                dgMain.ActiveCell.Selected = true;
                dgMain.ActiveCell.Activate();
                dgMain.Focus();
                dgMain.PerformAction(UltraGridAction.EnterEditMode);
            }
        }

        private void dgMain_Error(object sender, ErrorEventArgs e)
        {
            //e.Cancel = true;
        }


        private void valueChanged()
        {
            mainWindow.uiButtons(true);
        }

        private void dgMain_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            if (dgMain.Focused)
                e.Cancel = true;
        }

    }
}
