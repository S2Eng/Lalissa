namespace PMDS.GUI.BaseControls
{
    partial class ucKlinikCbo
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
            this.cbKlinik = new QS2.Desktop.ControlManagment.BaseComboEditor();
            this.lblEinrichtung = new QS2.Desktop.ControlManagment.BaseLabel();
            this.contextMenuStripCboKlinik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klinikenNeuLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleKlinikenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).BeginInit();
            this.contextMenuStripCboKlinik.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbKlinik
            // 
            this.cbKlinik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKlinik.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            this.cbKlinik.ContextMenuStrip = this.contextMenuStripCboKlinik;
            this.cbKlinik.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKlinik.Location = new System.Drawing.Point(1, 17);
            this.cbKlinik.Name = "cbKlinik";
            this.cbKlinik.Size = new System.Drawing.Size(235, 21);
            this.cbKlinik.TabIndex = 119;
            this.cbKlinik.TabStop = false;
            this.cbKlinik.ValueChanged += new System.EventHandler(this.cbKlinik_ValueChanged);
            // 
            // lblEinrichtung
            // 
            this.lblEinrichtung.Location = new System.Drawing.Point(0, 3);
            this.lblEinrichtung.Name = "lblEinrichtung";
            this.lblEinrichtung.Size = new System.Drawing.Size(114, 15);
            this.lblEinrichtung.TabIndex = 120;
            this.lblEinrichtung.Text = "Einrichtung";
            // 
            // contextMenuStripCboKlinik
            // 
            this.contextMenuStripCboKlinik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klinikenNeuLadenToolStripMenuItem,
            this.alleKlinikenLadenToolStripMenuItem});
            this.contextMenuStripCboKlinik.Name = "contextMenuStrip1";
            this.contextMenuStripCboKlinik.Size = new System.Drawing.Size(318, 48);
            // 
            // klinikenNeuLadenToolStripMenuItem
            // 
            this.klinikenNeuLadenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
            this.klinikenNeuLadenToolStripMenuItem.Name = "klinikenNeuLadenToolStripMenuItem";
            this.klinikenNeuLadenToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.klinikenNeuLadenToolStripMenuItem.Text = "Einrichtungen des angemeldeten Benutzers neu laden";
            this.klinikenNeuLadenToolStripMenuItem.Click += new System.EventHandler(this.klinikenNeuLadenToolStripMenuItem_Click);
            // 
            // alleKlinikenLadenToolStripMenuItem
            // 
            this.alleKlinikenLadenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
            this.alleKlinikenLadenToolStripMenuItem.Name = "alleKlinikenLadenToolStripMenuItem";
            this.alleKlinikenLadenToolStripMenuItem.Size = new System.Drawing.Size(317, 22);
            this.alleKlinikenLadenToolStripMenuItem.Text = "Alle Einrichtungen neu laden";
            this.alleKlinikenLadenToolStripMenuItem.Click += new System.EventHandler(this.alleKlinikenLadenToolStripMenuItem_Click);
            // 
            // ucKlinikCbo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbKlinik);
            this.Controls.Add(this.lblEinrichtung);
            this.Name = "ucKlinikCbo";
            this.Size = new System.Drawing.Size(239, 42);
            ((System.ComponentModel.ISupportInitialize)(this.cbKlinik)).EndInit();
            this.contextMenuStripCboKlinik.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Infragistics.Win.UltraWinEditors.UltraComboEditor cbKlinik;
        private QS2.Desktop.ControlManagment.BaseLabel lblEinrichtung;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCboKlinik;
        private System.Windows.Forms.ToolStripMenuItem klinikenNeuLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleKlinikenLadenToolStripMenuItem;
    }
}
