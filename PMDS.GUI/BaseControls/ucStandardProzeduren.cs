// - Erstellt durch MADA am ????
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using Infragistics.Win;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucStandardProzeduren : QS2.Desktop.ControlManagment.BaseControl
    {
        private StandardProzeduren          _standProzeduren;
        private dsEintrag.EintragDataTable  _massnahmen         = null;

        public ucStandardProzeduren()
        {
            InitializeComponent();

            _standProzeduren = new StandardProzeduren();
        }

        public void RefreshControl()
        {
            _standProzeduren.Read();
            grid.DataSource = _standProzeduren.ALL;
            UltraGridTools.AddEintragValueList(grid, 'M', "IDEintrag", 2);
        }

        public bool Save()
        {
            bool error = false;
            foreach (UltraGridRow r in grid.Rows)
            {
                if (!error && !ValdateRow(r))
                    error = true;
            }

            if (!error)
                _standProzeduren.Write();

            return !error;
        }

        private bool ValdateRow(UltraGridRow r)
        {
            bool error = false;
            DataRowView v = (DataRowView)r.ListObject;
            DataRow row = v.Row;
            row.RowError = "";

            if (r.Cells["Name"].Text.Trim() == "")
            {
                error = true;
                row.RowError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Name eingeben.");
            }

            return !error;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Rows ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        private dsStandardProzeduren.StandardProzedurenRow[] CurrentSelectedRows()
        {
            
            dsStandardProzeduren.StandardProzedurenRow[] list = null;
            List<DataRowView> listDataRowView = new List<DataRowView>();

            foreach (UltraGridRow r in grid.Rows)
            {
                if (r.Selected && r.ListObject != null)
                {
                    listDataRowView.Add((DataRowView)r.ListObject);
                }
            }

            if (listDataRowView.Count > 0)
            {
                list = new dsStandardProzeduren.StandardProzedurenRow[listDataRowView.Count];
                int i = 0;
                foreach (DataRowView v in listDataRowView)
                {
                    list[i] = (dsStandardProzeduren.StandardProzedurenRow)v.Row;
                    i++;
                }

            }

            return list;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Löscht Daetensätze
        /// </summary>
        //----------------------------------------------------------------------------
        private void DeleteDaten()
        {
            UltraGridRow[] ra = UltraGridTools.GetAllRowsFromGroupedUltraGrid(grid, true, true);

            if (ra.Length == 0)
                return;

            DialogResult res;
            if (ra.Length > 1)
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
            else
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);

            if (res != DialogResult.Yes)
                return;

            EintragStandardprozeduren eintStandardprozeduren;

            foreach (UltraGridRow r in ra)
            {

                if (r.ParentRow != null)                    // Die Relation kann immmer ohne Prüfung gelöscht werden
                {
                    r.Delete();
                    continue;
                }

                eintStandardprozeduren = new EintragStandardprozeduren();
                eintStandardprozeduren.ReadByStandardprozedur((Guid)r.Cells["ID"].Value);

                if (eintStandardprozeduren.EintragStdProzedurenByIDStdProz.Count == 0)      //Wenn keine Eintragzuordnung löschen
                {
                    _standProzeduren.Delete((Guid)r.Cells["ID"].Value);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Standardprozedur \"") + r.Cells["Name"].Value.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" kann nicht gelöscht werden. Weil Sie zu folgende Maßnahmen zugeordnet ist:\n"));

                    Eintrag eintrag ;
                    dsEintrag.EintragDataTable table;
                    foreach (dsEintragStandardprozeduren.EintragStandardprozedurenRow row in eintStandardprozeduren.EintragStdProzedurenByIDStdProz)
                    {
                        eintrag = new Eintrag();
                        table = eintrag.Read(row.IDEintrag);

                        sb.Append("\t- " + table[0].Text + "\n");
                    }

                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensatz löschen"), MessageBoxButtons.OK, MessageBoxIcon.Error, true);
                }

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _standProzeduren.New();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteDaten();
        }

        private void ucStandardProzeduren_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
            RefreshControl();
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                DeleteDaten();
            }
        }

        private void grid_BeforeRowInsert(object sender, BeforeRowInsertEventArgs e)
        {
           
        }

        private void grid_InitializeTemplateAddRow(object sender, InitializeTemplateAddRowEventArgs e)
        {
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
            if (e.TemplateAddRow.ParentRow == null)
            {
                e.TemplateAddRow.Cells["ShowPrintDialog"].Value = false;
                e.TemplateAddRow.Cells["NotfallJN"].Value = false;
                e.TemplateAddRow.Cells["Unterdrücken"].Value = false;
            }

            if (e.TemplateAddRow.Band.Key == "StandardProzeduren_EintragStandardprozeduren")                // Dialog zur M Wahl anzeigen 
            {
                e.TemplateAddRow.Cells["IDStandardProzeduren"].Value = e.TemplateAddRow.ParentRow.Cells["ID"].Value;
                e.TemplateAddRow.Cells["IDEintrag"].Value = Guid.Empty;
            }

           

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Maßnahmen für den Picker initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitMassnahmen()
        {
            if (_massnahmen != null)
                return;

            _massnahmen = new PDx().KATALOGE[EintragGruppe.M.ToString()[0]].EINTRAEGE;
        }

        private void grid_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void grid_AfterRowInsert(object sender, RowEventArgs e)
        {
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Verarbeitet den Klick auf eine neue M zum Notfall
        /// </summary>
        //----------------------------------------------------------------------------
        private void grid_ClickCellButton(object sender, CellEventArgs e)
        {
            if (!(e.Cell.Column.Key == "IDEintrag"))
                return;

            
            InitMassnahmen();
            frmPicker picker = new frmPicker(_massnahmen, "Text", "ID", -1, false);
            picker.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme wählen");
            if (picker.ShowDialog() == DialogResult.OK)
                e.Cell.Row.Cells["IDEintrag"].Value = (Guid)picker.Value;
            else
                e.Cell.Row.Cells["IDEintrag"].Value = Guid.Empty;

        }
    }
}
