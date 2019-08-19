using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PMDS.GUI.Kostentraeger.ucKostentraegerKlientEditSingle;


namespace PMDS.GUI.Kostentraeger
{

    public partial class frmKostentraegerKlientEditSingle : Form
    {





        public frmKostentraegerKlientEditSingle()
        {
            InitializeComponent();
        }

        private void frmKostentraegerKlientEditSingle_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDPatient, Nullable<Guid> IDKostenträger, Nullable<Guid> IDPatientKostenträger, bool isNew, eTypeUI TypeUI)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucKostentraegerKlientEditSingle1.mainWindow = this;
                this.ucKostentraegerKlientEditSingle1.initControl(TypeUI);
                this.ucKostentraegerKlientEditSingle1.loadData(IDPatient, IDKostenträger, IDPatientKostenträger, isNew);

            }
            catch (Exception ex)
            {
                throw new Exception("frmKostentraegerKlientEditSingle.initControl: " + ex.ToString());
            }
        }


    }


}
