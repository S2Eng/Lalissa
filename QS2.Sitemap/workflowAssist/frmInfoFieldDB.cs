using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;





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
                this.Cursor = Cursors.WaitCursor;
                this.loadForm();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public void loadForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.ePicture.ico_sys, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("infoFieldSQLServer") + (this.contInfoFieldDB1.searchColumnText.Trim() != "" ? " [" + this.contInfoFieldDB1.searchColumnText + "]" : "");

                this.contInfoFieldDB1.typUI = contInfoFieldDB.eTypUI.showOnly;
                this.contInfoFieldDB1.initControl(null, false);
                this.contInfoFieldDB1.mainWindow = this;

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

    }
}
