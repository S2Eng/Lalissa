namespace PMDS.GUI
{
    partial class ucNotfallM
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
            this.pnlTop = new QS2.Desktop.ControlManagment.BasePanel();
            this.pnlTopRight = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblDauer = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblZuletztam = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblZeitpunkt = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblDekurs = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblWichtig = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.auswahlGruppeComboMulti1 = new PMDS.GUI.BaseControls.AuswahlGruppeComboMulti();
            this.lblLast = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.txtBeschreibung = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.txtIstDauer = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.cbImportant = new PMDS.GUI.BaseControls.AuswahlGruppeCombo();
            this.dtpZeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pnlZusatz = new QS2.Desktop.ControlManagment.BasePanel();
            this.ucZusatzWert1 = new PMDS.GUI.ucZusatzWert();
            this.pnlTop2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblWiederAm = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblMedikation = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBedarfsMedikament = new PMDS.GUI.BaseControls.BedarfsMedikamentCombo();
            this.btnTimes = new Infragistics.Win.Misc.UltraDropDownButton();
            this.dtpNaechterZeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.pnlTopLeft = new QS2.Desktop.ControlManagment.BasePanel();
            this.txtM = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.chkDone = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            this.pnlZusatz.SuspendLayout();
            this.pnlTop2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechterZeitpunkt)).BeginInit();
            this.pnlTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlTopRight);
            this.pnlTop.Controls.Add(this.pnlZusatz);
            this.pnlTop.Controls.Add(this.pnlTop2);
            this.pnlTop.Controls.Add(this.pnlTopLeft);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(794, 351);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopRight.Controls.Add(this.lblDauer);
            this.pnlTopRight.Controls.Add(this.lblZuletztam);
            this.pnlTopRight.Controls.Add(this.lblZeitpunkt);
            this.pnlTopRight.Controls.Add(this.lblDekurs);
            this.pnlTopRight.Controls.Add(this.lblWichtig);
            this.pnlTopRight.Controls.Add(this.auswahlGruppeComboMulti1);
            this.pnlTopRight.Controls.Add(this.lblLast);
            this.pnlTopRight.Controls.Add(this.txtBeschreibung);
            this.pnlTopRight.Controls.Add(this.txtIstDauer);
            this.pnlTopRight.Controls.Add(this.cbImportant);
            this.pnlTopRight.Controls.Add(this.dtpZeitpunkt);
            this.pnlTopRight.Location = new System.Drawing.Point(0, 31);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(794, 118);
            this.pnlTopRight.TabIndex = 1;
            // 
            // lblDauer
            // 
            this.lblDauer.AutoSize = true;
            this.lblDauer.Location = new System.Drawing.Point(429, 10);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(36, 13);
            this.lblDauer.TabIndex = 18;
            this.lblDauer.Text = "Dauer";
            // 
            // lblZuletztam
            // 
            this.lblZuletztam.AutoSize = true;
            this.lblZuletztam.Location = new System.Drawing.Point(557, 9);
            this.lblZuletztam.Name = "lblZuletztam";
            this.lblZuletztam.Size = new System.Drawing.Size(54, 13);
            this.lblZuletztam.TabIndex = 17;
            this.lblZuletztam.Text = "zuletzt am";
            // 
            // lblZeitpunkt
            // 
            this.lblZeitpunkt.AutoSize = true;
            this.lblZeitpunkt.Location = new System.Drawing.Point(6, 9);
            this.lblZeitpunkt.Name = "lblZeitpunkt";
            this.lblZeitpunkt.Size = new System.Drawing.Size(52, 13);
            this.lblZeitpunkt.TabIndex = 16;
            this.lblZeitpunkt.Text = "Zeitpunkt";
            // 
            // lblDekurs
            // 
            this.lblDekurs.AutoSize = true;
            this.lblDekurs.Location = new System.Drawing.Point(6, 63);
            this.lblDekurs.Name = "lblDekurs";
            this.lblDekurs.Size = new System.Drawing.Size(41, 13);
            this.lblDekurs.TabIndex = 15;
            this.lblDekurs.Text = "Dekurs";
            // 
            // lblWichtig
            // 
            this.lblWichtig.AutoSize = true;
            this.lblWichtig.Location = new System.Drawing.Point(6, 34);
            this.lblWichtig.Name = "lblWichtig";
            this.lblWichtig.Size = new System.Drawing.Size(61, 13);
            this.lblWichtig.TabIndex = 9;
            this.lblWichtig.Text = "Wichtig für ";
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.auswahlGruppeComboMulti1.BackColor = System.Drawing.Color.Transparent;
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(89, 33);
            this.auswahlGruppeComboMulti1.Margin = new System.Windows.Forms.Padding(4);
            this.auswahlGruppeComboMulti1.Name = "auswahlGruppeComboMulti1";
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(698, 28);
            this.auswahlGruppeComboMulti1.TabIndex = 8;
            this.auswahlGruppeComboMulti1.TypeMulti = PMDS.GUI.BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe;
            this.auswahlGruppeComboMulti1.AfterCheck2 += new System.EventHandler(this.auswahlGruppeComboMulti1_AfterCheck);
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Location = new System.Drawing.Point(629, 9);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(57, 13);
            this.lblLast.TabIndex = 7;
            this.lblLast.Text = "** letzter **";
            // 
            // txtBeschreibung
            // 
            this.txtBeschreibung.AcceptsReturn = true;
            this.txtBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeschreibung.Enabled = false;
            this.txtBeschreibung.Location = new System.Drawing.Point(89, 61);
            this.txtBeschreibung.MaxLength = 2048;
            this.txtBeschreibung.Multiline = true;
            this.txtBeschreibung.Name = "txtBeschreibung";
            this.txtBeschreibung.Size = new System.Drawing.Size(698, 52);
            this.txtBeschreibung.TabIndex = 6;
            // 
            // txtIstDauer
            // 
            this.txtIstDauer.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtIstDauer.InputMask = "999";
            this.txtIstDauer.Location = new System.Drawing.Point(487, 7);
            this.txtIstDauer.Name = "txtIstDauer";
            this.txtIstDauer.NonAutoSizeHeight = 20;
            this.txtIstDauer.Size = new System.Drawing.Size(40, 20);
            this.txtIstDauer.TabIndex = 4;
            // 
            // cbImportant
            // 
            this.cbImportant.AddEmptyEntry = false;
            this.cbImportant.BerufsstandGruppeJNA = -1;
            this.cbImportant.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbImportant.Group = "BER";
            this.cbImportant.Location = new System.Drawing.Point(212, 6);
            this.cbImportant.Name = "cbImportant";
            this.cbImportant.ShowAddButton = true;
            this.cbImportant.Size = new System.Drawing.Size(124, 21);
            this.cbImportant.TabIndex = 3;
            this.cbImportant.Visible = false;
            // 
            // dtpZeitpunkt
            // 
            this.dtpZeitpunkt.FormatString = "";
            this.dtpZeitpunkt.Location = new System.Drawing.Point(89, 6);
            this.dtpZeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpZeitpunkt.Name = "dtpZeitpunkt";
            this.dtpZeitpunkt.Size = new System.Drawing.Size(108, 21);
            this.dtpZeitpunkt.TabIndex = 1;
            // 
            // pnlZusatz
            // 
            this.pnlZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlZusatz.Controls.Add(this.ucZusatzWert1);
            this.pnlZusatz.Location = new System.Drawing.Point(3, 183);
            this.pnlZusatz.Name = "pnlZusatz";
            this.pnlZusatz.Size = new System.Drawing.Size(790, 167);
            this.pnlZusatz.TabIndex = 3;
            this.pnlZusatz.VisibleChanged += new System.EventHandler(this.pnlZusatz_VisibleChanged);
            this.pnlZusatz.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlZusatz_Paint);
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ucZusatzWert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ucZusatzWert1.IgnoreNotOptional = false;
            this.ucZusatzWert1.IZusatz = null;
            this.ucZusatzWert1.Location = new System.Drawing.Point(0, 0);
            this.ucZusatzWert1.Margin = new System.Windows.Forms.Padding(4);
            this.ucZusatzWert1.Name = "ucZusatzWert1";
            this.ucZusatzWert1.ReadOnly = false;
            this.ucZusatzWert1.Size = new System.Drawing.Size(355, 167);
            this.ucZusatzWert1.TabIndex = 0;
            // 
            // pnlTop2
            // 
            this.pnlTop2.Controls.Add(this.lblWiederAm);
            this.pnlTop2.Controls.Add(this.lblMedikation);
            this.pnlTop2.Controls.Add(this.cbBedarfsMedikament);
            this.pnlTop2.Controls.Add(this.btnTimes);
            this.pnlTop2.Controls.Add(this.dtpNaechterZeitpunkt);
            this.pnlTop2.Location = new System.Drawing.Point(0, 150);
            this.pnlTop2.Name = "pnlTop2";
            this.pnlTop2.Size = new System.Drawing.Size(794, 32);
            this.pnlTop2.TabIndex = 2;
            // 
            // lblWiederAm
            // 
            this.lblWiederAm.AutoSize = true;
            this.lblWiederAm.Location = new System.Drawing.Point(6, 11);
            this.lblWiederAm.Name = "lblWiederAm";
            this.lblWiederAm.Size = new System.Drawing.Size(77, 13);
            this.lblWiederAm.TabIndex = 17;
            this.lblWiederAm.Text = "Wieder am/um";
            // 
            // lblMedikation
            // 
            this.lblMedikation.AutoSize = true;
            this.lblMedikation.Location = new System.Drawing.Point(292, 11);
            this.lblMedikation.Name = "lblMedikation";
            this.lblMedikation.Size = new System.Drawing.Size(66, 14);
            this.lblMedikation.TabIndex = 36;
            this.lblMedikation.Text = "Medikament";
            this.lblMedikation.Visible = false;
            // 
            // cbBedarfsMedikament
            // 
            this.cbBedarfsMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBedarfsMedikament.Location = new System.Drawing.Point(364, 7);
            this.cbBedarfsMedikament.Name = "cbBedarfsMedikament";
            this.cbBedarfsMedikament.Size = new System.Drawing.Size(423, 21);
            this.cbBedarfsMedikament.TabIndex = 35;
            this.cbBedarfsMedikament.Visible = false;
            // 
            // btnTimes
            // 
            this.btnTimes.Location = new System.Drawing.Point(212, 3);
            this.btnTimes.Name = "btnTimes";
            this.btnTimes.ShowFocusRect = false;
            this.btnTimes.Size = new System.Drawing.Size(21, 20);
            this.btnTimes.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnTimes.TabIndex = 9;
            this.btnTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTimes_MouseUp);
            // 
            // dtpNaechterZeitpunkt
            // 
            this.dtpNaechterZeitpunkt.FormatString = "";
            this.dtpNaechterZeitpunkt.Location = new System.Drawing.Point(89, 4);
            this.dtpNaechterZeitpunkt.MaskInput = "dd.mm.yyyy hh:mm";
            this.dtpNaechterZeitpunkt.Name = "dtpNaechterZeitpunkt";
            this.dtpNaechterZeitpunkt.NullText = "nächster Zeitpunkt";
            this.dtpNaechterZeitpunkt.Size = new System.Drawing.Size(117, 21);
            this.dtpNaechterZeitpunkt.TabIndex = 8;
            this.dtpNaechterZeitpunkt.Value = null;
            this.dtpNaechterZeitpunkt.ValueChanged += new System.EventHandler(this.dtpNaechterZeitpunkt_ValueChanged);
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopLeft.Controls.Add(this.txtM);
            this.pnlTopLeft.Controls.Add(this.chkDone);
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(794, 30);
            this.pnlTopLeft.TabIndex = 0;
            // 
            // txtM
            // 
            this.txtM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtM.Appearance = appearance1;
            this.txtM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtM.Location = new System.Drawing.Point(27, 3);
            this.txtM.MaxLength = 2048;
            this.txtM.Name = "txtM";
            this.txtM.ReadOnly = true;
            this.txtM.Size = new System.Drawing.Size(760, 21);
            this.txtM.TabIndex = 7;
            this.txtM.TabStop = false;
            // 
            // chkDone
            // 
            this.chkDone.Location = new System.Drawing.Point(3, 5);
            this.chkDone.Name = "chkDone";
            this.chkDone.Size = new System.Drawing.Size(18, 20);
            this.chkDone.TabIndex = 2;
            this.chkDone.CheckedChanged += new System.EventHandler(this.chkDone_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucNotfallM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlTop);
            this.Name = "ucNotfallM";
            this.Size = new System.Drawing.Size(794, 351);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.pnlTopRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            this.pnlZusatz.ResumeLayout(false);
            this.pnlTop2.ResumeLayout(false);
            this.pnlTop2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNaechterZeitpunkt)).EndInit();
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlTop;
        private QS2.Desktop.ControlManagment.BasePanel pnlZusatz;
        private QS2.Desktop.ControlManagment.BasePanel pnlTopRight;
        private QS2.Desktop.ControlManagment.BasePanel pnlTopLeft;
        private ucZusatzWert ucZusatzWert1;
        protected PMDS.GUI.BaseControls.AuswahlGruppeCombo cbImportant;
        private QS2.Desktop.ControlManagment.BaseTextEditor txtM;
        private QS2.Desktop.ControlManagment.BaseLableWin lblLast;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.Misc.UltraDropDownButton btnTimes;
        private QS2.Desktop.ControlManagment.BasePanel pnlTop2;
        protected PMDS.GUI.BaseControls.BedarfsMedikamentCombo cbBedarfsMedikament;
        private System.Windows.Forms.ToolTip toolTip1;
        public BaseControls.AuswahlGruppeComboMulti auswahlGruppeComboMulti1;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpZeitpunkt;
        protected QS2.Desktop.ControlManagment.BaseMaskEdit txtIstDauer;
        protected QS2.Desktop.ControlManagment.BaseTextEditor txtBeschreibung;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkDone;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpNaechterZeitpunkt;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMedikation;
        private QS2.Desktop.ControlManagment.BaseLableWin lblWichtig;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDekurs;
        private QS2.Desktop.ControlManagment.BaseLableWin lblZeitpunkt;
        private QS2.Desktop.ControlManagment.BaseLableWin lblWiederAm;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDauer;
        private QS2.Desktop.ControlManagment.BaseLableWin lblZuletztam;
    }
}
