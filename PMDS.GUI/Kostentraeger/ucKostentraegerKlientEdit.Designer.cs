namespace PMDS.Calc.UI.Admin
{
    partial class ucKostenträgerKlientEdit
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.dtGueltigAb = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblGültigAb = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblGültigBis = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtGueltigBis = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.cbKtrArt = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblKostenträgerart = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cbBetragErrechnet = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.txtBetrag = new Infragistics.Win.UltraWinEditors.UltraCurrencyEditor();
            this.lblBetrag = new QS2.Desktop.ControlManagment.BaseLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblErfasstAm = new QS2.Desktop.ControlManagment.BaseLabel();
            this.dtpErfasstAm = new QS2.Desktop.ControlManagment.BaseDateTimeEditor();
            this.lblBenutzer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cmbBenutzer = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.panelDatum = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbRechnungJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.cbVorauszahlungJN = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.panelRechnung = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblRechnungstyp = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboRechnungTyp = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.panelKostnträger = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelAuswahlRestzahler = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelAuswahlRechnung = new QS2.Desktop.ControlManagment.BasePanel();
            this.uGridBagLayoutPanelElemente = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblRechnungsdruckTyp = new QS2.Desktop.ControlManagment.BaseLabel();
            this.cboRechnungsdruckTyp = new QS2.Desktop.ControlManagment.BaseComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigAb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKtrArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBetragErrechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpErfasstAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).BeginInit();
            this.panelDatum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRechnungJN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVorauszahlungJN)).BeginInit();
            this.panelRechnung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRechnungTyp)).BeginInit();
            this.panelUnten.SuspendLayout();
            this.panelAuswahlRestzahler.SuspendLayout();
            this.panelAuswahlRechnung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelElemente)).BeginInit();
            this.uGridBagLayoutPanelElemente.SuspendLayout();
            this.panelOben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRechnungsdruckTyp)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGueltigAb
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            this.dtGueltigAb.Appearance = appearance1;
            this.dtGueltigAb.BackColor = System.Drawing.Color.White;
            this.dtGueltigAb.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtGueltigAb.Location = new System.Drawing.Point(67, 6);
            this.dtGueltigAb.Name = "dtGueltigAb";
            this.dtGueltigAb.ownFormat = "";
            this.dtGueltigAb.ownMaskInput = "";
            this.dtGueltigAb.Size = new System.Drawing.Size(96, 21);
            this.dtGueltigAb.TabIndex = 2;
            this.dtGueltigAb.Value = null;
            // 
            // lblGültigAb
            // 
            this.lblGültigAb.AutoSize = true;
            this.lblGültigAb.Location = new System.Drawing.Point(8, 9);
            this.lblGültigAb.Name = "lblGültigAb";
            this.lblGültigAb.Size = new System.Drawing.Size(50, 14);
            this.lblGültigAb.TabIndex = 8;
            this.lblGültigAb.Text = "Gültig ab";
            // 
            // lblGültigBis
            // 
            this.lblGültigBis.AutoSize = true;
            this.lblGültigBis.Location = new System.Drawing.Point(202, 10);
            this.lblGültigBis.Name = "lblGültigBis";
            this.lblGültigBis.Size = new System.Drawing.Size(51, 14);
            this.lblGültigBis.TabIndex = 10;
            this.lblGültigBis.Text = "Gültig bis";
            // 
            // dtGueltigBis
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            this.dtGueltigBis.Appearance = appearance2;
            this.dtGueltigBis.BackColor = System.Drawing.Color.White;
            this.dtGueltigBis.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtGueltigBis.Location = new System.Drawing.Point(259, 6);
            this.dtGueltigBis.Name = "dtGueltigBis";
            this.dtGueltigBis.ownFormat = "";
            this.dtGueltigBis.ownMaskInput = "";
            this.dtGueltigBis.Size = new System.Drawing.Size(96, 21);
            this.dtGueltigBis.TabIndex = 3;
            this.dtGueltigBis.Value = null;
            // 
            // cbKtrArt
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            this.cbKtrArt.Appearance = appearance3;
            this.cbKtrArt.BackColor = System.Drawing.Color.White;
            this.cbKtrArt.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKtrArt.Location = new System.Drawing.Point(96, 62);
            this.cbKtrArt.Name = "cbKtrArt";
            this.cbKtrArt.Size = new System.Drawing.Size(259, 21);
            this.cbKtrArt.TabIndex = 4;
            // 
            // lblKostenträgerart
            // 
            this.lblKostenträgerart.AutoSize = true;
            this.lblKostenträgerart.Location = new System.Drawing.Point(8, 65);
            this.lblKostenträgerart.Name = "lblKostenträgerart";
            this.lblKostenträgerart.Size = new System.Drawing.Size(82, 14);
            this.lblKostenträgerart.TabIndex = 12;
            this.lblKostenträgerart.Text = "Kostenträgerart";
            // 
            // cbBetragErrechnet
            // 
            this.cbBetragErrechnet.Location = new System.Drawing.Point(3, 6);
            this.cbBetragErrechnet.Name = "cbBetragErrechnet";
            this.cbBetragErrechnet.Size = new System.Drawing.Size(105, 20);
            this.cbBetragErrechnet.TabIndex = 7;
            this.cbBetragErrechnet.Text = "Restzahler";
            this.cbBetragErrechnet.CheckedChanged += new System.EventHandler(this.cbBetragErrechnet_CheckedChanged);
            // 
            // txtBetrag
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            this.txtBetrag.Appearance = appearance4;
            this.txtBetrag.BackColor = System.Drawing.Color.White;
            this.txtBetrag.Location = new System.Drawing.Point(132, 3);
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Size = new System.Drawing.Size(96, 21);
            this.txtBetrag.TabIndex = 8;
            // 
            // lblBetrag
            // 
            this.lblBetrag.AutoSize = true;
            this.lblBetrag.Location = new System.Drawing.Point(88, 9);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(38, 14);
            this.lblBetrag.TabIndex = 15;
            this.lblBetrag.Text = "Betrag";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblErfasstAm
            // 
            this.lblErfasstAm.AutoSize = true;
            this.lblErfasstAm.Location = new System.Drawing.Point(8, 33);
            this.lblErfasstAm.Name = "lblErfasstAm";
            this.lblErfasstAm.Size = new System.Drawing.Size(58, 14);
            this.lblErfasstAm.TabIndex = 19;
            this.lblErfasstAm.Text = "Erfasst am";
            // 
            // dtpErfasstAm
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            this.dtpErfasstAm.Appearance = appearance7;
            this.dtpErfasstAm.BackColor = System.Drawing.Color.White;
            this.dtpErfasstAm.DateTime = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpErfasstAm.Location = new System.Drawing.Point(67, 30);
            this.dtpErfasstAm.Name = "dtpErfasstAm";
            this.dtpErfasstAm.ownFormat = "";
            this.dtpErfasstAm.ownMaskInput = "";
            this.dtpErfasstAm.Size = new System.Drawing.Size(96, 21);
            this.dtpErfasstAm.TabIndex = 9;
            this.dtpErfasstAm.Value = null;
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(424, 9);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(50, 14);
            this.lblBenutzer.TabIndex = 21;
            this.lblBenutzer.Text = "Benutzer";
            // 
            // cmbBenutzer
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            this.cmbBenutzer.Appearance = appearance8;
            this.cmbBenutzer.BackColor = System.Drawing.Color.White;
            this.cmbBenutzer.Location = new System.Drawing.Point(480, 6);
            this.cmbBenutzer.Name = "cmbBenutzer";
            this.cmbBenutzer.Size = new System.Drawing.Size(205, 21);
            this.cmbBenutzer.TabIndex = 10;
            // 
            // panelDatum
            // 
            this.panelDatum.Controls.Add(this.lblErfasstAm);
            this.panelDatum.Controls.Add(this.lblGültigAb);
            this.panelDatum.Controls.Add(this.dtpErfasstAm);
            this.panelDatum.Controls.Add(this.dtGueltigAb);
            this.panelDatum.Controls.Add(this.lblBenutzer);
            this.panelDatum.Controls.Add(this.dtGueltigBis);
            this.panelDatum.Controls.Add(this.cmbBenutzer);
            this.panelDatum.Controls.Add(this.lblGültigBis);
            this.panelDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatum.Location = new System.Drawing.Point(0, 0);
            this.panelDatum.Name = "panelDatum";
            this.panelDatum.Size = new System.Drawing.Size(860, 55);
            this.panelDatum.TabIndex = 22;
            // 
            // cbRechnungJN
            // 
            this.cbRechnungJN.Location = new System.Drawing.Point(3, 6);
            this.cbRechnungJN.Name = "cbRechnungJN";
            this.cbRechnungJN.Size = new System.Drawing.Size(80, 20);
            this.cbRechnungJN.TabIndex = 6;
            this.cbRechnungJN.Text = "Rechnung";
            this.cbRechnungJN.CheckedChanged += new System.EventHandler(this.cbRechnungJN_CheckedChanged);
            // 
            // cbVorauszahlungJN
            // 
            this.cbVorauszahlungJN.Location = new System.Drawing.Point(729, 59);
            this.cbVorauszahlungJN.Name = "cbVorauszahlungJN";
            this.cbVorauszahlungJN.Size = new System.Drawing.Size(98, 20);
            this.cbVorauszahlungJN.TabIndex = 5;
            this.cbVorauszahlungJN.Text = "Vorauszahlung";
            // 
            // panelRechnung
            // 
            this.panelRechnung.Controls.Add(this.cboRechnungsdruckTyp);
            this.panelRechnung.Controls.Add(this.lblRechnungsdruckTyp);
            this.panelRechnung.Controls.Add(this.lblRechnungstyp);
            this.panelRechnung.Controls.Add(this.cboRechnungTyp);
            this.panelRechnung.Location = new System.Drawing.Point(102, 0);
            this.panelRechnung.Name = "panelRechnung";
            this.panelRechnung.Size = new System.Drawing.Size(370, 61);
            this.panelRechnung.TabIndex = 47;
            // 
            // lblRechnungstyp
            // 
            this.lblRechnungstyp.AutoSize = true;
            this.lblRechnungstyp.Location = new System.Drawing.Point(2, 6);
            this.lblRechnungstyp.Name = "lblRechnungstyp";
            this.lblRechnungstyp.Size = new System.Drawing.Size(77, 14);
            this.lblRechnungstyp.TabIndex = 45;
            this.lblRechnungstyp.Text = "Rechnungstyp";
            // 
            // cboRechnungTyp
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            this.cboRechnungTyp.Appearance = appearance6;
            this.cboRechnungTyp.BackColor = System.Drawing.Color.White;
            this.cboRechnungTyp.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboRechnungTyp.Location = new System.Drawing.Point(85, 3);
            this.cboRechnungTyp.Name = "cboRechnungTyp";
            this.cboRechnungTyp.Size = new System.Drawing.Size(117, 21);
            this.cboRechnungTyp.TabIndex = 44;
            // 
            // panelKostnträger
            // 
            this.panelKostnträger.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelKostnträger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKostnträger.Location = new System.Drawing.Point(0, 0);
            this.panelKostnträger.Name = "panelKostnträger";
            this.panelKostnträger.Size = new System.Drawing.Size(872, 294);
            this.panelKostnträger.TabIndex = 0;
            // 
            // panelUnten
            // 
            this.panelUnten.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelUnten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnten.Controls.Add(this.panelAuswahlRestzahler);
            this.panelUnten.Controls.Add(this.panelAuswahlRechnung);
            this.panelUnten.Controls.Add(this.cbVorauszahlungJN);
            this.panelUnten.Controls.Add(this.panelDatum);
            this.panelUnten.Controls.Add(this.cbKtrArt);
            this.panelUnten.Controls.Add(this.lblKostenträgerart);
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint1.Insets.Bottom = 5;
            gridBagConstraint1.Insets.Left = 5;
            gridBagConstraint1.Insets.Right = 5;
            gridBagConstraint1.Insets.Top = 5;
            gridBagConstraint1.OriginX = 0;
            gridBagConstraint1.OriginY = 0;
            this.uGridBagLayoutPanelElemente.SetGridBagConstraint(this.panelUnten, gridBagConstraint1);
            this.panelUnten.Location = new System.Drawing.Point(5, 5);
            this.panelUnten.Name = "panelUnten";
            this.uGridBagLayoutPanelElemente.SetPreferredSize(this.panelUnten, new System.Drawing.Size(872, 95));
            this.panelUnten.Size = new System.Drawing.Size(862, 158);
            this.panelUnten.TabIndex = 48;
            // 
            // panelAuswahlRestzahler
            // 
            this.panelAuswahlRestzahler.Controls.Add(this.txtBetrag);
            this.panelAuswahlRestzahler.Controls.Add(this.lblBetrag);
            this.panelAuswahlRestzahler.Controls.Add(this.cbBetragErrechnet);
            this.panelAuswahlRestzahler.Location = new System.Drawing.Point(8, 90);
            this.panelAuswahlRestzahler.Name = "panelAuswahlRestzahler";
            this.panelAuswahlRestzahler.Size = new System.Drawing.Size(286, 63);
            this.panelAuswahlRestzahler.TabIndex = 49;
            // 
            // panelAuswahlRechnung
            // 
            this.panelAuswahlRechnung.Controls.Add(this.cbRechnungJN);
            this.panelAuswahlRechnung.Controls.Add(this.panelRechnung);
            this.panelAuswahlRechnung.Location = new System.Drawing.Point(361, 90);
            this.panelAuswahlRechnung.Name = "panelAuswahlRechnung";
            this.panelAuswahlRechnung.Size = new System.Drawing.Size(496, 61);
            this.panelAuswahlRechnung.TabIndex = 48;
            // 
            // uGridBagLayoutPanelElemente
            // 
            this.uGridBagLayoutPanelElemente.Controls.Add(this.panelUnten);
            this.uGridBagLayoutPanelElemente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uGridBagLayoutPanelElemente.ExpandToFitHeight = true;
            this.uGridBagLayoutPanelElemente.ExpandToFitWidth = true;
            this.uGridBagLayoutPanelElemente.Location = new System.Drawing.Point(0, 294);
            this.uGridBagLayoutPanelElemente.Name = "uGridBagLayoutPanelElemente";
            this.uGridBagLayoutPanelElemente.Size = new System.Drawing.Size(872, 168);
            this.uGridBagLayoutPanelElemente.TabIndex = 50;
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.panelKostnträger);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(872, 294);
            this.panelOben.TabIndex = 51;
            // 
            // lblRechnungsdruckTyp
            // 
            this.lblRechnungsdruckTyp.AutoSize = true;
            this.lblRechnungsdruckTyp.Location = new System.Drawing.Point(3, 30);
            this.lblRechnungsdruckTyp.Name = "lblRechnungsdruckTyp";
            this.lblRechnungsdruckTyp.Size = new System.Drawing.Size(75, 14);
            this.lblRechnungsdruckTyp.TabIndex = 46;
            this.lblRechnungsdruckTyp.Text = "Re-Druck-Typ";
            // 
            // cboRechnungsdruckTyp
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            this.cboRechnungsdruckTyp.Appearance = appearance5;
            this.cboRechnungsdruckTyp.BackColor = System.Drawing.Color.White;
            this.cboRechnungsdruckTyp.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboRechnungsdruckTyp.Location = new System.Drawing.Point(84, 28);
            this.cboRechnungsdruckTyp.Name = "cboRechnungsdruckTyp";
            this.cboRechnungsdruckTyp.Size = new System.Drawing.Size(283, 21);
            this.cboRechnungsdruckTyp.TabIndex = 47;
            // 
            // ucKostenträgerKlientEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelOben);
            this.Controls.Add(this.uGridBagLayoutPanelElemente);
            this.Name = "ucKostenträgerKlientEdit";
            this.Size = new System.Drawing.Size(872, 462);
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigAb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKtrArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBetragErrechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpErfasstAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBenutzer)).EndInit();
            this.panelDatum.ResumeLayout(false);
            this.panelDatum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbRechnungJN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVorauszahlungJN)).EndInit();
            this.panelRechnung.ResumeLayout(false);
            this.panelRechnung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRechnungTyp)).EndInit();
            this.panelUnten.ResumeLayout(false);
            this.panelUnten.PerformLayout();
            this.panelAuswahlRestzahler.ResumeLayout(false);
            this.panelAuswahlRestzahler.PerformLayout();
            this.panelAuswahlRechnung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGridBagLayoutPanelElemente)).EndInit();
            this.uGridBagLayoutPanelElemente.ResumeLayout(false);
            this.panelOben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboRechnungsdruckTyp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtGueltigAb;
        private QS2.Desktop.ControlManagment.BaseLabel lblGültigAb;
        private QS2.Desktop.ControlManagment.BaseLabel lblGültigBis;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtGueltigBis;
        private QS2.Desktop.ControlManagment.BaseComboEditor cbKtrArt;
        private QS2.Desktop.ControlManagment.BaseLabel lblKostenträgerart;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbBetragErrechnet;
        private Infragistics.Win.UltraWinEditors.UltraCurrencyEditor txtBetrag;
        private QS2.Desktop.ControlManagment.BaseLabel lblBetrag;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseLabel lblErfasstAm;
        private QS2.Desktop.ControlManagment.BaseDateTimeEditor dtpErfasstAm;
        private QS2.Desktop.ControlManagment.BaseLabel lblBenutzer;
        private QS2.Desktop.ControlManagment.BaseComboEditor cmbBenutzer;
        private QS2.Desktop.ControlManagment.BasePanel panelDatum;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbVorauszahlungJN;
        private QS2.Desktop.ControlManagment.BaseCheckBox cbRechnungJN;
        private QS2.Desktop.ControlManagment.BasePanel panelRechnung;
        private QS2.Desktop.ControlManagment.BaseLabel lblRechnungstyp;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboRechnungTyp;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        private QS2.Desktop.ControlManagment.BasePanel panelAuswahlRechnung;
        private QS2.Desktop.ControlManagment.BasePanel panelAuswahlRestzahler;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel uGridBagLayoutPanelElemente;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private QS2.Desktop.ControlManagment.BasePanel panelKostnträger;
        private QS2.Desktop.ControlManagment.BaseComboEditor cboRechnungsdruckTyp;
        private QS2.Desktop.ControlManagment.BaseLabel lblRechnungsdruckTyp;
    }
}
