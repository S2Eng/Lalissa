using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//lthArztabrechnung   neues Form integrieren in PMDS.int (Neuer Ordner Arzabrechnung in PMDS.GUI)


namespace PMDS.GUI.Arztabrechnung
{


    public partial class frmArztabrechnungManage : Form
    {



        public frmArztabrechnungManage()
        {
            InitializeComponent();
        }

        private void frmArztabrechnungManage_Load(object sender, EventArgs e)
        {

        }
        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Abrechnung.ico_Abrechnung, 32, 32);

                this.contArztabrechnungManage1.mainWindow = this;
                this.contArztabrechnungManage1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmArztabrechnung.initControl: " + ex.ToString());
            }
        }

    }


}
