using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{

    public partial class QuickFilterButton : QS2.Desktop.ControlManagment.BaseButton
    {

        public Infragistics.Win.UltraWinGrid.UltraGrid _grid = null;

        public QS2.Desktop.ControlManagment.ControlManagment.onSaveLayoutClick onSaveLayoutClick = null;
        public PMDS.DB.DBQuickFilter DBQuickFilter1 = new DB.DBQuickFilter();

        public QuickFilterButtons MainWindow = null;



        



        public QuickFilterButton()
        {
            InitializeComponent();
        }



        public void initControl()
        {
            try
            {
                this.VisibleChanged += new System.EventHandler(this.QuickFilterButton_VisibleChanged);
            }
            catch (Exception ex)
            {
                throw new Exception("QuickFilterButton.initControl:" + ex.ToString());
            }
        }
        public void SetGrid(QS2.Desktop.ControlManagment.BaseGrid grid)
        {
            try
            {
                this._grid = grid;
                base.doBaseElements1.InfoControl.grid = grid;
            }
            catch (Exception ex)
            {
                throw new Exception("QuickFilterButton.SetGrid:" + ex.ToString());
            }
        }

        private void QuickFilterButton_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                this.doVisible();
            }
            catch (Exception ex)
            {
                throw new Exception("QuickFilterButton_VisibleChanged: " + ex.ToString());
            }
        }

    }
}
