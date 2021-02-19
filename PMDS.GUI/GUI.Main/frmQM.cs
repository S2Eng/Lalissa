using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VirtualKeyboard;

namespace PMDS.GUI
{
    public partial class frmQM : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmQM()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void frmQM_LocationChanged(object sender, EventArgs e)
        {
            ucQM1.MyLocationChanged();
        }

        private void ucQM1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            this.Close();
        }

        private void frmQM_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnExit.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
            }
        }


    }
}