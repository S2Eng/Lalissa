using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.GUI.Main
{


    public partial class frmDekurseListe : Form
    {


        public frmDekurseListe()
        {
            InitializeComponent();
        }

        private void frmDekurseListe_Load(object sender, EventArgs e)
        {

        }

        public void initControl(PMDS.GUI.GUI.Main.ucDekurseListe.eTypeUI TypeUI, Nullable<Guid> IDPatientAlias)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.ucDekurseListe1.initControl(TypeUI, IDPatientAlias);

            }
            catch (Exception ex)
            {
                throw new Exception("frmDekurseListe.initControl: " + ex.ToString());
            }
        }

        private void frmDekurseListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                e.Cancel = true;
                this.Visible = false;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
