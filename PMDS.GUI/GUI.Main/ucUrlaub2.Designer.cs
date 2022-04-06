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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlSTAMP_Awesenheitsgrund)).BeginInit();
            this.pnlSTAMP.SuspendLayout();
            this.SuspendLayout();
            // 
            // labEnde
            // 
            this.labEnde.AutoSize = true;
            this.labEnde.Location = new System.Drawing.Point(12, 92);
            this.labEnde.Name = "labEnde";
            this.labEnde.Size = new System.Drawing.Size(31, 14);
            this.labEnde.TabIndex = 8;
            this.labEnde.Text = "Ende";
            // 
            // dtpEnde
            // 
            this.dtpEnde.FormatString = "";
            this.dtpEnde.Location = new System.Drawing.Point(135, 90);
            this.dtpEnde.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.ownFormat = "";
            this.dtpEnde.ownMaskInput = "";
            this.dtpEnde.Size = new System.Drawing.Size(128, 21);
            this.dtpEnde.TabIndex = 9;
            // 
            // txtUrlaub
            // 
            this.txtUrlaub.AddEmptyEntry = false;
            this.txtUrlaub.AutoOpenCBO = false;
            this.txtUrlaub.BerufsstandGruppeJNA = -1;
            this.txtUrlaub.ExactMatch = false;
            this.txtUrlaub.Group = "URL";
            this.txtUrlaub.ID_PEP = -1;
            this.txtUrlaub.IgnoreUnterdruecken = true;
            this.txtUrlaub.Location = new System.Drawing.Point(135, 114);
            this.txtUrlaub.Name = "txtUrlaub";
            this.txtUrlaub.PflichtJN = false;
            this.txtUrlaub.SelectDistinct = false;
            this.txtUrlaub.ShowAddButton = true;
            this.txtUrlaub.Size = new System.Drawing.Size(342, 21);
            this.txtUrlaub.sys = false;
            this.txtUrlaub.TabIndex = 11;
            // 
            // labBeginn
            // 
            this.labBeginn.AutoSize = true;
            this.labBeginn.Location = new System.Drawing.Point(12, 68);
            this.labBeginn.Name = "labBeginn";
            this.labBeginn.Size = new System.Drawing.Size(40, 14);
            this.labBeginn.TabIndex = 6;
            this.labBeginn.Text = "Beginn";
            // 
            // labUrlaub
            // 
            this.labUrlaub.AutoSize = true;
            this.labUrlaub.Location = new System.Drawing.Point(12, 116);
            this.labUrlaub.Name = "labUrlaub";
            this.labUrlaub.Size = new System.Drawing.Size(74, 14);
            this.labUrlaub.TabIndex = 10;
            this.labUrlaub.Text = "Beschreibung";
            // 
            // dtpBeginn
            // 
            this.dtpBeginn.FormatString = "";
            this.dtpBeginn.Location = new System.Drawing.Point(135, 66);
            this.dtpBeginn.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpBeginn.Name = "dtpBeginn";
            this.dtpBeginn.ownFormat = "";
            this.dtpBeginn.ownMaskInput = "";
            this.dtpBeginn.Size = new System.Drawing.Size(128, 21);
            this.dtpBeginn.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance2;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.IsStandardControl = false;
            this.btnSave.Location = new System.Drawing.Point(409, 169);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 32);
            this.btnSave.TabIndex = 13;
            this.btnSave.Tag = "";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance3;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(320, 169);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(88, 32);
            this.btnAbort.TabIndex = 12;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // labInfo
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.labInfo.Appearance = appearance1;
            this.labInfo.BackColorInternal = System.Drawing.SystemColors.ControlDark;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(497, 48);
            this.labInfo.TabIndex = 14;
            this.labInfo.Text = "Abwesenheit von {0}";
            // 
            // auswahlSTAMP_Awesenheitsgrund
            // 
            this.auswahlSTAMP_Awesenheitsgrund.AddEmptyEntry = false;
            this.auswahlSTAMP_Awesenheitsgrund.AutoOpenCBO = false;
            this.auswahlSTAMP_Awesenheitsgrund.BerufsstandGruppeJNA = -1;
            this.auswahlSTAMP_Awesenheitsgrund.ExactMatch = false;
            this.auswahlSTAMP_Awesenheitsgrund.Group = "SAG";
            this.auswahlSTAMP_Awesenheitsgrund.ID_PEP = -1;
            this.auswahlSTAMP_Awesenheitsgrund.IgnoreUnterdruecken = true;
            this.auswahlSTAMP_Awesenheitsgrund.Location = new System.Drawing.Point(123, 1);
            this.auswahlSTAMP_Awesenheitsgrund.Name = "auswahlSTAMP_Awesenheitsgrund";
            this.auswahlSTAMP_Awesenheitsgrund.PflichtJN = false;
            this.auswahlSTAMP_Awesenheitsgrund.SelectDistinct = false;
            this.auswahlSTAMP_Awesenheitsgrund.ShowAddButton = true;
            this.auswahlSTAMP_Awesenheitsgrund.Size = new System.Drawing.Size(342, 21);
            this.auswahlSTAMP_Awesenheitsgrund.sys = false;
            this.auswahlSTAMP_Awesenheitsgrund.TabIndex = 15;
            this.auswahlSTAMP_Awesenheitsgrund.ValueChanged += new System.EventHandler(this.auswahlSTAMP_Awesenheitsgrund_ValueChanged);
            // 
            // pnlSTAMP
            // 
            this.pnlSTAMP.Controls.Add(this.lblAbwesenheitsgrund);
            this.pnlSTAMP.Controls.Add(this.auswahlSTAMP_Awesenheitsgrund);
            this.pnlSTAMP.Location = new System.Drawing.Point(12, 140);
            this.pnlSTAMP.Name = "pnlSTAMP";
            this.pnlSTAMP.Size = new System.Drawing.Size(479, 24);
            this.pnlSTAMP.TabIndex = 16;
            // 
            // lblAbwesenheitsgrund
            // 
            this.lblAbwesenheitsgrund.AutoSize = true;
            this.lblAbwesenheitsgrund.Location = new System.Drawing.Point(0, 5);
            this.lblAbwesenheitsgrund.Name = "lblAbwesenheitsgrund";
            this.lblAbwesenheitsgrund.Size = new System.Drawing.Size(85, 14);
            this.lblAbwesenheitsgrund.TabIndex = 17;
            this.lblAbwesenheitsgrund.Text = "Grund (STAMP)";
            // 
            // ucUrlaub2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSTAMP);
            this.Controls.Add(this.labInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.labEnde);
            this.Controls.Add(this.dtpEnde);
            this.Controls.Add(this.txtUrlaub);
            this.Controls.Add(this.labBeginn);
            this.Controls.Add(this.labUrlaub);
            this.Controls.Add(this.dtpBeginn);
            this.Name = "ucUrlaub2";
            this.Size = new System.Drawing.Size(497, 215);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrlaub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpBeginn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auswahlSTAMP_Awesenheitsgrund)).EndInit();
            this.pnlSTAMP.ResumeLayout(false);
            this.pnlSTAMP.PerformLayout();
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
    }
}
