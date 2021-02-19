using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;



namespace PMDS.GUI.Medikament
{



    public partial class frmSearchMedikamente : Form
    {


        public frmSearchMedikamente()
        {
            InitializeComponent();
        }

        private void frmSearchMedikamente_Load(object sender, EventArgs e)
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
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                this.AcceptButton = this.contSearchMedikamente1.btnSearch;
                this.CancelButton = this.contSearchMedikamente1.btnAbort;

                this.contSearchMedikamente1.MainWindow = this;
                this.contSearchMedikamente1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmSearchMedikamente.initControl: " + ex.ToString());
            }
            finally
            {
            }
        }
    }
}
