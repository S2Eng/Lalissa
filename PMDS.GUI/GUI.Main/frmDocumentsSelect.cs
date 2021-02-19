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


    public partial class frmDocumentsSelect : Form
    {


        public frmDocumentsSelect()
        {
            InitializeComponent();
        }

        private void frmDocumentsSelect_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void initControl(Guid IDAbteilung, ref PMDS.Global.db.ERSystem.dsKlientenliste dsKlientenliste1)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.contDocumentSelect1.mainForm = this;
                this.contDocumentSelect1.initControl(IDAbteilung, ref dsKlientenliste1);

            }
            catch (Exception ex)
            {
                throw new Exception("frmDocumentsSelect.initControl: " + ex.ToString());
            }
        }

    }
}
