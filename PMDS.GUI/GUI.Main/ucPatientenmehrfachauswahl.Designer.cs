namespace PMDS.GUI.GUI.Main
{
    partial class ucPatientenmehrfachauswahl
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.btnAbort = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnOK = new QS2.Desktop.ControlManagment.BaseButton();
            this.chkHistorie = new QS2.Desktop.ControlManagment.BaseCheckBox();
            this.lblFound = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lvPatients = new Infragistics.Win.UltraWinListView.UltraListView();
            this.ucPatientGroup1 = new PMDS.GUI.ucPatientGroup();
            this.lblNone = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblAll = new QS2.Desktop.ControlManagment.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chkHistorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnAbort.Appearance = appearance1;
            this.btnAbort.AutoWorkLayout = false;
            this.btnAbort.IsStandardControl = false;
            this.btnAbort.Location = new System.Drawing.Point(623, 486);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(74, 25);
            this.btnAbort.TabIndex = 106;
            this.btnAbort.Tag = "";
            this.btnAbort.Text = "Abbrechen";
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnOK.Appearance = appearance2;
            this.btnOK.AutoWorkLayout = false;
            this.btnOK.IsStandardControl = false;
            this.btnOK.Location = new System.Drawing.Point(697, 486);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 25);
            this.btnOK.TabIndex = 105;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkHistorie
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.Name = "Microsoft Sans Serif";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextHAlignAsString = "Left";
            this.chkHistorie.Appearance = appearance3;
            this.chkHistorie.BackColor = System.Drawing.Color.Transparent;
            this.chkHistorie.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkHistorie.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.chkHistorie.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkHistorie.Location = new System.Drawing.Point(219, 7);
            this.chkHistorie.Name = "chkHistorie";
            this.chkHistorie.Size = new System.Drawing.Size(76, 21);
            this.chkHistorie.TabIndex = 108;
            this.chkHistorie.Text = "Historie";
            this.chkHistorie.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkHistorie.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.chkHistorie.CheckedChanged += new System.EventHandler(this.chkHistorie_CheckedChanged);
            // 
            // lblFound
            // 
            this.lblFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.SizeInPoints = 8F;
            this.lblFound.Appearance = appearance4;
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblFound.Location = new System.Drawing.Point(219, 491);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(70, 14);
            this.lblFound.TabIndex = 109;
            this.lblFound.Text = "Gefunden: 10";
            // 
            // lvPatients
            // 
            this.lvPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.FontData.SizeInPoints = 10F;
            this.lvPatients.Appearance = appearance5;
            this.lvPatients.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPatients.ItemSettings.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            this.lvPatients.ItemSettings.SelectedAppearance = appearance7;
            this.lvPatients.ItemSettings.SelectionType = Infragistics.Win.UltraWinListView.SelectionType.Single;
            this.lvPatients.Location = new System.Drawing.Point(216, 34);
            this.lvPatients.Name = "lvPatients";
            this.lvPatients.Size = new System.Drawing.Size(551, 449);
            this.lvPatients.TabIndex = 111;
            this.lvPatients.View = Infragistics.Win.UltraWinListView.UltraListViewStyle.List;
            this.lvPatients.ViewSettingsList.CheckBoxStyle = Infragistics.Win.UltraWinListView.CheckBoxStyle.CheckBox;
            this.lvPatients.ViewSettingsList.ImageSize = new System.Drawing.Size(0, 0);
            this.lvPatients.ItemCheckStateChanged += new Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventHandler(this.lvPatients_ItemCheckStateChanged);
            // 
            // ucPatientGroup1
            // 
            this.ucPatientGroup1.allKliniken = false;
            this.ucPatientGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ucPatientGroup1.BackColor = System.Drawing.Color.Transparent;
            this.ucPatientGroup1.ENVAbteilung = false;
            this.ucPatientGroup1.IsMainHeaderPicker = false;
            this.ucPatientGroup1.Location = new System.Drawing.Point(1, 1);
            this.ucPatientGroup1.Name = "ucPatientGroup1";
            this.ucPatientGroup1.onlyKlinikenUsr = false;
            this.ucPatientGroup1.Size = new System.Drawing.Size(214, 514);
            this.ucPatientGroup1.TabIndex = 3;
            this.ucPatientGroup1.typUI = PMDS.GUI.ucPatientGroup.eTypUI.main;
            this.ucPatientGroup1.SelectionChanged += new PMDS.GUI.GroupDelegate(this.ucPatientGroup1_SelectionChanged);
            this.ucPatientGroup1.klinikHasChanged += new PMDS.GUI.klinikChanged(this.ucPatientGroup1_klinikHasChanged);
            // 
            // lblNone
            // 
            this.lblNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance8.FontData.SizeInPoints = 9.5F;
            appearance8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNone.Appearance = appearance8;
            this.lblNone.AutoSize = true;
            this.lblNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance9.FontData.UnderlineAsString = "True";
            this.lblNone.HotTrackAppearance = appearance9;
            this.lblNone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNone.Location = new System.Drawing.Point(724, 11);
            this.lblNone.Name = "lblNone";
            this.lblNone.Size = new System.Drawing.Size(38, 16);
            this.lblNone.TabIndex = 113;
            this.lblNone.Tag = "1";
            this.lblNone.Text = "Keine";
            this.lblNone.UseAppStyling = false;
            this.lblNone.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblNone.Click += new System.EventHandler(this.lblNone_Click);
            // 
            // lblAll
            // 
            this.lblAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance10.FontData.SizeInPoints = 9.5F;
            appearance10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAll.Appearance = appearance10;
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            appearance11.FontData.UnderlineAsString = "True";
            this.lblAll.HotTrackAppearance = appearance11;
            this.lblAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAll.Location = new System.Drawing.Point(695, 11);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(27, 16);
            this.lblAll.TabIndex = 112;
            this.lblAll.Tag = "1";
            this.lblAll.Text = "Alle";
            this.lblAll.UseAppStyling = false;
            this.lblAll.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // ucPatientenmehrfachauswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNone);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.chkHistorie);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ucPatientGroup1);
            this.Controls.Add(this.lvPatients);
            this.Name = "ucPatientenmehrfachauswahl";
            this.Size = new System.Drawing.Size(770, 514);
            this.Load += new System.EventHandler(this.ucPatientenmehrfachauswahl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkHistorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ucPatientGroup ucPatientGroup1;
        public QS2.Desktop.ControlManagment.BaseButton btnAbort;
        public QS2.Desktop.ControlManagment.BaseButton btnOK;
        private QS2.Desktop.ControlManagment.BaseCheckBox chkHistorie;
        private QS2.Desktop.ControlManagment.BaseLabel lblFound;
        protected Infragistics.Win.UltraWinListView.UltraListView lvPatients;
        internal QS2.Desktop.ControlManagment.BaseLabel lblNone;
        internal QS2.Desktop.ControlManagment.BaseLabel lblAll;
    }
}
