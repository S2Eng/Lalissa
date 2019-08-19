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

    public partial class frmVOBestellungErfassenDetail : Form
    {


        public frmVOBestellungErfassenDetail()
        {
            InitializeComponent();
        }

        private void frmVOBestellungErfassen_Load(object sender, EventArgs e)
        {

        }

        public void initControl(bool IsNew, Nullable<Guid> IDVOBestelldaten, Nullable<Guid> IDVO, bool EinmaligeAnfoderung)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOBestellungErfassenDetail1.mainWindow = this;
                this.ucVOBestellungErfassenDetail1.initControl(IsNew, IDVOBestelldaten, IDVO, EinmaligeAnfoderung);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOBestellungErfassenDetail.initControl: " + ex.ToString());
            }
        }

    }
}
