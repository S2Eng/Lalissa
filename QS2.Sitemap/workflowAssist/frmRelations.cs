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


    public partial class frmRelations : Form
    {

        public string  defaultApplication;




        public frmRelations()
        {
            InitializeComponent();
        }


        private void frmRessourcencs_Load(object sender, EventArgs e)
        {
            this.loadForm();
        }

        public void loadForm()
        {
            this.contRelations1.mainWindow = this;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Criterias, 32, 32);
            this.loadRes();
            this.contRelations1.initControl();

            //if (this.contCriterias1.ownMultiControl1 != null)
            //    this.contCriterias1.loadInfoControl(this.defaultApplication);
        }

        public void loadRes()
        {
            this.Text = qs2.core.language.sqlLanguage.getRes("Relations");
        }

    }
}
