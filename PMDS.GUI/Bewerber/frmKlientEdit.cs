using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public partial class frmKlientEdit : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmKlientEdit()
        {
            InitializeComponent();
            ucKlientEdit1.mainWindow = this;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return ucKlientEdit1.IDPatient; }
            set { ucKlientEdit1.IDPatient = value; }
        }

        public void NewBewerber()
        {
            ucKlientEdit1.NewBewerber();
        }

        private void frmKlientEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = ucKlientEdit1.AskForSave();

            bool cancel = false;

            if (res == DialogResult.None || res == DialogResult.No)
            {
                cancel = false;
            }
            else if (res == DialogResult.Yes)
                cancel = ucKlientEdit1.ContentChanged;
            else if (res == DialogResult.Cancel)
                cancel = true;

            e.Cancel = cancel;
        }

        private void frmKlientEdit_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32);
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}