using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{
    public partial class frmInputText : QS2.Desktop.ControlManagment.baseForm 
    {
        public bool _apport = true;
        private bool _pflicht1 = true;
        private bool _pflicht2 = true;
        public  PMDS.Global.retFkt retValues  = new PMDS.Global.retFkt();



        public frmInputText()
        {
            InitializeComponent();
        }

        private void frmInputText_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public void setData(string titWindow, string descrEingabe1, string defaultValue1, bool pflicht1,
                                string descrEingabe2, string defaultValue2, bool pflicht2 )
        {
            this._pflicht1 = pflicht1;
            this._pflicht2 = pflicht2;

            if (titWindow != "") this.Text = titWindow;

            this.lblDescription1.Text = descrEingabe1;
            this.txtInput1.Text = defaultValue1;

            this.lblDescription2.Text = descrEingabe2;
            this.txtInput2.Value  = (string )defaultValue2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this._pflicht1)
            {
                if (this.txtInput1.Text == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Eingabe ist erforderlich!", "Eingabe");
                    this.txtInput1.Focus();
                    return;
                }
            }
            if (this._pflicht1)
            {
                if (this.lblDescription2.Text == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Eingabe ist erforderlich!", "Eingabe");
                    this.lblDescription2.Focus();
                    return;
                }
            }

            retValues.txt1 = this.txtInput1.Text;
            retValues.txt2 = (string )this.txtInput2.Value ;

            this._apport = false;
            this.Close();
        }
        private void btnApport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInputText_Activated(object sender, EventArgs e)
        {
            this.txtInput1.Focus();
        }

    }
}
