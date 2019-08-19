using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Verordnungen
{

    public partial class frmVOErfassenDetail : Form
    {


        public frmVOErfassenDetail()
        {
            InitializeComponent();
        }

        private void frmVOErfassenDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(PMDS.Global.db.ERSystem.PMDSBusinessUI.eTypeUI TypeUI, bool IsNew, Nullable<Guid> IDVO, Nullable<Guid> IDAufenthalt, Nullable<Guid> IDPflegeplan, Nullable<Guid> IDMedDaten, Nullable<Guid> IDWundeKopf,
                                    bool WithPatientSelektor, bool Einzelansicht, Nullable<Guid> TypDefault)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOErfassenDetail1.mainWindow = this;
                this.ucVOErfassenDetail1.initControl(TypeUI, IsNew, IDVO, IDAufenthalt, IDPflegeplan, IDMedDaten, IDWundeKopf, WithPatientSelektor, Einzelansicht, TypDefault);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOErfassenDetail.initControl: " + ex.ToString());
            }
        }


    }

}
