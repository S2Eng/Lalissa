using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.BaseControls
{


    public partial class frmEditMedizinischeTypen2 : Form
    {



        public frmEditMedizinischeTypen2()
        {
            InitializeComponent();
        }

        private void frmEditMedizinischeTypen2_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contEditMedizinischeTypen21.mainWindow = this;
                this.contEditMedizinischeTypen21.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmEditMedizinischeTypen2.initControl: " + ex.ToString());
            }
        }

    }

}
