namespace PMDS.GUI.BaseControls
{
    partial class ucBerichtParameterDefinition
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
            this.cbTyp = new System.Windows.Forms.ComboBox();
            this.tbName = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.tbBezeichnung = new QS2.Desktop.ControlManagment.BaseTextEditorWin();
            this.pnlHeader = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblDefaultwert = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblBezeichnungImFenster = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblParameterType = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.lblName = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.pnlFields = new QS2.Desktop.ControlManagment.BasePanel();
            this.cbDefault = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTyp
            // 
            this.cbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTyp.FormattingEnabled = true;
            this.cbTyp.Location = new System.Drawing.Point(125, 1);
            this.cbTyp.Margin = new System.Windows.Forms.Padding(0);
            this.cbTyp.Name = "cbTyp";
            this.cbTyp.Size = new System.Drawing.Size(147, 21);
            this.cbTyp.TabIndex = 1;
            this.cbTyp.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(1, 1);
            this.tbName.Margin = new System.Windows.Forms.Padding(0);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(118, 20);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbBezeichnung
            // 
            this.tbBezeichnung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBezeichnung.Location = new System.Drawing.Point(278, 1);
            this.tbBezeichnung.Margin = new System.Windows.Forms.Padding(0);
            this.tbBezeichnung.Name = "tbBezeichnung";
            this.tbBezeichnung.Size = new System.Drawing.Size(195, 20);
            this.tbBezeichnung.TabIndex = 2;
            this.tbBezeichnung.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblDefaultwert);
            this.pnlHeader.Controls.Add(this.lblBezeichnungImFenster);
            this.pnlHeader.Controls.Add(this.lblParameterType);
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(697, 22);
            this.pnlHeader.TabIndex = 4;
            this.pnlHeader.VisibleChanged += new System.EventHandler(this.pnlHeader_VisibleChanged);
            // 
            // lblDefaultwert
            // 
            this.lblDefaultwert.AutoSize = true;
            this.lblDefaultwert.Location = new System.Drawing.Point(476, 4);
            this.lblDefaultwert.Name = "lblDefaultwert";
            this.lblDefaultwert.Size = new System.Drawing.Size(61, 13);
            this.lblDefaultwert.TabIndex = 3;
            this.lblDefaultwert.Text = "Defaultwert";
            // 
            // lblBezeichnungImFenster
            // 
            this.lblBezeichnungImFenster.AutoSize = true;
            this.lblBezeichnungImFenster.Location = new System.Drawing.Point(275, 4);
            this.lblBezeichnungImFenster.Name = "lblBezeichnungImFenster";
            this.lblBezeichnungImFenster.Size = new System.Drawing.Size(120, 13);
            this.lblBezeichnungImFenster.TabIndex = 2;
            this.lblBezeichnungImFenster.Text = "Bezeichnung im Fenster";
            // 
            // lblParameterType
            // 
            this.lblParameterType.AutoSize = true;
            this.lblParameterType.Location = new System.Drawing.Point(122, 4);
            this.lblParameterType.Name = "lblParameterType";
            this.lblParameterType.Size = new System.Drawing.Size(73, 13);
            this.lblParameterType.TabIndex = 1;
            this.lblParameterType.Text = "ParameterTyp";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(1, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Parametername";
            // 
            // pnlFields
            // 
            this.pnlFields.BackColor = System.Drawing.SystemColors.Window;
            this.pnlFields.Controls.Add(this.cbDefault);
            this.pnlFields.Controls.Add(this.tbName);
            this.pnlFields.Controls.Add(this.cbTyp);
            this.pnlFields.Controls.Add(this.tbBezeichnung);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(0, 22);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(697, 24);
            this.pnlFields.TabIndex = 5;
            // 
            // cbDefault
            // 
            this.cbDefault.DropDownHeight = 400;
            this.cbDefault.FormattingEnabled = true;
            this.cbDefault.IntegralHeight = false;
            this.cbDefault.Items.AddRange(new object[] {
            "-------- Datums Zeit Werte -------------------",
            "1QB + 1J",
            "1QE - 1J",
            "2QB",
            "2QE ",
            "3QB + 3W",
            "3QE - 3W",
            "4QB + 10M",
            "4QE - 10M",
            "DATUM_AKTUELL",
            "DATUM_AKTUELL -14T",
            "DATUM_AKTUELL + 14T",
            "JB",
            "JE",
            "MB",
            "ME",
            "TAG_BEGINN",
            "TAG_ENDE",
            "ZEIT_AKTUELL",
            "ZEIT_AKTUELL - 48S",
            "ZEIT_AKTUELL + 4S",
            "LEER",
            "-------- Werte für Boolean -------------------",
            "WAHR",
            "FALSCH",
            "UNDEFINIERT",
            "-------- Werte für Guid  -------------------",
            "GUIDLEER",
            "-------- Werte für Zahlen -------------------",
            "JAHR_AKTUELL",
            "MONAT_AKTUELL",
            "TAG_AKTUELL",
            "-------- Werte für ASZM Liste -------------------",
            "A",
            "S",
            "Z",
            "M",
            "-------- Werte für Auswahlliste -----------------",
            "ANR",
            "BER"});
            this.cbDefault.Location = new System.Drawing.Point(479, 0);
            this.cbDefault.Margin = new System.Windows.Forms.Padding(0);
            this.cbDefault.MaxDropDownItems = 30;
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.Size = new System.Drawing.Size(173, 21);
            this.cbDefault.TabIndex = 3;
            this.cbDefault.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // ucBerichtParameterDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucBerichtParameterDefinition";
            this.Size = new System.Drawing.Size(697, 46);
            this.Enter += new System.EventHandler(this.ucBerichtParameterDefinition_Enter);
            this.Leave += new System.EventHandler(this.ucBerichtParameterDefinition_Leave);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTyp;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbName;
        private QS2.Desktop.ControlManagment.BaseTextEditorWin tbBezeichnung;
        private QS2.Desktop.ControlManagment.BasePanel pnlHeader;
        private QS2.Desktop.ControlManagment.BaseLableWin lblDefaultwert;
        private QS2.Desktop.ControlManagment.BaseLableWin lblBezeichnungImFenster;
        private QS2.Desktop.ControlManagment.BaseLableWin lblParameterType;
        private QS2.Desktop.ControlManagment.BaseLableWin lblName;
        private QS2.Desktop.ControlManagment.BasePanel pnlFields;
        private System.Windows.Forms.ComboBox cbDefault;
    }
}
