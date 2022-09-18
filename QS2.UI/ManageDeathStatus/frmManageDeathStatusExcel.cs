using System;
using System.Windows.Forms;
using QS2.Resources;

namespace qs2.ui.ManageDeathStatus
{
    public partial class frmManageDeathStatusExcel : Form
    {
        public frmManageDeathStatusExcel()
        {
            InitializeComponent();
        }

        public bool InitControl()
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("ManageDeathStatus");
                    this.Icon = getRes.getIcon(getRes.ePicture.ico_Criterias, 32, 32);
                }
                this.contManageDeathStatusExcel1.ContMain = this;
                return this.contManageDeathStatusExcel1.InitControl();
            }
            catch (Exception ex)
            {
                throw new Exception("frmManageDeathStatusExcel.cs: " + ex.ToString());
            }
        }
    }
}
