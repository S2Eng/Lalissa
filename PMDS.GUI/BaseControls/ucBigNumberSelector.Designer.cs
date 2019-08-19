namespace PMDS.GUI.BaseControls
{
    partial class ucBigNumberSelector
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
            this.tbNumber = new QS2.Desktop.ControlManagment.BaseMaskEdit();
            this.pop1 = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
            this.pnlNumbers = new QS2.Desktop.ControlManagment.BasePanel();
            this.ultraFlowLayoutManager1 = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumber
            // 
            appearance1.BorderColor = System.Drawing.Color.Gainsboro;
            appearance1.FontData.SizeInPoints = 24F;
            appearance1.TextHAlignAsString = "Right";
            this.tbNumber.Appearance = appearance1;
            this.tbNumber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tbNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.tbNumber.InputMask = "99";
            this.tbNumber.Location = new System.Drawing.Point(0, 0);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.NonAutoSizeHeight = 44;
            this.tbNumber.PromptChar = ' ';
            this.tbNumber.Size = new System.Drawing.Size(164, 44);
            this.tbNumber.TabIndex = 21;
            this.tbNumber.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tbNumber.MaskChanged += new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit.MaskChangedEventHandler(this.tbNumber_MaskChanged);
            this.tbNumber.ValueChanged += new System.EventHandler(this.tbNumber_ValueChanged);
            this.tbNumber.Click += new System.EventHandler(this.tbNumber_Click);
            this.tbNumber.DoubleClick += new System.EventHandler(this.tbNumber_DoubleClick);
            this.tbNumber.Enter += new System.EventHandler(this.tbNumber_Enter);
            // 
            // pop1
            // 
            this.pop1.PopupControl = this.pnlNumbers;
            // 
            // pnlNumbers
            // 
            this.pnlNumbers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNumbers.Location = new System.Drawing.Point(57, 12);
            this.pnlNumbers.Name = "pnlNumbers";
            this.pnlNumbers.Size = new System.Drawing.Size(200, 100);
            this.pnlNumbers.TabIndex = 22;
            this.pnlNumbers.Visible = false;
            // 
            // ultraFlowLayoutManager1
            // 
            this.ultraFlowLayoutManager1.ContainerControl = this.pnlNumbers;
            // 
            // ucBigNumberSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlNumbers);
            this.Controls.Add(this.tbNumber);
            this.Name = "ucBigNumberSelector";
            this.Size = new System.Drawing.Size(164, 52);
            ((System.ComponentModel.ISupportInitialize)(this.ultraFlowLayoutManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.Misc.UltraPopupControlContainer pop1;
        private QS2.Desktop.ControlManagment.BasePanel pnlNumbers;
        private Infragistics.Win.Misc.UltraFlowLayoutManager ultraFlowLayoutManager1;
        public QS2.Desktop.ControlManagment.BaseMaskEdit tbNumber;
    }
}
