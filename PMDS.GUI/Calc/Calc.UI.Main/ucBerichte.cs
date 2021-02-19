using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;


namespace PMDS.Calc.UI.Admin
{

    public partial class ucBerichte : QS2.Desktop.ControlManagment.BaseControl
    {


        public ucBerichte()
        {
            InitializeComponent();
        }
        public void  initControl()
        {
            ucDynReports1.Init(ENV.DYNREPORTABRECHNUNGPATH  );
        }

        public bool ValidateFields()
        {
            return true;
        }

        public void RefreshControl()
        {
            //if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning) return;
            ////ucDynReports1.Init(ENV.DynReportPath);   // Reportliste laden    
            //ucDynReports1.Init(ENV.DynReportExtrasPath);
        }

    }
}
