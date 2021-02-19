using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace PMDS.Klient
{
    

    public partial class frmDepotgeldKost : QS2.Desktop.ControlManagment.baseForm 
    {



        public frmDepotgeldKost()
        {
            InitializeComponent();
        }
        public void initControl()
        {
            this.ucTaschengeldKostentraeger1.mainWindow = this;
            this.ucTaschengeldKostentraeger1.initControl();
            uiButtons(false);
        }


        private void frmDepotgeldKostenträger_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Abrechnung.ico_Kostenstraeger, 32, 32);
            this.btnClose.Appearance.Image = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.ucTaschengeldKostentraeger1.Save())
                    uiButtons(false);
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
        private void btnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ucTaschengeldKostentraeger1.loadData();
                uiButtons(false);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void uiButtons(bool on)
        {
            this.btnSave.Enabled = on;
            this.btnUndo.Enabled = on;
        }

    }
}
