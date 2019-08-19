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

    public partial class frmEintraegeQuickEdit : Form
    {


        public frmEintraegeQuickEdit()
        {
            InitializeComponent();
        }


        private void frmASZMQuickEdit_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string Gruppe, int iEntferntJN, string EintragText)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.contASZMQuickEdit1.mainWindow = this;
                this.contASZMQuickEdit1.initControl(Gruppe, iEntferntJN, EintragText);

            }
            catch (Exception ex)
            {
                throw new Exception("frmASZMQuickEdit.initControl: " + ex.ToString());
            }
        }

    }

}
