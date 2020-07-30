using EnvDTE;
using PMDS.Global;
using PMDSClient.Sitemap;
using System;
using System.Windows.Forms;


namespace PMDS.GUI.Print
{
    public partial class frmELGAPrintPflegesituationsbericht : Form
    {
        private bool _canClose { get; set; } = false;

        public frmELGAPrintPflegesituationsbericht()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                this.cbETo.NotKrankenkasse = true;
                this.cbETo.RefreshList();
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        private void frmELGAPrintPflegesituationsbericht_Load(object sender, EventArgs e)
        {
            this.cDAPflegesituationsberichtToolStripMenuItem.Visible = ENV.adminSecure;
            this.cDAEntlassungsbriefToolStripMenuItem.Visible = ENV.adminSecure;
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!validateCboEinrichtung())
                return;

            _canClose = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _canClose = true;
        }

        private void frmELGAPrintPflegesituationsbericht_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_canClose;
        }

        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(cbETo);
        }

        private bool validateCboEinrichtung()
        {
            if (this.cbETo.Value == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Einrichtung: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void CDAEntlassungsbriefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!validateCboEinrichtung())
                    return;

                WCFServiceClient s = new WCFServiceClient();
                s.genCDA2(QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA.Entlassungsbrief, (Guid)this.cbETo.Value, System.Guid.NewGuid(),
                            System.Guid.NewGuid().ToString(), 0, "ELGA_Stylesheet_v1.0.xsl", ENV.CurrentIDPatient, ENV.IDAUFENTHALT, "Test Entlassungsbrief", null);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CDAPflegesituationsberichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!validateCboEinrichtung())
                    return;

                //WCFServiceClient s = new WCFServiceClient();
                //s.genCDA2(QS2.Desktop.ControlManagment.ServiceReference_01.CDAeTypeCDA.Pflegesituationbericht, (Guid)this.cbETo.Value, System.Guid.NewGuid(),
                //            System.Guid.NewGuid().ToString(), 0, "ELGA_Stylesheet_v1.0.xsl", ENV.CurrentIDPatient, ENV.IDAUFENTHALT, "Test Pflegesituationsbericht", null);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmELGAPrintPflegesituationsbericht_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            ucELGAPrintPflegesituationsbericht1.Init();
        }
    }
}
