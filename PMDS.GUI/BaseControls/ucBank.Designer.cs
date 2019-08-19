namespace PMDS.GUI.BaseControls
{
    partial class ucBank
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
            this.txtName = new QS2.Desktop.ControlManagment.BaseTextEditor();
            this.lblName = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblKontoNummer = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBLZ = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblIBAN = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblBIC = new QS2.Desktop.ControlManagment.BaseLabel();
            this.txtKontoNr = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtBLZ = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtIBAN = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.txtBIC = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(116, 5);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(397, 24);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 9);
            this.lblName.Margin = new System.Windows.Forms.Padding(4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name der Bank";
            // 
            // lblKontoNummer
            // 
            this.lblKontoNummer.AutoSize = true;
            this.lblKontoNummer.Location = new System.Drawing.Point(4, 105);
            this.lblKontoNummer.Margin = new System.Windows.Forms.Padding(4);
            this.lblKontoNummer.Name = "lblKontoNummer";
            this.lblKontoNummer.Size = new System.Drawing.Size(91, 17);
            this.lblKontoNummer.TabIndex = 4;
            this.lblKontoNummer.Text = "Kontonummer";
            // 
            // lblBLZ
            // 
            this.lblBLZ.AutoSize = true;
            this.lblBLZ.Location = new System.Drawing.Point(4, 136);
            this.lblBLZ.Margin = new System.Windows.Forms.Padding(4);
            this.lblBLZ.Name = "lblBLZ";
            this.lblBLZ.Size = new System.Drawing.Size(30, 17);
            this.lblBLZ.TabIndex = 5;
            this.lblBLZ.Text = "BLZ";
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(4, 41);
            this.lblIBAN.Margin = new System.Windows.Forms.Padding(4);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(37, 17);
            this.lblIBAN.TabIndex = 6;
            this.lblIBAN.Text = "IBAN";
            // 
            // lblBIC
            // 
            this.lblBIC.AutoSize = true;
            this.lblBIC.Location = new System.Drawing.Point(4, 73);
            this.lblBIC.Margin = new System.Windows.Forms.Padding(4);
            this.lblBIC.Name = "lblBIC";
            this.lblBIC.Size = new System.Drawing.Size(28, 17);
            this.lblBIC.TabIndex = 7;
            this.lblBIC.Text = "BIC";
            // 
            // txtKontoNr
            // 
            appearance1.TextHAlignAsString = "Left";
            this.txtKontoNr.Appearance = appearance1;
            this.txtKontoNr.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtKontoNr.Location = new System.Drawing.Point(116, 101);
            this.txtKontoNr.Margin = new System.Windows.Forms.Padding(4);
            this.txtKontoNr.Name = "txtKontoNr";
            this.txtKontoNr.NonAutoSizeHeight = 20;
            this.txtKontoNr.PromptChar = ' ';
            this.txtKontoNr.Size = new System.Drawing.Size(176, 23);
            this.txtKontoNr.TabIndex = 4;
            this.txtKontoNr.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtBLZ
            // 
            appearance2.TextHAlignAsString = "Left";
            this.txtBLZ.Appearance = appearance2;
            this.txtBLZ.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer;
            this.txtBLZ.Location = new System.Drawing.Point(116, 132);
            this.txtBLZ.Margin = new System.Windows.Forms.Padding(4);
            this.txtBLZ.Name = "txtBLZ";
            this.txtBLZ.NonAutoSizeHeight = 20;
            this.txtBLZ.PromptChar = ' ';
            this.txtBLZ.Size = new System.Drawing.Size(105, 23);
            this.txtBLZ.TabIndex = 5;
            this.txtBLZ.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtIBAN
            // 
            this.txtIBAN.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtIBAN.InputMask = ">A>A## #### #### #### ####";
            this.txtIBAN.Location = new System.Drawing.Point(116, 39);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.NonAutoSizeHeight = 23;
            this.txtIBAN.Size = new System.Drawing.Size(176, 23);
            this.txtIBAN.TabIndex = 2;
            this.txtIBAN.Text = "AT    ";
            this.txtIBAN.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txtBIC
            // 
            this.txtBIC.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtBIC.InputMask = ">A>A>A>A>A>A>A>A>A>A>A";
            this.txtBIC.Location = new System.Drawing.Point(116, 69);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.NonAutoSizeHeight = 23;
            this.txtBIC.Size = new System.Drawing.Size(176, 23);
            this.txtBIC.TabIndex = 3;
            this.txtBIC.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // ucBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBIC);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.txtBLZ);
            this.Controls.Add(this.txtKontoNr);
            this.Controls.Add(this.lblBIC);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.lblBLZ);
            this.Controls.Add(this.lblKontoNummer);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucBank";
            this.Size = new System.Drawing.Size(517, 161);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS2.Desktop.ControlManagment.BaseTextEditor txtName;
        private QS2.Desktop.ControlManagment.BaseLabel lblName;
        private QS2.Desktop.ControlManagment.BaseLabel lblKontoNummer;
        private QS2.Desktop.ControlManagment.BaseLabel lblBLZ;
        private QS2.Desktop.ControlManagment.BaseLabel lblIBAN;
        private QS2.Desktop.ControlManagment.BaseLabel lblBIC;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtKontoNr;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtBLZ;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtIBAN;
        private QS2.Desktop.ControlManagment.BaseMaskEdit txtBIC;
    }
}
