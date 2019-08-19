namespace PMDS.GUI
{
    partial class frmPflegeEintragSmall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPflegeEintragSmall));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkSaveForAllCC = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.PanelDekursEntwürfe = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnDekursEntwurfErstellenAs = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDekursEntwurfErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.uDropDownDekursEntwürfe = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainerDekursEntwürfe = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.panelTxtControl = new System.Windows.Forms.Panel();
            this.textControSave = new TXTextControl.TextControl();
            this.textControChanges = new TXTextControl.TextControl();
            this.textControlLineBreak = new TXTextControl.TextControl();
            this.textControlOriginal = new TXTextControl.TextControl();
            this.btnDelete = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnEdit = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnClose = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelAll = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelText = new System.Windows.Forms.Panel();
            this.lblHistorie = new Infragistics.Win.Misc.UltraLabel();
            this.textControlHistorie = new TXTextControl.TextControl();
            this.PanelTxtEditorEdit = new System.Windows.Forms.Panel();
            this.contTXTFieldBeschreibung = new QS2.Desktop.Txteditor.contTXTField();
            this.panelZusatz = new System.Windows.Forms.Panel();
            this.lblZusatzwerte = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ucZusatzWert1 = new PMDS.GUI.ucZusatzWert();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtMassnahme = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lalMassnahme = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveForAllCC)).BeginInit();
            this.PanelDekursEntwürfe.SuspendLayout();
            this.panelTxtControl.SuspendLayout();
            this.panelAll.SuspendLayout();
            this.panelText.SuspendLayout();
            this.PanelTxtEditorEdit.SuspendLayout();
            this.panelZusatz.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassnahme)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.chkSaveForAllCC);
            this.panelButtons.Controls.Add(this.PanelDekursEntwürfe);
            this.panelButtons.Controls.Add(this.uDropDownDekursEntwürfe);
            this.panelButtons.Controls.Add(this.panelTxtControl);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 671);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1222, 40);
            this.panelButtons.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(1024, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Speichern";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkSaveForAllCC
            // 
            this.chkSaveForAllCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForAllCC.Location = new System.Drawing.Point(940, 6);
            this.chkSaveForAllCC.Name = "chkSaveForAllCC";
            this.chkSaveForAllCC.Size = new System.Drawing.Size(92, 27);
            this.chkSaveForAllCC.TabIndex = 93;
            this.chkSaveForAllCC.Text = "Für alle übernehmen";
            this.chkSaveForAllCC.BeforeCheckStateChanged += new Infragistics.Win.ToggleEditorBase.BeforeCheckStateChangedHandler(this.chkSaveForAllCC_BeforeCheckStateChanged);
            this.chkSaveForAllCC.CheckedChanged += new System.EventHandler(this.chkSaveForAllCC_CheckedChanged);
            // 
            // PanelDekursEntwürfe
            // 
            this.PanelDekursEntwürfe.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelDekursEntwürfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellenAs);
            this.PanelDekursEntwürfe.Controls.Add(this.btnDekursEntwurfErstellen);
            this.PanelDekursEntwürfe.Location = new System.Drawing.Point(191, 3);
            this.PanelDekursEntwürfe.Name = "PanelDekursEntwürfe";
            this.PanelDekursEntwürfe.Size = new System.Drawing.Size(103, 54);
            this.PanelDekursEntwürfe.TabIndex = 92;
            this.PanelDekursEntwürfe.Visible = false;
            // 
            // btnDekursEntwurfErstellenAs
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellenAs.Appearance = appearance1;
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
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.btnDekursEntwurfErstellen.Appearance = appearance2;
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
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.uDropDownDekursEntwürfe.Appearance = appearance3;
            this.uDropDownDekursEntwürfe.Location = new System.Drawing.Point(12, 9);
            this.uDropDownDekursEntwürfe.Name = "uDropDownDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemKey = "PanelDekursEntwürfe";
            this.uDropDownDekursEntwürfe.PopupItemProvider = this.ultraPopupControlContainerDekursEntwürfe;
            this.uDropDownDekursEntwürfe.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.uDropDownDekursEntwürfe.Size = new System.Drawing.Size(122, 23);
            this.uDropDownDekursEntwürfe.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.uDropDownDekursEntwürfe.TabIndex = 91;
            this.uDropDownDekursEntwürfe.Text = "Dekurs Entwurf";
            this.uDropDownDekursEntwürfe.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.uDropDownDekursEntwürfe.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraPopupControlContainerDekursEntwürfe
            // 
            this.ultraPopupControlContainerDekursEntwürfe.PopupControl = this.PanelDekursEntwürfe;
            // 
            // panelTxtControl
            // 
            this.panelTxtControl.BackColor = System.Drawing.Color.Transparent;
            this.panelTxtControl.Controls.Add(this.textControSave);
            this.panelTxtControl.Controls.Add(this.textControChanges);
            this.panelTxtControl.Controls.Add(this.textControlLineBreak);
            this.panelTxtControl.Controls.Add(this.textControlOriginal);
            this.panelTxtControl.Location = new System.Drawing.Point(152, 10);
            this.panelTxtControl.Margin = new System.Windows.Forms.Padding(4);
            this.panelTxtControl.Name = "panelTxtControl";
            this.panelTxtControl.Size = new System.Drawing.Size(21, 22);
            this.panelTxtControl.TabIndex = 40;
            // 
            // textControSave
            // 
            this.textControSave.Font = new System.Drawing.Font("Arial", 10F);
            this.textControSave.Location = new System.Drawing.Point(165, 1);
            this.textControSave.Margin = new System.Windows.Forms.Padding(4);
            this.textControSave.Name = "textControSave";
            this.textControSave.Size = new System.Drawing.Size(61, 43);
            this.textControSave.TabIndex = 42;
            this.textControSave.UserNames = null;
            this.textControSave.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControChanges
            // 
            this.textControChanges.Font = new System.Drawing.Font("Arial", 10F);
            this.textControChanges.Location = new System.Drawing.Point(234, 3);
            this.textControChanges.Margin = new System.Windows.Forms.Padding(4);
            this.textControChanges.Name = "textControChanges";
            this.textControChanges.Size = new System.Drawing.Size(61, 43);
            this.textControChanges.TabIndex = 41;
            this.textControChanges.UserNames = null;
            this.textControChanges.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControlLineBreak
            // 
            this.textControlLineBreak.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlLineBreak.Location = new System.Drawing.Point(725, 4);
            this.textControlLineBreak.Margin = new System.Windows.Forms.Padding(4);
            this.textControlLineBreak.Name = "textControlLineBreak";
            this.textControlLineBreak.Size = new System.Drawing.Size(61, 43);
            this.textControlLineBreak.TabIndex = 43;
            this.textControlLineBreak.UserNames = null;
            this.textControlLineBreak.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControlOriginal
            // 
            this.textControlOriginal.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlOriginal.Location = new System.Drawing.Point(95, 4);
            this.textControlOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.textControlOriginal.Name = "textControlOriginal";
            this.textControlOriginal.Size = new System.Drawing.Size(61, 43);
            this.textControlOriginal.TabIndex = 38;
            this.textControlOriginal.UserNames = null;
            this.textControlOriginal.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(753, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.AutoWorkLayout = false;
            this.btnEdit.IsStandardControl = false;
            this.btnEdit.Location = new System.Drawing.Point(827, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 32);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Editieren";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoWorkLayout = false;
            this.btnClose.IsStandardControl = false;
            this.btnClose.Location = new System.Drawing.Point(1143, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Schließen";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelText);
            this.panelAll.Controls.Add(this.panelZusatz);
            this.panelAll.Controls.Add(this.panelTop);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1222, 671);
            this.panelAll.TabIndex = 1;
            // 
            // panelText
            // 
            this.panelText.BackColor = System.Drawing.Color.Transparent;
            this.panelText.Controls.Add(this.lblHistorie);
            this.panelText.Controls.Add(this.textControlHistorie);
            this.panelText.Controls.Add(this.PanelTxtEditorEdit);
            this.panelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelText.Location = new System.Drawing.Point(0, 49);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(816, 622);
            this.panelText.TabIndex = 47;
            // 
            // lblHistorie
            // 
            this.lblHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHistorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistorie.Location = new System.Drawing.Point(5, 304);
            this.lblHistorie.Name = "lblHistorie";
            this.lblHistorie.Size = new System.Drawing.Size(82, 15);
            this.lblHistorie.TabIndex = 42;
            this.lblHistorie.Text = "Historie:";
            // 
            // textControlHistorie
            // 
            this.textControlHistorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControlHistorie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.textControlHistorie.BorderStyle = TXTextControl.BorderStyle.FixedSingle;
            this.textControlHistorie.Font = new System.Drawing.Font("Arial", 10F);
            this.textControlHistorie.Location = new System.Drawing.Point(5, 322);
            this.textControlHistorie.Name = "textControlHistorie";
            this.textControlHistorie.Size = new System.Drawing.Size(806, 296);
            this.textControlHistorie.TabIndex = 41;
            this.textControlHistorie.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.textControlHistorie.UserNames = null;
            this.textControlHistorie.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // PanelTxtEditorEdit
            // 
            this.PanelTxtEditorEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTxtEditorEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTxtEditorEdit.Controls.Add(this.contTXTFieldBeschreibung);
            this.PanelTxtEditorEdit.Location = new System.Drawing.Point(5, 4);
            this.PanelTxtEditorEdit.Name = "PanelTxtEditorEdit";
            this.PanelTxtEditorEdit.Size = new System.Drawing.Size(806, 297);
            this.PanelTxtEditorEdit.TabIndex = 43;
            // 
            // contTXTFieldBeschreibung
            // 
            this.contTXTFieldBeschreibung.bReadOnly = false;
            this.contTXTFieldBeschreibung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contTXTFieldBeschreibung.Location = new System.Drawing.Point(0, 0);
            this.contTXTFieldBeschreibung.Name = "contTXTFieldBeschreibung";
            this.contTXTFieldBeschreibung.Size = new System.Drawing.Size(804, 295);
            this.contTXTFieldBeschreibung.TabIndex = 38;
            // 
            // panelZusatz
            // 
            this.panelZusatz.BackColor = System.Drawing.Color.Transparent;
            this.panelZusatz.Controls.Add(this.lblZusatzwerte);
            this.panelZusatz.Controls.Add(this.ucZusatzWert1);
            this.panelZusatz.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelZusatz.Location = new System.Drawing.Point(816, 49);
            this.panelZusatz.Name = "panelZusatz";
            this.panelZusatz.Size = new System.Drawing.Size(406, 622);
            this.panelZusatz.TabIndex = 46;
            this.panelZusatz.Visible = false;
            // 
            // lblZusatzwerte
            // 
            this.lblZusatzwerte.AutoSize = true;
            this.lblZusatzwerte.Location = new System.Drawing.Point(4, 6);
            this.lblZusatzwerte.Margin = new System.Windows.Forms.Padding(4);
            this.lblZusatzwerte.Name = "lblZusatzwerte";
            this.lblZusatzwerte.Size = new System.Drawing.Size(66, 14);
            this.lblZusatzwerte.TabIndex = 42;
            this.lblZusatzwerte.Text = "Zusatzwerte";
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZusatzWert1.BackColor = System.Drawing.Color.Transparent;
            this.ucZusatzWert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucZusatzWert1.IgnoreNotOptional = false;
            this.ucZusatzWert1.IZusatz = null;
            this.ucZusatzWert1.Location = new System.Drawing.Point(6, 23);
            this.ucZusatzWert1.Margin = new System.Windows.Forms.Padding(5);
            this.ucZusatzWert1.Name = "ucZusatzWert1";
            this.ucZusatzWert1.ReadOnly = false;
            this.ucZusatzWert1.Size = new System.Drawing.Size(395, 592);
            this.ucZusatzWert1.TabIndex = 41;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.txtMassnahme);
            this.panelTop.Controls.Add(this.lalMassnahme);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1222, 49);
            this.panelTop.TabIndex = 45;
            // 
            // txtMassnahme
            // 
            this.txtMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.BackColorDisabled2 = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Black;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtMassnahme.Appearance = appearance4;
            this.txtMassnahme.BackColor = System.Drawing.Color.White;
            this.txtMassnahme.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtMassnahme.Enabled = false;
            this.txtMassnahme.Location = new System.Drawing.Point(52, 5);
            this.txtMassnahme.MaxLength = 255;
            this.txtMassnahme.Multiline = true;
            this.txtMassnahme.Name = "txtMassnahme";
            this.txtMassnahme.Size = new System.Drawing.Size(1165, 39);
            this.txtMassnahme.TabIndex = 40;
            this.txtMassnahme.UseAppStyling = false;
            // 
            // lalMassnahme
            // 
            this.lalMassnahme.AutoSize = true;
            this.lalMassnahme.Location = new System.Drawing.Point(10, 8);
            this.lalMassnahme.Name = "lalMassnahme";
            this.lalMassnahme.Size = new System.Drawing.Size(40, 14);
            this.lalMassnahme.TabIndex = 39;
            this.lalMassnahme.Text = "Eintrag";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // frmPflegeEintragSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1222, 711);
            this.Controls.Add(this.panelAll);
            this.Controls.Add(this.panelButtons);
            this.Name = "frmPflegeEintragSmall";
            this.Text = "Eintrag";
            this.Load += new System.EventHandler(this.frmShowText_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPflegeEintragSmall_VisibleChanged);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveForAllCC)).EndInit();
            this.PanelDekursEntwürfe.ResumeLayout(false);
            this.panelTxtControl.ResumeLayout(false);
            this.panelAll.ResumeLayout(false);
            this.panelText.ResumeLayout(false);
            this.PanelTxtEditorEdit.ResumeLayout(false);
            this.panelZusatz.ResumeLayout(false);
            this.panelZusatz.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassnahme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BasePanel panelAll;
        private QS2.Desktop.ControlManagment.BaseButton btnClose;
        private QS2.Desktop.Txteditor.contTXTField contTXTFieldBeschreibung;
        protected QS2.Desktop.ControlManagment.BaseLabel lalMassnahme;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtMassnahme;
        private QS2.Desktop.ControlManagment.BaseButton btnSave;
        private QS2.Desktop.ControlManagment.BaseButton btnEdit;
        private QS2.Desktop.ControlManagment.BaseButton btnDelete;
        protected System.Windows.Forms.Panel panelTxtControl;
        private TXTextControl.TextControl textControSave;
        private TXTextControl.TextControl textControChanges;
        private TXTextControl.TextControl textControlLineBreak;
        private TXTextControl.TextControl textControlOriginal;
        private TXTextControl.TextControl textControlHistorie;
        private Infragistics.Win.Misc.UltraLabel lblHistorie;
        private System.Windows.Forms.Panel PanelTxtEditorEdit;
        public Infragistics.Win.Misc.UltraDropDownButton uDropDownDekursEntwürfe;
        private QS2.Desktop.ControlManagment.BasePanel PanelDekursEntwürfe;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellenAs;
        public QS2.Desktop.ControlManagment.BaseButton btnDekursEntwurfErstellen;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainerDekursEntwürfe;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSaveForAllCC;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Panel panelZusatz;
        private System.Windows.Forms.Panel panelTop;
        protected QS2.Desktop.ControlManagment.BaseLabel lblZusatzwerte;
        public ucZusatzWert ucZusatzWert1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
    }
}