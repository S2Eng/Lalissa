using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI.GUI.Main
{



    public partial class frmTextbausteine : Form
    {


        public frmTextbausteine()
        {
            InitializeComponent();
        }




        private void frmTextbausteine_Load(object sender, EventArgs e)
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

                this.contTextbausteine1.mainForm = this;
                this.contTextbausteine1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("initControl: " + ex.ToString());
            }
        }

    }
}
