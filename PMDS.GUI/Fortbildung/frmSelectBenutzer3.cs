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


    public partial class frmSelectBenutzer3 : Form
    {
        public bool abort = true;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public System.Collections.Generic.List<Guid> lstUsersSelected = new List<Guid>();


        



        public frmSelectBenutzer3()
        {
            InitializeComponent();
        }

        private void frmSelectBenutzer3_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
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
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

                this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Users, false, false, null);
                this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                Nullable<Guid> nGuid = null;
                bool IDFoundInTree2 = false;
                this.contSelectPatientenBenutzer1.loadBenutzerPatients(ref nGuid, ref nGuid, ref nGuid, false, true, ref IDFoundInTree2);
                this.contSelectPatientenBenutzer1.PanelBottom.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectBenutzer3.initControl: " + ex.ToString());
            }
        }

        public bool selectData()
        {
            try
            {
                System.Collections.Generic.List<Guid> lstPatientsSelected = this.contSelectPatientenBenutzer1.getList();
                if (lstPatientsSelected.Count == 0)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                    return false;
                }
                try
                {
                    this.lstUsersSelected.Clear();
                    foreach (Guid IDPatient in lstPatientsSelected)
                    {
                        this.lstUsersSelected.Add(IDPatient);
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
                throw new Exception("frmSelectBenutzer3.selectData: " + ex.ToString());
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
        private void btnSave_Click(object sender, EventArgs e)
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

    }

}
