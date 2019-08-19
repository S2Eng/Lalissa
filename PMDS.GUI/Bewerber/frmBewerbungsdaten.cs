using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class frmBewerbungsdaten : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmBewerbungsdaten()
        {
            InitializeComponent();
        }
         
        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get {return ucBewerbungsdaten1.Klient;}
            set 
            { 
                ucBewerbungsdaten1.Klient = value;
                string info = ucBewerbungsdaten1.Klient.Sexus.StartsWith("m", StringComparison.CurrentCultureIgnoreCase) ? "des Klienten " : "der Klientin ";
                lblHeader.Text = string.Format(lblHeader.Text, info + ucBewerbungsdaten1.Klient.FullName);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ucBewerbungsdaten1.UpdateDATA();
            ucBewerbungsdaten1.Klient.Write(false, false, true );
            //Neu nach 03.07.2007 MDA
            ENV.SignalPatientDatenChanged(ucBewerbungsdaten1.Klient.ID);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmBewerbungsdaten_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.loadRes();
        }


        public void loadRes()
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_Bewerber, 32, 32);
 //           this.btnOK.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
 //           this.btnCancel.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32);
        }

    }
}