namespace PMDS.GUI.GUI.Main
{
    partial class ucUrlaub2
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.labEnde = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpEnde = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.txtUrlaub = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.labBeginn = new QS2.Desktop.ControlManagment.BaseLabel();
            this.labUrlaub = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpBeginn = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.labInfo = new QS2.Desktop.ControlManagment.BaseLabel();
            this.auswahlSTAMP_Awesenheitsgrund = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.pnlSTAMP = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblAbwesenheitsgrund = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlBeschreibung = new QS2.Desktop.ControlManagment.BasePanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlSTAMP_Awesenheitsgrund)).BeginInit();
            this.pnlSTAMP.SuspendLayout();
            this.pnlBeschreibung.SuspendLayout();
            this.SuspendLayout();
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(16, 108);
            this.labEnde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(36, 17);
            this.labEnde.TabIndex = 8;
            this.labEnde.Text = "Ende";
            // 
            // dtpEnde
            // 
            this.dtpEnde.FormatString = "";
            this.dtpEnde.Location = new System.Drawing.Point(180, 106);
            this.dtpEnde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEnde.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.ownFormat = "";
            this.dtpEnde.ownMaskInput = "";
            this.dtpEnde.Size = new System.Drawing.Size(171, 24);
            this.dtpEnde.TabIndex = 9;
            // 
            // txtUrlaub
            // 
            this.txtUrlaub.AddEmptyEntry = false;
            this.txtUrlaub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlaub.AutoOpenCBO = false;
            this.txtUrlaub.BerufsstandGruppeJNA = -1;
            this.txtUrlaub.ExactMatch = false;
            this.txtUrlaub.Group = "URL";
            this.txtUrlaub.ID_PEP = -1;
            this.txtUrlaub.IgnoreUnterdruecken = true;
            this.txtUrlaub.Location = new System.Drawing.Point(164, 5);
            this.txtUrlaub.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrlaub.Name = "txtUrlaub";
            this.txtUrlaub.PflichtJN = false;
            this.txtUrlaub.SelectDistinct = false;
            this.txtUrlaub.ShowAddButton = true;
            this.txtUrlaub.Size = new System.Drawing.Size(456, 24);
            this.txtUrlaub.sys = false;
            this.txtUrlaub.TabIndex = 11;
            // 
            // labBeginn
            // 
            this.labBeginn.AutoSize = true;
            this.labBeginn.Location = new System.Drawing.Point(16, 75);
            this.labBeginn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labBeginn.Name = "labBeginn";
            this.labBeginn.Size = new System.Drawing.Size(47, 17);
            this.labBeginn.TabIndex = 6;
            this.labBeginn.Text = "Beginn";
            // 
            // labUrlaub
            // 
            this.labUrlaub.AutoSize = true;
            this.labUrlaub.Location = new System.Drawing.Point(0, 7);
            this.labUrlaub.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labUrlaub.Name = "labUrlaub";
            this.labUrlaub.Size = new System.Drawing.Size(87, 17);
            this.labUrlaub.TabIndex = 10;
            this.labUrlaub.Text = "Beschreibung";
            // 
            // dtpBeginn
            // 
            this.dtpBeginn.FormatString = "";
            this.dtpBeginn.Location = new System.Drawing.Point(180, 73);
            this.dtpBeginn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpBeginn.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpBeginn.Name = "dtpBeginn";
            this.dtpBeginn.ownFormat = "";
            this.dtpBeginn.ownMaskInput = "";
            this.dtpBeginn.Size = new System.Drawing.Size(171, 24);
            this.dtpBeginn.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance6;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(545, 258);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 39);
            this.btnSave.TabIndex = 13;
            this.btnSave.Tag = "";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance5;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(427, 258);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(117, 39);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // labInfo
            // 
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance3;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(663, 59);
            this.labInfo.TabIndex = 14;
            this.labInfo.Text = "Abwesenheit von {0}";
            // 
            // auswahlSTAMP_Awesenheitsgrund
            // 
            this.auswahlSTAMP_Awesenheitsgrund.AddEmptyEntry = false;
            this.auswahlSTAMP_Awesenheitsgrund.AutoOpenCBO = false;
            this.auswahlSTAMP_Awesenheitsgrund.BerufsstandGruppeJNA = -1;
            this.auswahlSTAMP_Awesenheitsgrund.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.auswahlSTAMP_Awesenheitsgrund.ExactMatch = true;
            this.auswahlSTAMP_Awesenheitsgrund.Group = "SAG";
            this.auswahlSTAMP_Awesenheitsgrund.ID_PEP = -1;
            this.auswahlSTAMP_Awesenheitsgrund.IgnoreUnterdruecken = true;
            this.auswahlSTAMP_Awesenheitsgrund.Location = new System.Drawing.Point(164, 4);
            this.auswahlSTAMP_Awesenheitsgrund.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.auswahlSTAMP_Awesenheitsgrund.Name = "auswahlSTAMP_Awesenheitsgrund";
            this.auswahlSTAMP_Awesenheitsgrund.PflichtJN = false;
            this.auswahlSTAMP_Awesenheitsgrund.SelectDistinct = false;
            this.auswahlSTAMP_Awesenheitsgrund.ShowAddButton = false;
            this.auswahlSTAMP_Awesenheitsgrund.Size = new System.Drawing.Size(456, 24);
            this.auswahlSTAMP_Awesenheitsgrund.sys = true;
            this.auswahlSTAMP_Awesenheitsgrund.TabIndex = 15;
            this.auswahlSTAMP_Awesenheitsgrund.ValueChanged += new System.EventHandler(this.auswahlSTAMP_Awesenheitsgrund_ValueChanged);
            // 
            // pnlSTAMP
            // 
            this.pnlSTAMP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSTAMP.Controls.Add(this.lblAbwesenheitsgrund);
            this.pnlSTAMP.Controls.Add(this.auswahlSTAMP_Awesenheitsgrund);
            this.pnlSTAMP.Location = new System.Drawing.Point(16, 196);
            this.pnlSTAMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSTAMP.Name = "pnlSTAMP";
            this.pnlSTAMP.Size = new System.Drawing.Size(639, 36);
            this.pnlSTAMP.TabIndex = 16;
            // 
            // lblAbwesenheitsgrund
            // 
            this.lblAbwesenheitsgrund.AutoSize = true;
            this.lblAbwesenheitsgrund.Location = new System.Drawing.Point(0, 9);
            this.lblAbwesenheitsgrund.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblAbwesenheitsgrund.Name = "lblAbwesenheitsgrund";
            this.lblAbwesenheitsgrund.Size = new System.Drawing.Size(101, 17);
            this.lblAbwesenheitsgrund.TabIndex = 17;
            this.lblAbwesenheitsgrund.Text = "Grund (STAMP)";
            // 
            // pnlBeschreibung
            // 
            this.pnlBeschreibung.Controls.Add(this.txtUrlaub);
            this.pnlBeschreibung.Controls.Add(this.labUrlaub);
            this.pnlBeschreibung.Location = new System.Drawing.Point(16, 151);
            this.pnlBeschreibung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBeschreibung.Name = "pnlBeschreibung";
            this.pnlBeschreibung.Size = new System.Drawing.Size(639, 38);
            this.pnlBeschreibung.TabIndex = 17;
            // 
            // ucUrlaub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBeschreibung);
            this.Controls.Add(this.pnlSTAMP);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.labBeginn);
            this.Controls.Add(this.dtpBeginn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucUrlaub2";
            this.Size = new System.Drawing.Size(663, 320);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlSTAMP_Awesenheitsgrund)).EndInit();
            this.pnlSTAMP.ResumeLayout(false);
            this.pnlSTAMP.PerformLayout();
            this.pnlBeschreibung.ResumeLayout(false);
            this.pnlBeschreibung.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel labEnde;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpEnde;
        public BaseControls.AuswahlGruppeCombo txtUrlaub;
        private QS2.Desktop.ControlManagment.BaseLabel labBeginn;
        private QS2.Desktop.ControlManagment.BaseLabel labUrlaub;
        public QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpBeginn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public QS2.Desktop.ControlManagment.BaseButton btnSave;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        private QS2.Desktop.ControlManagment.BaseLabel labInfo;
        public BaseControls.AuswahlGruppeCombo auswahlSTAMP_Awesenheitsgrund;
        private QS2.Desktop.ControlManagment.BasePanel pnlSTAMP;
        private QS2.Desktop.ControlManagment.BaseLabel lblAbwesenheitsgrund;
        private QS2.Desktop.ControlManagment.BasePanel pnlBeschreibung;
    }
}
