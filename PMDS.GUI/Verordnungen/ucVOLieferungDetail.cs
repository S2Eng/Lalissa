using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Global.db.ERSystem;



namespace PMDS.GUI.Verordnungen
{

    public partial class ucVOLieferungDetail : UserControl
    {

        public Nullable<Guid> _IDAufenthalt = null;
        public ucVOLieferung.eTypeUI _TypeUI = new ucVOLieferung.eTypeUI();

        public bool abort = true;
        public frmVOLieferungDetail mainWindow = null;

        public PMDSBusiness b = new PMDSBusiness();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public UIGlobal UIGlobal1 = new UIGlobal();





        public ucVOLieferungDetail()
        {
            InitializeComponent();
        }

        private void ucLieferungDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl(ucVOLieferung.eTypeUI TypeUI, Nullable<Guid> IDAufenthalt)
        {
            try
            {
                this._IDAufenthalt = IDAufenthalt;
                this._TypeUI = TypeUI;



            }
            catch (Exception ex)
            {
                throw new Exception("ucVOLieferungDetail.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {


                }


            }
            catch (Exception ex)
            {
                throw new Exception("ucVOLieferungDetail.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOLieferungDetail.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVOLieferungDetail.saveData: " + ex.ToString());
            }
        }


    }

}
