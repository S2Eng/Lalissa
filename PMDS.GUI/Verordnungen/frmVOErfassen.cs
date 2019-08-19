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

    public partial class frmVOErfassen : Form
    {

        
        public frmVOErfassen()
        {
            InitializeComponent();
        }

        private void frmVOErfassen_Load(object sender, EventArgs e)
        {

        }

        public void initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI TypeUI, bool Einzelansicht, bool doVerknüpfungen, List<Guid> lstIDVONotShow)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOErfassen1.mainWindow = this;
                this.ucVOErfassen1.initControl(TypeUI, Einzelansicht, doVerknüpfungen, lstIDVONotShow);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOErfassen.initControl: " + ex.ToString());
            }
        }

    }
}
