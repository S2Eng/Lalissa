using PMDS.Global.db.ERSystem;
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

    public partial class frmVOBestellvorschlaegeDetail : Form
    {
        

        public frmVOBestellvorschlaegeDetail()
        {
            InitializeComponent();
        }

        private void frmVOBestelldatenDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(ucVOBestellvorschlaegeDetail.eTypeUI TypeUI, Nullable<Guid> IDVOBestellpostitionen, dsVO.VO_BestellpostitionenRow rVO_Bestellpostitionen, bool IsNew, Nullable<Guid> IDVO_Bestelldaten, Nullable<DateTime> DatumNächsterAnspruch)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOBestellvorschlaegeDetail1.mainWindow = this;
                this.ucVOBestellvorschlaegeDetail1.initControl(TypeUI, IDVOBestellpostitionen, rVO_Bestellpostitionen, IsNew, IDVO_Bestelldaten, DatumNächsterAnspruch);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOBestellvorschlaegeDetail.initControl: " + ex.ToString());
            }
        }

    }
}
