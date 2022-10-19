using System;
using System.Windows.Forms;

namespace qs2.sitemap.manage.wizardsDevelop
{
    public partial class frmCriterias : Form
    {
        private bool isInitialized;

        public bool doSearchAuto { get; set; } = false;
        public string searchAuto = "";
        public string defaultApplication;

        public frmCriterias()
        {
            InitializeComponent();
        }


        private void frmRessourcencs_Load(object sender, EventArgs e)
        {

        }

        public void loadForm(contCriterias.eTypeUI TypeUI)
        {
            if (!this.isInitialized)
            {
                this.contCriterias1.mainWindow = this;
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Criterias, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("CriteriasManager") + " (" +
                            qs2.core.language.sqlLanguage.getRes("ActiveLanguage") + ": " + qs2.core.language.sqlLanguage.getRes(qs2.core.ENV.Language) + ")";
                this.contCriterias1.initControl(TypeUI);

                if (this.doSearchAuto)
                    this.contCriterias1.initControl(this.defaultApplication, this.searchAuto);

                this.isInitialized = true;
            }
        }
    }
}
