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

        public bool _Einzelansicht = false;





        public frmVOMain()
        {
            InitializeComponent();
        }

        private void frmVOMain_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool Einzelansicht)
        {
            try
            {
                if (!PMDS.Global.ENV.lic_VO)
                {
                    return;
                }

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOMain1.mainWindow = this;
                this.ucVOMain1.initControl(Einzelansicht);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOMain.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.ucVOMain1.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOMain.loadData: " + ex.ToString());
            }
        }

        private void frmVOMain_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                }
            
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void frmVOMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

    }
}
