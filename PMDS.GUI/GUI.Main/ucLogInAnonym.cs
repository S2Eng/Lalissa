using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.GUI.Main
{


    public partial class ucLogInAnonym : UserControl
    {
        public Nullable<Guid> IDAnmeldungenReturn = null;
        public PMDS.db.Entities.Benutzer rUsr = null;
        public PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

        public bool abort = true;
        public frmLogInAnonym mainWindow = null;


        


        public ucLogInAnonym()
        {
            InitializeComponent();
        }

        private void ucLogInAnonym_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                this.mainWindow.AcceptButton = this.btnOK;
                this.mainWindow.CancelButton = this.btnAbort;

                this.rUsr = this.PMDSBusiness1.LogggedOnUser();

            }
            catch (Exception ex)
            {
                throw new Exception("ucLogInAnonym.initControl: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                if (this.txtName.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Name: Eingabe erforderich!", "PMDS", MessageBoxButtons.OK);
                    this.txtName.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucLogInAnonym.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (this.validateData())
                {
                    if (this.PMDSBusiness1.saveAnonymUser(ref this.IDAnmeldungenReturn, this.txtName.Text.Trim(), ref this.rUsr))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("ucLogInAnonym.saveData: " + ex.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.mainWindow.Close();
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
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.Close();
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
