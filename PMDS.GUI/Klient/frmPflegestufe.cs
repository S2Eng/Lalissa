using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Klient;
using PMDS.Calc.UI.Admin;
using PMDS.GUI.Klient;


namespace PMDS.GUI
{


    public partial class frmPflegestufe : QS2.Desktop.ControlManagment.baseForm 
    {
        protected bool _canClose = false;
        private dsKlientPflegestufe.PatientPflegestufeRow _row;
        private bool _NeuePflegestufe = false;




        public frmPflegestufe()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Closing += new CancelEventHandler(frm_Closing);
            Init();
            RequiredFields();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsKlientPflegestufe.PatientPflegestufeRow PFLEGESTUFE_ROW
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
                UpdateGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NEUE_PFLEGESTUFE
        {
            get { return _NeuePflegestufe; }
        }

        private void InitComboPflgestufen(KlientPflegegeldstufe pf)
        {
            object pflegestufe, beantrPflegestufe;

            pflegestufe = (cmbPflgestufe.Text.Trim() != "") ? PFLEGESTUFE : null;
            beantrPflegestufe = (cmbBeantragtestufe.Text.Trim() != "") ? BEANTRAGTEPFLEGESTUFE : null;
            
            cmbPflgestufe.Items.Clear();
            cmbBeantragtestufe.Items.Clear();

            bool pflegestufeGefunden = false, beantrPflegestufeGefunden = false;

            foreach (DataRow r in pf.ALL.Pflegegeldstufe.Rows)
            {
                cmbPflgestufe.Items.Add(r["ID"], (string)r["Bezeichnung"]);
                cmbBeantragtestufe.Items.Add(r["ID"], (string)r["Bezeichnung"]);

                if (pflegestufe!= null && pflegestufe.Equals(r["ID"])) pflegestufeGefunden = true;
                if (beantrPflegestufe != null && beantrPflegestufe.Equals(r["ID"])) beantrPflegestufeGefunden = true;
            }


            PFLEGESTUFE = pflegestufeGefunden ? pflegestufe : null;
            BEANTRAGTEPFLEGESTUFE = beantrPflegestufeGefunden ? beantrPflegestufe : null;
        }

        private void Init()
        {
            KlientPflegegeldstufe pf = new KlientPflegegeldstufe();
            InitComboPflgestufen(pf);

            if (pf.ALL.Pflegegeldstufe.Rows.Count > 0)
            {
                cmbPflgestufe.Value = pf.ALL.Pflegegeldstufe.Rows[0]["ID"];
            }

            cmbBeantragtestufe.Value = null;
            dtpGueltigAb.Value = DateTime.Now;
            this.dtpGueltigBis.Value = null;
            dtpAntragsdatum.Value = null;
            dtpBescheiddatum.Value = null;
        }

        public void UpdateGUI()
        {
            if (_row != null)
            {
                PFLEGESTUFE = _row.IDPflegegeldstufe;
                GUELTIG_AB = _row.GueltigAb;
                if (_row.IsGueltigBisNull())
                {
                    GUELTIG_BIS = null;
                }
                else
                {
                    GUELTIG_BIS = _row.GueltigBis;
                }
                
                if (!_row.IsAenderungsantragDatumNull())
                    ANTRAGSDATUM = _row.AenderungsantragDatum;

                if(!_row.IsIDPflegegeldstufeAntragNull())
                    BEANTRAGTEPFLEGESTUFE = _row.IDPflegegeldstufeAntrag;

                if(!_row.IsGenehmigungDatumNull())
                    BESCHEIDDATUM = _row.GenehmigungDatum;
            }
        }

        public void UpdateData()
        {
            if (_row != null)
            {
                _row.IDPflegegeldstufe = new Guid(PFLEGESTUFE.ToString());
                _row.GueltigAb = GUELTIG_AB;
                if (GUELTIG_BIS == null)
                {
                    _row.SetGueltigBisNull();
                }
                else
                {
                    _row.GueltigBis = GUELTIG_BIS.Value;
                }

                if (ANTRAGSDATUM != DateTime.MinValue)
                    _row.AenderungsantragDatum = ANTRAGSDATUM;
                else
                    _row.SetAenderungsantragDatumNull();

                if (BEANTRAGTEPFLEGESTUFE != null)
                    _row.IDPflegegeldstufeAntrag = new Guid(BEANTRAGTEPFLEGESTUFE.ToString());
                else
                    _row.SetIDPflegegeldstufeAntragNull();

                if (BESCHEIDDATUM != DateTime.MinValue)
                    _row.GenehmigungDatum = BESCHEIDDATUM;
                else
                    _row.SetGenehmigungDatumNull();
            }
        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            GuiUtil.ValidateField(cmbPflgestufe, cmbPflgestufe.Value != null,
            ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            GuiUtil.ValidateField(dtpGueltigAb, dtpGueltigAb.Text.Length > 0,
            ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(cmbPflgestufe);
            GuiUtil.ValidateRequired(dtpGueltigAb);
        }

        
        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object PFLEGESTUFE
        {
            get
            {
                return cmbPflgestufe.Value;
            }

            set
            {
                cmbPflgestufe.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime GUELTIG_AB
        {
            get
            {
                if (dtpGueltigAb.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpGueltigAb.DateTime;
            }

            set
            {
                dtpGueltigAb.Value = value;
            }
        }
        public Nullable<DateTime> GUELTIG_BIS
        {
            get
            {
                if (this.dtpGueltigBis.Value == null)
                    return null;
                else
                    return this.dtpGueltigBis.DateTime.Date;
            }

            set
            {
                this.dtpGueltigBis.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ANTRAGSDATUM
        {
            get
            {
                if (dtpAntragsdatum.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpAntragsdatum.DateTime;
            }

            set
            {
                dtpAntragsdatum.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object BEANTRAGTEPFLEGESTUFE
        {
            get
            {
                return cmbBeantragtestufe.Value;
            }

            set
            {
                cmbBeantragtestufe.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime BESCHEIDDATUM
        {
            get
            {
                if (dtpBescheiddatum.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpBescheiddatum.DateTime;
            }

            set
            {
                dtpBescheiddatum.Value = value;
            }
        }
        #endregion


        //----------------------------------------------------------------------------
        /// <summary>
        /// Dialog schließen überwachen
        /// </summary>
        //----------------------------------------------------------------------------
        private void frm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_canClose;
        }


        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFields())
                    return;

                _canClose = true;
            }
            finally
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _canClose = true;
        }

        private void cmbPflgestufe_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            frmPflegegeldstufe frm = new frmPflegegeldstufe();

            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                KlientPflegegeldstufe pf = new KlientPflegegeldstufe();
                InitComboPflgestufen(pf);

                if (frm.PFLEGEGELDSTUFE_ROW != null)
                {
                    _NeuePflegestufe = true;
                  
                    if(sender == cmbPflgestufe)
                        PFLEGESTUFE = frm.PFLEGEGELDSTUFE_ROW.ID;
                    else
                        BEANTRAGTEPFLEGESTUFE = frm.PFLEGEGELDSTUFE_ROW.ID;
                }
            }
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _canClose = true;
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void frmPflegestufe_Load(object sender, EventArgs e)
        {

        }
    }
}