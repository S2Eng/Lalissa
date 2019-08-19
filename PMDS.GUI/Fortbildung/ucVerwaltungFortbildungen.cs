using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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


    public partial class ucVerwaltungFortbildungen : UserControl
    {

        public frmVerwaltungFortbildungen mainWindow = null;

        public bool Isinitialized = false;






        public ucVerwaltungFortbildungen()
        {
            InitializeComponent();
        }

        private void ucVerwaltungFortbildungen_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.ucFortbildungenMain1.mainWindow = this;
                    this.ucFortbildungenMain1.initControl();

                    this.ucFortbildungenList1.mainWindow = this;
                    this.ucFortbildungenList1.initControl();

                    this.ucVeranstalter1.mainWindow = this;
                    this.ucVeranstalter1.initControl();

                    this.ucVeranstalter1.setUI(1);

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungFortbildungen.initControl: " + ex.ToString());
            }
        }
        

    }
}
