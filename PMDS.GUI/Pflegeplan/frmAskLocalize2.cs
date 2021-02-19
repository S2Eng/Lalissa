using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Shared;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;
using PMDS.GUI.BaseControls;
using PMDS.BusinessLogic;

namespace PMDS.GUI
{
    public partial class frmAskLocalize2 : frmBase
    {
        private ASZMSelectionArgs[] _sa;
        private bool _bCanClose = true;
        private bool _bOKClicked = false;
        private Patient _patient;

        //Neu nach 14.05.2007 MDA
        private bool _RessourceChanged = false;
        private PDxSelectionArgs _AktivePDx = null;

        public frmAskLocalize2(ASZMSelectionArgs[] aa)
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            this.Closing += new CancelEventHandler(frmAskLocalize_Closing);

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;

            _sa = aa;
            _patient = new Patient(ENV.CurrentIDPatient);

            ucPDXTreeView1.PDX_SELARGS = ASZMTransfer.GetPDxSelectionArgs(aa);
            FillTree();
            ucASZMTransfer1.Dock = DockStyle.Top;
            ucASZMTransferPDx1.Dock = DockStyle.Fill ;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZMSelectionArgs[] setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ASZMSelectionArgs[] ARGS
        {
            get { return _sa; }
            set
            {
                _sa = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Treeviw befüllen
        /// </summary>
        //----------------------------------------------------------------------------
        private void FillTree()
        {
            ucPDXTreeView1.FillTree(_sa);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dateneingabe Prüfen
        /// </summary>
        //----------------------------------------------------------------------------
        private bool ValidateFields()
        {
            bool bError = false;

            //PDx Ebene prüfen
            foreach (PDxSelectionArgs pdxSA in ucPDXTreeView1.PDX_SELARGS)
            {
                ucPDXTreeView1.PDX_SARG = pdxSA;
                bError = !ucASZMTransferPDx1.ValidateFields();

                if (bError)
                    break;
            }

            //ASZM Ebene prüfen
            if (!bError)
            {
                foreach (ASZMSelectionArgs a in _sa)
                {
                    if (a.UntertaegigBenutzerdefiniertJN)
                    {
                        ucPDXTreeView1.ARG = a;
                        bError = !ucASZMTransfer1.ValidateFields();

                        if (bError)
                            break;
                    }
                }
            }
            return bError;
        }

        #region Events
        //----------------------------------------------------------------------------
        /// <summary>
        /// Formular schlissen
        /// </summary>
        //----------------------------------------------------------------------------
        private void frmAskLocalize_Closing(object sender, CancelEventArgs e)
        {
            if (_bOKClicked)
                e.Cancel = !_bCanClose;
            _bOKClicked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bCanClose = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ucPDXTreeView1.ARG != null || ucPDXTreeView1.PDX_SARG != null)
            {
                if (ucPDXTreeView1.IsPDx)
                {
                    ucASZMTransferPDx1.UpdateDATA();
                }
                else
                {
                    ucASZMTransfer1.UpdateDATA();
                }
            }

            bool bError = ValidateFields();
            _bCanClose = !bError;

            if (_bCanClose)
                TransferPDXLokalisierungen();

            _bOKClicked = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein TreeNode wurde Selektiert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPDXTreeView1_TreeviewAfterNodeSelectEventHandler(object sender, SelectEventArgs e)
        {
            lblError.Visible = false;

            StringBuilder sb = new StringBuilder();
            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient: ") + _patient.FullName + "\n");
            
            if (ucPDXTreeView1.ARG != null || ucPDXTreeView1.PDX_SARG != null)
            {
                
                if (ucPDXTreeView1.IsPDx)
                {
                    //Wenn ein PDx ausgewählt wurde dann das Headertext angeben ,das Control ucASZMTransferPDx einblenden
                    //und das Control ucASZMTransfer ausblenden
                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Startdatum "));
                    if (ucPDXTreeView1.PDX_SARG.LokalisierungJN)
                        sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes(" und Lokalisierung "));

                    sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("für PDx \"") + ucPDXTreeView1.PDX_SARG.Klartext + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));

                    labInfo.Text = sb.ToString();
                    ucASZMTransfer1.Visible = false;
                    ucASZMTransferPDx1.Visible = true;
                    ucASZMTransferPDx1.Left = 0;
                    ucASZMTransferPDx1.Top = 0;
                    ucASZMTransferPDx1.PDX_SARG = ucPDXTreeView1.PDX_SARG;

                    //Neu nach 14.05.2007 MDA: Ressourcen des PDX anzeigen
                    _AktivePDx = ucPDXTreeView1.PDX_SARG;

                    tbResourcen.Text = _AktivePDx.Resourceklient;
                    _RessourceChanged = false;
                }
                else
                {
                    //Wenn ein PDx ausgewählt wurde dann das Headertext angeben ,das Control ucASZMTransferPDx ausblenden
                    //und das Control ucASZMTransfer einblenden

                    switch (ucPDXTreeView1.ARG.EintragGruppe)
                    {
                        case EintragGruppe.A:
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ätiologie \"") + ucPDXTreeView1.ARG.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));
                            break;
                        case EintragGruppe.S:
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Symptom \"") + ucPDXTreeView1.ARG.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));
                            break;
                        case EintragGruppe.R:
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ressource \"") + ucPDXTreeView1.ARG.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));
                            break;
                        case EintragGruppe.Z:
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ziel \"") + ucPDXTreeView1.ARG.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));
                            break;
                        case EintragGruppe.M:
                            sb.Append(QS2.Desktop.ControlManagment.ControlManagment.getRes("Startzeitpunkte für Maßnahme \"") + ucPDXTreeView1.ARG.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben"));
                            break;
                    }


                    labInfo.Text = sb.ToString();
                    ucASZMTransferPDx1.Visible = false;
                    ucASZMTransfer1.Visible = true;
                    ucASZMTransfer1.Left = 0;
                    ucASZMTransfer1.Top = 0;
                    ucASZMTransfer1.ARG = ucPDXTreeView1.ARG;
                }
            }
            else
            {
                //Falls kein PDX oder ASZM selektiert wurde, Fehlermeldung anzeigen
                labInfo.Text = sb.ToString();
                lblError.Visible = true;
                ucASZMTransferPDx1.Visible = false;
                ucASZMTransfer1.Visible = false;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// BeforeNodeSelectEventArgs
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPDXTreeView1_TreeviewBeforeNodeSelectEventArgs(object sender, BeforeSelectEventArgs e)
        {
            if (ucPDXTreeView1.ARG != null || ucPDXTreeView1.PDX_SARG != null)
            {
                lblError.Visible = false;
                //Änderungen übernehmen
                if (ucPDXTreeView1.IsPDx)
                    ucASZMTransferPDx1.UpdateDATA();
                else
                    ucASZMTransfer1.UpdateDATA();
            }
        }

        //Neu nach 04.07.2007 MDA
        //Lokalisierung von PDx zu PDxSelectionArgs übernehmen.
        private void TransferPDXLokalisierungen()
        {
            foreach (PDxSelectionArgs pdxArg in ucPDXTreeView1.PDX_SELARGS)
                TransferLokalisierung(pdxArg);
        }

        //Neu nach 04.07.2007 MDA
        private void TransferLokalisierung(PDxSelectionArgs arg)
        {
            foreach (ASZMSelectionArgs sa in arg.ARGS)
            {
                sa.LokalisierungJN = arg.LokalisierungJN;
                sa.Lokalisierung = arg.Lokalisierung;
                sa.LokalisierungSeite = arg.LokalisierungSeite;

                if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX)
                    sa.EvalStartDatum = arg.EvalStartDatum;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eine zusätzliche PDx Lokalisierung einfügen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucASZMTransferPDx1_PDxZusaetzlicheLokalisierung(object sender, EventArgs e)
        {
            ucASZMTransferPDx1.UpdateDATA();
            ucPDXTreeView1.AddPdx();
            _sa = ucPDXTreeView1.ARGS;
        }

        private void frmAskLocalize2_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;

            //Falls keine ASZM's ausgewählt worden, Fehlermeldung anzeigen
            if (_sa == null || _sa.Length == 0)
            {
                labInfo.Visible = false;
                pnlBody.Visible = false;
                btnOK.Enabled = false;


                Infragistics.Win.Misc.UltraLabel lbl = new QS2.Desktop.ControlManagment.BaseLabel();
                Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();

                appearance.BackColor = System.Drawing.Color.WhiteSmoke;
                appearance.BorderColor = System.Drawing.Color.SteelBlue;
                appearance.ForeColor = System.Drawing.Color.Navy;
                appearance.TextHAlignAsString = "Center";
                appearance.TextVAlignAsString = "Middle";
                lbl.Appearance = appearance;
                lbl.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
                lbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Location = new System.Drawing.Point(246, 113);
                lbl.Name = "lbl";
                lbl.Size = new System.Drawing.Size(397, 282);
                lbl.TabIndex = 9;
                lbl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden keine Ätiologien, Symptome, Ressourcen, Ziele oder Maßnahmen ausgewählt.");
                Controls.Add(lbl);
                
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn Daten ein PDx geändert wurden dann Image des zugehörigen TreeNode ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucASZMTransferPDx1_PDxValueChanged(object sender, EventArgs e)
        {
            ucPDXTreeView1.UpdateTreeNodeImage();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn Daten eine ASZM geändert wurden dann Image des zugehörigen TreeNode ändern
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucASZMTransfer1_ASZMValueChanged(object sender, EventArgs e)
        {
            ucPDXTreeView1.UpdateTreeNodeImage();
        }
        #endregion

        //Neu nach 14.05.2007 MDA: Änderung von Ressorcen übernehmen.
        private void tbResourcen_Leave(object sender, EventArgs e)
        {
            if (_RessourceChanged && _AktivePDx != null)
            {
                _AktivePDx.Resourceklient = tbResourcen.Text.Trim();

                foreach (ASZMSelectionArgs arg in _AktivePDx.ARGS)
                {
                    arg.Resourceklient = _AktivePDx.Resourceklient;
                }

                _RessourceChanged = false;
            }
        }

        private void tbResourcen_ValueChanged(object sender, EventArgs e)
        {
            _RessourceChanged = true;
        }
    }
}