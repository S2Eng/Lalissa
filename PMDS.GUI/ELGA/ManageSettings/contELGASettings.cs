using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.DB;

namespace PMDS.GUI.ELGA.ManageSettings
{

    public partial class contELGASettings : UserControl
    {

        public contELGAUser mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDSBusiness b = new PMDSBusiness();

        public bool Isinitialized = false;

        public Nullable<Guid> _IDPatient = System.Guid.Empty;
        public bool _IsNew = false;






        public contELGASettings()
        {
            InitializeComponent();
        }

        private void ContELGASettings_Load(object sender, EventArgs e)
        {

        }




        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this._db = PMDSBusiness.getDBContext();
                    this.clearUI();

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.contELGASettings: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this._IDPatient = null;
                this._IsNew = false;

                this.txtELGAUser.Text = "";
                this.txtELGAPwd.Text = "";
                this.txtELGAPwdWdhlg.Text = "";
                this.chkELGAActive.Checked = false;
                this.chkELGAAutostartSession.Checked = false;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.clearUI: " + ex.ToString());
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
                throw new Exception("contELGASettings.validateData: " + ex.ToString());
            }
        }
        public void loadData(Nullable<Guid> IDPatient, bool isNew)
        {
            try
            {
                this._IDPatient = IDPatient;
                this._IsNew = isNew;


                

            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.loadData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGASettings.saveData: " + ex.ToString());
            }
        }


    }

}

