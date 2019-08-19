using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    partial class ucMed1Verschreiben
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMed1Verschreiben));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.dsGUIDListe1 = new PMDS.Global.db.Global.dsGUIDListe();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrintMedListe = new QS2.Desktop.ControlManagment.BaseButton();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.dsKlientenListeByMedikament1 = new PMDS.Global.db.Global.dsKlientenListeByMedikament();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.panelBottom = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnTerminErstellen = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelPatientenMitGleichemMedikament = new System.Windows.Forms.Panel();
            this.btnKlientenMitGleichemMedikament = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelInfoRezeptgebührenbefreiungJN = new System.Windows.Forms.Panel();
            this.txtInfoRezeptgebührbefreiung2 = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
            this.panelObenButtonsRechts = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelMitte = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucMed1VerschreibenDetailAll = new PMDS.GUI.ucMed1VerschreibenDetail();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenListeByMedikament1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelOben.SuspendLayout();
            this.panelPatientenMitGleichemMedikament.SuspendLayout();
            this.panelInfoRezeptgebührenbefreiungJN.SuspendLayout();
            this.panelObenButtonsRechts.SuspendLayout();
            this.panelMitte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dsGUIDListe1
            // 
            this.dsGUIDListe1.DataSetName = "dsGUIDListe";
            this.dsGUIDListe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsGUIDListe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnPrintMedListe
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnPrintMedListe.Appearance = appearance2;
            this.btnPrintMedListe.AutoWorkLayout = false;
            this.btnPrintMedListe.IsStandardControl = false;
            this.btnPrintMedListe.Location = new System.Drawing.Point(13, 13);
            this.btnPrintMedListe.Name = "btnPrintMedListe";
            this.btnPrintMedListe.Size = new System.Drawing.Size(194, 35);
            this.btnPrintMedListe.TabIndex = 3;
            this.btnPrintMedListe.Text = "Medikamentenliste drucken";
            this.btnPrintMedListe.Click += new System.EventHandler(this.btnPrintMedBlatt_Click);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // dsKlientenListeByMedikament1
            // 
            this.dsKlientenListeByMedikament1.DataSetName = "dsKlientenListeByMedikament";
            this.dsKlientenListeByMedikament1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUndo
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance5;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(3, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(90, 32);
            this.btnUndo.TabIndex = 6;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Rückgängig";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Undo;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance4;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(94, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnTerminErstellen);
            this.panelBottom.Controls.Add(this.panelButtons);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 566);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1263, 42);
            this.panelBottom.TabIndex = 38;
            // 
            // btnTerminErstellen
            // 
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.btnTerminErstellen.Appearance = appearance3;
            this.btnTerminErstellen.AutoWorkLayout = false;
            this.btnTerminErstellen.IsStandardControl = false;
            this.btnTerminErstellen.Location = new System.Drawing.Point(13, 3);
            this.btnTerminErstellen.Name = "btnTerminErstellen";
            this.btnTerminErstellen.Size = new System.Drawing.Size(113, 32);
            this.btnTerminErstellen.TabIndex = 97;
            this.btnTerminErstellen.Text = "Termin erstellen";
            this.btnTerminErstellen.Click += new System.EventHandler(this.btnTerminErstellen_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnUndo);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(1068, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(195, 42);
            this.panelButtons.TabIndex = 37;
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.panelPatientenMitGleichemMedikament);
            this.panelOben.Controls.Add(this.panelInfoRezeptgebührenbefreiungJN);
            this.panelOben.Controls.Add(this.panelObenButtonsRechts);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(1263, 61);
            this.panelOben.TabIndex = 39;
            // 
            // panelPatientenMitGleichemMedikament
            // 
            this.panelPatientenMitGleichemMedikament.Controls.Add(this.btnKlientenMitGleichemMedikament);
            this.panelPatientenMitGleichemMedikament.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPatientenMitGleichemMedikament.Location = new System.Drawing.Point(349, 0);
            this.panelPatientenMitGleichemMedikament.Name = "panelPatientenMitGleichemMedikament";
            this.panelPatientenMitGleichemMedikament.Size = new System.Drawing.Size(203, 61);
            this.panelPatientenMitGleichemMedikament.TabIndex = 43;
            // 
            // btnKlientenMitGleichemMedikament
            // 
            this.btnKlientenMitGleichemMedikament.AutoWorkLayout = false;
            this.btnKlientenMitGleichemMedikament.IsStandardControl = false;
            this.btnKlientenMitGleichemMedikament.Location = new System.Drawing.Point(5, 13);
            this.btnKlientenMitGleichemMedikament.Name = "btnKlientenMitGleichemMedikament";
            this.btnKlientenMitGleichemMedikament.Size = new System.Drawing.Size(194, 35);
            this.btnKlientenMitGleichemMedikament.TabIndex = 42;
            this.btnKlientenMitGleichemMedikament.Text = "Klienten mit gleichem Medikament ";
            this.btnKlientenMitGleichemMedikament.Click += new System.EventHandler(this.btnKlientenMitGleichemMedikament_Click);
            // 
            // panelInfoRezeptgebührenbefreiungJN
            // 
            this.panelInfoRezeptgebührenbefreiungJN.Controls.Add(this.txtInfoRezeptgebührbefreiung2);
            this.panelInfoRezeptgebührenbefreiungJN.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInfoRezeptgebührenbefreiungJN.Location = new System.Drawing.Point(0, 0);
            this.panelInfoRezeptgebührenbefreiungJN.Name = "panelInfoRezeptgebührenbefreiungJN";
            this.panelInfoRezeptgebührenbefreiungJN.Size = new System.Drawing.Size(349, 61);
            this.panelInfoRezeptgebührenbefreiungJN.TabIndex = 40;
            // 
            // txtInfoRezeptgebührbefreiung2
            // 
            this.txtInfoRezeptgebührbefreiung2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BackColor2 = System.Drawing.Color.Transparent;
            appearance1.BackColorDisabled = System.Drawing.Color.Transparent;
            appearance1.BackColorDisabled2 = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.DarkRed;
            appearance1.ForeColorDisabled = System.Drawing.Color.DarkRed;
            this.txtInfoRezeptgebührbefreiung2.Appearance = appearance1;
            this.txtInfoRezeptgebührbefreiung2.Location = new System.Drawing.Point(4, 8);
            this.txtInfoRezeptgebührbefreiung2.Name = "txtInfoRezeptgebührbefreiung2";
            this.txtInfoRezeptgebührbefreiung2.ReadOnly = true;
            this.txtInfoRezeptgebührbefreiung2.Size = new System.Drawing.Size(341, 51);
            this.txtInfoRezeptgebührbefreiung2.TabIndex = 42;
            this.txtInfoRezeptgebührbefreiung2.Value = "";
            // 
            // panelObenButtonsRechts
            // 
            this.panelObenButtonsRechts.Controls.Add(this.btnPrintMedListe);
            this.panelObenButtonsRechts.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelObenButtonsRechts.Location = new System.Drawing.Point(1042, 0);
            this.panelObenButtonsRechts.Name = "panelObenButtonsRechts";
            this.panelObenButtonsRechts.Size = new System.Drawing.Size(221, 61);
            this.panelObenButtonsRechts.TabIndex = 39;
            // 
            // panelMitte
            // 
            this.panelMitte.Controls.Add(this.ucMed1VerschreibenDetailAll);
            this.panelMitte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMitte.Location = new System.Drawing.Point(0, 61);
            this.panelMitte.Name = "panelMitte";
            this.panelMitte.Size = new System.Drawing.Size(1263, 505);
            this.panelMitte.TabIndex = 40;
            // 
            // ucMed1VerschreibenDetailAll
            // 
            this.ucMed1VerschreibenDetailAll.BackColor = System.Drawing.Color.Transparent;
            this.ucMed1VerschreibenDetailAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMed1VerschreibenDetailAll.Location = new System.Drawing.Point(0, 0);
            this.ucMed1VerschreibenDetailAll.Name = "ucMed1VerschreibenDetailAll";
            this.ucMed1VerschreibenDetailAll.Size = new System.Drawing.Size(1263, 505);
            this.ucMed1VerschreibenDetailAll.TabIndex = 11;
            this.ucMed1VerschreibenDetailAll.ValueChanged += new System.EventHandler(this.OnValueChanged);
            this.ucMed1VerschreibenDetailAll.Click += new System.EventHandler(this.ucMed1VerschreibenDetailAll_Click);
            // 
            // ucMed1Verschreiben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelMitte);
            this.Controls.Add(this.panelOben);
            this.Controls.Add(this.panelBottom);
            this.Name = "ucMed1Verschreiben";
            this.Size = new System.Drawing.Size(1263, 608);
            this.VisibleChanged += new System.EventHandler(this.ucRezeptEdit2_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dsGUIDListe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientenListeByMedikament1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelOben.ResumeLayout(false);
            this.panelPatientenMitGleichemMedikament.ResumeLayout(false);
            this.panelInfoRezeptgebührenbefreiungJN.ResumeLayout(false);
            this.panelObenButtonsRechts.ResumeLayout(false);
            this.panelMitte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsGUIDListe dsGUIDListe1;
        private ucButton btnUndo;
        private ucButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseButton btnPrintMedListe;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private dsKlientenListeByMedikament dsKlientenListeByMedikament1;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private QS2.Desktop.ControlManagment.BasePanel panelMitte;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private QS2.Desktop.ControlManagment.BasePanel panelBottom;
        private QS2.Desktop.ControlManagment.BasePanel panelButtons;
        private QS2.Desktop.ControlManagment.BasePanel panelObenButtonsRechts;
        private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
        public ucMed1VerschreibenDetail ucMed1VerschreibenDetailAll;
        public QS2.Desktop.ControlManagment.BaseButton btnTerminErstellen;
        private System.Windows.Forms.Panel panelInfoRezeptgebührenbefreiungJN;
        private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtInfoRezeptgebührbefreiung2;
        private QS2.Desktop.ControlManagment.BaseButton btnKlientenMitGleichemMedikament;
        private System.Windows.Forms.Panel panelPatientenMitGleichemMedikament;
    }
}
