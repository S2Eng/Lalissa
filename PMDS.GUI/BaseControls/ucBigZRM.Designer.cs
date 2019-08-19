namespace PMDS.GUI.BaseControls
{
    partial class ucBigZRM
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.panel1 = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblMain = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panel2 = new QS2.Desktop.ControlManagment.BasePanel();
            this.tbMain = new PMDS.GUI.BaseControls.ucBigTextEditor();
            this.cbMain = new PMDS.GUI.BaseControls.ucBigComboBox();
            this.nbMain = new PMDS.GUI.BaseControls.ucBigNumberSelector();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.lblMain);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 200);
            this.panel1.TabIndex = 3;
            // 
            // lblMain
            // 
            this.lblMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblMain.Appearance = appearance2;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(3, 3);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(261, 194);
            this.lblMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbMain);
            this.panel2.Controls.Add(this.cbMain);
            this.panel2.Controls.Add(this.nbMain);
            this.panel2.Location = new System.Drawing.Point(273, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 200);
            this.panel2.TabIndex = 4;
            // 
            // tbMain
            // 
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMain.Location = new System.Drawing.Point(0, 97);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(364, 49);
            this.tbMain.TabIndex = 2;
            // 
            // cbMain
            // 
            this.cbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbMain.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.cbMain.ID = System.Guid.Empty;
            this.cbMain.Location = new System.Drawing.Point(0, 46);
            this.cbMain.Name = "cbMain";
            this.cbMain.PlayClickSound = true;
            this.cbMain.SelectedItem = null;
            this.cbMain.Size = new System.Drawing.Size(364, 51);
            this.cbMain.TabIndex = 0;
            // 
            // nbMain
            // 
            this.nbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.nbMain.Location = new System.Drawing.Point(0, 0);
            this.nbMain.Name = "nbMain";
            this.nbMain.PromptChar = ' ';
            this.nbMain.Size = new System.Drawing.Size(364, 46);
            this.nbMain.TabIndex = 1;
            this.nbMain.Value = "";
            this.nbMain.Load += new System.EventHandler(this.nbMain_Load);
            // 
            // ucBigZRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucBigZRM";
            this.Size = new System.Drawing.Size(637, 200);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBigComboBox cbMain;
        private ucBigNumberSelector nbMain;
        private ucBigTextEditor tbMain;
        private QS2.Desktop.ControlManagment.BasePanel panel1;
        private QS2.Desktop.ControlManagment.BasePanel panel2;
        private QS2.Desktop.ControlManagment.BaseLabel lblMain;
    }
}
