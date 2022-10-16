using System;
using System.Windows.Forms;

//Used in Lellissa: do not remove!

namespace qs2.sitemap.workflowAssist
{
    public partial class frmInfoFieldDB : Form
    {
        public frmInfoFieldDB()
        {
            InitializeComponent();
        }

        private void frmInfoFieldDB2_Load(object sender, EventArgs e)
        {
            try
            {
                contInfoFieldDB1.typUI = contInfoFieldDB.eTypUI.showOnly;
                contInfoFieldDB1.initControl(null, false);
                contInfoFieldDB1.mainWindow = this;

                Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
                Text = qs2.core.language.sqlLanguage.getRes("infoFieldSQLServer") + (contInfoFieldDB1.searchColumnText.Trim() != "" ? " [" + contInfoFieldDB1.searchColumnText + "]" : "");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
