using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucZeitbereicheZeitbereichserien : QS2.Desktop.ControlManagment.BaseControl
    {
        private Zeitbereich _Zeitbereich = new Zeitbereich();
        private ZeitbereichSerien _ZeitbereichSerien = new ZeitbereichSerien();
        private bool _ZeitbereichCanged = false;
        private bool _ZeitberechserienCanged = false;

        public ucZeitbereicheZeitbereichserien()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Init: lesen aller zeitbereiche und Zeitbereichserien
        /// </summary>
        //----------------------------------------------------------------------------
        public void Init()
        {
            InitZeitbereiche();
            InitZeitbereichserien();
        }

        /// <summary>
        /// Alle verfügbaren Zeitbereiche lesen
        /// </summary>
        private void InitZeitbereiche()
        {
            dgZeitbereich.DataMember = "";
            dgZeitbereich.DataSource = _Zeitbereich.Read();
        }

        /// <summary>
        /// Alle verfügbaren Zeitbereichserien lesen
        /// </summary>
        private void InitZeitbereichserien()
        {
            dgZeitbereichserien.DataMember = "";
            dgZeitbereichserien.DataSource = _ZeitbereichSerien.Read();
            RefreshZeitbereichValueList();
        }

        private void RefreshZeitbereichValueList()
        {
            // Valuelists laden
            dgZeitbereichserien.DisplayLayout.ValueLists.Clear();
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich0");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich1");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich2");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich3");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich4");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich5");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich6");
            UltraGridTools.AddZeitbereichValueList(dgZeitbereichserien, "IDZeitbereich7");
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ab in die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            //Zeitbereiche
            if (_ZeitbereichCanged)
            {
                _Zeitbereich.Write((dsZeitbereich.ZeitbereichDataTable)dgZeitbereich.DataSource);
                _ZeitbereichCanged = false;
                RefreshZeitbereichValueList();
            }

            //Zeitbereichserein
            SaveZeitbereichserien();
        }

        /// <summary>
        /// Zeitbereichserien speichern
        /// </summary>
        private void SaveZeitbereichserien()
        {
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = (dsZeitbereichSerien.ZeitbereichSerienDataTable)dgZeitbereichserien.DataSource;

            foreach (dsZeitbereichSerien.ZeitbereichSerienRow r in dt)              // Alle Guid.empty (wegen Combo) in nul umwandeln
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (!r.IsIDZeitbereich0Null() && r.IDZeitbereich0 == Guid.Empty) r.SetIDZeitbereich0Null();
                if (!r.IsIDZeitbereich1Null() && r.IDZeitbereich1 == Guid.Empty) r.SetIDZeitbereich1Null();
                if (!r.IsIDZeitbereich2Null() && r.IDZeitbereich2 == Guid.Empty) r.SetIDZeitbereich2Null();
                if (!r.IsIDZeitbereich3Null() && r.IDZeitbereich3 == Guid.Empty) r.SetIDZeitbereich3Null();
                if (!r.IsIDZeitbereich4Null() && r.IDZeitbereich4 == Guid.Empty) r.SetIDZeitbereich4Null();
                if (!r.IsIDZeitbereich5Null() && r.IDZeitbereich5 == Guid.Empty) r.SetIDZeitbereich5Null();
                if (!r.IsIDZeitbereich6Null() && r.IDZeitbereich6 == Guid.Empty) r.SetIDZeitbereich6Null();
                if (!r.IsIDZeitbereich7Null() && r.IDZeitbereich7 == Guid.Empty) r.SetIDZeitbereich7Null();
            }
            _ZeitbereichSerien.Write(dt);
        }

        private bool ValidateDelZeitbereich(UltraGridRow[] rows)
        {
            dsZeitbereichSerien.ZeitbereichSerienDataTable dt = (dsZeitbereichSerien.ZeitbereichSerienDataTable)dgZeitbereichserien.DataSource;
            dsZeitbereichSerien.ZeitbereichSerienRow[] zbRows;
            StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();
            foreach (UltraGridRow r in rows)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (sb.Length > 0) sb.Append(" OR ");
                    sb.Append("IDZeitbereich" + i + "= '" + (Guid)r.Cells["ID"].Value + "'");
                }
                    
                zbRows = (dsZeitbereichSerien.ZeitbereichSerienRow[])dt.Select(sb.ToString());

                if (zbRows.Length > 0)
                    list.Add(r.Cells["Bezeichnung"].Value.ToString());

            }

            if (list.Count > 0)
            {
                sb = new StringBuilder(); 
                if (list.Count == 1)
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgender Zeitbereich ist in Zeitbereichserien zugeordnet, daher kann er"));
                else
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Zeitbereiche sind in Zeitbereichserien zugeordnet, daher können sie"));
                sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" nicht gelöscht werden."));
                foreach (string s in list)
                    sb.Append("\n\t - " + s);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), true);
                return false;
            }
            else
                return true;
        }

        private void dgZeitbereich_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            _ZeitbereichCanged = true;
        }

        private void dgZeitbereichserien_Enter(object sender, EventArgs e)
        {
            if (_ZeitbereichCanged)
            {
                _ZeitbereichCanged = false;
                _Zeitbereich.Write((dsZeitbereich.ZeitbereichDataTable)dgZeitbereich.DataSource);
                RefreshZeitbereichValueList();
            }
        }

        private void dgZeitbereich_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = !ValidateDelZeitbereich(e.Rows);
        }

        private void dgZeitbereich_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
            DateTime dt = new DateTime(1900, 1, 1, 0, 0, 0);
            e.TemplateAddRow.Cells["von"].Value = dt;
            e.TemplateAddRow.Cells["bis"].Value = dt;
        }

        private void dgZeitbereichserien_InitializeTemplateAddRow(object sender, Infragistics.Win.UltraWinGrid.InitializeTemplateAddRowEventArgs e)
        {
            e.TemplateAddRow.Cells["ID"].Value = Guid.NewGuid();
        }

        private void dgZeitbereichserien_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void dgZeitbereich_Enter(object sender, EventArgs e)
        {
            if (_ZeitberechserienCanged)
            {
                _ZeitberechserienCanged = false;
                SaveZeitbereichserien();
            }
        }

        private void dgZeitbereichserien_AfterRowUpdate(object sender, Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            _ZeitberechserienCanged = true;
        }

        private void dgZeitbereichserien_AfterRowsDeleted(object sender, EventArgs e)
        {
            _ZeitberechserienCanged = true;
        }

        private void dgZeitbereich_AfterRowsDeleted(object sender, EventArgs e)
        {
            _ZeitbereichCanged = true;
        }
    }
}
