using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Datenerhebung
{


    public partial class frmDatenErhebung : Form
    {


        public frmDatenErhebung()
        {
            InitializeComponent();
        }

        private void frmDatenErhebung_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string lstFormulare)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Datenerhebung, 32, 32);

                this.ucDatenErhebungExtern1.mainWindow = this;
                this.ucDatenErhebungExtern1.initControl(lstFormulare);

            }
            catch (Exception ex)
            {
                throw new Exception("frmDatenErhebung.initControl: " + ex.ToString());
            }
        }

    }
}
