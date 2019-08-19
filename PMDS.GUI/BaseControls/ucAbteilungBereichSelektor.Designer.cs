namespace PMDS.GUI.BaseControls
{
    partial class ucAbteilungBereichSelektor
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
            this.ultraDropDownButton1 = new Infragistics.Win.Misc.UltraDropDownButton();
            this.ultraPopupControlContainer1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.ucPatientGroup1 = new PMDS.GUI.ucPatientGroup();
            this.SuspendLayout();
            // 
            // ultraDropDownButton1
            // 
            this.ultraDropDownButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            appearance1.TextHAlignAsString = "Left";
            this.ultraDropDownButton1.Appearance = appearance1;
            this.ultraDropDownButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
            this.ultraDropDownButton1.Location = new System.Drawing.Point(0, 0);
            this.ultraDropDownButton1.Name = "ultraDropDownButton1";
            this.ultraDropDownButton1.PopupItemKey = "ucPatientGroup1";
            this.ultraDropDownButton1.PopupItemProvider = this.ultraPopupControlContainer1;
            this.ultraDropDownButton1.Size = new System.Drawing.Size(176, 26);
            this.ultraDropDownButton1.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly;
            this.ultraDropDownButton1.TabIndex = 0;
            this.ultraDropDownButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraDropDownButton1.ClosedUp += new System.EventHandler(this.ultraDropDownButton1_ClosedUp);
            this.ultraDropDownButton1.Click += new System.EventHandler(this.ultraDropDownButton1_Click);
            // 
            // ultraPopupControlContainer1
            // 
            this.ultraPopupControlContainer1.PopupControl = this.ucPatientGroup1;
            this.ultraPopupControlContainer1.Opened += new System.EventHandler(this.ultraPopupControlContainer1_Opened);
            // 
            // ucPatientGroup1
            // 
            this.ucPatientGroup1.allKliniken = false;
            this.ucPatientGroup1.BackColor = System.Drawing.Color.Gainsboro;
            this.ucPatientGroup1.ENVAbteilung = false;
            this.ucPatientGroup1.Location = new System.Drawing.Point(0, 26);
            this.ucPatientGroup1.Name = "ucPatientGroup1";
            this.ucPatientGroup1.onlyKlinikenUsr = false;
            this.ucPatientGroup1.Size = new System.Drawing.Size(270, 248);
            this.ucPatientGroup1.TabIndex = 1;
            this.ucPatientGroup1.typUI = PMDS.GUI.ucPatientGroup.eTypUI.sub;
            this.ucPatientGroup1.Visible = false;
            this.ucPatientGroup1.DoubleClick += new System.EventHandler(this.ucPatientGroup1_DoubleClick);
            this.ucPatientGroup1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPatientGroup1_KeyDown);
            // 
            // ucAbteilungBereichSelektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ultraDropDownButton1);
            this.Controls.Add(this.ucPatientGroup1);
            this.Name = "ucAbteilungBereichSelektor";
            this.Size = new System.Drawing.Size(176, 26);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucAbteilungBereichSelektor_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPopupControlContainer ultraPopupControlContainer1;
        private Infragistics.Win.Misc.UltraDropDownButton ultraDropDownButton1;
        public ucPatientGroup ucPatientGroup1;
    }
}
