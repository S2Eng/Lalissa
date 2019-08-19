namespace PMDS.GUI.BaseControls
{
    partial class ucBigRM
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.lblDurchgeführtAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpZeitpunkt = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblWichtigFür = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblDauer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMedikament = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBeschreibung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMassnahme = new QS2.Desktop.ControlManagment.BaseLabel();
            this.pnlZusatz = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblZusatzWerte = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblUhr = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblMinuten = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblUm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraLabel11 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.ucDateSelect1 = new PMDS.GUI.ucDateSelect();
            this.txtBeschreibung = new PMDS.GUI.BaseControls.ucBigTextEditor();
            this.tbDauer = new PMDS.GUI.BaseControls.ucBigNumberSelector();
            this.tbMinuten = new PMDS.GUI.BaseControls.ucBigNumberSelector();
            this.tbStunde = new PMDS.GUI.BaseControls.ucBigNumberSelector();
            this.cbMedikament = new PMDS.GUI.BaseControls.ucBigComboBox();
            this.cbMassnahme = new PMDS.GUI.BaseControls.ucBigComboBox();
            this.cbWichtig = new PMDS.GUI.BaseControls.ucBigComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDurchgeführtAm
            // 
            this.lblDurchgeführtAm.AutoSize = true;
            this.lblDurchgeführtAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurchgeführtAm.Location = new System.Drawing.Point(6, 60);
            this.lblDurchgeführtAm.Name = "lblDurchgeführtAm";
            this.lblDurchgeführtAm.Size = new System.Drawing.Size(120, 46);
            this.lblDurchgeführtAm.TabIndex = 16;
            this.lblDurchgeführtAm.Text = "Durchgeführt\r\nam";
            // 
            // dtpZeitpunkt
            // 
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.dtpZeitpunkt.Appearance = appearance1;
            this.dtpZeitpunkt.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dtpZeitpunkt.ButtonAppearance = appearance2;
            this.dtpZeitpunkt.ButtonStyle = Infragistics.Win.UIElementButtonStyle.PopupBorderless;
            this.dtpZeitpunkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpZeitpunkt.FormatString = "";
            this.dtpZeitpunkt.Location = new System.Drawing.Point(140, 60);
            this.dtpZeitpunkt.MaskInput = "dd.mm.yyyy";
            this.dtpZeitpunkt.Name = "dtpZeitpunkt";
            this.dtpZeitpunkt.Size = new System.Drawing.Size(202, 46);
            this.dtpZeitpunkt.TabIndex = 15;
            this.dtpZeitpunkt.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.dtpZeitpunkt.ValueChanged += new System.EventHandler(this.dtpZeitpunkt_ValueChanged);
            // 
            // lblWichtigFür
            // 
            this.lblWichtigFür.AutoSize = true;
            this.lblWichtigFür.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWichtigFür.Location = new System.Drawing.Point(6, 124);
            this.lblWichtigFür.Name = "lblWichtigFür";
            this.lblWichtigFür.Size = new System.Drawing.Size(99, 24);
            this.lblWichtigFür.TabIndex = 18;
            this.lblWichtigFür.Text = "Wichtig für";
            // 
            // lblDauer
            // 
            this.lblDauer.AutoSize = true;
            this.lblDauer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDauer.Location = new System.Drawing.Point(684, 74);
            this.lblDauer.Name = "lblDauer";
            this.lblDauer.Size = new System.Drawing.Size(60, 24);
            this.lblDauer.TabIndex = 21;
            this.lblDauer.Text = "Dauer";
            // 
            // lblMedikament
            // 
            this.lblMedikament.AutoSize = true;
            this.lblMedikament.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedikament.Location = new System.Drawing.Point(564, 126);
            this.lblMedikament.Name = "lblMedikament";
            this.lblMedikament.Size = new System.Drawing.Size(114, 24);
            this.lblMedikament.TabIndex = 23;
            this.lblMedikament.Text = "Medikament";
            // 
            // lblBeschreibung
            // 
            this.lblBeschreibung.AutoSize = true;
            this.lblBeschreibung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeschreibung.Location = new System.Drawing.Point(7, 171);
            this.lblBeschreibung.Name = "lblBeschreibung";
            this.lblBeschreibung.Size = new System.Drawing.Size(127, 24);
            this.lblBeschreibung.TabIndex = 24;
            this.lblBeschreibung.Text = "Beschreibung";
            // 
            // lblMassnahme
            // 
            this.lblMassnahme.AutoSize = true;
            this.lblMassnahme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassnahme.Location = new System.Drawing.Point(6, 14);
            this.lblMassnahme.Name = "lblMassnahme";
            this.lblMassnahme.Size = new System.Drawing.Size(106, 24);
            this.lblMassnahme.TabIndex = 27;
            this.lblMassnahme.Text = "Maßnahme";
            // 
            // pnlZusatz
            // 
            this.pnlZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlZusatz.AutoScroll = true;
            this.pnlZusatz.Location = new System.Drawing.Point(0, 288);
            this.pnlZusatz.Name = "pnlZusatz";
            this.pnlZusatz.Size = new System.Drawing.Size(966, 317);
            this.pnlZusatz.TabIndex = 28;
            // 
            // lblZusatzWerte
            // 
            this.lblZusatzWerte.AutoSize = true;
            this.lblZusatzWerte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZusatzWerte.Location = new System.Drawing.Point(0, 258);
            this.lblZusatzWerte.Name = "lblZusatzWerte";
            this.lblZusatzWerte.Size = new System.Drawing.Size(113, 24);
            this.lblZusatzWerte.TabIndex = 29;
            this.lblZusatzWerte.Text = "Zusatzwerte";
            // 
            // lblUhr
            // 
            this.lblUhr.AutoSize = true;
            this.lblUhr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUhr.Location = new System.Drawing.Point(507, 76);
            this.lblUhr.Name = "lblUhr";
            this.lblUhr.Size = new System.Drawing.Size(38, 24);
            this.lblUhr.TabIndex = 31;
            this.lblUhr.Text = "Uhr";
            // 
            // lblMinuten
            // 
            this.lblMinuten.AutoSize = true;
            this.lblMinuten.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinuten.Location = new System.Drawing.Point(870, 74);
            this.lblMinuten.Name = "lblMinuten";
            this.lblMinuten.Size = new System.Drawing.Size(77, 24);
            this.lblMinuten.TabIndex = 32;
            this.lblMinuten.Text = "Minuten";
            // 
            // lblUm
            // 
            this.lblUm.AutoSize = true;
            this.lblUm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUm.Location = new System.Drawing.Point(356, 76);
            this.lblUm.Name = "lblUm";
            this.lblUm.Size = new System.Drawing.Size(34, 24);
            this.lblUm.TabIndex = 33;
            this.lblUm.Text = "um";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.AutoSize = true;
            this.ultraLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraLabel11.Location = new System.Drawing.Point(439, 76);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(12, 24);
            this.ultraLabel11.TabIndex = 36;
            this.ultraLabel11.Text = ":";
            // 
            // ultraFlowLayoutManager1
            // 
            this.ultraFlowLayoutManager1.ContainerControl = this.pnlZusatz;
            this.ultraFlowLayoutManager1.HorizontalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
            this.ultraFlowLayoutManager1.HorizontalGap = 20;
            this.ultraFlowLayoutManager1.VerticalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
            // 
            // ucDateSelect1
            // 
            this.ucDateSelect1.Location = new System.Drawing.Point(551, 60);
            this.ucDateSelect1.Name = "ucDateSelect1";
            this.ucDateSelect1.Size = new System.Drawing.Size(49, 48);
            this.ucDateSelect1.TabIndex = 39;
            this.ucDateSelect1.delRefresh += new PMDS.Global.refreshUI(this.ucDateSelect1_delRefresh);
            this.ucDateSelect1.Load += new System.EventHandler(this.ucDateSelect1_Load);
            // 
            // txtBeschreibung
            // 
            this.txtBeschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeschreibung.Location = new System.Drawing.Point(140, 172);
            this.txtBeschreibung.Name = "txtBeschreibung";
            this.txtBeschreibung.Size = new System.Drawing.Size(798, 95);
            this.txtBeschreibung.TabIndex = 38;
            // 
            // tbDauer
            // 
            this.tbDauer.Location = new System.Drawing.Point(762, 60);
            this.tbDauer.Name = "tbDauer";
            this.tbDauer.PromptChar = ' ';
            this.tbDauer.Size = new System.Drawing.Size(102, 48);
            this.tbDauer.TabIndex = 37;
            this.tbDauer.Value = "";
            // 
            // tbMinuten
            // 
            this.tbMinuten.Location = new System.Drawing.Point(449, 60);
            this.tbMinuten.Name = "tbMinuten";
            this.tbMinuten.PromptChar = ' ';
            this.tbMinuten.Size = new System.Drawing.Size(49, 48);
            this.tbMinuten.TabIndex = 35;
            this.tbMinuten.Value = "";
            this.tbMinuten.Load += new System.EventHandler(this.tbMinuten_Load);
            this.tbMinuten.Leave += new System.EventHandler(this.tbMinuten_Leave);
            // 
            // tbStunde
            // 
            this.tbStunde.Location = new System.Drawing.Point(390, 60);
            this.tbStunde.Name = "tbStunde";
            this.tbStunde.PromptChar = ' ';
            this.tbStunde.Size = new System.Drawing.Size(49, 48);
            this.tbStunde.TabIndex = 34;
            this.tbStunde.Value = "";
            this.tbStunde.Leave += new System.EventHandler(this.tbStunde_Leave);
            // 
            // cbMedikament
            // 
            this.cbMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMedikament.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMedikament.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbMedikament.Location = new System.Drawing.Point(684, 114);
            this.cbMedikament.Name = "cbMedikament";
            this.cbMedikament.PlayClickSound = true;
            this.cbMedikament.SelectedItem = null;
            this.cbMedikament.Size = new System.Drawing.Size(254, 51);
            this.cbMedikament.TabIndex = 22;
            this.cbMedikament.AfterCloseUp += new System.EventHandler(this.cbMedikament_AfterCloseUp);
            // 
            // cbMassnahme
            // 
            this.cbMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMassnahme.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbMassnahme.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbMassnahme.Location = new System.Drawing.Point(140, 3);
            this.cbMassnahme.Name = "cbMassnahme";
            this.cbMassnahme.PlayClickSound = true;
            this.cbMassnahme.SelectedItem = null;
            this.cbMassnahme.Size = new System.Drawing.Size(798, 51);
            this.cbMassnahme.TabIndex = 26;
            // 
            // cbWichtig
            // 
            this.cbWichtig.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbWichtig.ID = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cbWichtig.Location = new System.Drawing.Point(140, 114);
            this.cbWichtig.Name = "cbWichtig";
            this.cbWichtig.PlayClickSound = true;
            this.cbWichtig.SelectedItem = null;
            this.cbWichtig.Size = new System.Drawing.Size(358, 51);
            this.cbWichtig.TabIndex = 17;
            this.cbWichtig.Load += new System.EventHandler(this.cbWichtig_Load);
            // 
            // ucBigRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ucDateSelect1);
            this.Controls.Add(this.lblZusatzWerte);
            this.Controls.Add(this.txtBeschreibung);
            this.Controls.Add(this.tbDauer);
            this.Controls.Add(this.tbMinuten);
            this.Controls.Add(this.tbStunde);
            this.Controls.Add(this.lblUm);
            this.Controls.Add(this.lblMinuten);
            this.Controls.Add(this.cbMedikament);
            this.Controls.Add(this.lblMedikament);
            this.Controls.Add(this.lblBeschreibung);
            this.Controls.Add(this.pnlZusatz);
            this.Controls.Add(this.dtpZeitpunkt);
            this.Controls.Add(this.lblDurchgeführtAm);
            this.Controls.Add(this.lblMassnahme);
            this.Controls.Add(this.cbMassnahme);
            this.Controls.Add(this.lblDauer);
            this.Controls.Add(this.lblWichtigFür);
            this.Controls.Add(this.cbWichtig);
            this.Controls.Add(this.lblUhr);
            this.Controls.Add(this.ultraLabel11);
            this.Name = "ucBigRM";
            this.Size = new System.Drawing.Size(969, 608);
            this.Load += new System.EventHandler(this.ucBigRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private ucBigComboBox cbWichtig;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel1;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private ucBigComboBox cbMedikament;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private ucBigComboBox cbMassnahme;
        private QS2.Desktop.ControlManagment.BasePanel pnlZusatz;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel8;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel9;
        protected Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private ucBigNumberSelector tbStunde;
        private ucBigNumberSelector tbMinuten;
        private ucBigNumberSelector tbDauer;
        private ucBigTextEditor txtBeschreibung;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
        private ucDateSelect ucDateSelect1;
        protected QS2.Desktop.ControlManagment.BaseLabel lblDurchgeführtAm;
        protected QS2.Desktop.ControlManagment.BaseLabel lblWichtigFür;
        protected QS2.Desktop.ControlManagment.BaseLabel lblDauer;
        protected QS2.Desktop.ControlManagment.BaseLabel lblBeschreibung;
        protected QS2.Desktop.ControlManagment.BaseLabel lblUhr;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMinuten;
        protected QS2.Desktop.ControlManagment.BaseLabel lblUm;
        protected QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpZeitpunkt;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMedikament;
        protected QS2.Desktop.ControlManagment.BaseLabel lblMassnahme;
        protected QS2.Desktop.ControlManagment.BaseLabel lblZusatzWerte;
        protected QS2.Desktop.ControlManagment.BaseLabel ultraLabel11;
    }
}
