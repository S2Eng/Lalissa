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

    public partial class contELGALogIn : UserControl
    {

        public bool abort = true;
        public frmELGALogIn mainWindow = null;
        public bool IsInitialized = false;




        public contELGALogIn()
        {
            InitializeComponent();
        }

        private void contLogIn_Load(object sender, EventArgs e)
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
                throw new Exception("contELGALogIn.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("contELGALogIn.loadData: " + ex.ToString());
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
                throw new Exception("contELGALogIn.validateData: " + ex.ToString());
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
                throw new Exception("contELGALogIn.saveData: " + ex.ToString());
            }
        }



        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.mainWindow.Close();

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.mainWindow.Close();
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



    }
}
