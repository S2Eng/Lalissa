using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.DB;
using System.Linq;


namespace PMDS.GUI.Medikament
{

    public partial class ucPatientenGleichesMedikament : UserControl
    {

        public Guid _IDMedikament;
        public Guid _IDAufenthalt;
        
        public bool abort = false;

        public PMDSBusiness b = new PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public frmPatientenGleichesMedikament mainWindow = null;







        public ucPatientenGleichesMedikament()
        {
            InitializeComponent();
        }

        private void ucPatientenGleichesMedikament_Load(object sender, EventArgs e)
        {

        }



        public void initControl(Guid IDMedikament, Guid IDAufenthalt)
        {
            try
            {
                this._IDMedikament = IDMedikament;
                this._IDAufenthalt = IDAufenthalt;

                this.loadData();
            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenGleichesMedikament.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsKlientenliste1.Clear();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var rMedikament = (from m in db.Medikament
                               where m.ID == this._IDMedikament
                                       select new
                               {
                                   ID = m.ID,
                                   Bezeichnung = m.Bezeichnung,
                               }).First();

                    this.lblMedikament.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament") + ": " + rMedikament.Bezeichnung.Trim();

                    BusinessLogic.Rezept rez = new BusinessLogic.Rezept();
                    foreach (Global.db.Global.dsKlientenListeByMedikament.PatientRow r in rez.KlientenListeByMedikament(this._IDMedikament, this._IDAufenthalt))
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNewUI = this.sqlManange1.getNewUI(ref this.dsKlientenliste1);
                        rNewUI.Bezeichnung = r.Nachname.Trim() + " " + r.Vorname.Trim() + " " + r.Bezeichnung.Trim();
                    }

                    this.gridPatientsSameMedicament.Refresh();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucPatientenGleichesMedikament.loadData: " + ex.ToString());
            }
        }






        private void gridPatientsSameMedicament_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void gridPatientsSameMedicament_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridPatientsSameMedicament))
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }

}
