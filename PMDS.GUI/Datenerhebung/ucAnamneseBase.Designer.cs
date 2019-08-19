namespace PMDS.GUI
{
    partial class ucAnamneseBase
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAnamneseBase));
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Drucken der Anamnese", Infragistics.Win.ToolTipImage.Default, "Drucken", Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblBearbeiten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.btnPrint = new PMDS.GUI.ucButton(this.components);
            this.btnDelete = new PMDS.GUI.ucButton(this.components);
            this.btnNew = new PMDS.GUI.ucButton(this.components);
            this.btnUndo = new PMDS.GUI.ucButton(this.components);
            this.btnSave = new PMDS.GUI.ucButton(this.components);
            this.dtpErstelltAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cmbErstelltAm = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.cmbPfleger = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.ultraLabel6 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblErstelltAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.btnCopy = new QS2.Desktop.ControlManagment.BaseButton();
            this.baseButton1 = new QS2.Desktop.ControlManagment.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpErstelltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErstelltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPfleger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBearbeiten
            // 
            this.lblBearbeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBearbeiten.Location = new System.Drawing.Point(7, 506);
            this.lblBearbeiten.Name = "lblBearbeiten";
            this.lblBearbeiten.Size = new System.Drawing.Size(488, 28);
            this.lblBearbeiten.TabIndex = 116;
            this.lblBearbeiten.Text = "Diese Anamnese kann nicht mehr bearbeitet werden weil der Zeitraum von {0} Stunde" +
    "n für die Bearbeitung abgelaufen ist.";
            this.lblBearbeiten.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrint.Appearance = appearance1;
            this.btnPrint.AutoWorkLayout = false;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrint.DoOnClick = true;
            this.btnPrint.Enabled = false;
            this.btnPrint.IsStandardControl = true;
            this.btnPrint.Location = new System.Drawing.Point(736, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(26, 29);
            this.btnPrint.TabIndex = 113;
            this.btnPrint.TabStop = false;
            this.btnPrint.TYPE = PMDS.GUI.ucButton.ButtonType.Print;
            this.btnPrint.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            ultraToolTipInfo1.ToolTipText = "Drucken der Anamnese";
            ultraToolTipInfo1.ToolTipTitle = "Drucken";
            this.ultraToolTipManager1.SetUltraToolTip(this.btnPrint, ultraToolTipInfo1);
            this.btnPrint.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance7.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance7;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.DoOnClick = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageSize = new System.Drawing.Size(12, 12);
            this.btnDelete.IsStandardControl = true;
            this.btnDelete.Location = new System.Drawing.Point(798, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(26, 29);
            this.btnDelete.TabIndex = 112;
            this.btnDelete.TabStop = false;
            this.btnDelete.TYPE = PMDS.GUI.ucButton.ButtonType.Sub;
            this.btnDelete.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.Image = ((object)(resources.GetObject("appearance8.Image")));
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnNew.Appearance = appearance8;
            this.btnNew.AutoWorkLayout = false;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNew.DoOnClick = true;
            this.btnNew.ImageSize = new System.Drawing.Size(12, 12);
            this.btnNew.IsStandardControl = true;
            this.btnNew.Location = new System.Drawing.Point(771, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(26, 29);
            this.btnNew.TabIndex = 111;
            this.btnNew.TabStop = false;
            this.btnNew.TYPE = PMDS.GUI.ucButton.ButtonType.Add;
            this.btnNew.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.Image = ((object)(resources.GetObject("appearance9.Image")));
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnUndo.Appearance = appearance9;
            this.btnUndo.AutoWorkLayout = false;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUndo.DoOnClick = true;
            this.btnUndo.Enabled = false;
            this.btnUndo.IsStandardControl = true;
            this.btnUndo.Location = new System.Drawing.Point(635, 501);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(92, 32);
            this.btnUndo.TabIndex = 114;
            this.btnUndo.TabStop = false;
            this.btnUndo.Text = "Abbrechen";
            this.btnUndo.TYPE = PMDS.GUI.ucButton.ButtonType.Cancel;
            this.btnUndo.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            appearance10.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance10.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnSave.Appearance = appearance10;
            this.btnSave.AutoWorkLayout = false;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DoOnClick = true;
            this.btnSave.Enabled = false;
            this.btnSave.IsStandardControl = true;
            this.btnSave.Location = new System.Drawing.Point(728, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 32);
            this.btnSave.TabIndex = 115;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Speichern";
            this.btnSave.TYPE = PMDS.GUI.ucButton.ButtonType.Save;
            this.btnSave.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpErstelltAm
            // 
            this.dtpErstelltAm.DateTime = new System.DateTime(2006, 12, 14, 0, 0, 0, 0);
            this.dtpErstelltAm.FormatString = "";
            this.dtpErstelltAm.Location = new System.Drawing.Point(160, 2);
            this.dtpErstelltAm.MaskInput = "{date} {time}";
            this.dtpErstelltAm.Name = "dtpErstelltAm";
            this.dtpErstelltAm.ownFormat = "";
            this.dtpErstelltAm.ownMaskInput = "";
            this.dtpErstelltAm.Size = new System.Drawing.Size(126, 21);
            this.dtpErstelltAm.TabIndex = 117;
            this.dtpErstelltAm.Value = new System.DateTime(2006, 12, 14, 0, 0, 0, 0);
            this.dtpErstelltAm.Visible = false;
            // 
            // cmbErstelltAm
            // 
            this.cmbErstelltAm.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbErstelltAm.Location = new System.Drawing.Point(160, 2);
            this.cmbErstelltAm.Name = "cmbErstelltAm";
            this.cmbErstelltAm.Size = new System.Drawing.Size(207, 21);
            this.cmbErstelltAm.TabIndex = 118;
            this.cmbErstelltAm.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbErstelltAm_BeforeDropDown);
            this.cmbErstelltAm.ValueChanged += new System.EventHandler(this.cmbErstelltAm_ValueChanged);
            // 
            // cmbPfleger
            // 
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.cmbPfleger.Appearance = appearance4;
            this.cmbPfleger.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPfleger.Location = new System.Drawing.Point(410, 2);
            this.cmbPfleger.Name = "cmbPfleger";
            this.cmbPfleger.Size = new System.Drawing.Size(228, 21);
            this.cmbPfleger.TabIndex = 119;
            this.cmbPfleger.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ultraLabel6
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.FontData.SizeInPoints = 8F;
            this.ultraLabel6.Appearance = appearance5;
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.Location = new System.Drawing.Point(377, 6);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(27, 14);
            this.ultraLabel6.TabIndex = 121;
            this.ultraLabel6.Text = "Von:";
            // 
            // lblErstelltAm
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.FontData.SizeInPoints = 8F;
            this.lblErstelltAm.Appearance = appearance6;
            this.lblErstelltAm.AutoSize = true;
            this.lblErstelltAm.Location = new System.Drawing.Point(3, 6);
            this.lblErstelltAm.Name = "lblErstelltAm";
            this.lblErstelltAm.Size = new System.Drawing.Size(151, 14);
            this.lblErstelltAm.TabIndex = 120;
            this.lblErstelltAm.Text = "Pflegeanamnese erhoben am:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnCopy.Appearance = appearance3;
            this.btnCopy.AutoWorkLayout = false;
            this.btnCopy.IsStandardControl = false;
            this.btnCopy.Location = new System.Drawing.Point(701, 4);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(26, 29);
            this.btnCopy.TabIndex = 122;
            this.btnCopy.Tag = "15";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // baseButton1
            // 
            this.baseButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.baseButton1.Appearance = appearance2;
            this.baseButton1.AutoWorkLayout = false;
            this.baseButton1.IsStandardControl = false;
            this.baseButton1.Location = new System.Drawing.Point(574, 506);
            this.baseButton1.Margin = new System.Windows.Forms.Padding(4);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(26, 29);
            this.baseButton1.TabIndex = 123;
            this.baseButton1.Tag = "15";
            // 
            // ucAnamneseBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.dtpErstelltAm);
            this.Controls.Add(this.cmbErstelltAm);
            this.Controls.Add(this.cmbPfleger);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.lblErstelltAm);
            this.Controls.Add(this.lblBearbeiten);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Name = "ucAnamneseBase";
            this.Size = new System.Drawing.Size(839, 540);
            ((System.ComponentModel.ISupportInitialize)(this.dtpErstelltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbErstelltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPfleger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private QS2.Desktop.ControlManagment.BaseLabel lblBearbeiten;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel6;
        private QS2.Desktop.ControlManagment.BaseLabel lblErstelltAm;
        protected ucButton btnPrint;
        protected ucButton btnDelete;
        protected ucButton btnNew;
        protected ucButton btnUndo;
        protected ucButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpErstelltAm;
        protected QS2.Desktop.ControlManagment.BaseComboEditor cmbErstelltAm;
        protected QS2.Desktop.ControlManagment.BaseComboEditor cmbPfleger;
        public QS2.Desktop.ControlManagment.BaseButton btnCopy;
        public QS2.Desktop.ControlManagment.BaseButton baseButton1;
    }
}
