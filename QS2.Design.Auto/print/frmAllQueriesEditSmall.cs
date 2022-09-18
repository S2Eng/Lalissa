using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QS2.Resources;



namespace qs2.design.auto.print
{


    public partial class frmAllQueriesEditSmall : Form
    {

        public string IDParticipant = "";
        public string defaultApplication = "";







        public frmAllQueriesEditSmall()
        {
            InitializeComponent();
        }


        private void frmAllQueriesEditSmall_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("AssignSubqueries");
                this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Queries, 32, 32);
                this.lblListQueries.Text = qs2.core.language.sqlLanguage.getRes("ListQueries");
                this.btnClose.Appearance.Image = getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                //this.contSelListQueries.mainWindowQueryManage = this;
                this.contSelListQueries.Participant = this.IDParticipant;
                this.contSelListQueries.typeQuery = core.Enums.eTypeQuery.Admin;

                this.contSelListQueries.initControl(defaultApplication, false, false, false, true, false, false);
                //this.contSelListQueries.initControl(defaultApplication, false, false, true, true);

                this.contSelListQueries.loadQueries(null, this.defaultApplication.Trim(), this.IDParticipant, null, true, -999, false);
                           
            }
            catch (Exception ex)
            {
                throw new Exception("frmAllQueriesEditSmall.initControl: " + ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();

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


    }
}
