using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;



namespace qs2.sitemap.manage.wizardsDevelop
{


    public partial class frmCriterias : Form
    {

        public bool doSearchAuto = false;
        public string searchAuto = "";
        public string defaultApplication;
        public bool isInitialized = false;









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
                this.loadRes();
                this.contCriterias1.initControl(TypeUI);

                if (this.doSearchAuto)
                    this.contCriterias1.initControl(this.defaultApplication, this.searchAuto);

                //if (this.contCriterias1.ownMultiControl1 != null)
                //    this.contCriterias1.loadInfoControl(this.defaultApplication);

                this.isInitialized = true;
            }
        }

        public void loadRes()
        {
            this.Text = qs2.core.language.sqlLanguage.getRes("CriteriasManager") + " (" +
                        qs2.core.language.sqlLanguage.getRes("ActiveLanguage") + ": " + qs2.core.language.sqlLanguage.getRes(qs2.core.ENV.language.ToString()) + ")";
        
      
        }

    }
}
