using PMDS.Global.db.Global;

namespace PMDS.GUI.Klient
{
    partial class contPatientDelete
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnDelete = new QS2.Desktop.ControlManagment.BaseButton();
            this.lblIDPatient = new Infragistics.Win.Misc.UltraLabel();
            this.txtIDPatient = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.lblIDPatientInfo = new Infragistics.Win.Misc.UltraLabel();
            this.lblInfoPatientname = new Infragistics.Win.Misc.UltraLabel();
            this.lblInfoLetztesEntlassungsdatum = new Infragistics.Win.Misc.UltraLabel();
            this.lblWarning = new Infragistics.Win.Misc.UltraLabel();
            this.dsIDTextBezeichnung1 = new dsIDTextBezeichnung();
            this.textControl1 = new TXTextControl.TextControl();
            this.serverTextControl1 = new TXTextControl.ServerTextControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(237, 180);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(88, 32);
            this.btnAbort.TabIndex = 100;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnDelete.Appearance = appearance2;
            this.btnDelete.AutoWorkLayout = false;
            this.btnDelete.IsStandardControl = false;
            this.btnDelete.Location = new System.Drawing.Point(325, 180);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 32);
            this.btnDelete.TabIndex = 101;
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Löschen";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblIDPatient
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.lblIDPatient.Appearance = appearance3;
            this.lblIDPatient.Location = new System.Drawing.Point(17, 119);
            this.lblIDPatient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIDPatient.Name = "lblIDPatient";
            this.lblIDPatient.Size = new System.Drawing.Size(462, 19);
            this.lblIDPatient.TabIndex = 105;
            this.lblIDPatient.Text = "Bitte geben Sie zur Sicherheit unten nochmals die angeführte ID-Patient ein:";
            // 
            // txtIDPatient
            // 
            this.txtIDPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColorDisabled = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtIDPatient.Appearance = appearance4;
            this.txtIDPatient.BackColor = System.Drawing.Color.White;
            this.txtIDPatient.Location = new System.Drawing.Point(18, 139);
            this.txtIDPatient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDPatient.Name = "txtIDPatient";
            this.txtIDPatient.Size = new System.Drawing.Size(650, 23);
            this.txtIDPatient.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // lblIDPatientInfo
            // 
            this.lblIDPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.TextVAlignAsString = "Middle";
            this.lblIDPatientInfo.Appearance = appearance8;
            this.lblIDPatientInfo.Location = new System.Drawing.Point(17, 89);
            this.lblIDPatientInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblIDPatientInfo.Name = "lblIDPatientInfo";
            this.lblIDPatientInfo.Size = new System.Drawing.Size(652, 19);
            this.lblIDPatientInfo.TabIndex = 106;
            this.lblIDPatientInfo.Text = "ID-Patient: xxx-xxx...";
            // 
            // lblInfoPatientname
            // 
            this.lblInfoPatientname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.FontData.BoldAsString = "True";
            appearance7.TextVAlignAsString = "Middle";
            this.lblInfoPatientname.Appearance = appearance7;
            this.lblInfoPatientname.Location = new System.Drawing.Point(17, 11);
            this.lblInfoPatientname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblInfoPatientname.Name = "lblInfoPatientname";
            this.lblInfoPatientname.Size = new System.Drawing.Size(652, 19);
            this.lblInfoPatientname.TabIndex = 107;
            this.lblInfoPatientname.Text = "Patient:";
            // 
            // lblInfoLetztesEntlassungsdatum
            // 
            this.lblInfoLetztesEntlassungsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.TextVAlignAsString = "Middle";
            this.lblInfoLetztesEntlassungsdatum.Appearance = appearance6;
            this.lblInfoLetztesEntlassungsdatum.Location = new System.Drawing.Point(17, 37);
            this.lblInfoLetztesEntlassungsdatum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblInfoLetztesEntlassungsdatum.Name = "lblInfoLetztesEntlassungsdatum";
            this.lblInfoLetztesEntlassungsdatum.Size = new System.Drawing.Size(652, 19);
            this.lblInfoLetztesEntlassungsdatum.TabIndex = 108;
            this.lblInfoLetztesEntlassungsdatum.Text = "Letztes Entlassungsdatum:";
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.ForeColor = System.Drawing.Color.Red;
            appearance5.TextVAlignAsString = "Middle";
            this.lblWarning.Appearance = appearance5;
            this.lblWarning.Location = new System.Drawing.Point(17, 58);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(652, 19);
            this.lblWarning.TabIndex = 109;
            this.lblWarning.Text = "Achtung: Das letzte Entlassungsdatum des Patienten liegt weniger als 10 Jahre zur" +
    "ück!";
            // 
            // dsIDTextBezeichnung1
            // 
            this.dsIDTextBezeichnung1.DataSetName = "dsIDTextBezeichnung";
            this.dsIDTextBezeichnung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsIDTextBezeichnung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(588, 179);
            this.textControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(94, 40);
            this.textControl1.TabIndex = 110;
            this.textControl1.UserNames = null;
            // 
            // serverTextControl1
            // 
            this.serverTextControl1.SpellChecker = null;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(580, 173);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 60);
            this.panel1.TabIndex = 111;
            // 
            // contPatientDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblInfoLetztesEntlassungsdatum);
            this.Controls.Add(this.lblInfoPatientname);
            this.Controls.Add(this.txtIDPatient);
            this.Controls.Add(this.lblIDPatientInfo);
            this.Controls.Add(this.lblIDPatient);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "contPatientDelete";
            this.Size = new System.Drawing.Size(687, 220);
            this.Load += new System.EventHandler(this.contPatientDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtIDPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIDTextBezeichnung1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnDelete;
        private Infragistics.Win.Misc.UltraLabel lblIDPatient;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtIDPatient;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel lblIDPatientInfo;
        private Infragistics.Win.Misc.UltraLabel lblInfoPatientname;
        private Infragistics.Win.Misc.UltraLabel lblInfoLetztesEntlassungsdatum;
        private Infragistics.Win.Misc.UltraLabel lblWarning;
        private System.Windows.Forms.Panel panel1;
        private TXTextControl.TextControl textControl1;
        private dsIDTextBezeichnung dsIDTextBezeichnung1;
        private TXTextControl.ServerTextControl serverTextControl1;
    }
}
