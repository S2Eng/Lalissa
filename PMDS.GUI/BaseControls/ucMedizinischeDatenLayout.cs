//----------------------------------------------------------------------------
/// <summary>
///	ucMedizinischeDatenLayout.cs
/// Erstellt am:	06.06.2007
/// Erstellt von:	MDA
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucMedizinischeDatenLayout : QS2.Desktop.ControlManagment.BaseControl
    {
        private MedizinischeDatenLayout _medVerwaltung;


        public ucMedizinischeDatenLayout()
        {
            InitializeComponent();
            _medVerwaltung = new MedizinischeDatenLayout();
        }

        public void RefreshControl()
        {
            _medVerwaltung.Read();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            bool bError = false;

            //Prüfung:
            // - Reihenfolge darf nicht größer als 5
            // - Keine Lücken zwichen die Zahlen (z.b: 1, 3, 5)
            foreach (UltraGridRow r in grid.Rows)
                bError = bError || ValdateMaxValue(r);
 
            return !bError;
        }
        private bool IsInteger(object val)
        {
            try
            {
                int n = Convert.ToInt32(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValdateMaxValue(UltraGridRow r)
        {

            bool error = false;
            DataRowView v = (DataRowView)r.ListObject;
            DataRow row = v.Row;
            row.RowError = "";
            List<int> list = new List<int>();
            float output;
            for (int i = 3; i < r.Cells.Count; i++)
            {
                if (r.Cells[i].Value != DBNull.Value && float.TryParse(r.Cells[i].Value.ToString(), out output))
                {
                    int iVal = (int)r.Cells[i].Value;
                    if (iVal >= 1000)
                    {
                        iVal = iVal - 1000;
                    }
                    list.Add(iVal);
                }   
            }

            ControlComparer cc = new ControlComparer();
            list.Sort(cc);

            if (list[list.Count - 1] > 5)
                error = true;
            if (list.Count == 0 || list[0] != 1)
                error = true;
            else
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i + 1] != list[i] + 1)
                    {
                        error = true;
                        break;
                    }
                }
            }

            if (error)
            {
                row.RowError = "Logischer Fehler";
            }

            return error;
        }

        public void Write()
        {
            _medVerwaltung.Write();
        }

        private void ucMedizinischetypVerwaltung_Load(object sender, EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning)
                return;

            _medVerwaltung.Read();
            grid.DataSource = _medVerwaltung.ALL;
        }

        //private void grid_CellChange(object sender, CellEventArgs e)
        //{
        //    ValdateMaxValue(e.Cell.Row);
        //}

        private void grid_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            //if (grid.ActiveRow == null)
            //    return;

            //ValdateMaxValue(grid.ActiveRow);
        }

        private void grid_BeforeRowUpdate(object sender, CancelableRowEventArgs e)
        {

        }

        private void grid_AfterRowUpdate(object sender, RowEventArgs e)
        {
            ValdateMaxValue(e.Row);
        }

        private class ControlComparer : IComparer<int>
        {
            public int Compare(int n1, int n2)
            {
                return n1.CompareTo(n2);
            }
        }

    }
}
