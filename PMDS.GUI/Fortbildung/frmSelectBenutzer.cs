using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;




namespace PMDS.GUI.Fortbildung
{


    public partial class frmSelectBenutzer : Form
    {

        public bool abort = true;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public Nullable<Guid> IDSelUser = null;






        public frmSelectBenutzer()
        {
            InitializeComponent();
        }

        private void frmSelectBenutzer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }


        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenliste.ico_Klientenakt, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer.initControl: " + ex.ToString());
            }
        }
        public void loadUsers()
        {
            try
            {
                this.cboUsers.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db, ref lstBenutzerAll);
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {
                        this.cboUsers.Items.Add(rBenutzer.ID, rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer.loadUsers: " + ex.ToString());
            }
        }

        public bool selectData()
        {
            try
            {
                if (this.cboUsers.Value == null)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                try
                {
                    Guid IDUserSelected = new Guid(this.cboUsers.Value.ToString().Trim());
                }
                catch
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                this.IDSelUser = (Guid)this.cboUsers.Value;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer.selectData: " + ex.ToString());
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.selectData())
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
        private void btnAbort_Click(object sender, EventArgs e)
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

    }
}
