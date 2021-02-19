using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;




namespace PMDS.GUI.Fortbildung
{


    public partial class frmVerwaltungFortbildungen : Form
    {


        public frmVerwaltungFortbildungen()
        {
            InitializeComponent();
        }

        private void frmFortbildungen_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenliste.ico_Klientenakt, 32, 32);
                
                this.ucVerwaltungFortbildungen1.mainWindow = this;
                this.ucVerwaltungFortbildungen1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmVerwaltungFortbildungen.initControl: " + ex.ToString());
            }
        }

    }
}
