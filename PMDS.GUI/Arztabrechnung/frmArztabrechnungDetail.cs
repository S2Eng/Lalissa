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


    public partial class frmArztabrechnungDetail : Form
    {


        public frmArztabrechnungDetail()
        {
            InitializeComponent();
        }



        private void frmArztabrechnungcs_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool IsNew, Nullable<Guid> IDArztabrechnung, Nullable<Guid> IDPatient, Guid IDBenutzer, bool Manage)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Abrechnung .ico_Abrechnung, 32, 32);

                this.contArztabrechnung1.MainWindow = this;
                this.contArztabrechnung1.initControl2(IsNew, IDArztabrechnung, IDPatient, IDBenutzer, Manage);

            }
            catch (Exception ex)
            {
                throw new Exception("frmArztabrechnung.initControl: " + ex.ToString());
            }
        }

    }

}
