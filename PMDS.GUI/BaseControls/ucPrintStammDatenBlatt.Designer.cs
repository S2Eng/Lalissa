namespace PMDS.GUI.BaseControls
{
    partial class ucPrintStammDatenBlatt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrintStammDatenBlatt));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.pnlPrintStammDatenBlatt = new QS2.Desktop.ControlManagment.BasePanel();
            this.chkKostentraeger = new System.Windows.Forms.CheckBox();
            this.chkReha = new System.Windows.Forms.CheckBox();
            this.chkRegelungen = new System.Windows.Forms.CheckBox();
            this.chkDienstleister = new System.Windows.Forms.CheckBox();
            this.chkHilfsmittel = new System.Windows.Forms.CheckBox();
            this.chkVerwahrung = new System.Windows.Forms.CheckBox();
            this.chkPflegestufe = new System.Windows.Forms.CheckBox();
            this.chkAerzte = new System.Windows.Forms.CheckBox();
            this.chkSachwalter = new System.Windows.Forms.CheckBox();
            this.chkKontaktPersonen = new System.Windows.Forms.CheckBox();
            this.chkMedizinischeDaten = new System.Windows.Forms.CheckBox();
            this.chkVersicherungsdaten = new System.Windows.Forms.CheckBox();
            this.lblAusdruckVon = new QS2.Desktop.ControlManagment.BaseLabel();
            this.chkFreiheitsbeschränkungen = new System.Windows.Forms.CheckBox();
            this.btnPrintStammdaten = new PMDS.GUI.ucButton(this.components);
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.btnPrintSettings = new Infragistics.Win.Misc.UltraDropDownButton();
            this.pnlPrintStammDatenBlatt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrintStammDatenBlatt
            // 
            this.pnlPrintStammDatenBlatt.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPrintStammDatenBlatt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkKostentraeger);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkReha);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkRegelungen);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkDienstleister);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkHilfsmittel);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkVerwahrung);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkPflegestufe);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkAerzte);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkSachwalter);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkKontaktPersonen);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkMedizinischeDaten);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkVersicherungsdaten);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.lblAusdruckVon);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.chkFreiheitsbeschränkungen);
            this.pnlPrintStammDatenBlatt.Controls.Add(this.btnPrintStammdaten);
            this.pnlPrintStammDatenBlatt.Location = new System.Drawing.Point(3, 77);
            this.pnlPrintStammDatenBlatt.Name = "pnlPrintStammDatenBlatt";
            this.pnlPrintStammDatenBlatt.Size = new System.Drawing.Size(394, 202);
            this.pnlPrintStammDatenBlatt.TabIndex = 88;
            this.pnlPrintStammDatenBlatt.Visible = false;
            // 
            // chkKostentraeger
            // 
            this.chkKostentraeger.AutoSize = true;
            this.chkKostentraeger.Checked = true;
            this.chkKostentraeger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKostentraeger.Location = new System.Drawing.Point(11, 160);
            this.chkKostentraeger.Name = "chkKostentraeger";
            this.chkKostentraeger.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkKostentraeger.Size = new System.Drawing.Size(91, 22);
            this.chkKostentraeger.TabIndex = 94;
            this.chkKostentraeger.Text = "Kostenträger";
            this.chkKostentraeger.UseVisualStyleBackColor = true;
            // 
            // chkReha
            // 
            this.chkReha.AutoSize = true;
            this.chkReha.Checked = true;
            this.chkReha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReha.Location = new System.Drawing.Point(180, 93);
            this.chkReha.Name = "chkReha";
            this.chkReha.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkReha.Size = new System.Drawing.Size(94, 22);
            this.chkReha.TabIndex = 93;
            this.chkReha.Text = "Spital / Reha";
            this.chkReha.UseVisualStyleBackColor = true;
            // 
            // chkRegelungen
            // 
            this.chkRegelungen.AutoSize = true;
            this.chkRegelungen.Checked = true;
            this.chkRegelungen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRegelungen.Location = new System.Drawing.Point(180, 49);
            this.chkRegelungen.Name = "chkRegelungen";
            this.chkRegelungen.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkRegelungen.Size = new System.Drawing.Size(89, 22);
            this.chkRegelungen.TabIndex = 92;
            this.chkRegelungen.Text = "Regelungen";
            this.chkRegelungen.UseVisualStyleBackColor = true;
            // 
            // chkDienstleister
            // 
            this.chkDienstleister.AutoSize = true;
            this.chkDienstleister.Checked = true;
            this.chkDienstleister.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDienstleister.Location = new System.Drawing.Point(180, 71);
            this.chkDienstleister.Name = "chkDienstleister";
            this.chkDienstleister.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkDienstleister.Size = new System.Drawing.Size(106, 22);
            this.chkDienstleister.TabIndex = 91;
            this.chkDienstleister.Text = "Ext Dienstleister";
            this.chkDienstleister.UseVisualStyleBackColor = true;
            // 
            // chkHilfsmittel
            // 
            this.chkHilfsmittel.AutoSize = true;
            this.chkHilfsmittel.Checked = true;
            this.chkHilfsmittel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHilfsmittel.Location = new System.Drawing.Point(180, 160);
            this.chkHilfsmittel.Name = "chkHilfsmittel";
            this.chkHilfsmittel.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkHilfsmittel.Size = new System.Drawing.Size(75, 22);
            this.chkHilfsmittel.TabIndex = 90;
            this.chkHilfsmittel.Text = "Hilfsmittel";
            this.chkHilfsmittel.UseVisualStyleBackColor = true;
            // 
            // chkVerwahrung
            // 
            this.chkVerwahrung.AutoSize = true;
            this.chkVerwahrung.Checked = true;
            this.chkVerwahrung.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerwahrung.Location = new System.Drawing.Point(181, 137);
            this.chkVerwahrung.Name = "chkVerwahrung";
            this.chkVerwahrung.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkVerwahrung.Size = new System.Drawing.Size(88, 22);
            this.chkVerwahrung.TabIndex = 89;
            this.chkVerwahrung.Text = "Verwahrung";
            this.chkVerwahrung.UseVisualStyleBackColor = true;
            // 
            // chkPflegestufe
            // 
            this.chkPflegestufe.AutoSize = true;
            this.chkPflegestufe.Checked = true;
            this.chkPflegestufe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPflegestufe.Location = new System.Drawing.Point(181, 27);
            this.chkPflegestufe.Name = "chkPflegestufe";
            this.chkPflegestufe.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkPflegestufe.Size = new System.Drawing.Size(84, 22);
            this.chkPflegestufe.TabIndex = 87;
            this.chkPflegestufe.Text = "Pflegestufe";
            this.chkPflegestufe.UseVisualStyleBackColor = true;
            // 
            // chkAerzte
            // 
            this.chkAerzte.AutoSize = true;
            this.chkAerzte.Checked = true;
            this.chkAerzte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAerzte.Location = new System.Drawing.Point(11, 27);
            this.chkAerzte.Name = "chkAerzte";
            this.chkAerzte.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkAerzte.Size = new System.Drawing.Size(55, 22);
            this.chkAerzte.TabIndex = 0;
            this.chkAerzte.Text = "Ärzte";
            this.chkAerzte.UseVisualStyleBackColor = true;
            // 
            // chkSachwalter
            // 
            this.chkSachwalter.AutoSize = true;
            this.chkSachwalter.Checked = true;
            this.chkSachwalter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSachwalter.Location = new System.Drawing.Point(11, 49);
            this.chkSachwalter.Name = "chkSachwalter";
            this.chkSachwalter.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkSachwalter.Size = new System.Drawing.Size(84, 22);
            this.chkSachwalter.TabIndex = 1;
            this.chkSachwalter.Text = "Sachwalter";
            this.chkSachwalter.UseVisualStyleBackColor = true;
            // 
            // chkKontaktPersonen
            // 
            this.chkKontaktPersonen.AutoSize = true;
            this.chkKontaktPersonen.Checked = true;
            this.chkKontaktPersonen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKontaktPersonen.Location = new System.Drawing.Point(11, 71);
            this.chkKontaktPersonen.Name = "chkKontaktPersonen";
            this.chkKontaktPersonen.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkKontaktPersonen.Size = new System.Drawing.Size(112, 22);
            this.chkKontaktPersonen.TabIndex = 2;
            this.chkKontaktPersonen.Text = "Kontaktpersonen";
            this.chkKontaktPersonen.UseVisualStyleBackColor = true;
            // 
            // chkMedizinischeDaten
            // 
            this.chkMedizinischeDaten.AutoSize = true;
            this.chkMedizinischeDaten.Checked = true;
            this.chkMedizinischeDaten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMedizinischeDaten.Location = new System.Drawing.Point(11, 93);
            this.chkMedizinischeDaten.Name = "chkMedizinischeDaten";
            this.chkMedizinischeDaten.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.chkMedizinischeDaten.Size = new System.Drawing.Size(124, 22);
            this.chkMedizinischeDaten.TabIndex = 3;
            this.chkMedizinischeDaten.Text = "Medizinische Daten";
            this.chkMedizinischeDaten.UseVisualStyleBackColor = true;
            // 
            // chkVersicherungsdaten
            // 
            this.chkVersicherungsdaten.AutoSize = true;
            this.chkVersicherungsdaten.Checked = true;
            this.chkVersicherungsdaten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVersicherungsdaten.Location = new System.Drawing.Point(11, 115);
            this.chkVersicherungsdaten.Name = "chkVersicherungsdaten";
            this.chkVersicherungsdaten.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.chkVersicherungsdaten.Size = new System.Drawing.Size(125, 27);
            this.chkVersicherungsdaten.TabIndex = 4;
            this.chkVersicherungsdaten.Text = "Versicherungsdaten";
            this.chkVersicherungsdaten.UseVisualStyleBackColor = true;
            // 
            // lblAusdruckVon
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.lblAusdruckVon.Appearance = appearance1;
            this.lblAusdruckVon.AutoSize = true;
            this.lblAusdruckVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusdruckVon.Location = new System.Drawing.Point(14, 8);
            this.lblAusdruckVon.Name = "lblAusdruckVon";
            this.lblAusdruckVon.Size = new System.Drawing.Size(76, 14);
            this.lblAusdruckVon.TabIndex = 86;
            this.lblAusdruckVon.Text = "Ausdruck von:";
            // 
            // chkFreiheitsbeschränkungen
            // 
            this.chkFreiheitsbeschränkungen.AutoSize = true;
            this.chkFreiheitsbeschränkungen.Checked = true;
            this.chkFreiheitsbeschränkungen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFreiheitsbeschränkungen.Location = new System.Drawing.Point(11, 143);
            this.chkFreiheitsbeschränkungen.Name = "chkFreiheitsbeschränkungen";
            this.chkFreiheitsbeschränkungen.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.chkFreiheitsbeschränkungen.Size = new System.Drawing.Size(150, 22);
            this.chkFreiheitsbeschränkungen.TabIndex = 5;
            this.chkFreiheitsbeschränkungen.Text = "Freiheitsbeschränkungen";
            this.chkFreiheitsbeschränkungen.UseVisualStyleBackColor = true;
            // 
            // btnPrintStammdaten
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnPrintStammdaten.Appearance = appearance2;
            this.btnPrintStammdaten.AutoWorkLayout = false;
            this.btnPrintStammdaten.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPrintStammdaten.DoOnClick = true;
            this.btnPrintStammdaten.IsStandardControl = true;
            this.btnPrintStammdaten.Location = new System.Drawing.Point(294, 165);
            this.btnPrintStammdaten.Name = "btnPrintStammdaten";
            this.btnPrintStammdaten.Size = new System.Drawing.Size(75, 29);
            this.btnPrintStammdaten.TabIndex = 6;
            this.btnPrintStammdaten.TabStop = false;
            this.btnPrintStammdaten.TYPE = PMDS.GUI.ucButton.ButtonType.Print;
            this.btnPrintStammdaten.TYPEPlacement = PMDS.Global.UIGlobal.ButtonPlacement.normal;
            this.btnPrintStammdaten.Click += new System.EventHandler(this.btnPrintStammdaten_Click);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlPrintStammDatenBlatt;
            // 
            // btnPrintSettings
            // 
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintSettings.Appearance = appearance3;
            this.btnPrintSettings.Location = new System.Drawing.Point(0, 0);
            this.btnPrintSettings.Name = "btnPrintSettings";
            this.btnPrintSettings.PopupItemKey = "pnlPrintStammDatenBlatt";
            this.btnPrintSettings.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnPrintSettings.RightAlignPopup = Infragistics.Win.DefaultableBoolean.False;
            this.btnPrintSettings.Size = new System.Drawing.Size(165, 30);
            this.btnPrintSettings.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnPrintSettings.TabIndex = 89;
            this.btnPrintSettings.Text = "&Stammdatenblatt drucken";
            this.btnPrintSettings.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrintSettings.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ucPrintStammDatenBlatt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPrintSettings);
            this.Controls.Add(this.pnlPrintStammDatenBlatt);
            this.Name = "ucPrintStammDatenBlatt";
            this.Size = new System.Drawing.Size(400, 304);
            this.pnlPrintStammDatenBlatt.ResumeLayout(false);
            this.pnlPrintStammDatenBlatt.PerformLayout();
            this.ResumeLayout(false);

          }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlPrintStammDatenBlatt;
        private System.Windows.Forms.CheckBox chkAerzte;
        private System.Windows.Forms.CheckBox chkSachwalter;
        private System.Windows.Forms.CheckBox chkKontaktPersonen;
        private System.Windows.Forms.CheckBox chkMedizinischeDaten;
        private System.Windows.Forms.CheckBox chkVersicherungsdaten;
        private System.Windows.Forms.CheckBox chkFreiheitsbeschränkungen;
        private QS2.Desktop.ControlManagment.BaseLabel lblAusdruckVon;
        private ucButton btnPrintStammdaten;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private Infragistics.Win.Misc.UltraDropDownButton btnPrintSettings;
        private System.Windows.Forms.CheckBox chkReha;
        private System.Windows.Forms.CheckBox chkRegelungen;
        private System.Windows.Forms.CheckBox chkDienstleister;
        private System.Windows.Forms.CheckBox chkHilfsmittel;
        private System.Windows.Forms.CheckBox chkVerwahrung;
        private System.Windows.Forms.CheckBox chkPflegestufe;
        private System.Windows.Forms.CheckBox chkKostentraeger;
    }
}
