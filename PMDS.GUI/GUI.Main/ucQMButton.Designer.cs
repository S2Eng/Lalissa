namespace PMDS.GUI
{
    partial class ucQMButton
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.pnlButtons = new QS2.Desktop.ControlManagment.BasePanel();
            this.lblMain = new QS2.Desktop.ControlManagment.BaseLabel();
            this.lblZeitbereich = new QS2.Desktop.ControlManagment.BaseLabel();
            this.panelOben = new QS2.Desktop.ControlManagment.BasePanel();
            this.btnFocus = new QS2.Desktop.ControlManagment.BaseButton();
            this.panelUnten = new QS2.Desktop.ControlManagment.BasePanel();
            this.panelOben.SuspendLayout();
            this.panelUnten.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(172, 97);
            this.pnlButtons.TabIndex = 0;
            // 
            // lblMain
            // 
            appearance1.TextHAlignAsString = "Center";
            this.lblMain.Appearance = appearance1;
            this.lblMain.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.lblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(0, 0);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(172, 85);
            this.lblMain.TabIndex = 1;
            this.lblMain.Text = "Inkontinenzproduktwechsel";
            this.lblMain.DoubleClick += new System.EventHandler(this.lblMain_DoubleClick);
            this.lblMain.Click += new System.EventHandler(this.lblMain_Click);
            // 
            // lblZeitbereich
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblZeitbereich.Appearance = appearance2;
            this.lblZeitbereich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblZeitbereich.Location = new System.Drawing.Point(0, 57);
            this.lblZeitbereich.Name = "lblZeitbereich";
            this.lblZeitbereich.Size = new System.Drawing.Size(172, 40);
            this.lblZeitbereich.TabIndex = 2;
            this.lblZeitbereich.Text = "***";
            this.lblZeitbereich.DoubleClick += new System.EventHandler(this.lblZeitbereich_DoubleClick);
            this.lblZeitbereich.Click += new System.EventHandler(this.lblZeitbereich_Click);
            // 
            // panelOben
            // 
            this.panelOben.Controls.Add(this.lblMain);
            this.panelOben.Controls.Add(this.btnFocus);
            this.panelOben.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOben.Location = new System.Drawing.Point(0, 0);
            this.panelOben.Name = "panelOben";
            this.panelOben.Size = new System.Drawing.Size(172, 85);
            this.panelOben.TabIndex = 3;
            // 
            // btnFocus
            // 
            this.btnFocus.Location = new System.Drawing.Point(68, 31);
            this.btnFocus.Name = "btnFocus";
            this.btnFocus.Size = new System.Drawing.Size(27, 13);
            this.btnFocus.TabIndex = 2;
            // 
            // panelUnten
            // 
            this.panelUnten.BackColor = System.Drawing.Color.Transparent;
            this.panelUnten.Controls.Add(this.lblZeitbereich);
            this.panelUnten.Controls.Add(this.pnlButtons);
            this.panelUnten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnten.Location = new System.Drawing.Point(0, 85);
            this.panelUnten.Name = "panelUnten";
            this.panelUnten.Size = new System.Drawing.Size(172, 97);
            this.panelUnten.TabIndex = 4;
            this.panelUnten.DoubleClick += new System.EventHandler(this.panelUnten_DoubleClick);
            this.panelUnten.Click += new System.EventHandler(this.panelUnten_Click);
            // 
            // ucQMButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelUnten);
            this.Controls.Add(this.panelOben);
            this.Name = "ucQMButton";
            this.Size = new System.Drawing.Size(172, 182);
            this.panelOben.ResumeLayout(false);
            this.panelUnten.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private QS2.Desktop.ControlManagment.BasePanel pnlButtons;
        private QS2.Desktop.ControlManagment.BaseLabel lblMain;
        private QS2.Desktop.ControlManagment.BaseLabel lblZeitbereich;
        private QS2.Desktop.ControlManagment.BasePanel panelOben;
        private QS2.Desktop.ControlManagment.BasePanel panelUnten;
        public QS2.Desktop.ControlManagment.BaseButton btnFocus;
    }
}
