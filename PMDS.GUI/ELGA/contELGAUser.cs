using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.ELGA
{

    public partial class contELGAUser : UserControl
    {

        public ucBenutzer mainWindow = null;
        public bool IsInitialized = false;




        public contELGAUser()
        {
            InitializeComponent();
        }

        private void contELGAUserAdmin_Load(object sender, EventArgs e)
        {

        }

        
        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.contELGASettings1.initControl();
                    this.contELGARights1.initControl();
                    this.contELGAProtocoll1.initControl();



                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.initControl: " + ex.ToString());
            }
        }
        public void clearUI()
        {
            try
            {
                this.contELGARights1.clearUI();
                this.contELGARights1.clearUI();
                this.contELGAProtocoll1.clearUI();

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.clearUI: " + ex.ToString());
            }
        }
        public void loadData(Guid IDUser, bool IsNew, bool Editable)
        {
            try
            {
                this.contELGASettings1.loadData(IDUser, IsNew, Editable);
                this.contELGARights1.loadData(IDUser, IsNew, Editable);
                this.contELGAProtocoll1.loadData(IDUser, IsNew, Editable);

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                if (!this.contELGASettings1.validateData() || !this.contELGARights1.validateData())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                this.contELGASettings1.saveData();
                this.contELGARights1.saveData();

                this.loadData(this.contELGASettings1._IDUser.Value, this.contELGASettings1._IsNew, this.contELGASettings1._Editable);

                //this.mainWindow.contELGAUser1.contELGAProtocoll1.loadData(this.mainWindow.contELGAUser1.contELGAProtocoll1._IDUser, 
                //                                                                        this.mainWindow.contELGAUser1.contELGAProtocoll1._IsNew, 
                //                                                                        this.mainWindow.contELGAUser1.contELGAProtocoll1._Editable);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAUserAdmin.saveData: " + ex.ToString());
            }
        }

    }

}
