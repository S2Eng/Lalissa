using PMDS.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Verordnungen
{

    public partial class frmVOMain : Form
    {
        public frmVOMain()
        {
            InitializeComponent();
        }

        public void initControl(bool Einzelansicht)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS2.ico_Verordnungen_03, 32, 32);

                ucVOMain1.mainWindow = this;
                ucVOMain1.initControl(Einzelansicht);
            }
            catch (Exception ex)
            {
                throw new Exception("frmVOMain.initControl: " + ex.ToString());
            }
        }

        private void frmVOMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            this.Visible = false;
        }

    }
}
