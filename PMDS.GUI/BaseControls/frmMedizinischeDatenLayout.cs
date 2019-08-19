//----------------------------------------------------------------------------
/// <summary>
///	frmMedizinischeDatenLayout.cs
/// Erstellt am:	06.06.2007
/// Erstellt von:	MDA
/// </summary>
//----------------------------------------------------------------------------
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


    public partial class frmMedizinischeDatenLayout : QS2.Desktop.ControlManagment.baseForm 
    {
  

        


        public frmMedizinischeDatenLayout()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Felder vorher überprüfen
            if (!this.ucMedizinischeDatenLayout1.ValidateFields())
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Logischer Fehler!", "", MessageBoxButtons.OK);
                return;
            }
               

            ucMedizinischeDatenLayout1.Write();
            ENV.SignalMedizinischeDatenLayoutChanged();
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten wurden  gespeichert!", "", MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMedizinischetypVerwaltung_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMedizinischeDatenLayout_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }
    }
}