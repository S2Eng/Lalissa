using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.Calc.UI.Admin
{
    public partial class frmProtocoll : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmProtocoll()
        {
            InitializeComponent();
        }

        private void frmProtocoll_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
        }
    }
}
