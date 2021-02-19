using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.DB;
using System.Linq;



namespace PMDS.GUI
{
    

    public partial class frmRezeptEintrag : QS2.Desktop.ControlManagment.baseForm 
    {
        private bool                _CanClose = true;
        public PMDSBusinessUI b2 = new PMDSBusinessUI();




        public frmRezeptEintrag(dsRezeptEintrag.RezeptEintragRow row, BearbeitungsModus modus)
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            ucRezeptEintrag1.EintragBearbeitungsmodus = modus;
            if (modus == BearbeitungsModus.neu)
            {
                this.ucRezeptEintrag1.InitCmbMedikament(System.Guid.Empty);
            }
            else
            {
                this.ucRezeptEintrag1.InitCmbMedikament(row.IDMedikament);
            }
          
            ucRezeptEintrag1.RezeptEintrag              = row;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _CanClose = true;
            if (ucRezeptEintrag1.ValidateFields())
                ucRezeptEintrag1.UpdateDATA();
            else
                _CanClose = false;
        }

        private void frmRezeptEintrag_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CanClose = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn != null ==> es fand eine Änderung statt bei der der alte Eintrag 
        /// unverändert bleibt (nur das bis Datum wird gesetzt) und der neue in dieser Eigenschaft verspeichert wird
        /// Das tritt bei Änderung der Medikation auf
        /// </summary>
        //----------------------------------------------------------------------------
        public dsRezeptEintrag.RezeptEintragRow NewRezeptEintrag
        {
            get
            {
                return ucRezeptEintrag1.NewRezeptEintrag;
            }
        }

        private void frmRezeptEintrag_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

    }
}