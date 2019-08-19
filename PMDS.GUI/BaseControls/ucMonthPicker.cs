//----------------------------------------------------------------------------
/// <summary>
///	ucMonthPicker
/// 4.6.2008   erstellt RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using System.Windows.Forms;
using System.Drawing;

namespace PMDS.GUI.BaseControls
{
    public partial class ucMonthPicker : UltraDateTimeEditor
    {
        public ucMonthPicker()
        {
            InitializeComponent();
        }

        public ucMonthPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	eigenen Dropdown verhindern und Menü präsentieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucMonthPicker_BeforeDropDown(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            RefreshMenu();
            mnuMain.Show(PointToScreen(new Point(0,0)));
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Menü gemäß aktuellen Wert aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshMenu()
        {
            mnuMain.Items.Clear();
            DateTime dtCurrent = new DateTime(this.DateTime.Year, this.DateTime.Month, 1);
            DateTime dtStart    = dtCurrent.AddMonths(12);
            if (dtStart > DateTime.Now)
                dtStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1).AddMonths(1).AddDays(-1);
            DateTime dtEnd = dtStart.AddMonths(-24);
            while (dtStart > dtEnd)
            {
                ToolStripItem item  = mnuMain.Items.Add(dtStart.ToString("MM.yyyy"));
                item.Tag            = dtStart;
                item.Click          += new EventHandler(item_Click);
                dtStart             = dtStart.AddMonths(-1);
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Wert setzen
        /// </summary>
        //----------------------------------------------------------------------------
        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            this.DateTime = (DateTime)item.Tag;
        }
    }
}
