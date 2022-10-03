using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;





namespace qs2.sitemap
{


    public partial class dropDownStays : UserControl
    {

        public bool isLoaded = false;


        public dropDownStays()
        {
            InitializeComponent();
        }

        private void dropDownCountries_Load(object sender, EventArgs e)
        {
            
        }

        public void initControl()
        {
            try
            {
                if (this.isLoaded) return;

                this.sqlObjects1.initControl();
                this.loadRes();

                qs2.core.generic.getOPTypes(this.infragdropDownStays.DisplayLayout.ValueLists["OPTyp"], null, false);
                qs2.core.generic.getStayTypes(this.infragdropDownStays.DisplayLayout.ValueLists["StayTyp"], null);

                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.StayTypColumn.ColumnName].ValueList = this.infragdropDownStays.DisplayLayout.ValueLists["StayTyp"];
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.OPTypColumn.ColumnName].ValueList = this.infragdropDownStays.DisplayLayout.ValueLists["OPTyp"];

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.infragdropDownStays.DisplayLayout.Bands[0].Columns)
                {
                    col.Hidden = true;
                }

                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.MedRecNColumn.ColumnName].Hidden = false;
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.StayTypColumn.ColumnName].Hidden = false;
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.OPTypColumn.ColumnName].Hidden = false;
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.SurgDtStartColumn.ColumnName].Hidden = false;
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.SurgDtEndColumn.ColumnName].Hidden = false;
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.IsPlannedColumn.ColumnName].Hidden = false;
                
                this.isLoaded = true;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadRes()
        {
            try
            {
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.MedRecNColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("MedicalRecordNr");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.SurgDtStartColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("StartOfSurgery");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.SurgDtEndColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("EndOfSurgery");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.AdmitDtColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("DateOfAdmission");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.IsPlannedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("IsPlaned");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.IDColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.StayTypColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ");
                this.infragdropDownStays.DisplayLayout.Bands[0].Columns[this.dsObjects1.tblStay.OPTypColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("OPTyp");
                
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
