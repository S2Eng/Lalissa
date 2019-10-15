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


    public partial class contELGAKlient : UserControl
    {

        public ucKlient mainWindow = null;
        public bool IsInitialized = false;

        public Guid _IDKlient;
        public Guid _IDAufenthalt;




        public contELGAKlient()
        {
            InitializeComponent();
        }
        private void contELGAKlient_Load(object sender, EventArgs e)
        {

        }



        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.initControl: " + ex.ToString());
            }
        }


        public void loadData(Guid IDKlient, Guid IDAufenthalt)
        {
            try
            {
                this._IDKlient = IDKlient;
                this._IDAufenthalt = IDAufenthalt;


            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.loadData: " + ex.ToString());
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
                throw new Exception("contELGAKlient.validateData: " + ex.ToString());
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
                throw new Exception("contELGAKlient.saveData: " + ex.ToString());
            }
        }




        private void BtnKoontaktbestätigungStorno_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void BtnDoKontaktbestätigung_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                frmELGASearchPatient frmELGASearchPatient1 = new frmELGASearchPatient();
                frmELGASearchPatient1.initControl(this._IDKlient, this._IDAufenthalt, true);
                frmELGASearchPatient1.ShowDialog();
                if (!frmELGASearchPatient1.contELGASearchPatient1.abort)
                {

                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnSetSOO_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData(this._IDKlient, this._IDAufenthalt);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
