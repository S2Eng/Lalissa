using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win.UltraWinGrid;



namespace PMDS.GUI.BaseControls
{


    public partial class ucEssen : QS2.Desktop.ControlManagment.BaseControl
    {

        private Essen   _essen;
        private bool    _bFirstSet = false;
        public event EventHandler ValueChanged;
        public event EventHandler ValueSaved;
        private bool isLoaded = false;



        public ucEssen()
        {
            InitializeComponent();
        }

        public void initControl()
        {
            _essen = new Essen();
            dtpDate.DateTime = DateTime.Now;
            dtpDate.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            RefreshGrid();
            isLoaded = true;
        }

        public void RefreshGrid()
        {
            DateTime von = new DateTime(dtpDate.DateTime.Year, dtpDate.DateTime.Month, 1);
            DateTime bis = von.AddMonths(1).AddDays(-1);
            _essen.Read(von, bis);
            dgMain.DataMember = "";
            dgMain.DataSource = _essen.ESSEN_DATATABLE;
            dgMain.Refresh();
            SetFirstRow();
        }


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDate.Focused)
            {
                Write();
                RefreshGrid();
                if (ValueSaved != null)
                    ValueSaved(this, null);
            }
        }

        public void SetFirstRow()
        {
            dgMain.PerformAction(UltraGridAction.FirstRowInGrid);
            dgMain.PerformAction(UltraGridAction.ToggleRowSel);
            dgMain.PerformAction(UltraGridAction.NextCellByTab);
            dgMain.PerformAction(UltraGridAction.ActivateCell);
            dgMain.PerformAction(UltraGridAction.EnterEditMode);
        }

        public void Write()
        {
            _essen.Write();
        }

        private void dgMain_Enter(object sender, EventArgs e)
        {
            if (_bFirstSet)
                return;
            SetFirstRow();
            _bFirstSet = true;
        }

        private void dgMain_CellChange(object sender, CellEventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, null);
        }

    }
}
