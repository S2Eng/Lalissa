using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;
using QS2.Resources;



namespace qs2.ui.print
{


    public partial class frmQryAdmin : Form
    {

        public bool UnvisibleOnClose = false;






        public frmQryAdmin()
        {
            InitializeComponent();
        }


        private void frmRessourcencs_Load(object sender, EventArgs e)
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
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        public void loadForm()
        {
            try
            {
                this.contQryAdmin1.mainWindow = this;
                this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Queries, 32, 32);
                this.loadRes();
                this.contQryAdmin1.initControl(this.contQryAdmin1.DefaultApplication);
                this.contQryAdmin1.loadQueries(null, true, true);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
            }
        }

        public void loadRes()
        {
            if (this.contQryAdmin1.typeQuery == core.Enums.eTypeQuery.Admin)
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("QuerysAdmin");
            }
            else if (this.contQryAdmin1.typeQuery == core.Enums.eTypeQuery.User)
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("QueriesUser");
            }
        }

        private void frmQryAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.UnvisibleOnClose)
            {
                this.Visible = false;
                e.Cancel = true;
            }
            else
            {
                
            }
        }

    }
}
