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

    public partial class frmVOLieferungDetail : Form
    {


        public frmVOLieferungDetail()
        {
            InitializeComponent();
        }

        private void frmVOLieferungDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(ucVOLieferung.eTypeUI TypeUI, Nullable<Guid> IDAufenthalt)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucVOLieferungDetail1.mainWindow = this;
                this.ucVOLieferungDetail1.initControl(TypeUI, IDAufenthalt);

            }
            catch (Exception ex)
            {
                throw new Exception("frmVOLieferungDetail.initControl: " + ex.ToString());
            }
        }

    }
}
