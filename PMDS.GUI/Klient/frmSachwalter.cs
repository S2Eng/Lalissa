using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Klient;
using PMDS.BusinessLogic;

namespace PMDS.GUI
{
    public partial class frmSachwalter : QS2.Desktop.ControlManagment.baseForm 
    {
        protected bool _canClose = false;

        public frmSachwalter()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Closing += new CancelEventHandler(frm_Closing);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Kontaktperson setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        public Sachwalter Sachwalter
        {
            get
            {
                return ucSachwalter1.Sachwalter;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Sachwalter");

                ucSachwalter1.Sachwalter = value;
            }
        }

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
                if (!ucSachwalter1.ValidateFields())
                    return;

                ucSachwalter1.UpdateDATA();
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

        private void frmSachwalter_Load(object sender, EventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn)
            {
                this.btnOK.Visible = false;
            }
        }
    }
}