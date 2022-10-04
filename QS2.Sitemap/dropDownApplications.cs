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


    public partial class dropDownApplications : UserControl
    {


        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
        public bool _OnlyLicensedProducts = false;







        public dropDownApplications()
        {
            InitializeComponent();
        }

        private void dropDownApplications_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool OnlyLicensedProducts)
        {
            try
            {
                this._OnlyLicensedProducts = OnlyLicensedProducts;
                this.loadRes();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadRes()
        {
            this.ultraDropDownApp.DisplayLayout.Bands[0].Columns[this.dsLicense1.Applications.NameColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            this.ultraDropDownApp.DisplayLayout.Bands[0].Columns[this.dsLicense1.Applications.IDColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Key");
            this.ultraDropDownApp.DisplayLayout.Bands[0].Columns[this.dsLicense1.Applications.IDColumn.ColumnName].Hidden = true;
      
        }

        public void loadData()
        {
            try
            {
                this.dsLicense1.Applications.Clear();
                this.doLicense1.FillTableApplications(this.dsLicense1);
                this.ultraDropDownApp.Refresh();

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

    }
}
