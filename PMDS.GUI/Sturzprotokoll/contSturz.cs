using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.Sturzprotokoll
{


    public partial class contSturz : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.GUI.clAutoUI clAutoUI1 = null;

        public bool IsInitialized = false;
        public bool abort = false;
        
        public frmSturz mainWindow = null;







        public contSturz()
        {
            InitializeComponent();
        }

        private void contSturz_Load(object sender, EventArgs e)
        {

        }


        public void InitControl()
        {
            try
            {
                if (this.IsInitialized)
                {
                    return;
                }

                this.clAutoUI1.init("tblSturzprotokoll", ref this.panelSturzAutoUI);

                this.IsInitialized = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        public void loadData()
        {
            try
            {
                if (this.clAutoUI1.IsLoaded)
                {
                    return;
                }

                this.clAutoUI1.loadData("tblSturzprotokoll");

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void contSturz_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!DataLoaded)
                //{
                //    this.loadData();
                //    this.DataLoaded = true;
                //}

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.clAutoUI1.GetData();
                this.mainWindow.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                
            }
        }

    }
}
