using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.Calc.Calc.UI.Other
{


    public partial class frmListePatientenEntlassen : Form
    {




        public frmListePatientenEntlassen()
        {
            InitializeComponent();
        }

        private void frmListePatientenEntlassen_Load(object sender, EventArgs e)
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
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.contListePatientenEntlassen1.mainWindow = this;
                this.contListePatientenEntlassen1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmListePatientenEntlassen.initControl: " + ex.ToString());
            }
        }

    }

}
