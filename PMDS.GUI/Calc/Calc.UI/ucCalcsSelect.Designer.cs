namespace PMDS.Calc.UI
{
    partial class ucCalcsSelect
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
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint2 = new Infragistics.Win.Layout.GridBagConstraint();
            this.ucCalcs1 = new PMDS.Calc.UI.ucCalcs();
            this.ucKlienten1 = new PMDS.GUI.ucKlienten();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.klientenLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGridBagLayoutPanel1 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.ultraGridBagLayoutPanel2 = new Infragistics.Win.Misc.UltraGridBagLayoutPanel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).BeginInit();
            this.ultraGridBagLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).BeginInit();
            this.ultraGridBagLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucCalcs1
            // 
            this.ucCalcs1.BackColor = System.Drawing.Color.Transparent;
            this.ucCalcs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both;
            this.ultraGridBagLayoutPanel2.SetGridBagConstraint(this.ucCalcs1, gridBagConstraint1);
            this.ucCalcs1.Location = new System.Drawing.Point(0, 0);
            this.ucCalcs1.Name = "ucCalcs1";
            this.ultraGridBagLayoutPanel2.SetPreferredSize(this.ucCalcs1, new System.Drawing.Size(395, 218));
            this.ucCalcs1.Size = new System.Drawing.Size(676, 504);
            this.ucCalcs1.TabIndex = 0;
            // 
            // ucKlienten1
            // 
            this.ucKlienten1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucKlienten1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucKlienten1.ContextMenuStrip = this.contextMenuStrip1;
            gridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both;
            gridBagConstraint2.Insets.Right = 5;
            this.ultraGridBagLayoutPanel1.SetGridBagConstraint(this.ucKlienten1, gridBagConstraint2);
            this.ucKlienten1.Location = new System.Drawing.Point(0, 0);
            this.ucKlienten1.Name = "ucKlienten1";
            this.ultraGridBagLayoutPanel1.SetPreferredSize(this.ucKlienten1, new System.Drawing.Size(179, 185));
            this.ucKlienten1.Size = new System.Drawing.Size(190, 504);
            this.ucKlienten1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klientenLadenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // klientenLadenToolStripMenuItem
            // 
            this.klientenLadenToolStripMenuItem.Name = "klientenLadenToolStripMenuItem";
            this.klientenLadenToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.klientenLadenToolStripMenuItem.Text = "Klienten laden";
            this.klientenLadenToolStripMenuItem.Click += new System.EventHandler(this.klientenLadenToolStripMenuItem_Click);
            // 
            // ultraGridBagLayoutPanel1
            // 
            this.ultraGridBagLayoutPanel1.Controls.Add(this.ucKlienten1);
            this.ultraGridBagLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGridBagLayoutPanel1.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel1.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridBagLayoutPanel1.Name = "ultraGridBagLayoutPanel1";
            this.ultraGridBagLayoutPanel1.Size = new System.Drawing.Size(195, 504);
            this.ultraGridBagLayoutPanel1.TabIndex = 2;
            // 
            // ultraGridBagLayoutPanel2
            // 
            this.ultraGridBagLayoutPanel2.Controls.Add(this.ucCalcs1);
            this.ultraGridBagLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGridBagLayoutPanel2.ExpandToFitHeight = true;
            this.ultraGridBagLayoutPanel2.ExpandToFitWidth = true;
            this.ultraGridBagLayoutPanel2.Location = new System.Drawing.Point(195, 0);
            this.ultraGridBagLayoutPanel2.Name = "ultraGridBagLayoutPanel2";
            this.ultraGridBagLayoutPanel2.Size = new System.Drawing.Size(676, 504);
            this.ultraGridBagLayoutPanel2.TabIndex = 3;
            // 
            // ucCalcsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.ultraGridBagLayoutPanel2);
            this.Controls.Add(this.ultraGridBagLayoutPanel1);
            this.Name = "ucCalcsSelect";
            this.Size = new System.Drawing.Size(871, 504);
            this.Load += new System.EventHandler(this.ucCalcsSelect_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel1)).EndInit();
            this.ultraGridBagLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutPanel2)).EndInit();
            this.ultraGridBagLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PMDS.GUI.ucKlienten ucKlienten1;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel2;
        private Infragistics.Win.Misc.UltraGridBagLayoutPanel ultraGridBagLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem klientenLadenToolStripMenuItem;
        public ucCalcs ucCalcs1;
    }
}
