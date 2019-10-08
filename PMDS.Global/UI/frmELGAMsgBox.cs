using PMDS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.ELGA
{

    public partial class frmELGAMsgBox : Form
    {
        public bool abort = true;

        public PMDSBusiness b = new PMDSBusiness();
        public qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

        public Guid ID = System.Guid.NewGuid();






        public frmELGAMsgBox()
        {
            InitializeComponent();
        }

        private void FrmELGAMsgBox_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string MsgBox)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

                this.txtMessage.Text = MsgBox;

            }
            catch (Exception ex)
            {
                throw new Exception("frmELGAMsgBox.frmELGAMsgBox: " + ex.ToString());
            }
        }

        public bool checkOK()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmELGAMsgBox.checkOK: " + ex.ToString());
            }
        }


        private void BtnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

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
        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.checkOK())
                {
                    this.abort = false;
                    this.Close();
                }

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
