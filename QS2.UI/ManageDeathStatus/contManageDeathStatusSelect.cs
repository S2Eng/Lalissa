using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qs2.ui.ManageDeathStatus
{
    public partial class contManageDeathStatusSelect : UserControl
    {
        private frmManageDeathStatusSelect frmParent;

        public contManageDeathStatusSelect()
        {
            InitializeComponent();
        }

        public void InitControl(frmManageDeathStatusSelect frmParent)
        {
            this.frmParent = frmParent;
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                btnStartService.Text = qs2.core.language.sqlLanguage.getRes("ManageDeathStatus.StartService", false);
                btnStartXlsX.Text = qs2.core.language.sqlLanguage.getRes("ManageDeathStatus.StartXLSX", false);
            }
        }

        private void btnStartXlsX_Click(object sender, EventArgs e)
        {
            using (ManageDeathStatus.frmManageDeathStatusExcel frm = new ManageDeathStatus.frmManageDeathStatusExcel())
            {
                this.frmParent.WindowState = FormWindowState.Minimized;
                if (frm.InitControl())
                {
                    frm.ShowDialog();
                    frmParent.Close();
                }
                else
                {
                    frmParent.WindowState = FormWindowState.Normal;
                }
            }
        }
    }
}
