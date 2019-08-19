using PMDS.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.GUI.Main
{

    public partial class frmInfoSchnellrueckmeldungOpend : Form
    {


        public frmInfoSchnellrueckmeldungOpend()
        {
            InitializeComponent();
        }

        private void frmInfoSchnellrueckmeldungOpend_Load(object sender, EventArgs e)
        {
            this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnOK;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }
}
