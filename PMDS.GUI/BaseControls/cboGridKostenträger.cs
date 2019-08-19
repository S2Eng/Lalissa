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


    public partial class cboGridKostenträger : QS2.Desktop.ControlManagment.BaseControl
    {

       
        
        public cboGridKostenträger()
        {
            InitializeComponent();
        }

        private void cboGridKostenträger_Load(object sender, EventArgs e)
        {
        }

        public bool loadData()
        {
            try
            {
                foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn rGrid in this.dropDownKostenträger.DisplayLayout.Bands[0].Columns)
                {
                    rGrid.Hidden = true;
                }

                this.dropDownKostenträger.DisplayLayout.Bands[0].Columns[this.dsKostentraeger1.Kostentraeger.NameColumn.ColumnName].Hidden = false;
                this.dropDownKostenträger.DisplayLayout.Bands[0].Columns[this.dsKostentraeger1.Kostentraeger.PLZColumn.ColumnName].Hidden = false;
                this.dropDownKostenträger.DisplayLayout.Bands[0].Columns[this.dsKostentraeger1.Kostentraeger.OrtColumn.ColumnName].Hidden = false;
                this.dropDownKostenträger.DisplayLayout.Bands[0].Columns[this.dsKostentraeger1.Kostentraeger.StrasseColumn.ColumnName].Hidden = false;
                this.dropDownKostenträger.DisplayLayout.Bands[0].Columns[this.dsKostentraeger1.Kostentraeger.PatientbezogenJNColumn.ColumnName].Hidden = false;

                this.dsKostentraeger1.Clear();
                this.dbKostentraeger1.Read(false, System.Guid.Empty, ref this.dsKostentraeger1);
                this.dropDownKostenträger.Refresh();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("cboGridKostenträger.loadData: " + ex.ToString());
            }
        }


    }
}
