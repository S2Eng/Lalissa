namespace PMDS.GUI
{
    partial class ucPflegeEintragExLine
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblInfo = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblTerminText = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.ucDateSelect1 = new PMDS.GUI.ucDateSelect();
            this.lblDauer2 = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblMed = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblZeitpunkt = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.chkIgnoreLine = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.chkMorgenWieder = new QS2.Desktop.ControlManagment.BaseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnoreLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMorgenWieder)).BeginInit();
            this.SuspendLayout();
            // 
            // ucZusatzWert1
            // 
            this.ucZusatzWert1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.ucZusatzWert1.Location = new System.Drawing.Point(0, 160);
            this.ucZusatzWert1.MinimumSize = new System.Drawing.Size(300, 0);
            this.ucZusatzWert1.Size = new System.Drawing.Size(412, 142);
            // 
            // lblWichtigFür
            // 
            this.lblWichtigFür.Location = new System.Drawing.Point(512, 7);
            this.lblWichtigFür.Size = new System.Drawing.Size(70, 25);
            this.lblWichtigFür.Visible = false;
            // 
            // cbImportant
            // 
            this.cbImportant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbImportant.Location = new System.Drawing.Point(1087, 5);
            this.cbImportant.Size = new System.Drawing.Size(40, 24);
            // 
            // lblAnmerkung
            // 
            this.lblAnmerkung.Location = new System.Drawing.Point(8, 92);
            this.lblAnmerkung.Size = new System.Drawing.Size(48, 17);
            this.lblAnmerkung.Text = "Dekurs";
            this.lblAnmerkung.Visible = false;
            this.lblAnmerkung.Click += new System.EventHandler(this.lblAnmerkung_Click);
            // 
            // cbMassnahme
            // 
            this.cbMassnahme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMassnahme.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbMassnahme.Location = new System.Drawing.Point(44, 673);
            this.cbMassnahme.Size = new System.Drawing.Size(320, 24);
            // 
            // lblZeitpunktDerDurchführung
            // 
            this.lblZeitpunktDerDurchführung.Location = new System.Drawing.Point(429, 687);
            this.lblZeitpunktDerDurchführung.Visible = false;
            // 
            // labMassnahme
            // 
            this.labMassnahme.Location = new System.Drawing.Point(803, 684);
            this.labMassnahme.Visible = false;
            // 
            // chkDone
            // 
            this.chkDone.Location = new System.Drawing.Point(590, 37);
            this.chkDone.Size = new System.Drawing.Size(119, 17);
            // 
            // dtpZeitpunkt
            // 
            this.dtpZeitpunkt.Location = new System.Drawing.Point(332, 5);
            this.dtpZeitpunkt.Size = new System.Drawing.Size(135, 24);
            this.dtpZeitpunkt.ValueChanged += new System.EventHandler(this.dtpZeitpunkt_ValueChanged);
            // 
            // lblDauer
            // 
            this.lblDauer.Location = new System.Drawing.Point(732, 684);
            this.lblDauer.Visible = false;
            // 
            // txtIstDauer
            // 
            this.txtIstDauer.ContextMenuStrip = null;
            this.txtIstDauer.Location = new System.Drawing.Point(1031, 159);
            this.txtIstDauer.Visible = false;
            // 
            // cbBedarfsMedikament
            // 
            this.cbBedarfsMedikament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBedarfsMedikament.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbBedarfsMedikament.Location = new System.Drawing.Point(892, 156);
            this.cbBedarfsMedikament.Size = new System.Drawing.Size(69, 24);
            // 
            // lblMedikation
            // 
            this.lblMedikation.Location = new System.Drawing.Point(892, 698);
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(420, 88);
            // 
            // auswahlGruppeComboMulti1
            // 
            this.auswahlGruppeComboMulti1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.auswahlGruppeComboMulti1.Location = new System.Drawing.Point(590, 5);
            this.auswahlGruppeComboMulti1.Size = new System.Drawing.Size(494, 27);
            // 
            // chkAlsDekursKopieren
            // 
            this.chkAlsDekursKopieren.Location = new System.Drawing.Point(751, 58);
            this.chkAlsDekursKopieren.Size = new System.Drawing.Size(149, 17);
            // 
            // panelTxtControl
            // 
            this.panelTxtControl.Location = new System.Drawing.Point(226, 636);
            // 
            // lblZusatzwerte
            // 
            this.lblZusatzwerte.Location = new System.Drawing.Point(469, 736);
            // 
            // chkGegenzeichnen
            // 
            this.chkGegenzeichnen.Location = new System.Drawing.Point(751, 37);
            this.chkGegenzeichnen.Size = new System.Drawing.Size(192, 17);
            // 
            // panelBeschreibungTXTEditor
            // 
            this.panelBeschreibungTXTEditor.Location = new System.Drawing.Point(40, 720);
            this.panelBeschreibungTXTEditor.Size = new System.Drawing.Size(197, 67);
            // 
            // txtBeschreibungLine
            // 
            this.txtBeschreibungLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBeschreibungLine.Location = new System.Drawing.Point(100, 83);
            this.txtBeschreibungLine.Multiline = true;
            this.txtBeschreibungLine.Size = new System.Drawing.Size(984, 64);
            this.txtBeschreibungLine.ValueChanged += new System.EventHandler(this.txtBeschreibungLine_ValueChanged);
            this.txtBeschreibungLine.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBeschreibungLine_KeyUp);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1131, 1);
            this.splitter1.TabIndex = 35;
            this.splitter1.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.Tomato;
            this.lblInfo.Location = new System.Drawing.Point(5, 1);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(241, 25);
            this.lblInfo.TabIndex = 36;
            this.lblInfo.Text = "lblInfo";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTerminText
            // 
            this.lblTerminText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTerminText.Location = new System.Drawing.Point(7, 35);
            this.lblTerminText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerminText.Name = "lblTerminText";
            this.lblTerminText.Size = new System.Drawing.Size(573, 37);
            this.lblTerminText.TabIndex = 37;
            this.lblTerminText.Text = "lblTerminText";
            this.lblTerminText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTerminText.Visible = false;
            // 
            // ucDateSelect1
            // 
            this.ucDateSelect1.Location = new System.Drawing.Point(472, 1);
            this.ucDateSelect1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDateSelect1.Name = "ucDateSelect1";
            this.ucDateSelect1.Size = new System.Drawing.Size(40, 25);
            this.ucDateSelect1.TabIndex = 38;
            this.ucDateSelect1.delRefresh += new PMDS.Global.refreshUI(this.ucDateSelect1_delRefresh);
            this.ucDateSelect1.Load += new System.EventHandler(this.ucDateSelect1_Load_1);
            // 
            // lblDauer2
            // 
            this.lblDauer2.Location = new System.Drawing.Point(969, 156);
            this.lblDauer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDauer2.Name = "lblDauer2";
            this.lblDauer2.Size = new System.Drawing.Size(60, 25);
            this.lblDauer2.TabIndex = 50;
            this.lblDauer2.Text = "Dauer";
            this.lblDauer2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDauer2.Visible = false;
            // 
            // lblMed
            // 
            this.lblMed.Location = new System.Drawing.Point(821, 160);
            this.lblMed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMed.Name = "lblMed";
            this.lblMed.Size = new System.Drawing.Size(53, 17);
            this.lblMed.TabIndex = 51;
            this.lblMed.Text = "Med.";
            this.lblMed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMed.Visible = false;
            this.lblMed.Click += new System.EventHandler(this.baseLableWin2_Click);
            // 
            // lblZeitpunkt
            // 
            this.lblZeitpunkt.Location = new System.Drawing.Point(260, 1);
            this.lblZeitpunkt.Name = "lblZeitpunkt";
            this.lblZeitpunkt.Size = new System.Drawing.Size(71, 25);
            this.lblZeitpunkt.TabIndex = 52;
            this.lblZeitpunkt.Text = "Zeitpunkt";
            this.lblZeitpunkt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIgnoreLine
            // 
            this.chkIgnoreLine.Location = new System.Drawing.Point(954, 33);
            this.chkIgnoreLine.Margin = new System.Windows.Forms.Padding(4);
            this.chkIgnoreLine.Name = "chkIgnoreLine";
            this.chkIgnoreLine.Size = new System.Drawing.Size(130, 25);
            this.chkIgnoreLine.TabIndex = 53;
            this.chkIgnoreLine.Text = "Überspringen";
            this.chkIgnoreLine.CheckedChanged += new System.EventHandler(this.chkIgnoreLine_CheckedChanged);
            // 
            // chkMorgenWieder
            // 
            this.chkMorgenWieder.Location = new System.Drawing.Point(954, 58);
            this.chkMorgenWieder.Margin = new System.Windows.Forms.Padding(4);
            this.chkMorgenWieder.Name = "chkMorgenWieder";
            this.chkMorgenWieder.Size = new System.Drawing.Size(130, 25);
            this.chkMorgenWieder.TabIndex = 54;
            this.chkMorgenWieder.Text = "Morgen wieder";
            this.chkMorgenWieder.CheckedChanged += new System.EventHandler(this.chkMorgenWieder_CheckedChanged);
            // 
            // ucPflegeEintragExLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.chkMorgenWieder);
            this.Controls.Add(this.chkIgnoreLine);
            this.Controls.Add(this.lblZeitpunkt);
            this.Controls.Add(this.lblMed);
            this.Controls.Add(this.lblDauer2);
            this.Controls.Add(this.lblTerminText);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.ucDateSelect1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1131, 0);
            this.Name = "ucPflegeEintragExLine";
            this.Size = new System.Drawing.Size(1131, 306);
            this.Load += new System.EventHandler(this.ucPflegeEintragExLine_Load);
            this.Controls.SetChildIndex(this.panelTxtControl, 0);
            this.Controls.SetChildIndex(this.lblZusatzwerte, 0);
            this.Controls.SetChildIndex(this.cbMassnahme, 0);
            this.Controls.SetChildIndex(this.ucDateSelect1, 0);
            this.Controls.SetChildIndex(this.lblInfo, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.lblTerminText, 0);
            this.Controls.SetChildIndex(this.lblMin, 0);
            this.Controls.SetChildIndex(this.chkDone, 0);
            this.Controls.SetChildIndex(this.lblMedikation, 0);
            this.Controls.SetChildIndex(this.labMassnahme, 0);
            this.Controls.SetChildIndex(this.txtIstDauer, 0);
            this.Controls.SetChildIndex(this.lblDauer, 0);
            this.Controls.SetChildIndex(this.lblZeitpunktDerDurchführung, 0);
            this.Controls.SetChildIndex(this.dtpZeitpunkt, 0);
            this.Controls.SetChildIndex(this.cbBedarfsMedikament, 0);
            this.Controls.SetChildIndex(this.lblAnmerkung, 0);
            this.Controls.SetChildIndex(this.cbImportant, 0);
            this.Controls.SetChildIndex(this.lblWichtigFür, 0);
            this.Controls.SetChildIndex(this.chkAlsDekursKopieren, 0);
            this.Controls.SetChildIndex(this.panelBeschreibungTXTEditor, 0);
            this.Controls.SetChildIndex(this.chkGegenzeichnen, 0);
            this.Controls.SetChildIndex(this.auswahlGruppeComboMulti1, 0);
            this.Controls.SetChildIndex(this.txtBeschreibungLine, 0);
            this.Controls.SetChildIndex(this.ucZusatzWert1, 0);
            this.Controls.SetChildIndex(this.lblDauer2, 0);
            this.Controls.SetChildIndex(this.lblMed, 0);
            this.Controls.SetChildIndex(this.lblZeitpunkt, 0);
            this.Controls.SetChildIndex(this.chkIgnoreLine, 0);
            this.Controls.SetChildIndex(this.chkMorgenWieder, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImportant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMassnahme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpZeitpunkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBedarfsMedikament)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlsDekursKopieren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGegenzeichnen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeschreibungLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIgnoreLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMorgenWieder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblInfo;
        private QS2.Desktop.ControlManagment.BaseLableWin lblTerminText;
        private ucDateSelect ucDateSelect1;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDauer2;
        private QS2.Desktop.ControlManagment.BaseLableWin lblMed;
        private QS2.Desktop.ControlManagment.BaseLableWin lblZeitpunkt;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkIgnoreLine;
        protected QS2.Desktop.ControlManagment.BaseCheckBox chkMorgenWieder;
    }
}
