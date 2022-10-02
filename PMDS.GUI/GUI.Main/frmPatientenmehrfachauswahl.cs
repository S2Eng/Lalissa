using PMDS.DB;
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
    
    public partial class frmPatientenmehrfachauswahl : Form
    {
        public PMDS.GUI.VB.contSelectPatientenBenutzer contSelectPatientenBenutzer1 = null;
        public bool abort = true;
        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected = new List<PMDS.Global.UIGlobal.eSelectedNodes>();



        


        public frmPatientenmehrfachauswahl()
        {
            InitializeComponent();
        }

        private void frmPatientenmehrfachauswahl_Load(object sender, EventArgs e)
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
                //this.CancelButton = this.ucPatientenmehrfachauswahl1.btnAbort;
                //this.AcceptButton = this.ucPatientenmehrfachauswahl1.btnOK;
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                //PMDSBusinessComm.checkMessageForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);

                this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                this.contSelectPatientenBenutzer1.Dock = DockStyle.Fill;
                this.panelUsers.Controls.Add(this.contSelectPatientenBenutzer1);
                        
                bool IsSearch = false;
                bool isTxtTemplate = false;
                
                this.contSelectPatientenBenutzer1._SingleSelect = false;
                this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients, IsSearch, isTxtTemplate, null);
                this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                bool IDFoundInTree = false;
                this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(System.Guid.Empty, System.Guid.Empty, false, null, true, VB.contPlanungData.eTypeUI.PlansAll, ref IDFoundInTree);
                this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);
                //this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(Settings.CurrentIDPatient);
                this.contSelectPatientenBenutzer1.setLabelCount2();
                this.contSelectPatientenBenutzer1.PanelBottom.Visible = false;

                //this.ucPatientenmehrfachauswahl1.mainWindow = this;
                //this.ucPatientenmehrfachauswahl1.initControl();
                
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes in this.lstPatienteSelected)
                {
                    bool IDFoundInTree2 = false;
                    this.contSelectPatientenBenutzer1.SelectListViewItemBenutzerPatient(SelectedNodes.IDKlient.Value, ref IDFoundInTree2);
                    if (!IDFoundInTree2)
                    {
                        this.contSelectPatientenBenutzer1.addObjectToSelected2(SelectedNodes.IDKlient.Value, true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPatientenmehrfachauswahl.initControl: " + ex.ToString());
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.lstPatienteSelected.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    List<Guid> lstPatients = this.contSelectPatientenBenutzer1.getList();
                    if (lstPatients.Count > 0)
                    {
                        foreach (Guid IDPatient in lstPatients)
                        {
                            PMDS.Global.UIGlobal.eSelectedNodes SelectedNodes = new PMDS.Global.UIGlobal.eSelectedNodes();
                            SelectedNodes.IDKlient = IDPatient;
                            PMDS.db.Entities.Aufenthalt rActAufenthalt = b.getAktuellerAufenthaltPatient(SelectedNodes.IDKlient.Value, false, db);
                            SelectedNodes.IDAufenthalt = rActAufenthalt.ID;

                            this.lstPatienteSelected.Add(SelectedNodes);
                        }
                    }
                }

                this.abort = false;
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
