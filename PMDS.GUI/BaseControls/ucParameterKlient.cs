using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;


namespace PMDS.GUI.BaseControls
{


    public partial class ucParameterKlient : ucParameterBase, IBerichtParameterGUI
    {

        private PMDS.Print.CR.BerichtParameter _parameter;
        public bool PickerIsInitialized = false;
        



        public ucParameterKlient()
        {
            InitializeComponent();
        }


        public object VALUE
        {
            get 
            {
                System.Collections.Generic.List<Guid> lstSelectedUsersPatients = this.contPatientUserPicker1.contSelectPatienten.getList();
                if (lstSelectedUsersPatients.Count == 1)
                {
                    Guid IDPatientSelectedBack = lstSelectedUsersPatients[0];
                    return "{" + IDPatientSelectedBack.ToString() + "}";
                }
                else if (lstSelectedUsersPatients.Count != 1)
                {
                    throw new Exception("ucParameterKlient.VALUE: lstSelectedUsersPatients.Count!=1 not allowed!");
                }

                return "";
            }
        }

        public string VALUE_TEXT
        {
            get
            {
                System.Collections.Generic.List<Guid> lstSelectedUsersPatients = this.contPatientUserPicker1.contSelectPatienten.getList();
                if (lstSelectedUsersPatients.Count == 1)
                {
                    Guid IDPatientSelectedBack = lstSelectedUsersPatients[0];
                    Patient p = new Patient(IDPatientSelectedBack);
                    return p.FullInfo;
                }
                else if (lstSelectedUsersPatients.Count != 1)
                {
                    throw new Exception("ucParameterKlient.VALUE_TEXT: lstSelectedUsersPatients.Count!=1 not allowed!");
                }

                return "";
            }
        }

        public PMDS.Print.CR.BerichtParameter BERICHTPARAMETER
        {
            get
            {
                return _parameter;        
            }
            set
            {
                _parameter = value;
                if (value != null)
                    RefreshControl();
            }
        }

        private void RefreshControl()
        {
            if (!this.PickerIsInitialized)
            {
                this.contPatientUserPicker1.MainWindowParameter = this;
                this.contPatientUserPicker1.initControl(PatientUserPicker.contPatientUserPicker.eTypeUIPicker.PatientSingle, true, eTypePatientenUserPickerChanged.ReportSelection);

                this.PickerIsInitialized = true;
            }

            if (ENV.CurrentIDPatient == System.Guid.Empty)
            {
                this.contPatientUserPicker1.selectUserPatient(null);
            }
            else
            {
                this.contPatientUserPicker1.selectUserPatient(ENV.CurrentIDPatient);
            }

            lblText.Text = _parameter.Description;
        }

        public void SignalValueChanged2()
        {
            SignalValueChanged();
        }

    }
}
