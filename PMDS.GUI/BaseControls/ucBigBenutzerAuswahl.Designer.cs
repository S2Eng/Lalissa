namespace PMDS.GUI.BaseControls
{
    partial class ucBigBenutzerAuswahl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBigBenutzerAuswahl));
            this.btnBenutzer = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlAbtList = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnKorrektur = new QS2.Desktop.ControlManagment.BaseButton();
            this.btnAnmelden = new QS2.Desktop.ControlManagment.BaseButton();
            this.ucVKeyboardUniversal1 = new PMDS.GUI.BaseControls.ucVKeyboardUniversal();
            this.ultraLabel1 = new QS2.Desktop.ControlManagment.BaseLabel();
            this.tbKennwort = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.pnlBenutzer = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.labelPfleger = new QS2.Desktop.ControlManagment.BaseLableWin();
            this.pnlAbtList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKennwort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBenutzer
            // 
            appearance1.ForeColor = System.Drawing.Color.Blue;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.btnBenutzer.Appearance = appearance1;
            this.btnBenutzer.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnBenutzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBenutzer.ImageSize = new System.Drawing.Size(70, 70);
            this.btnBenutzer.Location = new System.Drawing.Point(0, 0);
            this.btnBenutzer.Name = "btnBenutzer";
            this.btnBenutzer.PopupItemKey = "pnlAbtList";
            this.btnBenutzer.PopupItemProvider = this.ultraPopupControlContainer1;
            this.btnBenutzer.ShowFocusRect = false;
            this.btnBenutzer.Size = new System.Drawing.Size(267, 147);
            this.btnBenutzer.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.btnBenutzer.TabIndex = 0;
            this.btnBenutzer.Text = "*********";
            this.btnBenutzer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnBenutzer.DroppingDown += new System.ComponentModel.CancelEventHandler(this.btnBenutzer_DroppingDown);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.pnlAbtList;
            this.ultraPopupControlContainer1.Opening += new System.ComponentModel.CancelEventHandler(this.ultraPopupControlContainer1_Opening);
            this.ultraPopupControlContainer1.Closed += new System.EventHandler(this.ultraPopupControlContainer1_Closed);
            // 
            // pnlAbtList
            // 
            this.pnlAbtList.AutoScroll = true;
            this.pnlAbtList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAbtList.Controls.Add(this.btnKorrektur);
            this.pnlAbtList.Controls.Add(this.btnAnmelden);
            this.pnlAbtList.Controls.Add(this.ucVKeyboardUniversal1);
            this.pnlAbtList.Controls.Add(this.ultraLabel1);
            this.pnlAbtList.Controls.Add(this.tbKennwort);
            this.pnlAbtList.Controls.Add(this.pnlBenutzer);
            this.pnlAbtList.Location = new System.Drawing.Point(161, 105);
            this.pnlAbtList.Name = "pnlAbtList";
            this.pnlAbtList.Size = new System.Drawing.Size(1024, 605);
            this.pnlAbtList.TabIndex = 1;
            this.pnlAbtList.Visible = false;
            // 
            // btnKorrektur
            // 
            this.btnKorrektur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKorrektur.AutoWorkLayout = false;
            this.btnKorrektur.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnKorrektur.Enabled = false;
            this.btnKorrektur.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKorrektur.IsStandardControl = false;
            this.btnKorrektur.Location = new System.Drawing.Point(755, 324);
            this.btnKorrektur.Name = "btnKorrektur";
            this.btnKorrektur.Size = new System.Drawing.Size(164, 53);
            this.btnKorrektur.TabIndex = 6;
            this.btnKorrektur.Text = "Korrektur";
            this.btnKorrektur.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnKorrektur.Click += new System.EventHandler(this.btnKorrektur_Click);
            // 
            // btnAnmelden
            // 
            this.btnAnmelden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnmelden.AutoWorkLayout = false;
            this.btnAnmelden.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.btnAnmelden.Enabled = false;
            this.btnAnmelden.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnmelden.IsStandardControl = false;
            this.btnAnmelden.Location = new System.Drawing.Point(755, 381);
            this.btnAnmelden.Name = "btnAnmelden";
            this.btnAnmelden.Size = new System.Drawing.Size(164, 158);
            this.btnAnmelden.TabIndex = 4;
            this.btnAnmelden.Text = "Anmelden";
            this.btnAnmelden.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnAnmelden.Click += new System.EventHandler(this.btnAnmelden_Click);
            // 
            // ucVKeyboardUniversal1
            // 
            this.ucVKeyboardUniversal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucVKeyboardUniversal1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVKeyboardUniversal1.Enabled = false;
            this.ucVKeyboardUniversal1.Location = new System.Drawing.Point(2, 324);
            this.ucVKeyboardUniversal1.Name = "ucVKeyboardUniversal1";
            this.ucVKeyboardUniversal1.Size = new System.Drawing.Size(924, 280);
            this.ucVKeyboardUniversal1.TabIndex = 5;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ultraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.ultraLabel1.Location = new System.Drawing.Point(129, 285);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(114, 37);
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Text = "Kennwort";
            // 
            // tbKennwort
            // 
            this.tbKennwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbKennwort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKennwort.Location = new System.Drawing.Point(249, 282);
            this.tbKennwort.MaxLength = 100;
            this.tbKennwort.Name = "tbKennwort";
            this.tbKennwort.PasswordChar = '*';
            this.tbKennwort.Size = new System.Drawing.Size(305, 38);
            this.tbKennwort.TabIndex = 2;
            this.tbKennwort.Enter += new System.EventHandler(this.tbKennwort_Enter);
            this.tbKennwort.Leave += new System.EventHandler(this.tbKennwort_Leave);
            // 
            // pnlBenutzer
            // 
            this.pnlBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBenutzer.AutoScroll = true;
            this.pnlBenutzer.Location = new System.Drawing.Point(0, 0);
            this.pnlBenutzer.Name = "pnlBenutzer";
            this.pnlBenutzer.Size = new System.Drawing.Size(1022, 273);
            this.pnlBenutzer.TabIndex = 0;
            // 
            // ultraFlowLayoutManager1
            // 
            this.ultraFlowLayoutManager1.ContainerControl = this.pnlBenutzer;
            this.ultraFlowLayoutManager1.HorizontalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
            this.ultraFlowLayoutManager1.VerticalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Near;
            // 
            // labelPfleger
            // 
            this.labelPfleger.AutoSize = true;
            this.labelPfleger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPfleger.Location = new System.Drawing.Point(4, 4);
            this.labelPfleger.Name = "labelPfleger";
            this.labelPfleger.Size = new System.Drawing.Size(51, 16);
            this.labelPfleger.TabIndex = 2;
            this.labelPfleger.Text = "Pfleger";
            // 
            // ucBigBenutzerAuswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.labelPfleger);
            this.Controls.Add(this.pnlAbtList);
            this.Controls.Add(this.btnBenutzer);
            this.Name = "ucBigBenutzerAuswahl";
            this.Size = new System.Drawing.Size(267, 147);
            this.pnlAbtList.ResumeLayout(false);
            this.pnlAbtList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKennwort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraDropDownButton btnBenutzer;
        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private QS2.Desktop.ControlManagment.BasePanel pnlAbtList;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
        private QS2.Desktop.ControlManagment.BasePanel pnlBenutzer;
        private QS2.Desktop.ControlManagment.BaseLabel ultraLabel1;
        private QS2.Desktop.ControlManagment.BaseTextEditor tbKennwort;
        private QS2.Desktop.ControlManagment.BaseButton btnAnmelden;
        private ucVKeyboardUniversal ucVKeyboardUniversal1;
        private QS2.Desktop.ControlManagment.BaseButton btnKorrektur;
        private QS2.Desktop.ControlManagment.BaseLableWin labelPfleger;
    }
}
