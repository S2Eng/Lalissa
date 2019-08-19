using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global.db.Global;



namespace PMDS.GUI.PflegePlan2
{
    public partial class ucZusatzeintrag : QS2.Desktop.ControlManagment.BaseControl, ISave
    {
        private bool _valueChangeEnabled = true;
        private bool contentChanged = false;
        private ZusatzGruppe _ZusatzGruppe;
        private Guid _IDEintrag = Guid.Empty;
        private bool _ShowButtons = true;

        public event EventHandler ValueChanged;

        public ucZusatzeintrag()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning) return;
            InitCombo();
         
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowUndoSaveButtons
        {
            get { return _ShowButtons; }
            set
            {
                _ShowButtons = value;
                pnlButton.Visible = value;
                if (_ShowButtons != value)
                {
                    dgEintrag.Height = pnlButton.Visible ? dgEintrag.Height + pnlButton.Height : dgEintrag.Height - pnlButton.Height;
                    Height = dgEintrag.Height + 2;
                    dgEintrag.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ZusatzGruppe ZusatzGruppe
        {
            get { return _ZusatzGruppe; }
            set
            {
                _valueChangeEnabled = false;
                _ZusatzGruppe = value;
                dgEintrag.DataSource = _ZusatzGruppe.ZusatzEintraege;
                _valueChangeEnabled = true;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDEintrag
        {
            get { return _IDEintrag; }
            set
            {
                _IDEintrag = value;
                Setfilter();
                dgEintrag.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            }
        }

        #region ISave
        public bool Save()
        {
            if (_ZusatzGruppe != null)
                ZusatzGruppe.Write();

            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            ENV.SignalZusatzeintragChanged(false);
            return true;
        }

        public void Undo()
        {
            if (_ZusatzGruppe != null)
                ZusatzGruppe.Read();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            ENV.SignalZusatzeintragChanged(false);
        }
        public bool IsChanged { get { return contentChanged; } }
        public bool ValidateFields()
        {
            bool bError = false;

            foreach (UltraGridRow r in dgEintrag.Rows)
            {
                if (r.IsFilteredOut) continue;
                bError = !ValidateDataRowCells(r);
                if (bError) break;
            }
            dgEintrag.DisplayLayout.Appearance.BackColor = System.Drawing.Color.White;
            return !bError;
        }
        #endregion


        private void Setfilter()
        {
            dgEintrag.BeginUpdate();
            dgEintrag.Rows.ColumnFilters.ClearAllFilters();

            dgEintrag.Rows.ColumnFilters["IDFilter"].FilterConditions.Add(FilterComparisionOperator.Equals, IDEintrag);
            dgEintrag.EndUpdate();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Spalten Datum, Einzahlung und Auszahlung einer Zeile Prüfen
        /// </summary>
        //----------------------------------------------------------------------------
        private bool ValidateDataRowCells(UltraGridRow row)
        {
            if (row == null || row.ListObject == null)
                return true;

            bool error = false;

            //ColumnError initialisieren
            DataRow r = ((DataRowView)row.ListObject).Row;

            if (r.RowState == DataRowState.Unchanged) return !error;

            r.SetColumnError(r.Table.Columns[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDZusatzEintragColumn.ColumnName], "");
            r.SetColumnError(r.Table.Columns[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDObjektColumn.ColumnName], "");

            string sError = "";

            //Eintra prüfen
            if (row.Cells[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDZusatzEintragColumn.ColumnName].Value == DBNull.Value ||
                row.Cells[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDZusatzEintragColumn.ColumnName].Value.ToString().Trim() == ""
                )
            {
                error = true;
                sError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ein Eintrag auswählen.");

                r.SetColumnError(r.Table.Columns[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDZusatzEintragColumn.ColumnName], sError);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
            }
            else
            {
                int idx = row.Index;

                dsZusatzGruppeEintrag.ZusatzGruppeEintragDataTable dt = (dsZusatzGruppeEintrag.ZusatzGruppeEintragDataTable)dgEintrag.DataSource;

                StringBuilder sb = new StringBuilder();
                sb.Append("ID <>'" + ((Guid)row.Cells["ID"].Value).ToString() + "'");
                sb.Append(" and IDFilter = '" + IDEintrag.ToString() + "'");
                sb.Append(" and IDObjekt = '" + ((Guid)row.Cells["IDObjekt"].Value).ToString() + "'");
                sb.Append(" and IDZusatzEintrag = '" + row.Cells["IDZusatzEintrag"].Value.ToString() + "'");

                dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[] rows = (dsZusatzGruppeEintrag.ZusatzGruppeEintragRow[])dt.Select(sb.ToString());
                sError = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag ist mehrmals der Selben Abteilung zugewiesen. Bitte ändern.");

                if (rows.Length > 0)
                {
                    error = true;
                    DataRow r2 = rows[0];
                    r2.SetColumnError(r2.Table.Columns[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDZusatzEintragColumn.ColumnName], sError);
                    r2.SetColumnError(r2.Table.Columns[dsZusatzGruppeEintrag1.ZusatzGruppeEintrag.IDObjektColumn.ColumnName], sError);
                }
                if (error)
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);

            }

            return !error;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Combo-Boxen befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitCombo()
        {
            // Eintrag-Combo initialisieren
            ValueList vl = new ValueList();
            foreach (dsIDListe.IDListeRow r in ZusatzEintrag.All())
                vl.ValueListItems.Add(r.ID, r.TEXT);

            UltraGridColumn c = dgEintrag.DisplayLayout.Bands[0].Columns["IDZusatzEintrag"];
            c.ValueList = vl;
            c.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            // Abteilungs-Combo initialisieren
            ValueList v2 = new ValueList();
            foreach (dsGUIDListe.IDListeRow r in KlinikAbteilungen.All())
                v2.ValueListItems.Add(r.ID, r.TEXT);

            UltraGridColumn c2 = dgEintrag.DisplayLayout.Bands[0].Columns["IDObjekt"];
            c2.ValueList = v2;
            c2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Buttons aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void UpdateButtons()
        {
            btnDel.Enabled = (dgEintrag.Rows.Count > 0);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs args)
        {
            contentChanged = true;
            btnSave.Enabled = true;
            btnUndo.Enabled = true;

            if (_valueChangeEnabled && (ValueChanged != null))
            {
                ValueChanged(sender, args);
                ENV.SignalZusatzeintragChanged(true);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dsZusatzGruppeEintrag.ZusatzGruppeEintragRow row = _ZusatzGruppe.AddEntry();
            row.IDFilter = IDEintrag;
            OnValueChanged(sender, EventArgs.Empty);
            UpdateButtons();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            UltraGridTools.DeleteCurrentSelectedRow(dgEintrag);
            OnValueChanged(sender, EventArgs.Empty);
            UpdateButtons();
        }

        private void dgEintrag_CellChange(object sender, CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            OnValueChanged(sender, EventArgs.Empty);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
                Save();
        }

        public void setControlsAktivDisable(bool bOn)
        {

            panelButtonsUnten.Visible  = !bOn;
                panelButtonsGrid.Visible = !bOn;
                if (PMDS.Global.historie.HistorieOn)
                {
                    this.dgEintrag.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

                }
                else
                {
                    this.dgEintrag.DisplayLayout.Override.CellClickAction = CellClickAction.Edit;
                }
        }

        private void dgEintrag_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
            {
                e.Cancel = true;
            }

        }
        

    }
}
