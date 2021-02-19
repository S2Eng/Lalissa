using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.GUI.Klient;
using PMDS.Klient;

namespace PMDS.GUI
{
    public partial class frmRehabilitation : QS2.Desktop.ControlManagment.baseForm 
    {
        protected bool _canClose = false;
        private bool _bearbeiten;
        private bool _massnahme;
        dsRehabilitation.RehabilitationRow _row;

        public frmRehabilitation(bool massnahmeJN, bool bearbeiten)
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }


            Closing += new CancelEventHandler(frm_Closing);
            _massnahme = massnahmeJN;
            _bearbeiten = bearbeiten;
            Init();
            RequiredFields();
        }

        private void Init()
        {
            if (!_massnahme)
            {
                if(_bearbeiten)
                    lblHeader.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ressource bearbeiten");
                else
                    lblHeader.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ressource hinzufügen");

                lblVon.Visible = false;
                dtpVon.Visible = false;

                lblBis.Location = lblVon.Location;
                dtpBis.Location = dtpVon.Location;

                pnlZiel.Visible = false;
                pnlInstitution.Visible = false;
                pnlEndeGrung.Visible = false;

                Height -= pnlZiel.Height + pnlInstitution.Height + pnlEndeGrung.Height;
            }
            else
            {
                if(_bearbeiten)
                    lblHeader.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme bearbeiten");
                else
                    lblHeader.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme hinzufügen");
            }
            
        }

        private void InitGUI()
        {
            if (_row != null)
            {
                if (!_row.IsVonNull())
                    dtpVon.Value = _row.Von;

                if (!_row.IsBisNull())
                    dtpBis.Value = _row.Bis;

                if (!_row.IsBeschreibungNull())
                    tbBeschreibung.Text = _row.Beschreibung.Trim();

                if (!_row.IsZielNull())
                    tbZiel.Text = _row.Ziel.Trim();

                if (!_row.IsInstitutionNull())
                    tbInstitution.Text = _row.Institution.Trim();

                if (!_row.IsEndeGrundNull())
                    tbEndeGrund.Text = _row.EndeGrund.Trim();

                if (!_row.IsBemerkungNull())
                    tbBemerkung.Text = _row.Bemerkung.Trim();

            }
        }

        public void UpdateData()
        {
            if (_row != null)
            {
                if (dtpVon.Value != null)
                    _row.Von = (DateTime)dtpVon.Value;
                else
                    _row.SetVonNull();

                if (dtpBis.Value != null)
                    _row.Bis = (DateTime)dtpBis.Value;
                else
                    _row.SetBisNull();

                if (tbBeschreibung.Text.Trim() != "")
                    _row.Beschreibung = tbBeschreibung.Text.Trim();
                else
                    _row.SetBeschreibungNull();

                if (tbZiel.Text.Trim() != "")
                    _row.Ziel = tbZiel.Text.Trim();
                else
                    _row.SetZielNull();

                if (tbInstitution.Text.Trim() != "")
                    _row.Institution = tbInstitution.Text.Trim();
                else
                    _row.SetInstitutionNull();

                if (tbEndeGrund.Text.Trim() != "")
                    _row.EndeGrund = tbEndeGrund.Text.Trim();
                else
                    _row.SetEndeGrundNull();

                if (tbBemerkung.Text.Trim() != "")
                    _row.Bemerkung = tbBemerkung.Text.Trim();
                else
                    _row.SetBemerkungNull();
            }
        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            if (dtpBis.Value != null && dtpVon.Value != null)
            {
                GuiUtil.ValidateField(dtpBis, (dtpVon.Text.Length == 0 || (DateTime)dtpBis.Value >= (DateTime)dtpVon.Value),
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis darf nicht kleiner als Von."), ref bError, bInfo, errorProvider1);
            }
            
            return !bError;
        }

        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            //GuiUtil.ValidateRequired(dtpVon);
        }

        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsRehabilitation.RehabilitationRow REHABILITATION_ROW
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
                InitGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Von
        {
            get{return dtpVon.Value;}
            set{dtpVon.Value = value;}
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Bis
        {
            get { return dtpBis.Value; }
            set { dtpBis.Value = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Beschreibung
        {
            get { return tbBeschreibung.Text.Trim(); }
            set { tbBeschreibung.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Ziel
        {
            get { return tbZiel.Text.Trim(); }
            set { tbZiel.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Institution
        {
            get { return tbInstitution.Text.Trim(); }
            set { tbInstitution.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EndeGrund
        {
            get { return tbEndeGrund.Text.Trim(); }
            set { tbEndeGrund.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Bemerkung
        {
            get { return tbBemerkung.Text.Trim(); }
            set { tbBemerkung.Text = value; }
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
    }
}