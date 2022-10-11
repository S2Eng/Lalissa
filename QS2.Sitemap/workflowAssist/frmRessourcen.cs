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


    public partial class frmRessourcen : Form
    {

        public bool doSearchAuto = false;
        public string searchAuto = "";
        public string defaultApplication;


        public frmRessourcen()
        {
            InitializeComponent();
        }


        private void frmRessourcencs_Load(object sender, EventArgs e)
        {
            this.loadForm();
        }

        public void loadForm()
        {
            this.contRessourcen1.mainWindow = this;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32);
            this.loadRes();
            this.contRessourcen1.initControl();

            if (this.doSearchAuto)
                this.contRessourcen1.initControl(this.defaultApplication, this.searchAuto);
        }

        public void loadRes()
        {
            this.Text = qs2.core.language.sqlLanguage.getRes("RessourcenManager") + " (" +
                        qs2.core.language.sqlLanguage.getRes("ActiveLanguage") + ": " + qs2.core.language.sqlLanguage.getRes(qs2.core.ENV.Language.ToString()) + ")";
        
        }

    }
}
