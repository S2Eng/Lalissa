using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Linq;

using PMDS.GUI.VB;
using PMDS.Global;
using PMDS.DB;
using PMDS.Global.db.ERSystem;
using Infragistics.Win.UltraWinTree;


namespace PMDS.GUI.PatientUserPicker
{

    public partial class contAbtBereiche : UserControl
    {

        public bool IsInitialized = false;
        public bool _lockSelectedKlinik = false;

        public ucMain MainWindowPMDS= null;


        public eTypeUIPicker _eTypeUIPicker;
        public enum eTypeUIPicker
        {
            AbteilungBereiche = 0

        }

        public PMDSBusiness b = new PMDSBusiness();






        public contAbtBereiche()
        {
            InitializeComponent();
        }

        private void contAbtBereiche_Load(object sender, EventArgs e)
        {

        }
        
        public void initControl(eTypeUIPicker TypeUIPicker)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._eTypeUIPicker = TypeUIPicker;

                    this.contSelectPatientenBenutzer1 = new VB.contSelectPatientenBenutzer();
                    bool isTxtTemplate = false;
                    this.contSelectPatientenBenutzer1._SingleSelect = false;
                    this.contSelectPatientenBenutzer1.setSelectededTxt_Name = false;
                    this.contSelectPatientenBenutzer1.SendEventAbtBereicheWhenSelectChanged = true;
                    //this.contSelectPatienten.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient");
                    this.contSelectPatientenBenutzer1.initControl(VB.contSelectPatientenBenutzer.eTypeUI.AbtBereich, true, isTxtTemplate, null);
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
                    this.contSelectPatientenBenutzer1.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                    this.contSelectPatientenBenutzer1.bShowAlleWhen0Selected = false;
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                    //this.contSelectPatientenBenutzer1.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                    //this.contSelectPatienten.MainPlanungGesamt = this;

                    //bool IDFoundInTree2 = false;
                    //this.contSelectPatientenBenutzer1.utreeAbtBereiche.Enabled = true;
                    //contPlanungData.eTypeUI TypeUI = contPlanungData.eTypeUI.IDKlient;
                    //this.contSelectPatientenBenutzer1.autoSelectAllForAbtBereich(PMDS.Global.ENV.CurrentIDAbteilung, PMDS.Global.ENV.IDBereich, false, null, true, TypeUI, ref IDFoundInTree2);

                    //ENV.delPatientenUersPickerValueChanged += new dPatientenUersPickerValueChanged(this.PatientenUersPickerValueChanged);
                    ENV.deldAbtBereichPickerValueChanged += new dAbtBereichPickerValueChanged(this.BereichPickerValueChanged);

                    //this.resetPicker(false);

                    //this.b.loadComboAllKliniken(this.cbKlinik, )

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contAbtBereiche.initControl: " + ex.ToString());
            }
        }

        public void resetPicker(bool LoadAbtBereich)
        {
            try
            {
                if (LoadAbtBereich)
                {
                    this.contSelectPatientenBenutzer1.loadDataAbtBereiche();
                }

                bool IDFoundInTree2 = false;
                Nullable<Guid> GuidNull = null;
                this.contSelectPatientenBenutzer1.loadBenutzerPatients(ref GuidNull, ref GuidNull, ref GuidNull, false, true, ref IDFoundInTree2, true);

            }
            catch (Exception ex)
            {
                throw new Exception("contAbtBereiche.resetPicker: " + ex.ToString());
            }
        }


        public void BereichPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, UltraTreeNode treeNodeKlinik)
        {
            try
            {
                //if (this._eTypeUIPicker == eTypeUIPicker.AbteilungBereiche && lstSelectedUsersPatients.Count > 1)
                //{
                //    throw new Exception("dbtBereichPickerValueChanged: lstSelectedUsersPatients.Count>1 not allowed for this._eTypeUIPicker == eTypeUIPicker.PatientSingle!");
                //}

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._eTypeUIPicker == eTypeUIPicker.AbteilungBereiche)
                    {
                        //this.dropDownPatienten.Text = this.b.getPatientsName(IDPatientSel, db);
                    }
                    else
                    {
                        throw new Exception("contAbtBereiche.dbtBereichPickerValueChanged: this._eTypeUIPicker '" + this._eTypeUIPicker.ToString() + "' not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contAbtBereiche.dbtBereichPickerValueChanged: " + ex.ToString());
            }
        }

        public Global.db.Patient.dsKlinik.KlinikRow getSelKlinik(bool withMsgBox)
        {
            try
            {
                //<20120202>
                if (this.cbKlinik.SelectedItem != null)
                {
                    Infragistics.Win.ValueListItem item = this.cbKlinik.SelectedItem;
                    return (Global.db.Patient.dsKlinik.KlinikRow)item.Tag;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return null;
            }
        }


        private void cbKlinik_ValueChanged(object sender, EventArgs e)
        {
            if (cbKlinik.Focused)
            {
                if (!this._lockSelectedKlinik)
                {
                    Global.db.Patient.dsKlinik.KlinikRow rKlinik = this.getSelKlinik(false);
                    if (rKlinik != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            //this.RefreshGUI(this._allKliniken, this._onlyKlinikenUsr, false, this._adminModusAlleKliniken);
                            PMDS.DB.PMDSBusinessComm.newCommAsyncToClients(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll, db);
                        }
                    }
                }
                else
                {
                    string xy = "";
                }
            }
        }

    }

}
