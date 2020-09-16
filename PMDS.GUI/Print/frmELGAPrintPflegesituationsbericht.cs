using EnvDTE;
using PMDS.Global;
using PMDSClient.Sitemap;
using System;
using System.Windows.Forms;

using MARC.Everest.Attributes;
using MARC.Everest.DataTypes;
using MARC.Everest.DataTypes.Interfaces;
using MARC.Everest.Formatters.XML.Datatypes.R1;
using MARC.Everest.RMIM.UV.CDAr2.POCD_MT000040UV;
using MARC.Everest.RMIM.UV.CDAr2.Vocabulary;
using MARC.Everest.RMIM.UV.NE2010.Interactions;
using MARC.Everest.Xml;
using System.Xml;
using MARC.Everest.Formatters.XML.ITS1;

namespace PMDS.GUI.Print
{
    public partial class frmELGAPrintPflegesituationsbericht : Form
    {
        private bool _canClose { get; set; } = false;
        private Component2 compFachlicheSektionen = new Component2();
        public bool ResumeWithPBS { get; set; } = false;
        public System.IO.MemoryStream msPSB { get; set; } =  new System.IO.MemoryStream();

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

            msPSB = this.ucELGAPrintPflegesituationsbericht1.GenerateCDA(true);
            ResumeWithPBS = false;
            _canClose = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResumeWithPBS = false;
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

        private void cbETo_ValueChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            Infragistics.Win.ValueListItem sel = this.cbETo.SelectedItem;
            if (sel != null)
            {
                ucELGAPrintPflegesituationsbericht1.Enabled = true;
                btnOK.Enabled = true;
                btnCheck.Enabled = true;
                ucELGAPrintPflegesituationsbericht1.Init(ENV.IDAUFENTHALT, (Guid)sel.DataValue, @"C:\Temp\Pflegesituationsbericht.xml");
                CheckELGA();
            }
        }

        private void CheckELGA()
        {
            this.ucELGAPrintPflegesituationsbericht1.GenerateCDA(false);
            this.btnOK.Enabled = false;
            if (this.ucELGAPrintPflegesituationsbericht1.ReturnCode == ucELGAPrintPflegesituationsbericht.eStatusResult.Ok)
            {
                this.btnPreview.Enabled = true;
            }
            else if (this.ucELGAPrintPflegesituationsbericht1.ReturnCode == ucELGAPrintPflegesituationsbericht.eStatusResult.Messages)
            {
                MessageBox.Show("Bitte beachten Sie die Hinweise, \r\nbevor Sie den Pflegesituationsbericht fertig stellen.", "Hinweis", MessageBoxButtons.OK);
                this.btnPreview.Enabled = true;
            }
            else if (this.ucELGAPrintPflegesituationsbericht1.ReturnCode == ucELGAPrintPflegesituationsbericht.eStatusResult.NoELGA)
            {
                MessageBox.Show("Der Klient nimmt nicht an ELGA teil.\nErstellen Sie bitte ein Pflegebegleitschreiben.", "Wichtiger Hinweis", MessageBoxButtons.OK);
                this.btnPreview.Enabled = false;
                ResumeWithPBS = true;
                _canClose = true;
                this.Close();
            }
            else
            {
                this.btnPreview.Enabled = false;
                DialogResult res = MessageBox.Show("Fehlende oder falsche Daten.\r\nDer Pflegesituationsbericht kann nicht erstellt werden.\r\n" + 
                                                    "Wollen Sie ein Pflegebegleitschreiben erstellen?", "FEHLER", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    ResumeWithPBS = true;
                    _canClose = true;
                    this.Close();
                }
                else
                {
                    ResumeWithPBS = false;
                    _canClose = true;
                    this.Close();
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckELGA();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream msXML = this.ucELGAPrintPflegesituationsbericht1.GenerateCDA(false);
            this.ucELGAPrintPflegesituationsbericht1.UpdatePreView(msXML);
            btnOK.Enabled = true;
        }
    }
}
