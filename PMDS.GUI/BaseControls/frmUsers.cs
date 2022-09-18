using PMDS.DB;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{
    
    public partial class frmUsers : QS2.Desktop.ControlManagment.baseForm 
    {

        public bool abort = true;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();





        public frmUsers()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }
        

        private void frmUsers_Load(object sender, EventArgs e)
        {

        }
        
        public void initControl()
        {
            try
            {
                this.AcceptButton = this.btnOK2;
                this.CancelButton = this.btnAbort2;

                this.btnOK2.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.loadUsers();

            }
            catch (Exception ex)
            {
                throw new Exception("frmUsers.initControl: " + ex.ToString());
            }
        }
        public void loadUsers()
        {
            try
            {
                this.cbBenutzer.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db, ref lstBenutzerAll);
                    foreach (PMDS.db.Entities.Benutzer rBenutzer in tBenutzer)
                    {
                        this.cbBenutzer.Items.Add(rBenutzer.ID, rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmUsers.loadUsers: " + ex.ToString());
            }
        }

        

        private void btnOK2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this.cbBenutzer.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Benutzer ausgewählt.", "", MessageBoxButtons.OK);
                    return;
                }
                if (this.cbBenutzer.Value.GetType() != typeof(Guid))
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Benutzer ausgewählt.", "", MessageBoxButtons.OK);
                    return;
                }

                bool bInfo = false;
                bool bError = false;
                PMDS.BusinessLogic.Benutzer User = new PMDS.BusinessLogic.Benutzer((Guid)this.cbBenutzer.Value);
                GuiUtil.ValidateField(this.txtPassword, User.HasPasswort(this.txtPassword.Text),
                                        ENV.String("GUI.E_INVALID_PASSWORD"), ref bError, bInfo, errorProvider1);
                if (bError)
                {
                    this.errorProvider1.SetError(this.txtPassword, "Error");
                    //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer-Passwort ist falsch!", "", MessageBoxButtons.OK);
                    return;
                }

                this.abort = false;
                this.Close();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnAbort2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            qs2.core.generic.TogglePassword(sender);
        }
    }
}
