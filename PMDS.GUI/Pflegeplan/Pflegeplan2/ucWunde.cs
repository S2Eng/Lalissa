//----------------------------------------------------------------------------
/// <summary>
/// Erstellt am:	25.9.2008
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;



namespace PMDS.GUI
{
    public partial class ucWunde : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, ISave
    {
        private Guid                _IDAufenthaltPDx;
        public event EventHandler   WundeChanged;
        private bool _DataChanged = false;
        private bool _InitInProgress = false;
        private bool _Evalfirsttimerefreshed = false;

        public ucWunde()
        {
            InitializeComponent();
            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            ENV.PflegePlanChanged += new PflegePlanChangedDelegate(ENV_PflegePlanChanged);

            ucWunddoku1.WundDokuChanged += new EventHandler(ucWunddoku1_WundDokuChanged);

            this.ucWunddoku1.setUIGrids();
        }

        void ucWunddoku1_WundDokuChanged(object sender, EventArgs e)
        {
            SignalValueChanged();
        }

        void ENV_PflegePlanChanged(Guid IDAufenthalt)
        {
            RefreshEvaluierung(IDAufenthalt);
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Die ID des Patienten wurde von außen geändert ==> aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            RefreshEvaluierung(Aufenthalt.LastByPatient(IDPatient));
        }

         private void RefreshEvaluierung(Guid IDAufenthalt)
        {
            ucZielEvaluierung1.RefreshContent(IDAufenthalt);
            this.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDxSelectionArgs setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthaltPDx
        {
            get { return _IDAufenthaltPDx; }
            set 
            {
                //if (value == _IDAufenthaltPDx)          // wieder der selbe == nix tun
                //    return;
                _InitInProgress = true;
                _IDAufenthaltPDx = value;
                ucWunddoku1.IDAufenthaltPDx = value;
                _InitInProgress = false;
            }
        }

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            if (_IDAufenthaltPDx == null)
            {
                ClearControl();
                return;
            }


            this.ucWunddoku1.setUIGrids();
        }

        private void ClearControl()
        {
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
                    this.ucWunddoku1.setUIGrids ();
        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            return ucWunddoku1.ValidateFields();
        }

        private void SignalValueChanged()
        {
            if (!_InitInProgress)
            {
                _DataChanged = true;
                if (WundeChanged != null)
                    WundeChanged(this, null);
            }
        }


        public bool Save()
        {
            _DataChanged = false;
            return ucWunddoku1.Save();
        }

        public void Undo()
        {
            _DataChanged = false;
            _InitInProgress = true;
            ucWunddoku1.Undo();
            _InitInProgress = false;
        }

        public bool IsChanged
        {
            get { return _DataChanged; }
        }
        public void setControlsAktivDisable(bool bOn)
        {
            this.ucWunddoku1.setControlsAktivDisable(bOn);
            this.ucZielEvaluierung1.setControlsAktivDisable(bOn);
        }

        private void tabMain_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !_Evalfirsttimerefreshed)
            {
                ucZielEvaluierung1.RefreshContent(Aufenthalt.LastByPatient(ENV.CurrentIDPatient));
                _Evalfirsttimerefreshed = true;
            }
        }


    }
}
