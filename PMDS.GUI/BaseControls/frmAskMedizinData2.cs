using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.BaseControls
{

    public partial class frmAskMedizinData2 : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmAskMedizinData2(bool bStart, string sBezeichnung, string sBeschreibung)
        {
            InitializeComponent();
            
            if (bStart)
            {
                Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn ") + sBezeichnung;
                lblHeader.Text = Text;
                lblDate.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn");
                lblInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung zum Beginn ");
            }
            else
            {
                Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende ") + sBezeichnung;
                lblHeader.Text = Text;
                lblDate.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende");
                lblInfo.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung zum Ende");
            }
            tbDescription.Text = sBeschreibung;
        }

        public DateTime DATE
        {
            get 
            {
                return dtpDate.Value.Date;
            }
        }

        public string TEXT
        {
            get
            {
                return tbReason.Text.Trim();
            }
        }

        public string DESCRIPTION
        {
            get
            {
                return tbDescription.Text.Trim();
            }
        }

        private void frmAskMedizinData2_Load(object sender, EventArgs e)
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
    }
}