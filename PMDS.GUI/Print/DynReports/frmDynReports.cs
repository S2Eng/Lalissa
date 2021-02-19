using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI
{
    public partial class frmDynReports : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmDynReports(string sBasePath)
        {
            InitializeComponent();
            ucDynReports1.Init(sBasePath);
            this.CancelButton = btnOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucDynReports1_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void frmDynReports_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Berichte, 32, 32);
        }
    }
}