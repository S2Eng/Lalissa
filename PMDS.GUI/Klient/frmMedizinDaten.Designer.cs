namespace PMDS.GUI
{


    partial class frmMedizinDaten
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedizinDaten));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.lblHeader = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnCancel = new PMDS.GUI.ucButton(this.components);
            this.btnOK = new PMDS.GUI.ucButton(this.components);
            this.contextMenuStripSavexyxy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mehrfachauswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBeginn = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblEnde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblIcdCode = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbICDCode = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblLetzeVers = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblNaechsteVers = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbAufnDiagn = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.dtpBeginn = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpLetztVers = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpEnde = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.dtpNaechVers = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cbAntikoaguliert = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbNuechtern = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.pnlBeginn = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlVersorgung = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlDiagAntik = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlNuechtern = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlAnzahl = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblAnzahl = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbAnzahl = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.pnlTherapie = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblTherapie = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbTherapie = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.cmbTyp = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlBeendGrung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBeendGrund = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBeendGrund = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBemerkung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBemerkung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBemerkung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBeschreibung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlTyp = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblTyp = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlHandling = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblHandling = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbHandling = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlModell = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblModel = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbModell = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnTerminErstellen = new PMDS.GUI.ucButton(this.components);
            this.btnDekursErstellen = new PMDS.GUI.ucButton(this.components);
            this.btnOpenBefund = new Infragistics.Win.Misc.UltraButton();
            this.ultraPopupControlContainerDekursEntwürfe = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.PanelDekursEntwürfe = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDekursEntwurfErstellenAs = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDekursEntwurfErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.uDropDownDekursEntwürfe = new Infragistics.Win.Misc.UltraDropDownButton();
            this.btnKlientenMehrfachauswahl = new QS2.Desktop.ControlManagment.BaseButton();
            this.pnlGroesse = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblGroesse = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbGroesse = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.btnBefundStorno = new Infragistics.Win.Misc.UltraButton();
            this.contextMenuStripSavexyxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbICDCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAufnDiagn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLetztVers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechVers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAntikoaguliert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuechtern)).BeginInit();
            this.pnlBeginn.SuspendLayout();
            this.pnlVersorgung.SuspendLayout();
            this.pnlDiagAntik.SuspendLayout();
            this.pnlNuechtern.SuspendLayout();
            this.pnlAnzahl.SuspendLayout();
            this.pnlTherapie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTherapie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTyp)).BeginInit();
            this.pnlBeendGrung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeendGrund)).BeginInit();
            this.pnlBemerkung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBemerkung)).BeginInit();
            this.pnlBeschreibung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlTyp.SuspendLayout();
            this.pnlHandling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHandling)).BeginInit();
            this.pnlModell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbModell)).BeginInit();
            this.PanelDekursEntwürfe.SuspendLayout();
            this.pnlGroesse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroesse)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblHeader.Appearance = appearance1;
            this.lblHeader.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(899, 48);
            this.lblHeader.TabIndex = 18;
            this.lblHeader.Text = "Heimaufenthalts- / Unterbringungsgesetz";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCancel.Appearance = appearance2;
            this.btnCancel.AutoWorkLayout = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DoOnClick = true;
            this.btnCancel.IsStandardControl = true;
            this.btnCancel.Location = new System.Drawing.Point(753, 692);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnCancel.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance3;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.contextMenuStrip1 = null;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DoOnClick = true;
            this.btnOK.IsStandardControl = true;
            this.btnOK.Location = new System.Drawing.Point(843, 692);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 32);
            this.btnOK.TabIndex = 14;
            this.btnOK.TabStop = false;
            this.btnOK.TYPE = PMDS.GUI.ucButton.ButtonType.OK;
            this.btnOK.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // contextMenuStripSavexyxy
            // 
            this.contextMenuStripSavexyxy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mehrfachauswahlToolStripMenuItem});
            this.contextMenuStripSavexyxy.Name = "contextMenuStripSave";
            this.contextMenuStripSavexyxy.Size = new System.Drawing.Size(169, 26);
            // 
            // mehrfachauswahlToolStripMenuItem
            // 
            this.mehrfachauswahlToolStripMenuItem.Name = "mehrfachauswahlToolStripMenuItem";
            this.mehrfachauswahlToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.mehrfachauswahlToolStripMenuItem.Text = "Mehrfachauswahl";
            // 
            // lblBeginn
            // 
            this.lblBeginn.AutoSize = true;
            this.lblBeginn.Location = new System.Drawing.Point(12, 11);
            this.lblBeginn.Name = "lblBeginn";
            this.lblBeginn.Size = new System.Drawing.Size(40, 14);
            this.lblBeginn.TabIndex = 25;
            this.lblBeginn.Text = "Beginn";
            // 
            // lblEnde
            // 
            this.lblEnde.AutoSize = true;
            this.lblEnde.Location = new System.Drawing.Point(298, 11);
            this.lblEnde.Name = "lblEnde";
            this.lblEnde.Size = new System.Drawing.Size(31, 14);
            this.lblEnde.TabIndex = 33;
            this.lblEnde.Text = "Ende";
            // 
            // lblIcdCode
            // 
            this.lblIcdCode.AutoSize = true;
            this.lblIcdCode.Location = new System.Drawing.Point(550, 10);
            this.lblIcdCode.Name = "lblIcdCode";
            this.lblIcdCode.Size = new System.Drawing.Size(55, 14);
            this.lblIcdCode.TabIndex = 34;
            this.lblIcdCode.Text = "ICD-Code";
            // 
            // tbICDCode
            // 
            this.tbICDCode.AcceptsReturn = true;
            this.tbICDCode.Location = new System.Drawing.Point(613, 6);
            this.tbICDCode.MaxLength = 20;
            this.tbICDCode.Name = "tbICDCode";
            this.tbICDCode.Size = new System.Drawing.Size(175, 21);
            this.tbICDCode.TabIndex = 2;
            // 
            // lblLetzeVers
            // 
            this.lblLetzeVers.AutoSize = true;
            this.lblLetzeVers.Location = new System.Drawing.Point(12, 6);
            this.lblLetzeVers.Name = "lblLetzeVers";
            this.lblLetzeVers.Size = new System.Drawing.Size(97, 14);
            this.lblLetzeVers.TabIndex = 42;
            this.lblLetzeVers.Text = "Letzte Versorgung";
            // 
            // lblNaechsteVers
            // 
            this.lblNaechsteVers.AutoSize = true;
            this.lblNaechsteVers.Location = new System.Drawing.Point(298, 7);
            this.lblNaechsteVers.Name = "lblNaechsteVers";
            this.lblNaechsteVers.Size = new System.Drawing.Size(107, 14);
            this.lblNaechsteVers.TabIndex = 44;
            this.lblNaechsteVers.Text = "Nächste Versorgung";
            // 
            // cbAufnDiagn
            // 
            this.cbAufnDiagn.Location = new System.Drawing.Point(151, 2);
            this.cbAufnDiagn.Name = "cbAufnDiagn";
            this.cbAufnDiagn.Size = new System.Drawing.Size(120, 20);
            this.cbAufnDiagn.TabIndex = 0;
            this.cbAufnDiagn.Text = "Aufnahmediagnose";
            // 
            // dtpBeginn
            // 
            this.dtpBeginn.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBeginn.FormatString = "";
            this.dtpBeginn.Location = new System.Drawing.Point(151, 5);
            this.dtpBeginn.MaskInput = "";
            this.dtpBeginn.Name = "dtpBeginn";
            this.dtpBeginn.ownFormat = "";
            this.dtpBeginn.ownMaskInput = "";
            this.dtpBeginn.Size = new System.Drawing.Size(102, 21);
            this.dtpBeginn.TabIndex = 0;
            this.dtpBeginn.Value = null;
            // 
            // dtpLetztVers
            // 
            this.dtpLetztVers.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLetztVers.FormatString = "";
            this.dtpLetztVers.Location = new System.Drawing.Point(151, 2);
            this.dtpLetztVers.MaskInput = "";
            this.dtpLetztVers.Name = "dtpLetztVers";
            this.dtpLetztVers.ownFormat = "";
            this.dtpLetztVers.ownMaskInput = "";
            this.dtpLetztVers.Size = new System.Drawing.Size(102, 21);
            this.dtpLetztVers.TabIndex = 0;
            this.dtpLetztVers.Value = null;
            // 
            // dtpEnde
            // 
            this.dtpEnde.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEnde.FormatString = "";
            this.dtpEnde.Location = new System.Drawing.Point(411, 4);
            this.dtpEnde.MaskInput = "";
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.ownFormat = "";
            this.dtpEnde.ownMaskInput = "";
            this.dtpEnde.Size = new System.Drawing.Size(102, 21);
            this.dtpEnde.TabIndex = 1;
            this.dtpEnde.Value = null;
            // 
            // dtpNaechVers
            // 
            this.dtpNaechVers.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNaechVers.FormatString = "";
            this.dtpNaechVers.Location = new System.Drawing.Point(411, 2);
            this.dtpNaechVers.MaskInput = "";
            this.dtpNaechVers.Name = "dtpNaechVers";
            this.dtpNaechVers.ownFormat = "";
            this.dtpNaechVers.ownMaskInput = "";
            this.dtpNaechVers.Size = new System.Drawing.Size(102, 21);
            this.dtpNaechVers.TabIndex = 1;
            this.dtpNaechVers.Value = null;
            // 
            // cbAntikoaguliert
            // 
            this.cbAntikoaguliert.Checked = true;
            this.cbAntikoaguliert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAntikoaguliert.Location = new System.Drawing.Point(298, 2);
            this.cbAntikoaguliert.Name = "cbAntikoaguliert";
            this.cbAntikoaguliert.Size = new System.Drawing.Size(107, 20);
            this.cbAntikoaguliert.TabIndex = 1;
            this.cbAntikoaguliert.Text = "Antikoaguliert";
            this.cbAntikoaguliert.Visible = false;
            // 
            // cbNuechtern
            // 
            this.cbNuechtern.Location = new System.Drawing.Point(151, 3);
            this.cbNuechtern.Name = "cbNuechtern";
            this.cbNuechtern.Size = new System.Drawing.Size(107, 20);
            this.cbNuechtern.TabIndex = 0;
            this.cbNuechtern.Text = "Nüchtern";
            // 
            // pnlBeginn
            // 
            this.pnlBeginn.Controls.Add(this.lblBeginn);
            this.pnlBeginn.Controls.Add(this.lblEnde);
            this.pnlBeginn.Controls.Add(this.lblIcdCode);
            this.pnlBeginn.Controls.Add(this.tbICDCode);
            this.pnlBeginn.Controls.Add(this.dtpBeginn);
            this.pnlBeginn.Controls.Add(this.dtpEnde);
            this.pnlBeginn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeginn.Location = new System.Drawing.Point(0, 48);
            this.pnlBeginn.Name = "pnlBeginn";
            this.pnlBeginn.Size = new System.Drawing.Size(899, 30);
            this.pnlBeginn.TabIndex = 51;
            // 
            // pnlVersorgung
            // 
            this.pnlVersorgung.Controls.Add(this.lblLetzeVers);
            this.pnlVersorgung.Controls.Add(this.lblNaechsteVers);
            this.pnlVersorgung.Controls.Add(this.dtpLetztVers);
            this.pnlVersorgung.Controls.Add(this.dtpNaechVers);
            this.pnlVersorgung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersorgung.Location = new System.Drawing.Point(0, 78);
            this.pnlVersorgung.Name = "pnlVersorgung";
            this.pnlVersorgung.Size = new System.Drawing.Size(899, 25);
            this.pnlVersorgung.TabIndex = 52;
            // 
            // pnlDiagAntik
            // 
            this.pnlDiagAntik.Controls.Add(this.cbAufnDiagn);
            this.pnlDiagAntik.Controls.Add(this.cbAntikoaguliert);
            this.pnlDiagAntik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDiagAntik.Location = new System.Drawing.Point(0, 103);
            this.pnlDiagAntik.Name = "pnlDiagAntik";
            this.pnlDiagAntik.Size = new System.Drawing.Size(899, 25);
            this.pnlDiagAntik.TabIndex = 54;
            // 
            // pnlNuechtern
            // 
            this.pnlNuechtern.Controls.Add(this.cbNuechtern);
            this.pnlNuechtern.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNuechtern.Location = new System.Drawing.Point(0, 128);
            this.pnlNuechtern.Name = "pnlNuechtern";
            this.pnlNuechtern.Size = new System.Drawing.Size(899, 25);
            this.pnlNuechtern.TabIndex = 55;
            // 
            // pnlAnzahl
            // 
            this.pnlAnzahl.Controls.Add(this.lblAnzahl);
            this.pnlAnzahl.Controls.Add(this.tbAnzahl);
            this.pnlAnzahl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnzahl.Location = new System.Drawing.Point(0, 153);
            this.pnlAnzahl.Name = "pnlAnzahl";
            this.pnlAnzahl.Size = new System.Drawing.Size(899, 25);
            this.pnlAnzahl.TabIndex = 60;
            // 
            // lblAnzahl
            // 
            this.lblAnzahl.AutoSize = true;
            this.lblAnzahl.Location = new System.Drawing.Point(12, 6);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(39, 14);
            this.lblAnzahl.TabIndex = 48;
            this.lblAnzahl.Text = "Anzahl";
            // 
            // tbAnzahl
            // 
            this.tbAnzahl.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double;
            this.tbAnzahl.Location = new System.Drawing.Point(151, 3);
            this.tbAnzahl.MinValue = "0";
            this.tbAnzahl.Name = "tbAnzahl";
            this.tbAnzahl.NonAutoSizeHeight = 20;
            this.tbAnzahl.NullText = "0";
            this.tbAnzahl.Size = new System.Drawing.Size(102, 20);
            this.tbAnzahl.TabIndex = 0;
            this.tbAnzahl.Text = "000";
            // 
            // pnlTherapie
            // 
            this.pnlTherapie.Controls.Add(this.lblTherapie);
            this.pnlTherapie.Controls.Add(this.tbTherapie);
            this.pnlTherapie.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTherapie.Location = new System.Drawing.Point(0, 364);
            this.pnlTherapie.Name = "pnlTherapie";
            this.pnlTherapie.Size = new System.Drawing.Size(899, 62);
            this.pnlTherapie.TabIndex = 64;
            // 
            // lblTherapie
            // 
            this.lblTherapie.AutoSize = true;
            this.lblTherapie.Location = new System.Drawing.Point(12, 5);
            this.lblTherapie.Name = "lblTherapie";
            this.lblTherapie.Size = new System.Drawing.Size(49, 14);
            this.lblTherapie.TabIndex = 38;
            this.lblTherapie.Text = "Therapie";
            // 
            // tbTherapie
            // 
            this.tbTherapie.AcceptsReturn = true;
            this.tbTherapie.Location = new System.Drawing.Point(151, 3);
            this.tbTherapie.MaxLength = 255;
            this.tbTherapie.Multiline = true;
            this.tbTherapie.Name = "tbTherapie";
            this.tbTherapie.Size = new System.Drawing.Size(637, 57);
            this.tbTherapie.TabIndex = 0;
            // 
            // cmbTyp
            // 
            this.cmbTyp.AddEmptyEntry = false;
            this.cmbTyp.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            this.cmbTyp.AutoOpenCBO = false;
            this.cmbTyp.BerufsstandGruppeJNA = -1;
            this.cmbTyp.ExactMatch = false;
            this.cmbTyp.Group = "DTH";
            this.cmbTyp.ID_PEP = -1;
            this.cmbTyp.Location = new System.Drawing.Point(151, 3);
            this.cmbTyp.MaxLength = 50;
            this.cmbTyp.Name = "cmbTyp";
            this.cmbTyp.PflichtJN = false;
            this.cmbTyp.ShowAddButton = true;
            this.cmbTyp.Size = new System.Drawing.Size(187, 21);
            this.cmbTyp.sys = false;
            this.cmbTyp.TabIndex = 0;
            // 
            // pnlBeendGrung
            // 
            this.pnlBeendGrung.Controls.Add(this.lblBeendGrund);
            this.pnlBeendGrung.Controls.Add(this.tbBeendGrund);
            this.pnlBeendGrung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeendGrung.Location = new System.Drawing.Point(0, 302);
            this.pnlBeendGrung.Name = "pnlBeendGrung";
            this.pnlBeendGrung.Size = new System.Drawing.Size(899, 62);
            this.pnlBeendGrung.TabIndex = 63;
            // 
            // lblBeendGrund
            // 
            this.lblBeendGrund.AutoSize = true;
            this.lblBeendGrund.Location = new System.Drawing.Point(12, 5);
            this.lblBeendGrund.Name = "lblBeendGrund";
            this.lblBeendGrund.Size = new System.Drawing.Size(99, 14);
            this.lblBeendGrund.TabIndex = 31;
            this.lblBeendGrund.Text = "Beendigungsgrund";
            // 
            // tbBeendGrund
            // 
            this.tbBeendGrund.AcceptsReturn = true;
            this.tbBeendGrund.Location = new System.Drawing.Point(151, 3);
            this.tbBeendGrund.MaxLength = 255;
            this.tbBeendGrund.Multiline = true;
            this.tbBeendGrund.Name = "tbBeendGrund";
            this.tbBeendGrund.Size = new System.Drawing.Size(637, 57);
            this.tbBeendGrund.TabIndex = 0;
            // 
            // pnlBemerkung
            // 
            this.pnlBemerkung.Controls.Add(this.lblBemerkung);
            this.pnlBemerkung.Controls.Add(this.tbBemerkung);
            this.pnlBemerkung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBemerkung.Location = new System.Drawing.Point(0, 240);
            this.pnlBemerkung.Name = "pnlBemerkung";
            this.pnlBemerkung.Size = new System.Drawing.Size(899, 62);
            this.pnlBemerkung.TabIndex = 62;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.AutoSize = true;
            this.lblBemerkung.Location = new System.Drawing.Point(12, 4);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(62, 14);
            this.lblBemerkung.TabIndex = 29;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // tbBemerkung
            // 
            this.tbBemerkung.AcceptsReturn = true;
            this.tbBemerkung.Location = new System.Drawing.Point(151, 2);
            this.tbBemerkung.MaxLength = 255;
            this.tbBemerkung.Multiline = true;
            this.tbBemerkung.Name = "tbBemerkung";
            this.tbBemerkung.Size = new System.Drawing.Size(637, 57);
            this.tbBemerkung.TabIndex = 0;
            // 
            // pnlBeschreibung
            // 
            this.pnlBeschreibung.Controls.Add(this.lblBeschreibung);
            this.pnlBeschreibung.Controls.Add(this.tbBeschreibung);
            this.pnlBeschreibung.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeschreibung.Location = new System.Drawing.Point(0, 178);
            this.pnlBeschreibung.Name = "pnlBeschreibung";
            this.pnlBeschreibung.Size = new System.Drawing.Size(899, 62);
            this.pnlBeschreibung.TabIndex = 61;
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Location = new System.Drawing.Point(12, 4);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(74, 14);
            this.lblBeschreibung.TabIndex = 27;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // tbBeschreibung
            // 
            this.tbBeschreibung.AcceptsReturn = true;
            this.tbBeschreibung.Location = new System.Drawing.Point(151, 2);
            this.tbBeschreibung.MaxLength = 255;
            this.tbBeschreibung.Multiline = true;
            this.tbBeschreibung.Name = "tbBeschreibung";
            this.tbBeschreibung.Size = new System.Drawing.Size(637, 57);
            this.tbBeschreibung.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlTyp
            // 
            this.pnlTyp.Controls.Add(this.cmbTyp);
            this.pnlTyp.Controls.Add(this.lblTyp);
            this.pnlTyp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTyp.Location = new System.Drawing.Point(0, 426);
            this.pnlTyp.Name = "pnlTyp";
            this.pnlTyp.Size = new System.Drawing.Size(899, 28);
            this.pnlTyp.TabIndex = 67;
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Location = new System.Drawing.Point(12, 3);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(23, 14);
            this.lblTyp.TabIndex = 46;
            this.lblTyp.Text = "Typ";
            // 
            // pnlHandling
            // 
            this.pnlHandling.Controls.Add(this.lblHandling);
            this.pnlHandling.Controls.Add(this.tbHandling);
            this.pnlHandling.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHandling.Location = new System.Drawing.Point(0, 454);
            this.pnlHandling.Name = "pnlHandling";
            this.pnlHandling.Size = new System.Drawing.Size(899, 62);
            this.pnlHandling.TabIndex = 11;
            // 
            // lblHandling
            // 
            this.lblHandling.AutoSize = true;
            this.lblHandling.Location = new System.Drawing.Point(12, 4);
            this.lblHandling.Name = "lblHandling";
            this.lblHandling.Size = new System.Drawing.Size(62, 14);
            this.lblHandling.TabIndex = 40;
            this.lblHandling.Text = "Anmerkung";
            // 
            // tbHandling
            // 
            this.tbHandling.AcceptsReturn = true;
            this.tbHandling.Location = new System.Drawing.Point(151, 2);
            this.tbHandling.MaxLength = 255;
            this.tbHandling.Multiline = true;
            this.tbHandling.Name = "tbHandling";
            this.tbHandling.Size = new System.Drawing.Size(637, 57);
            this.tbHandling.TabIndex = 0;
            // 
            // pnlModell
            // 
            this.pnlModell.Controls.Add(this.lblModel);
            this.pnlModell.Controls.Add(this.tbModell);
            this.pnlModell.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModell.Location = new System.Drawing.Point(0, 516);
            this.pnlModell.Name = "pnlModell";
            this.pnlModell.Size = new System.Drawing.Size(899, 62);
            this.pnlModell.TabIndex = 12;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(12, 4);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(38, 14);
            this.lblModel.TabIndex = 46;
            this.lblModel.Text = "Modell";
            // 
            // tbModell
            // 
            this.tbModell.AcceptsReturn = true;
            this.tbModell.Location = new System.Drawing.Point(151, 2);
            this.tbModell.MaxLength = 255;
            this.tbModell.Multiline = true;
            this.tbModell.Name = "tbModell";
            this.tbModell.Size = new System.Drawing.Size(637, 57);
            this.tbModell.TabIndex = 0;
            // 
            // btnTerminErstellen
            // 
            this.btnTerminErstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnTerminErstellen.Appearance = appearance11;
            this.btnTerminErstellen.AutoWorkLayout = false;
            this.btnTerminErstellen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTerminErstellen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTerminErstellen.DoOnClick = true;
            this.btnTerminErstellen.IsStandardControl = true;
            this.btnTerminErstellen.Location = new System.Drawing.Point(243, 691);
            this.btnTerminErstellen.Name = "btnTerminErstellen";
            this.btnTerminErstellen.Size = new System.Drawing.Size(102, 33);
            this.btnTerminErstellen.TabIndex = 68;
            this.btnTerminErstellen.TabStop = false;
            this.btnTerminErstellen.Text = "Termin erstellen";
            this.btnTerminErstellen.TYPE = PMDS.GUI.ucButton.ButtonType.none;
            this.btnTerminErstellen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnTerminErstellen.Click += new System.EventHandler(this.btnTerminErstellen_Click);
            // 
            // btnDekursErstellen
            // 
            this.btnDekursErstellen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDekursErstellen.Appearance = appearance10;
            this.btnDekursErstellen.AutoWorkLayout = false;
            this.btnDekursErstellen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDekursErstellen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDekursErstellen.DoOnClick = true;
            this.btnDekursErstellen.IsStandardControl = true;
            this.btnDekursErstellen.Location = new System.Drawing.Point(8, 691);
            this.btnDekursErstellen.Name = "btnDekursErstellen";
            this.btnDekursErstellen.Size = new System.Drawing.Size(100, 33);
            this.btnDekursErstellen.TabIndex = 69;
            this.btnDekursErstellen.TabStop = false;
            this.btnDekursErstellen.Text = "Dekurs erstellen";
            this.btnDekursErstellen.TYPE = PMDS.GUI.ucButton.ButtonType.none;
            this.btnDekursErstellen.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDekursErstellen.Click += new System.EventHandler(this.btnDekursErstellen_Click);
            // 
            // btnOpenBefund
            // 
            this.btnOpenBefund.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance9.BorderColor = System.Drawing.Color.Black;
            this.btnOpenBefund.Appearance = appearance9;
            this.btnOpenBefund.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenBefund.Location = new System.Drawing.Point(347, 691);
            this.btnOpenBefund.Name = "btnOpenBefund";
            this.btnOpenBefund.Size = new System.Drawing.Size(59, 33);
            this.btnOpenBefund.TabIndex = 70;
            this.btnOpenBefund.Tag = "";
            this.btnOpenBefund.Text = "Befund";
            this.btnOpenBefund.Visible = false;
            this.btnOpenBefund.Click += new System.EventHandler(this.btnOpenBefund_Click);
            // 
            // ultraPopupControlContainerDekursEntwürfe
            // 
            this.ultraPopupControlContainerDekursEntwürfe.PopupControl = this.PanelDekursEntwürfe;
            // 
            // PanelDekursEntwürfe
            // 
            this.PanelDekursEntwürfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PanelDekursEntwürfe.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelDekursEntwürfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellenAs);
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellen);
            this.PanelDekursEntwürfe.Location = new System.Drawing.Point(644, 693);
            this.PanelDekursEntwürfe.Name = "PanelDekursEntwürfe";
            this.PanelDekursEntwürfe.Size = new System.Drawing.Size(103, 54);
            this.PanelDekursEntwürfe.TabIndex = 94;
            this.PanelDekursEntwürfe.Visible = false;
            // 
            // btnDekursEntwurfErstellenAs
            // 
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellenAs.Appearance = appearance6;
            this.btnDekursEntwurfErstellenAs.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellenAs.IsStandardControl = false;
            this.btnDekursEntwurfErstellenAs.Location = new System.Drawing.Point(4, 27);
            this.btnDekursEntwurfErstellenAs.Name = "btnDekursEntwurfErstellenAs";
            this.btnDekursEntwurfErstellenAs.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellenAs.TabIndex = 96;
            this.btnDekursEntwurfErstellenAs.Text = "Erstellen als";
            this.btnDekursEntwurfErstellenAs.Click += new System.EventHandler(this.btnDekursEntwurfErstellenAs_Click);
            // 
            // btnDekursEntwurfErstellen
            // 
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellen.Appearance = appearance7;
            this.btnDekursEntwurfErstellen.AutoWorkLayout = false;
            this.btnDekursEntwurfErstellen.IsStandardControl = false;
            this.btnDekursEntwurfErstellen.Location = new System.Drawing.Point(4, 3);
            this.btnDekursEntwurfErstellen.Name = "btnDekursEntwurfErstellen";
            this.btnDekursEntwurfErstellen.Size = new System.Drawing.Size(94, 24);
            this.btnDekursEntwurfErstellen.TabIndex = 95;
            this.btnDekursEntwurfErstellen.Text = "Erstellen";
            this.btnDekursEntwurfErstellen.Click += new System.EventHandler(this.btnDekursEntwurfErstellen_Click);
            // 
            // uDropDownDekursEntwürfe
            // 
            this.uDropDownDekursEntwürfe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownDekursEntwürfe.Appearance = appearance8;
            this.uDropDownDekursEntwürfe.Location = new System.Drawing.Point(111, 693);
            this.uDropDownDekursEntwürfe.Name = "uDropDownDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemKey = "PanelDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemProvider = this.ultraPopupControlContainerDekursEntwürfe;
            this.uDropDownDekursEntwürfe.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDekursEntwürfe.Size = new System.Drawing.Size(122, 30);
            this.uDropDownDekursEntwürfe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDekursEntwürfe.TabIndex = 93;
            this.uDropDownDekursEntwürfe.Text = "Dekurs Entwurf";
            this.uDropDownDekursEntwürfe.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDekursEntwürfe.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnKlientenMehrfachauswahl
            // 
            this.btnKlientenMehrfachauswahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnKlientenMehrfachauswahl.Appearance = appearance5;
            this.btnKlientenMehrfachauswahl.AutoWorkLayout = false;
            this.btnKlientenMehrfachauswahl.IsStandardControl = false;
            this.btnKlientenMehrfachauswahl.Location = new System.Drawing.Point(479, 691);
            this.btnKlientenMehrfachauswahl.Name = "btnKlientenMehrfachauswahl";
            this.btnKlientenMehrfachauswahl.Size = new System.Drawing.Size(127, 33);
            this.btnKlientenMehrfachauswahl.TabIndex = 95;
            this.btnKlientenMehrfachauswahl.Text = "Klienten Mehrfachauswahl";
            this.btnKlientenMehrfachauswahl.UseAppStyling = false;
            this.btnKlientenMehrfachauswahl.Click += new System.EventHandler(this.btnKlientenMehrfachauswahl_Click);
            // 
            // pnlGroesse
            // 
            this.pnlGroesse.Controls.Add(this.lblGroesse);
            this.pnlGroesse.Controls.Add(this.tbGroesse);
            this.pnlGroesse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroesse.Location = new System.Drawing.Point(0, 578);
            this.pnlGroesse.Name = "pnlGroesse";
            this.pnlGroesse.Size = new System.Drawing.Size(899, 33);
            this.pnlGroesse.TabIndex = 96;
            // 
            // lblGroesse
            // 
            this.lblGroesse.AutoSize = true;
            this.lblGroesse.Location = new System.Drawing.Point(12, 4);
            this.lblGroesse.Name = "lblGroesse";
            this.lblGroesse.Size = new System.Drawing.Size(36, 14);
            this.lblGroesse.TabIndex = 46;
            this.lblGroesse.Text = "Größe";
            // 
            // tbGroesse
            // 
            this.tbGroesse.AcceptsReturn = true;
            this.tbGroesse.Location = new System.Drawing.Point(151, 5);
            this.tbGroesse.MaxLength = 255;
            this.tbGroesse.Multiline = true;
            this.tbGroesse.Name = "tbGroesse";
            this.tbGroesse.Size = new System.Drawing.Size(637, 24);
            this.tbGroesse.TabIndex = 0;
            // 
            // btnBefundStorno
            // 
            this.btnBefundStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BorderColor = System.Drawing.Color.Black;
            this.btnBefundStorno.Appearance = appearance4;
            this.btnBefundStorno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBefundStorno.Location = new System.Drawing.Point(408, 691);
            this.btnBefundStorno.Name = "btnBefundStorno";
            this.btnBefundStorno.Size = new System.Drawing.Size(69, 33);
            this.btnBefundStorno.TabIndex = 97;
            this.btnBefundStorno.Tag = "";
            this.btnBefundStorno.Text = "Befund stornieren";
            this.btnBefundStorno.Visible = false;
            this.btnBefundStorno.Click += new System.EventHandler(this.btnBefundStorno_Click);
            // 
            // frmMedizinDaten
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(899, 728);
            this.Controls.Add(this.btnBefundStorno);
            this.Controls.Add(this.pnlGroesse);
            this.Controls.Add(this.btnKlientenMehrfachauswahl);
            this.Controls.Add(this.PanelDekursEntwürfe);
            this.Controls.Add(this.uDropDownDekursEntwürfe);
            this.Controls.Add(this.btnOpenBefund);
            this.Controls.Add(this.btnDekursErstellen);
            this.Controls.Add(this.btnTerminErstellen);
            this.Controls.Add(this.pnlModell);
            this.Controls.Add(this.pnlHandling);
            this.Controls.Add(this.pnlTyp);
            this.Controls.Add(this.pnlTherapie);
            this.Controls.Add(this.pnlBeendGrung);
            this.Controls.Add(this.pnlBemerkung);
            this.Controls.Add(this.pnlBeschreibung);
            this.Controls.Add(this.pnlAnzahl);
            this.Controls.Add(this.pnlNuechtern);
            this.Controls.Add(this.pnlDiagAntik);
            this.Controls.Add(this.pnlVersorgung);
            this.Controls.Add(this.pnlBeginn);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMedizinDaten";
            this.ShowInTaskbar = false;
            this.Text = "Medizinsche Daten";
            this.Load += new System.EventHandler(this.frmMedizinDaten_Load);
            this.contextMenuStripSavexyxy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbICDCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAufnDiagn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpLetztVers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechVers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAntikoaguliert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuechtern)).EndInit();
            this.pnlBeginn.ResumeLayout(false);
            this.pnlBeginn.PerformLayout();
            this.pnlVersorgung.ResumeLayout(false);
            this.pnlVersorgung.PerformLayout();
            this.pnlDiagAntik.ResumeLayout(false);
            this.pnlNuechtern.ResumeLayout(false);
            this.pnlAnzahl.ResumeLayout(false);
            this.pnlAnzahl.PerformLayout();
            this.pnlTherapie.ResumeLayout(false);
            this.pnlTherapie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTherapie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTyp)).EndInit();
            this.pnlBeendGrung.ResumeLayout(false);
            this.pnlBeendGrung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeendGrund)).EndInit();
            this.pnlBemerkung.ResumeLayout(false);
            this.pnlBemerkung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBemerkung)).EndInit();
            this.pnlBeschreibung.ResumeLayout(false);
            this.pnlBeschreibung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlTyp.ResumeLayout(false);
            this.pnlTyp.PerformLayout();
            this.pnlHandling.ResumeLayout(false);
            this.pnlHandling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHandling)).EndInit();
            this.pnlModell.ResumeLayout(false);
            this.pnlModell.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbModell)).EndInit();
            this.PanelDekursEntwürfe.ResumeLayout(false);
            this.pnlGroesse.ResumeLayout(false);
            this.pnlGroesse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbGroesse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblHeader;
        private PMDS.GUI.ucButton btnCancel;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeginn;
        private QS2.Desktop.ControlManagment.BaseLabel lblEnde;
        private QS2.Desktop.ControlManagment.BaseLabel lblIcdCode;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbICDCode;
        private QS2.Desktop.ControlManagment.BaseLabel lblLetzeVers;
        private QS2.Desktop.ControlManagment.BaseLabel lblNaechsteVers;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbAufnDiagn;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBeginn;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpLetztVers;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnde;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpNaechVers;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbAntikoaguliert;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbNuechtern;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeginn;
        private QS2.Desktop.ControlManagment.BasePanel pnlVersorgung;
        private QS2.Desktop.ControlManagment.BasePanel pnlDiagAntik;
        private QS2.Desktop.ControlManagment.BasePanel pnlNuechtern;
        private QS2.Desktop.ControlManagment.BasePanel pnlAnzahl;
        private QS2.Desktop.ControlManagment.BaseLabel lblAnzahl;
        private QS2.Desktop.ControlManagment.BaseMaskEdit tbAnzahl;
        private QS2.Desktop.ControlManagment.BasePanel pnlTherapie;
        private QS2.Desktop.ControlManagment.BaseLabel lblTherapie;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbTherapie;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeendGrung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeendGrund;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeendGrund;
        private QS2.Desktop.ControlManagment.BasePanel pnlBemerkung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBemerkung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBemerkung;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeschreibung;
        private QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbBeschreibung;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private PMDS.GUI.BaseControls.AuswahlGruppeCombo cmbTyp;
        private QS2.Desktop.ControlManagment.BasePanel pnlTyp;
        private QS2.Desktop.ControlManagment.BaseLabel lblTyp;
        private QS2.Desktop.ControlManagment.BasePanel pnlHandling;
        private QS2.Desktop.ControlManagment.BaseLabel lblHandling;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbHandling;
        private QS2.Desktop.ControlManagment.BasePanel pnlModell;
        private QS2.Desktop.ControlManagment.BaseLabel lblModel;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbModell;
        private ucButton btnDekursErstellen;
        private ucButton btnTerminErstellen;
        internal Infragistics.Win.Misc.UltraButton btnOpenBefund;
        private System.Windows.Forms.ToolStripMenuItem mehrfachauswahlToolStripMenuItem;
        public ucButton btnOK;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripSavexyxy;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerDekursEntwürfe;
        private QS2.Desktop.ControlManagment.BasePanel PanelDekursEntwürfe;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellenAs;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellen;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDekursEntwürfe;
        public QS2.Desktop.ControlManagment.BaseButton btnKlientenMehrfachauswahl;
        private QS2.Desktop.ControlManagment.BasePanel pnlGroesse;
        private QS2.Desktop.ControlManagment.BaseLabel lblGroesse;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbGroesse;
        internal Infragistics.Win.Misc.UltraButton btnBefundStorno;
    }
}