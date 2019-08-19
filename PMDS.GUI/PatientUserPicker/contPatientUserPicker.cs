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


    public partial class contPatientUserPicker : UserControl
    {

        public bool IsInitialized = false;
        public contSelectPatientenBenutzer contSelectPatienten = null;

        public ucHeader MainWindowHeader2 = null;
        public BaseControls.ucParameterKlient MainWindowParameter = null;

        public eTypeUIPicker _eTypeUIPicker;
        public enum eTypeUIPicker
        {
            PatientSingle = 0

        }

        public PMDSBusiness b = new PMDSBusiness();








        public contPatientUserPicker()
        {
            InitializeComponent();
        }

        private void contPatientUserPicker_Load(object sender, EventArgs e)
        {

        }
         
        public void initControl(eTypeUIPicker TypeUIPicker, bool SendEventPatientUsersWhenSelectChanged, eTypePatientenUserPickerChanged _TypePatientenUserPickerChanged)
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._eTypeUIPicker = TypeUIPicker;

                    this.contSelectPatienten = new VB.contSelectPatientenBenutzer();
                    bool isTxtTemplate = false;
                    this.contSelectPatienten._SingleSelect = true;
                    this.contSelectPatienten.treeBenutzerPatients.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.None;
                    this.contSelectPatienten.setSelectededTxt_Name = true;
                    this.contSelectPatienten.SendEventPatientUsersWhenSelectChanged = SendEventPatientUsersWhenSelectChanged;
                    //this.contSelectPatienten.LabelPickerAlternate = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient");
                    this.contSelectPatienten.initControl(VB.contSelectPatientenBenutzer.eTypeUI.Patients, true, isTxtTemplate, this.dropDownPatienten);
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatienten;
                    this.contSelectPatienten.popupContMainSearch = this.uPopUpContPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;
                    this.contSelectPatienten.treeBenutzerPatientsSelected.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
                    this.contSelectPatienten.treeBenutzerPatientsSelected.ViewSettingsDetails.ColumnAutoSizeMode = Infragistics.Win.UltraWinListView.ColumnAutoSizeMode.AllItemsAndHeader;
                    this.contSelectPatienten.bShowAlleWhen0Selected = false;
                    this.contSelectPatienten.loadDataAbtBereiche();
                    this.contSelectPatienten.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                    //this.contSelectPatienten.MainPlanungGesamt = this;
                    this.uPopUpContPatienten.PopupControl = this.contSelectPatienten;
                    this.dropDownPatienten.PopupItem = this.uPopUpContPatienten;

                    if (SendEventPatientUsersWhenSelectChanged)
                    {
                        this.contSelectPatienten._TypePatientenUserPickerChanged = _TypePatientenUserPickerChanged;
                        ENV.delPatientenUersPickerValueChanged += new dPatientenUersPickerValueChanged(this.PatientenUersPickerValueChanged);
                    }

                    bool IDFoundInTree2 = false;
                    this.contSelectPatienten.utreeAbtBereiche.Enabled = true;
                    contPlanungData.eTypeUI TypeUI = contPlanungData.eTypeUI.IDKlient;
                    this.contSelectPatienten.autoSelectAllForAbtBereich(PMDS.Global.ENV.CurrentIDAbteilung, PMDS.Global.ENV.IDBereich, false, null, true, TypeUI, ref IDFoundInTree2);

                    this.dropDownPatienten.Text = this.contSelectPatienten.setLabelCount2();


                    this.resetPicker(false);

                    //contPlanungData.cPlanArchive SelPlanArchive = new contPlanungData.cPlanArchive();
                    //Nullable<Guid> IDKlinik = null;
                    //Nullable<Guid> IDAbteilung = null;
                    //Nullable<Guid> IDBereich = null;
                    //UltraTreeNode treeNode = null;
                    //this.contSelectPatienten.getSelectedAbtBereich(ref IDKlinik, ref IDAbteilung, ref IDBereich, ref treeNode, true);


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientUserPicker.initControl: " + ex.ToString());
            }
        }

        public void resetPicker(bool LoadAbtBereich, bool clearTxtDropDown = false)
        {
            try
            {
                if (LoadAbtBereich)
                {
                    this.contSelectPatienten.loadDataAbtBereiche();
                }

                bool IDFoundInTree2 = false;
                Nullable<Guid> GuidNull = null;
                this.contSelectPatienten.loadBenutzerPatients(ref GuidNull, ref GuidNull, ref GuidNull, false, true, ref IDFoundInTree2, true);

                if (clearTxtDropDown)
                {
                    this.dropDownPatienten.Text = "";
                }
             
            }
            catch (Exception ex)
            {
                throw new Exception("contPatientUserPicker.resetPicker: " + ex.ToString());
            }
        }

        public void selectUserPatient(Nullable<Guid> IDUserPatient)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._eTypeUIPicker == eTypeUIPicker.PatientSingle)
                    {
                        //this.contSelectPatienten.SelectAllNoneBenutzerPatients(CheckState.Unchecked);

                        bool IDFoundInTree = false;
                        contPlanungData.eTypeUI TypeUI = contPlanungData.eTypeUI.IDKlient;
                        this.contSelectPatienten.autoSelectAllForAbtBereich(PMDS.Global.ENV.CurrentIDAbteilung, PMDS.Global.ENV.IDBereich, false, IDUserPatient, true, TypeUI, ref IDFoundInTree);
                        if (!IDFoundInTree)
                        {
                            IDFoundInTree = false;
                            this.contSelectPatienten.autoSelectAllForAbtBereich(System.Guid.Empty, System.Guid.Empty, false, IDUserPatient, true, TypeUI, ref IDFoundInTree);
                            //throw new Exception("selectUserPatient: IDFoundInTree=false for IDPatient '" + IDUserPatient.ToString() + "' not allowed!");
                            if (!IDFoundInTree)
                            {
                                if (IDUserPatient != null && !IDUserPatient.Equals(System.Guid.Empty))
                                {
                                    this.dropDownPatienten.Text = this.b.getPatientsName(IDUserPatient.Value, db);
                                    //throw new Exception("selectUserPatient: IDFoundInTree=false for IDPatient '" + IDUserPatient.ToString() + "' not allowed!");
                                }
                            }
                            else
                            {
                                this.dropDownPatienten.Text = this.b.getPatientsName(IDUserPatient.Value, db);
                            }

                        }
                        else
                        {
                            this.dropDownPatienten.Text = this.b.getPatientsName(IDUserPatient.Value, db);
                        }
                       
                    }
                    else
                    {
                        throw new Exception("PatientenUersPickerValueChanged: this._eTypeUIPicker '" + this._eTypeUIPicker.ToString() + "' not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientUserPicker.selectUserPatient: " + ex.ToString());
            }
        }





        public void PatientenUersPickerValueChanged(Nullable<Guid> IDKlinik, Nullable<Guid> IDAbteilung, Nullable<Guid> IDBereich, System.Collections.Generic.List<Guid> lstSelectedUsersPatients, UltraTreeNode treeNodeKlinik,
                                                    eTypePatientenUserPickerChanged TypePatientenUserPickerChanged)
        {
            try
            {
                if (TypePatientenUserPickerChanged == this.contSelectPatienten._TypePatientenUserPickerChanged)
                {
                    if (this._eTypeUIPicker == eTypeUIPicker.PatientSingle && lstSelectedUsersPatients.Count > 1)
                    {
                        throw new Exception("PatientenUersPickerValueChanged: lstSelectedUsersPatients.Count>1 not allowed for this._eTypeUIPicker == eTypeUIPicker.PatientSingle!");
                    }

                    if (this.MainWindowHeader2 != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            if (this._eTypeUIPicker == eTypeUIPicker.PatientSingle)
                            {
                                if (lstSelectedUsersPatients.Count == 1)
                                {
                                    Guid IDPatientSel = lstSelectedUsersPatients[0];
                                    this.dropDownPatienten.Text = this.b.getPatientsName(IDPatientSel, db);

                                    object obj = null;
                                    this.MainWindowHeader2.PickerValueChanged(IDPatientSel);
                                }
                                else
                                {
                                    bool noPatientSelected = true;
                                }
                            }
                            else
                            {
                                throw new Exception("PatientenUersPickerValueChanged: this._eTypeUIPicker '" + this._eTypeUIPicker.ToString() + "' not allowed!");
                            }
                        }

                    }
                    else if (this.MainWindowParameter != null)
                    {
                        this.MainWindowParameter.SignalValueChanged2();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contPatientUserPicker.PatientenUersPickerValueChanged: " + ex.ToString());
            }
        }

    }

}
