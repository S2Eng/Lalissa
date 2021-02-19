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


    public partial class frmManageDocuments : Form
    {



        public frmManageDocuments()
        {
            InitializeComponent();
        }


        private void frmManageDocuments_Load(object sender, EventArgs e)
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

                this.contManageDocuments1.mainForm = this;
                this.contManageDocuments1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmManageDocuments.initControl: " + ex.ToString());
            }
        }

        private void contManageDocuments1_Load(object sender, EventArgs e)
        {

        }
    }
}
