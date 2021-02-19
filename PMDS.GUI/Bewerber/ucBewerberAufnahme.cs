using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucBewerberAufnahme : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDPatient;
        private PatientBewerber _patBewerber;
        public event BewebungsdatenDetailsDelegate BewebungsdatenDetailsDelegate;

        public ucBewerberAufnahme()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                _patBewerber = new PatientBewerber();
                dgKlienten.DataSource = _patBewerber.ListKlienten;
            }
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set 
            { 
                _IDPatient = value;
                SelectCurrentPatient();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeueAufnahme
        {
            get { return !pnlKlienten.Visible; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle ausgewählte Zeile
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private dsPatientBereich.PatientRow CurrentRow
        {
            get { return (dsPatientBereich.PatientRow)UltraGridTools.CurrentSelectedRow(dgKlienten); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bewerbername
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Klientname
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public void RefreshControl()
        {
            if (_patBewerber == null)
                return;

            _patBewerber.KlientByFilter(Klientname);
            SelectCurrentPatient();
        }

        private void SelectCurrentPatient()
        {
            if (_IDPatient == Guid.Empty)
                return;

            foreach (UltraGridRow r in dgKlienten.Rows)
            {
                if ((Guid)r.Cells["ID"].Value == _IDPatient)
                {
                    r.Selected = true;
                    dgKlienten.ActiveRow = r;
                    break;
                }
            }
        }

        private void BewerbungsDaten()
        {
            if (CurrentRow == null || BewebungsdatenDetailsDelegate == null)
                return;
            
            BewebungsdatenDetailsDelegate(_IDPatient);
        }

        private void dgKlienten_AfterRowActivate(object sender, EventArgs e)
        {
            dgKlienten.ActiveRow.Selected = true;

            if (CurrentRow != null)
                _IDPatient = CurrentRow.ID;
        }

        private void ucBewerberAufnahme_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
            {
                opsBewerber.Value = 0;
                txtName.Text = "";
                RefreshControl();

                if (pnlKlienten.Visible)
                    dgKlienten.Select();
            }
        }

        private void opsBewerber_ValueChanged(object sender, EventArgs e)
        {
            pnlKlienten.Visible = (int)opsBewerber.Value == 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshControl();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshControl();
        }

        private void dgKlienten_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            BewerbungsDaten();
        }
    }
}
