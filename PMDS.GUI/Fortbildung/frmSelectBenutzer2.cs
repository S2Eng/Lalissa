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


    public partial class frmSelectBenutzer2 : Form
    {

        public bool abort = true;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public System.Collections.Generic.List<Guid> lstUsersSelected = new List<Guid>();







        public frmSelectBenutzer2()
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
                throw new Exception("frmSelectBenutzer2.initControl: " + ex.ToString());
            }
        }
        public void loadUsers()
        {
            try
            {
                this.treeUIsers.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db, ref lstBenutzerAll);
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {
                        UltraListViewItem itm = this.treeUIsers.Items.Add(rBenutzer.ID.ToString(), rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "");
                        itm.CheckState = CheckState.Unchecked;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer2.loadUsers: " + ex.ToString());
            }
        }

        public bool selectData()
        {
            try
            {
                int iSelectedUsers = 0;
                foreach (UltraListViewItem itm in this.treeUIsers.Items)
                {
                    if (itm.CheckState == CheckState.Checked)
                        iSelectedUsers += 1;
                }

                if (iSelectedUsers == 0)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                try
                {
                    this.lstUsersSelected.Clear();
                    foreach (UltraListViewItem itm in this.treeUIsers.Items)
                    {
                        if (itm.CheckState == CheckState.Checked)
                            this.lstUsersSelected.Add( new Guid(itm.Key));
                    }

                }
                catch
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer2.selectData: " + ex.ToString());
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
