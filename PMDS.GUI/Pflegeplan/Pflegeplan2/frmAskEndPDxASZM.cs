using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class frmAskEndPDxASZM : QS2.Desktop.ControlManagment.baseForm 
    {
        private bool _bCanClose = true;

        public frmAskEndPDxASZM()
        {
            InitializeComponent();
            dtpEnd.DateTime = DateTime.Now.Date;
            RequiredFields();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Das Ende Datum
        /// </summary>
        //----------------------------------------------------------------------------
        public DateTime END_DATE
        {
            get { return dtpEnd.DateTime; }
            set { dtpEnd.DateTime = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// PDX Endegrund
        /// </summary>
        //----------------------------------------------------------------------------
        public string PDX_REASON
        {
            get{ return ucAskEndPDX1.REASON; }
            set{ ucAskEndPDX1.REASON = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Endegrund
        /// </summary>
        //----------------------------------------------------------------------------
        public string ASZM_REASON
        {
            get { return ucAskEndASZM1.REASON; }
            set { ucAskEndASZM1.REASON = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die ausgewählten ASZM
        /// </summary>
        //----------------------------------------------------------------------------
        public ASZMLokalisiert[] SELECTED_ASZM
        {
            get { return ucAskEndASZM1.SELECTED_ASZM; }
        }

        public void EndPDX(ASZMLokalisiert[] raszm)
        {
            ucAskEndPDX1.RASZM = raszm;
        }

        public void EndASZM(ASZMLokalisiert[] raszm, PDxLokalisiert[] rpdx)
        {
            ucAskEndASZM1.RASZM = raszm;
            ucAskEndASZM1.RPDX = rpdx;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(dtpEnd);
        }

        private bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            GuiUtil.ValidateField(dtpEnd, (dtpEnd.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            if (!bError && grpEndPDX.Visible)
            {
                bError = !ucAskEndPDX1.ValidateFields();
            }

            if (!bError && grpEndASZM.Visible)
                bError = !ucAskEndASZM1.ValidateFields();

            return !bError;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bCanClose = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _bCanClose = false;
            if (!ValidateFields())
                return;

            _bCanClose = true;
        }

        private void frmAskEndPDxASZM_Load(object sender, EventArgs e)
        {
            if (ucAskEndPDX1.RASZM == null)
                grpEndPDX.Visible = false;

            if (ucAskEndASZM1.RASZM == null || ucAskEndASZM1.RPDX == null)
                 grpEndASZM.Visible = false;

            if (grpEndPDX.Visible)
                ucAskEndASZM1.HiedeEndDate = true;

            if(ucAskEndPDX1.RASZM == null && ucAskEndASZM1.RASZM != null && ucAskEndASZM1.RPDX != null)
                Height = MinimumSize.Height;
            else if(ucAskEndPDX1.RASZM != null && (ucAskEndASZM1.RASZM == null || ucAskEndASZM1.RPDX == null))
                Height = MinimumSize.Height;

            MinimumSize = Size;
            MaximumSize = Size;
        }

        private void frmAskEndPDxASZM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_bCanClose)
                e.Cancel = true;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            ucAskEndASZM1.END_DATE = dtpEnd.DateTime;
            ucAskEndPDX1.END_DATE = dtpEnd.DateTime;
        }
    }
}