using PMDS.DB;
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


    public partial class frmUrlaub2 : Form
    {


        public frmUrlaub2()
        {
            InitializeComponent();
        }



        private void frmUrlaub2_Load(object sender, EventArgs e)
        {

        }

        public void initControl(Guid IDPatient)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.ucUrlaub21.mainWindow = this;
                this.ucUrlaub21.initControl(IDPatient);

            }
            catch (Exception ex)
            {
                throw new Exception("initControl" + ex.ToString());
            }
        }

    }


}
