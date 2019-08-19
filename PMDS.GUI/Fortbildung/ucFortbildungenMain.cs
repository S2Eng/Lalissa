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


    public partial class ucFortbildungenMain : UserControl
    {

        public bool Isinitialized = false;
        public ucVerwaltungFortbildungen mainWindow = null;





        public ucFortbildungenMain()
        {
            InitializeComponent();
        }

        private void ucFortbildungen_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.ucFortbildungDetails1.mainWindow = this;
                    this.ucFortbildungDetails1.initControl();

                    this.ucFortbildungBenutzerDetails1.mainWindow = this;
                    this.ucFortbildungBenutzerDetails1.initControl();
                    
                    this.ucFortbildungBenutzerList1.mainWindow = this;
                    this.ucFortbildungBenutzerList1.initControl2();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungenMain.initControl: " + ex.ToString());
            }
        }

    }
}
